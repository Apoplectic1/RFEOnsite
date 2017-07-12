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

        private WhoopNodeForm mWhoopNodeDownlinkForm;

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

            comboBoxPreset.SelectedIndex = 0;

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

            mGraph.Chart.Dock = DockStyle.Fill;

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
            mFolderDialog.Description = "Create or Select Desktop Folder to Store CSV Files";
            mFolderDialog.ShowDialog();

            string filePath = mFolderDialog.SelectedPath + "\\" + fileName;



            csvExport.ExportToFile(filePath);

            mCsvFileSweepCount++;
        }

        public void UIUpdateCallback_RFE_Configutration(RFEConfiguration fromSerialThread)
        {
            double stopMHz;

            textBoxStartFrequency.Text = fromSerialThread.GetExplorer_StartMHz.ToString();//  fStartMHz.ToString();
            stopMHz = (fromSerialThread.GetExplorer_StepMHz * 112.0) + fromSerialThread.GetExplorer_StartMHz;
            textBoxStopFrequency.Text = Math.Round(stopMHz, 2).ToString();
            textBoxRBW.Text = Math.Round(fromSerialThread.GetExplorer_RBWKHz, 2).ToString();
            textBoxStepSize.Text = Math.Round(fromSerialThread.GetExplorer_StepMHz * 1000.0, 2).ToString();
            labelFoundDevice.Text = fromSerialThread.mMainModel.ToString();
            labelFoundModel.Text = fromSerialThread.mExpansionModel.ToString();
            labelFirmwareText.Text = fromSerialThread.mFirmwareVersion;

            if (fromSerialThread.mMainModel == eModel.MODEL_6G)
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

        public void UIUpdateCallback_Chart(Series seriesFromExplorer)
        {
            while (mGraph.Chart.Series.Count > 0) { mGraph.Chart.Series.RemoveAt(0); }
           

            //if (checkBoxChartRealTime.Checked)
            //{
            //    newSeries.Color = Color.DarkSlateGray;
            //    newSeries.Name = "RealTime";
            //    mGraph.Chart.Series.Add(newSeries);
            //}

            //if (checkBoxChartAverage.Checked)
            //{
            //    newSeries = SeriesAverage(newSeries);

            //    newSeries.Color = Color.DarkGreen;
            //    newSeries.Name = "Average";
            //    mGraph.Chart.Series.Add(newSeries);
            //}

            if (checkBoxChartPeak.Checked)
            {
                //newSeries = SeriesPeak(newSeries);

                seriesFromExplorer.Color = Color.DarkRed;
                seriesFromExplorer.Name = "Peak";
                mGraph.Chart.Series.Add(seriesFromExplorer);
            }

        }

        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
            // Pass "labelRFEComPort.Text" - a string - to Initialize() thread (await)
            // TThe thread then updates the GUI
            buttonFindCOMPorts.Enabled = false;

            IProgress<string> UIComPortLabel = new Progress<string>(s => labelRFEComPort.Text = s);
            await Task.Factory.StartNew(() => gRFE.InitializeSerialConnection(UIComPortLabel));

            if (!labelRFEComPort.Text.Contains("COM"))
            {
                buttonFindCOMPorts.Text = "Not Found. Try Again.";
                return;
            }

            buttonFindCOMPorts.Text = "Connected";
            buttonFindCOMPorts.Enabled = false;

            IProgress<Series> UpdateUIChartSeries = new Progress<Series>(SERIES => UIUpdateCallback_Chart(SERIES));
            IProgress<RFEConfiguration> UpdateUIControls = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configutration(RFE));
            IProgress<CsvExport> UpdateCsvExport = new Progress<CsvExport>(CSV => UIUpdateCallback_CsvExport(CSV));
            IProgress<int> UpdateUIProgressBar = new Progress<int>(s => TaskProgressBar.Value = s);

            await Task.Factory.StartNew(() => gRFE.AttachSerialPortAndReceiveDataThread(UpdateUIControls, UpdateUIChartSeries, UpdateCsvExport, UpdateUIProgressBar));

            buttonSetConfiguration.Enabled = true;
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

            buttonStartSweeps.Enabled = true;
        }

        private void buttonStartWeeps_Click(object sender, EventArgs e)
        {
            gRFE.SweepCount = (int)numericUpDownSweeps.Value;


            if (checkBoxChartRealTime.Checked || checkBoxChartAverage.Checked || checkBoxChartPeak.Checked)
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
                labelCsvRootText.Enabled = true;
                labelRootDirectory.Enabled = true;
                labelProgressWriteCsvFile.Enabled = true;
            }
            else
            {
                textBoxSweepLocation.Enabled = false;
                textBoxCsvFileName.Enabled = false;
                labelCsvRootText.Enabled = false;
                labelRootDirectory.Enabled = false;
                labelProgressWriteCsvFile.Enabled = true;
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

        private void textBoxSweepLocation_TextChanged(object sender, EventArgs e)
        {

            this.toolTip1.SetToolTip(this.textBoxSweepLocation, "Enter a short site collection location identifier " +
                "for data that is about to be collected.\nThis identifier will be used to create or enter a Desktop sub-folder to" +
                    " store collected data in CSV Files.");
        }

        private void checkBoxChartRealTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChartRealTime.Checked)
            {
                checkBoxChartAverage.Enabled = false;
                checkBoxChartPeak.Enabled = false;
                gRFE.Capture = true;
            }
            else
            {
                checkBoxChartAverage.Enabled = false;
                checkBoxChartPeak.Enabled = false;
                gRFE.Capture = false;
            }
        }

        private void labelRightAttentaion_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLeftSMAAttenuationValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelLeftSMAAttenuationText_Click(object sender, EventArgs e)
        {

        }

        private void labelRightSMAAttenuationText_Click(object sender, EventArgs e)
        {

        }

        private void textBoxRightSMAAttentuationValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenWhoopNodeSelection(object sender, EventArgs e)
        {
            if (comboBoxPreset.SelectedItem == null)
                return;

            var item = (string)comboBoxPreset.SelectedItem;

            if (item == "Whoop Downlink")
            {
                textBoxStartFrequency.Enabled = false;
                textBoxStopFrequency.Enabled = false;
                textBoxStepSize.Enabled = false;

                using (WhoopNodeForm mWhoopNodeDownlinkForm = new WhoopNodeForm())
                {
                    mWhoopNodeDownlinkForm.StartPosition = FormStartPosition.CenterParent;
                    var value = mWhoopNodeDownlinkForm.ShowDialog();
                    if (mWhoopNodeDownlinkForm.Selected)
                    {
                        bool b700 = mWhoopNodeDownlinkForm.Band_700;
                        bool b850 = mWhoopNodeDownlinkForm.Band_850;
                        bool bPCS = mWhoopNodeDownlinkForm.Band_PCS;
                        bool bAWS = mWhoopNodeDownlinkForm.Band_AWS;
                    }
                }

                return;
            }

            if (item == "Manual Configuration")
            {
                textBoxStartFrequency.Enabled = true;
                textBoxStopFrequency.Enabled = true;
                textBoxStepSize.Enabled = true;

                return;
            }
        }
    }
}
