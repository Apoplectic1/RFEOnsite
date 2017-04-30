using RFEOnSite;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static RFEOnsite.RFExplorer;

namespace RFEOnsite
{
    public partial class MainForm : Form
    {
        RFExplorer gRFE;
        Charts mChart;

        public MainForm()
        {
            InitializeComponent();

            gRFE = new RFExplorer();

            mChart = new Charts();

            InitializeChart();
        }

        private void InitializeChart()
        {

            this.components = new System.ComponentModel.Container();
            
            ((ISupportInitialize)(mChart.Chart)).BeginInit();

            SuspendLayout();
            
            mChart.Chart.Dock = System.Windows.Forms.DockStyle.Fill;

            mChart.Chart.Location = new System.Drawing.Point(0, 50);
            
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Use this to resize Client Area
            //this.ClientSize = new System.Drawing.Size(284, 262); 
            
            this.Load += new EventHandler(Form1_Load);

            ((ISupportInitialize)(this.mChart.Chart)).EndInit();

            this.ResumeLayout(false);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            if (textBoxStartFrequency.Text.Length > 0)
            {
                mChart.MinX = Convert.ToInt32(textBoxStartFrequency.Text);
            }

            if (textBoxStopFrequency.Text.Length > 0)
            {
                mChart.MaxX = Convert.ToInt32(textBoxStopFrequency.Text);
            }
           
            mChart.MaxY = -30;
            mChart.MinY = -100;

            mChart.ReplaceSeries(gRFE.SweepData);

            mChart.BuildChart();

            mChart.Chart.Invalidate();

            panelChart.Controls.Add(mChart.Chart);
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
            rbwKHz   = textBoxRBW.Text;
            stepMHZ  = textBoxStepSize.Text;

            gRFE.SetConfiguration(Convert.ToDouble(startMHz), Convert.ToDouble(stopMHz));

            mChart.MinX = Convert.ToInt32(startMHz);
            mChart.MaxX = Convert.ToInt32(stopMHz);

            mChart.Chart.ChartAreas[0].AxisX.Maximum = mChart.MaxX;
            mChart.Chart.ChartAreas[0].AxisX.Minimum = mChart.MinX;

            mChart.Chart.ChartAreas[0].AxisX.Interval = (mChart.MaxX - mChart.MinX) / 5;
            mChart.Chart.Refresh();
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
    }
}
