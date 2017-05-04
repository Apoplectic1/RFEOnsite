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
        public RFExplorer gRFE;
        public Charts mGraph;

        public MainForm()
        {
            InitializeComponent();

            
            mGraph = new Charts();
            gRFE = new RFExplorer();


            InitializeChartUI();
        }

        private void InitializeChartUI()
        {

            components = new System.ComponentModel.Container();

            ((ISupportInitialize)(mGraph.Chart)).BeginInit();

            SuspendLayout();

            mGraph.Chart.Dock = System.Windows.Forms.DockStyle.Fill;

            mGraph.Chart.Location = new System.Drawing.Point(0, 50);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Use this to resize Client Area
            //this.ClientSize = new System.Drawing.Size(284, 262); 

            Load += new EventHandler(Form1_Load);

            ((ISupportInitialize)(mGraph.Chart)).EndInit();

            ResumeLayout(false);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            if (textBoxStartFrequency.Text.Length > 0)
            {
                mGraph.MinX = Convert.ToInt32(textBoxStartFrequency.Text);
            }

            if (textBoxStopFrequency.Text.Length > 0)
            {
                mGraph.MaxX = Convert.ToInt32(textBoxStopFrequency.Text);
            }

            mGraph.MaxY = -30;
            mGraph.MinY = -100;

            mGraph.BuildChart();

            
            gRFE.mSeries = new Series();

            gRFE.mSeries.Points.AddXY(750, -50);

            mGraph.Chart.Series.Add(gRFE.mSeries);


            //gRFE.AddReplaceSeries(mGraph.Chart, gRFE.SweepData);

            panelChart.Controls.Add(mGraph.Chart);
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

        public void UIUpdateCallback_Series(Series series)
        {
            mGraph.Chart.Series.Add(series);
        }

        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
            // Pass "labelRFEComPort.Text" - a string - to Initialize() thread (await)
            // TThe thread then updates the GUI

            IProgress<string> updateUiComPortLabel = new Progress<string>(s => labelRFEComPort.Text = s);

            await Task.Factory.StartNew(() => gRFE.Initialize(updateUiComPortLabel));

            if (!labelRFEComPort.Text.Contains("COM"))
            {
                buttonFindCOMPorts.Text = "Not Found. Try Again.";
                return;
            }

            buttonFindCOMPorts.Text = "Connected";
            buttonFindCOMPorts.Enabled = false;

            var updateUISeries = new Progress<Series>(SERIES => UIUpdateCallback_Series(SERIES));
            var UpdateUI = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configutration(RFE));

            gRFE.AttachSerialPortAndDataReceivedThread(UpdateUI, updateUISeries);
        }

        private void buttonSetConfiguration_Click(object sender, EventArgs e)
        {
            double startMHz;
            double stopMHz;
            double rbwKHz;
            double stepMHZ;

            startMHz = Convert.ToDouble(textBoxStartFrequency.Text);
            stopMHz = Convert.ToDouble(textBoxStopFrequency.Text);
            rbwKHz = Convert.ToDouble(textBoxRBW.Text);
            stepMHZ = Convert.ToDouble(textBoxStepSize.Text);

            gRFE.SetConfiguration(startMHz, stopMHz);

            mGraph.MinX = startMHz;
            mGraph.MaxX = stopMHz;

            mGraph.Chart.ChartAreas[0].AxisX.Maximum = mGraph.MaxX;
            mGraph.Chart.ChartAreas[0].AxisX.Minimum = mGraph.MinX;

            mGraph.Chart.ChartAreas[0].AxisX.Interval = (mGraph.MaxX - mGraph.MinX) / 5;

            if (checkBoxChartRealTime.Checked == true)
            {
                //gRFE.Capture = true;
            }
        }

        private void comboBoxProgramMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //buttonSetConfiguration.Focus();
        }

        private void buttonStartWeeps_Click(object sender, EventArgs e)
        {
            gRFE.SweepCount = (int)numericUpDownSweeps.Value;

            gRFE.Capture = true;
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
