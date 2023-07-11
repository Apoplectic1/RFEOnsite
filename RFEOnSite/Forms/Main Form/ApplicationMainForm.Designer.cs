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
            this.Button_ConnectRFExplorer = new System.Windows.Forms.Button();
            this.Label_ComPortValue = new System.Windows.Forms.Label();
            this.CheckBoxRadialAzimuth = new System.Windows.Forms.CheckBox();
            this.Button_REEDocumentation = new System.Windows.Forms.Button();
            this.RadioButton_SignalGenerator = new System.Windows.Forms.RadioButton();
            this.RadioButton_SpectrumAnalyzer = new System.Windows.Forms.RadioButton();
            this.Label_Model = new System.Windows.Forms.Label();
            this.Label_Device = new System.Windows.Forms.Label();
            this.Label_FirmwareValue = new System.Windows.Forms.Label();
            this.Label_Firmware = new System.Windows.Forms.Label();
            this.Label_ModelValue = new System.Windows.Forms.Label();
            this.Label_DeviceValue = new System.Windows.Forms.Label();
            this.ButtonStartSweeps = new System.Windows.Forms.Button();
            this.LabelStartSweeps = new System.Windows.Forms.Label();
            this.NumericUpDownSweeps = new System.Windows.Forms.NumericUpDown();
            this.GroupBox_SweepControl = new System.Windows.Forms.GroupBox();
            this.LabelActualSweeps = new System.Windows.Forms.Label();
            this.LabelTaskCount = new System.Windows.Forms.Label();
            this.LabelExecTask = new System.Windows.Forms.Label();
            this.ButtonCancelSweeps = new System.Windows.Forms.Button();
            this.LabelProgressWriteCsvFile = new System.Windows.Forms.Label();
            this.TaskProgressBar = new System.Windows.Forms.ProgressBar();
            this.TextBoxCsvFileName = new System.Windows.Forms.TextBox();
            this.CheckBoxSaveCsvFiles = new System.Windows.Forms.CheckBox();
            this.CheckBoxChartPeak = new System.Windows.Forms.CheckBox();
            this.CheckBoxChartAverage = new System.Windows.Forms.CheckBox();
            this.CheckBoxChartAutoScale = new System.Windows.Forms.CheckBox();
            this.GroupBox_ReceivedSignalStrength = new System.Windows.Forms.GroupBox();
            this.PanelChart = new System.Windows.Forms.Panel();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TextBoxCollectionLocation = new System.Windows.Forms.TextBox();
            this.LabelRBW = new System.Windows.Forms.Label();
            this.ButtonSetConfiguration = new System.Windows.Forms.Button();
            this.TextBoxRBW = new System.Windows.Forms.TextBox();
            this.ComboBoxPreset = new System.Windows.Forms.ComboBox();
            this.ButtonGetRfeConfiguration = new System.Windows.Forms.Button();
            this.LabelStopFrequency = new System.Windows.Forms.Label();
            this.ButtonCaptureImage = new System.Windows.Forms.Button();
            this.ButtonPersistClear = new System.Windows.Forms.Button();
            this.Button_CSVFileStorage_CollectionFloor_Enable = new System.Windows.Forms.Button();
            this.RadioButton_CSVFileStorage_FloorIncrement = new System.Windows.Forms.RadioButton();
            this.RadioButton_CSVFileStorage_FloorDecrement = new System.Windows.Forms.RadioButton();
            this.CheckBoxAutoIncrementMarkerNumber = new System.Windows.Forms.CheckBox();
            this.CheckBoxHoldStep = new System.Windows.Forms.CheckBox();
            this.CheckBoxHoldStop = new System.Windows.Forms.CheckBox();
            this.CheckBoxHoldStart = new System.Windows.Forms.CheckBox();
            this.LabelStartFrequency = new System.Windows.Forms.Label();
            this.LabelFrequencyStep = new System.Windows.Forms.Label();
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabControlMainConnection = new System.Windows.Forms.TabPage();
            this.Label_ComPortText = new System.Windows.Forms.Label();
            this.GroupBox_DocumentationAndUSBTroubleShooting = new System.Windows.Forms.GroupBox();
            this.Button_USBTroubleShooting = new System.Windows.Forms.Button();
            this.Button_USBDriverDownload = new System.Windows.Forms.Button();
            this.TabControlMainOmniDirectional = new System.Windows.Forms.TabPage();
            this.GroupBox_OmniDirectional_CurrentConfiguration = new System.Windows.Forms.GroupBox();
            this.LabelRBWUnit = new System.Windows.Forms.Label();
            this.LabelPresets = new System.Windows.Forms.Label();
            this.LabelRightAntennaGainUnit = new System.Windows.Forms.Label();
            this.TextBoxRightAntennaGain = new System.Windows.Forms.TextBox();
            this.LabelRightAntennaGain = new System.Windows.Forms.Label();
            this.LabelLeftAntennaGainUnit = new System.Windows.Forms.Label();
            this.TextBoxLeftAntennaGain = new System.Windows.Forms.TextBox();
            this.LabelLeftAntennaGain = new System.Windows.Forms.Label();
            this.TextBoxStepFrequency = new System.Windows.Forms.TextBox();
            this.LabelStopFrequencyUnit = new System.Windows.Forms.Label();
            this.LabelStartFrequencyUnit = new System.Windows.Forms.Label();
            this.LabelFrequencyStepUnit = new System.Windows.Forms.Label();
            this.TextBoxStartFrequency = new System.Windows.Forms.TextBox();
            this.TextBoxStopFrequency = new System.Windows.Forms.TextBox();
            this.TabControlMainRadial = new System.Windows.Forms.TabPage();
            this.LabelRadialAzimuth = new System.Windows.Forms.Label();
            this.LabelTrueNorthText = new System.Windows.Forms.Label();
            this.NumericUpDownRadialAzimuth = new System.Windows.Forms.NumericUpDown();
            this.TabControlSiteImage = new System.Windows.Forms.TabPage();
            this.ButtonPauseResume = new System.Windows.Forms.Button();
            this.LabelCaptured = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.TabControlCalibration = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxCalibrationPointsPerSweepInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxCalibrationSourceDbm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonCalibrationStart = new System.Windows.Forms.Button();
            this.Button_CSVFileStorage_Next = new System.Windows.Forms.Button();
            this.GroupBox_CSVFileStorage = new System.Windows.Forms.GroupBox();
            this.GroupBoxCsvInformation = new System.Windows.Forms.GroupBox();
            this.GroupBox_CSVFileStorage_AutoNext = new System.Windows.Forms.GroupBox();
            this.GroupBoxClientId = new System.Windows.Forms.GroupBox();
            this.TextBoxClient = new System.Windows.Forms.TextBox();
            this.GroupBoxFloorId = new System.Windows.Forms.GroupBox();
            this.NumericUpDown_CSVFileStorage_FloorNumber = new System.Windows.Forms.NumericUpDown();
            this.TextBox_CSVFileStorage_CollectionFloorName = new System.Windows.Forms.TextBox();
            this.GroupBox_CSVFileStorage_CollectionMarker = new System.Windows.Forms.GroupBox();
            this.TextBox_CSVFileStorage_CollectionMarkerName = new System.Windows.Forms.TextBox();
            this.NumericUpDown_CSVFileStorage_MarkerNumber = new System.Windows.Forms.NumericUpDown();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.MenuStripMainForm = new System.Windows.Forms.MenuStrip();
            this.MenuStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripMenuItemPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.force2400BaudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripStatusMainForm = new System.Windows.Forms.StatusStrip();
            this.StripStatusLabelPreset = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatusLabelDivision1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatusLabelCsvDirectory = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSweeps)).BeginInit();
            this.GroupBox_SweepControl.SuspendLayout();
            this.GroupBox_ReceivedSignalStrength.SuspendLayout();
            this.TabControlMain.SuspendLayout();
            this.TabControlMainConnection.SuspendLayout();
            this.GroupBox_DocumentationAndUSBTroubleShooting.SuspendLayout();
            this.TabControlMainOmniDirectional.SuspendLayout();
            this.GroupBox_OmniDirectional_CurrentConfiguration.SuspendLayout();
            this.TabControlMainRadial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRadialAzimuth)).BeginInit();
            this.TabControlSiteImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.TabControlCalibration.SuspendLayout();
            this.GroupBox_CSVFileStorage.SuspendLayout();
            this.GroupBoxCsvInformation.SuspendLayout();
            this.GroupBox_CSVFileStorage_AutoNext.SuspendLayout();
            this.GroupBoxClientId.SuspendLayout();
            this.GroupBoxFloorId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CSVFileStorage_FloorNumber)).BeginInit();
            this.GroupBox_CSVFileStorage_CollectionMarker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CSVFileStorage_MarkerNumber)).BeginInit();
            this.MenuStripMainForm.SuspendLayout();
            this.StripStatusMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_ConnectRFExplorer
            // 
            this.Button_ConnectRFExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(197)))), ((int)(((byte)(202)))), ((int)(((byte)(31)))));
            this.Button_ConnectRFExplorer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Button_ConnectRFExplorer.FlatAppearance.BorderSize = 5;
            this.Button_ConnectRFExplorer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Button_ConnectRFExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Button_ConnectRFExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_ConnectRFExplorer.Location = new System.Drawing.Point(81, 36);
            this.Button_ConnectRFExplorer.Name = "Button_ConnectRFExplorer";
            this.Button_ConnectRFExplorer.Size = new System.Drawing.Size(155, 73);
            this.Button_ConnectRFExplorer.TabIndex = 0;
            this.Button_ConnectRFExplorer.Text = "Connect RF Explorer";
            this.ToolTip1.SetToolTip(this.Button_ConnectRFExplorer, "Connects a USB RF Explorer/Generator to this application. Close the application t" +
        "o disconnect.");
            this.Button_ConnectRFExplorer.UseVisualStyleBackColor = false;
            this.Button_ConnectRFExplorer.Click += new System.EventHandler(this.ButtonFindPorts_Click);
            // 
            // Label_ComPortValue
            // 
            this.Label_ComPortValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_ComPortValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_ComPortValue.Location = new System.Drawing.Point(365, 33);
            this.Label_ComPortValue.Name = "Label_ComPortValue";
            this.Label_ComPortValue.Size = new System.Drawing.Size(124, 22);
            this.Label_ComPortValue.TabIndex = 1;
            this.Label_ComPortValue.Text = "Not Connected";
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
            // Button_REEDocumentation
            // 
            this.Button_REEDocumentation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_REEDocumentation.Location = new System.Drawing.Point(35, 29);
            this.Button_REEDocumentation.Name = "Button_REEDocumentation";
            this.Button_REEDocumentation.Size = new System.Drawing.Size(179, 51);
            this.Button_REEDocumentation.TabIndex = 16;
            this.Button_REEDocumentation.Text = "RF Explorer Documentation";
            this.Button_REEDocumentation.UseVisualStyleBackColor = true;
            this.Button_REEDocumentation.Click += new System.EventHandler(this.ButtonDocumentation_Click);
            // 
            // RadioButton_SignalGenerator
            // 
            this.RadioButton_SignalGenerator.AutoSize = true;
            this.RadioButton_SignalGenerator.BackColor = System.Drawing.Color.Transparent;
            this.RadioButton_SignalGenerator.Location = new System.Drawing.Point(247, 56);
            this.RadioButton_SignalGenerator.Name = "RadioButton_SignalGenerator";
            this.RadioButton_SignalGenerator.Size = new System.Drawing.Size(148, 24);
            this.RadioButton_SignalGenerator.TabIndex = 15;
            this.RadioButton_SignalGenerator.Text = "Signal Generator";
            this.RadioButton_SignalGenerator.UseVisualStyleBackColor = false;
            this.RadioButton_SignalGenerator.CheckedChanged += new System.EventHandler(this.RadioButtonGenerator_CheckedChanged);
            // 
            // RadioButton_SpectrumAnalyzer
            // 
            this.RadioButton_SpectrumAnalyzer.AutoSize = true;
            this.RadioButton_SpectrumAnalyzer.BackColor = System.Drawing.Color.Transparent;
            this.RadioButton_SpectrumAnalyzer.Checked = true;
            this.RadioButton_SpectrumAnalyzer.Location = new System.Drawing.Point(247, 29);
            this.RadioButton_SpectrumAnalyzer.Name = "RadioButton_SpectrumAnalyzer";
            this.RadioButton_SpectrumAnalyzer.Size = new System.Drawing.Size(161, 24);
            this.RadioButton_SpectrumAnalyzer.TabIndex = 14;
            this.RadioButton_SpectrumAnalyzer.TabStop = true;
            this.RadioButton_SpectrumAnalyzer.Text = "Spectrum Analyzer";
            this.RadioButton_SpectrumAnalyzer.UseVisualStyleBackColor = false;
            this.RadioButton_SpectrumAnalyzer.CheckedChanged += new System.EventHandler(this.RadioButtonAnalyzer_CheckedChanged);
            // 
            // Label_Model
            // 
            this.Label_Model.AutoSize = true;
            this.Label_Model.BackColor = System.Drawing.Color.Transparent;
            this.Label_Model.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Model.Location = new System.Drawing.Point(301, 91);
            this.Label_Model.Name = "Label_Model";
            this.Label_Model.Size = new System.Drawing.Size(56, 20);
            this.Label_Model.TabIndex = 13;
            this.Label_Model.Text = "Model:";
            this.ToolTip1.SetToolTip(this.Label_Model, "This RF Explorer Model ID.");
            // 
            // Label_Device
            // 
            this.Label_Device.AutoSize = true;
            this.Label_Device.BackColor = System.Drawing.Color.Transparent;
            this.Label_Device.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Device.Location = new System.Drawing.Point(298, 72);
            this.Label_Device.Name = "Label_Device";
            this.Label_Device.Size = new System.Drawing.Size(61, 20);
            this.Label_Device.TabIndex = 12;
            this.Label_Device.Text = "Device:";
            this.ToolTip1.SetToolTip(this.Label_Device, "This RF Explorer Device ID.");
            // 
            // Label_FirmwareValue
            // 
            this.Label_FirmwareValue.AutoSize = true;
            this.Label_FirmwareValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_FirmwareValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_FirmwareValue.Location = new System.Drawing.Point(365, 53);
            this.Label_FirmwareValue.Name = "Label_FirmwareValue";
            this.Label_FirmwareValue.Size = new System.Drawing.Size(35, 20);
            this.Label_FirmwareValue.TabIndex = 5;
            this.Label_FirmwareValue.Text = "N/A";
            this.Label_FirmwareValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Firmware
            // 
            this.Label_Firmware.AutoSize = true;
            this.Label_Firmware.BackColor = System.Drawing.Color.Transparent;
            this.Label_Firmware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Firmware.Location = new System.Drawing.Point(279, 53);
            this.Label_Firmware.Name = "Label_Firmware";
            this.Label_Firmware.Size = new System.Drawing.Size(78, 20);
            this.Label_Firmware.TabIndex = 4;
            this.Label_Firmware.Text = "Firmware:";
            this.ToolTip1.SetToolTip(this.Label_Firmware, "This RF Explorer firmware version.");
            // 
            // Label_ModelValue
            // 
            this.Label_ModelValue.AutoSize = true;
            this.Label_ModelValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_ModelValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_ModelValue.Location = new System.Drawing.Point(365, 91);
            this.Label_ModelValue.Name = "Label_ModelValue";
            this.Label_ModelValue.Size = new System.Drawing.Size(35, 20);
            this.Label_ModelValue.TabIndex = 3;
            this.Label_ModelValue.Text = "N/A";
            // 
            // Label_DeviceValue
            // 
            this.Label_DeviceValue.AutoSize = true;
            this.Label_DeviceValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_DeviceValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_DeviceValue.Location = new System.Drawing.Point(365, 72);
            this.Label_DeviceValue.Name = "Label_DeviceValue";
            this.Label_DeviceValue.Size = new System.Drawing.Size(35, 20);
            this.Label_DeviceValue.TabIndex = 2;
            this.Label_DeviceValue.Text = "N/A";
            // 
            // ButtonStartSweeps
            // 
            this.ButtonStartSweeps.BackColor = System.Drawing.Color.ForestGreen;
            this.ButtonStartSweeps.Enabled = false;
            this.ButtonStartSweeps.FlatAppearance.BorderSize = 3;
            this.ButtonStartSweeps.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen;
            this.ButtonStartSweeps.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonStartSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStartSweeps.Location = new System.Drawing.Point(69, 60);
            this.ButtonStartSweeps.Name = "ButtonStartSweeps";
            this.ButtonStartSweeps.Size = new System.Drawing.Size(114, 49);
            this.ButtonStartSweeps.TabIndex = 13;
            this.ButtonStartSweeps.Text = "Capture";
            this.ToolTip1.SetToolTip(this.ButtonStartSweeps, resources.GetString("ButtonStartSweeps.ToolTip"));
            this.ButtonStartSweeps.UseVisualStyleBackColor = false;
            this.ButtonStartSweeps.Click += new System.EventHandler(this.ButtonStartSweeps_Click);
            // 
            // LabelStartSweeps
            // 
            this.LabelStartSweeps.AutoSize = true;
            this.LabelStartSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStartSweeps.Location = new System.Drawing.Point(16, 27);
            this.LabelStartSweeps.Name = "LabelStartSweeps";
            this.LabelStartSweeps.Size = new System.Drawing.Size(94, 25);
            this.LabelStartSweeps.TabIndex = 14;
            this.LabelStartSweeps.Text = "Sweeps:";
            this.ToolTip1.SetToolTip(this.LabelStartSweeps, "Fill each FFT bin with the selected number of samples.");
            // 
            // NumericUpDownSweeps
            // 
            this.NumericUpDownSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDownSweeps.Location = new System.Drawing.Point(118, 23);
            this.NumericUpDownSweeps.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDownSweeps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownSweeps.Name = "NumericUpDownSweeps";
            this.NumericUpDownSweeps.Size = new System.Drawing.Size(91, 31);
            this.NumericUpDownSweeps.TabIndex = 15;
            this.NumericUpDownSweeps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDownSweeps.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // GroupBox_SweepControl
            // 
            this.GroupBox_SweepControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox_SweepControl.Controls.Add(this.LabelActualSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.LabelTaskCount);
            this.GroupBox_SweepControl.Controls.Add(this.LabelExecTask);
            this.GroupBox_SweepControl.Controls.Add(this.ButtonCancelSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.LabelProgressWriteCsvFile);
            this.GroupBox_SweepControl.Controls.Add(this.TaskProgressBar);
            this.GroupBox_SweepControl.Controls.Add(this.LabelStartSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.ButtonStartSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.NumericUpDownSweeps);
            this.GroupBox_SweepControl.Controls.Add(this.TextBoxCsvFileName);
            this.GroupBox_SweepControl.Enabled = false;
            this.GroupBox_SweepControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_SweepControl.Location = new System.Drawing.Point(550, 490);
            this.GroupBox_SweepControl.Name = "GroupBox_SweepControl";
            this.GroupBox_SweepControl.Size = new System.Drawing.Size(437, 215);
            this.GroupBox_SweepControl.TabIndex = 16;
            this.GroupBox_SweepControl.TabStop = false;
            this.GroupBox_SweepControl.Text = "Sweep Control";
            // 
            // LabelActualSweeps
            // 
            this.LabelActualSweeps.AutoSize = true;
            this.LabelActualSweeps.Location = new System.Drawing.Point(379, 144);
            this.LabelActualSweeps.Name = "LabelActualSweeps";
            this.LabelActualSweeps.Size = new System.Drawing.Size(0, 20);
            this.LabelActualSweeps.TabIndex = 21;
            this.LabelActualSweeps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelTaskCount
            // 
            this.LabelTaskCount.AutoSize = true;
            this.LabelTaskCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTaskCount.Location = new System.Drawing.Point(353, 30);
            this.LabelTaskCount.Name = "LabelTaskCount";
            this.LabelTaskCount.Size = new System.Drawing.Size(39, 20);
            this.LabelTaskCount.TabIndex = 20;
            this.LabelTaskCount.Text = "Idle";
            this.LabelTaskCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelExecTask
            // 
            this.LabelExecTask.AutoSize = true;
            this.LabelExecTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelExecTask.Location = new System.Drawing.Point(231, 30);
            this.LabelExecTask.Name = "LabelExecTask";
            this.LabelExecTask.Size = new System.Drawing.Size(121, 20);
            this.LabelExecTask.TabIndex = 19;
            this.LabelExecTask.Text = "Executing Task:";
            // 
            // ButtonCancelSweeps
            // 
            this.ButtonCancelSweeps.BackColor = System.Drawing.Color.Yellow;
            this.ButtonCancelSweeps.Enabled = false;
            this.ButtonCancelSweeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancelSweeps.Location = new System.Drawing.Point(257, 60);
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
            this.LabelProgressWriteCsvFile.Enabled = false;
            this.LabelProgressWriteCsvFile.Location = new System.Drawing.Point(6, 144);
            this.LabelProgressWriteCsvFile.Name = "LabelProgressWriteCsvFile";
            this.LabelProgressWriteCsvFile.Size = new System.Drawing.Size(84, 20);
            this.LabelProgressWriteCsvFile.TabIndex = 17;
            this.LabelProgressWriteCsvFile.Text = "CSV File:";
            // 
            // TaskProgressBar
            // 
            this.TaskProgressBar.Location = new System.Drawing.Point(15, 115);
            this.TaskProgressBar.Name = "TaskProgressBar";
            this.TaskProgressBar.Size = new System.Drawing.Size(401, 23);
            this.TaskProgressBar.TabIndex = 16;
            // 
            // TextBoxCsvFileName
            // 
            this.TextBoxCsvFileName.Enabled = false;
            this.TextBoxCsvFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCsvFileName.Location = new System.Drawing.Point(6, 165);
            this.TextBoxCsvFileName.Name = "TextBoxCsvFileName";
            this.TextBoxCsvFileName.ReadOnly = true;
            this.TextBoxCsvFileName.Size = new System.Drawing.Size(422, 20);
            this.TextBoxCsvFileName.TabIndex = 1;
            this.TextBoxCsvFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CheckBoxSaveCsvFiles
            // 
            this.CheckBoxSaveCsvFiles.AutoSize = true;
            this.CheckBoxSaveCsvFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxSaveCsvFiles.Location = new System.Drawing.Point(9, 27);
            this.CheckBoxSaveCsvFiles.Name = "CheckBoxSaveCsvFiles";
            this.CheckBoxSaveCsvFiles.Size = new System.Drawing.Size(265, 24);
            this.CheckBoxSaveCsvFiles.TabIndex = 17;
            this.CheckBoxSaveCsvFiles.Text = "Save Collected Data to CSV Files";
            this.ToolTip1.SetToolTip(this.CheckBoxSaveCsvFiles, "Checking this box will cause CSV files to be saved in a selected sub-folder on th" +
        "e user\'s Desktop.");
            this.CheckBoxSaveCsvFiles.UseVisualStyleBackColor = true;
            this.CheckBoxSaveCsvFiles.CheckedChanged += new System.EventHandler(this.CheckBoxSaveCsvFiles_CheckedChanged);
            // 
            // CheckBoxChartPeak
            // 
            this.CheckBoxChartPeak.AutoSize = true;
            this.CheckBoxChartPeak.Checked = true;
            this.CheckBoxChartPeak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxChartPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxChartPeak.Location = new System.Drawing.Point(363, 426);
            this.CheckBoxChartPeak.Name = "CheckBoxChartPeak";
            this.CheckBoxChartPeak.Size = new System.Drawing.Size(64, 24);
            this.CheckBoxChartPeak.TabIndex = 3;
            this.CheckBoxChartPeak.Text = "Peak";
            this.ToolTip1.SetToolTip(this.CheckBoxChartPeak, "For each FFT bin, find and display the maximum power for that bin.");
            this.CheckBoxChartPeak.UseVisualStyleBackColor = true;
            this.CheckBoxChartPeak.CheckedChanged += new System.EventHandler(this.CheckBoxChartPeak_CheckedChanged);
            // 
            // CheckBoxChartAverage
            // 
            this.CheckBoxChartAverage.AutoSize = true;
            this.CheckBoxChartAverage.Checked = true;
            this.CheckBoxChartAverage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxChartAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxChartAverage.Location = new System.Drawing.Point(191, 426);
            this.CheckBoxChartAverage.Name = "CheckBoxChartAverage";
            this.CheckBoxChartAverage.Size = new System.Drawing.Size(87, 24);
            this.CheckBoxChartAverage.TabIndex = 2;
            this.CheckBoxChartAverage.Text = "Average";
            this.ToolTip1.SetToolTip(this.CheckBoxChartAverage, "For each FFT bin, compute and display the average power for that bin.");
            this.CheckBoxChartAverage.UseVisualStyleBackColor = true;
            this.CheckBoxChartAverage.CheckedChanged += new System.EventHandler(this.CheckBoxChartAverage_CheckedChanged);
            // 
            // CheckBoxChartAutoScale
            // 
            this.CheckBoxChartAutoScale.AutoSize = true;
            this.CheckBoxChartAutoScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxChartAutoScale.Location = new System.Drawing.Point(10, 426);
            this.CheckBoxChartAutoScale.Name = "CheckBoxChartAutoScale";
            this.CheckBoxChartAutoScale.Size = new System.Drawing.Size(106, 24);
            this.CheckBoxChartAutoScale.TabIndex = 1;
            this.CheckBoxChartAutoScale.Text = "Auto Scale";
            this.ToolTip1.SetToolTip(this.CheckBoxChartAutoScale, "When checked, scale the plot data to fill the graph area. Unchecked will only plo" +
        "t captured data points between -30 dBm and -110 dBm.");
            this.CheckBoxChartAutoScale.UseVisualStyleBackColor = true;
            this.CheckBoxChartAutoScale.CheckedChanged += new System.EventHandler(this.CheckBoxChartAutoScale_CheckedChanged);
            // 
            // GroupBox_ReceivedSignalStrength
            // 
            this.GroupBox_ReceivedSignalStrength.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox_ReceivedSignalStrength.Controls.Add(this.CheckBoxChartAutoScale);
            this.GroupBox_ReceivedSignalStrength.Controls.Add(this.CheckBoxChartAverage);
            this.GroupBox_ReceivedSignalStrength.Controls.Add(this.CheckBoxChartPeak);
            this.GroupBox_ReceivedSignalStrength.Controls.Add(this.PanelChart);
            this.GroupBox_ReceivedSignalStrength.Enabled = false;
            this.GroupBox_ReceivedSignalStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_ReceivedSignalStrength.Location = new System.Drawing.Point(550, 27);
            this.GroupBox_ReceivedSignalStrength.Name = "GroupBox_ReceivedSignalStrength";
            this.GroupBox_ReceivedSignalStrength.Size = new System.Drawing.Size(437, 457);
            this.GroupBox_ReceivedSignalStrength.TabIndex = 4;
            this.GroupBox_ReceivedSignalStrength.TabStop = false;
            this.GroupBox_ReceivedSignalStrength.Text = "Received Signal Strength";
            // 
            // PanelChart
            // 
            this.PanelChart.Location = new System.Drawing.Point(10, 25);
            this.PanelChart.Name = "PanelChart";
            this.PanelChart.Size = new System.Drawing.Size(418, 415);
            this.PanelChart.TabIndex = 0;
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 20000;
            this.ToolTip1.InitialDelay = 1000;
            this.ToolTip1.ReshowDelay = 1000;
            // 
            // TextBoxCollectionLocation
            // 
            this.TextBoxCollectionLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCollectionLocation.Location = new System.Drawing.Point(8, 60);
            this.TextBoxCollectionLocation.Name = "TextBoxCollectionLocation";
            this.TextBoxCollectionLocation.Size = new System.Drawing.Size(341, 26);
            this.TextBoxCollectionLocation.TabIndex = 2;
            this.TextBoxCollectionLocation.Text = "Collection Location";
            this.ToolTip1.SetToolTip(this.TextBoxCollectionLocation, "Enter a short site collection location identifier for data that is about to be co" +
        "llected.\nThis identifier will be used to create or enter a Desktop sub-folder to" +
        " store collected data in CSV Files.");
            this.TextBoxCollectionLocation.TextChanged += new System.EventHandler(this.TextBoxSweepLocation_TextChanged);
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
            // ButtonSetConfiguration
            // 
            this.ButtonSetConfiguration.Enabled = false;
            this.ButtonSetConfiguration.Location = new System.Drawing.Point(345, 42);
            this.ButtonSetConfiguration.Name = "ButtonSetConfiguration";
            this.ButtonSetConfiguration.Size = new System.Drawing.Size(127, 51);
            this.ButtonSetConfiguration.TabIndex = 10;
            this.ButtonSetConfiguration.Text = "Set Explorer Configuration";
            this.ToolTip1.SetToolTip(this.ButtonSetConfiguration, resources.GetString("ButtonSetConfiguration.ToolTip"));
            this.ButtonSetConfiguration.UseVisualStyleBackColor = true;
            this.ButtonSetConfiguration.Click += new System.EventHandler(this.ButtonSetConfiguration_Click);
            // 
            // TextBoxRBW
            // 
            this.TextBoxRBW.Location = new System.Drawing.Point(168, 101);
            this.TextBoxRBW.Name = "TextBoxRBW";
            this.TextBoxRBW.ReadOnly = true;
            this.TextBoxRBW.Size = new System.Drawing.Size(56, 26);
            this.TextBoxRBW.TabIndex = 17;
            this.TextBoxRBW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip1.SetToolTip(this.TextBoxRBW, "RBW is not directly settable. It is determined by table lookup in the RF Explorer" +
        " and is based on Span.");
            // 
            // ComboBoxPreset
            // 
            this.ComboBoxPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPreset.Enabled = false;
            this.ComboBoxPreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxPreset.FormattingEnabled = true;
            this.ComboBoxPreset.Items.AddRange(new object[] {
            "Continuous",
            "Single",
            "CP4 Downlink",
            "Full Downlink"});
            this.ComboBoxPreset.Location = new System.Drawing.Point(133, 231);
            this.ComboBoxPreset.Name = "ComboBoxPreset";
            this.ComboBoxPreset.Size = new System.Drawing.Size(213, 32);
            this.ComboBoxPreset.TabIndex = 25;
            this.ToolTip1.SetToolTip(this.ComboBoxPreset, resources.GetString("ComboBoxPreset.ToolTip"));
            this.ComboBoxPreset.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPreset_IndexChanged);
            // 
            // ButtonGetRfeConfiguration
            // 
            this.ButtonGetRfeConfiguration.Enabled = false;
            this.ButtonGetRfeConfiguration.Location = new System.Drawing.Point(345, 108);
            this.ButtonGetRfeConfiguration.Name = "ButtonGetRfeConfiguration";
            this.ButtonGetRfeConfiguration.Size = new System.Drawing.Size(127, 54);
            this.ButtonGetRfeConfiguration.TabIndex = 27;
            this.ButtonGetRfeConfiguration.Text = "Get Explorer  Configuration";
            this.ToolTip1.SetToolTip(this.ButtonGetRfeConfiguration, "Request and display the current RF Explorer configuration.");
            this.ButtonGetRfeConfiguration.UseVisualStyleBackColor = true;
            this.ButtonGetRfeConfiguration.Click += new System.EventHandler(this.ButtonGetConfiguration_Click);
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
            this.ToolTip1.SetToolTip(this.LabelStopFrequency, "End measurments at this frequency.");
            // 
            // ButtonCaptureImage
            // 
            this.ButtonCaptureImage.BackColor = System.Drawing.Color.Gray;
            this.ButtonCaptureImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCaptureImage.Location = new System.Drawing.Point(9, 108);
            this.ButtonCaptureImage.Name = "ButtonCaptureImage";
            this.ButtonCaptureImage.Size = new System.Drawing.Size(141, 50);
            this.ButtonCaptureImage.TabIndex = 44;
            this.ButtonCaptureImage.Text = "Capture Frame";
            this.ToolTip1.SetToolTip(this.ButtonCaptureImage, "Captures an image and stores it with the current location sweep data.");
            this.ButtonCaptureImage.UseVisualStyleBackColor = false;
            this.ButtonCaptureImage.Click += new System.EventHandler(this.ButtonCaptureImage_Click);
            // 
            // ButtonPersistClear
            // 
            this.ButtonPersistClear.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonPersistClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonPersistClear.Location = new System.Drawing.Point(391, 46);
            this.ButtonPersistClear.Name = "ButtonPersistClear";
            this.ButtonPersistClear.Size = new System.Drawing.Size(108, 53);
            this.ButtonPersistClear.TabIndex = 45;
            this.ButtonPersistClear.Text = "Clear All Fields";
            this.ToolTip1.SetToolTip(this.ButtonPersistClear, "Restores all fields to default values. Sets \"Manual\" Preset.");
            this.ButtonPersistClear.UseVisualStyleBackColor = false;
            this.ButtonPersistClear.Click += new System.EventHandler(this.ButtonPersistClear_Click);
            // 
            // Button_CSVFileStorage_CollectionFloor_Enable
            // 
            this.Button_CSVFileStorage_CollectionFloor_Enable.BackColor = System.Drawing.Color.Olive;
            this.Button_CSVFileStorage_CollectionFloor_Enable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_CSVFileStorage_CollectionFloor_Enable.Location = new System.Drawing.Point(223, 22);
            this.Button_CSVFileStorage_CollectionFloor_Enable.Name = "Button_CSVFileStorage_CollectionFloor_Enable";
            this.Button_CSVFileStorage_CollectionFloor_Enable.Size = new System.Drawing.Size(79, 29);
            this.Button_CSVFileStorage_CollectionFloor_Enable.TabIndex = 42;
            this.Button_CSVFileStorage_CollectionFloor_Enable.Text = "Enable";
            this.ToolTip1.SetToolTip(this.Button_CSVFileStorage_CollectionFloor_Enable, "Include a Floor indentifier in the CSV file name.  Also enables the increment and" +
        " decrement mode.");
            this.Button_CSVFileStorage_CollectionFloor_Enable.UseVisualStyleBackColor = false;
            this.Button_CSVFileStorage_CollectionFloor_Enable.Click += new System.EventHandler(this.Button_CSVFileStorage_CollectionFloor_Enable_Click);
            // 
            // RadioButton_CSVFileStorage_FloorIncrement
            // 
            this.RadioButton_CSVFileStorage_FloorIncrement.AutoSize = true;
            this.RadioButton_CSVFileStorage_FloorIncrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton_CSVFileStorage_FloorIncrement.Location = new System.Drawing.Point(12, 17);
            this.RadioButton_CSVFileStorage_FloorIncrement.Name = "RadioButton_CSVFileStorage_FloorIncrement";
            this.RadioButton_CSVFileStorage_FloorIncrement.Size = new System.Drawing.Size(72, 17);
            this.RadioButton_CSVFileStorage_FloorIncrement.TabIndex = 41;
            this.RadioButton_CSVFileStorage_FloorIncrement.Text = "Increment";
            this.ToolTip1.SetToolTip(this.RadioButton_CSVFileStorage_FloorIncrement, "When Enabled, increment the floor number each time the Next Button is pressed.");
            this.RadioButton_CSVFileStorage_FloorIncrement.UseVisualStyleBackColor = true;
            // 
            // RadioButton_CSVFileStorage_FloorDecrement
            // 
            this.RadioButton_CSVFileStorage_FloorDecrement.AutoSize = true;
            this.RadioButton_CSVFileStorage_FloorDecrement.Checked = true;
            this.RadioButton_CSVFileStorage_FloorDecrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton_CSVFileStorage_FloorDecrement.Location = new System.Drawing.Point(12, 39);
            this.RadioButton_CSVFileStorage_FloorDecrement.Name = "RadioButton_CSVFileStorage_FloorDecrement";
            this.RadioButton_CSVFileStorage_FloorDecrement.Size = new System.Drawing.Size(77, 17);
            this.RadioButton_CSVFileStorage_FloorDecrement.TabIndex = 40;
            this.RadioButton_CSVFileStorage_FloorDecrement.TabStop = true;
            this.RadioButton_CSVFileStorage_FloorDecrement.Text = "Decrement";
            this.ToolTip1.SetToolTip(this.RadioButton_CSVFileStorage_FloorDecrement, "When Enabled, deccrement the floor number each time the Next Button is pressed.");
            this.RadioButton_CSVFileStorage_FloorDecrement.UseVisualStyleBackColor = true;
            // 
            // CheckBoxAutoIncrementMarkerNumber
            // 
            this.CheckBoxAutoIncrementMarkerNumber.AutoSize = true;
            this.CheckBoxAutoIncrementMarkerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxAutoIncrementMarkerNumber.Location = new System.Drawing.Point(223, 32);
            this.CheckBoxAutoIncrementMarkerNumber.Name = "CheckBoxAutoIncrementMarkerNumber";
            this.CheckBoxAutoIncrementMarkerNumber.Size = new System.Drawing.Size(101, 17);
            this.CheckBoxAutoIncrementMarkerNumber.TabIndex = 29;
            this.CheckBoxAutoIncrementMarkerNumber.Text = "Auto Increment ";
            this.ToolTip1.SetToolTip(this.CheckBoxAutoIncrementMarkerNumber, "Auto Increment the Collection Site Marker Number after the Capture Button is pres" +
        "sed.");
            this.CheckBoxAutoIncrementMarkerNumber.UseVisualStyleBackColor = true;
            this.CheckBoxAutoIncrementMarkerNumber.CheckedChanged += new System.EventHandler(this.CheckBoxAutoIncrement_CheckedChanged);
            // 
            // CheckBoxHoldStep
            // 
            this.CheckBoxHoldStep.AutoSize = true;
            this.CheckBoxHoldStep.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxHoldStep.Enabled = false;
            this.CheckBoxHoldStep.Location = new System.Drawing.Point(272, 50);
            this.CheckBoxHoldStep.Name = "CheckBoxHoldStep";
            this.CheckBoxHoldStep.Size = new System.Drawing.Size(61, 24);
            this.CheckBoxHoldStep.TabIndex = 30;
            this.CheckBoxHoldStep.Text = "Hold";
            this.ToolTip1.SetToolTip(this.CheckBoxHoldStep, "Check to hold this value constant and recalculate the other two frequency paramet" +
        "ers.");
            this.CheckBoxHoldStep.UseVisualStyleBackColor = false;
            // 
            // CheckBoxHoldStop
            // 
            this.CheckBoxHoldStop.AutoSize = true;
            this.CheckBoxHoldStop.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxHoldStop.Enabled = false;
            this.CheckBoxHoldStop.Location = new System.Drawing.Point(272, 76);
            this.CheckBoxHoldStop.Name = "CheckBoxHoldStop";
            this.CheckBoxHoldStop.Size = new System.Drawing.Size(61, 24);
            this.CheckBoxHoldStop.TabIndex = 29;
            this.CheckBoxHoldStop.Text = "Hold";
            this.ToolTip1.SetToolTip(this.CheckBoxHoldStop, "Check to hold this value constant and recalculate the other two frequency paramet" +
        "ers.");
            this.CheckBoxHoldStop.UseVisualStyleBackColor = false;
            // 
            // CheckBoxHoldStart
            // 
            this.CheckBoxHoldStart.AutoSize = true;
            this.CheckBoxHoldStart.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxHoldStart.Enabled = false;
            this.CheckBoxHoldStart.Location = new System.Drawing.Point(272, 24);
            this.CheckBoxHoldStart.Name = "CheckBoxHoldStart";
            this.CheckBoxHoldStart.Size = new System.Drawing.Size(61, 24);
            this.CheckBoxHoldStart.TabIndex = 28;
            this.CheckBoxHoldStart.Text = "Hold";
            this.ToolTip1.SetToolTip(this.CheckBoxHoldStart, "Check to hold this value constant and recalculate the other two frequency paramet" +
        "ers.");
            this.CheckBoxHoldStart.UseVisualStyleBackColor = false;
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
            this.ToolTip1.SetToolTip(this.LabelStartFrequency, "Begin measurments at this frequency.");
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
            this.ToolTip1.SetToolTip(this.LabelFrequencyStep, "Frequency sample step size/interval. The RF Explorer will always divide into 112 " +
        "bins.");
            // 
            // TabControlMain
            // 
            this.TabControlMain.Controls.Add(this.TabControlMainConnection);
            this.TabControlMain.Controls.Add(this.TabControlMainOmniDirectional);
            this.TabControlMain.Controls.Add(this.TabControlMainRadial);
            this.TabControlMain.Controls.Add(this.TabControlSiteImage);
            this.TabControlMain.Controls.Add(this.TabControlCalibration);
            this.TabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TabControlMain.Location = new System.Drawing.Point(12, 27);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(532, 346);
            this.TabControlMain.TabIndex = 37;
            this.ToolTip1.SetToolTip(this.TabControlMain, "Connect the RF Explorer to this COM Port.");
            this.TabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // TabControlMainConnection
            // 
            this.TabControlMainConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.TabControlMainConnection.Controls.Add(this.Label_ComPortText);
            this.TabControlMainConnection.Controls.Add(this.Label_Model);
            this.TabControlMainConnection.Controls.Add(this.Label_Device);
            this.TabControlMainConnection.Controls.Add(this.Button_ConnectRFExplorer);
            this.TabControlMainConnection.Controls.Add(this.Label_FirmwareValue);
            this.TabControlMainConnection.Controls.Add(this.Label_ComPortValue);
            this.TabControlMainConnection.Controls.Add(this.Label_Firmware);
            this.TabControlMainConnection.Controls.Add(this.Label_DeviceValue);
            this.TabControlMainConnection.Controls.Add(this.Label_ModelValue);
            this.TabControlMainConnection.Controls.Add(this.GroupBox_DocumentationAndUSBTroubleShooting);
            this.TabControlMainConnection.Location = new System.Drawing.Point(4, 29);
            this.TabControlMainConnection.Name = "TabControlMainConnection";
            this.TabControlMainConnection.Padding = new System.Windows.Forms.Padding(3);
            this.TabControlMainConnection.Size = new System.Drawing.Size(524, 313);
            this.TabControlMainConnection.TabIndex = 0;
            this.TabControlMainConnection.Text = "Connection";
            // 
            // Label_ComPortText
            // 
            this.Label_ComPortText.AutoSize = true;
            this.Label_ComPortText.BackColor = System.Drawing.Color.Transparent;
            this.Label_ComPortText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_ComPortText.Location = new System.Drawing.Point(275, 33);
            this.Label_ComPortText.Name = "Label_ComPortText";
            this.Label_ComPortText.Size = new System.Drawing.Size(82, 20);
            this.Label_ComPortText.TabIndex = 18;
            this.Label_ComPortText.Text = "COM Port:";
            this.ToolTip1.SetToolTip(this.Label_ComPortText, "This RF Explorer COM Port connection.");
            // 
            // GroupBox_DocumentationAndUSBTroubleShooting
            // 
            this.GroupBox_DocumentationAndUSBTroubleShooting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBox_DocumentationAndUSBTroubleShooting.Controls.Add(this.Button_USBTroubleShooting);
            this.GroupBox_DocumentationAndUSBTroubleShooting.Controls.Add(this.Button_REEDocumentation);
            this.GroupBox_DocumentationAndUSBTroubleShooting.Controls.Add(this.Button_USBDriverDownload);
            this.GroupBox_DocumentationAndUSBTroubleShooting.Controls.Add(this.RadioButton_SignalGenerator);
            this.GroupBox_DocumentationAndUSBTroubleShooting.Controls.Add(this.RadioButton_SpectrumAnalyzer);
            this.GroupBox_DocumentationAndUSBTroubleShooting.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GroupBox_DocumentationAndUSBTroubleShooting.Location = new System.Drawing.Point(35, 132);
            this.GroupBox_DocumentationAndUSBTroubleShooting.Name = "GroupBox_DocumentationAndUSBTroubleShooting";
            this.GroupBox_DocumentationAndUSBTroubleShooting.Size = new System.Drawing.Size(455, 169);
            this.GroupBox_DocumentationAndUSBTroubleShooting.TabIndex = 21;
            this.GroupBox_DocumentationAndUSBTroubleShooting.TabStop = false;
            this.GroupBox_DocumentationAndUSBTroubleShooting.Text = "Documentation and USB Trouble Shooting";
            // 
            // Button_USBTroubleShooting
            // 
            this.Button_USBTroubleShooting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_USBTroubleShooting.Location = new System.Drawing.Point(35, 98);
            this.Button_USBTroubleShooting.Name = "Button_USBTroubleShooting";
            this.Button_USBTroubleShooting.Size = new System.Drawing.Size(179, 51);
            this.Button_USBTroubleShooting.TabIndex = 19;
            this.Button_USBTroubleShooting.Text = "USB Trouble Shooting";
            this.Button_USBTroubleShooting.UseVisualStyleBackColor = true;
            this.Button_USBTroubleShooting.Click += new System.EventHandler(this.BaudRate_Click);
            // 
            // Button_USBDriverDownload
            // 
            this.Button_USBDriverDownload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_USBDriverDownload.Location = new System.Drawing.Point(247, 98);
            this.Button_USBDriverDownload.Name = "Button_USBDriverDownload";
            this.Button_USBDriverDownload.Size = new System.Drawing.Size(179, 51);
            this.Button_USBDriverDownload.TabIndex = 20;
            this.Button_USBDriverDownload.Text = "USB 6.7.5 Driver Download";
            this.Button_USBDriverDownload.UseVisualStyleBackColor = true;
            this.Button_USBDriverDownload.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TabControlMainOmniDirectional
            // 
            this.TabControlMainOmniDirectional.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TabControlMainOmniDirectional.Controls.Add(this.GroupBox_OmniDirectional_CurrentConfiguration);
            this.TabControlMainOmniDirectional.Location = new System.Drawing.Point(4, 29);
            this.TabControlMainOmniDirectional.Name = "TabControlMainOmniDirectional";
            this.TabControlMainOmniDirectional.Padding = new System.Windows.Forms.Padding(3);
            this.TabControlMainOmniDirectional.Size = new System.Drawing.Size(524, 313);
            this.TabControlMainOmniDirectional.TabIndex = 1;
            this.TabControlMainOmniDirectional.Text = "OmniDirectional";
            // 
            // GroupBox_OmniDirectional_CurrentConfiguration
            // 
            this.GroupBox_OmniDirectional_CurrentConfiguration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(11)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelRBWUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.ComboBoxPreset);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelRBW);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBoxRBW);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBoxHoldStep);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBoxHoldStop);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.CheckBoxHoldStart);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.ButtonGetRfeConfiguration);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelPresets);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelRightAntennaGainUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBoxRightAntennaGain);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelRightAntennaGain);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelLeftAntennaGainUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBoxLeftAntennaGain);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelLeftAntennaGain);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBoxStepFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelStopFrequencyUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelStartFrequencyUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.ButtonSetConfiguration);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelFrequencyStepUnit);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelStartFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelFrequencyStep);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBoxStartFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.TextBoxStopFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Controls.Add(this.LabelStopFrequency);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Enabled = false;
            this.GroupBox_OmniDirectional_CurrentConfiguration.Location = new System.Drawing.Point(16, 21);
            this.GroupBox_OmniDirectional_CurrentConfiguration.Name = "GroupBox_OmniDirectional_CurrentConfiguration";
            this.GroupBox_OmniDirectional_CurrentConfiguration.Size = new System.Drawing.Size(490, 274);
            this.GroupBox_OmniDirectional_CurrentConfiguration.TabIndex = 10;
            this.GroupBox_OmniDirectional_CurrentConfiguration.TabStop = false;
            this.GroupBox_OmniDirectional_CurrentConfiguration.Text = "Current Configuration";
            // 
            // LabelRBWUnit
            // 
            this.LabelRBWUnit.AutoSize = true;
            this.LabelRBWUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelRBWUnit.Location = new System.Drawing.Point(224, 104);
            this.LabelRBWUnit.Name = "LabelRBWUnit";
            this.LabelRBWUnit.Size = new System.Drawing.Size(39, 20);
            this.LabelRBWUnit.TabIndex = 6;
            this.LabelRBWUnit.Text = "KHz";
            // 
            // LabelPresets
            // 
            this.LabelPresets.AutoSize = true;
            this.LabelPresets.BackColor = System.Drawing.Color.Transparent;
            this.LabelPresets.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPresets.Location = new System.Drawing.Point(196, 199);
            this.LabelPresets.Name = "LabelPresets";
            this.LabelPresets.Size = new System.Drawing.Size(95, 29);
            this.LabelPresets.TabIndex = 26;
            this.LabelPresets.Text = "Presets";
            // 
            // LabelRightAntennaGainUnit
            // 
            this.LabelRightAntennaGainUnit.AutoSize = true;
            this.LabelRightAntennaGainUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelRightAntennaGainUnit.Enabled = false;
            this.LabelRightAntennaGainUnit.Location = new System.Drawing.Point(224, 170);
            this.LabelRightAntennaGainUnit.Name = "LabelRightAntennaGainUnit";
            this.LabelRightAntennaGainUnit.Size = new System.Drawing.Size(29, 20);
            this.LabelRightAntennaGainUnit.TabIndex = 24;
            this.LabelRightAntennaGainUnit.Text = "dB";
            // 
            // TextBoxRightAntennaGain
            // 
            this.TextBoxRightAntennaGain.Enabled = false;
            this.TextBoxRightAntennaGain.Location = new System.Drawing.Point(168, 167);
            this.TextBoxRightAntennaGain.Name = "TextBoxRightAntennaGain";
            this.TextBoxRightAntennaGain.Size = new System.Drawing.Size(56, 26);
            this.TextBoxRightAntennaGain.TabIndex = 23;
            this.TextBoxRightAntennaGain.Text = "0";
            this.TextBoxRightAntennaGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxRightAntennaGain.TextChanged += new System.EventHandler(this.TextBoxRightAntennaGain_TextChanged);
            // 
            // LabelRightAntennaGain
            // 
            this.LabelRightAntennaGain.AutoSize = true;
            this.LabelRightAntennaGain.BackColor = System.Drawing.Color.Transparent;
            this.LabelRightAntennaGain.Enabled = false;
            this.LabelRightAntennaGain.Location = new System.Drawing.Point(18, 170);
            this.LabelRightAntennaGain.Name = "LabelRightAntennaGain";
            this.LabelRightAntennaGain.Size = new System.Drawing.Size(150, 20);
            this.LabelRightAntennaGain.TabIndex = 22;
            this.LabelRightAntennaGain.Text = "Right Antenna Gain";
            // 
            // LabelLeftAntennaGainUnit
            // 
            this.LabelLeftAntennaGainUnit.AutoSize = true;
            this.LabelLeftAntennaGainUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelLeftAntennaGainUnit.Enabled = false;
            this.LabelLeftAntennaGainUnit.Location = new System.Drawing.Point(224, 144);
            this.LabelLeftAntennaGainUnit.Name = "LabelLeftAntennaGainUnit";
            this.LabelLeftAntennaGainUnit.Size = new System.Drawing.Size(29, 20);
            this.LabelLeftAntennaGainUnit.TabIndex = 21;
            this.LabelLeftAntennaGainUnit.Text = "dB";
            // 
            // TextBoxLeftAntennaGain
            // 
            this.TextBoxLeftAntennaGain.Enabled = false;
            this.TextBoxLeftAntennaGain.Location = new System.Drawing.Point(168, 141);
            this.TextBoxLeftAntennaGain.Name = "TextBoxLeftAntennaGain";
            this.TextBoxLeftAntennaGain.Size = new System.Drawing.Size(56, 26);
            this.TextBoxLeftAntennaGain.TabIndex = 20;
            this.TextBoxLeftAntennaGain.Text = "0";
            this.TextBoxLeftAntennaGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxLeftAntennaGain.TextChanged += new System.EventHandler(this.TextBoxLeftAntennaGain_TextChanged);
            // 
            // LabelLeftAntennaGain
            // 
            this.LabelLeftAntennaGain.AutoSize = true;
            this.LabelLeftAntennaGain.BackColor = System.Drawing.Color.Transparent;
            this.LabelLeftAntennaGain.Enabled = false;
            this.LabelLeftAntennaGain.Location = new System.Drawing.Point(28, 144);
            this.LabelLeftAntennaGain.Name = "LabelLeftAntennaGain";
            this.LabelLeftAntennaGain.Size = new System.Drawing.Size(140, 20);
            this.LabelLeftAntennaGain.TabIndex = 19;
            this.LabelLeftAntennaGain.Text = "Left Antenna Gain";
            // 
            // TextBoxStepFrequency
            // 
            this.TextBoxStepFrequency.Enabled = false;
            this.TextBoxStepFrequency.Location = new System.Drawing.Point(168, 49);
            this.TextBoxStepFrequency.Name = "TextBoxStepFrequency";
            this.TextBoxStepFrequency.Size = new System.Drawing.Size(56, 26);
            this.TextBoxStepFrequency.TabIndex = 18;
            this.TextBoxStepFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LabelStopFrequencyUnit
            // 
            this.LabelStopFrequencyUnit.AutoSize = true;
            this.LabelStopFrequencyUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelStopFrequencyUnit.Location = new System.Drawing.Point(224, 78);
            this.LabelStopFrequencyUnit.Name = "LabelStopFrequencyUnit";
            this.LabelStopFrequencyUnit.Size = new System.Drawing.Size(42, 20);
            this.LabelStopFrequencyUnit.TabIndex = 16;
            this.LabelStopFrequencyUnit.Text = "MHz";
            // 
            // LabelStartFrequencyUnit
            // 
            this.LabelStartFrequencyUnit.AutoSize = true;
            this.LabelStartFrequencyUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelStartFrequencyUnit.Location = new System.Drawing.Point(224, 26);
            this.LabelStartFrequencyUnit.Name = "LabelStartFrequencyUnit";
            this.LabelStartFrequencyUnit.Size = new System.Drawing.Size(42, 20);
            this.LabelStartFrequencyUnit.TabIndex = 15;
            this.LabelStartFrequencyUnit.Text = "MHz";
            // 
            // LabelFrequencyStepUnit
            // 
            this.LabelFrequencyStepUnit.AutoSize = true;
            this.LabelFrequencyStepUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelFrequencyStepUnit.Location = new System.Drawing.Point(224, 52);
            this.LabelFrequencyStepUnit.Name = "LabelFrequencyStepUnit";
            this.LabelFrequencyStepUnit.Size = new System.Drawing.Size(39, 20);
            this.LabelFrequencyStepUnit.TabIndex = 9;
            this.LabelFrequencyStepUnit.Text = "KHz";
            // 
            // TextBoxStartFrequency
            // 
            this.TextBoxStartFrequency.Enabled = false;
            this.TextBoxStartFrequency.Location = new System.Drawing.Point(168, 23);
            this.TextBoxStartFrequency.Name = "TextBoxStartFrequency";
            this.TextBoxStartFrequency.Size = new System.Drawing.Size(56, 26);
            this.TextBoxStartFrequency.TabIndex = 3;
            this.TextBoxStartFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxStartFrequency.TextChanged += new System.EventHandler(this.TextBoxStartFrequency_TextChanged);
            // 
            // TextBoxStopFrequency
            // 
            this.TextBoxStopFrequency.Enabled = false;
            this.TextBoxStopFrequency.Location = new System.Drawing.Point(168, 75);
            this.TextBoxStopFrequency.Name = "TextBoxStopFrequency";
            this.TextBoxStopFrequency.Size = new System.Drawing.Size(56, 26);
            this.TextBoxStopFrequency.TabIndex = 7;
            this.TextBoxStopFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxStopFrequency.TextChanged += new System.EventHandler(this.TextBoxStopFrequency_TextChanged);
            // 
            // TabControlMainRadial
            // 
            this.TabControlMainRadial.BackColor = System.Drawing.Color.White;
            this.TabControlMainRadial.Controls.Add(this.LabelRadialAzimuth);
            this.TabControlMainRadial.Controls.Add(this.LabelTrueNorthText);
            this.TabControlMainRadial.Controls.Add(this.CheckBoxRadialAzimuth);
            this.TabControlMainRadial.Controls.Add(this.NumericUpDownRadialAzimuth);
            this.TabControlMainRadial.Location = new System.Drawing.Point(4, 29);
            this.TabControlMainRadial.Name = "TabControlMainRadial";
            this.TabControlMainRadial.Size = new System.Drawing.Size(524, 313);
            this.TabControlMainRadial.TabIndex = 2;
            this.TabControlMainRadial.Text = "Radial";
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
            // TabControlSiteImage
            // 
            this.TabControlSiteImage.Controls.Add(this.ButtonPauseResume);
            this.TabControlSiteImage.Controls.Add(this.LabelCaptured);
            this.TabControlSiteImage.Controls.Add(this.ButtonCaptureImage);
            this.TabControlSiteImage.Controls.Add(this.PictureBox);
            this.TabControlSiteImage.Location = new System.Drawing.Point(4, 29);
            this.TabControlSiteImage.Name = "TabControlSiteImage";
            this.TabControlSiteImage.Padding = new System.Windows.Forms.Padding(3);
            this.TabControlSiteImage.Size = new System.Drawing.Size(524, 313);
            this.TabControlSiteImage.TabIndex = 3;
            this.TabControlSiteImage.Text = "Location Camera";
            this.TabControlSiteImage.UseVisualStyleBackColor = true;
            // 
            // ButtonPauseResume
            // 
            this.ButtonPauseResume.Location = new System.Drawing.Point(34, 211);
            this.ButtonPauseResume.Name = "ButtonPauseResume";
            this.ButtonPauseResume.Size = new System.Drawing.Size(91, 32);
            this.ButtonPauseResume.TabIndex = 49;
            this.ButtonPauseResume.Text = "Pause";
            this.ButtonPauseResume.UseVisualStyleBackColor = true;
            this.ButtonPauseResume.Click += new System.EventHandler(this.ButtonPauseResume_Click);
            // 
            // LabelCaptured
            // 
            this.LabelCaptured.AutoSize = true;
            this.LabelCaptured.Location = new System.Drawing.Point(42, 161);
            this.LabelCaptured.Name = "LabelCaptured";
            this.LabelCaptured.Size = new System.Drawing.Size(0, 20);
            this.LabelCaptured.TabIndex = 48;
            this.LabelCaptured.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(157, 6);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(361, 301);
            this.PictureBox.TabIndex = 45;
            this.PictureBox.TabStop = false;
            // 
            // TabControlCalibration
            // 
            this.TabControlCalibration.Controls.Add(this.label3);
            this.TabControlCalibration.Controls.Add(this.TextBoxCalibrationPointsPerSweepInterval);
            this.TabControlCalibration.Controls.Add(this.label2);
            this.TabControlCalibration.Controls.Add(this.TextBoxCalibrationSourceDbm);
            this.TabControlCalibration.Controls.Add(this.label1);
            this.TabControlCalibration.Controls.Add(this.ButtonCalibrationStart);
            this.TabControlCalibration.Location = new System.Drawing.Point(4, 29);
            this.TabControlCalibration.Name = "TabControlCalibration";
            this.TabControlCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.TabControlCalibration.Size = new System.Drawing.Size(524, 313);
            this.TabControlCalibration.TabIndex = 4;
            this.TabControlCalibration.Text = "Calibration";
            this.TabControlCalibration.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
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
            this.Button_CSVFileStorage_Next.Location = new System.Drawing.Point(95, 22);
            this.Button_CSVFileStorage_Next.Name = "Button_CSVFileStorage_Next";
            this.Button_CSVFileStorage_Next.Size = new System.Drawing.Size(75, 29);
            this.Button_CSVFileStorage_Next.TabIndex = 43;
            this.Button_CSVFileStorage_Next.Text = "Next";
            this.ToolTip1.SetToolTip(this.Button_CSVFileStorage_Next, "Decrement or Increment the Collection Floor Number.");
            this.Button_CSVFileStorage_Next.UseVisualStyleBackColor = false;
            this.Button_CSVFileStorage_Next.Click += new System.EventHandler(this.Button_CSVFileStorage_CollectionFloor_AutoNext_Click);
            // 
            // GroupBox_CSVFileStorage
            // 
            this.GroupBox_CSVFileStorage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox_CSVFileStorage.Controls.Add(this.CheckBoxSaveCsvFiles);
            this.GroupBox_CSVFileStorage.Controls.Add(this.GroupBoxCsvInformation);
            this.GroupBox_CSVFileStorage.Enabled = false;
            this.GroupBox_CSVFileStorage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox_CSVFileStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.GroupBoxCsvInformation.Controls.Add(this.ButtonPersistClear);
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBoxClientId);
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBoxFloorId);
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
            // GroupBoxClientId
            // 
            this.GroupBoxClientId.Controls.Add(this.TextBoxClient);
            this.GroupBoxClientId.Controls.Add(this.TextBoxCollectionLocation);
            this.GroupBoxClientId.Location = new System.Drawing.Point(20, 16);
            this.GroupBoxClientId.Name = "GroupBoxClientId";
            this.GroupBoxClientId.Size = new System.Drawing.Size(358, 98);
            this.GroupBoxClientId.TabIndex = 43;
            this.GroupBoxClientId.TabStop = false;
            this.GroupBoxClientId.Text = "Client Information";
            // 
            // TextBoxClient
            // 
            this.TextBoxClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxClient.Location = new System.Drawing.Point(8, 27);
            this.TextBoxClient.Name = "TextBoxClient";
            this.TextBoxClient.Size = new System.Drawing.Size(341, 26);
            this.TextBoxClient.TabIndex = 20;
            this.TextBoxClient.Text = "Client";
            this.TextBoxClient.TextChanged += new System.EventHandler(this.TextBoxClient_TextChanged);
            // 
            // GroupBoxFloorId
            // 
            this.GroupBoxFloorId.Controls.Add(this.Button_CSVFileStorage_CollectionFloor_Enable);
            this.GroupBoxFloorId.Controls.Add(this.NumericUpDown_CSVFileStorage_FloorNumber);
            this.GroupBoxFloorId.Controls.Add(this.TextBox_CSVFileStorage_CollectionFloorName);
            this.GroupBoxFloorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxFloorId.Location = new System.Drawing.Point(20, 121);
            this.GroupBoxFloorId.Name = "GroupBoxFloorId";
            this.GroupBoxFloorId.Size = new System.Drawing.Size(308, 63);
            this.GroupBoxFloorId.TabIndex = 42;
            this.GroupBoxFloorId.TabStop = false;
            this.GroupBoxFloorId.Text = "Collection Floor";
            // 
            // NumericUpDown_CSVFileStorage_FloorNumber
            // 
            this.NumericUpDown_CSVFileStorage_FloorNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.NumericUpDown_CSVFileStorage_FloorNumber.Enabled = false;
            this.NumericUpDown_CSVFileStorage_FloorNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_CSVFileStorage_FloorNumber.Location = new System.Drawing.Point(151, 21);
            this.NumericUpDown_CSVFileStorage_FloorNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.TextBox_CSVFileStorage_CollectionFloorName.Enabled = false;
            this.TextBox_CSVFileStorage_CollectionFloorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_CSVFileStorage_CollectionFloorName.Location = new System.Drawing.Point(6, 23);
            this.TextBox_CSVFileStorage_CollectionFloorName.Name = "TextBox_CSVFileStorage_CollectionFloorName";
            this.TextBox_CSVFileStorage_CollectionFloorName.Size = new System.Drawing.Size(132, 26);
            this.TextBox_CSVFileStorage_CollectionFloorName.TabIndex = 37;
            this.TextBox_CSVFileStorage_CollectionFloorName.Text = "z";
            this.TextBox_CSVFileStorage_CollectionFloorName.TextChanged += new System.EventHandler(this.TextBoxFloorLabel_TextChanged);
            // 
            // GroupBox_CSVFileStorage_CollectionMarker
            // 
            this.GroupBox_CSVFileStorage_CollectionMarker.Controls.Add(this.TextBox_CSVFileStorage_CollectionMarkerName);
            this.GroupBox_CSVFileStorage_CollectionMarker.Controls.Add(this.CheckBoxAutoIncrementMarkerNumber);
            this.GroupBox_CSVFileStorage_CollectionMarker.Controls.Add(this.NumericUpDown_CSVFileStorage_MarkerNumber);
            this.GroupBox_CSVFileStorage_CollectionMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_CSVFileStorage_CollectionMarker.Location = new System.Drawing.Point(20, 191);
            this.GroupBox_CSVFileStorage_CollectionMarker.Name = "GroupBox_CSVFileStorage_CollectionMarker";
            this.GroupBox_CSVFileStorage_CollectionMarker.Size = new System.Drawing.Size(358, 63);
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
            1,
            0,
            0,
            0});
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
            this.LabelCopyright.Location = new System.Drawing.Point(808, 717);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(172, 13);
            this.LabelCopyright.TabIndex = 25;
            this.LabelCopyright.Text = "Copyright 2023 - Neve Group, LTD";
            // 
            // MenuStripMainForm
            // 
            this.MenuStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripMenuItemFile,
            this.uSBSettingsToolStripMenuItem});
            this.MenuStripMainForm.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMainForm.Name = "MenuStripMainForm";
            this.MenuStripMainForm.Size = new System.Drawing.Size(1001, 24);
            this.MenuStripMainForm.TabIndex = 26;
            this.MenuStripMainForm.Text = "menuStrip1";
            // 
            // MenuStripMenuItemFile
            // 
            this.MenuStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripMenuItemPreset});
            this.MenuStripMenuItemFile.Name = "MenuStripMenuItemFile";
            this.MenuStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.MenuStripMenuItemFile.Text = "File";
            // 
            // MenuStripMenuItemPreset
            // 
            this.MenuStripMenuItemPreset.Name = "MenuStripMenuItemPreset";
            this.MenuStripMenuItemPreset.Size = new System.Drawing.Size(93, 22);
            this.MenuStripMenuItemPreset.Text = "Exit";
            this.MenuStripMenuItemPreset.Click += new System.EventHandler(this.MenuStripMenuItemPreset_Click);
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
            this.StripStatusMainForm.Size = new System.Drawing.Size(1001, 22);
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
            this.ClientSize = new System.Drawing.Size(1001, 734);
            this.Controls.Add(this.LabelCopyright);
            this.Controls.Add(this.StripStatusMainForm);
            this.Controls.Add(this.TabControlMain);
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
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSweeps)).EndInit();
            this.GroupBox_SweepControl.ResumeLayout(false);
            this.GroupBox_SweepControl.PerformLayout();
            this.GroupBox_ReceivedSignalStrength.ResumeLayout(false);
            this.GroupBox_ReceivedSignalStrength.PerformLayout();
            this.TabControlMain.ResumeLayout(false);
            this.TabControlMainConnection.ResumeLayout(false);
            this.TabControlMainConnection.PerformLayout();
            this.GroupBox_DocumentationAndUSBTroubleShooting.ResumeLayout(false);
            this.GroupBox_DocumentationAndUSBTroubleShooting.PerformLayout();
            this.TabControlMainOmniDirectional.ResumeLayout(false);
            this.GroupBox_OmniDirectional_CurrentConfiguration.ResumeLayout(false);
            this.GroupBox_OmniDirectional_CurrentConfiguration.PerformLayout();
            this.TabControlMainRadial.ResumeLayout(false);
            this.TabControlMainRadial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRadialAzimuth)).EndInit();
            this.TabControlSiteImage.ResumeLayout(false);
            this.TabControlSiteImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.TabControlCalibration.ResumeLayout(false);
            this.TabControlCalibration.PerformLayout();
            this.GroupBox_CSVFileStorage.ResumeLayout(false);
            this.GroupBox_CSVFileStorage.PerformLayout();
            this.GroupBoxCsvInformation.ResumeLayout(false);
            this.GroupBox_CSVFileStorage_AutoNext.ResumeLayout(false);
            this.GroupBox_CSVFileStorage_AutoNext.PerformLayout();
            this.GroupBoxClientId.ResumeLayout(false);
            this.GroupBoxClientId.PerformLayout();
            this.GroupBoxFloorId.ResumeLayout(false);
            this.GroupBoxFloorId.PerformLayout();
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


         

        private Button Button_ConnectRFExplorer;
        private Button ButtonStartSweeps;
        private GroupBox GroupBox_SweepControl;
        private Label Label_DeviceValue;
        private Label Label_ModelValue;
        private Label Label_Firmware;
        private Label Label_FirmwareValue;
        private Label Label_ComPortValue;
        private Label LabelStartSweeps;
        private NumericUpDown NumericUpDownSweeps;
        private ProgressBar TaskProgressBar;
        private CheckBox CheckBoxSaveCsvFiles;
        private CheckBox CheckBoxChartPeak;
        private CheckBox CheckBoxChartAverage;
        private CheckBox CheckBoxChartAutoScale;
        private Label Label_Device;
        private Label Label_Model;
        private ToolTip ToolTip1;
        private GroupBox GroupBox_CSVFileStorage;
        private TextBox TextBoxCsvFileName;
        private TextBox TextBoxCollectionLocation;
        private RadioButton RadioButton_SignalGenerator;
        private RadioButton RadioButton_SpectrumAnalyzer;
        private Label LabelProgressWriteCsvFile;
        private Button Button_REEDocumentation;
        private Label LabelCopyright;
        private Button ButtonCancelSweeps;
        private Label LabelTaskCount;
        private Label LabelExecTask;
        private CheckBox CheckBoxRadialAzimuth;
        private NumericUpDown NumericUpDown_CSVFileStorage_MarkerNumber;
        private TextBox TextBox_CSVFileStorage_CollectionMarkerName;
        private CheckBox CheckBoxAutoIncrementMarkerNumber;
        private TextBox TextBoxClient;
        private GroupBox GroupBox_OmniDirectional_CurrentConfiguration;
        private Button ButtonGetRfeConfiguration;
        private Label LabelPresets;
        private ComboBox ComboBoxPreset;
        private Label LabelRightAntennaGainUnit;
        private TextBox TextBoxRightAntennaGain;
        private Label LabelRightAntennaGain;
        private Label LabelLeftAntennaGainUnit;
        private TextBox TextBoxLeftAntennaGain;
        private Label LabelLeftAntennaGain;
        private TextBox TextBoxStepFrequency;
        private TextBox TextBoxRBW;
        private Label LabelStopFrequencyUnit;
        private Label LabelStartFrequencyUnit;
        private Button ButtonSetConfiguration;
        private Label LabelFrequencyStepUnit;
        private Label LabelStartFrequency;
        private Label LabelFrequencyStep;
        private TextBox TextBoxStartFrequency;
        private TextBox TextBoxStopFrequency;
        private Label LabelStopFrequency;
        private Label LabelRBWUnit;
        private Label LabelRBW;
        private Label LabelRadialAzimuth;
        private NumericUpDown NumericUpDownRadialAzimuth;
        private Label LabelActualSweeps;
        private MenuStrip MenuStripMainForm;
        private ToolStripMenuItem MenuStripMenuItemFile;
        private ToolStripMenuItem MenuStripMenuItemPreset;
        private CheckBox CheckBoxHoldStep;
        private CheckBox CheckBoxHoldStop;
        private CheckBox CheckBoxHoldStart;
        private TextBox TextBox_CSVFileStorage_CollectionFloorName;
        private GroupBox GroupBoxFloorId;
        private RadioButton RadioButton_CSVFileStorage_FloorIncrement;
        private RadioButton RadioButton_CSVFileStorage_FloorDecrement;
        private NumericUpDown NumericUpDown_CSVFileStorage_FloorNumber;
        private GroupBox GroupBox_CSVFileStorage_CollectionMarker;
        private TabControl TabControlMain;
        private TabPage TabControlMainConnection;
        private TabPage TabControlMainOmniDirectional;
        private TabPage TabControlMainRadial;
        private Label LabelTrueNorthText;
        private Label Label_ComPortText;
        private GroupBox GroupBoxClientId;
        private Button Button_CSVFileStorage_CollectionFloor_Enable;
        private Button ButtonCaptureImage;
        private TabPage TabControlSiteImage;
        private PictureBox PictureBox;
        private Label LabelCaptured;
        private Button ButtonPersistClear;
        private StatusStrip StripStatusMainForm;
        private GroupBox GroupBoxCsvInformation;
        private GroupBox GroupBox_ReceivedSignalStrength;
        private Panel PanelChart;
        private ToolStripStatusLabel StripStatusLabelPreset;
        private ToolStripStatusLabel StripStatusLabelCsvDirectory;
        private ToolStripStatusLabel StripStatusLabelDivision1;
        private Button Button_USBTroubleShooting;
        private Button Button_USBDriverDownload;
        private GroupBox GroupBox_DocumentationAndUSBTroubleShooting;
        private ToolStripMenuItem uSBSettingsToolStripMenuItem;
        private ToolStripMenuItem force2400BaudToolStripMenuItem;
        private TabPage TabControlCalibration;
        private Button ButtonCalibrationStart;
        private Label label3;
        private TextBox TextBoxCalibrationPointsPerSweepInterval;
        private Label label2;
        private TextBox TextBoxCalibrationSourceDbm;
        private Label label1;
        private Button ButtonPauseResume;
        private Button Button_CSVFileStorage_Next;
        private GroupBox GroupBox_CSVFileStorage_AutoNext;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}

