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
using static RFExplorerCommunicator.RFExplorer;

namespace RFE_SerialTest
{
    public partial class MainForm : Form
    {
        RFExplorer gRFE;

        public MainForm()
        {
            InitializeComponent();

            gRFE = new RFExplorer();

        }

        public void config(RFEConfiguration config)
        {
            double stopMHz;
            double resolutionBandWidth;
            double steps;

            textBoxStartFrequency.Text = config.fStartMHZ.ToString();
            stopMHz = (config.fStepMHZ * 112.0) + config.fStartMHZ;
            textBoxStopFrequency.Text = Math.Round(stopMHz, 2).ToString();
            labelRBWKhz.Text = Math.Round(config.fRBWKHZ, 2).ToString() + " KHz";
            label3.Text = Math.Round(config.fStepMHZ, 2).ToString() + " MHz";
        }

        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
           
            var progress = new Progress<string>(s => labelRFEComPort.Text = s);

            await Task.Factory.StartNew(() => gRFE.Initialize(progress));

            if (!labelRFEComPort.Text.Contains("COM"))
            {
                buttonFindCOMPorts.Text = "Not Found. Try Again.";
                return;
            }

            buttonFindCOMPorts.Text = "Connected";
            buttonFindCOMPorts.Enabled = false;


            var configurationUpdate = new Progress<RFEConfiguration>(RFE => config(RFE));

            gRFE.Configuration(configurationUpdate);

        }
        
    }
}
