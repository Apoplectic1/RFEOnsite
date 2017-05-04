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
        Charts mUIChart;

        public MainForm()
        {
            InitializeComponent();

            gRFE = new RFExplorer();

            mUIChart = new Charts();

            InitializeChart();
        }

        private void InitializeChart()
        {

            components = new System.ComponentModel.Container();
            
            ((ISupportInitialize)(mUIChart.Chart)).BeginInit();

            SuspendLayout();

            mUIChart.Chart.Dock = System.Windows.Forms.DockStyle.Fill;

            mUIChart.Chart.Location = new System.Drawing.Point(0, 50);
            
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Use this to resize Client Area
            //this.ClientSize = new System.Drawing.Size(284, 262); 

            Load += new EventHandler(Form1_Load);

            ((ISupportInitialize)(mUIChart.Chart)).EndInit();

            ResumeLayout(false);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            if (textBoxStartFrequency.Text.Length > 0)
            {
                mUIChart.MinX = Convert.ToInt32(textBoxStartFrequency.Text);
            }

            if (textBoxStopFrequency.Text.Length > 0)
            {
                mUIChart.MaxX = Convert.ToInt32(textBoxStopFrequency.Text);
            }

            mUIChart.MaxY = -30;
            mUIChart.MinY = -100;

            mUIChart.BuildChart();

            mUIChart.AddReplaceSeries(mUIChart.Chart, gRFE.SweepData);

            panelChart.Controls.Add(mUIChart.Chart);
        }
        
        public void UIUpdateCallback_RFE_Configutration(RFEConfiguration config)
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

            var UpdateUI = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configutration(RFE));

            gRFE.AttachSerialPortAndDataReceivedThread(UpdateUI);
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

            mUIChart.MinX = Convert.ToInt32(startMHz);
            mUIChart.MaxX = Convert.ToInt32(stopMHz);

            mUIChart.Chart.ChartAreas[0].AxisX.Maximum = mUIChart.MaxX;
            mUIChart.Chart.ChartAreas[0].AxisX.Minimum = mUIChart.MinX;

            mUIChart.Chart.ChartAreas[0].AxisX.Interval = (mUIChart.MaxX - mUIChart.MinX) / 5;

            if (checkBoxChartRealTime.Checked == true)
            {
                gRFE.Capture = true;
            }
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
            foreach (var series in mUIChart.Chart.Series)
            {
                series.Points.Clear();
            }
            mUIChart.Chart.Series[0].Points.AddXY(700, -70);
            mUIChart.Chart.Series[0].Points.AddXY(750, -70);
            mUIChart.Chart.Series[0].Points.AddXY(800, -70);

        }

        private void checkBoxChartRealTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChartRealTime.Checked == true)
            {
                gRFE.Capture = true;
            }
        }
    }
}
