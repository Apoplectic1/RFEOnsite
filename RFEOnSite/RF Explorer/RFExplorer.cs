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
        private bool mConfigured;
        private bool mSecondReturnedConfiguration; // For synchornization
        private bool mFirstRetunedConfiguration;  // For synchornization

        public int SweepCount { get; set; }
        public bool Capture { get; set; }
        public bool WaitingForConfigurationCallBack { get; set; }
        public bool SweepValueStable { get; set; } = false;
        public bool Force2400Baud { get; set; } = false;

        public RFExplorer()
        {
            mSerialPort = new SerialPorts();
            mReceivedSweep = new List<string>();
            mRFEConfiguration = new RFEConfiguration();
            SweepCount = 0;
            mConfigured = false;
            Capture = false;
            mSecondReturnedConfiguration = false;
            mFirstRetunedConfiguration = false;
            WaitingForConfigurationCallBack = true;
        }

        //Background Thread to find and connect to serial port. Main Thread Awaits completion
        public void InitializeSerialConnection(IProgress<string> UpdateUIComPortText)
        {
            mSerialPort.FindSerialPorts();
            if (Force2400Baud)
                mSerialPort.BaudRate = 2400;
            else
                mSerialPort.BaudRate = 500000;

            mSerialPort.ConnectPort();

            UpdateUIComPortText.Report(mSerialPort.ConnectedPortName);
        }

        public void CreateReceiveDataThread(IProgress<RFEConfiguration> configurationData, IProgress<List<string>> sweepData, IProgress<string> sweepChartData, IProgress<int> nProgress)
        {
            //Start listening to data from the RF Explorer
            mReceiveThread = new Thread(() => ReceiveThread(configurationData, sweepData, sweepChartData, nProgress));
            mReceiveThread.Start();

            mSecondReturnedConfiguration = false;
            mFirstRetunedConfiguration = false;
        }

        public void DestroyReceiveDataThread()
        {
            Capture = false;
            mConfigured = false;
            mReceivedSweep.Clear();

            if (mReceiveThread != null)
                mReceiveThread.Abort();
        }

        public void SendConfiguration(double startMHz, double stopMHz, int amplitudeTop = -50, int amplitudeBottom = -110)
        {
            string start;
            string stop;
            string top;
            string bottom;

            Capture = false;
            mConfigured = false;

            mReceivedSweep.Clear();

            mSecondReturnedConfiguration = false;
            mFirstRetunedConfiguration = false;

            start = (startMHz * 1000.0).ToString("0000000");
            stop = (stopMHz * 1000.0).ToString("0000000");
            top = amplitudeTop.ToString("000");
            bottom = amplitudeBottom.ToString("000");


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

            // Average
            mSerialPort.SendCommand("C+\x2"); // Calculator Mode -  Average

            // Send final configuration and wait for the Explorer to return with configuration data
            mSerialPort.SendCommand("C2-F:" + start + "'" + stop + "," + top + "," + bottom);
            mSerialPort.SendCommand("C0"); // Request Config Data

        }

        public void DisconnectSerialPort()
        {
            //mSerialPort.RFEConnected = false;
            mSerialPort.DisconnectPort();
        }

        public void RequestConfiguration()
        {
            mSerialPort.SendCommand("C0"); // Request Config Data
        }

        private void ReceiveThread(IProgress<RFEConfiguration> configurationProgress,
                                    IProgress<List<string>> sweepDataList,
                                    IProgress<string> sweepData,
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
                    Monitor.Exit(mSerialPort);
                }
                catch (IOException) { }
                catch (TimeoutException) { }
                catch (Exception) { }

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
                    if (mConfigured && Capture)
                    {
                        if (sNewLine.StartsWith("$S"))
                        {
                            if (sNewLine.Length == 115)
                            {
                                if (SweepCount > 0)
                                {
                                    //Sweep until count is zero
                                    progressBarProgress.Report(SweepCount);
                                    sweepData.Report(sNewLine);
                                    mReceivedSweep.Add(sNewLine);
                                    SweepCount--;

                                    if (SweepCount == 0 || SweepValueStable)
                                    {
                                        Capture = false;
                                        sReceived = "";
                                        sNewText = "";
                                        sweepDataList.Report(mReceivedSweep);
                                        progressBarProgress.Report(0);
                                    }
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

                        // Look for Serial Number string
                        if ((sNewLine.StartsWith("#Sn")) && (sNewLine.Length == 19))
                        {
                            mRFEConfiguration.ParseSerialNumber(sNewLine);
                        }

                        // Look for Model and Version string
                        if ((sNewLine.StartsWith("#C2-M:")) && (sNewLine.Length == 19))
                        {
                            mRFEConfiguration.ParseModelAndVersion(sNewLine);
                        }

                        // Look for Configuration string 
                        if ((sNewLine.StartsWith("#C2-F:")) && (sNewLine.Length == 81))
                        {
                            if (mFirstRetunedConfiguration == false)
                            {
                                mFirstRetunedConfiguration = true;
                                mSecondReturnedConfiguration = false;
                            }
                            else
                            {
                                mSecondReturnedConfiguration = true;
                                mFirstRetunedConfiguration = false;
                            }

                            // Attempt at synchronizing so the number of returned lines is what is expected
                            // It looks like the Explorer returns TWO configuration repsonses after a set config command
                            // The first is old and the second is new
                            // Read set flags to find the second configuration response.

                            bool configurationValid = mRFEConfiguration.mMainModel.Equals(eModel.MODEL_6G_PLUS) ? mFirstRetunedConfiguration : mSecondReturnedConfiguration;

                            if (configurationValid)
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
                                mSecondReturnedConfiguration = false;
                                mFirstRetunedConfiguration = false;
                            }
                        }
                    }
                }

                Thread.Sleep(10);
            }
        }
    }
}
