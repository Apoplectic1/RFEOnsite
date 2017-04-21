using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFE_SerialTest
{
    public class SerialCommunications
    {
        private static string[] mEnumeratedComPortNames;
        private static string[] mConnectedPorts;
        private static SerialPort mSerialPort;

        public string[] ComPortName { get { return mConnectedPorts; } }
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

            int nTotalPortsFound = 0;

            if (mConnectedPorts != null)
            {
                nTotalPortsFound = mConnectedPorts.Length;
                Cursor.Current = Cursors.Default;
                return true;
            }

            Cursor.Current = Cursors.Default;
            return false;
        }
    }
}
