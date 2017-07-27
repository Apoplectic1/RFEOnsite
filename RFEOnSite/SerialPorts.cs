using Microsoft.Win32;
using System;
using System.IO.Ports;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RFEOnSite
{
    public class SerialPorts
    {
        private static string[] mEnumeratedComPortNames;
        private static string[] mConnectedPorts;
        private string mConnectedPort;
        private SerialPort mSerialPort;
        private bool mRFEConnected;

        public string[] ComPortName { get { return mConnectedPorts; } }
        public bool RFEConnected { get { return mRFEConnected; } }
        public SerialPort Port { get { return mSerialPort; } set { mSerialPort = value; } }
        public string ConnectedPortName { get { return mConnectedPort; } }
        private static bool IsConnectedPort(string sPortName)
        {
            foreach (string sPort in mEnumeratedComPortNames)
            {
                if (sPort == sPortName)
                    return true;
            }
            return false;
        }

        private static bool IsRepeatedPort(string sPortName)
        {
            if (mConnectedPorts == null)
                return false;

            foreach (string sPort in mConnectedPorts)
            {
                if (sPort == sPortName)
                    return true;
            }
            return false;
        }
        public bool FindSerialPorts()
        {
            Cursor.Current = Cursors.WaitCursor;

            mSerialPort = new SerialPort();

            mEnumeratedComPortNames = System.IO.Ports.SerialPort.GetPortNames();

            mConnectedPorts = null;

            string csSubkey = "SYSTEM\\CurrentControlSet\\Enum\\USB\\VID_10C4&PID_EA60";
            RegistryKey regUSBKey = Registry.LocalMachine.OpenSubKey(csSubkey, RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.QueryValues | System.Security.AccessControl.RegistryRights.EnumerateSubKeys);

            if (regUSBKey == null)
            {
                Cursor.Current = Cursors.Default;
                return false;
            }

            string[] arrDeviceCP210x = regUSBKey.GetSubKeyNames();

            //Iterate all driver for CP210x and get those with a valid connected COM port
            foreach (string sUSBIndex in arrDeviceCP210x)
            {
                try
                {
                    RegistryKey regUSBID = regUSBKey.OpenSubKey(sUSBIndex, RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.QueryValues | System.Security.AccessControl.RegistryRights.EnumerateSubKeys);
                    if (regUSBID != null)
                    {
                        Object obFriendlyName = regUSBID.GetValue("FriendlyName");
                        if (obFriendlyName != null)
                        {
                            RegistryKey regDevice = regUSBID.OpenSubKey("Device Parameters", RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.QueryValues);
                            if (regDevice != null)
                            {
                                object obPortName = regDevice.GetValue("PortName");
                                string sPortName = obPortName.ToString();

                                if (IsConnectedPort(sPortName) && !IsRepeatedPort(sPortName))
                                {
                                    if (mConnectedPorts == null)
                                    {
                                        mConnectedPorts = new string[] { sPortName };
                                    }
                                    else
                                    {
                                        Array.Resize(ref mConnectedPorts, mConnectedPorts.Length + 1);
                                        mConnectedPorts[mConnectedPorts.Length - 1] = sPortName;
                                    }
                                }
                            }
                        }
                    }
                }

                catch (SecurityException) { }
            }
            Cursor.Current = Cursors.Default;

            if (mConnectedPorts != null)
            {
                mConnectedPort = String.Concat(mConnectedPorts);
                return true;
            }

            mConnectedPort = "";
            return false;
        }

        public void ConnectPort()
        {
            try
            {
                Monitor.Enter(mSerialPort);

                mSerialPort.BaudRate = 500000;
                mSerialPort.DataBits = 8;
                mSerialPort.StopBits = StopBits.One;
                mSerialPort.Parity = Parity.None;
                mSerialPort.PortName = String.Concat(mConnectedPorts);
                mSerialPort.ReadTimeout = 100;
                mSerialPort.WriteBufferSize = 1024;
                mSerialPort.ReadBufferSize = 8192;
                mSerialPort.Open();
                mSerialPort.Handshake = Handshake.None;
                mSerialPort.Encoding = Encoding.GetEncoding(28591); //Trick: use ASCII and binary together

                mRFEConnected = true;

                OnPortConnected(new EventArgs());
                Thread.Sleep(500);

                SendCommand_RequestConfigData();
                Thread.Sleep(500);

            }
            catch (Exception)
            {
                string message; // = obException.ToString();
                string caption = "Serial Port Connection Error";
                message = "After Application closes:\n\t1. Disconnect the RF Explorer USB cable.\n\t2. Cycle RF Explorer Power.\n\t3. Reconnect and try again.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the Exception MessageBox.
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                        Application.Exit();
                }
            }
            finally
            {
                Monitor.Exit(mSerialPort);
            }
        }

        public void DisconnectPort()
        {
            try
            {
                mRFEConnected = false;
                mSerialPort.Close();
            }
            catch
            {

            }
        }



        public void SendCommand_RequestConfigData()
        {
            SendCommand("C0");
        }


        /// <summary>
        /// Format and send command - for instance to reboot just use "r", the '#' decorator and byte length char will be included within
        /// </summary>
        /// <param name="sData">unformatted command from http://code.google.com/p/rfexplorer/wiki/RFExplorerRS232Interface </param>
        public void SendCommand(string sData)
        {
            if (!mRFEConnected)
            {
                return;
            }

            try
            {
                Monitor.Enter(mSerialPort);
                mSerialPort.Write("#" + Convert.ToChar(sData.Length + 2) + sData);
            }
            catch (Exception)
            {
                
            }
            finally
            {
                Monitor.Exit(mSerialPort);
            }
        }

        

        // **********************************************************************************************************************
        // ********** Event Handlers ********************************************************************************************
        // **********************************************************************************************************************
        /// <summary>
        /// This event will fire in the event of a communication port is connected
        /// </summary>
        public event EventHandler PortConnectedEvent;
        protected virtual void OnPortConnected(EventArgs e)
        {
            PortConnectedEvent?.Invoke(this, e);
        }

        /// <summary>
        /// This event will fire in the event of a communication port is closed, either by manual user intervention or by a link error
        /// </summary>
        public event EventHandler PortClosedEvent;
        protected virtual void OnPortClosed(EventArgs e)
        {
            PortClosedEvent?.Invoke(this, e);
        }
    }
}
