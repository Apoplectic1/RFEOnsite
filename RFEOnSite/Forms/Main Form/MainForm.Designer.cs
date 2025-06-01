using System.Windows.Forms;

namespace RFEOnSite
{
    partial class MainForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Button_Connection_ConnectExplorer = new System.Windows.Forms.Button();
            this.Label_Connection_ComPortValue = new System.Windows.Forms.Label();
            this.CheckBoxRadialAzimuth = new System.Windows.Forms.CheckBox();
            this.Button_Connection_Documentation = new System.Windows.Forms.Button();
            this.RadioButton_Connection_SetSignalGenerator = new System.Windows.Forms.RadioButton();
            this.RadioButton_Connection_SetSpectrumAnalyzer = new System.Windows.Forms.RadioButton();
            this.Label_Connection_ModelID = new System.Windows.Forms.Label();
            this.Label_Connection_DeviceID = new System.Windows.Forms.Label();
            this.Label_Connection_FirmwareValue = new System.Windows.Forms.Label();
            this.Label_Connection_Firmware = new System.Windows.Forms.Label();
            this.Label_Connection_ModelIDValue = new System.Windows.Forms.Label();
            this.Label_Connection_DeviceIDValue = new System.Windows.Forms.Label();
            this.ButtonStartSweeps = new System.Windows.Forms.Button();
            this.Label_SweepControl_VariationVariation = new System.Windows.Forms.Label();
            this.NumericUpDown_SweepControl_VariationSweeps = new System.Windows.Forms.NumericUpDown();
            this.GroupBox_SweepControl = new System.Windows.Forms.GroupBox();
            this.Label_SweepControl_UserMaximum = new System.Windows.Forms.Label();
            this.Label_SweepControl_UserSweeps = new System.Windows.Forms.Label();
            this.NumericUpDown_SweepControl_UserSweeps = new System.Windows.Forms.NumericUpDown();
            this.Label_SweepControl_VariationSweeps = new System.Windows.Forms.Label();
            this.Label_SweepControl_Variation_DbOver = new System.Windows.Forms.Label();
            this.NumericUpDown_SweepControl_VariationDb = new System.Windows.Forms.NumericUpDown();
            this.LabelExecutingTask = new System.Windows.Forms.Label();
            this.LabelExecTask = new System.Windows.Forms.Label();
            this.ButtonCancelSweeps = new System.Windows.Forms.Button();
            this.LabelProgressWriteCsvFile = new System.Windows.Forms.Label();
            this.TaskProgressBar = new System.Windows.Forms.ProgressBar();
            this.TextBoxCsvFileName = new System.Windows.Forms.TextBox();
            this.CheckBox_CSVFileStorage_SaveCsvFiles = new System.Windows.Forms.CheckBox();
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale = new System.Windows.Forms.CheckBox();
            this.GroupBox_ReceivedSignalStrength = new System.Windows.Forms.GroupBox();
            this.PanelChart = new System.Windows.Forms.Panel();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TextBox_CSVFileStorage_CollectionLocationDescription = new System.Windows.Forms.TextBox();
            this.LabelRBW = new System.Windows.Forms.Label();
            this.Button_CurrentConfiguration_SetRfeConfiguration = new System.Windows.Forms.Button();
            this.TextBoxRBW = new System.Windows.Forms.TextBox();
            this.ComboBox_CurrentConfiguration_Preset = new System.Windows.Forms.ComboBox();
            this.Button_CurrentConfiguration_GetRfeConfiguration = new System.Windows.Forms.Button();
            this.LabelStopFrequency = new System.Windows.Forms.Label();
            this.Button_CSVFileStorage_ResetAllFields = new System.Windows.Forms.Button();
            this.Button_CSVFileStorage_CollectionFloor_Enable = new System.Windows.Forms.Button();
            this.RadioButton_CSVFileStorage_FloorIncrement = new System.Windows.Forms.RadioButton();
            this.RadioButton_CSVFileStorage_FloorDecrement = new System.Windows.Forms.RadioButton();
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber = new System.Windows.Forms.CheckBox();
            this.LabelStartFrequency = new System.Windows.Forms.Label();
            this.LabelFrequencyStep = new System.Windows.Forms.Label();
            this.TabControl_Main = new System.Windows.Forms.TabControl();
            this.TabControl_Main_Connection = new System.Windows.Forms.TabPage();
            this.Label_Connection_ComPortText = new System.Windows.Forms.Label();
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting = new System.Windows.Forms.GroupBox();
            this.Button_FirmwareUpdate = new System.Windows.Forms.Button();
            this.Button_Connection_UsbTroubleShooting = new System.Windows.Forms.Button();
            this.Button_Connection_USBDriverDownload = new System.Windows.Forms.Button();
            this.TabControl_Main_OmniDirectional = new System.Windows.Forms.TabPage();
            this.GroupBox_OmniDirectional_CurrentConfiguration = new System.Windows.Forms.GroupBox();
            this.CheckBox_Band_WCS = new System.Windows.Forms.CheckBox();
            this.CheckBox_Band_AWS = new System.Windows.Forms.CheckBox();
            this.CheckBox_Band_CEL = new System.Windows.Forms.CheckBox();
            this.CheckBox_Band_700 = new System.Windows.Forms.CheckBox();
            this.CheckBox_Band_PCS = new System.Windows.Forms.CheckBox();
            this.CheckBox_Band_600 = new System.Windows.Forms.CheckBox();
            this.LabelRBWUnit = new System.Windows.Forms.Label();
            this.Label_CurrentConfiguration_Presets = new System.Windows.Forms.Label();
            this.Label_CurrentConfiguration_RightAntennaGaindB = new System.Windows.Forms.Label();
            this.TextBox_CurrentConfiguration_RightAntennaGain = new System.Windows.Forms.TextBox();
            this.Label_CurrentConfiguration_RightAntennaGain = new System.Windows.Forms.Label();
            this.Label_CurrentConfiguration_LeftAntennaGaindB = new System.Windows.Forms.Label();
            this.TextBox_CurrentConfiguration_LeftAntennaGain = new System.Windows.Forms.TextBox();
            this.Label_CurrentConfiguration_LeftAntennaGain = new System.Windows.Forms.Label();
            this.TextBox_CurrentConfiguration_StepFrequency = new System.Windows.Forms.TextBox();
            this.LabelStopFrequencyUnit = new System.Windows.Forms.Label();
            this.LabelStartFrequencyUnit = new System.Windows.Forms.Label();
            this.LabelFrequencyStepUnit = new System.Windows.Forms.Label();
            this.TextBox_CurrentConfiguration_StartFrequency = new System.Windows.Forms.TextBox();
            this.TextBox_CurrentConfiguration_StopFrequency = new System.Windows.Forms.TextBox();
            this.TabControl_Main_Radial = new System.Windows.Forms.TabPage();
            this.LabelRadialAzimuth = new System.Windows.Forms.Label();
            this.LabelTrueNorthText = new System.Windows.Forms.Label();
            this.NumericUpDownRadialAzimuth = new System.Windows.Forms.NumericUpDown();
            this.TabControl_Main_LocationCamera = new System.Windows.Forms.TabPage();
            this.Label_LocationCamera_Marker = new System.Windows.Forms.Label();
            this.Label_LocationCamera_Floor = new System.Windows.Forms.Label();
            this.Button_LocationCamera_PauseResume = new System.Windows.Forms.Button();
            this.Button_LocationCamera_CaptureFrame = new System.Windows.Forms.Button();
            this.PictureBox_LocationCamera = new System.Windows.Forms.PictureBox();
            this.TabControl_Main_Calibration = new System.Windows.Forms.TabPage();
            this.TextBoxCalibrationPointsPerSweepInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxCalibrationSourceDbm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonCalibrationStart = new System.Windows.Forms.Button();
            this.Button_CSVFileStorage_Next = new System.Windows.Forms.Button();
            this.Button_CSVFileStorage_ResetFloorAndMarkers = new System.Windows.Forms.Button();
            this.TextBox_CSVFileStorage_Client = new System.Windows.Forms.TextBox();
            this.GroupBox_CSVFileStorage = new System.Windows.Forms.GroupBox();
            this.GroupBoxCsvInformation = new System.Windows.Forms.GroupBox();
            this.GroupBox_CSVFileStorage_AutoNext = new System.Windows.Forms.GroupBox();
            this.GroupBox_CSVFileStorage_ClientInformation = new System.Windows.Forms.GroupBox();
            this.GroupBox_CSVFileStorage_CollectionFloor = new System.Windows.Forms.GroupBox();
            this.NumericUpDown_CSVFileStorage_FloorNumber = new System.Windows.Forms.NumericUpDown();
            this.TextBox_CSVFileStorage_CollectionFloorName = new System.Windows.Forms.TextBox();
            this.GroupBox_CSVFileStorage_CollectionMarker = new System.Windows.Forms.GroupBox();
            this.TextBox_CSVFileStorage_CollectionMarkerName = new System.Windows.Forms.TextBox();
            this.NumericUpDown_CSVFileStorage_MarkerNumber = new System.Windows.Forms.NumericUpDown();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.MenuStripMainForm = new System.Windows.Forms.MenuStrip();
            this.MenuStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripMenuItemPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.force2400BaudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripStatusMainForm = new System.Windows.Forms.StatusStrip();
            this.StripStatusLabelPreset = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatusLabelDivision1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatusLabelCsvDirectory = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_SweepControl_VariationSweeps)).BeginInit();
            this.GroupBox_SweepControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_SweepControl_UserSweeps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_SweepControl_VariationDb)).BeginInit();
            this.GroupBox_ReceivedSignalStrength.SuspendLayout();
            this.TabControl_Main.SuspendLayout();
            this.TabControl_Main_Connection.SuspendLayout();
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.SuspendLayout();
            this.TabControl_Main_OmniDirectional.SuspendLayout();
            this.GroupBox_OmniDirectional_CurrentConfiguration.SuspendLayout();
            this.TabControl_Main_Radial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRadialAzimuth)).BeginInit();
            this.TabControl_Main_LocationCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_LocationCamera)).BeginInit();
            this.TabControl_Main_Calibration.SuspendLayout();
            this.GroupBox_CSVFileStorage.SuspendLayout();
            this.GroupBoxCsvInformation.SuspendLayout();
            this.GroupBox_CSVFileStorage_AutoNext.SuspendLayout();
            this.GroupBox_CSVFileStorage_ClientInformation.SuspendLayout();
            this.GroupBox_CSVFileStorage_CollectionFloor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CSVFileStorage_FloorNumber)).BeginInit();
            this.GroupBox_CSVFileStorage_CollectionMarker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CSVFileStorage_MarkerNumber)).BeginInit();
            this.MenuStripMainForm.SuspendLayout();
            this.StripStatusMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Connection_ConnectExplorer
            // 
            this.Button_Connection_ConnectExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(197)))), ((int)(((byte)(202)))), ((int)(((byte)(31)))));
            this.Button_Connection_ConnectExplorer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Button_Connection_ConnectExplorer.FlatAppearance.BorderSize = 5;
            this.Button_Connection_ConnectExplorer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Button_Connection_ConnectExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Button_Connection_ConnectExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Connection_ConnectExplorer.Location = new System.Drawing.Point(81, 36);
            this.Button_Connection_ConnectExplorer.Name = "Button_Connection_ConnectExplorer";
            this.Button_Connection_ConnectExplorer.Size = new System.Drawing.Size(155, 73);
            this.Button_Connection_ConnectExplorer.TabIndex = 0;
            this.Button_Connection_ConnectExplorer.Text = "Connect RF Explorer";
            this.ToolTip1.SetToolTip(this.Button_Connection_ConnectExplorer, "Connects a USB RF Explorer/Generator to this application. Close the application t" +
        "o disconnect.");
            this.Button_Connection_ConnectExplorer.UseVisualStyleBackColor = false;
            this.Button_Connection_ConnectExplorer.Click += new System.EventHandler(this.ButtonFindPorts_Click);
            // 
            // Label_Connection_ComPortValue
            // 
            this.Label_Connection_ComPortValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_Connection_ComPortValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Connection_ComPortValue.Location = new System.Drawing.Point(365, 33);
            this.Label_Connection_ComPortValue.Name = "Label_Connection_ComPortValue";
            this.Label_Connection_ComPortValue.Size = new System.Drawing.Size(124, 22);
            this.Label_Connection_ComPortValue.TabIndex = 1;
            this.Label_Connection_ComPortValue.Text = "Not Connected";
            // 
            // CheckBoxRadialAzimuth
            // 
            this.CheckBoxRadialAzimuth.AutoSize = true;
            this.CheckBoxRadialAzimuth.Enabled = false;
            this.CheckBoxRadialAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxRadialAzimuth.Location = new System.Drawing.Point(161, 45);
            this.CheckBoxRadialAzimuth.Name = "CheckBoxRadialAzimuth";
            this.CheckBoxRadialAzimuth.Size = new System.Drawing.Size(202, 35);
            this.CheckBoxRadialAzimuth.TabIndex = 28;
            this.CheckBoxRadialAzimuth.Text = "Radial Survey";
            this.ToolTip1.SetToolTip(this.CheckBoxRadialAzimuth, resources.GetString("CheckBoxRadialAzimuth.ToolTip"));
            this.CheckBoxRadialAzimuth.UseVisualStyleBackColor = true;
            this.CheckBoxRadialAzimuth.CheckedChanged += new System.EventHandler(this.CheckBoxRadial_CheckedChanged);
            // 
            // Button_Connection_Documentation
            // 
            this.Button_Connection_Documentation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Connection_Documentation.Location = new System.Drawing.Point(35, 29);
            this.Button_Connection_Documentation.Name = "Button_Connection_Documentation";
            this.Button_Connection_Documentation.Size = new System.Drawing.Size(179, 51);
            this.Button_Connection_Documentation.TabIndex = 16;
            this.Button_Connection_Documentation.Text = "RF Explorer Documentation";
            this.Button_Connection_Documentation.UseVisualStyleBackColor = true;
            this.Button_Connection_Documentation.Click += new System.EventHandler(this.ButtonDocumentation_Click);
            // 
            // RadioButton_Connection_SetSignalGenerator
            // 
            this.RadioButton_Connection_SetSignalGenerator.AutoSize = true;
            this.RadioButton_Connection_SetSignalGenerator.BackColor = System.Drawing.Color.Transparent;
            this.RadioButton_Connection_SetSignalGenerator.Location = new System.Drawing.Point(247, 56);
            this.RadioButton_Connection_SetSignalGenerator.Name = "RadioButton_Connection_SetSignalGenerator";
            this.RadioButton_Connection_SetSignalGenerator.Size = new System.Drawing.Size(148, 24);
            this.RadioButton_Connection_SetSignalGenerator.TabIndex = 15;
            this.RadioButton_Connection_SetSignalGenerator.Text = "Signal Generator";
            this.RadioButton_Connection_SetSignalGenerator.UseVisualStyleBackColor = false;
            this.RadioButton_Connection_SetSignalGenerator.CheckedChanged += new System.EventHandler(this.RadioButtonGenerator_CheckedChanged);
            // 
            // RadioButton_Connection_SetSpectrumAnalyzer
            // 
            this.RadioButton_Connection_SetSpectrumAnalyzer.AutoSize = true;
            this.RadioButton_Connection_SetSpectrumAnalyzer.BackColor = System.Drawing.Color.Transparent;
            this.RadioButton_Connection_SetSpectrumAnalyzer.Checked = true;
            this.RadioButton_Connection_SetSpectrumAnalyzer.Location = new System.Drawing.Point(247, 29);
            this.RadioButton_Connection_SetSpectrumAnalyzer.Name = "RadioButton_Connection_SetSpectrumAnalyzer";
            this.RadioButton_Connection_SetSpectrumAnalyzer.Size = new System.Drawing.Size(161, 24);
            this.RadioButton_Connection_SetSpectrumAnalyzer.TabIndex = 14;
            this.RadioButton_Connection_SetSpectrumAnalyzer.TabStop = true;
            this.RadioButton_Connection_SetSpectrumAnalyzer.Text = "Spectrum Analyzer";
            this.RadioButton_Connection_SetSpectrumAnalyzer.UseVisualStyleBackColor = false;
            this.RadioButton_Connection_SetSpectrumAnalyzer.CheckedChanged += new System.EventHandler(this.RadioButtonAnalyzer_CheckedChanged);
            // 
            // Label_Connection_ModelID
            // 
            this.Label_Connection_ModelID.AutoSize = true;
            this.Label_Connection_ModelID.BackColor = System.Drawing.Color.Transparent;
            this.Label_Connection_ModelID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Connection_ModelID.Location = new System.Drawing.Point(301, 91);
            this.Label_Connection_ModelID.Name = "Label_Connection_ModelID";
            this.Label_Connection_ModelID.Size = new System.Drawing.Size(56, 20);
            this.Label_Connection_ModelID.TabIndex = 13;
            this.Label_Connection_ModelID.Text = "Model:";
            this.ToolTip1.SetToolTip(this.Label_Connection_ModelID, "This RF Explorer Model ID.");
            // 
            // Label_Connection_DeviceID
            // 
            this.Label_Connection_DeviceID.AutoSize = true;
            this.Label_Connection_DeviceID.BackColor = System.Drawing.Color.Transparent;
            this.Label_Connection_DeviceID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Connection_DeviceID.Location = new System.Drawing.Point(298, 72);
            this.Label_Connection_DeviceID.Name = "Label_Connection_DeviceID";
            this.Label_Connection_DeviceID.Size = new System.Drawing.Size(61, 20);
            this.Label_Connection_DeviceID.TabIndex = 12;
            this.Label_Connection_DeviceID.Text = "Device:";
            this.ToolTip1.SetToolTip(this.Label_Connection_DeviceID, "This RF Explorer Device ID.");
            // 
            // Label_Connection_FirmwareValue
            // 
            this.Label_Connection_FirmwareValue.AutoSize = true;
            this.Label_Connection_FirmwareValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_Connection_FirmwareValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Connection_FirmwareValue.Location = new System.Drawing.Point(365, 53);
            this.Label_Connection_FirmwareValue.Name = "Label_Connection_FirmwareValue";
            this.Label_Connection_FirmwareValue.Size = new System.Drawing.Size(35, 20);
            this.Label_Connection_FirmwareValue.TabIndex = 5;
            this.Label_Connection_FirmwareValue.Text = "N/A";
            this.Label_Connection_FirmwareValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Connection_Firmware
            // 
            this.Label_Connection_Firmware.AutoSize = true;
            this.Label_Connection_Firmware.BackColor = System.Drawing.Color.Transparent;
            this.Label_Connection_Firmware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Connection_Firmware.Location = new System.Drawing.Point(279, 53);
            this.Label_Connection_Firmware.Name = "Label_Connection_Firmware";
            this.Label_Connection_Firmware.Size = new System.Drawing.Size(78, 20);
            this.Label_Connection_Firmware.TabIndex = 4;
            this.Label_Connection_Firmware.Text = "Firmware:";
            this.ToolTip1.SetToolTip(this.Label_Connection_Firmware, "This RF Explorer firmware version.");
            // 
            // Label_Connection_ModelIDValue
            // 
            this.Label_Connection_ModelIDValue.AutoSize = true;
            this.Label_Connection_ModelIDValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_Connection_ModelIDValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Connection_ModelIDValue.Location = new System.Drawing.Point(365, 91);
            this.Label_Connection_ModelIDValue.Name = "Label_Connection_ModelIDValue";
            this.Label_Connection_ModelIDValue.Size = new System.Drawing.Size(35, 20);
            this.Label_Connection_ModelIDValue.TabIndex = 3;
            this.Label_Connection_ModelIDValue.Text = "N/A";
            // 
            // Label_Connection_DeviceIDValue
            // 
            this.Label_Connection_DeviceIDValue.AutoSize = true;
            this.Label_Connection_DeviceIDValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_Connection_DeviceIDValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Connection_DeviceIDValue.Location = new System.Drawing.Point(365, 72);
            this.Label_Connection_DeviceIDValue.Name = "Label_Connection_DeviceIDValue";
            this.Label_Connection_DeviceIDValue.Size = new System.Drawing.Size(35, 20);
            this.Label_Connection_DeviceIDValue.TabIndex = 2;
            this.Label_Connection_DeviceIDValue.Text = "N/A";
            // 
            // ButtonStartSweeps
            // 
            this.ButtonStartSweeps.BackColor = System.Drawing.Color.DarkKhaki;
            this.ButtonStartSweeps.Enabled = false;
            this.ButtonStartSweeps.FlatAppearance.BorderSize = 3;
            this.ButtonStartSweeps.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen;
            this.ButtonStartSweeps.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonStartSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStartSweeps.Location = new System.Drawing.Point(26, 95);
            this.ButtonStartSweeps.Name = "ButtonStartSweeps";
            this.ButtonStartSweeps.Size = new System.Drawing.Size(114, 49);
            this.ButtonStartSweeps.TabIndex = 13;
            this.ButtonStartSweeps.Text = "Capture";
            this.ToolTip1.SetToolTip(this.ButtonStartSweeps, resources.GetString("ButtonStartSweeps.ToolTip"));
            this.ButtonStartSweeps.UseVisualStyleBackColor = false;
            this.ButtonStartSweeps.Click += new System.EventHandler(this.ButtonStartSweeps_Click);
            // 
            // Label_SweepControl_VariationVariation
            // 
            this.Label_SweepControl_VariationVariation.AutoSize = true;
            this.Label_SweepControl_VariationVariation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SweepControl_VariationVariation.Location = new System.Drawing.Point(70, 54);
            this.Label_SweepControl_VariationVariation.Name = "Label_SweepControl_VariationVariation";
            this.Label_SweepControl_VariationVariation.Size = new System.Drawing.Size(127, 24);
            this.Label_SweepControl_VariationVariation.TabIndex = 14;
            this.Label_SweepControl_VariationVariation.Text = "Stable Data is:";
            this.ToolTip1.SetToolTip(this.Label_SweepControl_VariationVariation, "Mean Absolute Difference ");
            // 
            // NumericUpDown_SweepControl_VariationSweeps
            // 
            this.NumericUpDown_SweepControl_VariationSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_SweepControl_VariationSweeps.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_VariationSweeps.Location = new System.Drawing.Point(340, 52);
            this.NumericUpDown_SweepControl_VariationSweeps.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_VariationSweeps.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_VariationSweeps.Name = "NumericUpDown_SweepControl_VariationSweeps";
            this.NumericUpDown_SweepControl_VariationSweeps.Size = new System.Drawing.Size(76, 29);
            this.NumericUpDown_SweepControl_VariationSweeps.TabIndex = 15;
            this.NumericUpDown_SweepControl_VariationSweeps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDown_SweepControl_VariationSweeps.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_VariationSweeps.ValueChanged += new System.EventHandler(this.NumericUpDown_SweepControl_VariationSweeps_ValueChanged);
            // 
            // GroupBox_SweepControl
            // 
            this.GroupBox_SweepControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox_SweepControl.Controls.Add(this.Label_SweepControl_UserMaximum);
            this.GroupBox_SweepControl.Controls.Add(this.Label_SweepControl_UserSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.NumericUpDown_SweepControl_UserSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.Label_SweepControl_VariationSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.Label_SweepControl_Variation_DbOver);
            this.GroupBox_SweepControl.Controls.Add(this.NumericUpDown_SweepControl_VariationDb);
            this.GroupBox_SweepControl.Controls.Add(this.LabelExecutingTask);
            this.GroupBox_SweepControl.Controls.Add(this.LabelExecTask);
            this.GroupBox_SweepControl.Controls.Add(this.ButtonCancelSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.LabelProgressWriteCsvFile);
            this.GroupBox_SweepControl.Controls.Add(this.TaskProgressBar);
            this.GroupBox_SweepControl.Controls.Add(this.Label_SweepControl_VariationVariation);
            this.GroupBox_SweepControl.Controls.Add(this.ButtonStartSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.NumericUpDown_SweepControl_VariationSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.TextBoxCsvFileName);
            this.GroupBox_SweepControl.Enabled = false;
            this.GroupBox_SweepControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_SweepControl.Location = new System.Drawing.Point(550, 457);
            this.GroupBox_SweepControl.Name = "GroupBox_SweepControl";
            this.GroupBox_SweepControl.Size = new System.Drawing.Size(587, 248);
            this.GroupBox_SweepControl.TabIndex = 16;
            this.GroupBox_SweepControl.TabStop = false;
            this.GroupBox_SweepControl.Text = "Sweep Control";
            // 
            // Label_SweepControl_UserMaximum
            // 
            this.Label_SweepControl_UserMaximum.AutoSize = true;
            this.Label_SweepControl_UserMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SweepControl_UserMaximum.Location = new System.Drawing.Point(114, 21);
            this.Label_SweepControl_UserMaximum.Name = "Label_SweepControl_UserMaximum";
            this.Label_SweepControl_UserMaximum.Size = new System.Drawing.Size(153, 25);
            this.Label_SweepControl_UserMaximum.TabIndex = 30;
            this.Label_SweepControl_UserMaximum.Text = "Never Exceed:";
            this.ToolTip1.SetToolTip(this.Label_SweepControl_UserMaximum, "Fill each FFT bin with the selected number of samples.");
            // 
            // Label_SweepControl_UserSweeps
            // 
            this.Label_SweepControl_UserSweeps.AutoSize = true;
            this.Label_SweepControl_UserSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SweepControl_UserSweeps.Location = new System.Drawing.Point(373, 21);
            this.Label_SweepControl_UserSweeps.Name = "Label_SweepControl_UserSweeps";
            this.Label_SweepControl_UserSweeps.Size = new System.Drawing.Size(88, 25);
            this.Label_SweepControl_UserSweeps.TabIndex = 29;
            this.Label_SweepControl_UserSweeps.Text = "Sweeps";
            this.ToolTip1.SetToolTip(this.Label_SweepControl_UserSweeps, "Fill each FFT bin with the selected number of samples.");
            // 
            // NumericUpDown_SweepControl_UserSweeps
            // 
            this.NumericUpDown_SweepControl_UserSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_SweepControl_UserSweeps.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_UserSweeps.Location = new System.Drawing.Point(268, 18);
            this.NumericUpDown_SweepControl_UserSweeps.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_UserSweeps.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_UserSweeps.Name = "NumericUpDown_SweepControl_UserSweeps";
            this.NumericUpDown_SweepControl_UserSweeps.Size = new System.Drawing.Size(100, 31);
            this.NumericUpDown_SweepControl_UserSweeps.TabIndex = 28;
            this.NumericUpDown_SweepControl_UserSweeps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDown_SweepControl_UserSweeps.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_UserSweeps.ValueChanged += new System.EventHandler(this.NumericUpDown_SweepControl_UserSweeps_ValueChanged);
            // 
            // Label_SweepControl_VariationSweeps
            // 
            this.Label_SweepControl_VariationSweeps.AutoSize = true;
            this.Label_SweepControl_VariationSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SweepControl_VariationSweeps.Location = new System.Drawing.Point(418, 54);
            this.Label_SweepControl_VariationSweeps.Name = "Label_SweepControl_VariationSweeps";
            this.Label_SweepControl_VariationSweeps.Size = new System.Drawing.Size(78, 24);
            this.Label_SweepControl_VariationSweeps.TabIndex = 23;
            this.Label_SweepControl_VariationSweeps.Text = "Sweeps";
            this.ToolTip1.SetToolTip(this.Label_SweepControl_VariationSweeps, "Fill each FFT bin with the selected number of samples.");
            // 
            // Label_SweepControl_Variation_DbOver
            // 
            this.Label_SweepControl_Variation_DbOver.AutoSize = true;
            this.Label_SweepControl_Variation_DbOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SweepControl_Variation_DbOver.Location = new System.Drawing.Point(265, 54);
            this.Label_SweepControl_Variation_DbOver.Name = "Label_SweepControl_Variation_DbOver";
            this.Label_SweepControl_Variation_DbOver.Size = new System.Drawing.Size(75, 24);
            this.Label_SweepControl_Variation_DbOver.TabIndex = 22;
            this.Label_SweepControl_Variation_DbOver.Text = "dB over";
            this.ToolTip1.SetToolTip(this.Label_SweepControl_Variation_DbOver, "Fill each FFT bin with the selected number of samples.");
            // 
            // NumericUpDown_SweepControl_VariationDb
            // 
            this.NumericUpDown_SweepControl_VariationDb.DecimalPlaces = 2;
            this.NumericUpDown_SweepControl_VariationDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_SweepControl_VariationDb.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NumericUpDown_SweepControl_VariationDb.Location = new System.Drawing.Point(196, 52);
            this.NumericUpDown_SweepControl_VariationDb.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_SweepControl_VariationDb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NumericUpDown_SweepControl_VariationDb.Name = "NumericUpDown_SweepControl_VariationDb";
            this.NumericUpDown_SweepControl_VariationDb.Size = new System.Drawing.Size(69, 29);
            this.NumericUpDown_SweepControl_VariationDb.TabIndex = 21;
            this.NumericUpDown_SweepControl_VariationDb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDown_SweepControl_VariationDb.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericUpDown_SweepControl_VariationDb.ValueChanged += new System.EventHandler(this.NumericUpDown_SweepControl_VariationDb_ValueChanged);
            // 
            // LabelExecutingTask
            // 
            this.LabelExecutingTask.AutoSize = true;
            this.LabelExecutingTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelExecutingTask.Location = new System.Drawing.Point(441, 109);
            this.LabelExecutingTask.Name = "LabelExecutingTask";
            this.LabelExecutingTask.Size = new System.Drawing.Size(39, 20);
            this.LabelExecutingTask.TabIndex = 20;
            this.LabelExecutingTask.Text = "Idle";
            this.LabelExecutingTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelExecTask
            // 
            this.LabelExecTask.AutoSize = true;
            this.LabelExecTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelExecTask.Location = new System.Drawing.Point(319, 109);
            this.LabelExecTask.Name = "LabelExecTask";
            this.LabelExecTask.Size = new System.Drawing.Size(121, 20);
            this.LabelExecTask.TabIndex = 19;
            this.LabelExecTask.Text = "Executing Task:";
            // 
            // ButtonCancelSweeps
            // 
            this.ButtonCancelSweeps.BackColor = System.Drawing.Color.DarkKhaki;
            this.ButtonCancelSweeps.Enabled = false;
            this.ButtonCancelSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancelSweeps.Location = new System.Drawing.Point(161, 95);
            this.ButtonCancelSweeps.Name = "ButtonCancelSweeps";
            this.ButtonCancelSweeps.Size = new System.Drawing.Size(114, 49);
            this.ButtonCancelSweeps.TabIndex = 18;
            this.ButtonCancelSweeps.Text = "Cancel";
            this.ToolTip1.SetToolTip(this.ButtonCancelSweeps, "Stops the current data collection and stores the any data collected (if enabled w" +
        "ith \'Save  Collected CSV Files\'). ");
            this.ButtonCancelSweeps.UseVisualStyleBackColor = false;
            this.ButtonCancelSweeps.Click += new System.EventHandler(this.ButtonCancelSweeps_Click);
            // 
            // LabelProgressWriteCsvFile
            // 
            this.LabelProgressWriteCsvFile.AutoSize = true;
            this.LabelProgressWriteCsvFile.Location = new System.Drawing.Point(6, 194);
            this.LabelProgressWriteCsvFile.Name = "LabelProgressWriteCsvFile";
            this.LabelProgressWriteCsvFile.Size = new System.Drawing.Size(84, 20);
            this.LabelProgressWriteCsvFile.TabIndex = 17;
            this.LabelProgressWriteCsvFile.Text = "CSV File:";
            // 
            // TaskProgressBar
            // 
            this.TaskProgressBar.Location = new System.Drawing.Point(6, 158);
            this.TaskProgressBar.Name = "TaskProgressBar";
            this.TaskProgressBar.Size = new System.Drawing.Size(575, 23);
            this.TaskProgressBar.TabIndex = 16;
            // 
            // TextBoxCsvFileName
            // 
            this.TextBoxCsvFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCsvFileName.Location = new System.Drawing.Point(6, 218);
            this.TextBoxCsvFileName.Name = "TextBoxCsvFileName";
            this.TextBoxCsvFileName.ReadOnly = true;
            this.TextBoxCsvFileName.Size = new System.Drawing.Size(575, 20);
            this.TextBoxCsvFileName.TabIndex = 1;
            // 
            // CheckBox_CSVFileStorage_SaveCsvFiles
            // 
            this.CheckBox_CSVFileStorage_SaveCsvFiles.AutoSize = true;
            this.CheckBox_CSVFileStorage_SaveCsvFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox_CSVFileStorage_SaveCsvFiles.Location = new System.Drawing.Point(9, 27);
            this.CheckBox_CSVFileStorage_SaveCsvFiles.Name = "CheckBox_CSVFileStorage_SaveCsvFiles";
            this.CheckBox_CSVFileStorage_SaveCsvFiles.Size = new System.Drawing.Size(265, 24);
            this.CheckBox_CSVFileStorage_SaveCsvFiles.TabIndex = 17;
            this.CheckBox_CSVFileStorage_SaveCsvFiles.Text = "Save Collected Data to CSV Files";
            this.ToolTip1.SetToolTip(this.CheckBox_CSVFileStorage_SaveCsvFiles, "Creates a \'RFEOnSite Data\' directory on the user\'s Desktop to store collection CS" +
        "V files.");
            this.CheckBox_CSVFileStorage_SaveCsvFiles.UseVisualStyleBackColor = true;
            this.CheckBox_CSVFileStorage_SaveCsvFiles.CheckedChanged += new System.EventHandler(this.CheckBoxSaveCsvFiles_CheckedChanged);
            // 
            // CheckBox_ReceivedSignalStrength_ChartAutoScale
            // 
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.AutoSize = true;
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.Checked = true;
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.Location = new System.Drawing.Point(17, 390);
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.Name = "CheckBox_ReceivedSignalStrength_ChartAutoScale";
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.Size = new System.Drawing.Size(106, 24);
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.TabIndex = 1;
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.Text = "Auto Scale";
            this.ToolTip1.SetToolTip(this.CheckBox_ReceivedSignalStrength_ChartAutoScale, "When checked, scale the plot data to fill the graph area. Unchecked will only plo" +
        "t captured data points between -50 dBm and -110 dBm.");
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.UseVisualStyleBackColor = false;
            this.CheckBox_ReceivedSignalStrength_ChartAutoScale.CheckedChanged += new System.EventHandler(this.CheckBoxChartAutoScale_CheckedChanged);
            // 
            // GroupBox_ReceivedSignalStrength
            // 
            this.GroupBox_ReceivedSignalStrength.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox_ReceivedSignalStrength.Controls.Add(this.CheckBox_ReceivedSignalStrength_ChartAutoScale);
            this.GroupBox_ReceivedSignalStrength.Controls.Add(this.PanelChart);
            this.GroupBox_ReceivedSignalStrength.Enabled = false;
            this.GroupBox_ReceivedSignalStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_ReceivedSignalStrength.Location = new System.Drawing.Point(550, 27);
            this.GroupBox_ReceivedSignalStrength.Name = "GroupBox_ReceivedSignalStrength";
            this.GroupBox_ReceivedSignalStrength.Size = new System.Drawing.Size(587, 424);
            this.GroupBox_ReceivedSignalStrength.TabIndex = 4;
            this.GroupBox_ReceivedSignalStrength.TabStop = false;
            this.GroupBox_ReceivedSignalStrength.Text = "Received Signal Strength";
            // 
            // PanelChart
            // 
            this.PanelChart.Location = new System.Drawing.Point(10, 25);
            this.PanelChart.Name = "PanelChart";
            this.PanelChart.Size = new System.Drawing.Size(571, 392);
            this.PanelChart.TabIndex = 0;
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 20000;
            this.ToolTip1.InitialDelay = 1000;
            this.ToolTip1.ReshowDelay = 1000;
            // 
            // TextBox_CSVFileStorage_CollectionLocationDescription
            // 
            this.TextBox_CSVFileStorage_CollectionLocationDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_CSVFileStorage_CollectionLocationDescription.Location = new System.Drawing.Point(8, 60);
            this.TextBox_CSVFileStorage_CollectionLocationDescription.Name = "TextBox_CSVFileStorage_CollectionLocationDescription";
            this.TextBox_CSVFileStorage_CollectionLocationDescription.Size = new System.Drawing.Size(341, 26);
            this.TextBox_CSVFileStorage_CollectionLocationDescription.TabIndex = 2;
            this.TextBox_CSVFileStorage_CollectionLocationDescription.Text = "Client Location";
            this.ToolTip1.SetToolTip(this.TextBox_CSVFileStorage_CollectionLocationDescription, "Enter a short client location description. This text will create a CSV file subdi" +
        "rectory  under the Desktop/RFEOnSite Data/Client directory.");
            this.TextBox_CSVFileStorage_CollectionLocationDescription.TextChanged += new System.EventHandler(this.TextBoxSweepLocation_TextChanged);
            // 
            // LabelRBW
            // 
            this.LabelRBW.AutoSize = true;
            this.LabelRBW.BackColor = System.Drawing.Color.Transparent;
            this.LabelRBW.Location = new System.Drawing.Point(4, 104);
            this.LabelRBW.Name = "LabelRBW";
            this.LabelRBW.Size = new System.Drawing.Size(164, 20);
            this.LabelRBW.TabIndex = 5;
            this.LabelRBW.Text = "Resolution Bandwidth";
            this.ToolTip1.SetToolTip(this.LabelRBW, resources.GetString("LabelRBW.ToolTip"));
            // 
            // Button_CurrentConfiguration_SetRfeConfiguration
            // 
            this.Button_CurrentConfiguration_SetRfeConfiguration.Enabled = false;
            this.Button_CurrentConfiguration_SetRfeConfiguration.Location = new System.Drawing.Point(309, 42);
            this.Button_CurrentConfiguration_SetRfeConfiguration.Name = "Button_CurrentConfiguration_SetRfeConfiguration";
            this.Button_CurrentConfiguration_SetRfeConfiguration.Size = new System.Drawing.Size(127, 51);
            this.Button_CurrentConfiguration_SetRfeConfiguration.TabIndex = 10;
            this.Button_CurrentConfiguration_SetRfeConfiguration.Text = "Set Explorer Configuration";
            this.ToolTip1.SetToolTip(this.Button_CurrentConfiguration_SetRfeConfiguration, resources.GetString("Button_CurrentConfiguration_SetRfeConfiguration.ToolTip"));
            this.Button_CurrentConfiguration_SetRfeConfiguration.UseVisualStyleBackColor = true;
            this.Button_CurrentConfiguration_SetRfeConfiguration.Click += new System.EventHandler(this.ButtonSetConfiguration_Click);
            // 
            // TextBoxRBW
            // 
            this.TextBoxRBW.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBoxRBW.CausesValidation = false;
            this.TextBoxRBW.Location = new System.Drawing.Point(168, 101);
            this.TextBoxRBW.Name = "TextBoxRBW";
            this.TextBoxRBW.ReadOnly = true;
            this.TextBoxRBW.Size = new System.Drawing.Size(70, 26);
            this.TextBoxRBW.TabIndex = 17;
            this.TextBoxRBW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip1.SetToolTip(this.TextBoxRBW, "RBW is not directly settable. It is determined by table lookup in the RF Explorer" +
        " and is based on Span.");
            // 
            // ComboBox_CurrentConfiguration_Preset
            // 
            this.ComboBox_CurrentConfiguration_Preset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_CurrentConfiguration_Preset.Enabled = false;
            this.ComboBox_CurrentConfiguration_Preset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_CurrentConfiguration_Preset.FormattingEnabled = true;
            this.ComboBox_CurrentConfiguration_Preset.Items.AddRange(new object[] {
            "Continuous",
            "Single Sweep",
            "Full Downlink"});
            this.ComboBox_CurrentConfiguration_Preset.Location = new System.Drawing.Point(114, 215);
            this.ComboBox_CurrentConfiguration_Preset.Name = "ComboBox_CurrentConfiguration_Preset";
            this.ComboBox_CurrentConfiguration_Preset.Size = new System.Drawing.Size(142, 32);
            this.ComboBox_CurrentConfiguration_Preset.TabIndex = 25;
            this.ToolTip1.SetToolTip(this.ComboBox_CurrentConfiguration_Preset, resources.GetString("ComboBox_CurrentConfiguration_Preset.ToolTip"));
            this.ComboBox_CurrentConfiguration_Preset.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPreset_IndexChanged);
            // 
            // Button_CurrentConfiguration_GetRfeConfiguration
            // 
            this.Button_CurrentConfiguration_GetRfeConfiguration.Enabled = false;
            this.Button_CurrentConfiguration_GetRfeConfiguration.Location = new System.Drawing.Point(309, 108);
            this.Button_CurrentConfiguration_GetRfeConfiguration.Name = "Button_CurrentConfiguration_GetRfeConfiguration";
            this.Button_CurrentConfiguration_GetRfeConfiguration.Size = new System.Drawing.Size(127, 54);
            this.Button_CurrentConfiguration_GetRfeConfiguration.TabIndex = 27;
            this.Button_CurrentConfiguration_GetRfeConfiguration.Text = "Get Explorer  Configuration";
            this.ToolTip1.SetToolTip(this.Button_CurrentConfiguration_GetRfeConfiguration, "Get Explorer Configuration\r\n\r\nNot used with Full Downlink Preset.\r\n\r\nRequest and " +
        "display the current RF Explorer configuration.\r\n\r\nUse in conjunction with Set Ex" +
        "plorer Configuration.");
            this.Button_CurrentConfiguration_GetRfeConfiguration.UseVisualStyleBackColor = true;
            this.Button_CurrentConfiguration_GetRfeConfiguration.Click += new System.EventHandler(this.ButtonGetConfiguration_Click);
            // 
            // LabelStopFrequency
            // 
            this.LabelStopFrequency.AutoSize = true;
            this.LabelStopFrequency.BackColor = System.Drawing.Color.Transparent;
            this.LabelStopFrequency.Location = new System.Drawing.Point(46, 78);
            this.LabelStopFrequency.Name = "LabelStopFrequency";
            this.LabelStopFrequency.Size = new System.Drawing.Size(122, 20);
            this.LabelStopFrequency.TabIndex = 4;
            this.LabelStopFrequency.Text = "Stop Frequency";
            this.ToolTip1.SetToolTip(this.LabelStopFrequency, "End measurments at this frequency.\r\n\r\nClick \"Set Explorer Configuration\" to progr" +
        "am the connected RF Explorer");
            // 
            // Button_CSVFileStorage_ResetAllFields
            // 
            this.Button_CSVFileStorage_ResetAllFields.BackColor = System.Drawing.SystemColors.Control;
            this.Button_CSVFileStorage_ResetAllFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_CSVFileStorage_ResetAllFields.Location = new System.Drawing.Point(293, 12);
            this.Button_CSVFileStorage_ResetAllFields.Name = "Button_CSVFileStorage_ResetAllFields";
            this.Button_CSVFileStorage_ResetAllFields.Size = new System.Drawing.Size(108, 53);
            this.Button_CSVFileStorage_ResetAllFields.TabIndex = 45;
            this.Button_CSVFileStorage_ResetAllFields.Text = "Reset All Fields";
            this.ToolTip1.SetToolTip(this.Button_CSVFileStorage_ResetAllFields, "Restores all fields to default values. Sets \"Single Sweep\" Preset.");
            this.Button_CSVFileStorage_ResetAllFields.UseVisualStyleBackColor = false;
            this.Button_CSVFileStorage_ResetAllFields.Click += new System.EventHandler(this.Button_CSVFileStorage_ClearAllFields_Click);
            // 
            // Button_CSVFileStorage_CollectionFloor_Enable
            // 
            this.Button_CSVFileStorage_CollectionFloor_Enable.BackColor = System.Drawing.Color.Olive;
            this.Button_CSVFileStorage_CollectionFloor_Enable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_CSVFileStorage_CollectionFloor_Enable.Location = new System.Drawing.Point(223, 22);
            this.Button_CSVFileStorage_CollectionFloor_Enable.Name = "Button_CSVFileStorage_CollectionFloor_Enable";
            this.Button_CSVFileStorage_CollectionFloor_Enable.Size = new System.Drawing.Size(79, 29);
            this.Button_CSVFileStorage_CollectionFloor_Enable.TabIndex = 42;
            this.Button_CSVFileStorage_CollectionFloor_Enable.Text = "Disable";
            this.ToolTip1.SetToolTip(this.Button_CSVFileStorage_CollectionFloor_Enable, "Include a Floor indentifier in the CSV file name.  Also enables the increment and" +
        " decrement mode.");
            this.Button_CSVFileStorage_CollectionFloor_Enable.UseVisualStyleBackColor = false;
            this.Button_CSVFileStorage_CollectionFloor_Enable.Click += new System.EventHandler(this.Button_CSVFileStorage_CollectionFloor_Enable_Click);
            // 
            // RadioButton_CSVFileStorage_FloorIncrement
            // 
            this.RadioButton_CSVFileStorage_FloorIncrement.AutoSize = true;
            this.RadioButton_CSVFileStorage_FloorIncrement.Checked = true;
            this.RadioButton_CSVFileStorage_FloorIncrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton_CSVFileStorage_FloorIncrement.Location = new System.Drawing.Point(2, 16);
            this.RadioButton_CSVFileStorage_FloorIncrement.Name = "RadioButton_CSVFileStorage_FloorIncrement";
            this.RadioButton_CSVFileStorage_FloorIncrement.Size = new System.Drawing.Size(72, 17);
            this.RadioButton_CSVFileStorage_FloorIncrement.TabIndex = 41;
            this.RadioButton_CSVFileStorage_FloorIncrement.TabStop = true;
            this.RadioButton_CSVFileStorage_FloorIncrement.Text = "Increment";
            this.ToolTip1.SetToolTip(this.RadioButton_CSVFileStorage_FloorIncrement, "When Enabled, increment the floor number each time the Next Button is pressed. Re" +
        "ally? Most people prefer decending floors!");
            this.RadioButton_CSVFileStorage_FloorIncrement.UseVisualStyleBackColor = true;
            // 
            // RadioButton_CSVFileStorage_FloorDecrement
            // 
            this.RadioButton_CSVFileStorage_FloorDecrement.AutoSize = true;
            this.RadioButton_CSVFileStorage_FloorDecrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton_CSVFileStorage_FloorDecrement.Location = new System.Drawing.Point(2, 38);
            this.RadioButton_CSVFileStorage_FloorDecrement.Name = "RadioButton_CSVFileStorage_FloorDecrement";
            this.RadioButton_CSVFileStorage_FloorDecrement.Size = new System.Drawing.Size(77, 17);
            this.RadioButton_CSVFileStorage_FloorDecrement.TabIndex = 40;
            this.RadioButton_CSVFileStorage_FloorDecrement.Text = "Decrement";
            this.ToolTip1.SetToolTip(this.RadioButton_CSVFileStorage_FloorDecrement, "When Enabled, deccrement the floor number each time the Next Button is pressed.");
            this.RadioButton_CSVFileStorage_FloorDecrement.UseVisualStyleBackColor = true;
            // 
            // CheckBox_CSVFileStorage_AutoIncrementMarkerNumber
            // 
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.AutoSize = true;
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Location = new System.Drawing.Point(223, 32);
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Name = "CheckBox_CSVFileStorage_AutoIncrementMarkerNumber";
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Size = new System.Drawing.Size(101, 17);
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.TabIndex = 29;
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.Text = "Auto Increment ";
            this.ToolTip1.SetToolTip(this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber, "Auto Increment the Collection Site Marker Number after the Capture Button is pres" +
        "sed.");
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.UseVisualStyleBackColor = true;
            this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber.CheckedChanged += new System.EventHandler(this.CheckBoxAutoIncrement_CheckedChanged);
            // 
            // LabelStartFrequency
            // 
            this.LabelStartFrequency.AutoSize = true;
            this.LabelStartFrequency.BackColor = System.Drawing.Color.Transparent;
            this.LabelStartFrequency.Location = new System.Drawing.Point(45, 26);
            this.LabelStartFrequency.Name = "LabelStartFrequency";
            this.LabelStartFrequency.Size = new System.Drawing.Size(123, 20);
            this.LabelStartFrequency.TabIndex = 2;
            this.LabelStartFrequency.Text = "Start Frequency";
            this.ToolTip1.SetToolTip(this.LabelStartFrequency, "Begin measurments at this frequency.\r\n\r\nClick \"Set Explorer Configuration\" to pro" +
        "gram the connected RF Explorer.");
            // 
            // LabelFrequencyStep
            // 
            this.LabelFrequencyStep.AutoSize = true;
            this.LabelFrequencyStep.BackColor = System.Drawing.Color.Transparent;
            this.LabelFrequencyStep.Location = new System.Drawing.Point(46, 52);
            this.LabelFrequencyStep.Name = "LabelFrequencyStep";
            this.LabelFrequencyStep.Size = new System.Drawing.Size(122, 20);
            this.LabelFrequencyStep.TabIndex = 8;
            this.LabelFrequencyStep.Text = "Frequency Step";
            this.ToolTip1.SetToolTip(this.LabelFrequencyStep, "Frequency sample step size returned by approximation or by the RF Explorer.");
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Controls.Add(this.TabControl_Main_Connection);
            this.TabControl_Main.Controls.Add(this.TabControl_Main_OmniDirectional);
            this.TabControl_Main.Controls.Add(this.TabControl_Main_Radial);
            this.TabControl_Main.Controls.Add(this.TabControl_Main_LocationCamera);
            this.TabControl_Main.Controls.Add(this.TabControl_Main_Calibration);
            this.TabControl_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TabControl_Main.Location = new System.Drawing.Point(12, 27);
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(532, 346);
            this.TabControl_Main.TabIndex = 37;
            this.ToolTip1.SetToolTip(this.TabControl_Main, "Connect the RF Explorer to this COM Port.");
            this.TabControl_Main.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // TabControl_Main_Connection
            // 
            this.TabControl_Main_Connection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.TabControl_Main_Connection.Controls.Add(this.Label_Connection_ComPortText);
            this.TabControl_Main_Connection.Controls.Add(this.Label_Connection_ModelID);
            this.TabControl_Main_Connection.Controls.Add(this.Label_Connection_DeviceID);
            this.TabControl_Main_Connection.Controls.Add(this.Button_Connection_ConnectExplorer);
            this.TabControl_Main_Connection.Controls.Add(this.Label_Connection_FirmwareValue);
            this.TabControl_Main_Connection.Controls.Add(this.Label_Connection_ComPortValue);
            this.TabControl_Main_Connection.Controls.Add(this.Label_Connection_Firmware);
            this.TabControl_Main_Connection.Controls.Add(this.Label_Connection_DeviceIDValue);
            this.TabControl_Main_Connection.Controls.Add(this.Label_Connection_ModelIDValue);
            this.TabControl_Main_Connection.Controls.Add(this.GroupBox_Connection_DocumentationAndUSBTroubleShooting);
            this.TabControl_Main_Connection.Location = new System.Drawing.Point(4, 29);
            this.TabControl_Main_Connection.Name = "TabControl_Main_Connection";
            this.TabControl_Main_Connection.Padding = new System.Windows.Forms.Padding(3);
            this.TabControl_Main_Connection.Size = new System.Drawing.Size(524, 313);
            this.TabControl_Main_Connection.TabIndex = 0;
            this.TabControl_Main_Connection.Text = "Connection";
            // 
            // Label_Connection_ComPortText
            // 
            this.Label_Connection_ComPortText.AutoSize = true;
            this.Label_Connection_ComPortText.BackColor = System.Drawing.Color.Transparent;
            this.Label_Connection_ComPortText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Connection_ComPortText.Location = new System.Drawing.Point(275, 33);
            this.Label_Connection_ComPortText.Name = "Label_Connection_ComPortText";
            this.Label_Connection_ComPortText.Size = new System.Drawing.Size(82, 20);
            this.Label_Connection_ComPortText.TabIndex = 18;
            this.Label_Connection_ComPortText.Text = "COM Port:";
            this.ToolTip1.SetToolTip(this.Label_Connection_ComPortText, "This RF Explorer COM Port connection.");
            // 
            // GroupBox_Connection_DocumentationAndUSBTroubleShooting
            // 
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Controls.Add(this.Button_FirmwareUpdate);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Controls.Add(this.Button_Connection_UsbTroubleShooting);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Controls.Add(this.Button_Connection_Documentation);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Controls.Add(this.Button_Connection_USBDriverDownload);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Controls.Add(this.RadioButton_Connection_SetSignalGenerator);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Controls.Add(this.RadioButton_Connection_SetSpectrumAnalyzer);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Location = new System.Drawing.Point(35, 132);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Name = "GroupBox_Connection_DocumentationAndUSBTroubleShooting";
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Size = new System.Drawing.Size(455, 169);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.TabIndex = 21;
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.TabStop = false;
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.Text = "Documentation and USB Trouble Shooting";
            // 
            // Button_FirmwareUpdate
            // 
            this.Button_FirmwareUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_FirmwareUpdate.Location = new System.Drawing.Point(141, 98);
            this.Button_FirmwareUpdate.Name = "Button_FirmwareUpdate";
            this.Button_FirmwareUpdate.Size = new System.Drawing.Size(90, 51);
            this.Button_FirmwareUpdate.TabIndex = 21;
            this.Button_FirmwareUpdate.Text = "Firmware Update";
            this.Button_FirmwareUpdate.UseVisualStyleBackColor = true;
            this.Button_FirmwareUpdate.Click += new System.EventHandler(this.Button_FirmwareUpdate_Click);
            // 
            // Button_Connection_UsbTroubleShooting
            // 
            this.Button_Connection_UsbTroubleShooting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Connection_UsbTroubleShooting.Location = new System.Drawing.Point(35, 98);
            this.Button_Connection_UsbTroubleShooting.Name = "Button_Connection_UsbTroubleShooting";
            this.Button_Connection_UsbTroubleShooting.Size = new System.Drawing.Size(90, 51);
            this.Button_Connection_UsbTroubleShooting.TabIndex = 19;
            this.Button_Connection_UsbTroubleShooting.Text = "Trouble Shooting";
            this.Button_Connection_UsbTroubleShooting.UseVisualStyleBackColor = true;
            this.Button_Connection_UsbTroubleShooting.Click += new System.EventHandler(this.BaudRate_Click);
            // 
            // Button_Connection_USBDriverDownload
            // 
            this.Button_Connection_USBDriverDownload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Connection_USBDriverDownload.Location = new System.Drawing.Point(247, 98);
            this.Button_Connection_USBDriverDownload.Name = "Button_Connection_USBDriverDownload";
            this.Button_Connection_USBDriverDownload.Size = new System.Drawing.Size(179, 51);
            this.Button_Connection_USBDriverDownload.TabIndex = 20;
            this.Button_Connection_USBDriverDownload.Text = "RF Explorer Driver Download";
            this.Button_Connection_USBDriverDownload.UseVisualStyleBackColor = true;
            this.Button_Connection_USBDriverDownload.Click += new System.EventHandler(this.Button_USBDriverDownload_Click);
            // 
            // TabControl_Main_OmniDirectional
            // 
            this.TabControl_Main_OmniDirectional.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TabControl_Main_OmniDirectional.Controls.Add(this.GroupBox_OmniDirectional_CurrentConfiguration);
            this.TabControl_Main_OmniDirectional.Location = new System.Drawing.Point(4, 29);
            this.TabControl_Main_OmniDirectional.Name = "TabControl_Main_OmniDirectional";
            this.TabControl_Main_OmniDirectional.Padding = new System.Windows.Forms.Padding(3);
            this.TabControl_Main_OmniDirectional.Size = new System.Drawing.Size(524, 313);
            this.TabControl_Main_OmniDirectional.TabIndex = 1;
            this.TabControl_Main_OmniDirectional.Text = "OmniDirectional";
            // 
            // GroupBox_OmniDirectional_CurrentConfiguration
            // 
            this.GroupBox_OmniDirectional_CurrentConfiguration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(11)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBox_Band_WCS);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBox_Band_AWS);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBox_Band_CEL);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBox_Band_700);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBox_Band_PCS);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBox_Band_600);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelRBWUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.ComboBox_CurrentConfiguration_Preset);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelRBW);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBoxRBW);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.Button_CurrentConfiguration_GetRfeConfiguration);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.Label_CurrentConfiguration_Presets);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.Label_CurrentConfiguration_RightAntennaGaindB);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBox_CurrentConfiguration_RightAntennaGain);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.Label_CurrentConfiguration_RightAntennaGain);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.Label_CurrentConfiguration_LeftAntennaGaindB);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBox_CurrentConfiguration_LeftAntennaGain);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.Label_CurrentConfiguration_LeftAntennaGain);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBox_CurrentConfiguration_StepFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelStopFrequencyUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelStartFrequencyUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.Button_CurrentConfiguration_SetRfeConfiguration);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelFrequencyStepUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelStartFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelFrequencyStep);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBox_CurrentConfiguration_StartFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBox_CurrentConfiguration_StopFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelStopFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Location = new System.Drawing.Point(16, 21);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Name = "GroupBox_OmniDirectional_CurrentConfiguration";
            this.GroupBox_OmniDirectional_CurrentConfiguration.Size = new System.Drawing.Size(490, 274);
            this.GroupBox_OmniDirectional_CurrentConfiguration.TabIndex = 10;
            this.GroupBox_OmniDirectional_CurrentConfiguration.TabStop = false;
            this.GroupBox_OmniDirectional_CurrentConfiguration.Text = "Current Configuration";
            // 
            // CheckBox_Band_WCS
            // 
            this.CheckBox_Band_WCS.AutoSize = true;
            this.CheckBox_Band_WCS.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Band_WCS.Checked = true;
            this.CheckBox_Band_WCS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Band_WCS.Location = new System.Drawing.Point(412, 230);
            this.CheckBox_Band_WCS.Name = "CheckBox_Band_WCS";
            this.CheckBox_Band_WCS.Size = new System.Drawing.Size(65, 24);
            this.CheckBox_Band_WCS.TabIndex = 33;
            this.CheckBox_Band_WCS.Text = "WCS";
            this.CheckBox_Band_WCS.UseVisualStyleBackColor = false;
            this.CheckBox_Band_WCS.CheckedChanged += new System.EventHandler(this.CheckBox_Band_WCS_CheckedChanged);
            // 
            // CheckBox_Band_AWS
            // 
            this.CheckBox_Band_AWS.AutoSize = true;
            this.CheckBox_Band_AWS.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Band_AWS.Checked = true;
            this.CheckBox_Band_AWS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Band_AWS.Location = new System.Drawing.Point(341, 230);
            this.CheckBox_Band_AWS.Name = "CheckBox_Band_AWS";
            this.CheckBox_Band_AWS.Size = new System.Drawing.Size(65, 24);
            this.CheckBox_Band_AWS.TabIndex = 32;
            this.CheckBox_Band_AWS.Text = "AWS";
            this.CheckBox_Band_AWS.UseVisualStyleBackColor = false;
            this.CheckBox_Band_AWS.CheckedChanged += new System.EventHandler(this.CheckBox_Band_AWS_CheckedChanged);
            // 
            // CheckBox_Band_CEL
            // 
            this.CheckBox_Band_CEL.AutoSize = true;
            this.CheckBox_Band_CEL.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Band_CEL.Checked = true;
            this.CheckBox_Band_CEL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Band_CEL.Location = new System.Drawing.Point(397, 206);
            this.CheckBox_Band_CEL.Name = "CheckBox_Band_CEL";
            this.CheckBox_Band_CEL.Size = new System.Drawing.Size(80, 24);
            this.CheckBox_Band_CEL.TabIndex = 31;
            this.CheckBox_Band_CEL.Text = "Cellular";
            this.CheckBox_Band_CEL.UseVisualStyleBackColor = false;
            this.CheckBox_Band_CEL.CheckedChanged += new System.EventHandler(this.CheckBox_Band_CEL_CheckedChanged);
            // 
            // CheckBox_Band_700
            // 
            this.CheckBox_Band_700.AutoSize = true;
            this.CheckBox_Band_700.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Band_700.Checked = true;
            this.CheckBox_Band_700.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Band_700.Location = new System.Drawing.Point(336, 206);
            this.CheckBox_Band_700.Name = "CheckBox_Band_700";
            this.CheckBox_Band_700.Size = new System.Drawing.Size(55, 24);
            this.CheckBox_Band_700.TabIndex = 30;
            this.CheckBox_Band_700.Text = "700";
            this.CheckBox_Band_700.UseVisualStyleBackColor = false;
            this.CheckBox_Band_700.CheckedChanged += new System.EventHandler(this.CheckBox_Band_700_CheckedChanged);
            // 
            // CheckBox_Band_PCS
            // 
            this.CheckBox_Band_PCS.AutoSize = true;
            this.CheckBox_Band_PCS.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Band_PCS.Checked = true;
            this.CheckBox_Band_PCS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Band_PCS.Location = new System.Drawing.Point(275, 230);
            this.CheckBox_Band_PCS.Name = "CheckBox_Band_PCS";
            this.CheckBox_Band_PCS.Size = new System.Drawing.Size(60, 24);
            this.CheckBox_Band_PCS.TabIndex = 29;
            this.CheckBox_Band_PCS.Text = "PCS";
            this.CheckBox_Band_PCS.UseVisualStyleBackColor = false;
            this.CheckBox_Band_PCS.CheckedChanged += new System.EventHandler(this.CheckBox_Band_PCS_CheckedChanged);
            // 
            // CheckBox_Band_600
            // 
            this.CheckBox_Band_600.AutoSize = true;
            this.CheckBox_Band_600.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Band_600.Checked = true;
            this.CheckBox_Band_600.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Band_600.Location = new System.Drawing.Point(275, 206);
            this.CheckBox_Band_600.Name = "CheckBox_Band_600";
            this.CheckBox_Band_600.Size = new System.Drawing.Size(55, 24);
            this.CheckBox_Band_600.TabIndex = 28;
            this.CheckBox_Band_600.Text = "600";
            this.CheckBox_Band_600.UseVisualStyleBackColor = false;
            this.CheckBox_Band_600.CheckedChanged += new System.EventHandler(this.CheckBox_Band_600_CheckedChanged);
            // 
            // LabelRBWUnit
            // 
            this.LabelRBWUnit.AutoSize = true;
            this.LabelRBWUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelRBWUnit.Location = new System.Drawing.Point(244, 104);
            this.LabelRBWUnit.Name = "LabelRBWUnit";
            this.LabelRBWUnit.Size = new System.Drawing.Size(39, 20);
            this.LabelRBWUnit.TabIndex = 6;
            this.LabelRBWUnit.Text = "KHz";
            // 
            // Label_CurrentConfiguration_Presets
            // 
            this.Label_CurrentConfiguration_Presets.AutoSize = true;
            this.Label_CurrentConfiguration_Presets.BackColor = System.Drawing.Color.Transparent;
            this.Label_CurrentConfiguration_Presets.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_CurrentConfiguration_Presets.Location = new System.Drawing.Point(23, 217);
            this.Label_CurrentConfiguration_Presets.Name = "Label_CurrentConfiguration_Presets";
            this.Label_CurrentConfiguration_Presets.Size = new System.Drawing.Size(89, 29);
            this.Label_CurrentConfiguration_Presets.TabIndex = 26;
            this.Label_CurrentConfiguration_Presets.Text = "Preset:";
            // 
            // Label_CurrentConfiguration_RightAntennaGaindB
            // 
            this.Label_CurrentConfiguration_RightAntennaGaindB.AutoSize = true;
            this.Label_CurrentConfiguration_RightAntennaGaindB.BackColor = System.Drawing.Color.Transparent;
            this.Label_CurrentConfiguration_RightAntennaGaindB.Enabled = false;
            this.Label_CurrentConfiguration_RightAntennaGaindB.Location = new System.Drawing.Point(224, 170);
            this.Label_CurrentConfiguration_RightAntennaGaindB.Name = "Label_CurrentConfiguration_RightAntennaGaindB";
            this.Label_CurrentConfiguration_RightAntennaGaindB.Size = new System.Drawing.Size(29, 20);
            this.Label_CurrentConfiguration_RightAntennaGaindB.TabIndex = 24;
            this.Label_CurrentConfiguration_RightAntennaGaindB.Text = "dB";
            // 
            // TextBox_CurrentConfiguration_RightAntennaGain
            // 
            this.TextBox_CurrentConfiguration_RightAntennaGain.AllowDrop = true;
            this.TextBox_CurrentConfiguration_RightAntennaGain.Enabled = false;
            this.TextBox_CurrentConfiguration_RightAntennaGain.Location = new System.Drawing.Point(168, 167);
            this.TextBox_CurrentConfiguration_RightAntennaGain.Name = "TextBox_CurrentConfiguration_RightAntennaGain";
            this.TextBox_CurrentConfiguration_RightAntennaGain.Size = new System.Drawing.Size(56, 26);
            this.TextBox_CurrentConfiguration_RightAntennaGain.TabIndex = 23;
            this.TextBox_CurrentConfiguration_RightAntennaGain.Text = "0";
            this.TextBox_CurrentConfiguration_RightAntennaGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_CurrentConfiguration_RightAntennaGain.TextChanged += new System.EventHandler(this.TextBoxRightAntennaGain_TextChanged);
            // 
            // Label_CurrentConfiguration_RightAntennaGain
            // 
            this.Label_CurrentConfiguration_RightAntennaGain.AutoSize = true;
            this.Label_CurrentConfiguration_RightAntennaGain.BackColor = System.Drawing.Color.Transparent;
            this.Label_CurrentConfiguration_RightAntennaGain.Location = new System.Drawing.Point(18, 170);
            this.Label_CurrentConfiguration_RightAntennaGain.Name = "Label_CurrentConfiguration_RightAntennaGain";
            this.Label_CurrentConfiguration_RightAntennaGain.Size = new System.Drawing.Size(150, 20);
            this.Label_CurrentConfiguration_RightAntennaGain.TabIndex = 22;
            this.Label_CurrentConfiguration_RightAntennaGain.Text = "Right Antenna Gain";
            // 
            // Label_CurrentConfiguration_LeftAntennaGaindB
            // 
            this.Label_CurrentConfiguration_LeftAntennaGaindB.AutoSize = true;
            this.Label_CurrentConfiguration_LeftAntennaGaindB.BackColor = System.Drawing.Color.Transparent;
            this.Label_CurrentConfiguration_LeftAntennaGaindB.Enabled = false;
            this.Label_CurrentConfiguration_LeftAntennaGaindB.Location = new System.Drawing.Point(224, 144);
            this.Label_CurrentConfiguration_LeftAntennaGaindB.Name = "Label_CurrentConfiguration_LeftAntennaGaindB";
            this.Label_CurrentConfiguration_LeftAntennaGaindB.Size = new System.Drawing.Size(29, 20);
            this.Label_CurrentConfiguration_LeftAntennaGaindB.TabIndex = 21;
            this.Label_CurrentConfiguration_LeftAntennaGaindB.Text = "dB";
            // 
            // TextBox_CurrentConfiguration_LeftAntennaGain
            // 
            this.TextBox_CurrentConfiguration_LeftAntennaGain.AllowDrop = true;
            this.TextBox_CurrentConfiguration_LeftAntennaGain.Enabled = false;
            this.TextBox_CurrentConfiguration_LeftAntennaGain.Location = new System.Drawing.Point(168, 141);
            this.TextBox_CurrentConfiguration_LeftAntennaGain.Name = "TextBox_CurrentConfiguration_LeftAntennaGain";
            this.TextBox_CurrentConfiguration_LeftAntennaGain.Size = new System.Drawing.Size(56, 26);
            this.TextBox_CurrentConfiguration_LeftAntennaGain.TabIndex = 20;
            this.TextBox_CurrentConfiguration_LeftAntennaGain.Text = "0";
            this.TextBox_CurrentConfiguration_LeftAntennaGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_CurrentConfiguration_LeftAntennaGain.TextChanged += new System.EventHandler(this.TextBoxLeftAntennaGain_TextChanged);
            // 
            // Label_CurrentConfiguration_LeftAntennaGain
            // 
            this.Label_CurrentConfiguration_LeftAntennaGain.AutoSize = true;
            this.Label_CurrentConfiguration_LeftAntennaGain.BackColor = System.Drawing.Color.Transparent;
            this.Label_CurrentConfiguration_LeftAntennaGain.Location = new System.Drawing.Point(28, 144);
            this.Label_CurrentConfiguration_LeftAntennaGain.Name = "Label_CurrentConfiguration_LeftAntennaGain";
            this.Label_CurrentConfiguration_LeftAntennaGain.Size = new System.Drawing.Size(140, 20);
            this.Label_CurrentConfiguration_LeftAntennaGain.TabIndex = 19;
            this.Label_CurrentConfiguration_LeftAntennaGain.Text = "Left Antenna Gain";
            // 
            // TextBox_CurrentConfiguration_StepFrequency
            // 
            this.TextBox_CurrentConfiguration_StepFrequency.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TextBox_CurrentConfiguration_StepFrequency.CausesValidation = false;
            this.TextBox_CurrentConfiguration_StepFrequency.Location = new System.Drawing.Point(168, 49);
            this.TextBox_CurrentConfiguration_StepFrequency.Name = "TextBox_CurrentConfiguration_StepFrequency";
            this.TextBox_CurrentConfiguration_StepFrequency.ReadOnly = true;
            this.TextBox_CurrentConfiguration_StepFrequency.Size = new System.Drawing.Size(70, 26);
            this.TextBox_CurrentConfiguration_StepFrequency.TabIndex = 18;
            this.TextBox_CurrentConfiguration_StepFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip1.SetToolTip(this.TextBox_CurrentConfiguration_StepFrequency, "The RF Explorer has a minumum 1 KHz step size. Stop to Start is divded into 112 e" +
        "qual steps.");
            // 
            // LabelStopFrequencyUnit
            // 
            this.LabelStopFrequencyUnit.AutoSize = true;
            this.LabelStopFrequencyUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelStopFrequencyUnit.Location = new System.Drawing.Point(244, 78);
            this.LabelStopFrequencyUnit.Name = "LabelStopFrequencyUnit";
            this.LabelStopFrequencyUnit.Size = new System.Drawing.Size(42, 20);
            this.LabelStopFrequencyUnit.TabIndex = 16;
            this.LabelStopFrequencyUnit.Text = "MHz";
            // 
            // LabelStartFrequencyUnit
            // 
            this.LabelStartFrequencyUnit.AutoSize = true;
            this.LabelStartFrequencyUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelStartFrequencyUnit.Location = new System.Drawing.Point(244, 26);
            this.LabelStartFrequencyUnit.Name = "LabelStartFrequencyUnit";
            this.LabelStartFrequencyUnit.Size = new System.Drawing.Size(42, 20);
            this.LabelStartFrequencyUnit.TabIndex = 15;
            this.LabelStartFrequencyUnit.Text = "MHz";
            // 
            // LabelFrequencyStepUnit
            // 
            this.LabelFrequencyStepUnit.AutoSize = true;
            this.LabelFrequencyStepUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelFrequencyStepUnit.Location = new System.Drawing.Point(244, 52);
            this.LabelFrequencyStepUnit.Name = "LabelFrequencyStepUnit";
            this.LabelFrequencyStepUnit.Size = new System.Drawing.Size(39, 20);
            this.LabelFrequencyStepUnit.TabIndex = 9;
            this.LabelFrequencyStepUnit.Text = "KHz";
            // 
            // TextBox_CurrentConfiguration_StartFrequency
            // 
            this.TextBox_CurrentConfiguration_StartFrequency.Enabled = false;
            this.TextBox_CurrentConfiguration_StartFrequency.Location = new System.Drawing.Point(168, 23);
            this.TextBox_CurrentConfiguration_StartFrequency.Name = "TextBox_CurrentConfiguration_StartFrequency";
            this.TextBox_CurrentConfiguration_StartFrequency.Size = new System.Drawing.Size(70, 26);
            this.TextBox_CurrentConfiguration_StartFrequency.TabIndex = 3;
            this.TextBox_CurrentConfiguration_StartFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip1.SetToolTip(this.TextBox_CurrentConfiguration_StartFrequency, "First set Start Frequency then set Stop Frequency. If Step size is too large, adj" +
        "ust Step Size.");
            this.TextBox_CurrentConfiguration_StartFrequency.TextChanged += new System.EventHandler(this.TextBoxStartFrequency_TextChanged);
            // 
            // TextBox_CurrentConfiguration_StopFrequency
            // 
            this.TextBox_CurrentConfiguration_StopFrequency.Enabled = false;
            this.TextBox_CurrentConfiguration_StopFrequency.Location = new System.Drawing.Point(168, 75);
            this.TextBox_CurrentConfiguration_StopFrequency.Name = "TextBox_CurrentConfiguration_StopFrequency";
            this.TextBox_CurrentConfiguration_StopFrequency.Size = new System.Drawing.Size(70, 26);
            this.TextBox_CurrentConfiguration_StopFrequency.TabIndex = 7;
            this.TextBox_CurrentConfiguration_StopFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBox_CurrentConfiguration_StopFrequency.TextChanged += new System.EventHandler(this.TextBoxStopFrequency_TextChanged);
            // 
            // TabControl_Main_Radial
            // 
            this.TabControl_Main_Radial.BackColor = System.Drawing.Color.White;
            this.TabControl_Main_Radial.Controls.Add(this.LabelRadialAzimuth);
            this.TabControl_Main_Radial.Controls.Add(this.LabelTrueNorthText);
            this.TabControl_Main_Radial.Controls.Add(this.CheckBoxRadialAzimuth);
            this.TabControl_Main_Radial.Controls.Add(this.NumericUpDownRadialAzimuth);
            this.TabControl_Main_Radial.Location = new System.Drawing.Point(4, 29);
            this.TabControl_Main_Radial.Name = "TabControl_Main_Radial";
            this.TabControl_Main_Radial.Size = new System.Drawing.Size(524, 313);
            this.TabControl_Main_Radial.TabIndex = 2;
            this.TabControl_Main_Radial.Text = "Radial";
            // 
            // LabelRadialAzimuth
            // 
            this.LabelRadialAzimuth.AutoSize = true;
            this.LabelRadialAzimuth.BackColor = System.Drawing.Color.White;
            this.LabelRadialAzimuth.Enabled = false;
            this.LabelRadialAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRadialAzimuth.ForeColor = System.Drawing.Color.Black;
            this.LabelRadialAzimuth.Location = new System.Drawing.Point(128, 103);
            this.LabelRadialAzimuth.Name = "LabelRadialAzimuth";
            this.LabelRadialAzimuth.Size = new System.Drawing.Size(262, 37);
            this.LabelRadialAzimuth.TabIndex = 35;
            this.LabelRadialAzimuth.Text = "Azimuth Degrees";
            this.LabelRadialAzimuth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTrueNorthText
            // 
            this.LabelTrueNorthText.AutoSize = true;
            this.LabelTrueNorthText.Location = new System.Drawing.Point(215, 250);
            this.LabelTrueNorthText.Name = "LabelTrueNorthText";
            this.LabelTrueNorthText.Size = new System.Drawing.Size(84, 20);
            this.LabelTrueNorthText.TabIndex = 36;
            this.LabelTrueNorthText.Text = "True North";
            // 
            // NumericUpDownRadialAzimuth
            // 
            this.NumericUpDownRadialAzimuth.Enabled = false;
            this.NumericUpDownRadialAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDownRadialAzimuth.Location = new System.Drawing.Point(155, 174);
            this.NumericUpDownRadialAzimuth.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.NumericUpDownRadialAzimuth.Name = "NumericUpDownRadialAzimuth";
            this.NumericUpDownRadialAzimuth.Size = new System.Drawing.Size(204, 49);
            this.NumericUpDownRadialAzimuth.TabIndex = 34;
            this.NumericUpDownRadialAzimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TabControl_Main_LocationCamera
            // 
            this.TabControl_Main_LocationCamera.Controls.Add(this.Label_LocationCamera_Marker);
            this.TabControl_Main_LocationCamera.Controls.Add(this.Label_LocationCamera_Floor);
            this.TabControl_Main_LocationCamera.Controls.Add(this.Button_LocationCamera_PauseResume);
            this.TabControl_Main_LocationCamera.Controls.Add(this.Button_LocationCamera_CaptureFrame);
            this.TabControl_Main_LocationCamera.Controls.Add(this.PictureBox_LocationCamera);
            this.TabControl_Main_LocationCamera.Location = new System.Drawing.Point(4, 29);
            this.TabControl_Main_LocationCamera.Name = "TabControl_Main_LocationCamera";
            this.TabControl_Main_LocationCamera.Padding = new System.Windows.Forms.Padding(3);
            this.TabControl_Main_LocationCamera.Size = new System.Drawing.Size(524, 313);
            this.TabControl_Main_LocationCamera.TabIndex = 3;
            this.TabControl_Main_LocationCamera.Text = "Location Camera";
            this.TabControl_Main_LocationCamera.UseVisualStyleBackColor = true;
            // 
            // Label_LocationCamera_Marker
            // 
            this.Label_LocationCamera_Marker.Location = new System.Drawing.Point(4, 111);
            this.Label_LocationCamera_Marker.Name = "Label_LocationCamera_Marker";
            this.Label_LocationCamera_Marker.Size = new System.Drawing.Size(148, 20);
            this.Label_LocationCamera_Marker.TabIndex = 52;
            this.Label_LocationCamera_Marker.Text = "Marker ID";
            this.Label_LocationCamera_Marker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_LocationCamera_Floor
            // 
            this.Label_LocationCamera_Floor.Location = new System.Drawing.Point(4, 89);
            this.Label_LocationCamera_Floor.Name = "Label_LocationCamera_Floor";
            this.Label_LocationCamera_Floor.Size = new System.Drawing.Size(148, 20);
            this.Label_LocationCamera_Floor.TabIndex = 51;
            this.Label_LocationCamera_Floor.Text = "Floor ID";
            this.Label_LocationCamera_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_LocationCamera_PauseResume
            // 
            this.Button_LocationCamera_PauseResume.Location = new System.Drawing.Point(33, 191);
            this.Button_LocationCamera_PauseResume.Name = "Button_LocationCamera_PauseResume";
            this.Button_LocationCamera_PauseResume.Size = new System.Drawing.Size(91, 32);
            this.Button_LocationCamera_PauseResume.TabIndex = 49;
            this.Button_LocationCamera_PauseResume.Text = "Capture Marker Image";
            this.Button_LocationCamera_PauseResume.UseVisualStyleBackColor = true;
            this.Button_LocationCamera_PauseResume.Click += new System.EventHandler(this.ButtonPauseResume_Click);
            // 
            // Button_LocationCamera_CaptureFrame
            // 
            this.Button_LocationCamera_CaptureFrame.BackColor = System.Drawing.Color.Gray;
            this.Button_LocationCamera_CaptureFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_LocationCamera_CaptureFrame.Location = new System.Drawing.Point(8, 135);
            this.Button_LocationCamera_CaptureFrame.Name = "Button_LocationCamera_CaptureFrame";
            this.Button_LocationCamera_CaptureFrame.Size = new System.Drawing.Size(141, 50);
            this.Button_LocationCamera_CaptureFrame.TabIndex = 44;
            this.Button_LocationCamera_CaptureFrame.Text = "Capture Marker Image";
            this.ToolTip1.SetToolTip(this.Button_LocationCamera_CaptureFrame, resources.GetString("Button_LocationCamera_CaptureFrame.ToolTip"));
            this.Button_LocationCamera_CaptureFrame.UseVisualStyleBackColor = false;
            this.Button_LocationCamera_CaptureFrame.Click += new System.EventHandler(this.ButtonCaptureImage_Click);
            // 
            // PictureBox_LocationCamera
            // 
            this.PictureBox_LocationCamera.Location = new System.Drawing.Point(157, 6);
            this.PictureBox_LocationCamera.Name = "PictureBox_LocationCamera";
            this.PictureBox_LocationCamera.Size = new System.Drawing.Size(361, 301);
            this.PictureBox_LocationCamera.TabIndex = 45;
            this.PictureBox_LocationCamera.TabStop = false;
            // 
            // TabControl_Main_Calibration
            // 
            this.TabControl_Main_Calibration.Controls.Add(this.TextBoxCalibrationPointsPerSweepInterval);
            this.TabControl_Main_Calibration.Controls.Add(this.label2);
            this.TabControl_Main_Calibration.Controls.Add(this.TextBoxCalibrationSourceDbm);
            this.TabControl_Main_Calibration.Controls.Add(this.label1);
            this.TabControl_Main_Calibration.Controls.Add(this.ButtonCalibrationStart);
            this.TabControl_Main_Calibration.Location = new System.Drawing.Point(4, 29);
            this.TabControl_Main_Calibration.Name = "TabControl_Main_Calibration";
            this.TabControl_Main_Calibration.Padding = new System.Windows.Forms.Padding(3);
            this.TabControl_Main_Calibration.Size = new System.Drawing.Size(524, 313);
            this.TabControl_Main_Calibration.TabIndex = 4;
            this.TabControl_Main_Calibration.Text = "Calibration";
            this.TabControl_Main_Calibration.UseVisualStyleBackColor = true;
            // 
            // TextBoxCalibrationPointsPerSweepInterval
            // 
            this.TextBoxCalibrationPointsPerSweepInterval.Location = new System.Drawing.Point(328, 102);
            this.TextBoxCalibrationPointsPerSweepInterval.Name = "TextBoxCalibrationPointsPerSweepInterval";
            this.TextBoxCalibrationPointsPerSweepInterval.Size = new System.Drawing.Size(33, 26);
            this.TextBoxCalibrationPointsPerSweepInterval.TabIndex = 4;
            this.TextBoxCalibrationPointsPerSweepInterval.Text = "3";
            this.TextBoxCalibrationPointsPerSweepInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxCalibrationPointsPerSweepInterval.TextChanged += new System.EventHandler(this.TextBoxCalibrationPointsPerSweepInterval_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Calibration Points per Sweep Interval";
            // 
            // TextBoxCalibrationSourceDbm
            // 
            this.TextBoxCalibrationSourceDbm.Location = new System.Drawing.Point(237, 61);
            this.TextBoxCalibrationSourceDbm.Name = "TextBoxCalibrationSourceDbm";
            this.TextBoxCalibrationSourceDbm.Size = new System.Drawing.Size(56, 26);
            this.TextBoxCalibrationSourceDbm.TabIndex = 2;
            this.TextBoxCalibrationSourceDbm.Text = "-75";
            this.TextBoxCalibrationSourceDbm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxCalibrationSourceDbm.TextChanged += new System.EventHandler(this.TextBoxCalibrationSourceDbm_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Signal Source dBm";
            // 
            // ButtonCalibrationStart
            // 
            this.ButtonCalibrationStart.Location = new System.Drawing.Point(218, 239);
            this.ButtonCalibrationStart.Name = "ButtonCalibrationStart";
            this.ButtonCalibrationStart.Size = new System.Drawing.Size(87, 33);
            this.ButtonCalibrationStart.TabIndex = 0;
            this.ButtonCalibrationStart.Text = "Start";
            this.ButtonCalibrationStart.UseVisualStyleBackColor = true;
            this.ButtonCalibrationStart.Click += new System.EventHandler(this.ButtonCalibrationStart_Click);
            // 
            // Button_CSVFileStorage_Next
            // 
            this.Button_CSVFileStorage_Next.BackColor = System.Drawing.Color.Olive;
            this.Button_CSVFileStorage_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_CSVFileStorage_Next.Location = new System.Drawing.Point(80, 15);
            this.Button_CSVFileStorage_Next.Name = "Button_CSVFileStorage_Next";
            this.Button_CSVFileStorage_Next.Size = new System.Drawing.Size(106, 42);
            this.Button_CSVFileStorage_Next.TabIndex = 43;
            this.Button_CSVFileStorage_Next.Text = "Next Floor";
            this.ToolTip1.SetToolTip(this.Button_CSVFileStorage_Next, "Decrement or Increment the Collection Floor Number.");
            this.Button_CSVFileStorage_Next.UseVisualStyleBackColor = false;
            this.Button_CSVFileStorage_Next.Click += new System.EventHandler(this.Button_CSVFileStorage_CollectionFloor_AutoNext_Click);
            // 
            // Button_CSVFileStorage_ResetFloorAndMarkers
            // 
            this.Button_CSVFileStorage_ResetFloorAndMarkers.BackColor = System.Drawing.SystemColors.Control;
            this.Button_CSVFileStorage_ResetFloorAndMarkers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button_CSVFileStorage_ResetFloorAndMarkers.Location = new System.Drawing.Point(407, 4);
            this.Button_CSVFileStorage_ResetFloorAndMarkers.Name = "Button_CSVFileStorage_ResetFloorAndMarkers";
            this.Button_CSVFileStorage_ResetFloorAndMarkers.Size = new System.Drawing.Size(113, 68);
            this.Button_CSVFileStorage_ResetFloorAndMarkers.TabIndex = 46;
            this.Button_CSVFileStorage_ResetFloorAndMarkers.Text = "Reset Floor Markers";
            this.ToolTip1.SetToolTip(this.Button_CSVFileStorage_ResetFloorAndMarkers, "Resets only the Collection Floor and Collection Marker fields to 1.");
            this.Button_CSVFileStorage_ResetFloorAndMarkers.UseVisualStyleBackColor = false;
            this.Button_CSVFileStorage_ResetFloorAndMarkers.Click += new System.EventHandler(this.Button_CSVFileStorage_ResetFloorAndMarkers_Click);
            // 
            // TextBox_CSVFileStorage_Client
            // 
            this.TextBox_CSVFileStorage_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_CSVFileStorage_Client.Location = new System.Drawing.Point(8, 27);
            this.TextBox_CSVFileStorage_Client.Name = "TextBox_CSVFileStorage_Client";
            this.TextBox_CSVFileStorage_Client.Size = new System.Drawing.Size(341, 26);
            this.TextBox_CSVFileStorage_Client.TabIndex = 20;
            this.TextBox_CSVFileStorage_Client.Text = "Client Name";
            this.ToolTip1.SetToolTip(this.TextBox_CSVFileStorage_Client, "Enter a short client description. This text will create a CSV file subdirectory  " +
        "under the user\'s \'Desktop/RFEOnSite Data\' directory.");
            this.TextBox_CSVFileStorage_Client.TextChanged += new System.EventHandler(this.TextBoxClient_TextChanged);
            // 
            // GroupBox_CSVFileStorage
            // 
            this.GroupBox_CSVFileStorage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox_CSVFileStorage.Controls.Add(this.Button_CSVFileStorage_ResetFloorAndMarkers);
            this.GroupBox_CSVFileStorage.Controls.Add(this.Button_CSVFileStorage_ResetAllFields);
            this.GroupBox_CSVFileStorage.Controls.Add(this.CheckBox_CSVFileStorage_SaveCsvFiles);
            this.GroupBox_CSVFileStorage.Controls.Add(this.GroupBoxCsvInformation);
            this.GroupBox_CSVFileStorage.Enabled = false;
            this.GroupBox_CSVFileStorage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox_CSVFileStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_CSVFileStorage.Location = new System.Drawing.Point(14, 379);
            this.GroupBox_CSVFileStorage.Name = "GroupBox_CSVFileStorage";
            this.GroupBox_CSVFileStorage.Size = new System.Drawing.Size(526, 326);
            this.GroupBox_CSVFileStorage.TabIndex = 23;
            this.GroupBox_CSVFileStorage.TabStop = false;
            this.GroupBox_CSVFileStorage.Text = "CSV File Storage";
            // 
            // GroupBoxCsvInformation
            // 
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBox_CSVFileStorage_AutoNext);
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBox_CSVFileStorage_ClientInformation);
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBox_CSVFileStorage_CollectionFloor);
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBox_CSVFileStorage_CollectionMarker);
            this.GroupBoxCsvInformation.Enabled = false;
            this.GroupBoxCsvInformation.Location = new System.Drawing.Point(8, 51);
            this.GroupBoxCsvInformation.Name = "GroupBoxCsvInformation";
            this.GroupBoxCsvInformation.Size = new System.Drawing.Size(512, 262);
            this.GroupBoxCsvInformation.TabIndex = 46;
            this.GroupBoxCsvInformation.TabStop = false;
            // 
            // GroupBox_CSVFileStorage_AutoNext
            // 
            this.GroupBox_CSVFileStorage_AutoNext.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox_CSVFileStorage_AutoNext.Controls.Add(this.Button_CSVFileStorage_Next);
            this.GroupBox_CSVFileStorage_AutoNext.Controls.Add(this.RadioButton_CSVFileStorage_FloorIncrement);
            this.GroupBox_CSVFileStorage_AutoNext.Controls.Add(this.RadioButton_CSVFileStorage_FloorDecrement);
            this.GroupBox_CSVFileStorage_AutoNext.Location = new System.Drawing.Point(332, 121);
            this.GroupBox_CSVFileStorage_AutoNext.Name = "GroupBox_CSVFileStorage_AutoNext";
            this.GroupBox_CSVFileStorage_AutoNext.Size = new System.Drawing.Size(176, 63);
            this.GroupBox_CSVFileStorage_AutoNext.TabIndex = 0;
            this.GroupBox_CSVFileStorage_AutoNext.TabStop = false;
            // 
            // GroupBox_CSVFileStorage_ClientInformation
            // 
            this.GroupBox_CSVFileStorage_ClientInformation.Controls.Add(this.TextBox_CSVFileStorage_Client);
            this.GroupBox_CSVFileStorage_ClientInformation.Controls.Add(this.TextBox_CSVFileStorage_CollectionLocationDescription);
            this.GroupBox_CSVFileStorage_ClientInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_CSVFileStorage_ClientInformation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GroupBox_CSVFileStorage_ClientInformation.Location = new System.Drawing.Point(20, 16);
            this.GroupBox_CSVFileStorage_ClientInformation.Name = "GroupBox_CSVFileStorage_ClientInformation";
            this.GroupBox_CSVFileStorage_ClientInformation.Size = new System.Drawing.Size(358, 98);
            this.GroupBox_CSVFileStorage_ClientInformation.TabIndex = 43;
            this.GroupBox_CSVFileStorage_ClientInformation.TabStop = false;
            this.GroupBox_CSVFileStorage_ClientInformation.Text = "Client Information";
            // 
            // GroupBox_CSVFileStorage_CollectionFloor
            // 
            this.GroupBox_CSVFileStorage_CollectionFloor.Controls.Add(this.Button_CSVFileStorage_CollectionFloor_Enable);
            this.GroupBox_CSVFileStorage_CollectionFloor.Controls.Add(this.NumericUpDown_CSVFileStorage_FloorNumber);
            this.GroupBox_CSVFileStorage_CollectionFloor.Controls.Add(this.TextBox_CSVFileStorage_CollectionFloorName);
            this.GroupBox_CSVFileStorage_CollectionFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_CSVFileStorage_CollectionFloor.Location = new System.Drawing.Point(20, 121);
            this.GroupBox_CSVFileStorage_CollectionFloor.Name = "GroupBox_CSVFileStorage_CollectionFloor";
            this.GroupBox_CSVFileStorage_CollectionFloor.Size = new System.Drawing.Size(482, 63);
            this.GroupBox_CSVFileStorage_CollectionFloor.TabIndex = 42;
            this.GroupBox_CSVFileStorage_CollectionFloor.TabStop = false;
            this.GroupBox_CSVFileStorage_CollectionFloor.Text = "Collection Floor";
            // 
            // NumericUpDown_CSVFileStorage_FloorNumber
            // 
            this.NumericUpDown_CSVFileStorage_FloorNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.NumericUpDown_CSVFileStorage_FloorNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_CSVFileStorage_FloorNumber.Location = new System.Drawing.Point(151, 21);
            this.NumericUpDown_CSVFileStorage_FloorNumber.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NumericUpDown_CSVFileStorage_FloorNumber.Name = "NumericUpDown_CSVFileStorage_FloorNumber";
            this.NumericUpDown_CSVFileStorage_FloorNumber.Size = new System.Drawing.Size(59, 31);
            this.NumericUpDown_CSVFileStorage_FloorNumber.TabIndex = 39;
            this.NumericUpDown_CSVFileStorage_FloorNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDown_CSVFileStorage_FloorNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_CSVFileStorage_FloorNumber.ValueChanged += new System.EventHandler(this.NumericUpDownAutoText_ValueChanged);
            // 
            // TextBox_CSVFileStorage_CollectionFloorName
            // 
            this.TextBox_CSVFileStorage_CollectionFloorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_CSVFileStorage_CollectionFloorName.Location = new System.Drawing.Point(6, 23);
            this.TextBox_CSVFileStorage_CollectionFloorName.Name = "TextBox_CSVFileStorage_CollectionFloorName";
            this.TextBox_CSVFileStorage_CollectionFloorName.Size = new System.Drawing.Size(132, 26);
            this.TextBox_CSVFileStorage_CollectionFloorName.TabIndex = 37;
            this.TextBox_CSVFileStorage_CollectionFloorName.Text = "Floor";
            this.TextBox_CSVFileStorage_CollectionFloorName.TextChanged += new System.EventHandler(this.TextBoxFloorLabel_TextChanged);
            // 
            // GroupBox_CSVFileStorage_CollectionMarker
            // 
            this.GroupBox_CSVFileStorage_CollectionMarker.Controls.Add(this.TextBox_CSVFileStorage_CollectionMarkerName);
            this.GroupBox_CSVFileStorage_CollectionMarker.Controls.Add(this.CheckBox_CSVFileStorage_AutoIncrementMarkerNumber);
            this.GroupBox_CSVFileStorage_CollectionMarker.Controls.Add(this.NumericUpDown_CSVFileStorage_MarkerNumber);
            this.GroupBox_CSVFileStorage_CollectionMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_CSVFileStorage_CollectionMarker.Location = new System.Drawing.Point(20, 191);
            this.GroupBox_CSVFileStorage_CollectionMarker.Name = "GroupBox_CSVFileStorage_CollectionMarker";
            this.GroupBox_CSVFileStorage_CollectionMarker.Size = new System.Drawing.Size(333, 63);
            this.GroupBox_CSVFileStorage_CollectionMarker.TabIndex = 37;
            this.GroupBox_CSVFileStorage_CollectionMarker.TabStop = false;
            this.GroupBox_CSVFileStorage_CollectionMarker.Text = "Collection Marker";
            // 
            // TextBox_CSVFileStorage_CollectionMarkerName
            // 
            this.TextBox_CSVFileStorage_CollectionMarkerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_CSVFileStorage_CollectionMarkerName.Location = new System.Drawing.Point(6, 27);
            this.TextBox_CSVFileStorage_CollectionMarkerName.Name = "TextBox_CSVFileStorage_CollectionMarkerName";
            this.TextBox_CSVFileStorage_CollectionMarkerName.Size = new System.Drawing.Size(132, 26);
            this.TextBox_CSVFileStorage_CollectionMarkerName.TabIndex = 30;
            this.TextBox_CSVFileStorage_CollectionMarkerName.Text = "M";
            this.TextBox_CSVFileStorage_CollectionMarkerName.TextChanged += new System.EventHandler(this.TextBoxCollectionSite_TextChanged);
            // 
            // NumericUpDown_CSVFileStorage_MarkerNumber
            // 
            this.NumericUpDown_CSVFileStorage_MarkerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_CSVFileStorage_MarkerNumber.Location = new System.Drawing.Point(151, 25);
            this.NumericUpDown_CSVFileStorage_MarkerNumber.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NumericUpDown_CSVFileStorage_MarkerNumber.Name = "NumericUpDown_CSVFileStorage_MarkerNumber";
            this.NumericUpDown_CSVFileStorage_MarkerNumber.Size = new System.Drawing.Size(59, 31);
            this.NumericUpDown_CSVFileStorage_MarkerNumber.TabIndex = 18;
            this.NumericUpDown_CSVFileStorage_MarkerNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDown_CSVFileStorage_MarkerNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_CSVFileStorage_MarkerNumber.ValueChanged += new System.EventHandler(this.NumericUpDownLocation_ValueChanged);
            // 
            // LabelCopyright
            // 
            this.LabelCopyright.AutoSize = true;
            this.LabelCopyright.BackColor = System.Drawing.SystemColors.Control;
            this.LabelCopyright.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelCopyright.Location = new System.Drawing.Point(993, 717);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(145, 13);
            this.LabelCopyright.TabIndex = 25;
            this.LabelCopyright.Text = "Copyright 2025 - Redevi, Inc.";
            // 
            // MenuStripMainForm
            // 
            this.MenuStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripMenuItemFile,
            this.uSBSettingsToolStripMenuItem});
            this.MenuStripMainForm.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMainForm.Name = "MenuStripMainForm";
            this.MenuStripMainForm.Size = new System.Drawing.Size(1149, 24);
            this.MenuStripMainForm.TabIndex = 26;
            this.MenuStripMainForm.Text = "menuStrip1";
            // 
            // MenuStripMenuItemFile
            // 
            this.MenuStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripMenuItemPreset,
            this.aboutToolStripMenuItem});
            this.MenuStripMenuItemFile.Name = "MenuStripMenuItemFile";
            this.MenuStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.MenuStripMenuItemFile.Text = "File";
            // 
            // MenuStripMenuItemPreset
            // 
            this.MenuStripMenuItemPreset.Name = "MenuStripMenuItemPreset";
            this.MenuStripMenuItemPreset.Size = new System.Drawing.Size(107, 22);
            this.MenuStripMenuItemPreset.Text = "Exit";
            this.MenuStripMenuItemPreset.Click += new System.EventHandler(this.MenuStripMenuItemPreset_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // uSBSettingsToolStripMenuItem
            // 
            this.uSBSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.force2400BaudToolStripMenuItem});
            this.uSBSettingsToolStripMenuItem.Name = "uSBSettingsToolStripMenuItem";
            this.uSBSettingsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.uSBSettingsToolStripMenuItem.Text = "USB Settings";
            // 
            // force2400BaudToolStripMenuItem
            // 
            this.force2400BaudToolStripMenuItem.AutoToolTip = true;
            this.force2400BaudToolStripMenuItem.BackColor = System.Drawing.Color.Yellow;
            this.force2400BaudToolStripMenuItem.CheckOnClick = true;
            this.force2400BaudToolStripMenuItem.Name = "force2400BaudToolStripMenuItem";
            this.force2400BaudToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.force2400BaudToolStripMenuItem.Text = "Force 2400 Baud";
            this.force2400BaudToolStripMenuItem.ToolTipText = "Use as a last resort. This will result in very slow scans. \n\nYou must also manual" +
    "ly set 2.4 kbps in the RF Explorer USB Baud configuration menu.\n\nNote that this " +
    "setting is PERSISTED.";
            // 
            // StripStatusMainForm
            // 
            this.StripStatusMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatusLabelPreset,
            this.StripStatusLabelDivision1,
            this.StripStatusLabelCsvDirectory,
            this.toolStripStatusLabel1});
            this.StripStatusMainForm.Location = new System.Drawing.Point(0, 712);
            this.StripStatusMainForm.Name = "StripStatusMainForm";
            this.StripStatusMainForm.Size = new System.Drawing.Size(1149, 22);
            this.StripStatusMainForm.TabIndex = 38;
            this.StripStatusMainForm.Text = "StatusStripMainForm";
            // 
            // StripStatusLabelPreset
            // 
            this.StripStatusLabelPreset.Name = "StripStatusLabelPreset";
            this.StripStatusLabelPreset.Size = new System.Drawing.Size(10, 17);
            this.StripStatusLabelPreset.Text = " ";
            // 
            // StripStatusLabelDivision1
            // 
            this.StripStatusLabelDivision1.Name = "StripStatusLabelDivision1";
            this.StripStatusLabelDivision1.Size = new System.Drawing.Size(0, 17);
            // 
            // StripStatusLabelCsvDirectory
            // 
            this.StripStatusLabelCsvDirectory.Name = "StripStatusLabelCsvDirectory";
            this.StripStatusLabelCsvDirectory.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1149, 734);
            this.Controls.Add(this.LabelCopyright);
            this.Controls.Add(this.StripStatusMainForm);
            this.Controls.Add(this.TabControl_Main);
            this.Controls.Add(this.GroupBox_ReceivedSignalStrength);
            this.Controls.Add(this.GroupBox_SweepControl);
            this.Controls.Add(this.GroupBox_CSVFileStorage);
            this.Controls.Add(this.MenuStripMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.MenuStripMainForm;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "RFE OnSite";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_SweepControl_VariationSweeps)).EndInit();
            this.GroupBox_SweepControl.ResumeLayout(false);
            this.GroupBox_SweepControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_SweepControl_UserSweeps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_SweepControl_VariationDb)).EndInit();
            this.GroupBox_ReceivedSignalStrength.ResumeLayout(false);
            this.GroupBox_ReceivedSignalStrength.PerformLayout();
            this.TabControl_Main.ResumeLayout(false);
            this.TabControl_Main_Connection.ResumeLayout(false);
            this.TabControl_Main_Connection.PerformLayout();
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.ResumeLayout(false);
            this.GroupBox_Connection_DocumentationAndUSBTroubleShooting.PerformLayout();
            this.TabControl_Main_OmniDirectional.ResumeLayout(false);
            this.GroupBox_OmniDirectional_CurrentConfiguration.ResumeLayout(false);
            this.GroupBox_OmniDirectional_CurrentConfiguration.PerformLayout();
            this.TabControl_Main_Radial.ResumeLayout(false);
            this.TabControl_Main_Radial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRadialAzimuth)).EndInit();
            this.TabControl_Main_LocationCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_LocationCamera)).EndInit();
            this.TabControl_Main_Calibration.ResumeLayout(false);
            this.TabControl_Main_Calibration.PerformLayout();
            this.GroupBox_CSVFileStorage.ResumeLayout(false);
            this.GroupBox_CSVFileStorage.PerformLayout();
            this.GroupBoxCsvInformation.ResumeLayout(false);
            this.GroupBox_CSVFileStorage_AutoNext.ResumeLayout(false);
            this.GroupBox_CSVFileStorage_AutoNext.PerformLayout();
            this.GroupBox_CSVFileStorage_ClientInformation.ResumeLayout(false);
            this.GroupBox_CSVFileStorage_ClientInformation.PerformLayout();
            this.GroupBox_CSVFileStorage_CollectionFloor.ResumeLayout(false);
            this.GroupBox_CSVFileStorage_CollectionFloor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CSVFileStorage_FloorNumber)).EndInit();
            this.GroupBox_CSVFileStorage_CollectionMarker.ResumeLayout(false);
            this.GroupBox_CSVFileStorage_CollectionMarker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CSVFileStorage_MarkerNumber)).EndInit();
            this.MenuStripMainForm.ResumeLayout(false);
            this.MenuStripMainForm.PerformLayout();
            this.StripStatusMainForm.ResumeLayout(false);
            this.StripStatusMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


         

        private Button Button_Connection_ConnectExplorer;
        private Button ButtonStartSweeps;
        private GroupBox GroupBox_SweepControl;
        private Label Label_Connection_DeviceIDValue;
        private Label Label_Connection_ModelIDValue;
        private Label Label_Connection_Firmware;
        private Label Label_Connection_FirmwareValue;
        private Label Label_Connection_ComPortValue;
        private Label Label_SweepControl_VariationVariation;
        private NumericUpDown NumericUpDown_SweepControl_VariationSweeps;
        private ProgressBar TaskProgressBar;
        private CheckBox CheckBox_CSVFileStorage_SaveCsvFiles;
        private CheckBox CheckBox_ReceivedSignalStrength_ChartAutoScale;
        private Label Label_Connection_DeviceID;
        private Label Label_Connection_ModelID;
        private ToolTip ToolTip1;
        private GroupBox GroupBox_CSVFileStorage;
        private TextBox TextBoxCsvFileName;
        private TextBox TextBox_CSVFileStorage_CollectionLocationDescription;
        private RadioButton RadioButton_Connection_SetSignalGenerator;
        private RadioButton RadioButton_Connection_SetSpectrumAnalyzer;
        private Label LabelProgressWriteCsvFile;
        private Button Button_Connection_Documentation;
        private Label LabelCopyright;
        private Button ButtonCancelSweeps;
        private Label LabelExecutingTask;
        private Label LabelExecTask;
        private CheckBox CheckBoxRadialAzimuth;
        private NumericUpDown NumericUpDown_CSVFileStorage_MarkerNumber;
        private TextBox TextBox_CSVFileStorage_CollectionMarkerName;
        private CheckBox CheckBox_CSVFileStorage_AutoIncrementMarkerNumber;
        private TextBox TextBox_CSVFileStorage_Client;
        private GroupBox GroupBox_OmniDirectional_CurrentConfiguration;
        private Button Button_CurrentConfiguration_GetRfeConfiguration;
        private Label Label_CurrentConfiguration_Presets;
        private ComboBox ComboBox_CurrentConfiguration_Preset;
        private Label Label_CurrentConfiguration_RightAntennaGaindB;
        private TextBox TextBox_CurrentConfiguration_RightAntennaGain;
        private Label Label_CurrentConfiguration_RightAntennaGain;
        private Label Label_CurrentConfiguration_LeftAntennaGaindB;
        private TextBox TextBox_CurrentConfiguration_LeftAntennaGain;
        private Label Label_CurrentConfiguration_LeftAntennaGain;
        private TextBox TextBox_CurrentConfiguration_StepFrequency;
        private TextBox TextBoxRBW;
        private Label LabelStopFrequencyUnit;
        private Label LabelStartFrequencyUnit;
        private Button Button_CurrentConfiguration_SetRfeConfiguration;
        private Label LabelFrequencyStepUnit;
        private Label LabelStartFrequency;
        private Label LabelFrequencyStep;
        private TextBox TextBox_CurrentConfiguration_StartFrequency;
        private TextBox TextBox_CurrentConfiguration_StopFrequency;
        private Label LabelStopFrequency;
        private Label LabelRBWUnit;
        private Label LabelRBW;
        private Label LabelRadialAzimuth;
        private NumericUpDown NumericUpDownRadialAzimuth;
        private MenuStrip MenuStripMainForm;
        private ToolStripMenuItem MenuStripMenuItemFile;
        private ToolStripMenuItem MenuStripMenuItemPreset;
        private TextBox TextBox_CSVFileStorage_CollectionFloorName;
        private GroupBox GroupBox_CSVFileStorage_CollectionFloor;
        private RadioButton RadioButton_CSVFileStorage_FloorIncrement;
        private RadioButton RadioButton_CSVFileStorage_FloorDecrement;
        private NumericUpDown NumericUpDown_CSVFileStorage_FloorNumber;
        private GroupBox GroupBox_CSVFileStorage_CollectionMarker;
        private TabControl TabControl_Main;
        private TabPage TabControl_Main_Connection;
        private TabPage TabControl_Main_OmniDirectional;
        private TabPage TabControl_Main_Radial;
        private Label LabelTrueNorthText;
        private Label Label_Connection_ComPortText;
        private GroupBox GroupBox_CSVFileStorage_ClientInformation;
        private Button Button_CSVFileStorage_CollectionFloor_Enable;
        private TabPage TabControl_Main_LocationCamera;
        private PictureBox PictureBox_LocationCamera;
        private Button Button_CSVFileStorage_ResetAllFields;
        private StatusStrip StripStatusMainForm;
        private GroupBox GroupBoxCsvInformation;
        private GroupBox GroupBox_ReceivedSignalStrength;
        private Panel PanelChart;
        private ToolStripStatusLabel StripStatusLabelPreset;
        private ToolStripStatusLabel StripStatusLabelCsvDirectory;
        private ToolStripStatusLabel StripStatusLabelDivision1;
        private Button Button_Connection_UsbTroubleShooting;
        private Button Button_Connection_USBDriverDownload;
        private GroupBox GroupBox_Connection_DocumentationAndUSBTroubleShooting;
        private ToolStripMenuItem uSBSettingsToolStripMenuItem;
        private ToolStripMenuItem force2400BaudToolStripMenuItem;
        private TabPage TabControl_Main_Calibration;
        private Button ButtonCalibrationStart;
        private TextBox TextBoxCalibrationPointsPerSweepInterval;
        private Label label2;
        private TextBox TextBoxCalibrationSourceDbm;
        private Label label1;
        private Button Button_LocationCamera_PauseResume;
        private Button Button_CSVFileStorage_Next;
        private GroupBox GroupBox_CSVFileStorage_AutoNext;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button Button_CSVFileStorage_ResetFloorAndMarkers;
        private Label Label_LocationCamera_Marker;
        private Label Label_LocationCamera_Floor;
        private Button Button_LocationCamera_CaptureFrame;
        private CheckBox CheckBox_Band_PCS;
        private CheckBox CheckBox_Band_600;
        private CheckBox CheckBox_Band_WCS;
        private CheckBox CheckBox_Band_AWS;
        private CheckBox CheckBox_Band_CEL;
        private CheckBox CheckBox_Band_700;
        private NumericUpDown NumericUpDown_SweepControl_VariationDb;
        private Label Label_SweepControl_VariationSweeps;
        private Label Label_SweepControl_Variation_DbOver;
        private NumericUpDown NumericUpDown_SweepControl_UserSweeps;
        private Label Label_SweepControl_UserMaximum;
        private Label Label_SweepControl_UserSweeps;
        private Button Button_FirmwareUpdate;
    }
}

