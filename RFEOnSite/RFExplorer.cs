using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RFEOnSite
{
    public partial class RFExplorer
    {
        private static List<string> mReceivedSweep;
        private RFEConfiguration mRFEConfiguration;
        private SerialPorts mSerialPort;
        private Thread mReceiveThread;
        private bool mCapture;
        private bool mConfigured;
        private int mSweepCount;

        public int SweepCount { get { return mSweepCount; } set { mSweepCount = value; } }
        public bool Capture { get { return mCapture; } set { mCapture = value; } }
        public List<string> SweepData { get { return mReceivedSweep; } }



        public RFExplorer()
        {
            mSerialPort = new SerialPorts();
            mReceivedSweep = new List<string>();
            mRFEConfiguration = new RFEConfiguration();
            mSweepCount = 0;
            mConfigured = false;
            mCapture = false;
        }

        public void InitializeSerialConnection(IProgress<string> UpdateUIComPortText)
        {
            mSerialPort.FindSerialPorts();

            mSerialPort.ConnectPort();

            UpdateUIComPortText.Report(mSerialPort.ConnectedPortName);
        }

        public void AttachSerialPortAndReceiveDataThread(IProgress<RFEConfiguration> configurationData, IProgress<List<string>> sweepData, IProgress<int> nProgress)
        {
            //Start listening to data from the RF Explorer
            mReceiveThread = new Thread(() => ReceiveThread(configurationData, sweepData, nProgress));
            mReceiveThread.Start();
        }

        public void SendConfiguration(double startMHz, double stopMHz, int amplitudeTop = -30, int amplitudeBottom = -110)
        {
            string start;
            string stop;
            string top;
            string bottom;

            mCapture = false;
            mConfigured = false;

            mReceivedSweep.Clear();

            start = (startMHz * 1000.0).ToString("0000000");
            stop = (stopMHz * 1000.0).ToString("0000000");
            top = amplitudeTop.ToString("000");
            bottom = amplitudeBottom.ToString("000");


            //mSerialPort.SendCommand("CH"); // Hold Data

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

            // Send final configuration and wait for the Explorer to return with configuration data
            mSerialPort.SendCommand("C2-F:" + start + "'" + stop + "," + top + "," + bottom);
            mSerialPort.SendCommand("C0"); // Request Config Data

        }
        public void RequestConfiguration()
        {
            mSerialPort.SendCommand("C0"); // Request Config Data
        }

        private void ReceiveThread(IProgress<RFEConfiguration> configurationProgress,
                                    IProgress<List<string>> sweepData,
                                    IProgress<int> progressBarProgress)

        {
            string sNewLine = String.Empty;
            string sLeftOver = String.Empty;
            string sReceived = "";

            while (mSerialPort.RFEConnected)
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

                    string caption = "RF Explorer Serial Communications";
                    string message = "Serial communication with the RF Explorer appears to be unreliable.\nCheck or replace the USB cable.";
                    MessageBox.Show(message, caption);

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
                                    //Sweep until count is zero
                                    progressBarProgress.Report(mSweepCount);
                                    mReceivedSweep.Add(sNewLine);
                                    mSweepCount--;

                                    if (mSweepCount == 0)
                                    {
                                        mCapture = false;
                                        sReceived = "";
                                        sNewText = "";
                                        sweepData.Report(mReceivedSweep);
                                        progressBarProgress.Report(0);
                                    }
                                }
                                //else
                                //{
                                //    // Sweeping is now done so stop and report results using two Progress callbacks.
                                //    mCapture = false;
                                //    sReceived = "";
                                //    sNewText = "";
                                //    sweepData.Report(mReceivedSweep);
                                //    progressBarProgress.Report(0);
                                //}
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

                            // Now actually Update UI thread with configuration information 
                            // that was obtained from the RF Explorer in this thread 
                            configurationProgress.Report(mRFEConfiguration); // This is not blocking and falls through. It "calls" the UI thread
                            mReceivedSweep.Clear();
                            sReceived = "";
                            sNewText = "";
                            sNewLine = "";
                            mConfigured = true;
                        }
                    }
                }

                Thread.Sleep(10);
            }
        }
    }
}
