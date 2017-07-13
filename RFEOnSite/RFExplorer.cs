using RFEOnSite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFEOnsite
{

    public partial class RFExplorer
    {
        private static List<string> mReceivedSweep;
        private RFEConfiguration mRFEConfiguration;
        private SerialPorts mSerialPort;
        private Thread mReceiveThread;
        private bool mCapture = false;
        private bool mConfigured = false;
        private int mSweepCount;
        private bool mbWriteCsvFiles;
        volatile private bool mbRunReceiveThread;
        public CsvExport mCsvExport;

        

        public int SweepCount { get { return mSweepCount; } set { mSweepCount = value; } }
        public bool Capture { get { return mCapture; } set { mCapture = value; } }
        public List<string> SweepData { get { return mReceivedSweep; } }
        public bool WriteCsvFiles { get { return mbWriteCsvFiles; } set { mbWriteCsvFiles = value; } }

        
        public RFExplorer()
        {
            mSerialPort = new SerialPorts();
            mReceivedSweep = new List<string>();
            mRFEConfiguration = new RFEConfiguration();
            mSweepCount = 0;
            mCsvExport = new CsvExport();
            mbWriteCsvFiles = false;
        }

        public void InitializeSerialConnection(IProgress<string> UpdateUIComPortText)
        {
            mSerialPort.FindSerialPorts();

            mSerialPort.ConnectPort();

            UpdateUIComPortText.Report(mSerialPort.ConnectedPortName);
        }

        public void AttachSerialPortAndReceiveDataThread(IProgress<RFEConfiguration> configurationData, IProgress<Series> series, IProgress<CsvExport> csvExport, IProgress<int> nProgress)
        {
            //Start listening to data from the RF Explorer
            mbRunReceiveThread = true;
            mReceiveThread = new Thread(() => ReceiveThread(configurationData, series, nProgress, csvExport));
            mReceiveThread.Start();
        }

        public void SendConfiguration(double startMHz, double stopMHz, int amplitudeTop = 0, int amplitudeBottom = -110)
        {
            string start;
            string stop;
            string top;
            string bottom;

            mCapture = false;
            mConfigured = false;

            start = (startMHz * 1000.0).ToString("0000000");
            stop = (stopMHz * 1000.0).ToString("0000000");
            top = (amplitudeTop * 1000.0).ToString("0000");
            bottom = (amplitudeBottom * 1000.0).ToString("0000");

            mReceivedSweep.Clear();

            // Select Proper RFE antenna Port
            if (startMHz >= 4850)
            {
                mSerialPort.SendCommand("CM\x0"); // Left Antenna Port 
                mSerialPort.SendCommand("Cp\x2"); // DSP Filter Mode- Fast
            }
            else
            {
                mSerialPort.SendCommand("CM\x1"); // Right Antenna Port
                mSerialPort.SendCommand("Cp\x1"); // DSP Filter Mode- Only available on right: 15 to 2700 MHz 
            }

            // Make sure Offset is zero
            mSerialPort.SendCommand("CO\x0");


            // Reset Max Hold
            mSerialPort.SendCommand("C+\x1"); // Calculator Mode -  

            mSerialPort.SendCommand("C2-F:" + start + "'" + stop + "," + top + "," + bottom);

            mConfigured = true;
        }

        private void ReceiveThread( IProgress<RFEConfiguration> configurationProgress, 
                                    IProgress<Series> seriesProgress, 
                                    IProgress<int> progressBarProgress, 
                                    IProgress<CsvExport> csvExportProgress)
        {
            string sNewLine = String.Empty;
            string sLeftOver = String.Empty;

            while (mbRunReceiveThread)
            {
                string sReceived = "";

                while (mSerialPort.RFEConnected && mbRunReceiveThread)
                {
                    string sNewText = "";

                    try
                    {
                        Monitor.Enter(mSerialPort);
                        if (mSerialPort.Port.IsOpen && mSerialPort.Port.BytesToRead > 0)
                        {
                            sNewText = mSerialPort.Port.ReadExisting();
                        }
                    }
                    catch (IOException) { }
                    catch (TimeoutException) { }
                    catch (Exception) { }
                    finally
                    {
                        Monitor.Exit(mSerialPort);
                    }

                    if (sNewText.Length > 0)
                    {
                        sReceived += sNewText;
                        sNewText = "";
                    }

                    if (sReceived.Length > 66 * 1024)
                    {
                        //Safety code, some error prevented the string from being processed in several loop cycles. Reset it.
                        sReceived = "";
                    }

                    if (sReceived.Length > 0)
                    {
                        if (mConfigured && mCapture)
                        {
                            if (sNewLine.StartsWith("$S"))
                            {
                                if (sNewLine.Length == 115)
                                {
                                    if (mSweepCount > 0)
                                    {
                                        progressBarProgress.Report(mSweepCount);
                                        mReceivedSweep.Add(sNewLine);
                                        mSweepCount--;
                                        //sNewLine = String.Empty;
                                    }
                                    else
                                    {
                                        mCapture = false;
                                        progressBarProgress.Report(mSweepCount);
                                        mRFEConfiguration.ParseChartSeriesFromExplorer(seriesProgress);

                                        if (WriteCsvFiles)
                                        {
                                            mRFEConfiguration.ParseCsvDataFromExplorer(csvExportProgress);
                                        }
                                        mReceivedSweep.Clear();
                                    }

                                    //continue;
                                }
                            }
                        }

                        // Ensure we have an EOL terminated string
                        int nEndPos = sReceived.IndexOf("\r\n");
                        if (nEndPos >= 0)
                        {
                            sNewLine = sReceived.Substring(0, nEndPos);
                            sLeftOver = sReceived.Substring(nEndPos + 2);
                            sReceived = sLeftOver;

                            if ((sNewLine.StartsWith("#Sn")) && (sNewLine.Length == 19))
                            {
                                mRFEConfiguration.ParseSerialNumber(sNewLine);
                            }

                            if ((sNewLine.StartsWith("#C2-M:")) && (sNewLine.Length == 19))
                            {
                                mRFEConfiguration.ParseModelAndVersion(sNewLine);
                            }
                            // Look for Configuration string 
                            if ((sNewLine.StartsWith("#C2-F:")) && (sNewLine.Length == 81))
                            {
                                mRFEConfiguration.ParseConfiguration(sNewLine);
                                configurationProgress.Report(mRFEConfiguration);
                                mConfigured = true;
                            }
                        }
                    }

                    Thread.Sleep(10);
                }

                Thread.Sleep(500);
            }
        }
    }
}
