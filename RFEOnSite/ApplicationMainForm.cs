using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static RFEOnSite.RFExplorer;

namespace RFEOnSite
{
    public partial class MainForm : Form
    {
        public GlobalData gRFEOnSite;
        
        public MainForm()
        {

            gRFEOnSite = new GlobalData();

            InitializeComponent();

            // Versioning Text at top of Application Window
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                Version version = ad.CurrentVersion;
                Text = "RF Explorer OnSite - Version: " + version.ToString();
            }
            else
            {
                Text = "RF Explorer OnSite - Version: " + System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString("yyyy.MM.dd - HHMM");
            }

            ComboBoxPreset.SelectedIndex = 0;
            //ComboBoxPreset.Enabled = false;

            InitializeChartUI();

            // Navigate to and set User's Desktop as current working Directory
            // Force Dialog to Desktop ONLY
            gRFEOnSite.FileOps.FolderDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            gRFEOnSite.FileOps.CreateEnterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // Navigate to, Create if needed, and Enter SurveyData Desktop/SurveyData
            gRFEOnSite.FileOps.CreateEnterDirectory("SurveyData");

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
                RadioButtonGenerator.Enabled = false;
            }
            else
            {
                RadioButtonAnalyzer.Checked = false;
                RadioButtonGenerator.Checked = true;
                RadioButtonAnalyzer.Enabled = false;
            }

            //mConfigurationState = eConfigState.eExplorerValid;

        }

        public void UIUpdateCallback_SweepData(List<string> sweepsFromExplorer)
        {
            // Executing on UI Thread with Series data gathered and consructed in passed from serial worker thread - which keeps righ on executing.
            // What is now stopping if mCapture is now false (set in thread). The thread will not capture more RF Explorer data until mCapture becomes true.

            // This gets called at the completion of the number of sweeps from the Explorer worker thread

            //#if DEBUG
            //if (sweepsFromExplorer.Count != NumericUpDownSweeps.Value)
            //{
            //    string message;
            //    string caption = "RF Explorer Sweep Error";
            //    message = "The Explorer READ thread returned " + sweepsFromExplorer.Count.ToString() + " out of " + NumericUpDownSweeps.Value.ToString() + " expected sweeps.";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    DialogResult result;

            //    // Displays the Exception MessageBox.
            //    result = MessageBox.Show(message, caption, buttons);
            //}
            //#endif

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

            // If Save CSV Files, Housekeeping to get a valid location
            while (CheckBoxSaveCsvFiles.Checked && TextBoxSweepLocation.Text == "Enter Collection Location Identifier")
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = "Enter a location identifier for the current Sweep(s):",
                    StartPosition = FormStartPosition.CenterParent
                };

                Label textLabel = new Label() { Left = 50, Top = 20, Text = "Survey Location:" };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 350 };
                Button confirmation = new Button() { Text = "OK", Left = 300, Width = 100, Top = 75, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                while (!gRFEOnSite.FileOps.IsValidPath(TextBoxSweepLocation.Text) )
                {
                    if (prompt.ShowDialog(this) == DialogResult.OK)
                    {
                        // Read the contents of testDialog's TextBox.
                        TextBoxSweepLocation.Text = textBox.Text;
                        if (TextBoxSweepLocation.Text == "")
                        {
                            TextBoxSweepLocation.Text = "Enter Collection Location Identifier";
                        }
                    }
                    else
                    {
                        // User closed DialogBox by "X";
                        CheckBoxSaveCsvFiles.Checked = false;
                    }
                }
                prompt.Dispose();
            }

           
            if (CheckBoxSaveCsvFiles.Checked)
            {
                if (gRFEOnSite.FileOps.FolderDialog.SelectedPath.Length == 0)
                {
                    gRFEOnSite.FileOps.FolderDialog.SelectedPath = gRFEOnSite.FileOps.PeekCwdDirectory();
                    gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxSweepLocation.Text);

                    gRFEOnSite.FileOps.FolderDialog.Description = "Create or Select Desktop SubFolder to Store CSV Files for location:\n\n   " + TextBoxSweepLocation.Text;
                    gRFEOnSite.FileOps.FolderDialog.ShowDialog();
                }

                string fileName = TextBoxSweepLocation.Text + "-" + gRFEOnSite.FileOps.FileCounter.ToString("D2") + " ";

                string dateString = gRFEOnSite.FileOps.RunStartTime.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " ";

                string rangeString1 = Convert.ToInt64(TextBoxStartFrequency.Text.Replace(".", "")).ToString("D5") + "to";

                string rangeString2 = Convert.ToInt64(TextBoxStopFrequency.Text.Replace(".", "")).ToString("D5");

                //string extra = "-" + NumericUpDownSweeps.Text + " at 000 Degrees.csv";
                string extra = "-" + NumericUpDownSweeps.Text + " Omni.csv";

                TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + extra;

                string filePath = gRFEOnSite.FileOps.FolderDialog.SelectedPath + "\\" + TextBoxCsvFileName.Text;

                gRFEOnSite.FileOps.Path = filePath;

                gRFEOnSite.FileOps.ExportCsvFile(gRFEOnSite.Graph.MinX, gRFEOnSite.Graph.MaxX, gRFEOnSite.ExplorerSweepData);

                gRFEOnSite.FileOps.FileCounter++;
            }



            if (gRFEOnSite.Graph.GraphAverage || gRFEOnSite.Graph.GraphPeak)
            {
                gRFEOnSite.Graph.DrawChart(gRFEOnSite.ExplorerSweepData);
            }
            
            if (gRFEOnSite.FileOps.FileCounter == gRFEOnSite.PresetTable.Count() + 1)
            {
                LabelTask.Text = "Done";
            }

            //*****************************************************
            // SETUP AND GET NEXT SWEEP
            //*****************************************************
            // Preset Mode -- 
            // Automatically get, populate and set sweep start and stop frequency pairs and cycle through the list of them
            // The first pair is determnined and set from the "Capture" Clicked Event (method) on the UI.
            // This gets the 'next' values and then sweeps with them

            if (gRFEOnSite.WhoopPresetActive)
            {
                foreach (PresetTableEntry pair in gRFEOnSite.PresetTable.Skip(gRFEOnSite.PresetTableIndex))
                {
                    gRFEOnSite.PresetTableIndex++;

                    switch (pair.SweepBand)
                    {
                        case eBand.e700:
                            if (!gRFEOnSite.Whoop700) continue;
                            break;
                        case eBand.e850:
                            if (!gRFEOnSite.Whoop850) continue;
                            break;
                        case eBand.ePCS:
                            if (!gRFEOnSite.WhoopPCS) continue;
                            break;
                        case eBand.eAWS:
                            if (!gRFEOnSite.WhoopAWS) continue;
                            break;
                        default:
                            continue;
                    }

                    gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                    System.Threading.Thread.Sleep(100);

                    gRFEOnSite.Graph.MinX = pair.SweepStart;
                    gRFEOnSite.Graph.MaxX = pair.SweepStop;

                    gRFEOnSite.Explorer.SweepCount = (int)NumericUpDownSweeps.Value;

                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    gRFEOnSite.Explorer.Capture = true;
                    LabelTask.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetTable.Count();
                    break;
                }
            }
            else
            {
                LabelTask.Text = "Done";
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
            ButtonGetConfiguration.Enabled = true;
            ComboBoxPreset.Enabled = true;
            //mConfigurationState = eConfigState.eInvalid;
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

            //mConfigurationState = eConfigState.eExplorerUpdate;

            gRFEOnSite.Explorer.SendConfiguration(startMHz, stopMHz, -80, -110);

            gRFEOnSite.Graph.MinX = startMHz;
            gRFEOnSite.Graph.MaxX = stopMHz;

            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Maximum = gRFEOnSite.Graph.MaxX;
            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Minimum = gRFEOnSite.Graph.MinX;

            gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Interval = (gRFEOnSite.Graph.MaxX - gRFEOnSite.Graph.MinX) / 5;

            ButtonStartSweeps.Enabled = true;
        }

        private void ButtonStartSweeps_Click(object sender, EventArgs e)
        {
            ButtonStartSweeps.Enabled = false;
            gRFEOnSite.FileOps.FileCounter = 1;
            gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
            gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;

            gRFEOnSite.Explorer.SweepCount = (int)NumericUpDownSweeps.Value;

            if (gRFEOnSite.WhoopPresetActive)
            {
                gRFEOnSite.PresetTableIndex = 0;
                foreach (PresetTableEntry pair in gRFEOnSite.PresetTable)
                {
                    gRFEOnSite.PresetTableIndex++;

                    LabelTask.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetTable.Count();

                    switch (pair.SweepBand)
                    {
                        case eBand.e700:
                            if (!gRFEOnSite.Whoop700) continue;
                            break;
                        case eBand.e850:
                            if (!gRFEOnSite.Whoop850) continue;
                            break;
                        case eBand.ePCS:
                            if (!gRFEOnSite.WhoopPCS) continue;
                            break;
                        case eBand.eAWS:
                            if (!gRFEOnSite.WhoopAWS) continue;
                            break;
                        default:
                            continue;
                    }

                    gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                    System.Threading.Thread.Sleep(100);

                    gRFEOnSite.Graph.MinX = pair.SweepStart;
                    gRFEOnSite.Graph.MaxX = pair.SweepStop;

                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    gRFEOnSite.Explorer.Capture = true;
                    break;
                }
            }
            else
            {
                LabelTask.Text = "1 of 1";
                TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                TaskProgressBar.Step = 1;
                TaskProgressBar.Value = 0;

                gRFEOnSite.Explorer.Capture = true;

            }
        }

        private void CheckBoxSaveCsvFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxSaveCsvFiles.Checked)
            {
                TextBoxSweepLocation.Enabled = true;
                TextBoxCsvFileName.Enabled = true;
                LabelCsvRootText.Enabled = true;
                LabelRootDirectory.Enabled = true;
                LabelProgressWriteCsvFile.Enabled = true;
            }
            else
            {
                TextBoxSweepLocation.Enabled = false;
                TextBoxCsvFileName.Enabled = false;
                LabelCsvRootText.Enabled = false;
                LabelRootDirectory.Enabled = false;
                LabelProgressWriteCsvFile.Enabled = true;
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

        private void TextBoxSweepLocation_TextChanged(object sender, EventArgs e)
        {

            ToolTip1.SetToolTip(TextBoxSweepLocation, "Enter a short site collection location identifier " +
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

        private void LabelLeftSMAAttenuationText_Click(object sender, EventArgs e)
        {

        }

        private void LabelRightSMAAttenuationText_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxRightSMAAttentuationValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxPreset_IndexChanged(object sender, EventArgs e)
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
                    mWhoopNodeDownlinkForm.PresetFormCheckBox700 = gRFEOnSite.Whoop700;
                    mWhoopNodeDownlinkForm.PresetFormCheckBox850 = gRFEOnSite.Whoop850;
                    mWhoopNodeDownlinkForm.PresetFormCheckBoxPCS = gRFEOnSite.WhoopPCS;
                    mWhoopNodeDownlinkForm.PresetFormCheckBoxAWS = gRFEOnSite.WhoopAWS;

                    mWhoopNodeDownlinkForm.StartPosition = FormStartPosition.CenterParent;

                    mWhoopNodeDownlinkForm.ShowDialog();

                    gRFEOnSite.WhoopPresetActive = mWhoopNodeDownlinkForm.Selected;

                    if (gRFEOnSite.WhoopPresetActive)
                    {
                        gRFEOnSite.Whoop700 = mWhoopNodeDownlinkForm.PresetFormCheckBox700;
                        gRFEOnSite.Whoop850 = mWhoopNodeDownlinkForm.PresetFormCheckBox850;
                        gRFEOnSite.WhoopPCS = mWhoopNodeDownlinkForm.PresetFormCheckBoxPCS;
                        gRFEOnSite.WhoopAWS = mWhoopNodeDownlinkForm.PresetFormCheckBoxAWS;
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

        private void ButtonDocumentation_Click(object sender, EventArgs e)
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

        private void CheckBoxChartPeak_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Graph.GraphPeak = CheckBoxChartPeak.Checked;
            if (gRFEOnSite.Graph.GraphAverage == false && gRFEOnSite.Graph.GraphPeak == false)
            {
                CheckBoxChartAverage.Checked = true;
                gRFEOnSite.Graph.GraphAverage = true;
            }
        }

        private void CheckBoxChartAverage_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Graph.GraphAverage = CheckBoxChartAverage.Checked;

            if (gRFEOnSite.Graph.GraphAverage == false && gRFEOnSite.Graph.GraphPeak == false)
            {
                CheckBoxChartPeak.Checked = true;
                gRFEOnSite.Graph.GraphPeak = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gRFEOnSite.Explorer.RequestConfiguration();
        }

        private void TextBoxStartFrequency_TextChanged(object sender, EventArgs e)
        {
            double start, stop, stepSize;
            bool bStatus;

            bStatus = Double.TryParse(TextBoxStartFrequency.Text, out start);
            bStatus &= Double.TryParse(TextBoxStopFrequency.Text, out stop);

            if (bStatus)
            {
                if (stop > start)
                {
                    stepSize = (stop - start) / .1120;
                    TextBoxStepSize.Text = stepSize.ToString("F0");
                }
            }
        }

        private void TextBoxStopFrequency_TextChanged(object sender, EventArgs e)
        {
            double start, stop, stepSize;
            bool bStatus;

            bStatus = Double.TryParse(TextBoxStartFrequency.Text, out start);
            bStatus &= Double.TryParse(TextBoxStopFrequency.Text, out stop);

            if (bStatus)
            {
                if (stop > start)
                {
                    stepSize = (stop - start) / .1120;
                    TextBoxStepSize.Text = stepSize.ToString("F0");
                }
            }
        }

        private void RadioButtonAnalyzer_CheckedChanged(object sender, EventArgs e)
        {
            buttonDocumentation.Text = "RF Explorer Documentation";
        }

        private void RadioButtonGenerator_CheckedChanged(object sender, EventArgs e)
        {
            buttonDocumentation.Text = "RFE Generator Documentation";
        }

        private void ButtonCancelSweeps_Click(object sender, EventArgs e)
        {
            gRFEOnSite.Explorer.SweepCount = 1;
            gRFEOnSite.PresetTableIndex = gRFEOnSite.PresetTable.Count();
        }
    }
}
