using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static RFExplorerCommunicator.RFExplorer;

namespace RFE_SerialTest
{

    public partial class RFExplorer
    {
        Queue           mReceiveThreadDataArray;
        Thread          mReceiveThread;                     //Thread to process received RS232 activity
        volatile bool   mbRunReceiveThread;                 //Run thread (true) or temporarily stop it (false)
        SerialCommunications mSerialPort;
        
       
        public RFExplorer ()
        {
            mSerialPort = new SerialCommunications();

            mReceiveThreadDataArray = new Queue();
        }
        

        public bool Initialize()
        {
            bool bStatus;

            bStatus = mSerialPort.FindSerialPorts();

            if (mSerialPort.ComPortName != null)
            {
                MainForm.ComPortLabel = String.Concat(mSerialPort.ComPortName);
            }

            mSerialPort.ConnectPort();

            // Start listening to data from the RF Explorer
            mbRunReceiveThread = true;
            ThreadStart threadDelegate = new ThreadStart(ReceiveThreadfunc);
            mReceiveThread = new Thread(threadDelegate);
            mReceiveThread.Start();

            return true;
        }

        private void ReceiveThreadfunc()
        {
            SerialPort testPort = new SerialPort();
            bool temp = testPort.IsOpen;

            //this is the object used to keep current configuration data
            RFEConfiguration objCurrentConfiguration = null;
            RFEConfiguration objNewConfiguration = null;

            while (mbRunReceiveThread)
            {
                string strReceived = "";
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
                    catch (Exception obExeption)
                    {
                        Monitor.Enter(mReceiveThreadDataArray);
                        mReceiveThreadDataArray.Enqueue(obExeption);
                        Monitor.Exit(mReceiveThreadDataArray);
                    }
                    finally { Monitor.Exit(mSerialPort); }

                    if (sNewText.Length > 0)
                    {
                        strReceived += sNewText;
                        sNewText = "";
                    }

                    if (strReceived.Length > 66 * 1024)
                    {
                        //Safety code, some error prevented the string from being processed in several loop cycles. Reset it.
                        strReceived = "";
                    }

                    if (strReceived.Length > 0)
                    {
                        if (strReceived[0] == '#')
                        {
                            int nEndPos = strReceived.IndexOf("\r\n");
                            if (nEndPos >= 0)
                            {
                                string sNewLine = strReceived.Substring(0, nEndPos);
                                string sLeftOver = strReceived.Substring(nEndPos + 2);
                                strReceived = sLeftOver;
                                
                                if ((sNewLine.Length > 5) &&
                                        (sNewLine.StartsWith("#C2-F:") || sNewLine.StartsWith("#C2-f:") ||
                                        (sNewLine.StartsWith("#C3-") && (sNewLine[4] != 'M')) || sNewLine.StartsWith("#C4-F:"))
                                    )
                                {
                                    //Standard configuration expected
                                    objNewConfiguration = new RFEConfiguration();
                                    if (objNewConfiguration.ProcessReceivedString(sNewLine))
                                    {
                                        objCurrentConfiguration = new RFEConfiguration(objNewConfiguration);
                                        Monitor.Enter(mReceiveThreadDataArray);
                                        mReceiveThreadDataArray.Enqueue(objNewConfiguration);
                                        Monitor.Exit(mReceiveThreadDataArray);
                                    }
                                }
                                else
                                {
                                    Monitor.Enter(mReceiveThreadDataArray);
                                    mReceiveThreadDataArray.Enqueue(sNewLine);
                                    Monitor.Exit(mReceiveThreadDataArray);
                                }
                            }
                        }
                        else
                        {
                            int nEndPos = strReceived.IndexOf("\r\n");
                            if (nEndPos >= 0)
                            {
                                string sNewLine = strReceived.Substring(0, nEndPos);
                                string sLeftOver = strReceived.Substring(nEndPos + 2);
                                strReceived = sLeftOver;
                                Monitor.Enter(mReceiveThreadDataArray);
                                mReceiveThreadDataArray.Enqueue(sNewLine);
                                Monitor.Exit(mReceiveThreadDataArray);
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
