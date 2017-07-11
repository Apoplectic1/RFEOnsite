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
        public CsvExport mCsvExports;
        private int mCsvFileSweepCount;


        private FolderBrowserDialog mFolderDialog;
        public MainForm()
        {
            InitializeComponent();

            // Versioning
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                Version version = ad.CurrentVersion;
                this.Text = "RF Explorer OnSite - Version: " + version.ToString();
            }
            else
            {
                this.Text = "RF Explorer OnSite - Version: " + System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString("yyyy.MM.dd - HHMM");
            }


            mGraph = new Charts();
            gRFE = new RFExplorer();
            mCsvExports = new CsvExport();

            InitializeChartUI();

            mFolderDialog = new FolderBrowserDialog();
            mFolderDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            labelCsvRootText.Text = "Root Folder for CSV Files:";
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
            mGraph.MinY = -110;

            mGraph.BuildChart();


            gRFE.mSeries = new Series();

            gRFE.mSeries.Points.AddXY(750, -30);

            foreach (var series in mGraph.Chart.Series)
            {
                series.Points.Clear();
            }

            mGraph.Chart.Series.Add(gRFE.mSeries);


            //gRFE.AddReplaceSeries(mGraph.Chart, gRFE.SweepData);

            panelChart.Controls.Add(mGraph.Chart);
        }

        public void UIUpdateCallback_CsvExport(CsvExport csvExport)
        {


            string fileName = textBoxSweepLocation.Text + "-" +
                mCsvFileSweepCount.ToString("D2") +
                " " +
                DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) +
                " " +
                (Convert.ToInt64(textBoxStartFrequency.Text) * 10).ToString("D5") +
                "to" +
                (Convert.ToInt64(textBoxStopFrequency.Text) * 10).ToString("D5") +
                "-" +
                numericUpDownSweeps.Text +
                " at " +
                "000 " +
                "Degrees.csv";

            textBoxCsvFileName.Text = fileName;

            string filePath = mFolderDialog.SelectedPath + "\\" + fileName;



            csvExport.ExportToFile(filePath);

            mCsvFileSweepCount++;
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
            labelFirmwareText.Text = config.mFirmwareVersion;

            if (config.mMainModel == eModel.MODEL_6G)
            {
                radioButtonAnalyzer.Checked = true;
                radioButtonGenerator.Checked = false;
            }
            else
            {
                radioButtonAnalyzer.Checked = false;
                radioButtonGenerator.Checked = true;
            }
        }

        public void UIUpdateCallback_Series(Series newSeries)
        {
            //lock (mGraph.Chart.Series)
            {
                for (int i = 0; mGraph.Chart.Series.Count != 0; i++)
                {
                    mGraph.Chart.Series.RemoveAt(0);
                }

                if (checkBoxChartRealTime.Checked)
                {
                    newSeries.Color = Color.DarkSlateGray;
                    newSeries.Name = "RealTime";
                    mGraph.Chart.Series.Add(newSeries);
                }

                if (checkBoxChartAverage.Checked)
                {
                    newSeries = AverageSeries(newSeries);

                    newSeries.Color = Color.DarkGreen;
                    newSeries.Name = "Average";
                    mGraph.Chart.Series.Add(newSeries);
                }

                if (checkBoxChartPeakHold.Checked)
                {
                    newSeries = PeakHoldSeries(newSeries);

                    newSeries.Color = Color.DarkRed;
                    newSeries.Name = "PeakHold";
                    mGraph.Chart.Series.Add(newSeries);
                }
            }
        }

        private Series AverageSeries(Series inSeries)
        {
            Series outSeries = new Series();

            return outSeries;
        }

        private Series PeakHoldSeries(Series inSeries)
        {
            Series outSeries = new Series();
            double maxY = -200.0;

            for (int index = 0; index < 112; index++)
            {

            }


            return outSeries;
        }

        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
            // Pass "labelRFEComPort.Text" - a string - to Initialize() thread (await)
            // TThe thread then updates the GUI
            buttonFindCOMPorts.Enabled = false;

            IProgress<string> updateUiComPortLabel = new Progress<string>(s => labelRFEComPort.Text = s);
            await Task.Factory.StartNew(() => gRFE.Initialize(updateUiComPortLabel));

            if (!labelRFEComPort.Text.Contains("COM"))
            {
                buttonFindCOMPorts.Text = "Not Found. Try Again.";
                return;
            }

            buttonFindCOMPorts.Text = "Connected";
            buttonFindCOMPorts.Enabled = false;

            IProgress<Series> updateUISeries = new Progress<Series>(SERIES => UIUpdateCallback_Series(SERIES));
            IProgress<RFEConfiguration> UpdateUI = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configutration(RFE));
            IProgress<int> UpdateUIProgressBar = new Progress<int>(s => TaskProgressBar.Value = s);

            IProgress<CsvExport> UpdateCsvExport = new Progress<CsvExport>(CSV => UIUpdateCallback_CsvExport(CSV));

            gRFE.AttachSerialPortAndReceiveDataThread(UpdateUI, updateUISeries, UpdateUIProgressBar, UpdateCsvExport);
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


            if (checkBoxChartRealTime.Checked || checkBoxChartAverage.Checked || checkBoxChartPeakHold.Checked)
            {
                TaskProgressBar.Maximum = gRFE.SweepCount;
                TaskProgressBar.Step = 1;
                TaskProgressBar.Value = 0;

                buttonStartSweeps.Text = "Cancel";
                mCsvFileSweepCount = 1;

                gRFE.Capture = true;
            }

        }

        private void checkBoxSaveCsvFiles_CheckedChanged(object sender, EventArgs e)
        {
            gRFE.WriteCsvFiles = checkBoxSaveCsvFiles.Checked;

            if (gRFE.WriteCsvFiles)
            {
                textBoxSweepLocation.Enabled = true;
                textBoxCsvFileName.Enabled = true;
                buttonSelectCsvFolder.Enabled = true;
                labelCsvRootText.Enabled = true;
                labelRootDirectory.Enabled = true;
                labelProgressWriteCsvFile.Enabled = true;
            }
            else
            {
                textBoxSweepLocation.Enabled = false;
                textBoxCsvFileName.Enabled = false;
                buttonSelectCsvFolder.Enabled = false;
                labelCsvRootText.Enabled = false;
                labelRootDirectory.Enabled = false;
                labelProgressWriteCsvFile.Enabled = true;
            }
        }

        private void buttonSelectCsvFolder_Click(object sender, EventArgs e)
        {
            mFolderDialog.Description = "Create or select a Desktop folder to store CSV file results in.";
            if (mFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                labelRootDirectory.Text = mFolderDialog.SelectedPath;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ConfigurationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConnectionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxSerialConnection_Enter(object sender, EventArgs e)
        {

        }
    }
}
