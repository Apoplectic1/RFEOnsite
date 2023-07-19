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

namespace RFEOnSite
{
    public partial class MainForm : Form
    {
        public GlobalData gRFEOnSite;
        private VideoCapture mCapture;
        private Mat mMat;

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

            ComboBoxPreset.SelectedIndex = 1;
            //ComboBoxPreset.Enabled = false;

            InitializeChartUI();

            // Navigate to and set User's Desktop as current working Directory
            // Force Dialog to Desktop ONLY
            gRFEOnSite.FileOps.FolderDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            gRFEOnSite.FileOps.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // Navigate to, Create if needed, and Enter Desktop/RFEOnSite Data
            //gRFEOnSite.FileOps.CreateEnterDirectory("RFEOnSite Data");

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
            Settings.Default.Persist_MarkerIncrementState = CheckBoxAutoIncrementMarkerNumber.Checked;


            Settings.Default.Persist_AutoScaleState = CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked;
            Settings.Default.Persist_AverageState = CheckBox_ReceivedSignalStrength_ChartAverage.Checked;
            Settings.Default.Persist_PeakState = CheckBox_ReceivedSignalStrength_ChartPeak.Checked;
            Settings.Default.Persist_SweepsCountState = NumericUpDown_SweepControl_Sweeps.Value;

            Settings.Default.Persist_Preset = ComboBoxPreset.SelectedItem.ToString();
            Settings.Default.Persist_2400State = force2400BaudToolStripMenuItem.Checked;
        }

        void RecallUiPersistanceStates()
        {
            CheckBox_CSVFileStorage_SaveCsvFiles.Checked = Settings.Default.Persist_SaveCsvCheckedState;
            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {
                GroupBoxCsvInformation.Enabled = true;
            }
            else
            {
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
            CheckBoxAutoIncrementMarkerNumber.Checked = Settings.Default.Persist_MarkerIncrementState;

            CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked = Settings.Default.Persist_AutoScaleState;
            CheckBox_ReceivedSignalStrength_ChartAverage.Checked = Settings.Default.Persist_AverageState;
            CheckBox_ReceivedSignalStrength_ChartPeak.Checked = Settings.Default.Persist_PeakState;
            NumericUpDown_SweepControl_Sweeps.Value = Settings.Default.Persist_SweepsCountState;
            force2400BaudToolStripMenuItem.Checked = Settings.Default.Persist_2400State;

            //this.ComboBoxPreset.SelectedItem = Settings.Default.Persist_Preset;
            ComboBoxPreset.SelectedItem = "Manual";
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
            //TextBoxStepFrequency.Text = Math.Round(fromSerialThread.StepMHz * 1000.0, 2).ToString();
            TextBox_CurrentConfiguration_StepFrequency.Text = (fromSerialThread.StepMHz * 1000.0).ToString("F2");

            Label_DeviceValue.Text = fromSerialThread.mMainModel.ToString();
            Label_ModelValue.Text = fromSerialThread.mExpansionModel.ToString();
            Label_FirmwareValue.Text = fromSerialThread.FirmwareVersion;

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
                    ButtonSetConfiguration.Enabled = true;
                }

                GroupBox_SweepControl.Enabled = true;
                RadioButton_SpectrumAnalyzer.Checked = true;
                RadioButton_SignalGenerator.Checked = false;
                RadioButton_SignalGenerator.Enabled = false;


                gRFEOnSite.Graph.MinX = gRFEOnSite.StartFrequency;
                gRFEOnSite.Graph.MaxX = gRFEOnSite.StopFrequency;
                gRFEOnSite.Graph.ChartTitle = "Range: " + gRFEOnSite.Graph.MinX.ToString() + " to " + gRFEOnSite.Graph.MaxX + " MHz";
            }
            else
            {
                ButtonStartSweeps.Enabled = false;
                GroupBox_SweepControl.Enabled = false;
                RadioButton_SpectrumAnalyzer.Checked = false;
                RadioButton_SignalGenerator.Checked = true;
                RadioButton_SpectrumAnalyzer.Enabled = false;
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

            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {

                string fileName;
                if (gRFEOnSite.CalibrationActive)
                {
                    fileName = "Calibration - " + gRFEOnSite.SerialNumebr + " - " + gRFEOnSite.FileOps.FileCounter.ToString("D2") + " ";
                }
                else
                {
                    fileName = TextBox_CSVFileStorage_CollectionLocationDescription.Text + "-" + gRFEOnSite.FileOps.FileCounter.ToString("D2") + " ";
                }
                string dateString = gRFEOnSite.FileOps.RunStartTime.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " ";

                // Convert 714.3435 in MHz to string like 07143
                // 714.0000  should be 07140
                // The Text box may or may not have a decimal point
                string rangeString1;
                string rangeString2;

                if (TextBox_CurrentConfiguration_StartFrequency.Text.Contains("."))
                {
                    rangeString1 = Convert.ToInt64(TextBox_CurrentConfiguration_StartFrequency.Text.Replace(".", "")).ToString("D5") + "to";
                }
                else
                {
                    rangeString1 = Convert.ToInt64(TextBox_CurrentConfiguration_StartFrequency.Text).ToString("D4") + "0to";
                }


                if (TextBox_CurrentConfiguration_StopFrequency.Text.Contains("."))
                {
                    rangeString2 = Convert.ToInt64(TextBox_CurrentConfiguration_StopFrequency.Text.Replace(".", "")).ToString("D5");
                }
                else
                {
                    rangeString2 = Convert.ToInt64(TextBox_CurrentConfiguration_StopFrequency.Text).ToString("D4") + "0";
                }


                // *********************************
                // *********************************
                // This is a BAD way of fixing the file name

                double tempStopMhz = Convert.ToDouble(rangeString2);
                double tempStepSize = Convert.ToDouble(TextBox_CurrentConfiguration_StepFrequency.Text);
                string tempRangeString2 = (tempStopMhz - (tempStepSize / 100.0)).ToString();
                rangeString2 = Convert.ToInt64(tempRangeString2.Replace(".", "")).ToString("D5");


                //**********************************

                if (gRFEOnSite.RadialSurvey)
                {
                    TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + "-" +
                        NumericUpDown_SweepControl_Sweeps.Text + " at " + gRFEOnSite.RadialDegrees.ToString("D3") + " .csv";
                }
                else
                {
                    TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + "-" +
                        NumericUpDown_SweepControl_Sweeps.Text + " at Omni.csv";
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
            if (gRFEOnSite.PresetType == ePreset.eCP4Downlink)
            {
                foreach (PresetTableEntry pair in gRFEOnSite.PresetCP4DownlinkTable.Skip(gRFEOnSite.PresetTableIndex))
                {
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
                        {
                            ButtonCalibrationStart.Text = "Next";
                        }
                        else
                        {
                            gRFEOnSite.Explorer.Capture = true;
                        }
                    }

                    LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetCP4DownlinkTable.Count();
                    return;
                }

            }

            if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
            {
                foreach (PresetTableEntry pair in gRFEOnSite.PresetDownlinkTable.Skip(gRFEOnSite.PresetTableIndex))
                {
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


            if (gRFEOnSite.PresetType == ePreset.eSingle)
            {
                LabelTaskCount.Text = "Done";
                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;

                if (CheckBoxAutoIncrementMarkerNumber.Checked && CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
                {
                    NumericUpDown_CSVFileStorage_MarkerNumber.Value += 1;
                }

                TabControlMain.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = true;
                GroupBox_OmniDirectional_CurrentConfiguration.Enabled = true;
                NumericUpDown_SweepControl_Sweeps.Enabled = true;
            }



            if (gRFEOnSite.PresetType == ePreset.eContinuous)
            {
                LabelTaskCount.Text = "Done";
                ButtonStartSweeps.Enabled = true;
                //ButtonCancelSweeps.Enabled = false;

                if (CheckBoxAutoIncrementMarkerNumber.Checked && CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
                {
                    NumericUpDown_CSVFileStorage_MarkerNumber.Value += 1;
                }

                TabControlMain.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = true;
                GroupBox_OmniDirectional_CurrentConfiguration.Enabled = true;
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

                LabelTaskCount.Text = "Done";


                if (gRFEOnSite.CalibrationActive)
                {
                    ButtonCalibrationStart.Text = "Start";
                }


                if (CheckBoxAutoIncrementMarkerNumber.Checked && CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
                {
                    if (ButtonCancelSweeps.Enabled)
                    {
                        NumericUpDown_CSVFileStorage_MarkerNumber.Value += 1;
                    }
                }

                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;
                TabControlMain.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = true;
                GroupBox_OmniDirectional_CurrentConfiguration.Enabled = true;
                NumericUpDown_SweepControl_Sweeps.Enabled = true;
            }


            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {
                TabControlMain.SelectedTab.Enabled = true;
                gRFEOnSite.CsvDirectoryValid = true;
                gRFEOnSite.CaptureImage = true;
                ButtonCaptureImage.BackColor = SystemColors.Highlight;
                gRFEOnSite.FileOps.PopDirectory(); // For Image Capture
            }
            else
            {
                //gRFEOnSite.CaptureImage = false;
            }
            /*
            else
            {
                TabControlMain.SelectedTab.Enabled = false;
                ButtonCaptureImage.BackColor = Color.Gray;
                ButtonCaptureImage.Refresh();
            }
            */
        }

        private async void ButtonFindPorts_Click(object sender, EventArgs e)
        {
            // Pass "labelRFEComPort.Text" - a string - to Initialize() thread (await)
            // The thread then updates the GUI
            Button_ConnectRFExplorer.Enabled = false;

            gRFEOnSite.Explorer.Force2400Baud = force2400BaudToolStripMenuItem.Checked;

            IProgress<string> UIComPortLabel = new Progress<string>(s => Label_ComPortValue.Text = s);
            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.InitializeSerialConnection(UIComPortLabel));


            Button_ConnectRFExplorer.Text = "Connected";
            Button_ConnectRFExplorer.Enabled = false;
            Button_ConnectRFExplorer.BackColor = Color.Green;


            // A reference to the right hand side object (from the UI Thread) is passed to the thread through the left hand side IProcess object
            IProgress<RFEConfiguration> UpdateUIControls = new Progress<RFEConfiguration>(RFE => UIUpdateCallback_RFE_Configuration(RFE));
            IProgress<List<string>> UpdateUISweepData = new Progress<List<string>>(SWEEPS => UIUpdateCallback_SweepData(SWEEPS));

            IProgress<int> UpdateUIProgressBar = new Progress<int>(s => TaskProgressBar.Value = s);
            /*
            IProgress<int> UpdateUIProgressBar = new Progress<int>(s =>
            {
                TaskProgressBar.Value = s;
                TaskProgressBar.Maximum = s;
            });
            */

            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.CreateReceiveDataThread(
                                    UpdateUIControls,
                                    UpdateUISweepData,
                                    UpdateUIProgressBar));

            ButtonGetRfeConfiguration.Enabled = true;
            ComboBoxPreset.Enabled = true;
            GroupBox_OmniDirectional_CurrentConfiguration.Enabled = true;
            GroupBox_ReceivedSignalStrength.Enabled = true;

            gRFEOnSite.Explorer.RequestConfiguration();

            TabControlMain.SelectedTab.Enabled = false;

            GroupBox_CSVFileStorage.Enabled = true;


            await Task.Delay(2000);


            if (Label_FirmwareValue.Text == @"N/A")
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

            TabControlMain.SelectedTab = TabControlMainOmniDirectional;
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

        private void ButtonStartSweeps_Click(object sender, EventArgs e)
        {
            SetUIItemsEnabledState();


            int floorNumber = Convert.ToInt32(NumericUpDown_CSVFileStorage_FloorNumber.Value.ToString());
            int markerNumber = Convert.ToInt32(NumericUpDown_CSVFileStorage_MarkerNumber.Value.ToString());

            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
            {
                gRFEOnSite.FileOps.PopToDirectory(1);
                gRFEOnSite.FileOps.CreateEnterDirectory("RFEOnSite Data");
                gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_Client.Text);
                gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionLocationDescription.Text);
                if (CheckBoxAutoIncrementMarkerNumber.Checked)
                {
                    if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Disable")
                    {
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionFloorName.Text + floorNumber.ToString("D2") + "//" + TextBox_CSVFileStorage_CollectionMarkerName.Text + "-" +
                            markerNumber.ToString("D2"));
                    }
                    else
                    {
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionMarkerName.Text + markerNumber.ToString("D2"));
                    }
                }
                else
                {
                    if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Disable")
                    {
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionFloorName.Text + floorNumber.ToString("D2") + "//" + TextBox_CSVFileStorage_CollectionMarkerName.Text);
                    }
                    else
                    {
                        gRFEOnSite.FileOps.CreateEnterDirectory(TextBox_CSVFileStorage_CollectionMarkerName.Text);
                    }
                }

                gRFEOnSite.FileOps.CreateEnterDirectory(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            }

            gRFEOnSite.Explorer.SweepCount = (int)NumericUpDown_SweepControl_Sweeps.Value;

            if (gRFEOnSite.PresetActive)
            {
                gRFEOnSite.PresetTableIndex = 0;

                if (gRFEOnSite.PresetType == ePreset.eCP4Downlink)
                {
                    foreach (PresetTableEntry pair in gRFEOnSite.PresetCP4DownlinkTable)
                    {
                        gRFEOnSite.PresetTableIndex++;

                        LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetCP4DownlinkTable.Count();

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
            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
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
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;

            RefreshUI();
        }

        private void CheckBoxChartAutoScale_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Graph.AutoScale = CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked;
        }

        private void TextBoxLeftAntennaGain_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TextBox_CurrentConfiguration_LeftAntennaGain.Text, out double gain))
            {
                gRFEOnSite.LeftAntennaGain = gain;
            }
            else
            {
                TextBox_CurrentConfiguration_LeftAntennaGain.Text = "";
            }
        }

        private void TextBoxRightAntennaGain_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TextBox_CurrentConfiguration_RightAntennaGain.Text, out double gain))
            {
                gRFEOnSite.RightAntennaGain = gain;
            }
            else
            {
                TextBox_CurrentConfiguration_RightAntennaGain.Text = "";
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

                CheckBox_CSVFileStorage_SaveCsvFiles.Checked = false;
                GroupBox_CSVFileStorage.Enabled = false;
            }

            if (item == "Single")
            {
                gRFEOnSite.PresetType = ePreset.eSingle;

                gRFEOnSite.PresetActive = false;

                TextBox_CurrentConfiguration_StartFrequency.Enabled = true;
                TextBox_CurrentConfiguration_StopFrequency.Enabled = true;
                TextBoxRBW.Enabled = true;
                TextBox_CurrentConfiguration_StepFrequency.Enabled = true;
                ButtonSetConfiguration.Enabled = true;
                ButtonGetRfeConfiguration.Enabled = true;
            }


            if (item == "CP4 Downlink")
            {
                gRFEOnSite.PresetType = ePreset.eCP4Downlink;

                TextBox_CurrentConfiguration_StartFrequency.Enabled = false;
                TextBox_CurrentConfiguration_StopFrequency.Enabled = false;
                TextBoxRBW.Enabled = false;
                TextBox_CurrentConfiguration_StepFrequency.Enabled = false;
                ButtonSetConfiguration.Enabled = false;
                ButtonGetRfeConfiguration.Enabled = false;
                GroupBox_SweepControl.Enabled = true;
                ButtonCancelSweeps.Enabled = false;

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
                    ButtonSetConfiguration.Enabled = true;
                }
            }


            if (item == "Full Downlink")
            {
                gRFEOnSite.PresetType = ePreset.eFullDownlink;

                TextBox_CurrentConfiguration_StartFrequency.Enabled = false;
                TextBox_CurrentConfiguration_StopFrequency.Enabled = false;
                TextBoxRBW.Enabled = false;
                TextBox_CurrentConfiguration_StepFrequency.Enabled = false;
                ButtonSetConfiguration.Enabled = false;
                ButtonGetRfeConfiguration.Enabled = false;
                GroupBox_SweepControl.Enabled = true;

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
                    ButtonSetConfiguration.Enabled = true;
                }
            }
        }

        private void ButtonDocumentation_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadioButton_SpectrumAnalyzer.Checked)
                {
                    System.Diagnostics.Process.Start("https://j3.rf-explorer.com/download/docs/RF%20Explorer%20Spectrum%20Analyzer%20User%20Manual.pdf");
                }
                else
                {
                    if (RadioButton_SignalGenerator.Checked)
                    {
                        System.Diagnostics.Process.Start("https://j3.rf-explorer.com/download/docs/RF%20Explorer%20Signal%20Generator%20User%20Manual.pdf");
                    }
                    else
                    {
                        System.Diagnostics.Process.Start("https://j3.rf-explorer.com/download/docs/RF%20Explorer%20Spectrum%20Analyzer%20User%20Manual.pdf");
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
            gRFEOnSite.Graph.GraphPeak = CheckBox_ReceivedSignalStrength_ChartPeak.Checked;
            if (gRFEOnSite.Graph.GraphAverage == false && gRFEOnSite.Graph.GraphPeak == false)
            {
                CheckBox_ReceivedSignalStrength_ChartAverage.Checked = true;
                gRFEOnSite.Graph.GraphAverage = true;
            }
        }

        private void CheckBoxChartAverage_CheckedChanged(object sender, EventArgs e)
        {
            gRFEOnSite.Graph.GraphAverage = CheckBox_ReceivedSignalStrength_ChartAverage.Checked;

            if (gRFEOnSite.Graph.GraphAverage == false && gRFEOnSite.Graph.GraphPeak == false)
            {
                CheckBox_ReceivedSignalStrength_ChartPeak.Checked = true;
                gRFEOnSite.Graph.GraphPeak = true;
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
            /*
            else
            {
                TextBox_CurrentConfiguration_StopFrequency.Text = "";
            }
            */
        }

        private void RadioButtonAnalyzer_CheckedChanged(object sender, EventArgs e)
        {
            Button_REEDocumentation.Text = "RF Explorer Documentation";
        }

        private void RadioButtonGenerator_CheckedChanged(object sender, EventArgs e)
        {
            Button_REEDocumentation.Text = "RFE Generator Documentation";
        }

        private void ButtonCancelSweeps_Click(object sender, EventArgs e)
        {
            ButtonCancelSweeps.Enabled = false;
            LabelTaskCount.Text = "Done";

            gRFEOnSite.Explorer.SweepCount = 1;
            gRFEOnSite.PresetTableIndex = gRFEOnSite.PresetCP4DownlinkTable.Count();
            NumericUpDown_SweepControl_Sweeps.Enabled = true;

            if (CheckBox_CSVFileStorage_SaveCsvFiles.Checked && CheckBoxAutoIncrementMarkerNumber.Checked && !gRFEOnSite.PresetActive)
            {
                if (NumericUpDown_CSVFileStorage_MarkerNumber.Value > 1)
                {
                    NumericUpDown_CSVFileStorage_MarkerNumber.Value -= 1;
                }
            }
            gRFEOnSite.Explorer.Capture = false;

            //gRFEOnSite.CancelActive = true;

            ButtonStartSweeps.Enabled = true;
            ButtonCancelSweeps.Enabled = false;
            TabControlMain.Enabled = true;
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
            if (CheckBoxAutoIncrementMarkerNumber.Checked)
            {
                NumericUpDown_CSVFileStorage_MarkerNumber.Enabled = true;
            }
            else
            {
                NumericUpDown_CSVFileStorage_MarkerNumber.Enabled = false;
            }

            RefreshUI();
        }

        private void TextBoxCollectionSite_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;

            RefreshUI();
        }

        private void TextBoxClient_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            RefreshUI();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NumericUpDown_CSVFileStorage_FloorNumber.Value = 1;
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            RefreshUI();
        }
        private void NumericUpDownLocation_ValueChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void TextBoxFloorLabel_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            RefreshUI();
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
                Button_ConnectRFExplorer.Enabled = true;
                Button_ConnectRFExplorer.BackColor = Color.Red;
                Button_ConnectRFExplorer.Text = "Connect RF Explorer";

                TextBox_CurrentConfiguration_StartFrequency.Text = "";
                TextBox_CurrentConfiguration_StopFrequency.Text = "";
                TextBoxRBW.Text = "";
                TextBox_CurrentConfiguration_StepFrequency.Text = "";
            }
        }

        private void Button_CSVFileStorage_CollectionFloor_Enable_Click(object sender, EventArgs e)
        {
            if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Enable")
            {
                Button_CSVFileStorage_CollectionFloor_Enable.Text = "Disable";
                GroupBox_CSVFileStorage_AutoNext.Enabled = true;
                RefreshUI();
                return;
            }
            else
            {
                Button_CSVFileStorage_CollectionFloor_Enable.Text = "Enable";
                GroupBox_CSVFileStorage_AutoNext.Enabled = false;
                RefreshUI();
                return;
            }
        }

        private void Button_CSVFileStorage_CollectionFloor_AutoNext_Click(object sender, EventArgs e)
        {

            if (Button_CSVFileStorage_CollectionFloor_Enable.Text == "Enable")
            {
                return;
            }

            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;

            if (RadioButton_CSVFileStorage_FloorDecrement.Checked == true)
            {
                if (NumericUpDown_CSVFileStorage_FloorNumber.Value == 1)
                {
                    return;
                }

                NumericUpDown_CSVFileStorage_FloorNumber.Value = NumericUpDown_CSVFileStorage_FloorNumber.Value - 1;
            }
            else
            {
                NumericUpDown_CSVFileStorage_FloorNumber.Value = NumericUpDown_CSVFileStorage_FloorNumber.Value + 1;
            }

            RefreshUI();

        }

        private void NumericUpDownAutoText_ValueChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void RefreshUI()
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

                StripStatusLabelCsvDirectory.Text =
                    "Next CSV Capture Directory: Desktop\\RFEOnSite Data\\" +
                    TextBox_CSVFileStorage_Client.Text +
                    "\\" +
                    TextBox_CSVFileStorage_CollectionLocationDescription.Text +
                    "\\" +
                    TextBox_CSVFileStorage_CollectionFloorName.Text +
                    floorNumber.ToString("D2") +
                    "\\" +
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

                StripStatusLabelCsvDirectory.Text =
                    "Next CSV Capture Directory: Desktop\\RFEOnSite Data\\" +
                    TextBox_CSVFileStorage_Client.Text +
                    "\\" +
                    TextBox_CSVFileStorage_CollectionLocationDescription.Text +
                    "\\" +
                    TextBox_CSVFileStorage_CollectionMarkerName.Text +
                     markerNumber.ToString("D2");
            }
        }



        private void ButtonCaptureImage_Click(object sender, EventArgs e)
        {
            if (!gRFEOnSite.CsvDirectoryValid)
            {
                return;
            }

            Bitmap image = mCapture.QueryFrame().ToBitmap();
            Bitmap resized = new Bitmap(image, new Size(image.Width * 4, image.Height * 4));
            resized.Save(DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            resized.Dispose();
            image.Dispose();

            ButtonPauseResume.Text = "Resume";
            gRFEOnSite.CaptureImage = false;

            ButtonCaptureImage.BackColor = Color.Green;
            ButtonCaptureImage.Enabled = false;
            ButtonCaptureImage.Text = "Captured";
            ButtonCaptureImage.Refresh();

            SystemSounds.Asterisk.Play();
            
            //ButtonCaptureImage.BackColor = SystemColors.Highlight;
        }

        private void ProcessVideoFrame(object sender, EventArgs e)
        {
            if (!gRFEOnSite.CaptureImage)
            {
                return;
            }

            try
            {
                if (mCapture != null)
                {
                    mMat = mCapture.QueryFrame();
                    PictureBox.Image = mMat.ToBitmap();
                }
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
                    ButtonCaptureImage.BackColor = SystemColors.Highlight;
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

        private void Button_CSVFileStorage_ClearAllFields_Click(object sender, EventArgs e)
        {
            //this.CheckBoxSaveCsvFiles.Checked = Settings.Default.Persist_SaveCsvCheckedState;
            TextBox_CSVFileStorage_Client.Text = "Client Name";
            TextBox_CSVFileStorage_CollectionLocationDescription.Text = "Client Location";

            TextBox_CSVFileStorage_CollectionFloorName.Text = "Floor";
            NumericUpDown_CSVFileStorage_FloorNumber.Value = 1;
            Button_CSVFileStorage_CollectionFloor_Enable.Text = "Disable";
            RadioButton_CSVFileStorage_FloorDecrement.Checked = false;
            RadioButton_CSVFileStorage_FloorIncrement.Checked = true;

            TextBox_CSVFileStorage_CollectionMarkerName.Text = "M";
            NumericUpDown_CSVFileStorage_MarkerNumber.Value = 1;
            this.CheckBoxAutoIncrementMarkerNumber.Checked = true;


            CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked = false;
            CheckBox_ReceivedSignalStrength_ChartAverage.Checked = true;
            CheckBox_ReceivedSignalStrength_ChartPeak.Checked = true;
            NumericUpDown_SweepControl_Sweeps.Value = 100;

            //this.ComboBoxPreset.SelectedItem = "Manual";

            TabControlMain.SelectedTab = TabControlMainOmniDirectional;

            RefreshUI();

        }

        private void MenuStripMenuItemPreset_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BaudRate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://j3.rf-explorer.com/40-rfe/article/104-troubleshooting-usb-drivers");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://j3.rf-explorer.com/download/sw/win/RFExplorer_USB_Driver.zip");
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
                GroupBox_CSVFileStorage.Enabled = false;
                GroupBox_OmniDirectional_CurrentConfiguration.Enabled = false;
                NumericUpDown_SweepControl_Sweeps.Enabled = false;
                TabControlMain.Enabled = false;
                LabelActualSweeps.Text = "";

                gRFEOnSite.FileOps.PopToDirectory(1);
                gRFEOnSite.FileOps.CreateEnterDirectory("CalibrationData");

                gRFEOnSite.FileOps.CreateEnterDirectory(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));

                gRFEOnSite.Explorer.SweepCount = Convert.ToInt32(NumericUpDown_SweepControl_Sweeps.Value);

                if (gRFEOnSite.PresetActive)
                {
                    gRFEOnSite.PresetTableIndex = 0;

                    if (gRFEOnSite.PresetType == ePreset.eCP4Downlink)
                    {
                        foreach (PresetTableEntry pair in gRFEOnSite.PresetCP4DownlinkTable)
                        {
                            gRFEOnSite.PresetTableIndex++;

                            LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetCP4DownlinkTable.Count();

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

        public void SetUIItemsEnabledState()
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
                    GroupBox_CSVFileStorage.Enabled = false;
                    GroupBox_OmniDirectional_CurrentConfiguration.Enabled = true;
                    NumericUpDown_SweepControl_Sweeps.Enabled = true;
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
                    GroupBox_CSVFileStorage.Enabled = false;
                    GroupBox_OmniDirectional_CurrentConfiguration.Enabled = false;
                    NumericUpDown_SweepControl_Sweeps.Enabled = false;
                    TabControlMain.Enabled = false;
                    LabelActualSweeps.Text = "";
                    break;

                case ePreset.eCP4Downlink:
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
                    GroupBox_CSVFileStorage.Enabled = false;
                    GroupBox_OmniDirectional_CurrentConfiguration.Enabled = false;
                    NumericUpDown_SweepControl_Sweeps.Enabled = false;
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
                    GroupBox_CSVFileStorage.Enabled = false;
                    GroupBox_OmniDirectional_CurrentConfiguration.Enabled = false;
                    NumericUpDown_SweepControl_Sweeps.Enabled = false;
                    TabControlMain.Enabled = false;
                    LabelActualSweeps.Text = "";
                    break;
            }
        }

        private void ButtonPauseResume_Click(object sender, EventArgs e)
        {
            if (ButtonPauseResume.Text == "Resume")
            {
                ButtonCaptureImage.BackColor = SystemColors.Highlight;
                ButtonCaptureImage.Enabled = true;
                ButtonCaptureImage.Text = "Capture Frame";

                ButtonPauseResume.Text = "Pause";
                gRFEOnSite.CaptureImage = true;
            }
            else if (ButtonPauseResume.Text == "Pause")
            {
                ButtonCaptureImage.BackColor = SystemColors.ControlLight;
                ButtonCaptureImage.Enabled = false;
                ButtonCaptureImage.Text = "Pasued";

                ButtonPauseResume.Text = "Resume";
                gRFEOnSite.CaptureImage = false;
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlg1 = new Form();
            dlg1.ShowDialog();
        }
    }
}
