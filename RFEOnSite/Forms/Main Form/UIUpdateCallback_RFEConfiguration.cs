using System;
using System.Windows.Forms;
using static RFEOnSite.RFExplorer;

namespace RFEOnSite
{
    public partial class MainForm
    {
        public void UIUpdateCallback_RFEConfiguration(RFEConfiguration fromSerialThread)
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
                    //ButtonStartSweeps.Enabled = true;
                    Button_CurrentConfiguration_SetRfeConfiguration.Enabled = true;
                }

                GroupBox_SweepControl.Enabled = true;
                RadioButton_Connection_SetSpectrumAnalyzer.Checked = true;
                RadioButton_Connection_SetSignalGenerator.Checked = false;
                RadioButton_Connection_SetSignalGenerator.Enabled = false;


                gRFEOnSite.Chart.MinX = gRFEOnSite.StartFrequency;
                gRFEOnSite.Chart.MaxX = gRFEOnSite.StopFrequency;
                gRFEOnSite.Chart.Title = "Range: " + gRFEOnSite.Chart.MinX.ToString() + " to " + gRFEOnSite.Chart.MaxX + " MHz";
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

    }
}
