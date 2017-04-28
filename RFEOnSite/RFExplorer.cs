using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RFExplorerCommunicator;
using static RFExplorerCommunicator.RFExplorer;

namespace RFEOnsite
{

    public partial class RFExplorer
    {
        Queue mReceiveThreadDataArray;
        //        Thread mReceiveThread;                     //Thread to process received RS232 activity
        volatile bool mbRunReceiveThread;                 //Run thread (true) or temporarily stop it (false)
        SerialCommunications mSerialPort;
        RFEConfiguration mRFEConfiguration;


        public RFExplorer()
        {
            mSerialPort = new SerialCommunications();

            mReceiveThreadDataArray = new Queue();
            mRFEConfiguration = new RFEConfiguration();
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
            //ThreadStart threadDelegate = new ThreadStart(ReceiveThreadfunc);
            //mReceiveThread = new Thread(threadDelegate);
            //mReceiveThread.Start();

            Thread mReceiveThread = new Thread(() => ReceiveThreadfunc(progress));
            mReceiveThread.Start();


        }

        public void SetConfiguration(double startMHz, double stopMHz, int amplitudeTop = 0, int amplitudeBottom = -110)
        {
            string start;
            string stop;
            string top;
            string bottom;


            start = Convert.ToInt32(Convert.ToDecimal(startMHz * 1000.0)).ToString("0000000");
            stop = Convert.ToInt32(Convert.ToDecimal(stopMHz * 1000.0)).ToString("0000000");
            top = Convert.ToInt32(Convert.ToDecimal(amplitudeTop * 1000.0)).ToString("0000");
            bottom = Convert.ToInt32(Convert.ToDecimal(amplitudeBottom * 1000.0)).ToString("0000");

            mReceiveThreadDataArray.Clear();

            if (startMHz >= 4850)
            {
                mSerialPort.SendCommand("CM\x0");
            }
            else
            {
                mSerialPort.SendCommand("CM\x1");
            }

            mSerialPort.SendCommand("C2-F:" + start + "'" + stop + "," + top + ",-110");

        }


        //        RFEConfiguration objNewConfiguration = new RFEConfiguration();
        

        private void ReceiveThreadfunc(IProgress<RFEConfiguration> progress)
        {
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
                        string sNewLine;
                        string sLeftOver;

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
                                //progress.Report(mRFEConfiguration);
                            }
                            progress.Report(mRFEConfiguration);
                        }
                    }

                    Thread.Sleep(10);
                }

                Thread.Sleep(500);
            }
        }
    }
}
