using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFE_SerialTest;

namespace RFE_SerialTest
{
    public partial class applicationMainForm : Form
    {
        RFExplorer gRFE;
        SerialCommunications gSerialPort;
        public applicationMainForm()
        {
            InitializeComponent();

            gRFE = new RFExplorer();
            gSerialPort = new SerialCommunications();

        }

        private void buttonFindPorts_Click(object sender, EventArgs e)
        {
            bool bStatus;
            bStatus = gSerialPort.FindSerialPorts();

            if (gSerialPort.ComPortName != null)
            {
                labelRFEComPort.Text = String.Concat(gSerialPort.ComPortName);
            }
        }
    }
}
