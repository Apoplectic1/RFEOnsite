using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RFEOnsite.RFExplorer;

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
            labelFoundDevice.Text = config.mMainModel.ToString();
            labelFoundModel.Text = config.mExpansionModel.ToString();
            labelFirmware.Text = config.mFirmwareVersion;
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
            //buttonSetConfiguration.Focus();
        }
        
        private void buttonStartWeeps_Click(object sender, EventArgs e)
        {
            string startMHz;
            string stopMHz;
            string rbwKHz;
            string stepMHZ;

            startMHz = textBoxStartFrequency.Text;
            stopMHz = textBoxStopFrequency.Text;
            rbwKHz = textBoxRBW.Text;
            stepMHZ = textBoxStepSize.Text;

            gRFE.SweepCount = (int)numericUpDownSweeps.Value;
            gRFE.SetConfiguration(Convert.ToDouble(startMHz), Convert.ToDouble(stopMHz));

            gRFE.Capture = true;
        }

        private void groupBoxSerialConnection_Enter(object sender, EventArgs e)
        {

        }
    }
}
