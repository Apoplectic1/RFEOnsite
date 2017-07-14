using RFEOnSite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static RFEOnsite.RFExplorer;

namespace RFEOnsite
{
    public partial class MainForm : Form
    {
        private GlobalData gRFEOnSite;
        private int mCsvFileSweepCount;
        private FolderBrowserDialog mFolderDialog;


        public MainForm()
        {
            gRFEOnSite = new GlobalData();

            InitializeComponent();

            // Versioning Text at top of Application Window
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

            comboBoxPreset.SelectedIndex = 0;

            InitializeChartUI();

            mFolderDialog = new FolderBrowserDialog();
            mFolderDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            labelCsvRootText.Text = "Root Folder for CSV Files:";
        }

        private void InitializeChartUI()
        {

            components = new Container();

            ((ISupportInitialize)(gRFEOnSite.Graph.Chart)).BeginInit();

            SuspendLayout();

            gRFEOnSite.Graph.Chart.Dock = DockStyle.Fill;
            gRFEOnSite.Graph.Chart.Location = new Point(0, 50);

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;

            // Use this to resize Client Area
            //this.ClientSize = new System.Drawing.Size(284, 262); 

            Load += new EventHandler(Form1_Load);

            ((ISupportInitialize)(gRFEOnSite.Graph.Chart)).EndInit();

            ResumeLayout(false);
        }

        void Form1_Load(object sender, EventArgs e)
        {

            // This builds a dummy chart on the GUI and adds a dummy point to draw and not show white space
            // Prolly not the correct way of initializing

            if (textBoxStartFrequency.Text.Length > 0)
            {
                gRFEOnSite.Graph.MinX = Convert.ToInt32(textBoxStartFrequency.Text);
            }

            if (textBoxStopFrequency.Text.Length > 0)
            {
                gRFEOnSite.Graph.MaxX = Convert.ToInt32(textBoxStopFrequency.Text);
            }

            gRFEOnSite.Graph.MaxY = -30;
            gRFEOnSite.Graph.MinY = -110;
            gRFEOnSite.Graph.BuildChart();
            gRFEOnSite.Graph.RemoveChartSeries("All");
            gRFEOnSite.Graph.Series = new Series();
            gRFEOnSite.Graph.Series.Points.AddXY(750, -30);
            gRFEOnSite.Graph.Chart.Series.Add(gRFEOnSite.Graph.Series);

            panelChart.Controls.Add(gRFEOnSite.Graph.Chart);
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

        public void UIUpdateCallback_RFE_Configuration(RFEConfiguration fromSerialThread)
        {
            // Executing on UI Thread with Series data gathered and consructed in passed from serial worker thread

            // *********************************************************************
            // *********************************************************************
            // Updates UI with configuration data read from the physical RF Explorer
            // *********************************************************************
            // *********************************************************************
            double stopMHz;
          
            textBoxStartFrequency.Text = fromSerialThread.StartMHz.ToString();

            stopMHz = (fromSerialThread.StepMHz * 112.0) + fromSerialThread.StartMHz;
            textBoxStopFrequency.Text = Math.Round(stopMHz, 2).ToString();

            textBoxRBW.Text = Math.Round(fromSerialThread.RBWKHz, 2).ToString();
            textBoxStepSize.Text = Math.Round(fromSerialThread.StepMHz * 1000.0, 2).ToString();
            labelDeviceText.Text = fromSerialThread.mMainModel.ToString();
            labelModelText.Text = fromSerialThread.mExpansionModel.ToString();
            labelFirmwareText.Text = fromSerialThread.FirmwareVersion;

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

            //gRFEOnSite.ConfigurationState = true;
        }

        public void UIUpdateCallback_Chart(Series seriesFromExplorer)
        {
            // Executing on UI Thread with Series data gathered and consructed in passed from serial worker thread
            gRFEOnSite.Graph.RemoveChartSeries("All");

            if (checkBoxChartPeak.Checked)
            {
                //newSeries = SeriesPeak(newSeries);

                seriesFromExplorer.Color = Color.DarkRed;
                seriesFromExplorer.Name = "Peak";
                gRFEOnSite.Graph.Chart.Series.Add(seriesFromExplorer);
            }
        }

        public void UIUpdateCallback_SweepData(List<string> sweepsFromExplorer)
        {
            // Executing on UI Thread with Series data gathered and consructed in passed from serial worker thread - which keeps righ on executing.
            // What is now stopping if mCapture is now false (set in thread). The thread will not capture more RF Explorer data until mCapture becomes true.

            // This gets called at the completion of the number of sweeps from the Explorer worker thread

            if (sweepsFromExplorer.Count != numericUpDownSweeps.Value)
            {
                string message;
                string caption = "RF Explorer Sweep Error";
                message = "The Explorer READ thread returned " + sweepsFromExplorer.Count.ToString() + " out of " + numericUpDownSweeps.Value.ToString() + " expected sweeps.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the Exception MessageBox.
                result = MessageBox.Show(message, caption, buttons);
            }

            // Copy Bytes to local list: gRFEOnSite.ExplorerSweepData
            // This List is available to both the Charts and CsvEXport classes
            gRFEOnSite.ExplorerSweepData.Clear();
            for (int i = 0; i < sweepsFromExplorer.Count; i++)
            {
                gRFEOnSite.ExplorerSweepData.Add(sweepsFromExplorer[i]);
            }

            // This really does appear to clear the thread mReceivedSweeps list 
            sweepsFromExplorer.Clear();

            gRFEOnSite.GraphAverage = checkBoxChartAverage.Checked;
            gRFEOnSite.GraphPeak = checkBoxChartPeak.Checked;

            if (checkBoxSaveCsvFiles.Checked)
            {
                //gRFEOnSite.CsvFiles.WriteFile(gRFEOnSite.ExplorerSweepData);
            }

            List<string> value = gRFEOnSite.ExplorerSweepData;


            // See if we have more frequencies to scan
            // If we don't: Just graph and/or csv save and then wait for the user to click something
            // If we do: send some sort of signal to get next frequency pair scanning in worker thread

            // Temp: one pair and graph and csv Write

            // Now Graph and/or Write CSV Files

            if (gRFEOnSite.GraphAverage || gRFEOnSite.GraphPeak)
            {
                gRFEOnSite.Graph.DrawChart(gRFEOnSite.ExplorerSweepData);
            }

            if (checkBoxSaveCsvFiles.Checked)
            {
                //gRFEOnSite.CsvFiles.WriteFile();
            }

            buttonStartSweeps.Enabled = true;
        }


        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
            // Pass "labelRFEComPort.Text" - a string - to Initialize() thread (await)
            // The thread then updates the GUI
            buttonFindCOMPorts.Enabled = false;

            IProgress<string> UIComPortLabel = new Progress<string>(s => labelRFEComPort.Text = s);
            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.InitializeSerialConnection(UIComPortLabel));

            if (!labelRFEComPort.Text.Contains("COM"))
            {
                buttonFindCOMPorts.Text = "Not Found. Try Again.";
                return;
            }

            buttonFindCOMPorts.Text = "Connected";
            buttonFindCOMPorts.Enabled = false;
            buttonFindCOMPorts.BackColor = Color.Green;

  
            // A reference to the right hand side object (from the UI Thread) is passed to the thread through the left hand side IProcess object
            IProgress<RFEConfiguration> UpdateUIControls    = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configuration(RFE));
            IProgress<List<string>> UpdateUISweepData       = new Progress<List<string>>(SWEEPS => UIUpdateCallback_SweepData(SWEEPS));
            IProgress<int> UpdateUIProgressBar              = new Progress<int>(s => TaskProgressBar.Value = s);

            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.AttachSerialPortAndReceiveDataThread(
                                    UpdateUIControls,
                                    UpdateUISweepData,
                                    UpdateUIProgressBar));
                                 

            buttonSetConfiguration.Enabled = true;
        }

        private void buttonSetConfiguration_Click(object sender, EventArgs e)
        {
            // ***********************************************************
            // ***********************************************************
            // Updates the physical RF Explorer with data from UI and then
            // Updates UI Graph with configuration data read from the UI
            // ***********************************************************
            // ***********************************************************

            double startMHz = Convert.ToDouble(textBoxStartFrequency.Text);
            double stopMHz = Convert.ToDouble(textBoxStopFrequency.Text);
            double stepKHZ = Convert.ToDouble(textBoxStepSize.Text);

            gRFEOnSite.Explorer.SendConfiguration(startMHz, stopMHz);
            
            gRFEOnSite.Graph.MinX = startMHz;
            gRFEOnSite.Graph.MaxX = stopMHz;
            gRFEOnSite.Graph.StepX = stepKHZ / 1000.0;

            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Maximum = gRFEOnSite.Graph.MaxX;
            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Minimum = gRFEOnSite.Graph.MinX;

            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Interval = (gRFEOnSite.Graph.MaxX - gRFEOnSite.Graph.MinX) / 5;

            buttonStartSweeps.Enabled = true;
        }

        private void buttonStartSweeps_Click(object sender, EventArgs e)
        {
            buttonStartSweeps.Enabled = false;

            gRFEOnSite.Explorer.SweepCount = (int)numericUpDownSweeps.Value;

            if (gRFEOnSite.WhoopPresetActive)
            {
                foreach (FrequencyTable pair in gRFEOnSite.WhoopDownLinkFrequencies)
                {
                    double start = pair.start;
                    double stop = pair.stop;

                    gRFEOnSite.Explorer.SendConfiguration(start, stop);

                    System.Threading.Thread.Sleep(100);

                    gRFEOnSite.Graph.MinX = start;
                    gRFEOnSite.Graph.MaxX = stop;
                    gRFEOnSite.Graph.StepX = 0.10;

                    //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Maximum = gRFEOnSite.Graph.MaxX;
                    //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Minimum = gRFEOnSite.Graph.MinX;

                    //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Interval = (gRFEOnSite.Graph.MaxX - gRFEOnSite.Graph.MinX) / 5;

                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    mCsvFileSweepCount = 1;

                    gRFEOnSite.Explorer.Capture = true;
                    break;
                }
            }
            else
            {
                if (checkBoxChartRealTime.Checked || checkBoxChartAverage.Checked || checkBoxChartPeak.Checked)
                {
                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    //buttonStartSweeps.Text = "Cancel";
                    mCsvFileSweepCount = 1;

                    gRFEOnSite.Explorer.Capture = true;
                }
            }
        }

        private void checkBoxSaveCsvFiles_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Explorer.WriteCsvFiles = checkBoxSaveCsvFiles.Checked;

            if (gRFEOnSite.Explorer.WriteCsvFiles)
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
                gRFEOnSite.Explorer.Capture = true;
            }
            else
            {
                checkBoxChartAverage.Enabled = false;
                checkBoxChartPeak.Enabled = false;
                gRFEOnSite.Explorer.Capture = false;
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

        private void comboBoxPreset_IndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPreset.SelectedItem == null)
                return;

            var item = (string)comboBoxPreset.SelectedItem;

            if (item == "Whoop Downlink")
            {
                textBoxStartFrequency.Enabled = false;
                textBoxStopFrequency.Enabled = false;
                textBoxRBW.Enabled = false;
                textBoxStepSize.Enabled = false;
                buttonSetConfiguration.Enabled = false;

                using (WhoopNodeForm mWhoopNodeDownlinkForm = new WhoopNodeForm())
                {
                    mWhoopNodeDownlinkForm.CheckBox700 = gRFEOnSite.Whoop700;
                    mWhoopNodeDownlinkForm.CheckBox850 = gRFEOnSite.Whoop850;
                    mWhoopNodeDownlinkForm.CheckBoxPCS = gRFEOnSite.WhoopPCS;
                    mWhoopNodeDownlinkForm.CheckBoxAWS = gRFEOnSite.WhoopAWS;

                    mWhoopNodeDownlinkForm.StartPosition = FormStartPosition.CenterParent;

                    mWhoopNodeDownlinkForm.ShowDialog();

                    gRFEOnSite.WhoopPresetActive = mWhoopNodeDownlinkForm.Selected;

                    if (gRFEOnSite.WhoopPresetActive)
                    {
                        gRFEOnSite.Whoop700 = mWhoopNodeDownlinkForm.CheckBox700;
                        gRFEOnSite.Whoop850 = mWhoopNodeDownlinkForm.CheckBox850;
                        gRFEOnSite.WhoopPCS = mWhoopNodeDownlinkForm.CheckBoxPCS;
                        gRFEOnSite.WhoopAWS = mWhoopNodeDownlinkForm.CheckBoxAWS;
                    }
                    else
                    {
                        textBoxStartFrequency.Enabled = true;
                        textBoxStopFrequency.Enabled = true;
                        textBoxRBW.Enabled = true;
                        textBoxStepSize.Enabled = true;
                        buttonSetConfiguration.Enabled = true;
                    }
                }
                
                return;
            }

            if (item == "Manual Configuration")
            {
                gRFEOnSite.WhoopPresetActive = false;

                textBoxStartFrequency.Enabled = true;
                textBoxStopFrequency.Enabled = true;
                textBoxRBW.Enabled = true;
                textBoxStepSize.Enabled = true;
                buttonSetConfiguration.Enabled = true;
                return;
            }
        }

        private void buttonDocumentation_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAnalyzer.Checked)
                {
                    System.Diagnostics.Process.Start("http://j3.rf-explorer.com/download/docs/RF%20Explorer%20Spectrum%20Analyzer%20User%20Manual.pdf");
                }
                else
                {
                    if (radioButtonGenerator.Checked)
                    { 
                        System.Diagnostics.Process.Start("http://j3.rf-explorer.com/download/docs/RF%20Explorer%20Signal%20Generator%20User%20Manual.pdf");
                    }
                    else
                    {
                        System.Diagnostics.Process.Start("http://j3.rf-explorer.com/download/docs/RF%20Explorer%20Spectrum%20Analyzer%20User%20Manual.pdf");
                    }
                }
            }

            catch
            {
                string message; // = obException.ToString();
                string caption = "Can't connect to the RF Explorer website.";
                message = "This is probably due to a lack of Internet connectivity for this PC/Tablet.\nEstablish connectivity and try again.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the Exception MessageBox.
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void checkBoxChartPeak_CheckedChanged(object sender, EventArgs e)
        {
         
            if (checkBoxChartPeak.Checked)
            {
                gRFEOnSite.Graph.Chart.Series["Peak"].Enabled = true;
            }
            else
            {
                gRFEOnSite.Graph.Chart.Series["Peak"].Enabled = false;
            }
        }
    }
}
