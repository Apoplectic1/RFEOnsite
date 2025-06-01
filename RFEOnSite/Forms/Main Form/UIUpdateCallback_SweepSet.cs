using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;

namespace RFEOnSite
{
    public partial class MainForm
    {
        public void UIUpdateCallback_SweepSet(List<string> sweepsFromExplorer)
        {
            // ***********************************************************************************
            // Updates UI with sweep data read from the physical RF Explorer worker thread.
            // fromSerialThread is constructed and populated by RFEConfiguration.cs
            // UIUpdateCallback_SweepSet gets called at the completion of the number of sweeps from the Explorer worker thread.
            // Thread mCapture is now false (set only in thread) stopping capture until set true. 
            // ***********************************************************************************

            // Copy Bytes to local list: gRFEOnSite.ExplorerSweepData
            // This List is available to both the Charts and CsvEXport classes and is an attempt a parallelism

            gRFEOnSite.ExplorerSweepData.Clear();
            for (int i = 0; i < sweepsFromExplorer.Count; i++)
            {
                gRFEOnSite.ExplorerSweepData.Add(sweepsFromExplorer[i]);
            }
            sweepsFromExplorer.Clear();

            gRFEOnSite.Chart.ClearSeries("All");
            gRFEOnSite.Chart.InitializeChart();


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
                        NumericUpDown_SweepControl_VariationSweeps.Text + " at " + gRFEOnSite.RadialDegrees.ToString("D3") + " .csv";
                else
                    TextBoxCsvFileName.Text = fileName + dateString + rangeString1 + rangeString2 + "-" +
                        NumericUpDown_SweepControl_VariationSweeps.Text + " at Omni.csv";

                gRFEOnSite.FileOps.Path = TextBoxCsvFileName.Text;
                gRFEOnSite.FileOps.ExportCsvFile(gRFEOnSite.StartFrequency, gRFEOnSite.StopFrequency, gRFEOnSite.FrequencyStepSize, gRFEOnSite.ExplorerSweepData);

                gRFEOnSite.FileOps.FileCounter++;
            }

            //*****************************************************
            // SETUP AND GET NEXT SWEEP
            //*****************************************************
            // Preset Mode
            // Automatically get, populate and set sweep start and stop frequency pairs and cycle through the list of them
            // The first pair is determnined and set from the "Capture" Clicked Event (method) on the UI.
            // This gets the 'next' values and then sweeps with them

            gRFEOnSite.CurrentSweepNumber = 1;

            // Upon entry, it skips PresetTable entries that have already been processed or ignored
            if (gRFEOnSite.PresetType == ePreset.eFullDownlink)
            {
                foreach (PresetTable pair in gRFEOnSite.PresetDownlinkTable.Skip(gRFEOnSite.PresetTableIndex))
                {
                    gRFEOnSite.StableSweep.Clear();
                    gRFEOnSite.Explorer.SweepCount = gRFEOnSite.Sweeps;
                    gRFEOnSite.Explorer.SweepValueStable = false;

                    gRFEOnSite.PresetTableIndex++; // Needs to be before the breaks to stay in step with foreach

                    // We found a table entry to Sweep: Program the RF Explorer
                    gRFEOnSite.Explorer.SendConfiguration(pair.SweepStart, pair.SweepStop);

                    Thread.Sleep(100);

                    TaskProgressBar.Maximum = gRFEOnSite.Sweeps;
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
                NumericUpDown_SweepControl_VariationSweeps.Enabled = true;

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
                NumericUpDown_SweepControl_VariationSweeps.Enabled = true;

                if (CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Checked && CheckBox_CSVFileStorage_SaveCsvFiles.Checked)
                    NumericUpDown_CSVFileStorage_MarkerNumber.Value += 1;

                TabControl_Main.Enabled = true;
                GroupBox_CSVFileStorage.Enabled = true;
                NumericUpDown_SweepControl_VariationSweeps.Enabled = true;

                Thread.Sleep(100);

                gRFEOnSite.Explorer.SweepCount = gRFEOnSite.Sweeps;

                TaskProgressBar.Maximum = gRFEOnSite.Sweeps;
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
                NumericUpDown_SweepControl_VariationSweeps.Enabled = true;

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
            NumericUpDown_SweepControl_UserSweeps.Enabled = true;
            NumericUpDown_SweepControl_VariationDb.Enabled = true;
            NumericUpDown_SweepControl_VariationSweeps.Enabled = true;

            SystemSounds.Hand.Play();
        }

    }
}
