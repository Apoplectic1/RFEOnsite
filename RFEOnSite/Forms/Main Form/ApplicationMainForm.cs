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
using Emgu.CV.Structure;
using System.Deployment.Application;
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;

namespace RFEOnSite
{
    public partial class MainForm : Form
    {
        public GlobalData gRFEOnSite;
        private VideoCapture mCapture;
        private Mat mMat;

        public enum eFrameType { NEW, ACTIVE, CAPTURED, IDLE }

        public MainForm()
        {
            // Version Number
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                Version version = ad.CurrentVersion;
                Text = "RF Explorer OnSite - Version: " + version.ToString();
            }
            else
            {
                Text = "RF Explorer OnSite - - Version: " + System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString("yyyy.MM.dd - h:mm tt");
            }

            gRFEOnSite = new GlobalData();

            InitializeComponent();

            // User Events
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

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

            ComboBox_CurrentConfiguration_Preset.SelectedIndex = 2;
            //ComboBoxPreset.Enabled = false;

            InitializeChartUI();

            mCapture = new VideoCapture();
            mMat = new Mat();

            // Navigate to and set User's Desktop as current working Directory
            // Force Dialog to Desktop ONLY
            gRFEOnSite.FileOps.FolderDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            gRFEOnSite.FileOps.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // Navigate to, Create if needed, and Enter Desktop/RFEOnSite Data
            //gRFEOnSite.FileOps.CreateEnterDirectory("RFEOnSite Data");

            Button_CurrentConfiguration_SetRfeConfiguration.Enabled = false;
            //NumericUpDownMarkerNumber.Enabled = false;
            //CheckBoxAutoIncrementMarkerNumber.Enabled = false;

            TabControl_Main_LocationCamera.Enabled = false;

            Application.Idle += DisplayVideoFrames;
            gRFEOnSite.CsvDirectoryValid = false;
            PictureBox_LocationCamera.SizeMode = PictureBoxSizeMode.StretchImage;

            CheckBox_Band_600.Enabled = false;
            CheckBox_Band_700.Enabled = false;
            CheckBox_Band_CEL.Enabled = false;
            CheckBox_Band_PCS.Enabled = false;
            CheckBox_Band_AWS.Enabled = false;
            CheckBox_Band_WCS.Enabled = false;
            Label_CurrentConfiguration_Presets.Enabled = false;
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

            if (TextBox_CurrentConfiguration_StartFrequency.Text.Length > 0)
            {
                gRFEOnSite.Graph.MinX = Convert.ToInt32(TextBox_CurrentConfiguration_StartFrequency.Text);
            }

            if (TextBox_CurrentConfiguration_StopFrequency.Text.Length > 0)
            {
                gRFEOnSite.Graph.MaxX = Convert.ToInt32(TextBox_CurrentConfiguration_StopFrequency.Text);
            }

            gRFEOnSite.Graph.ChartTitle = "Range: " + gRFEOnSite.Graph.MinX.ToString() + " to " + gRFEOnSite.Graph.MaxX + " MHz";
            gRFEOnSite.Graph.MaxY = -30;
            gRFEOnSite.Graph.MinY = -110;
            gRFEOnSite.Graph.BuildChart();
            gRFEOnSite.Graph.InitializeSeries();
            gRFEOnSite.Graph.ClearSeries("All");
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
            Settings.Default.Persist_SaveCsvCheckedState = CheckBox_CSVFileStorage_SaveCsvFiles.Checked;

            Settings.Default.Persist_ClientTextState = TextBox_CSVFileStorage_Client.Text;
            Settings.Default.Persist_LocationTextState = TextBox_CSVFileStorage_CollectionLocationDescription.Text;

            Settings.Default.Persist_FloorTextState = TextBox_CSVFileStorage_CollectionFloorName.Text;
            Settings.Default.Persist_FloorNumberState = NumericUpDown_CSVFileStorage_FloorNumber.Value;
            Settings.Default.Persist_FloorEnableState = Button_CSVFileStorage_CollectionFloor_Enable.Text;
            Settings.Default.Persist_FloorDecrementState = RadioButton_CSVFileStorage_FloorDecrement.Checked;

            Settings.Default.Persist_MarkerTextState = TextBox_CSVFileStorage_CollectionMarkerName.Text;
            Settings.Default.Persist_MarkerNumberState = NumericUpDown_CSVFileStorage_MarkerNumber.Value;
            Settings.Default.Persist_AutoNext = Button_CSVFileStorage_CollectionFloor_Enable.Text;
            Settings.Default.Persist_MarkerIncrementState = CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked;


            Settings.Default.Persist_AutoScaleState = CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked;
            Settings.Default.Persist_SweepsCountState = NumericUpDown_SweepControl_Sweeps.Value;

            Settings.Default.Persist_Preset = ComboBox_CurrentConfiguration_Preset.SelectedItem.ToString();
            Settings.Default.Persist_2400State = force2400BaudToolStripMenuItem.Checked;

            Settings.Default.Persist_CheckBox_Band_600_State = CheckBox_Band_600.Checked;
            Settings.Default.Persist_CheckBox_Band_700_State = CheckBox_Band_700.Checked;
            Settings.Default.Persist_CheckBox_Band_CEL_State = CheckBox_Band_CEL.Checked;
            Settings.Default.Persist_CheckBox_Band_PCS_State = CheckBox_Band_PCS.Checked;
            Settings.Default.Persist_CheckBox_Band_AWS_State = CheckBox_Band_AWS.Checked;
            Settings.Default.Persist_CheckBox_Band_WCS_State = CheckBox_Band_WCS.Checked;
        }

        void RecallUiPersistanceStates()
        {
            CheckBox_CSVFileStorage_SaveCsvFiles.Checked = Settings.Default.Persist_SaveCsvCheckedState;
            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {
                gRFEOnSite.CsvDirectoryValid = true;
                GroupBoxCsvInformation.Enabled = true;
            }
            else
            {
                gRFEOnSite.CsvDirectoryValid = false;
                GroupBoxCsvInformation.Enabled = false;
            }

            TextBox_CSVFileStorage_Client.Text = Settings.Default.Persist_ClientTextState;
            TextBox_CSVFileStorage_CollectionLocationDescription.Text = Settings.Default.Persist_LocationTextState;

            TextBox_CSVFileStorage_CollectionFloorName.Text = Settings.Default.Persist_FloorTextState;
            NumericUpDown_CSVFileStorage_FloorNumber.Value = Settings.Default.Persist_FloorNumberState;
            Button_CSVFileStorage_CollectionFloor_Enable.Text = Settings.Default.Persist_FloorEnableState;
            RadioButton_CSVFileStorage_FloorDecrement.Checked = Settings.Default.Persist_FloorDecrementState;
            RadioButton_CSVFileStorage_FloorIncrement.Checked = !RadioButton_CSVFileStorage_FloorDecrement.Checked;

            TextBox_CSVFileStorage_CollectionMarkerName.Text = Settings.Default.Persist_MarkerTextState;
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = Settings.Default.Persist_MarkerNumberState;
            CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked = Settings.Default.Persist_MarkerIncrementState;

            CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked = Settings.Default.Persist_AutoScaleState;
            NumericUpDown_SweepControl_Sweeps.Value = Settings.Default.Persist_SweepsCountState;
            force2400BaudToolStripMenuItem.Checked = Settings.Default.Persist_2400State;

            //this.ComboBoxPreset.SelectedItem = Settings.Default.Persist_Preset;
            ComboBox_CurrentConfiguration_Preset.SelectedItem = "Manual";

            CheckBox_Band_600.Checked = Settings.Default.Persist_CheckBox_Band_600_State;
            CheckBox_Band_700.Checked = Settings.Default.Persist_CheckBox_Band_700_State;
            CheckBox_Band_CEL.Checked = Settings.Default.Persist_CheckBox_Band_CEL_State;
            CheckBox_Band_PCS.Checked = Settings.Default.Persist_CheckBox_Band_PCS_State;
            CheckBox_Band_AWS.Checked = Settings.Default.Persist_CheckBox_Band_AWS_State;
            CheckBox_Band_WCS.Checked = Settings.Default.Persist_CheckBox_Band_WCS_State;
        }

        public void UIUpdateCallback_RFE_Configuration(RFEConfiguration fromSerialThread)
        {
            // ***********************************************************************************
            // Updates UI with configuration data read from the physical RF Explorer worker thread
            // fromSerialThread is constructed and populated by RFEConfiguration.cs
            // ***********************************************************************************

            double startMHz = fromSerialThread.StartMHz;
            TextBox_CurrentConfiguration_StartFrequency.Text = startMHz.ToString();
            double stopMHz = (fromSerialThread.StepMHz * 112.0) + fromSerialThread.StartMHz;
            TextBox_CurrentConfiguration_StopFrequency.Text = Math.Round(stopMHz, 2).ToString();

            TextBoxRBW.Text = Math.Round(fromSerialThread.RBWKHz, 2).ToString();
            TextBox_CurrentConfiguration_StepFrequency.Text = (fromSerialThread.StepMHz * 1000.0).ToString("F2");

            Label_Connection_DeviceIDValue.Text = fromSerialThread.mMainModel.ToString();
            Label_Connection_ModelIDValue.Text = fromSerialThread.mExpansionModel.ToString();
            Label_Connection_FirmwareValue.Text = fromSerialThread.FirmwareVersion;

            gRFEOnSite.SerialNumebr = fromSerialThread.mSerialNumber;


            if (TextBox_CurrentConfiguration_StartFrequency.Text == TextBox_CurrentConfiguration_StopFrequency.Text)
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

            if ((fromSerialThread.mMainModel == eModel.MODEL_6G) || (fromSerialThread.mMainModel == eModel.MODEL_6G_PLUS))
            {
                if (!gRFEOnSite.PresetActive)
                {
                    ButtonStartSweeps.Enabled = true;
                    Button_CurrentConfiguration_SetRfeConfiguration.Enabled = true;
                }

                GroupBox_SweepControl.Enabled = true;
                RadioButton_Connection_SetSpectrumAnalyzer.Checked = true;
                RadioButton_Connection_SetSignalGenerator.Checked = false;
                RadioButton_Connection_SetSignalGenerator.Enabled = false;


                gRFEOnSite.Graph.MinX = gRFEOnSite.StartFrequency;
                gRFEOnSite.Graph.MaxX = gRFEOnSite.StopFrequency;
                gRFEOnSite.Graph.ChartTitle = "Range: " + gRFEOnSite.Graph.MinX.ToString() + " to " + gRFEOnSite.Graph.MaxX + " MHz";
            }
            else
            {
                ButtonStartSweeps.Enabled = false;
                GroupBox_SweepControl.Enabled = false;
                RadioButton_Connection_SetSpectrumAnalyzer.Checked = false;
                RadioButton_Connection_SetSignalGenerator.Checked = true;
                RadioButton_Connection_SetSpectrumAnalyzer.Enabled = false;
            }
        }

        public void UIUpdateCallback_SweepData(List<string> sweepsFromExplorer)
        {
            // ***********************************************************************************
            // Updates UI with sweep data read from the physical RF Explorer worker thread.
            // fromSerialThread is constructed and populated by RFEConfiguration.cs
            // UIUpdateCallback_SweepData gets called at the completion of the number of sweeps from the Explorer worker thread.
            // Thread mCapture is now false (set only in thread) stopping capture until set true. 
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

            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {
                string fileName;

                if (gRFEOnSite.CalibrationActive)
                    fileName = "Calibration - " + gRFEOnSite.SerialNumebr + " - " + gRFEOnSite.FileOps.FileCounter.ToString("D2") + " ";
                else
                    fileName = TextBox_CSVFileStorage_CollectionLocationDescription.Text + "-" + gRFEOnSite.FileOps.FileCounter.ToString("D2") + " ";

                string dateString = gRFEOnSite.FileOps.RunStartTime.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " ";

                // Convert 714.3435 in MHz to string like 07143
                // 714.0000  should be 07140
                // The Text box may or may not have a decimal point
                string rangeString1;
                string rangeString2;

                if (TextBox_CurrentConfiguration_StartFrequency.Text.Contains("."))
                    rangeString1 = Convert.ToInt64(TextBox_CurrentConfiguration_StartFrequency.Text.Replace(".", "")).ToString("D5") + "to";
                else
                    rangeString1 = Convert.ToInt64(TextBox_CurrentConfiguration_StartFrequency.Text).ToString("D4") + "0to";


                if (TextBox_CurrentConfiguration_StopFrequency.Text.Contains("."))
                    rangeString2 = Convert.ToInt64(TextBox_CurrentConfiguration_StopFrequency.Text.Replace(".", "")).ToString("D5");
                else
                    rangeString2 = Convert.ToInt64(TextBox_CurrentConfiguration_StopFrequency.Text).ToString("D4") + "0";

                // *********************************
                // *********************************
                // This is a BAD way of fixing the file name

                double tempStopMhz = Convert.ToDouble(rangeString2);
                double tempStepSize = Convert.ToDouble(TextBox_CurrentConfiguration_StepFrequency.Text);
                string tempRangeString2 = (tempStopMhz - (tempStepSize / 100.0)).ToString();
                rangeString2 = Convert.ToInt64(tempRangeString2.Replace(".", "")).ToString("D5");

                //**********************************

                if (gRFEOnSite.RadialSurvey)
                    TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + "-" +
                        NumericUpDown_SweepControl_Sweeps.Text + " at " + gRFEOnSite.RadialDegrees.ToString("D3") + " .csv";
                else
                    TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + "-" +
                        NumericUpDown_SweepControl_Sweeps.Text + " at Omni.csv";

                gRFEOnSite.FileOps.Path = TextBoxCsvFileName.Text;
                gRFEOnSite.FileOps.ExportCsvFile(gRFEOnSite.StartFrequency, gRFEOnSite.StopFrequency, gRFEOnSite.FrequencyStepSize, gRFEOnSite.ExplorerSweepData);

                gRFEOnSite.FileOps.FileCounter++;
            }

            gRFEOnSite.Graph.DrawChart(gRFEOnSite.ExplorerSweepData);


            //*****************************************************
            // SETUP AND GET NEXT SWEEP
            //*****************************************************
            // Preset Mode -- 
            // Automatically get, populate and set sweep start and stop frequency pairs and cycle through the list of them
            // The first pair is determnined and set from the "Capture" Clicked Event (method) on the UI.
            // This gets the 'next' values and then sweeps with them

            // Upon entry, it skips PresetTable entries that have already been processed or ignored
            if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
            {
                foreach (PresetTableEntry pair in gRFEOnSite.PresetDownlinkTable.Skip(gRFEOnSite.PresetTableIndex))
                {
                    gRFEOnSite.Explorer.AutoSweep.Initialize(true, 1.0M, gRFEOnSite.Explorer.SweepCount);
                    gRFEOnSite.PresetTableIndex++; // Needs to be before the breaks to stay in step with foreach

                    // We found a table entry to Sweep: Program the RF Explorer
                    gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                    Thread.Sleep(100);

                    gRFEOnSite.Explorer.SweepCount = (int)NumericUpDown_SweepControl_Sweeps.Value;

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
                            ButtonCalibrationStart.Text = "Next";
                        else
                            gRFEOnSite.Explorer.Capture = true;
                    }

                    LabelExecutingTask.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetDownlinkTable.Count();

                    return;
                }

                if (mCapture.IsOpened == true)
                {
                    TabControl_Main.SelectedTab = TabControl_Main_LocationCamera;
                    SetCameraState(eFrameType.ACTIVE);
                }
            }

            if (gRFEOnSite.PresetType == ePreset.eSingle)
            {
                LabelExecutingTask.Text = "Done";
                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;
                NumericUpDown_SweepControl_Sweeps.Enabled = true;

                if (CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked && CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
                    NumericUpDown_CSVFileStorage_MarkerNumber.Value += 1;

                TabControl_Main.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = true;
            }

            if (gRFEOnSite.PresetType == ePreset.eContinuous)
            {
                LabelExecutingTask.Text = "Done";
                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;
                NumericUpDown_SweepControl_Sweeps.Enabled = true;

                if (CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked && CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
                    NumericUpDown_CSVFileStorage_MarkerNumber.Value += 1;

                TabControl_Main.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = true;
                NumericUpDown_SweepControl_Sweeps.Enabled = true;

                Thread.Sleep(100);

                gRFEOnSite.Explorer.SweepCount = (int)NumericUpDown_SweepControl_Sweeps.Value;

                TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                TaskProgressBar.Step = 1;
                TaskProgressBar.Value = 0;

                gRFEOnSite.Explorer.Capture = true;
            }

            // The only way we get here is by walking through every table entry - we have to be done
            if (gRFEOnSite.PresetActive)
            {
                LabelExecutingTask.Text = "Done";
                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;
                NumericUpDown_SweepControl_Sweeps.Enabled = true;

                if (gRFEOnSite.CalibrationActive)
                    ButtonCalibrationStart.Text = "Start";

                if (CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked && CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
                    NumericUpDown_CSVFileStorage_MarkerNumber.Value += 1;

                TabControl_Main.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = true;
            }

            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {
                //TabControlMain.Enabled = true;
                gRFEOnSite.FileOps.PopDirectory(); // For Image Capture
            }

            SystemSounds.Hand.Play();
        }

        private void ButtonDocumentation_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadioButton_Connection_SetSpectrumAnalyzer.Checked)
                    System.Diagnostics.Process.Start("https://j3.rf-explorer.com/download/docs/RF%20Explorer%20Spectrum%20Analyzer%20User%20Manual.pdf");
                else
                {
                    if (RadioButton_Connection_SetSignalGenerator.Checked)
                        System.Diagnostics.Process.Start("https://j3.rf-explorer.com/download/docs/RF%20Explorer%20Signal%20Generator%20User%20Manual.pdf");
                    else
                        System.Diagnostics.Process.Start("https://j3.rf-explorer.com/download/docs/RF%20Explorer%20Spectrum%20Analyzer%20User%20Manual.pdf");
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

        private void Button_USBDriverDownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://j3.rf-explorer.com/download/sw/win/RFExplorer_USB_Driver.zip");
        }

        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
            // Pass "labelRFEComPort.Text" - a string - to Initialize() thread (await)
            // The thread then updates the GUI
            Button_Connection_ConnectExplorer.Enabled = false;
            CheckBox_CSVFileStorage_SaveCsvFiles.Checked = true;

            gRFEOnSite.Explorer.Force2400Baud = force2400BaudToolStripMenuItem.Checked;

            IProgress<string> UIComPortLabel = new Progress<string>(s => Label_Connection_ComPortValue.Text = s);
            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.InitializeSerialConnection(UIComPortLabel));

            Button_Connection_ConnectExplorer.Text = "Connected";
            Button_Connection_ConnectExplorer.Enabled = false;
            Button_Connection_ConnectExplorer.BackColor = Color.Green;

            // A reference to the right hand side object (from the UI Thread) is passed to the thread through the left hand side IProcess object
            IProgress<RFEConfiguration> UpdateUIControls = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configuration(RFE));
            IProgress<List<string>> UpdateUISweepData = new Progress<List<string>>(SWEEPS => UIUpdateCallback_SweepData(SWEEPS));
            IProgress<int> UpdateUIProgressBar = new Progress<int>(s => TaskProgressBar.Value = s);

            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.CreateReceiveDataThread(
                                    UpdateUIControls,
                                    UpdateUISweepData,
                                    UpdateUIProgressBar));

            Button_CurrentConfiguration_GetRfeConfiguration.Enabled = true;
            ComboBox_CurrentConfiguration_Preset.Enabled = true;
            GroupBox_ReceivedSignalStrength.Enabled = true;

            gRFEOnSite.Explorer.RequestConfiguration();

            //TabControlMain.Enabled = false;
            GroupBox_CSVFileStorage.Enabled = true;

            await Task.Delay(2000);

            if (Label_Connection_FirmwareValue.Text == @"N/A")
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

            TabControl_Main.SelectedTab = TabControl_Main_OmniDirectional;
            SetCameraState(eFrameType.NEW);
            Label_CurrentConfiguration_Presets.Enabled = true;
            CheckBox_Band_600.Enabled = true;
            CheckBox_Band_700.Enabled = true;
            CheckBox_Band_CEL.Enabled = true;
            CheckBox_Band_PCS.Enabled = true;
            CheckBox_Band_AWS.Enabled = true;
            CheckBox_Band_WCS.Enabled = true;
        }

        private void BaudRate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://j3.rf-explorer.com/40-rfe/article/104-troubleshooting-usb-drivers");
        }

        private void ButtonSetConfiguration_Click(object sender, EventArgs e)
        {
            bool bValidField;

            bValidField = Double.TryParse(TextBox_CurrentConfiguration_StartFrequency.Text, out double startMHz);
            bValidField &= Double.TryParse(TextBox_CurrentConfiguration_StopFrequency.Text, out double stopMHz);
            bValidField &= Double.TryParse(TextBox_CurrentConfiguration_StepFrequency.Text, out double stepKHz);

            if (bValidField)
            {
                if (stopMHz - startMHz < 0.112)
                {
                    string message;
                    string caption = "Impossible RF Explorer Configuration Requested";
                    message = "The entered starting and stopping frequencies are too close together.\n\nChoose a stopping frequency that is at least 112 KHz larger that the starting frequency.\nThe RF Explorer requires 112 bins.";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the Exception MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    return;
                }

                ButtonStartSweeps.Enabled = false;
                ButtonCancelSweeps.Enabled = false;
                GroupBox_SweepControl.Enabled = false;

                gRFEOnSite.Explorer.WaitingForConfigurationCallBack = true;
                gRFEOnSite.Explorer.SendConfiguration(startMHz, stopMHz, -80, -110);
            }
        }

        // Start Sweeps
        private void ButtonStartSweeps_Click(object sender, EventArgs e)
        {
            SetUIItemsEnabledState();
            SetCameraState(eFrameType.IDLE);

            int floorNumber = Convert.ToInt32(NumericUpDown_CSVFileStorage_FloorNumber.Value.ToString());
            int markerNumber = Convert.ToInt32(NumericUpDown_CSVFileStorage_MarkerNumber.Value.ToString());

            if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Disable")
                Label_LocationCamera_Floor.Text = (TextBox_CSVFileStorage_CollectionFloorName.Text + " " + NumericUpDown_CSVFileStorage_FloorNumber.Value.ToString()).Trim();
            else
                Label_LocationCamera_Floor.Text = "";

            Label_LocationCamera_Marker.Text = (TextBox_CSVFileStorage_CollectionMarkerName.Text + " " + NumericUpDown_CSVFileStorage_MarkerNumber.Value.ToString()).Trim();

            RefreshCSVFileStorage(true);

            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {
                gRFEOnSite.FileOps.PopToDirectory(1);
                gRFEOnSite.FileOps.CreateEnterDirectory("RFEOnSite Data");
                gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_Client.Text);
                gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionLocationDescription.Text);

                if (CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked)
                {
                    if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Disable")
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionFloorName.Text + floorNumber.ToString("D2") + "//" + TextBox_CSVFileStorage_CollectionMarkerName.Text + "-" + markerNumber.ToString("D2"));
                    else
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionMarkerName.Text + markerNumber.ToString("D2"));
                }
                else
                {
                    if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Disable")
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionFloorName.Text + floorNumber.ToString("D2") + "//" + TextBox_CSVFileStorage_CollectionMarkerName.Text);
                    else
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionMarkerName.Text);
                }

                gRFEOnSite.FileOps.CreateEnterDirectory(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }

            gRFEOnSite.Explorer.SweepCount = (int)NumericUpDown_SweepControl_Sweeps.Value;

            if (gRFEOnSite.PresetActive)
            {
                gRFEOnSite.PresetTableIndex = 0;

                if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
                {
                    foreach (PresetTableEntry pair in gRFEOnSite.PresetDownlinkTable)
                    {
                        gRFEOnSite.PresetTableIndex++;

                        gRFEOnSite.Explorer.AutoSweep.Initialize(true, 1.0M, gRFEOnSite.Explorer.SweepCount);
                        LabelExecutingTask.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetDownlinkTable.Count();

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
                LabelExecutingTask.Text = "1 of 1";
                TaskProgressBar.Maximum = gRFEOnSite.Explorer.SweepCount;
                TaskProgressBar.Step = 1;
                TaskProgressBar.Value = 0;

                gRFEOnSite.Explorer.Capture = true;
            }
        }

        private void CheckBoxSaveCsvFiles_CheckedChanged(object sender, EventArgs e)
        {
            GroupBoxCsvInformation.Enabled = CheckBox_CSVFileStorage_SaveCsvFiles.Checked;

            RefreshCSVFileStorage();
        }

        private void TextBoxSweepLocation_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;

            RefreshCSVFileStorage();
        }

        private void CheckBoxChartAutoScale_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Graph.AutoScale = CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked;
        }

        private void TextBoxLeftAntennaGain_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TextBox_CurrentConfiguration_LeftAntennaGain.Text, out double gain))
                gRFEOnSite.LeftAntennaGain = gain;
            else
                TextBox_CurrentConfiguration_LeftAntennaGain.Text = "";
        }

        private void TextBoxRightAntennaGain_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TextBox_CurrentConfiguration_RightAntennaGain.Text, out double gain))
                gRFEOnSite.RightAntennaGain = gain;
            else
                TextBox_CurrentConfiguration_RightAntennaGain.Text = "";
        }

        private void ComboBoxPreset_IndexChanged(object sender, EventArgs e)
        {
            CheckBox_Band_600.Enabled = false;
            CheckBox_Band_700.Enabled = false;
            CheckBox_Band_CEL.Enabled = false;
            CheckBox_Band_PCS.Enabled = false;
            CheckBox_Band_AWS.Enabled = false;
            CheckBox_Band_WCS.Enabled = false;

            if (ComboBox_CurrentConfiguration_Preset.SelectedItem == null)
                return;

            StripStatusLabelPreset.Text = "Preset: " + (string)ComboBox_CurrentConfiguration_Preset.SelectedItem;

            var item = (string)ComboBox_CurrentConfiguration_Preset.SelectedItem;

            if (item == "Continuous")
            {
                gRFEOnSite.PresetType = ePreset.eContinuous;

                CheckBox_CSVFileStorage_SaveCsvFiles.Checked = false;
                GroupBox_CSVFileStorage.Enabled = false;
            }

            if (item == "Single Sweep")
            {
                gRFEOnSite.PresetType = ePreset.eSingle;

                gRFEOnSite.PresetActive = false;

                TextBox_CurrentConfiguration_StartFrequency.Enabled = true;
                TextBox_CurrentConfiguration_StopFrequency.Enabled = true;
                TextBoxRBW.Enabled = true;
                TextBox_CurrentConfiguration_StepFrequency.Enabled = true;
                Button_CurrentConfiguration_SetRfeConfiguration.Enabled = true;
                Button_CurrentConfiguration_GetRfeConfiguration.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = false;
            }

            if (item == "Full Downlink")
            {
                CheckBox_Band_600.Enabled = true;
                CheckBox_Band_700.Enabled = true;
                CheckBox_Band_CEL.Enabled = true;
                CheckBox_Band_PCS.Enabled = true;
                CheckBox_Band_AWS.Enabled = true;
                CheckBox_Band_WCS.Enabled = true;

                gRFEOnSite.PresetType = ePreset.eFullDownlink;
               
                TextBox_CurrentConfiguration_StartFrequency.Enabled = false;
                TextBox_CurrentConfiguration_StopFrequency.Enabled = false;
                TextBoxRBW.Enabled = false;
                TextBox_CurrentConfiguration_StepFrequency.Enabled = false;
                Button_CurrentConfiguration_SetRfeConfiguration.Enabled = false;
                Button_CurrentConfiguration_GetRfeConfiguration.Enabled = false;
                GroupBox_SweepControl.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = true;

                gRFEOnSite.PresetActive = true;

                if (gRFEOnSite.PresetActive)
                {
                    ButtonStartSweeps.Enabled = true;
                    CheckBox_CSVFileStorage_SaveCsvFiles.Checked = true;
                }
                else
                {
                    TextBox_CurrentConfiguration_StartFrequency.Enabled = true;
                    TextBox_CurrentConfiguration_StopFrequency.Enabled = true;
                    TextBoxRBW.Enabled = true;
                    TextBox_CurrentConfiguration_StepFrequency.Enabled = true;
                    Button_CurrentConfiguration_SetRfeConfiguration.Enabled = true;
                }
            }
        }

        private void ButtonGetConfiguration_Click(object sender, EventArgs e)
        {
            gRFEOnSite.Explorer.RequestConfiguration();
        }

        private void TextBoxStartFrequency_TextChanged(object sender, EventArgs e)
        {
            double stepSize;
            bool bStatus;

            bStatus = Double.TryParse(TextBox_CurrentConfiguration_StartFrequency.Text, out double start);
            Double.TryParse(TextBox_CurrentConfiguration_StopFrequency.Text, out double stop);

            if (bStatus)
            {
                if (stop > (start + .111) && (stop < 6000.0))
                {
                    stepSize = (stop - start) / 0.1120;
                    TextBox_CurrentConfiguration_StepFrequency.Text = stepSize.ToString("F3");
                    TextBoxRBW.Text = "";
                }
            }
            else
            {
                TextBox_CurrentConfiguration_StepFrequency.Text = (0.112).ToString("F3");
                TextBox_CurrentConfiguration_StopFrequency.Text = (start + .112).ToString("F3");
            }
        }

        private void TextBoxStopFrequency_TextChanged(object sender, EventArgs e)
        {
            double stepSize;
            bool bStatus;

            bStatus = Double.TryParse(TextBox_CurrentConfiguration_StartFrequency.Text, out double start); // **** stop
            Double.TryParse(TextBox_CurrentConfiguration_StopFrequency.Text, out double stop);

            if (bStatus)
            {
                if (stop > start)
                {
                    stepSize = (stop - start) / 0.1120;
                    TextBox_CurrentConfiguration_StepFrequency.Text = stepSize.ToString("F3");
                    TextBoxRBW.Text = "";
                }
            }
        }

        private void RadioButtonAnalyzer_CheckedChanged(object sender, EventArgs e)
        {
            Button_Connection_Documentation.Text = "RF Explorer Documentation";
        }

        private void RadioButtonGenerator_CheckedChanged(object sender, EventArgs e)
        {
            Button_Connection_Documentation.Text = "RFE Generator Documentation";
        }

        private void ButtonCancelSweeps_Click(object sender, EventArgs e)
        {
            ButtonCancelSweeps.Enabled = false;
            LabelExecutingTask.Text = "Done";

            gRFEOnSite.Explorer.SweepCount = 1;
            NumericUpDown_SweepControl_Sweeps.Enabled = true;

            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked && CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked && !gRFEOnSite.PresetActive)
            {
                if (NumericUpDown_CSVFileStorage_MarkerNumber.Value > 1)
                {
                    NumericUpDown_CSVFileStorage_MarkerNumber.Value -= 1;
                }
            }
            gRFEOnSite.Explorer.Capture = false;
            ButtonStartSweeps.Enabled = true;
            ButtonCancelSweeps.Enabled = false;
            TabControl_Main.Enabled = true;
            GroupBox_CSVFileStorage.Enabled = true;
            GroupBox_OmniDirectional_CurrentConfiguration.Enabled = true;
            NumericUpDown_SweepControl_Sweeps.Enabled = true;
        }

        private void CheckBoxRadial_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.RadialSurvey = CheckBoxRadialAzimuth.Checked;
        }

        private void CheckBoxAutoIncrement_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked)
                NumericUpDown_CSVFileStorage_MarkerNumber.Enabled = true;
            else
                NumericUpDown_CSVFileStorage_MarkerNumber.Enabled = false;

            RefreshCSVFileStorage();
        }

        private void TextBoxCollectionSite_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            RefreshCSVFileStorage();
        }

        private void TextBoxClient_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            RefreshCSVFileStorage();
        }

        private void Button_CSVFileStorage_ResetFloorAndMarkers_Click(object sender, EventArgs e)
        {
            Label_LocationCamera_Floor.Text = "Floor ID";
            Label_LocationCamera_Marker.Text = "Marker ID";

            NumericUpDown_CSVFileStorage_FloorNumber.Value = 1;
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            SetCameraState(eFrameType.NEW);
            RefreshCSVFileStorage();
        }

        private void NumericUpDownLocation_ValueChanged(object sender, EventArgs e)
        {
            RefreshCSVFileStorage();
        }

        private void TextBoxFloorLabel_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            RefreshCSVFileStorage();
        }

        private void ToolStripMenuItemFileExit_Click(object sender, EventArgs e)
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
                Button_Connection_ConnectExplorer.Enabled = true;
                Button_Connection_ConnectExplorer.BackColor = Color.Red;
                Button_Connection_ConnectExplorer.Text = "Connect RF Explorer";

                TextBox_CurrentConfiguration_StartFrequency.Text = "";
                TextBox_CurrentConfiguration_StopFrequency.Text = "";
                TextBoxRBW.Text = "";
                TextBox_CurrentConfiguration_StepFrequency.Text = "";
                SetCameraState(eFrameType.NEW);
            }
        }

        private void Button_CSVFileStorage_CollectionFloor_Enable_Click(object sender, EventArgs e)
        {
            if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Enable")
            {
                Button_CSVFileStorage_CollectionFloor_Enable.Text = "Disable";
                GroupBox_CSVFileStorage_AutoNext.Enabled = true;
                Label_LocationCamera_Floor.Text = (TextBox_CSVFileStorage_CollectionFloorName.Text + " " + NumericUpDown_CSVFileStorage_FloorNumber.Value.ToString()).Trim();
                RefreshCSVFileStorage();
            }
            else
            {
                Button_CSVFileStorage_CollectionFloor_Enable.Text = "Enable";
                GroupBox_CSVFileStorage_AutoNext.Enabled = false;
                Label_LocationCamera_Floor.Text = "";
                RefreshCSVFileStorage();
            }

            Label_LocationCamera_Marker.Text = (TextBox_CSVFileStorage_CollectionMarkerName.Text + " " + (NumericUpDown_CSVFileStorage_MarkerNumber.Value - 1).ToString()).Trim();
        }

        private void Button_CSVFileStorage_CollectionFloor_AutoNext_Click(object sender, EventArgs e)
        {
            if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Enable")
                return;

            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;

            if (RadioButton_CSVFileStorage_FloorDecrement.Checked == true)
            {
                if (NumericUpDown_CSVFileStorage_FloorNumber.Value == 1)
                    return;

                NumericUpDown_CSVFileStorage_FloorNumber.Value = NumericUpDown_CSVFileStorage_FloorNumber.Value - 1;
            }
            else
                NumericUpDown_CSVFileStorage_FloorNumber.Value = NumericUpDown_CSVFileStorage_FloorNumber.Value + 1;

            RefreshCSVFileStorage();
        }

        private void NumericUpDownAutoText_ValueChanged(object sender, EventArgs e)
        {
            RefreshCSVFileStorage();
        }

        private void RefreshCSVFileStorage(bool bSweeping = false)
        {
            if (!CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {
                StripStatusLabelDivision1.Text = "";
                StripStatusLabelCsvDirectory.Text = "";
                return;
            }

            StripStatusLabelDivision1.Text = "|";

            if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Disable")
            {
                // Button is displaying "Disable" so Floor collection is enabled
                TextBox_CSVFileStorage_CollectionFloorName.Enabled = true;
                NumericUpDown_CSVFileStorage_FloorNumber.Enabled = true;
                GroupBox_CSVFileStorage_AutoNext.Enabled = true;

                int floorNumber = Convert.ToInt32(NumericUpDown_CSVFileStorage_FloorNumber.Value.ToString());
                int markerNumber = Convert.ToInt32(NumericUpDown_CSVFileStorage_MarkerNumber.Value.ToString());

                if (bSweeping)
                    StripStatusLabelCsvDirectory.Text =
                        "Collecting CSV Capture Directory: Desktop\\RFEOnSite Data\\" +
                        TextBox_CSVFileStorage_Client.Text + "\\" +
                        TextBox_CSVFileStorage_CollectionLocationDescription.Text + "\\" +
                        TextBox_CSVFileStorage_CollectionFloorName.Text +
                        floorNumber.ToString("D2") + "\\" +
                        TextBox_CSVFileStorage_CollectionMarkerName.Text +
                        markerNumber.ToString("D2");
                else
                    StripStatusLabelCsvDirectory.Text =
                    "Next CSV Capture Directory: Desktop\\RFEOnSite Data\\" +
                    TextBox_CSVFileStorage_Client.Text + "\\" +
                    TextBox_CSVFileStorage_CollectionLocationDescription.Text + "\\" +
                    TextBox_CSVFileStorage_CollectionFloorName.Text +
                    floorNumber.ToString("D2") + "\\" +
                    TextBox_CSVFileStorage_CollectionMarkerName.Text +
                    markerNumber.ToString("D2");
            }
            else
            {
                // Button is displaying "Enable" so Floor collection is disabled
                TextBox_CSVFileStorage_CollectionFloorName.Enabled = false;
                NumericUpDown_CSVFileStorage_FloorNumber.Enabled = false;
                GroupBox_CSVFileStorage_AutoNext.Enabled = false;

                int markerNumber = Convert.ToInt32(NumericUpDown_CSVFileStorage_MarkerNumber.Value.ToString());

                if (bSweeping)
                    StripStatusLabelCsvDirectory.Text =
                        "Collecting CSV Capture Directory: Desktop\\RFEOnSite Data\\" +
                        TextBox_CSVFileStorage_Client.Text + "\\" +
                        TextBox_CSVFileStorage_CollectionLocationDescription.Text + "\\" +
                        TextBox_CSVFileStorage_CollectionMarkerName.Text +
                        markerNumber.ToString("D2");
                else
                    StripStatusLabelCsvDirectory.Text =
                    "Next CSV Capture Directory: Desktop\\RFEOnSite Data\\" +
                    TextBox_CSVFileStorage_Client.Text + "\\" +
                    TextBox_CSVFileStorage_CollectionLocationDescription.Text + "\\" +
                    TextBox_CSVFileStorage_CollectionMarkerName.Text +
                    markerNumber.ToString("D2");
            }
        }

        private void ButtonCaptureImage_Click(object sender, EventArgs e)
        {
            if (!gRFEOnSite.CsvDirectoryValid)
                return;

            try
            {
                if (mCapture.IsOpened == false)
                    return;

                Bitmap image = mCapture.QueryFrame().ToBitmap();
                if (image == null)
                {
                    SetCameraState(eFrameType.NEW);
                    return;
                }

                Bitmap resized = new Bitmap(image, new Size(image.Width * 4, image.Height * 4));

                string floorNumber = NumericUpDown_CSVFileStorage_FloorNumber.Value.ToString("00");
                string markerNumber = (NumericUpDown_CSVFileStorage_MarkerNumber.Value - 1).ToString("00");
                string fileName = TextBox_CSVFileStorage_CollectionFloorName.Text + floorNumber + " " +
                                  TextBox_CSVFileStorage_CollectionMarkerName.Text + markerNumber + " " +
                                  DateTime.Now.ToString("yyyy-MM-dd - hh-mm-ss tt") +
                                  ".jpg";

                resized.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                resized.Dispose();
                image.Dispose();

                SetCameraState(eFrameType.CAPTURED);

                SystemSounds.Asterisk.Play();
            }
            catch
            {
                SetCameraState(eFrameType.NEW);
            }
        }

        private void DisplayVideoFrames(object sender, EventArgs e)
        {
            if (!gRFEOnSite.VideoCapture)
                return;

            try
            {
                if (mCapture.IsOpened == true)
                {
                    mMat = mCapture.QueryFrame();
                    PictureBox_LocationCamera.Image = mMat.ToBitmap();
                }
            }
            catch
            {
                gRFEOnSite.VideoCapture = false;
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl_Main.SelectedTab.Text == "Location Camera")
            {
                if (mCapture.IsOpened)
                {
                    TabControl_Main_LocationCamera.Enabled = true;
                    if (gRFEOnSite.CsvDirectoryValid && Button_LocationCamera_CaptureFrame.Text != "Wait for Capture")
                        SetCameraState(eFrameType.ACTIVE);
                    else
                     if (Button_LocationCamera_CaptureFrame.Text != "Wait for Capture")
                        SetCameraState(eFrameType.IDLE);
                }
                else
                {
                    SetCameraState(eFrameType.IDLE);
                    Button_LocationCamera_CaptureFrame.Text = "No Camera Present";
                }
            }
            else
                SetCameraState(eFrameType.IDLE);
        }

        private void Button_CSVFileStorage_ClearAllFields_Click(object sender, EventArgs e)
        {
            //this.CheckBoxSaveCsvFiles.Checked = Settings.Default.Persist_SaveCsvCheckedState;
            TextBox_CSVFileStorage_Client.Text = "Client Name";
            TextBox_CSVFileStorage_CollectionLocationDescription.Text = "Client Location";

            Label_LocationCamera_Floor.Text = "Floor ID";
            Label_LocationCamera_Marker.Text = "Marker ID";

            TextBox_CSVFileStorage_CollectionFloorName.Text = "Floor";
            NumericUpDown_CSVFileStorage_FloorNumber.Value = 1;
            Button_CSVFileStorage_CollectionFloor_Enable.Text = "Disable";
            RadioButton_CSVFileStorage_FloorDecrement.Checked = false;
            RadioButton_CSVFileStorage_FloorIncrement.Checked = true;

            TextBox_CSVFileStorage_CollectionMarkerName.Text = "M";
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked = true;


            CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked = false;
            NumericUpDown_SweepControl_Sweeps.Value = 300;

            ComboBox_CurrentConfiguration_Preset.SelectedIndex = 2;

            CheckBox_Band_600.Checked = true;
            CheckBox_Band_700.Checked = true;
            CheckBox_Band_CEL.Checked = true;
            CheckBox_Band_PCS.Checked = true;
            CheckBox_Band_AWS.Checked = true;
            CheckBox_Band_WCS.Checked = true;

            SetCameraState(eFrameType.NEW);
            RefreshCSVFileStorage();
        }

        private void MenuStripMenuItemPreset_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            if (LabelExecutingTask.Text == "Done" || LabelExecutingTask.Text == "Idle")
            {
                ButtonStartSweeps.Enabled = false;
                ButtonCancelSweeps.Enabled = true;
                gRFEOnSite.CsvDirectoryValid = false;
                SetCameraState(eFrameType.NEW);

                gRFEOnSite.FileOps.FileCounter = 1;
                gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
                gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;
                GroupBox_CSVFileStorage.Enabled = false;
                //GroupBox_OmniDirectional_CurrentConfiguration.Enabled = false;
                NumericUpDown_SweepControl_Sweeps.Enabled = false;
                TabControl_Main.Enabled = false;
                LabelActualSweeps.Text = "";

                gRFEOnSite.FileOps.PopToDirectory(1);
                gRFEOnSite.FileOps.CreateEnterDirectory("CalibrationData");

                gRFEOnSite.FileOps.CreateEnterDirectory(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));

                gRFEOnSite.Explorer.SweepCount = Convert.ToInt32(NumericUpDown_SweepControl_Sweeps.Value);

                if (gRFEOnSite.PresetActive)
                {
                    gRFEOnSite.PresetTableIndex = 0;

                    if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
                    {
                        foreach (PresetTableEntry pair in gRFEOnSite.PresetDownlinkTable)
                        {
                            gRFEOnSite.PresetTableIndex++;

                            LabelExecutingTask.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetDownlinkTable.Count();

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
                    LabelExecutingTask.Text = "1 of 1";
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

        public void SetUIItemsEnabledState(string sweepText = "Capture")
        {
            Label_CurrentConfiguration_Presets.Enabled = true;

            switch (gRFEOnSite.PresetType)
            {
                case ePreset.eContinuous:
                    // Disable all but Cancel in the SweepsControl GroupBox
                    ButtonStartSweeps.Text = sweepText;
                    ButtonStartSweeps.Refresh();
                    ButtonStartSweeps.Enabled = false;

                    ButtonCancelSweeps.Enabled = true;
                    ButtonCancelSweeps.Text = "Stop";
                    gRFEOnSite.CsvDirectoryValid = CheckBox_CSVFileStorage_SaveCsvFiles.Checked;
                    GroupBox_CSVFileStorage.Enabled = false;
                    NumericUpDown_SweepControl_Sweeps.Enabled = true;
                    TabControl_Main.Enabled = false;
                    LabelActualSweeps.Text = "";
                    break;

                case ePreset.eSingle:
                    // Disable all but Cancel in the SweepsControl GroupBox
                    ButtonStartSweeps.Text = sweepText;
                    ButtonStartSweeps.Refresh();
                    ButtonStartSweeps.Enabled = false;

                    ButtonCancelSweeps.Enabled = true;
                    ButtonCancelSweeps.Text = "Cancel";
                    NumericUpDown_SweepControl_Sweeps.Enabled = false;

                    // Disable CSV File Storage GroupBox
                    GroupBox_CSVFileStorage.Enabled = false;

                    // Disable the Main Tab Control
                    TabControl_Main.Enabled = false;

                    // Clear actual number of Sweeps
                    LabelActualSweeps.Text = "";

                    // Set up File Parameters for writing CSV Files
                    gRFEOnSite.FileOps.FileCounter = 1;
                    gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
                    gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;
                    break;

                case ePreset.eFullDownlink:
                    // Disable all but Cancel in the SweepsControl GroupBox
                    ButtonStartSweeps.Text = sweepText;
                    ButtonStartSweeps.Refresh();
                    ButtonStartSweeps.Enabled = false;

                    ButtonCancelSweeps.Enabled = true;
                    ButtonCancelSweeps.Text = "Cancel";
                    gRFEOnSite.CsvDirectoryValid = CheckBox_CSVFileStorage_SaveCsvFiles.Checked;
                    gRFEOnSite.FileOps.FileCounter = 1;
                    gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
                    gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;
                    GroupBox_CSVFileStorage.Enabled = false;
                    NumericUpDown_SweepControl_Sweeps.Enabled = false;
                    TabControl_Main.Enabled = false;
                    LabelActualSweeps.Text = "";
                    break;
            }
        }

        private void ButtonPauseResume_Click(object sender, EventArgs e)
        {
            if (Button_LocationCamera_PauseResume.Text == "Resume")
                SetCameraState(eFrameType.ACTIVE);
            else
                SetCameraState(eFrameType.IDLE);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlg1 = new Form();
            dlg1.ShowDialog();
        }

        private void SetCameraState(eFrameType nextState = eFrameType.NEW)
        {
            // Changes LocationCamera TAB to a new state based on current state

            switch (nextState)
            {
                case eFrameType.NEW:
                    //Display an uninitalized PictureBox
                    Bitmap grayBitmap = new Bitmap(PictureBox_LocationCamera.Width, PictureBox_LocationCamera.Height);

                    // Set the entire bitmap to a solid gray color
                    Color grayColor = Color.Gray;
                    using (Graphics graphics = Graphics.FromImage(grayBitmap))
                    {
                        using (Brush brush = new SolidBrush(grayColor))
                        {
                            graphics.FillRectangle(brush, 0, 0, PictureBox_LocationCamera.Width, PictureBox_LocationCamera.Height);
                        }
                    }

                    // Update the PictureBox with the solid gray image
                    PictureBox_LocationCamera.Image = grayBitmap;
                    PictureBox_LocationCamera.Refresh();

                    Button_LocationCamera_CaptureFrame.Text = "Wait for Capture";
                    Button_LocationCamera_CaptureFrame.BackColor = Color.Gray;
                    Button_LocationCamera_CaptureFrame.Enabled = false;
                    Button_LocationCamera_CaptureFrame.Refresh();

                    Button_LocationCamera_PauseResume.Text = "Waiting";
                    Button_LocationCamera_PauseResume.BackColor = Color.Gray;
                    Button_LocationCamera_PauseResume.Enabled = false;
                    Button_LocationCamera_PauseResume.Refresh();

                    gRFEOnSite.VideoCapture = false;
                    break;

                case eFrameType.ACTIVE:
                    // Start Camera displaying video frames
                    Button_LocationCamera_CaptureFrame.Enabled = true;
                    Button_LocationCamera_CaptureFrame.Text = "Capture Frame";
                    Button_LocationCamera_CaptureFrame.BackColor = SystemColors.Highlight;
                    Button_LocationCamera_CaptureFrame.Refresh();

                    Button_LocationCamera_PauseResume.Enabled = true;
                    Button_LocationCamera_PauseResume.Text = "Pause";
                    Button_LocationCamera_PauseResume.BackColor = SystemColors.Control;
                    Button_LocationCamera_PauseResume.Refresh();

                    gRFEOnSite.VideoCapture = true;
                    break;

                case eFrameType.CAPTURED:
                    // Continure to display captured video frame and pause
                    Button_LocationCamera_CaptureFrame.Text = "Captured";
                    Button_LocationCamera_CaptureFrame.BackColor = Color.Green;
                    Button_LocationCamera_CaptureFrame.Enabled = false;
                    Button_LocationCamera_CaptureFrame.Refresh();

                    Button_LocationCamera_PauseResume.Text = "Resume";
                    Button_LocationCamera_PauseResume.BackColor = SystemColors.Control;
                    Button_LocationCamera_PauseResume.Enabled = true;
                    Button_LocationCamera_PauseResume.Refresh();

                    gRFEOnSite.VideoCapture = false;
                    break;

                case eFrameType.IDLE:
                    //We are initialized 
                    PictureBox_LocationCamera.BackColor = SystemColors.ControlLight;

                    Button_LocationCamera_CaptureFrame.Text = "Paused";
                    Button_LocationCamera_CaptureFrame.BackColor = SystemColors.ControlLight;
                    Button_LocationCamera_CaptureFrame.Enabled = false;
                    Button_LocationCamera_CaptureFrame.Refresh();

                    Button_LocationCamera_PauseResume.Text = "Resume";
                    Button_LocationCamera_PauseResume.BackColor = SystemColors.Control;
                    Button_LocationCamera_PauseResume.Enabled = true;
                    Button_LocationCamera_PauseResume.Refresh();

                    gRFEOnSite.VideoCapture = false;
                    break;
            }
        }

        private void CheckBox_Band_600_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.PresetDownlinkTable.SetDownlinkTableBands(CheckBox_Band_600.Checked, CheckBox_Band_700.Checked, CheckBox_Band_CEL.Checked, CheckBox_Band_PCS.Checked, CheckBox_Band_AWS.Checked, CheckBox_Band_WCS.Checked);
        }

        private void CheckBox_Band_700_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.PresetDownlinkTable.SetDownlinkTableBands(CheckBox_Band_600.Checked, CheckBox_Band_700.Checked, CheckBox_Band_CEL.Checked, CheckBox_Band_PCS.Checked, CheckBox_Band_AWS.Checked, CheckBox_Band_WCS.Checked);
        }

        private void CheckBox_Band_CEL_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.PresetDownlinkTable.SetDownlinkTableBands(CheckBox_Band_600.Checked, CheckBox_Band_700.Checked, CheckBox_Band_CEL.Checked, CheckBox_Band_PCS.Checked, CheckBox_Band_AWS.Checked, CheckBox_Band_WCS.Checked);
        }

        private void CheckBox_Band_PCS_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.PresetDownlinkTable.SetDownlinkTableBands(CheckBox_Band_600.Checked, CheckBox_Band_700.Checked, CheckBox_Band_CEL.Checked, CheckBox_Band_PCS.Checked, CheckBox_Band_AWS.Checked, CheckBox_Band_WCS.Checked);
        }

        private void CheckBox_Band_AWS_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.PresetDownlinkTable.SetDownlinkTableBands(CheckBox_Band_600.Checked, CheckBox_Band_700.Checked, CheckBox_Band_CEL.Checked, CheckBox_Band_PCS.Checked, CheckBox_Band_AWS.Checked, CheckBox_Band_WCS.Checked);
        }

        private void CheckBox_Band_WCS_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.PresetDownlinkTable.SetDownlinkTableBands(CheckBox_Band_600.Checked, CheckBox_Band_700.Checked, CheckBox_Band_CEL.Checked, CheckBox_Band_PCS.Checked, CheckBox_Band_AWS.Checked, CheckBox_Band_WCS.Checked);
        }
    }
}
