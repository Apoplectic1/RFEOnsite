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

        public string[] ComPortName { get { return mConnectedPorts; } }
        public bool RFEConnected { get; private set; }
        public SerialPort Port { get; set; }
        public string ConnectedPortName { get; private set; }




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

            Port = new SerialPort();

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
                ConnectedPortName = String.Concat(mConnectedPorts);
                return true;
            }

            ConnectedPortName = "";
            return false;
        }

        public void ConnectPort()
        {
            try
            {
                Monitor.Enter(Port);

                Port.BaudRate = 500000;
                Port.DataBits = 8;
                Port.StopBits = StopBits.One;
                Port.Parity = Parity.None;
                Port.PortName = String.Concat(mConnectedPorts);
                Port.ReadTimeout = 100;
                Port.WriteBufferSize = 1024;
                Port.ReadBufferSize = 8192;
                Port.Open();
                Port.Handshake = Handshake.None;
                Port.Encoding = Encoding.GetEncoding(28591); //Trick: use ASCII and binary together

                RFEConnected = true;

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
                Monitor.Exit(Port);
            }
        }

        public void DisconnectPort()
        {
            try
            {
                RFEConnected = false;
                Port.Close();
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
            if (!RFEConnected)
            {
                return;
            }

            try
            {
                Monitor.Enter(Port);
                Port.Write("#" + Convert.ToChar(sData.Length + 2) + sData);
            }
            catch (Exception)
            {
                
            }
            finally
            {
                Monitor.Exit(Port);
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
