using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFEOnsite;
using static RFExplorerCommunicator.RFExplorer;

namespace RFEOnsite
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

            textBoxStartFrequency.Text = config.fStartMHZ.ToString();
            stopMHz = (config.fStepMHZ * 112.0) + config.fStartMHZ;
            textBoxStopFrequency.Text = Math.Round(stopMHz, 2).ToString();
            textBoxRBW.Text = Math.Round(config.fRBWKHZ, 2).ToString();
            textBoxStepSize.Text = Math.Round(config.fStepMHZ * 1000.0, 2).ToString();
            label4.Text = config.mMainModel.ToString();
            label5.Text = config.mExpansionModel.ToString();
            label7.Text = config.mFirmwareVersion;
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

        private void buttonSetConfiguration_Click(object sender, EventArgs e)
        {
            string startMHz;
            string stopMHz;
            string rbwKHz;
            string stepMHZ;

            startMHz = textBoxStartFrequency.Text;
            stopMHz  = textBoxStopFrequency.Text;
            rbwKHz = textBoxRBW.Text;
            stepMHZ = textBoxStepSize.Text;

            gRFE.SetConfiguration(Convert.ToDouble(startMHz), Convert.ToDouble(stopMHz));
        }

        private void comboBoxProgramMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSetConfiguration.Focus();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
