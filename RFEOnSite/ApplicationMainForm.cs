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
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing.Imaging;

namespace RFEOnSite
{
    public partial class MainForm : Form
    {
        public GlobalData gRFEOnSite;

        public MainForm()
        {

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
            NumericUpDownLocation.Enabled = false;
            CheckBoxAutoIncrement.Enabled = false;
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

                GroupBoxSweepControl.Enabled = true;
                RadioButtonAnalyzer.Checked = true;
                RadioButtonGenerator.Checked = false;
                RadioButtonGenerator.Enabled = false;


                gRFEOnSite.Graph.MinX = gRFEOnSite.StartFrequency;
                gRFEOnSite.Graph.MaxX = gRFEOnSite.StopFrequency;

                //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Maximum = gRFEOnSite.Graph.MaxX;
                //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Minimum = gRFEOnSite.Graph.MinX;

                //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Interval = (gRFEOnSite.Graph.MaxX - gRFEOnSite.Graph.MinX) / 5;

                //gRFEOnSite.Graph.DrawChart(gRFEOnSite.Graph.GraphPeak, gRFEOnSite.Graph.GraphAverage, gRFEOnSite.ExplorerSweepData);
            }
            else
            {
                ButtonStartSweeps.Enabled = false;
                GroupBoxSweepControl.Enabled = false;
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
                string fileName = TextBoxCollectionLocation.Text + "-" + gRFEOnSite.FileOps.FileCounter.ToString("D2") + " ";
                string dateString = gRFEOnSite.FileOps.RunStartTime.ToString("yyyy-MM-dd HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " ";
                string rangeString1 = Convert.ToInt64(TextBoxStartFrequency.Text.Replace(".", "")).ToString("D5") + "to";
                string rangeString2 = Convert.ToInt64(TextBoxStopFrequency.Text.Replace(".", "")).ToString("D5");

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

            if (gRFEOnSite.PresetActive)
            {
                // This foreach cycles through each entry in PresetTable skipping entries that are disabled by the UI (in switch () {})
                // Upon entry, it skips PresetTable entries that have already been processed or ignored
                if (gRFEOnSite.PresetType == ePreset.eWhoopDownlink)
                {
                    foreach (PresetTableEntry pair in gRFEOnSite.PresetWhoopDownlinkTable.Skip(gRFEOnSite.PresetTableIndex))
                    {
                        gRFEOnSite.PresetTableIndex++; // Needs to be before the breaks to stay in step with foreach

                        switch (pair.SweepBand)
                        {
                            case eBand.e700:
                                if (!gRFEOnSite.Sweep700) continue;
                                break;
                            case eBand.e850:
                                if (!gRFEOnSite.Sweep850) continue;
                                break;
                            case eBand.ePCS:
                                if (!gRFEOnSite.SweepPCS) continue;
                                break;
                            case eBand.eAWS:
                                if (!gRFEOnSite.SweepAWS) continue;
                                break;
                            default:
                                MessageBox.Show("You broke something. ApplicationMainForm.cs\n " +
                                    "Callback: UIUpdateCallback_SweepData(List<string> sweepsFromExplorer)");
                                Application.Exit();
                                break;
                        }

                        // We found a table entry to Sweep: Program the RF Explorer
                        gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                        System.Threading.Thread.Sleep(100);

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
                            gRFEOnSite.Explorer.Capture = true;
                        }

                        LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetWhoopDownlinkTable.Count();
                        return;
                    }
                }


                if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
                {
                    foreach (PresetTableEntry pair in gRFEOnSite.PresetDownlinkTable.Skip(gRFEOnSite.PresetTableIndex))
                    {
                        gRFEOnSite.PresetTableIndex++; // Needs to be before the breaks to stay in step with foreach

                        switch (pair.SweepBand)
                        {
                            case eBand.e700:
                                if (!gRFEOnSite.Sweep700) continue;
                                break;
                            case eBand.e850:
                                if (!gRFEOnSite.Sweep850) continue;
                                break;
                            case eBand.ePCS:
                                if (!gRFEOnSite.SweepPCS) continue;
                                break;
                            case eBand.eAWS:
                                if (!gRFEOnSite.SweepAWS) continue;
                                break;
                            default:
                                MessageBox.Show("You broke something. ApplicationMainForm.cs\n " +
                                    "Callback: UIUpdateCallback_SweepData(List<string> sweepsFromExplorer)");
                                Application.Exit();
                                break;
                        }

                        // We found a table entry to Sweep: Program the RF Explorer
                        gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                        System.Threading.Thread.Sleep(100);

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
                            gRFEOnSite.Explorer.Capture = true;
                        }

                        LabelTaskCount.Text = gRFEOnSite.PresetTableIndex.ToString() + " of " + gRFEOnSite.PresetDownlinkTable.Count();
                        return;
                    }
                }
            }
            else // Manual Sweep
            {
                LabelTaskCount.Text = "Done";
                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;

                if (CheckBoxAutoIncrement.Checked && CheckBoxSaveCsvFiles.Checked)
                {
                    NumericUpDownLocation.Value += 1;
                }

                TabControlMain.Enabled = true;
                GroupBoxCsvConfiguration.Enabled = true;
                GroupBoxConfiguration.Enabled = true;
                NumericUpDownSweeps.Enabled = true;
            }

            // The only way we get here is by walking through every table entry - we have to be done
            if (gRFEOnSite.PresetActive)
            {

                LabelTaskCount.Text = "Done";


                if (CheckBoxAutoIncrement.Checked && CheckBoxSaveCsvFiles.Checked)
                {
                    if (ButtonCancelSweeps.Enabled)
                    {
                        NumericUpDownLocation.Value += 1;
                    }
                }

                ButtonStartSweeps.Enabled = true;
                ButtonCancelSweeps.Enabled = false;
                TabControlMain.Enabled = true;
                GroupBoxCsvConfiguration.Enabled = true;
                GroupBoxConfiguration.Enabled = true;
                NumericUpDownSweeps.Enabled = true;
            }
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

            await Task.Factory.StartNew(() => gRFEOnSite.Explorer.CreateReceiveDataThread(
                                    UpdateUIControls,
                                    UpdateUISweepData,
                                    UpdateUIProgressBar));

            ButtonGetConfiguration.Enabled = true;
            ComboBoxPreset.Enabled = true;
            GroupBoxConfiguration.Enabled = true;
            GroupBoxCsvConfiguration.Enabled = true;
            PanelChart.Enabled = true;
            GroupBoxChart.Enabled = true;
            ChartPanel.Enabled = true;

            gRFEOnSite.Explorer.RequestConfiguration();

            ButtonStartSweeps.Enabled = true;
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
                GroupBoxSweepControl.Enabled = false;

                gRFEOnSite.Explorer.WaitingForConfigurationCallBack = true;
                gRFEOnSite.Explorer.SendConfiguration(startMHz, stopMHz, -80, -110);
            }
        }

        private void ButtonStartSweeps_Click(object sender, EventArgs e)
        {
            ButtonStartSweeps.Enabled = false;
            ButtonCancelSweeps.Enabled = true;

            gRFEOnSite.FileOps.FileCounter = 1;
            gRFEOnSite.FileOps.RunStartTime = DateTime.Now;
            gRFEOnSite.FileOps.FolderDialog.SelectedPath = string.Empty;
            GroupBoxCsvConfiguration.Enabled = false;
            GroupBoxConfiguration.Enabled = false;
            NumericUpDownSweeps.Enabled = false;
            TabControlMain.Enabled = false;
            LabelActualSweeps.Text = "";

            if (CheckBoxSaveCsvFiles.Checked)
            {
                gRFEOnSite.FileOps.PopToDirectory(1);
                gRFEOnSite.FileOps.CreateEnterDirectory("SurveyData");
                gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxClient.Text);
                gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxCollectionLocation.Text);
                if (CheckBoxAutoIncrement.Checked)
                {
                    gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxCollectionSite.Text + "-" + NumericUpDownLocation.Value.ToString());
                }
                else
                {
                    gRFEOnSite.FileOps.CreateEnterDirectory(TextBoxCollectionSite.Text);
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

                        switch (pair.SweepBand)
                        {
                            case eBand.e700:
                                if (!gRFEOnSite.Sweep700) continue;
                                break;
                            case eBand.e850:
                                if (!gRFEOnSite.Sweep850) continue;
                                break;
                            case eBand.ePCS:
                                if (!gRFEOnSite.SweepPCS) continue;
                                break;
                            case eBand.eAWS:
                                if (!gRFEOnSite.SweepAWS) continue;
                                break;
                            default:
                                continue;
                        }


                        gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                        System.Threading.Thread.Sleep(100);

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

                        switch (pair.SweepBand)
                        {
                            case eBand.e700:
                                if (!gRFEOnSite.Sweep700) continue;
                                break;
                            case eBand.e850:
                                if (!gRFEOnSite.Sweep850) continue;
                                break;
                            case eBand.ePCS:
                                if (!gRFEOnSite.SweepPCS) continue;
                                break;
                            case eBand.eAWS:
                                if (!gRFEOnSite.SweepAWS) continue;
                                break;
                            default:
                                continue;
                        }

                        gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                        System.Threading.Thread.Sleep(100);

                        //gRFEOnSite.Graph.MinX = pair.SweepStart;
                        //gRFEOnSite.Graph.MaxX = pair.SweepStop;

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
                TextBoxCollectionLocation.Enabled = true;
                TextBoxCsvFileName.Enabled = true;
                LabelProgressWriteCsvFile.Enabled = true;
                CheckBoxAutoIncrement.Enabled = true;
                TextBoxClient.Enabled = true;
                TextBoxCollectionSite.Enabled = true;
                LabelCsvDirectory.Enabled = true;
                LabelProgressWriteCsvFile.Enabled = true;

                if (ButtonFloorId.Text == "Next")
                {
                    LabelCsvDirectory.Text = "Desktop\\SurveyData\\" + TextBoxClient.Text + "\\" + TextBoxCollectionLocation.Text + "\\" + TextBoxAutoLabel.Text + NumericUpDownAutoText.Value.ToString() + " " + TextBoxCollectionSite.Text + "-" + NumericUpDownLocation.Value.ToString();
                }
                else
                {
                    LabelCsvDirectory.Text = "Desktop\\SurveyData\\" + TextBoxClient.Text + "\\" + TextBoxCollectionLocation.Text + "\\" + TextBoxCollectionSite.Text;
                }
            }
            else
            {
                TextBoxCollectionLocation.Enabled = false;
                TextBoxCsvFileName.Enabled = false;
                LabelProgressWriteCsvFile.Enabled = true;
                CheckBoxAutoIncrement.Enabled = false;
                TextBoxClient.Enabled = false;
                TextBoxCollectionSite.Enabled = false;
                LabelCsvDirectory.Enabled = false;
                LabelProgressWriteCsvFile.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


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

            gRFEOnSite.Explorer.DestroyReceiveDataThread();
            gRFEOnSite.Explorer.DisconnectSerialPort();
        }

        private void ConfigurationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConnectionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBoxSweepLocation_TextChanged(object sender, EventArgs e)
        {
            if (ButtonFloorId.Text == "Next")
            {
                LabelCsvDirectory.Text = "Desktop\\SurveyData\\" + TextBoxClient.Text + "\\" + TextBoxCollectionLocation.Text + "\\" + TextBoxAutoLabel.Text + NumericUpDownAutoText.Value.ToString() + " " + TextBoxCollectionSite.Text + "-" + NumericUpDownLocation.Value.ToString();
            }
            else
            {
                LabelCsvDirectory.Text = "Desktop\\SurveyData\\" + TextBoxClient.Text + "\\" + TextBoxCollectionLocation.Text + "\\" + TextBoxCollectionSite.Text;
            }
            NumericUpDownLocation.Value = 1;

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

            var item = (string)ComboBoxPreset.SelectedItem;

            if (item == "Whoop Downlink")
            {
                gRFEOnSite.PresetType = ePreset.eWhoopDownlink;

                TextBoxStartFrequency.Enabled = false;
                TextBoxStopFrequency.Enabled = false;
                TextBoxRBW.Enabled = false;
                TextBoxStepFrequency.Enabled = false;
                ButtonSetConfiguration.Enabled = false;
                ButtonGetConfiguration.Enabled = false;
                GroupBoxSweepControl.Enabled = true;
                ButtonCancelSweeps.Enabled = false;

                CheckBoxHoldStart.Enabled = false;
                CheckBoxHoldStep.Enabled = false;
                CheckBoxHoldStop.Enabled = false;

                using (WhoopNodeForm mWhoopNodeDownlinkForm = new WhoopNodeForm())
                {
                    mWhoopNodeDownlinkForm.PresetFormCheckBox700 = gRFEOnSite.Sweep700;
                    mWhoopNodeDownlinkForm.PresetFormCheckBox850 = gRFEOnSite.Sweep850;
                    mWhoopNodeDownlinkForm.PresetFormCheckBoxPCS = gRFEOnSite.SweepPCS;
                    mWhoopNodeDownlinkForm.PresetFormCheckBoxAWS = gRFEOnSite.SweepAWS;

                    mWhoopNodeDownlinkForm.StartPosition = FormStartPosition.CenterParent;

                    mWhoopNodeDownlinkForm.ShowDialog();

                    gRFEOnSite.PresetActive = mWhoopNodeDownlinkForm.Selected;

                    if (gRFEOnSite.PresetActive)
                    {
                        gRFEOnSite.Sweep700 = mWhoopNodeDownlinkForm.PresetFormCheckBox700;
                        gRFEOnSite.Sweep850 = mWhoopNodeDownlinkForm.PresetFormCheckBox850;
                        gRFEOnSite.SweepPCS = mWhoopNodeDownlinkForm.PresetFormCheckBoxPCS;
                        gRFEOnSite.SweepAWS = mWhoopNodeDownlinkForm.PresetFormCheckBoxAWS;
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

                return;
            }

            if (item == "Manual")
            {
                gRFEOnSite.PresetActive = false;
                gRFEOnSite.PresetType = ePreset.eManual;

                TextBoxStartFrequency.Enabled = true;
                TextBoxStopFrequency.Enabled = true;
                TextBoxRBW.Enabled = true;
                TextBoxStepFrequency.Enabled = true;
                ButtonSetConfiguration.Enabled = true;
                ButtonGetConfiguration.Enabled = true;
                CheckBoxHoldStart.Enabled = true;
                CheckBoxHoldStep.Enabled = true;
                CheckBoxHoldStop.Enabled = true;
                return;
            }

            if (item == "Full Downlink")
            {
                gRFEOnSite.PresetType = ePreset.eFullDownlink;

                TextBoxStartFrequency.Enabled = false;
                TextBoxStopFrequency.Enabled = false;
                TextBoxRBW.Enabled = false;
                TextBoxStepFrequency.Enabled = false;
                ButtonSetConfiguration.Enabled = false;
                ButtonGetConfiguration.Enabled = false;
                GroupBoxSweepControl.Enabled = true;

                CheckBoxHoldStart.Enabled = false;
                CheckBoxHoldStep.Enabled = false;
                CheckBoxHoldStop.Enabled = false;

                using (FullDownlinkForm mFullDownlinkForm = new FullDownlinkForm())
                {
                    mFullDownlinkForm.PresetFormCheckBox700 = gRFEOnSite.Sweep700;
                    mFullDownlinkForm.PresetFormCheckBox850 = gRFEOnSite.Sweep850;
                    mFullDownlinkForm.PresetFormCheckBoxPCS = gRFEOnSite.SweepPCS;
                    mFullDownlinkForm.PresetFormCheckBoxAWS = gRFEOnSite.SweepAWS;

                    mFullDownlinkForm.StartPosition = FormStartPosition.CenterParent;

                    mFullDownlinkForm.ShowDialog();

                    gRFEOnSite.PresetActive = mFullDownlinkForm.Selected;

                    if (gRFEOnSite.PresetActive)
                    {
                        gRFEOnSite.Sweep700 = mFullDownlinkForm.PresetFormCheckBox700;
                        gRFEOnSite.Sweep850 = mFullDownlinkForm.PresetFormCheckBox850;
                        gRFEOnSite.SweepPCS = mFullDownlinkForm.PresetFormCheckBoxPCS;
                        gRFEOnSite.SweepAWS = mFullDownlinkForm.PresetFormCheckBoxAWS;
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

            bStatus = Double.TryParse(TextBoxStopFrequency.Text, out start);
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

            if (CheckBoxSaveCsvFiles.Checked && CheckBoxAutoIncrement.Checked && !gRFEOnSite.PresetActive)
            {
                if (NumericUpDownLocation.Value > 1)
                {
                    NumericUpDownLocation.Value -= 1;
                }
            }

            gRFEOnSite.CancelActive = true;

            ButtonStartSweeps.Enabled = true;
            ButtonCancelSweeps.Enabled = false;

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
            if (CheckBoxAutoIncrement.Checked)
            {
                NumericUpDownLocation.Enabled = true;
            }
            else
            {
                NumericUpDownLocation.Enabled = false;
            }

            RefreshUI();
        }

        private void TextBoxCollectionSite_TextChanged(object sender, EventArgs e)
        {
            NumericUpDownLocation.Value = 1;

            RefreshUI();
        }

        private void TextBoxClient_TextChanged(object sender, EventArgs e)
        {
            NumericUpDownLocation.Value = 1;
            RefreshUI();
        }

        private void NumericUpDownLocation_ValueChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void TextBoxAutoLabel_TextChanged(object sender, EventArgs e)
        {
            LabelCsvDirectory.Text = "Desktop\\SurveyData\\" + TextBoxClient.Text + "\\" + TextBoxCollectionLocation.Text + "\\" + TextBoxAutoLabel.Text + NumericUpDownAutoText.Value.ToString() + " " + TextBoxCollectionSite.Text + "-" + NumericUpDownLocation.Value.ToString();
            NumericUpDownLocation.Value = 1;
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


            if (RadioButtonAutoTextDecrement.Checked == true)
            {
                if (NumericUpDownAutoText.Value == 1)
                {
                    DialogResult diag = MessageBox.Show(@"Trying to decrement Floor while Floor value is '1'. Enter different Floor or ID text or change the count such that it's value stays greater than one.", "Floor/ID Error", MessageBoxButtons.OK);
                    return;
                }

                NumericUpDownAutoText.Value = NumericUpDownAutoText.Value - 1;
            }
            else
            {
                NumericUpDownAutoText.Value = NumericUpDownAutoText.Value + 1;
            }

            RefreshUI();

        }

        private void NumericUpDownAutoText_ValueChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            if (ButtonFloorId.Text == "Next")
            {
                LabelCsvDirectory.Text =
                    "Desktop\\SurveyData\\" +
                    TextBoxClient.Text +
                    "\\" +
                    TextBoxCollectionLocation.Text +
                    "\\" +
                    TextBoxAutoLabel.Text +
                    NumericUpDownAutoText.Value.ToString() +
                    " " +
                    TextBoxCollectionSite.Text +
                    "-" +
                    NumericUpDownLocation.Value.ToString();
            }
            else
            {
                LabelCsvDirectory.Text =
                    "Desktop\\SurveyData\\" +
                    TextBoxClient.Text +
                    "\\" +
                    TextBoxCollectionLocation.Text +
                    "\\" +
                    TextBoxCollectionSite.Text +
                    "-" +
                    NumericUpDownLocation.Value.ToString();
            }
        }

        VideoCapture mCapture;
        Mat mMat;

        private void ButtonCaptureImageOmni_Click(object sender, EventArgs e)
        {
            Mat matTemp = new Mat();

            matTemp = mCapture.QueryFrame();

            ///PictureBox.SizeMode = PictureBoxSizeMode.Normal;

            matTemp.Bitmap.Save(@"test1.png", ImageFormat.Png);
            ////PictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            //matTemp = null;
        }

        private void ProcessVideoFrame(object sender, EventArgs e)
        {
            try
            {
                mMat = mCapture.QueryFrame();

                PictureBox.Image = mMat.Bitmap;
            }
            catch(Exception ex)
            {

            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControlMain.SelectedTab.Text == "Location Camera")//your specific tabname
            {
                if (mCapture == null)
                {
                    mCapture = new VideoCapture();
                }

                if (mMat == null)
                {
                    mMat = new Mat();
                }

                Application.Idle += ProcessVideoFrame;
                PictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else
            {
                mCapture = null;
                mMat = null;
                Application.Idle -= ProcessVideoFrame;
            }
        }
    }
}
