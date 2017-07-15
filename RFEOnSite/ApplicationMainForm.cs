using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static RFEOnSite.RFExplorer;

namespace RFEOnSite
{
    public partial class MainForm : Form
    {
        private GlobalData gRFEOnSite;

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

            ComboBoxPreset.SelectedIndex = 0;

            InitializeChartUI();

            gRFEOnSite.FileOps.FolderDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;

            LabelCsvRootText.Text = "Root Folder for CSV Files:";

            ButtonSetConfiguration.Enabled = false;
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

            if (TextBoxStartFrequency.Text.Length > 0)
            {
                gRFEOnSite.Graph.MinX = Convert.ToInt32(TextBoxStartFrequency.Text);
            }

            if (TextBoxStopFrequency.Text.Length > 0)
            {
                gRFEOnSite.Graph.MaxX = Convert.ToInt32(TextBoxStopFrequency.Text);
            }

            gRFEOnSite.Graph.MaxY = -30;
            gRFEOnSite.Graph.MinY = -110;
            gRFEOnSite.Graph.BuildChart();
            gRFEOnSite.Graph.RemoveChartSeries("All");
            gRFEOnSite.Graph.Series = new Series();
            gRFEOnSite.Graph.Series.Points.AddXY(750, -30);
            gRFEOnSite.Graph.Chart.Series.Add(gRFEOnSite.Graph.Series);

            PanelChart.Controls.Add(gRFEOnSite.Graph.Chart);
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

            TextBoxStartFrequency.Text = fromSerialThread.StartMHz.ToString();

            stopMHz = (fromSerialThread.StepMHz * 112.0) + fromSerialThread.StartMHz;
            TextBoxStopFrequency.Text = Math.Round(stopMHz, 2).ToString();

            TextBoxRBW.Text = Math.Round(fromSerialThread.RBWKHz, 2).ToString();
            TextBoxStepSize.Text = Math.Round(fromSerialThread.StepMHz * 1000.0, 2).ToString();
            LabelDeviceText.Text = fromSerialThread.mMainModel.ToString();
            LabelModelText.Text = fromSerialThread.mExpansionModel.ToString();
            LabelFirmwareText.Text = fromSerialThread.FirmwareVersion;

            if (fromSerialThread.mMainModel == eModel.MODEL_6G)
            {
                RadioButtonAnalyzer.Checked = true;
                RadioButtonGenerator.Checked = false;
            }
            else
            {
                RadioButtonAnalyzer.Checked = false;
                RadioButtonGenerator.Checked = true;
            }
        }

        public void UIUpdateCallback_SweepData(List<string> sweepsFromExplorer)
        {
            // Executing on UI Thread with Series data gathered and consructed in passed from serial worker thread - which keeps righ on executing.
            // What is now stopping if mCapture is now false (set in thread). The thread will not capture more RF Explorer data until mCapture becomes true.

            // This gets called at the completion of the number of sweeps from the Explorer worker thread

#if DEBUG
            if (sweepsFromExplorer.Count != NumericUpDownSweeps.Value)
            {
                string message;
                string caption = "RF Explorer Sweep Error";
                message = "The Explorer READ thread returned " + sweepsFromExplorer.Count.ToString() + " out of " + NumericUpDownSweeps.Value.ToString() + " expected sweeps.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the Exception MessageBox.
                result = MessageBox.Show(message, caption, buttons);
            }
#endif

            // Copy Bytes to local list: gRFEOnSite.ExplorerSweepData
            // This List is available to both the Charts and CsvEXport classes
            gRFEOnSite.ExplorerSweepData.Clear();
            for (int i = 0; i < sweepsFromExplorer.Count; i++)
            {
                gRFEOnSite.ExplorerSweepData.Add(sweepsFromExplorer[i]);
            }

            // This really does appear to clear the thread mReceivedSweeps list 
            sweepsFromExplorer.Clear();

            // See if we have more frequencies to scan
            // If we don't: Just graph and/or csv save and then wait for the user to click something
            // If we do: send some sort of signal to get next frequency pair scanning in worker thread

            if (CheckBoxSaveCsvFiles.Checked)
            {
                string fileName = TextBoxSweepLocation.Text + "-" + gRFEOnSite.Explorer.SweepCount.ToString("D2") + " ";

                string dateString = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " ";

                string rangeString1 = Convert.ToInt64(TextBoxStartFrequency.Text.Replace(".", "")).ToString("D5") + "to";

                string rangeString2 = Convert.ToInt64(TextBoxStopFrequency.Text.Replace(".", "")).ToString("D5");

                string extra = "-" + NumericUpDownSweeps.Text + " at 000 Degrees.csv";

                TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + extra;

                gRFEOnSite.FileOps.FolderDialog.Description = "Create or Select Desktop Folder to Store CSV Files";
                gRFEOnSite.FileOps.FolderDialog.ShowDialog();

                string filePath = gRFEOnSite.FileOps.FolderDialog.SelectedPath + "\\" + TextBoxCsvFileName.Text;

                gRFEOnSite.FileOps.Path = filePath;

                gRFEOnSite.FileOps.ExportCsvFile();
                

            }



            if (gRFEOnSite.Graph.GraphAverage || gRFEOnSite.Graph.GraphPeak)
            {
                gRFEOnSite.Graph.DrawChart(gRFEOnSite.ExplorerSweepData);
            }

            ButtonStartSweeps.Enabled = true;
        }


        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
            // Pass "labelRFEComPort.Text" - a string - to Initialize() thread (await)
            // The thread then updates the GUI
            ButtonFindCOMPorts.Enabled = false;

            IProgress<string> UIComPortLabel = new Progress<string>(s => LabelRFEComPort.Text = s);
            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.InitializeSerialConnection(UIComPortLabel));

            if (!LabelRFEComPort.Text.Contains("COM"))
            {
                ButtonFindCOMPorts.Text = "Not Found. Try Again.";
                return;
            }

            ButtonFindCOMPorts.Text = "Connected";
            ButtonFindCOMPorts.Enabled = false;
            ButtonFindCOMPorts.BackColor = Color.Green;


            // A reference to the right hand side object (from the UI Thread) is passed to the thread through the left hand side IProcess object
            IProgress<RFEConfiguration> UpdateUIControls = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configuration(RFE));
            IProgress<List<string>> UpdateUISweepData = new Progress<List<string>>(SWEEPS => UIUpdateCallback_SweepData(SWEEPS));
            IProgress<int> UpdateUIProgressBar = new Progress<int>(s => TaskProgressBar.Value = s);

            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.AttachSerialPortAndReceiveDataThread(
                                    UpdateUIControls,
                                    UpdateUISweepData,
                                    UpdateUIProgressBar));


            ButtonSetConfiguration.Enabled = true;
        }

        private void ButtonSetConfiguration_Click(object sender, EventArgs e)
        {
            // ***********************************************************
            // ***********************************************************
            // Updates the physical RF Explorer with data from UI and then
            // Updates UI Graph with configuration data read from the UI
            // ***********************************************************
            // ***********************************************************

            double startMHz = Convert.ToDouble(TextBoxStartFrequency.Text);
            double stopMHz = Convert.ToDouble(TextBoxStopFrequency.Text);
            double stepKHZ = Convert.ToDouble(TextBoxStepSize.Text);

            gRFEOnSite.Explorer.SendConfiguration(startMHz, stopMHz);

            gRFEOnSite.Graph.MinX = startMHz;
            gRFEOnSite.Graph.MaxX = stopMHz;
            gRFEOnSite.Graph.StepX = stepKHZ / 1000.0;

            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Maximum = gRFEOnSite.Graph.MaxX;
            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Minimum = gRFEOnSite.Graph.MinX;

            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Interval = (gRFEOnSite.Graph.MaxX - gRFEOnSite.Graph.MinX) / 5;

            ButtonStartSweeps.Enabled = true;
        }

        private void buttonStartSweeps_Click(object sender, EventArgs e)
        {
            ButtonStartSweeps.Enabled = false;

            gRFEOnSite.Explorer.SweepCount = (int)NumericUpDownSweeps.Value;

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

                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    gRFEOnSite.Explorer.SweepCount = 1;

                    gRFEOnSite.Explorer.Capture = true;
                    break;
                }
            }
            else
            {
                if (CheckBoxChartAutoScale.Checked || CheckBoxChartAverage.Checked || CheckBoxChartPeak.Checked)
                {
                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    gRFEOnSite.Explorer.SweepCount = 1;

                    gRFEOnSite.Explorer.Capture = true;
                }
            }
        }

        private void CheckBoxSaveCsvFiles_CheckedChanged(object sender, EventArgs e)
        {
            //gRFEOnSite.Explorer.WriteCsvFiles = checkBoxSaveCsvFiles.Checked;

            //if (gRFEOnSite.Explorer.WriteCsvFiles)
            //{
            //    textBoxSweepLocation.Enabled = true;
            //    textBoxCsvFileName.Enabled = true;
            //    labelCsvRootText.Enabled = true;
            //    labelRootDirectory.Enabled = true;
            //    labelProgressWriteCsvFile.Enabled = true;
            //}
            //else
            //{
            //    textBoxSweepLocation.Enabled = false;
            //    textBoxCsvFileName.Enabled = false;
            //    labelCsvRootText.Enabled = false;
            //    labelRootDirectory.Enabled = false;
            //    labelProgressWriteCsvFile.Enabled = true;
            //}
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

            this.ToolTip1.SetToolTip(this.TextBoxSweepLocation, "Enter a short site collection location identifier " +
                "for data that is about to be collected.\nThis identifier will be used to create or enter a Desktop sub-folder to" +
                    " store collected data in CSV Files.");
        }

        private void CheckBoxChartAutoScale_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Graph.AutoScale = CheckBoxChartAutoScale.Checked;
        }

        private void LabelRightAttentaion_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxLeftSMAAttenuationValue_TextChanged(object sender, EventArgs e)
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
            if (ComboBoxPreset.SelectedItem == null)
                return;

            var item = (string)ComboBoxPreset.SelectedItem;

            if (item == "Whoop Downlink")
            {
                TextBoxStartFrequency.Enabled = false;
                TextBoxStopFrequency.Enabled = false;
                TextBoxRBW.Enabled = false;
                TextBoxStepSize.Enabled = false;
                ButtonSetConfiguration.Enabled = false;

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
                        ButtonStartSweeps.Enabled = true;
                        CheckBoxSaveCsvFiles.Checked = true;
                    }
                    else
                    {
                        TextBoxStartFrequency.Enabled = true;
                        TextBoxStopFrequency.Enabled = true;
                        TextBoxRBW.Enabled = true;
                        TextBoxStepSize.Enabled = true;
                        ButtonSetConfiguration.Enabled = true;
                    }
                }

                return;
            }

            if (item == "Manual Configuration")
            {
                gRFEOnSite.WhoopPresetActive = false;

                TextBoxStartFrequency.Enabled = true;
                TextBoxStopFrequency.Enabled = true;
                TextBoxRBW.Enabled = true;
                TextBoxStepSize.Enabled = true;
                ButtonSetConfiguration.Enabled = true;
                return;
            }
        }

        private void buttonDocumentation_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonAnalyzer.Checked)
                {
                    System.Diagnostics.Process.Start("http://j3.rf-explorer.com/download/docs/RF%20Explorer%20Spectrum%20Analyzer%20User%20Manual.pdf");
                }
                else
                {
                    if (RadioButtonGenerator.Checked)
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
            gRFEOnSite.Graph.GraphPeak = CheckBoxChartPeak.Checked;
            if (gRFEOnSite.Graph.GraphAverage == false && gRFEOnSite.Graph.GraphPeak == false)
            {
                CheckBoxChartAverage.Checked = true;
                gRFEOnSite.Graph.GraphAverage = true;
            }
        }

        private void checkBoxChartAverage_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Graph.GraphAverage = CheckBoxChartAverage.Checked;

            if (gRFEOnSite.Graph.GraphAverage == false && gRFEOnSite.Graph.GraphPeak == false)
            {
                CheckBoxChartPeak.Checked = true;
                gRFEOnSite.Graph.GraphPeak = true;
            }
        }
    }
}
