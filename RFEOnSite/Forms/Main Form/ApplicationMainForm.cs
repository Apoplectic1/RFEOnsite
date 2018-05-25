using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static RFEOnSite.RFExplorer;

using Emgu.CV;
using System.Drawing.Imaging;
using System.Threading;
using System.Media;
using RFE_OnSite.Properties;

namespace RFEOnSite
{
    public partial class MainForm : Form
    {
        public GlobalData gRFEOnSite;

        public MainForm()
        {

            //if (Debugger.IsAttached)
            //    Settings.Default.Reset();


            gRFEOnSite = new GlobalData();

            InitializeComponent();

            // User Events
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);

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
            gRFEOnSite.FileOps.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // Navigate to, Create if needed, and Enter SurveyData Desktop/SurveyData
            //gRFEOnSite.FileOps.CreateEnterDirectory("SurveyData");

            ButtonSetConfiguration.Enabled = false;
            //NumericUpDownMarkerNumber.Enabled = false;
            //CheckBoxAutoIncrementMarkerNumber.Enabled = false;

            TabControlSiteImage.Enabled = false;

            Application.Idle += ProcessVideoFrame;
            gRFEOnSite.CsvDirectoryValid = false;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
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

            Load += new EventHandler(MainForm_Load);

            ((ISupportInitialize)(gRFEOnSite.Graph.Chart)).EndInit();

            ResumeLayout(false);
        }

        void MainForm_Load(object sender, EventArgs e)
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

            gRFEOnSite.Graph.ChartTitle = "Range: " + gRFEOnSite.Graph.MinX.ToString() + " to " + gRFEOnSite.Graph.MaxX + " MHz";
            gRFEOnSite.Graph.MaxY = -30;
            gRFEOnSite.Graph.MinY = -110;
            gRFEOnSite.Graph.BuildChart();
            gRFEOnSite.Graph.RemoveChartSeries("All");
            gRFEOnSite.Graph.Series = new Series();
            gRFEOnSite.Graph.Series.Points.AddXY(750, -30);
            gRFEOnSite.Graph.Chart.Series.Add(gRFEOnSite.Graph.Series);

            PanelChart.Controls.Add(gRFEOnSite.Graph.Chart);

            RecallUiPersistanceStates();
        }
        private void MainForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //Display a MsgBox asking the user to close the form.
            if (MessageBox.Show("Are you sure you want to close the Application?", "Close RFEOnSite?",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Cancel the Closing event
                e.Cancel = true;
                return;
            }

            SaveUiPersistanceStatesInternal();
            Settings.Default.Save();

            gRFEOnSite.Explorer.DestroyReceiveDataThread();
            gRFEOnSite.Explorer.DisconnectSerialPort();
        }

        void SaveUiPersistanceStatesInternal()
        {
            Settings.Default.Persist_SaveCsvCheckedState = this.CheckBoxSaveCsvFiles.Checked;

            Settings.Default.Persist_ClientTextState = this.TextBoxClient.Text;
            Settings.Default.Persist_LocationTextState = this.TextBoxCollectionLocation.Text;

            Settings.Default.Persist_FloorTextState = this.TextBoxFloorName.Text;
            Settings.Default.Persist_FloorNumberState = this.NumericUpDownFloorNumber.Value;
            Settings.Default.Persist_FloorEnableState = this.ButtonFloorId.Text;
            Settings.Default.Persist_FloorDecrementState = this.RadioButtonFloorDecrement.Checked;

            Settings.Default.Persist_MarkerTextState = this.TextBoxMarkerName.Text;
            Settings.Default.Persist_MarkerNumberState = this.NumericUpDownMarkerNumber.Value;
            Settings.Default.Persist_MarkerIncrementState = this.CheckBoxAutoIncrementMarkerNumber.Checked;


            Settings.Default.Persist_AutoScaleState = this.CheckBoxChartAutoScale.Checked;
            Settings.Default.Persist_AverageState = this.CheckBoxChartAverage.Checked;
            Settings.Default.Persist_PeakState = this.CheckBoxChartPeak.Checked;
            Settings.Default.Persist_SweepsCountState = this.NumericUpDownSweeps.Value;

            Settings.Default.Persist_Preset = this.ComboBoxPreset.SelectedItem.ToString();
            Settings.Default.Persist_2400State = this.force2400BaudToolStripMenuItem.Checked;
        }

        void RecallUiPersistanceStates()
        {
            this.CheckBoxSaveCsvFiles.Checked = Settings.Default.Persist_SaveCsvCheckedState;
            if (CheckBoxSaveCsvFiles.Checked)
            {
                GroupBoxCsvInformation.Enabled = true;
            }
            else
            {
                GroupBoxCsvInformation.Enabled = false;
            }

            this.TextBoxClient.Text = Settings.Default.Persist_ClientTextState;
            this.TextBoxCollectionLocation.Text = Settings.Default.Persist_LocationTextState;

            this.TextBoxFloorName.Text = Settings.Default.Persist_FloorTextState;
            this.NumericUpDownFloorNumber.Value = Settings.Default.Persist_FloorNumberState;
            this.ButtonFloorId.Text = Settings.Default.Persist_FloorEnableState;
            this.RadioButtonFloorDecrement.Checked = Settings.Default.Persist_FloorDecrementState;
            RadioButtonFloorIncrement.Checked = !RadioButtonFloorDecrement.Checked;

            this.TextBoxMarkerName.Text = Settings.Default.Persist_MarkerTextState;
            this.NumericUpDownMarkerNumber.Value = Settings.Default.Persist_MarkerNumberState;
            this.CheckBoxAutoIncrementMarkerNumber.Checked = Settings.Default.Persist_MarkerIncrementState;

            this.CheckBoxChartAutoScale.Checked = Settings.Default.Persist_AutoScaleState;
            this.CheckBoxChartAverage.Checked = Settings.Default.Persist_AverageState;
            this.CheckBoxChartPeak.Checked = Settings.Default.Persist_PeakState;
            this.NumericUpDownSweeps.Value = Settings.Default.Persist_SweepsCountState;
            this.force2400BaudToolStripMenuItem.Checked = Settings.Default.Persist_2400State;

            //this.ComboBoxPreset.SelectedItem = Settings.Default.Persist_Preset;
            this.ComboBoxPreset.SelectedItem = "Manual";
        }

        public void UIUpdateCallback_RFE_Configuration(RFEConfiguration fromSerialThread)
        {
            // ***********************************************************************************
            // Updates UI with configuration data read from the physical RF Explorer worker thread
            // fromSerialThread is constructed and populated by RFEConfiguration.cs
            // ***********************************************************************************

            double startMHz = fromSerialThread.StartMHz;
            TextBoxStartFrequency.Text = startMHz.ToString();
            double stopMHz = (fromSerialThread.StepMHz * 112.0) + fromSerialThread.StartMHz;
            TextBoxStopFrequency.Text = Math.Round(stopMHz, 2).ToString();

            TextBoxRBW.Text = Math.Round(fromSerialThread.RBWKHz, 2).ToString();
            //TextBoxStepFrequency.Text = Math.Round(fromSerialThread.StepMHz * 1000.0, 2).ToString();
            TextBoxStepFrequency.Text = (fromSerialThread.StepMHz * 1000.0).ToString("F2");

            LabelDeviceText.Text = fromSerialThread.mMainModel.ToString();
            LabelModelText.Text = fromSerialThread.mExpansionModel.ToString();
            LabelFirmwareText.Text = fromSerialThread.FirmwareVersion;

            gRFEOnSite.SerialNumebr = fromSerialThread.mSerialNumber;


            if (TextBoxStartFrequency.Text == TextBoxStopFrequency.Text)
            {
                string caption = "Unexpected RF Explorer Configuration Returned";
                string message = "The returned starting and stopping frequencies are identical.\n\nEasy Fix:\n\t1. Disconnect the RF Explorer USB Cable.\n\t2. Cycle RF Explorer Power.\n\t3. Reconnect and try again.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                Application.Exit();
            }

            gRFEOnSite.Explorer.WaitingForConfigurationCallBack = false;

            // Table Updates Only
            gRFEOnSite.StartFrequency = startMHz;
            gRFEOnSite.StopFrequency = stopMHz;
            gRFEOnSite.ResolutionBandWidth = fromSerialThread.RBWKHz;
            gRFEOnSite.FrequencyStepSize = fromSerialThread.StepMHz;

            if (fromSerialThread.mMainModel == eModel.MODEL_6G)
            {
                if (!gRFEOnSite.PresetActive)
                {
                    ButtonStartSweeps.Enabled = true;
                    ButtonSetConfiguration.Enabled = true;
                }

                GroupBoxSweepConfiguration.Enabled = true;
                RadioButtonAnalyzer.Checked = true;
                RadioButtonGenerator.Checked = false;
                RadioButtonGenerator.Enabled = false;


                gRFEOnSite.Graph.MinX = gRFEOnSite.StartFrequency;
                gRFEOnSite.Graph.MaxX = gRFEOnSite.StopFrequency;
                gRFEOnSite.Graph.ChartTitle = "Range: " + gRFEOnSite.Graph.MinX.ToString() + " to " + gRFEOnSite.Graph.MaxX + " MHz";
            }
            else
            {
                ButtonStartSweeps.Enabled = false;
                GroupBoxSweepConfiguration.Enabled = false;
                RadioButtonAnalyzer.Checked = false;
                RadioButtonGenerator.Checked = true;
                RadioButtonAnalyzer.Enabled = false;
            }
        }

        public void UIUpdateCallback_SweepData(List<string> sweepsFromExplorer)
        {
            // ***********************************************************************************
            // Updates UI with sweep data read from the physical RF Explorer worker thread
            // fromSerialThread is constructed and populated by RFEConfiguration.cs
            // This gets called at the completion of the number of sweeps from the Explorer worker thread
            // Thread mCapture is now false (set only in thread) stopping capture until set true 
            // ***********************************************************************************

            // Copy Bytes to local list: gRFEOnSite.ExplorerSweepData
            // This List is available to both the Charts and CsvEXport classes and is an attempt a parallelism


            LabelActualSweeps.Text = sweepsFromExplorer.Count.ToString(); // Show number of retured sweeps - Confidence

            gRFEOnSite.ExplorerSweepData.Clear();
            for (int i = 0; i < sweepsFromExplorer.Count; i++)
            {
                gRFEOnSite.ExplorerSweepData.Add(sweepsFromExplorer[i]);
            }

            // This really does appear to clear the thread mReceivedSweeps list 
            sweepsFromExplorer.Clear();

            if (CheckBoxSaveCsvFiles.Checked)
            {

                string fileName;
                if (gRFEOnSite.CalibrationActive)
                {
                    fileName = "Calibration - " + gRFEOnSite.SerialNumebr + " - " + gRFEOnSite.FileOps.FileCounter.ToString("D2") + " ";
                }
                else
                {
                    fileName = TextBoxCollectionLocation.Text + "-" + gRFEOnSite.FileOps.FileCounter.ToString("D2") + " ";
                }
                string dateString = gRFEOnSite.FileOps.RunStartTime.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " ";

                // Convert 714.3435 in MHz to string like 07143
                // 714.0000  should be 07140
                // The Text box may or may not have a decimal point
                string rangeString1;
                string rangeString2;

                if (TextBoxStartFrequency.Text.Contains("."))
                {
                    rangeString1 = Convert.ToInt64(TextBoxStartFrequency.Text.Replace(".", "")).ToString("D5") + "to";
                }
                else
                {
                    rangeString1 = Convert.ToInt64(TextBoxStartFrequency.Text).ToString("D4") + "0to";
                }


                if (TextBoxStopFrequency.Text.Contains("."))
                {
                    rangeString2 = Convert.ToInt64(TextBoxStopFrequency.Text.Replace(".", "")).ToString("D5");
                }
                else
                {
                    rangeString2 = Convert.ToInt64(TextBoxStopFrequency.Text).ToString("D4") + "0";
                }


                // *********************************
                // *********************************
                // This is a BAD way of fixing the file name

                double tempStopMhz = Convert.ToDouble(rangeString2);
                double tempStepSize = Convert.ToDouble(TextBoxStepFrequency.Text);
                string tempRangeString2 = (tempStopMhz - (tempStepSize / 100.0)).ToString();
                rangeString2 = Convert.ToInt64(tempRangeString2.Replace(".", "")).ToString("D5");


                //**********************************

                if (gRFEOnSite.RadialSurvey)
                {
                    TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + "-" +
                        NumericUpDownSweeps.Text + " at " + gRFEOnSite.RadialDegrees.ToString("D3") + " .csv";
                }
                else
                {
                    TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + "-" +
                        NumericUpDownSweeps.Text + " at Omni.csv";
                }

                gRFEOnSite.FileOps.Path = TextBoxCsvFileName.Text;
                gRFEOnSite.FileOps.ExportCsvFile(gRFEOnSite.StartFrequency, gRFEOnSite.StopFrequency, gRFEOnSite.FrequencyStepSize, gRFEOnSite.ExplorerSweepData);

                gRFEOnSite.FileOps.FileCounter++;
            }

            gRFEOnSite.Graph.DrawChart(gRFEOnSite.Graph.GraphPeak, gRFEOnSite.Graph.GraphAverage, gRFEOnSite.ExplorerSweepData);


            //*****************************************************
            // SETUP AND GET NEXT SWEEP
            //*****************************************************
            // Preset Mode -- 
            // Automatically get, populate and set sweep start and stop frequency pairs and cycle through the list of them
            // The first pair is determnined and set from the "Capture" Clicked Event (method) on the UI.
            // This gets the 'next' values and then sweeps with them

            // Upon entry, it skips PresetTable entries that have already been processed or ignored
            if (gRFEOnSite.PresetType == ePreset.eWhoopDownlink)
            {
                foreach (PresetTableEntry pair in gRFEOnSite.PresetWhoopDownlinkTable.Skip(gRFEOnSite.PresetTableIndex))
                {
                    gRFEOnSite.PresetTableIndex++; // Needs to be before the breaks to stay in step with foreach

                    // We found a table entry to Sweep: Program the RF Explorer
                    gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                    Thread.Sleep(100);

                    gRFEOnSite.Explorer.SweepCount = (int)NumericUpDownSweeps.Value;

                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    if (gRFEOnSite.CancelActive)
                    {
                        gRFEOnSite.Explorer.Capture = false;
                        gRFEOnSite.CancelActive = false;
                    }
                    else
                    {
                        if (gRFEOnSite.CalibrationActive)
                        {
                            ButtonCalibrationStart.Text = "Next";
                        }
                        else
                        {
                            gRFEOnSite.Explorer.Capture = true;
                        }
                    }

                    LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetWhoopDownlinkTable.Count();
                    return;
                }
               


                if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
                {
                    foreach (PresetTableEntry pair in gRFEOnSite.PresetDownlinkTable.Skip(gRFEOnSite.PresetTableIndex))
                    {
                        gRFEOnSite.PresetTableIndex++; // Needs to be before the breaks to stay in step with foreach

                        // We found a table entry to Sweep: Program the RF Explorer
                        gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                        Thread.Sleep(100);

                        gRFEOnSite.Explorer.SweepCount = (int)NumericUpDownSweeps.Value;

                        TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                        TaskProgressBar.Step = 1;
                        TaskProgressBar.Value = 0;


                        if (gRFEOnSite.CancelActive)
                        {
                            gRFEOnSite.Explorer.Capture = false;
                            gRFEOnSite.CancelActive = false;
                        }
                        else
                        {
                            if (gRFEOnSite.CalibrationActive)
                            {
                                ButtonCalibrationStart.Text = "Next";
                            }
                            else
                            {
                                gRFEOnSite.Explorer.Capture = true;
                            }
                        }

                        LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetDownlinkTable.Count();
                        return;
                    }
                }
            }
            

            if (gRFEOnSite.PresetType == ePreset.eSingle || gRFEOnSite.PresetType == ePreset.eContinuous)
            {
                LabelTaskCount.Text = "Done";
                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;

                if (CheckBoxAutoIncrementMarkerNumber.Checked && CheckBoxSaveCsvFiles.Checked)
                {
                    NumericUpDownMarkerNumber.Value += 1;
                }

                TabControlMain.Enabled = true;
                GroupBoxCsvConfiguration.Enabled = true;
                GroupBoxConfiguration.Enabled = true;
                NumericUpDownSweeps.Enabled = true;



                if (gRFEOnSite.PresetType == ePreset.eContinuous)
                {

                    ////gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                    Thread.Sleep(100);

                    gRFEOnSite.Explorer.SweepCount = (int)NumericUpDownSweeps.Value;

                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    gRFEOnSite.Explorer.Capture = true;
                }
            }

            // The only way we get here is by walking through every table entry - we have to be done
            if (gRFEOnSite.PresetActive)
            {

                LabelTaskCount.Text = "Done";


                if (gRFEOnSite.CalibrationActive)
                {
                    ButtonCalibrationStart.Text = "Start";
                }


                if (CheckBoxAutoIncrementMarkerNumber.Checked && CheckBoxSaveCsvFiles.Checked)
                {
                    if (ButtonCancelSweeps.Enabled)
                    {
                        NumericUpDownMarkerNumber.Value += 1;
                    }
                }

                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;
                TabControlMain.Enabled = true;
                GroupBoxCsvConfiguration.Enabled = true;
                GroupBoxConfiguration.Enabled = true;
                NumericUpDownSweeps.Enabled = true;
            }


            if (CheckBoxSaveCsvFiles.Checked)
            {
                TabControlMain.SelectedTab.Enabled = true;
                gRFEOnSite.CsvDirectoryValid = true;
                gRFEOnSite.CaptureImage = true;
                ButtonCaptureImage.BackColor = System.Drawing.SystemColors.Highlight;
                gRFEOnSite.FileOps.PopDirectory(); // For Image Capture
            }
            else
            {
                TabControlMain.SelectedTab.Enabled = false;
                ButtonCaptureImage.BackColor = Color.Gray;
                ButtonCaptureImage.Refresh();
            }
        }

        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
            // Pass "labelRFEComPort.Text" - a string - to Initialize() thread (await)
            // The thread then updates the GUI
            ButtonFindCOMPorts.Enabled = false;

            gRFEOnSite.Explorer.Force2400Baud = force2400BaudToolStripMenuItem.Checked;

            IProgress<string> UIComPortLabel = new Progress<string>(s => LabelRFEComPort.Text = s);
            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.InitializeSerialConnection(UIComPortLabel));


            ButtonFindCOMPorts.Text = "Connected";
            ButtonFindCOMPorts.Enabled = false;
            ButtonFindCOMPorts.BackColor = Color.Green;


            // A reference to the right hand side object (from the UI Thread) is passed to the thread through the left hand side IProcess object
            IProgress<RFEConfiguration> UpdateUIControls = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configuration(RFE));
            IProgress<List<string>> UpdateUISweepData = new Progress<List<string>>(SWEEPS => UIUpdateCallback_SweepData(SWEEPS));
            IProgress<int> UpdateUIProgressBar = new Progress<int>(s => TaskProgressBar.Value = s);

            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.CreateReceiveDataThread(
                                    UpdateUIControls,
                                    UpdateUISweepData,
                                    UpdateUIProgressBar));

            ButtonGetRfeConfiguration.Enabled = true;
            ComboBoxPreset.Enabled = true;
            GroupBoxConfiguration.Enabled = true;
            GroupBoxCurrentSweepChartConfiguration.Enabled = true;

            gRFEOnSite.Explorer.RequestConfiguration();

            TabControlMain.SelectedTab.Enabled = false;

            GroupBoxCsvConfiguration.Enabled = true;


            await Task.Delay(2000);


            if (LabelFirmwareText.Text == @"N/A")
            {
                string message; // = obException.ToString();
                string caption = "USB Cable/Serial Port Connection Error";
                message = "Most likely causes include:\n" +
                    "\t1. USB Cable Connection or Faulty USB Cable.\n" +
                    "\t2. Silicon Image USB Driver not Version 6.7.5\n" +
                    "\t3. Connection Baud Rate setting mismatch.\n" +
                    "\t    Connection assumes 500,000 Baud.\n" +
                    "\n" +
                    "After application closes:\n" +
                    "\t1. Disconnect the RF Explorer USB cable.\n" +
                    "\t2. Cycle RF Explorer Power.\n" +
                    "\t3. Verify Baud Rate in the Explorer configuration menu.\n" +
                    "\t4. Reconnect USB cable and try again.\n" +
                    "\t5. Click 'USB Trouble Shooting' button after restart.\n" +
                    "\t6. Complete USB driver removal and re-install.\n" +
                    "\t7. Force 2400 Baud from 'USB Settings' Menu.\n" +
                    "\t   Requires setting USB configuration menu to 2.4 kbps";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the Exception MessageBox.
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Environment.Exit(1);
                }
            }

            this.TabControlMain.SelectedTab = TabControlMainOmniDirectional;

            gRFEOnSite.Explorer.Capture = true;
        }

        private void ButtonSetConfiguration_Click(object sender, EventArgs e)
        {
            // ***********************************************************
            // ***********************************************************
            // Updates the physical RF Explorer with data from UI and then
            // Updates UI Graph with configuration data read from the UI
            // ***********************************************************
            // ***********************************************************
            double startMHz;
            double stopMHz;
            double stepKHz;
            bool bValidField;


            bValidField = Double.TryParse(TextBoxStartFrequency.Text, out startMHz);
            bValidField &= Double.TryParse(TextBoxStopFrequency.Text, out stopMHz);
            bValidField &= Double.TryParse(TextBoxStepFrequency.Text, out stepKHz);

            if (bValidField)
            {
                if (stopMHz - startMHz < 0.2990)
                {
                    string message;
                    string caption = "Bogus RF Explorer Configuration Requested";
                    message = "The entered starting and stopping frequencies are identical, negative or too close together.\n\nChoose a stoping frequency that is at least 300 KHz larger that the starting frequency.";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the Exception MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    return;
                }


                ButtonStartSweeps.Enabled = false;
                ButtonCancelSweeps.Enabled = false;
                GroupBoxSweepConfiguration.Enabled = false;

                gRFEOnSite.Explorer.WaitingForConfigurationCallBack = true;
                gRFEOnSite.Explorer.SendConfiguration(startMHz, stopMHz, -80, -110);
            }
        }

        private void ButtonStartSweeps_Click(object sender, EventArgs e)
        {

            switch (gRFEOnSite.PresetType)
            {
                case ePreset.eContinuous:
                    ButtonStartSweeps.Enabled = false;
                    ButtonStartSweeps.Text = "Start";
                    ButtonCancelSweeps.Enabled = true;
                    ButtonCancelSweeps.Text = "Stop";
                    gRFEOnSite.CsvDirectoryValid = false;
                    gRFEOnSite.CaptureImage = false;
                    ButtonCaptureImage.BackColor = Color.Gray;
                    ButtonCaptureImage.Refresh();


                    GroupBoxCsvConfiguration.Enabled = false;
                    GroupBoxConfiguration.Enabled = true;
                    NumericUpDownSweeps.Enabled = true;
                    TabControlMain.Enabled = false;
                    LabelActualSweeps.Text = "";
                    break;

                case ePreset.eSingle:
                    ButtonStartSweeps.Enabled = false;
                    ButtonStartSweeps.Text = "Capture";
                    ButtonCancelSweeps.Enabled = true;
                    ButtonCancelSweeps.Text = "Cancel";
                    gRFEOnSite.CsvDirectoryValid = false;
                    gRFEOnSite.CaptureImage = false;
                    ButtonCaptureImage.BackColor = Color.Gray;
                    ButtonCaptureImage.Refresh();


                    gRFEOnSite.FileOps.FileCounter = 1;
                    gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
                    gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;
                    GroupBoxCsvConfiguration.Enabled = false;
                    GroupBoxConfiguration.Enabled = false;
                    NumericUpDownSweeps.Enabled = false;
                    TabControlMain.Enabled = false;
                    LabelActualSweeps.Text = "";
                    break;

                case ePreset.eWhoopDownlink:
                    ButtonStartSweeps.Enabled = false;
                    ButtonStartSweeps.Text = "Capture";
                    ButtonCancelSweeps.Enabled = true;
                    ButtonCancelSweeps.Text = "Cancel";
                    gRFEOnSite.CsvDirectoryValid = false;
                    gRFEOnSite.CaptureImage = false;
                    ButtonCaptureImage.BackColor = Color.Gray;
                    ButtonCaptureImage.Refresh();


                    gRFEOnSite.FileOps.FileCounter = 1;
                    gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
                    gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;
                    GroupBoxCsvConfiguration.Enabled = false;
                    GroupBoxConfiguration.Enabled = false;
                    NumericUpDownSweeps.Enabled = false;
                    TabControlMain.Enabled = false;
                    LabelActualSweeps.Text = "";
                    break;

                case ePreset.eFullDownlink:
                    ButtonStartSweeps.Enabled = false;
                    ButtonStartSweeps.Text = "Capture";
                    ButtonCancelSweeps.Enabled = true;
                    ButtonCancelSweeps.Text = "Cancel";
                    gRFEOnSite.CsvDirectoryValid = false;
                    gRFEOnSite.CaptureImage = false;
                    ButtonCaptureImage.BackColor = Color.Gray;
                    ButtonCaptureImage.Refresh();


                    gRFEOnSite.FileOps.FileCounter = 1;
                    gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
                    gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;
                    GroupBoxCsvConfiguration.Enabled = false;
                    GroupBoxConfiguration.Enabled = false;
                    NumericUpDownSweeps.Enabled = false;
                    TabControlMain.Enabled = false;
                    LabelActualSweeps.Text = "";
                    break;
            }


            int floorNumber = Convert.ToInt32(NumericUpDownFloorNumber.Value.ToString());
            int markerNumber = Convert.ToInt32(NumericUpDownMarkerNumber.Value.ToString());

            if (CheckBoxSaveCsvFiles.Checked)
            {
                gRFEOnSite.FileOps.PopToDirectory(1);
                gRFEOnSite.FileOps.CreateEnterDirectory("SurveyData");
                gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxClient.Text);
                gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxCollectionLocation.Text);
                if (CheckBoxAutoIncrementMarkerNumber.Checked)
                {
                    if (ButtonFloorId.Text == "Next")
                    {
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxFloorName.Text + "-" + floorNumber.ToString("D2") + " " + TextBoxMarkerName.Text + "-" +
                            markerNumber.ToString("D2"));
                    }
                    else
                    {
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxMarkerName.Text + "-" + markerNumber.ToString("D2"));
                    }
                }
                else
                {
                    if (ButtonFloorId.Text == "Next")
                    {
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxFloorName.Text + "-" + floorNumber.ToString("D2") + " " + TextBoxMarkerName.Text);
                    }
                    else
                    {
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxMarkerName.Text);
                    }
                }

                gRFEOnSite.FileOps.CreateEnterDirectory(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }

            gRFEOnSite.Explorer.SweepCount = (int)NumericUpDownSweeps.Value;

            if (gRFEOnSite.PresetActive)
            {
                gRFEOnSite.PresetTableIndex = 0;

                if (gRFEOnSite.PresetType == ePreset.eWhoopDownlink)
                {
                    foreach (PresetTableEntry pair in gRFEOnSite.PresetWhoopDownlinkTable)
                    {
                        gRFEOnSite.PresetTableIndex++;

                        LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetWhoopDownlinkTable.Count();

                        gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                        Thread.Sleep(100);

                        TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                        TaskProgressBar.Step = 1;
                        TaskProgressBar.Value = 0;

                        gRFEOnSite.Explorer.Capture = true;
                        break;
                    }
                }

                if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
                {
                    foreach (PresetTableEntry pair in gRFEOnSite.PresetDownlinkTable)
                    {
                        gRFEOnSite.PresetTableIndex++;

                        LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetDownlinkTable.Count();

                        gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                        Thread.Sleep(100);

                        TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                        TaskProgressBar.Step = 1;
                        TaskProgressBar.Value = 0;

                        gRFEOnSite.Explorer.Capture = true;
                        break;
                    }
                }
            }
            else
            {
                LabelTaskCount.Text = "1 of 1";
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
                GroupBoxCsvInformation.Enabled = true;
            }
            else
            {
                GroupBoxCsvInformation.Enabled = false;
            }

            RefreshUI();
        }




        private void TextBoxSweepLocation_TextChanged(object sender, EventArgs e)
        {
            NumericUpDownMarkerNumber.Value = 1;

            RefreshUI();

            //ToolTip1.SetToolTip(TextBoxCollectionLocation, "Enter a short site collection location identifier " +
            //    "for data that is about to be collected.\nThis identifier will be used to create or enter a Desktop sub-folder to" +
            //        " store collected data in CSV Files.");
        }

        private void CheckBoxChartAutoScale_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Graph.AutoScale = CheckBoxChartAutoScale.Checked;
        }

        private void TextBoxLeftAntennaGain_TextChanged(object sender, EventArgs e)
        {
            double gain;
            if (Double.TryParse(TextBoxLeftAntennaGain.Text, out gain))
            {
                gRFEOnSite.LeftAntennaGain = gain;
            }
            else
            {
                TextBoxLeftAntennaGain.Text = "";
            }
        }

        private void TextBoxRightAntennaGain_TextChanged(object sender, EventArgs e)
        {
            double gain;
            if (Double.TryParse(TextBoxRightAntennaGain.Text, out gain))
            {
                gRFEOnSite.RightAntennaGain = gain;
            }
            else
            {
                TextBoxRightAntennaGain.Text = "";
            }
        }

        private void ComboBoxPreset_IndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxPreset.SelectedItem == null)
                return;

            StripStatusLabelPreset.Text = "Preset: " + (string)ComboBoxPreset.SelectedItem;

            var item = (string)ComboBoxPreset.SelectedItem;

            if (item == "Continuous")
            {
                gRFEOnSite.PresetType = ePreset.eContinuous;

                CheckBoxSaveCsvFiles.Checked = false;
                GroupBoxCsvConfiguration.Enabled = false;
            }

            if (item == "Single")
            {
                gRFEOnSite.PresetType = ePreset.eSingle;

                gRFEOnSite.PresetActive = false;

                TextBoxStartFrequency.Enabled = true;
                TextBoxStopFrequency.Enabled = true;
                TextBoxRBW.Enabled = true;
                TextBoxStepFrequency.Enabled = true;
                ButtonSetConfiguration.Enabled = true;
                ButtonGetRfeConfiguration.Enabled = true;
                CheckBoxHoldStart.Enabled = true;
                CheckBoxHoldStep.Enabled = true;
                CheckBoxHoldStop.Enabled = true;
            }


            if (item == "Whoop Downlink")
            {
                gRFEOnSite.PresetType = ePreset.eWhoopDownlink;

                TextBoxStartFrequency.Enabled = false;
                TextBoxStopFrequency.Enabled = false;
                TextBoxRBW.Enabled = false;
                TextBoxStepFrequency.Enabled = false;
                ButtonSetConfiguration.Enabled = false;
                ButtonGetRfeConfiguration.Enabled = false;
                GroupBoxSweepConfiguration.Enabled = true;
                ButtonCancelSweeps.Enabled = false;

                CheckBoxHoldStart.Enabled = false;
                CheckBoxHoldStep.Enabled = false;
                CheckBoxHoldStop.Enabled = false;

                gRFEOnSite.PresetActive = true;

                if (gRFEOnSite.PresetActive)
                {
                    ButtonStartSweeps.Enabled = true;
                    CheckBoxSaveCsvFiles.Checked = true;
                }
                else
                {
                    TextBoxStartFrequency.Enabled = true;
                    TextBoxStopFrequency.Enabled = true;
                    TextBoxRBW.Enabled = true;
                    TextBoxStepFrequency.Enabled = true;
                    ButtonSetConfiguration.Enabled = true;
                }
            }


            if (item == "Full Downlink")
            {
                gRFEOnSite.PresetType = ePreset.eFullDownlink;

                TextBoxStartFrequency.Enabled = false;
                TextBoxStopFrequency.Enabled = false;
                TextBoxRBW.Enabled = false;
                TextBoxStepFrequency.Enabled = false;
                ButtonSetConfiguration.Enabled = false;
                ButtonGetRfeConfiguration.Enabled = false;
                GroupBoxSweepConfiguration.Enabled = true;

                CheckBoxHoldStart.Enabled = false;
                CheckBoxHoldStep.Enabled = false;
                CheckBoxHoldStop.Enabled = false;

                gRFEOnSite.PresetActive = true;

                if (gRFEOnSite.PresetActive)
                {
                    ButtonStartSweeps.Enabled = true;
                    CheckBoxSaveCsvFiles.Checked = true;
                }
                else
                {
                    TextBoxStartFrequency.Enabled = true;
                    TextBoxStopFrequency.Enabled = true;
                    TextBoxRBW.Enabled = true;
                    TextBoxStepFrequency.Enabled = true;
                    ButtonSetConfiguration.Enabled = true;
                }
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

        private void ButtonGetConfiguration_Click(object sender, EventArgs e)
        {
            gRFEOnSite.Explorer.RequestConfiguration();
        }

        private void TextBoxStartFrequency_TextChanged(object sender, EventArgs e)
        {
            double start, stop, stepSize;
            bool bStatus;

            bStatus = Double.TryParse(TextBoxStartFrequency.Text, out start);
            Double.TryParse(TextBoxStopFrequency.Text, out stop);

            if (bStatus)
            {
                if (stop > start)
                {
                    stepSize = (stop - start) / .1120;
                    TextBoxStepFrequency.Text = stepSize.ToString("F0");
                }
            }
            else
            {
                TextBoxStartFrequency.Text = "";
            }
        }

        private void TextBoxStopFrequency_TextChanged(object sender, EventArgs e)
        {
            double start, stop, stepSize;
            bool bStatus;

            bStatus = Double.TryParse(TextBoxStartFrequency.Text, out start); // **** stop
            Double.TryParse(TextBoxStopFrequency.Text, out stop);

            if (bStatus)
            {
                if (stop > start)
                {
                    stepSize = (stop - start) / .1120;
                    TextBoxStepFrequency.Text = stepSize.ToString("F0");
                }
            }
            else
            {
                TextBoxStopFrequency.Text = "";
            }
        }

        private void RadioButtonAnalyzer_CheckedChanged(object sender, EventArgs e)
        {
            ButtonDocumentation.Text = "RF Explorer Documentation";
        }

        private void RadioButtonGenerator_CheckedChanged(object sender, EventArgs e)
        {
            ButtonDocumentation.Text = "RFE Generator Documentation";
        }

        private void ButtonCancelSweeps_Click(object sender, EventArgs e)
        {
            ButtonCancelSweeps.Enabled = false;
            LabelTaskCount.Text = "Done";

            gRFEOnSite.Explorer.SweepCount = 1;
            gRFEOnSite.PresetTableIndex = gRFEOnSite.PresetWhoopDownlinkTable.Count();
            NumericUpDownSweeps.Enabled = true;

            if (CheckBoxSaveCsvFiles.Checked && CheckBoxAutoIncrementMarkerNumber.Checked && !gRFEOnSite.PresetActive)
            {
                if (NumericUpDownMarkerNumber.Value > 1)
                {
                    NumericUpDownMarkerNumber.Value -= 1;
                }
            }

            gRFEOnSite.CancelActive = true;

            ButtonStartSweeps.Enabled = true;
            ButtonCancelSweeps.Enabled = false;
            TabControlMain.Enabled = true;
            GroupBoxCsvConfiguration.Enabled = true;
            GroupBoxConfiguration.Enabled = true;
            NumericUpDownSweeps.Enabled = true;
        }

        private void CheckBoxRadial_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.RadialSurvey = CheckBoxRadialAzimuth.Checked;
        }

        private void CheckBoxAutoIncrement_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAutoIncrementMarkerNumber.Checked)
            {
                NumericUpDownMarkerNumber.Enabled = true;
            }
            else
            {
                NumericUpDownMarkerNumber.Enabled = false;
            }

            RefreshUI();
        }

        private void TextBoxCollectionSite_TextChanged(object sender, EventArgs e)
        {
            NumericUpDownMarkerNumber.Value = 1;

            RefreshUI();
        }

        private void TextBoxClient_TextChanged(object sender, EventArgs e)
        {
            NumericUpDownMarkerNumber.Value = 1;
            RefreshUI();
        }

        private void NumericUpDownLocation_ValueChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void TextBoxFloorLabel_TextChanged(object sender, EventArgs e)
        {
            NumericUpDownMarkerNumber.Value = 1;
            RefreshUI();
        }

        private void toolStripMenuItemFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonCloseSerialPort_Click(object sender, EventArgs e)
        {
            DialogResult diag = MessageBox.Show("Disconnect RF Explorer - Are you Sure?", "Disconnect?", MessageBoxButtons.OKCancel);
            if (diag == DialogResult.OK)
            {
                gRFEOnSite.Explorer.DestroyReceiveDataThread();
                gRFEOnSite.Explorer.DisconnectSerialPort();
                ButtonFindCOMPorts.Enabled = true;
                ButtonFindCOMPorts.BackColor = Color.Red;
                ButtonFindCOMPorts.Text = "Connect RF Explorer";

                TextBoxStartFrequency.Text = "";
                TextBoxStopFrequency.Text = "";
                TextBoxRBW.Text = "";
                TextBoxStepFrequency.Text = "";
            }
        }

        private void ButtonFloorId_Click(object sender, EventArgs e)
        {
            if (ButtonFloorId.Text == "Enable")
            {
                ButtonFloorId.Text = "Next";

                RefreshUI();
                return;
            }

            NumericUpDownMarkerNumber.Value = 1;

            if (RadioButtonFloorDecrement.Checked == true)
            {
                if (NumericUpDownFloorNumber.Value == 1)
                {
                    DialogResult diag = MessageBox.Show(@"Trying to decrement Floor while Floor value is '1'. Enter different Floor or ID text or change the count such that it's value stays greater than one.", "Floor/ID Error", MessageBoxButtons.OK);
                    return;
                }

                NumericUpDownFloorNumber.Value = NumericUpDownFloorNumber.Value - 1;
            }
            else
            {
                NumericUpDownFloorNumber.Value = NumericUpDownFloorNumber.Value + 1;
            }

            RefreshUI();

        }

        private void NumericUpDownAutoText_ValueChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            if (!CheckBoxSaveCsvFiles.Checked)
            {
                StripStatusLabelDivision1.Text = "";
                StripStatusLabelCsvDirectory.Text = "";
                return;
            }

            StripStatusLabelDivision1.Text = "|";

            if (ButtonFloorId.Text == "Next")
            {
                TextBoxFloorName.Enabled = true;
                NumericUpDownFloorNumber.Enabled = true;
                RadioButtonFloorDecrement.Enabled = true;
                RadioButtonFloorIncrement.Enabled = true;

                int floorNumber = Convert.ToInt32(NumericUpDownFloorNumber.Value.ToString());
                int markerNumber = Convert.ToInt32(NumericUpDownMarkerNumber.Value.ToString());

                StripStatusLabelCsvDirectory.Text =
                    "CSV Directory: Desktop\\SurveyData\\" +
                    TextBoxClient.Text +
                    "\\" +
                    TextBoxCollectionLocation.Text +
                    "\\" +
                    TextBoxFloorName.Text +
                    floorNumber.ToString("D2") +
                    "\\" +
                    TextBoxMarkerName.Text +
                    "-" +
                    markerNumber.ToString("D2");
            }
            else
            {
                TextBoxFloorName.Enabled = false;
                NumericUpDownFloorNumber.Enabled = false;
                RadioButtonFloorDecrement.Enabled = false;
                RadioButtonFloorIncrement.Enabled = false;

                int markerNumber = Convert.ToInt32(NumericUpDownMarkerNumber.Value.ToString());

                StripStatusLabelCsvDirectory.Text =
                    "CSV Directory: Desktop\\SurveyData\\" +
                    TextBoxClient.Text +
                    "\\" +
                    TextBoxCollectionLocation.Text +
                    "\\" +
                    TextBoxMarkerName.Text +
                    "-" +
                     markerNumber.ToString("D2");
            }
        }

        VideoCapture mCapture;
        Mat mMat;

        private void ButtonCaptureImage_Click(object sender, EventArgs e)
        {
            if (!gRFEOnSite.CsvDirectoryValid)
            {
                return;
            }

            ButtonCaptureImage.BackColor = Color.Green;
            LabelCaptured.Text = "Captured";
            LabelCaptured.Refresh();
            ButtonCaptureImage.Refresh();

            SystemSounds.Asterisk.Play();

            Thread.Sleep(500);
            Bitmap resized = new Bitmap(mMat.Bitmap, new Size(mMat.Bitmap.Width * 4, mMat.Bitmap.Height * 4));
            resized.Save(DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".jpg", ImageFormat.Jpeg);

            LabelCaptured.Text = "";
            ButtonCaptureImage.BackColor = System.Drawing.SystemColors.Highlight;
        }

        private void ProcessVideoFrame(object sender, EventArgs e)
        {
            if (!gRFEOnSite.CaptureImage)
            {
                return;
            }

            try
            {
                mMat = mCapture.QueryFrame();
                PictureBox.Image = mMat.Bitmap;
            }
            catch
            {
                if (mCapture != null) mCapture.Dispose();
                mCapture = null;
                if (mMat != null) mMat.Dispose();
                mMat = null;
            }

        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControlMain.SelectedTab.Text == "Location Camera") //specific tabname
            {
                if (mCapture == null)
                {
                    mCapture = new VideoCapture();
                }

                if (mMat == null)
                {
                    mMat = new Mat();
                }

                if (gRFEOnSite.CsvDirectoryValid)
                {
                    gRFEOnSite.CaptureImage = true;
                    TabControlMain.SelectedTab.Enabled = true;
                    ButtonCaptureImage.BackColor = System.Drawing.SystemColors.Highlight;
                }
                else
                {
                    gRFEOnSite.CaptureImage = false;
                    TabControlMain.SelectedTab.Enabled = false;
                    ButtonCaptureImage.BackColor = Color.Gray;
                    ButtonCaptureImage.Refresh();
                    return;
                }
            }
            else
            {
                gRFEOnSite.CaptureImage = false;
                ButtonCaptureImage.BackColor = Color.Gray;
                PictureBox.BackColor = Color.Gray;
            }
        }

        private void ButtonPersistClear_Click(object sender, EventArgs e)
        {
            //this.CheckBoxSaveCsvFiles.Checked = Settings.Default.Persist_SaveCsvCheckedState;
            this.TextBoxClient.Text = "Client";
            this.TextBoxCollectionLocation.Text = "Collection Location";

            this.TextBoxFloorName.Text = "Floor";
            this.NumericUpDownFloorNumber.Value = 1;
            this.ButtonFloorId.Text = "Enable";
            this.RadioButtonFloorDecrement.Checked = false;
            RadioButtonFloorIncrement.Checked = true;

            this.TextBoxMarkerName.Text = "M";
            this.NumericUpDownMarkerNumber.Value = 1;
            //this.CheckBoxAutoIncrementMarkerNumber.Checked = false;


            this.CheckBoxChartAutoScale.Checked = false;
            this.CheckBoxChartAverage.Checked = true;
            this.CheckBoxChartPeak.Checked = true;
            this.NumericUpDownSweeps.Value = 100;

            //this.ComboBoxPreset.SelectedItem = "Manual";

            this.TabControlMain.SelectedTab = TabControlMainOmniDirectional;

            RefreshUI();

        }


        private void MenuStripMenuItemPreset_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BaudRate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://j3.rf-explorer.com/62-rfe/troubleshooting/104-troubleshooting-usb-drivers");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://j3.rf-explorer.com/download/sw/win/RFExplorer_USB_Driver.zip");
        }

        private void TextBoxCalibrationSourceDbm_TextChanged(object sender, EventArgs e)
        {
            gRFEOnSite.CalibarationSourceDbm = Convert.ToDouble(TextBoxCalibrationSourceDbm.Text);
        }

        private void TextBoxCalibrationPointsPerSweepInterval_TextChanged(object sender, EventArgs e)
        {
            gRFEOnSite.CalibrationPointsPerSweepInterval = Convert.ToInt32(TextBoxCalibrationPointsPerSweepInterval.Text);
        }

        private void ButtonCalibrationStart_Click(object sender, EventArgs e)
        {
            if (LabelTaskCount.Text == "Done" || LabelTaskCount.Text == "Idle")
            {
                ButtonStartSweeps.Enabled = false;
                ButtonCancelSweeps.Enabled = true;
                gRFEOnSite.CsvDirectoryValid = false;
                gRFEOnSite.CaptureImage = false;
                ButtonCaptureImage.BackColor = Color.Gray;
                ButtonCaptureImage.Refresh();


                gRFEOnSite.FileOps.FileCounter = 1;
                gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
                gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;
                GroupBoxCsvConfiguration.Enabled = false;
                GroupBoxConfiguration.Enabled = false;
                NumericUpDownSweeps.Enabled = false;
                TabControlMain.Enabled = false;
                LabelActualSweeps.Text = "";




                gRFEOnSite.FileOps.PopToDirectory(1);
                gRFEOnSite.FileOps.CreateEnterDirectory("CalibrationData");

                gRFEOnSite.FileOps.CreateEnterDirectory(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));


                gRFEOnSite.Explorer.SweepCount = Convert.ToInt32(NumericUpDownSweeps.Value);

                if (gRFEOnSite.PresetActive)
                {
                    gRFEOnSite.PresetTableIndex = 0;

                    if (gRFEOnSite.PresetType == ePreset.eWhoopDownlink)
                    {
                        foreach (PresetTableEntry pair in gRFEOnSite.PresetWhoopDownlinkTable)
                        {
                            gRFEOnSite.PresetTableIndex++;

                            LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetWhoopDownlinkTable.Count();

                            gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                            Thread.Sleep(100);

                            TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                            TaskProgressBar.Step = 1;
                            TaskProgressBar.Value = 0;


                            gRFEOnSite.Explorer.Capture = true;
                        }
                    }

                    if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
                    {
                        foreach (PresetTableEntry pair in gRFEOnSite.PresetDownlinkTable)
                        {
                            gRFEOnSite.PresetTableIndex++;

                            LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetDownlinkTable.Count();

                            gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                            Thread.Sleep(100);

                            TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                            TaskProgressBar.Step = 1;
                            TaskProgressBar.Value = 0;

                            gRFEOnSite.Explorer.Capture = true;
                            break;
                        }
                    }
                }
                else
                {
                    LabelTaskCount.Text = "1 of 1";
                    TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                    TaskProgressBar.Step = 1;
                    TaskProgressBar.Value = 0;

                    gRFEOnSite.Explorer.Capture = true;
                }


                gRFEOnSite.CalibrationActive = true;
            }
            else
            {
                gRFEOnSite.Explorer.Capture = true;
            }
        }
    }
}
