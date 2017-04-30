using RFEOnSite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace RFEOnsite
{

    public partial class RFExplorer
    {
        private static Queue<string> mReceivedData;
        private RFEConfiguration mRFEConfiguration;
        private SerialCommunications mSerialPort;
        private Thread mReceiveThread;
        private bool mCapture = false;
        private bool mConfigured = false;
        private int nSweepCount;
        volatile private bool mbRunReceiveThread;

        private static Charts mChart;



        public int SweepCount { get { return nSweepCount; } set { nSweepCount = value; } }
        public Queue<string> SweepData { get { return mReceivedData; } }
        public bool Capture { get { return mCapture; } set { mCapture = value; } }

        public Queue<string> ReceivedData { get { return mReceivedData; } }


        public RFExplorer()
        {
            mSerialPort = new SerialCommunications();
            mReceivedData = new Queue<string>();
            mRFEConfiguration = new RFEConfiguration();
            nSweepCount = 0;

            mChart = new Charts();
        }

        public void UpdateUI(IProgress<string> progress)
        {
            progress.Report(mSerialPort.ConnectedPortName);
        }

        public void Initialize(IProgress<string> progress)
        {
            mSerialPort.FindSerialPorts();

            mSerialPort.ConnectPort();

            progress.Report(mSerialPort.ConnectedPortName);

        }

        public void Configuration(IProgress<RFEConfiguration> progress)
        {
            //Start listening to data from the RF Explorer
            mbRunReceiveThread = true;
            mReceiveThread = new Thread(() => ReceiveThreadfunc(progress));
            mReceiveThread.Start();
        }

        public void SetConfiguration(double startMHz, double stopMHz, int amplitudeTop = 0, int amplitudeBottom = -110)
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

            mReceivedData.Clear();

            if (startMHz >= 4850)
            {
                mSerialPort.SendCommand("CM\x0");
            }
            else
            {
                mSerialPort.SendCommand("CM\x1");
            }

            mSerialPort.SendCommand("C2-F:" + start + "'" + stop + "," + top + "," + bottom);

            mConfigured = true;
        }

        private void ReceiveThreadfunc(IProgress<RFEConfiguration> progress)
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
                    catch (Exception obExeption) { }
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
                                    if (nSweepCount > 0)
                                    {
                                        mReceivedData.Enqueue(sNewLine);
                                        nSweepCount--;
                                    }
                                    else
                                    {
                                        mRFEConfiguration.ParseSweepData();
                                    }
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
                                mRFEConfiguration.ParseCurrentSetup(sNewLine);
                            }
                            // Look for Configuration string 
                            if ((sNewLine.StartsWith("#C2-F:")) && (sNewLine.Length == 81))
                            {
                                mRFEConfiguration.ParseConfigurationString(sNewLine);
                                progress.Report(mRFEConfiguration);
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
