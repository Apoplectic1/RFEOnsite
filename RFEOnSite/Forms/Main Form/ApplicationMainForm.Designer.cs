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
            this.ButtonFindCOMPorts = new System.Windows.Forms.Button();
            this.LabelRFEComPort = new System.Windows.Forms.Label();
            this.CheckBoxRadialAzimuth = new System.Windows.Forms.CheckBox();
            this.ButtonDocumentation = new System.Windows.Forms.Button();
            this.RadioButtonGenerator = new System.Windows.Forms.RadioButton();
            this.RadioButtonAnalyzer = new System.Windows.Forms.RadioButton();
            this.LabelModel = new System.Windows.Forms.Label();
            this.LabelDevice = new System.Windows.Forms.Label();
            this.LabelFirmwareText = new System.Windows.Forms.Label();
            this.LabelFirmware = new System.Windows.Forms.Label();
            this.LabelModelText = new System.Windows.Forms.Label();
            this.LabelDeviceText = new System.Windows.Forms.Label();
            this.ButtonStartSweeps = new System.Windows.Forms.Button();
            this.LabelStartSweeps = new System.Windows.Forms.Label();
            this.NumericUpDownSweeps = new System.Windows.Forms.NumericUpDown();
            this.GroupBoxSweepConfiguration = new System.Windows.Forms.GroupBox();
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
            this.GroupBoxCurrentSweepChartConfiguration = new System.Windows.Forms.GroupBox();
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
            this.GroupBoxCsvConfiguration = new System.Windows.Forms.GroupBox();
            this.GroupBoxCsvInformation = new System.Windows.Forms.GroupBox();
            this.GroupBoxClientId = new System.Windows.Forms.GroupBox();
            this.TextBoxClient = new System.Windows.Forms.TextBox();
            this.GroupBoxFloorId = new System.Windows.Forms.GroupBox();
            this.ButtonFloorId = new System.Windows.Forms.Button();
            this.RadioButtonFloorIncrement = new System.Windows.Forms.RadioButton();
            this.RadioButtonFloorDecrement = new System.Windows.Forms.RadioButton();
            this.NumericUpDownFloorNumber = new System.Windows.Forms.NumericUpDown();
            this.TextBoxFloorName = new System.Windows.Forms.TextBox();
            this.GroupBoxMarkerId = new System.Windows.Forms.GroupBox();
            this.TextBoxMarkerName = new System.Windows.Forms.TextBox();
            this.CheckBoxAutoIncrementMarkerNumber = new System.Windows.Forms.CheckBox();
            this.NumericUpDownMarkerNumber = new System.Windows.Forms.NumericUpDown();
            this.LabelRadialAzimuth = new System.Windows.Forms.Label();
            this.NumericUpDownRadialAzimuth = new System.Windows.Forms.NumericUpDown();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.GroupBoxConfiguration = new System.Windows.Forms.GroupBox();
            this.CheckBoxHoldStep = new System.Windows.Forms.CheckBox();
            this.CheckBoxHoldStop = new System.Windows.Forms.CheckBox();
            this.CheckBoxHoldStart = new System.Windows.Forms.CheckBox();
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
            this.LabelStartFrequency = new System.Windows.Forms.Label();
            this.LabelFrequencyStep = new System.Windows.Forms.Label();
            this.TextBoxStartFrequency = new System.Windows.Forms.TextBox();
            this.TextBoxStopFrequency = new System.Windows.Forms.TextBox();
            this.LabelRBWUnit = new System.Windows.Forms.Label();
            this.MenuStripMainForm = new System.Windows.Forms.MenuStrip();
            this.MenuStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripMenuItemPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.force2400BaudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabControlMainConnection = new System.Windows.Forms.TabPage();
            this.LabelPortText = new System.Windows.Forms.Label();
            this.GroupBoxDocumentation = new System.Windows.Forms.GroupBox();
            this.BaudRate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TabControlMainOmniDirectional = new System.Windows.Forms.TabPage();
            this.TabControlMainRadial = new System.Windows.Forms.TabPage();
            this.LabelTrueNorthText = new System.Windows.Forms.Label();
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
            this.StripStatusMainForm = new System.Windows.Forms.StatusStrip();
            this.StripStatusLabelPreset = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatusLabelDivision1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatusLabelCsvDirectory = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSweeps)).BeginInit();
            this.GroupBoxSweepConfiguration.SuspendLayout();
            this.GroupBoxCurrentSweepChartConfiguration.SuspendLayout();
            this.GroupBoxCsvConfiguration.SuspendLayout();
            this.GroupBoxCsvInformation.SuspendLayout();
            this.GroupBoxClientId.SuspendLayout();
            this.GroupBoxFloorId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownFloorNumber)).BeginInit();
            this.GroupBoxMarkerId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownMarkerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRadialAzimuth)).BeginInit();
            this.GroupBoxConfiguration.SuspendLayout();
            this.MenuStripMainForm.SuspendLayout();
            this.TabControlMain.SuspendLayout();
            this.TabControlMainConnection.SuspendLayout();
            this.GroupBoxDocumentation.SuspendLayout();
            this.TabControlMainOmniDirectional.SuspendLayout();
            this.TabControlMainRadial.SuspendLayout();
            this.TabControlSiteImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.TabControlCalibration.SuspendLayout();
            this.StripStatusMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonFindCOMPorts
            // 
            this.ButtonFindCOMPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(197)))), ((int)(((byte)(202)))), ((int)(((byte)(31)))));
            this.ButtonFindCOMPorts.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonFindCOMPorts.FlatAppearance.BorderSize = 5;
            this.ButtonFindCOMPorts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ButtonFindCOMPorts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonFindCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonFindCOMPorts.Location = new System.Drawing.Point(81, 36);
            this.ButtonFindCOMPorts.Name = "ButtonFindCOMPorts";
            this.ButtonFindCOMPorts.Size = new System.Drawing.Size(155, 73);
            this.ButtonFindCOMPorts.TabIndex = 0;
            this.ButtonFindCOMPorts.Text = "Connect RF Explorer";
            this.ButtonFindCOMPorts.UseVisualStyleBackColor = false;
            this.ButtonFindCOMPorts.Click += new System.EventHandler(this.ButtonFindPorts_Click);
            // 
            // LabelRFEComPort
            // 
            this.LabelRFEComPort.BackColor = System.Drawing.Color.Transparent;
            this.LabelRFEComPort.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelRFEComPort.Location = new System.Drawing.Point(365, 33);
            this.LabelRFEComPort.Name = "LabelRFEComPort";
            this.LabelRFEComPort.Size = new System.Drawing.Size(124, 22);
            this.LabelRFEComPort.TabIndex = 1;
            this.LabelRFEComPort.Text = "Not Connected";
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
            // ButtonDocumentation
            // 
            this.ButtonDocumentation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonDocumentation.Location = new System.Drawing.Point(35, 29);
            this.ButtonDocumentation.Name = "ButtonDocumentation";
            this.ButtonDocumentation.Size = new System.Drawing.Size(179, 51);
            this.ButtonDocumentation.TabIndex = 16;
            this.ButtonDocumentation.Text = "RF Explorer Documentation";
            this.ButtonDocumentation.UseVisualStyleBackColor = true;
            this.ButtonDocumentation.Click += new System.EventHandler(this.ButtonDocumentation_Click);
            // 
            // RadioButtonGenerator
            // 
            this.RadioButtonGenerator.AutoSize = true;
            this.RadioButtonGenerator.BackColor = System.Drawing.Color.Transparent;
            this.RadioButtonGenerator.Location = new System.Drawing.Point(247, 56);
            this.RadioButtonGenerator.Name = "RadioButtonGenerator";
            this.RadioButtonGenerator.Size = new System.Drawing.Size(148, 24);
            this.RadioButtonGenerator.TabIndex = 15;
            this.RadioButtonGenerator.Text = "Signal Generator";
            this.RadioButtonGenerator.UseVisualStyleBackColor = false;
            this.RadioButtonGenerator.CheckedChanged += new System.EventHandler(this.RadioButtonGenerator_CheckedChanged);
            // 
            // RadioButtonAnalyzer
            // 
            this.RadioButtonAnalyzer.AutoSize = true;
            this.RadioButtonAnalyzer.BackColor = System.Drawing.Color.Transparent;
            this.RadioButtonAnalyzer.Checked = true;
            this.RadioButtonAnalyzer.Location = new System.Drawing.Point(247, 29);
            this.RadioButtonAnalyzer.Name = "RadioButtonAnalyzer";
            this.RadioButtonAnalyzer.Size = new System.Drawing.Size(161, 24);
            this.RadioButtonAnalyzer.TabIndex = 14;
            this.RadioButtonAnalyzer.TabStop = true;
            this.RadioButtonAnalyzer.Text = "Spectrum Analyzer";
            this.RadioButtonAnalyzer.UseVisualStyleBackColor = false;
            this.RadioButtonAnalyzer.CheckedChanged += new System.EventHandler(this.RadioButtonAnalyzer_CheckedChanged);
            // 
            // LabelModel
            // 
            this.LabelModel.AutoSize = true;
            this.LabelModel.BackColor = System.Drawing.Color.Transparent;
            this.LabelModel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelModel.Location = new System.Drawing.Point(301, 91);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.Size = new System.Drawing.Size(56, 20);
            this.LabelModel.TabIndex = 13;
            this.LabelModel.Text = "Model:";
            // 
            // LabelDevice
            // 
            this.LabelDevice.AutoSize = true;
            this.LabelDevice.BackColor = System.Drawing.Color.Transparent;
            this.LabelDevice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelDevice.Location = new System.Drawing.Point(298, 72);
            this.LabelDevice.Name = "LabelDevice";
            this.LabelDevice.Size = new System.Drawing.Size(61, 20);
            this.LabelDevice.TabIndex = 12;
            this.LabelDevice.Text = "Device:";
            // 
            // LabelFirmwareText
            // 
            this.LabelFirmwareText.AutoSize = true;
            this.LabelFirmwareText.BackColor = System.Drawing.Color.Transparent;
            this.LabelFirmwareText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelFirmwareText.Location = new System.Drawing.Point(365, 53);
            this.LabelFirmwareText.Name = "LabelFirmwareText";
            this.LabelFirmwareText.Size = new System.Drawing.Size(35, 20);
            this.LabelFirmwareText.TabIndex = 5;
            this.LabelFirmwareText.Text = "N/A";
            this.LabelFirmwareText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelFirmware
            // 
            this.LabelFirmware.AutoSize = true;
            this.LabelFirmware.BackColor = System.Drawing.Color.Transparent;
            this.LabelFirmware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelFirmware.Location = new System.Drawing.Point(279, 53);
            this.LabelFirmware.Name = "LabelFirmware";
            this.LabelFirmware.Size = new System.Drawing.Size(78, 20);
            this.LabelFirmware.TabIndex = 4;
            this.LabelFirmware.Text = "Firmware:";
            // 
            // LabelModelText
            // 
            this.LabelModelText.AutoSize = true;
            this.LabelModelText.BackColor = System.Drawing.Color.Transparent;
            this.LabelModelText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelModelText.Location = new System.Drawing.Point(365, 91);
            this.LabelModelText.Name = "LabelModelText";
            this.LabelModelText.Size = new System.Drawing.Size(35, 20);
            this.LabelModelText.TabIndex = 3;
            this.LabelModelText.Text = "N/A";
            // 
            // LabelDeviceText
            // 
            this.LabelDeviceText.AutoSize = true;
            this.LabelDeviceText.BackColor = System.Drawing.Color.Transparent;
            this.LabelDeviceText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelDeviceText.Location = new System.Drawing.Point(365, 72);
            this.LabelDeviceText.Name = "LabelDeviceText";
            this.LabelDeviceText.Size = new System.Drawing.Size(35, 20);
            this.LabelDeviceText.TabIndex = 2;
            this.LabelDeviceText.Text = "N/A";
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
            // GroupBoxSweepConfiguration
            // 
            this.GroupBoxSweepConfiguration.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBoxSweepConfiguration.Controls.Add(this.LabelActualSweeps);
            this.GroupBoxSweepConfiguration.Controls.Add(this.LabelTaskCount);
            this.GroupBoxSweepConfiguration.Controls.Add(this.LabelExecTask);
            this.GroupBoxSweepConfiguration.Controls.Add(this.ButtonCancelSweeps);
            this.GroupBoxSweepConfiguration.Controls.Add(this.LabelProgressWriteCsvFile);
            this.GroupBoxSweepConfiguration.Controls.Add(this.TaskProgressBar);
            this.GroupBoxSweepConfiguration.Controls.Add(this.LabelStartSweeps);
            this.GroupBoxSweepConfiguration.Controls.Add(this.ButtonStartSweeps);
            this.GroupBoxSweepConfiguration.Controls.Add(this.NumericUpDownSweeps);
            this.GroupBoxSweepConfiguration.Controls.Add(this.TextBoxCsvFileName);
            this.GroupBoxSweepConfiguration.Enabled = false;
            this.GroupBoxSweepConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxSweepConfiguration.Location = new System.Drawing.Point(550, 490);
            this.GroupBoxSweepConfiguration.Name = "GroupBoxSweepConfiguration";
            this.GroupBoxSweepConfiguration.Size = new System.Drawing.Size(437, 215);
            this.GroupBoxSweepConfiguration.TabIndex = 16;
            this.GroupBoxSweepConfiguration.TabStop = false;
            this.GroupBoxSweepConfiguration.Text = "Sweep Control";
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
            // GroupBoxCurrentSweepChartConfiguration
            // 
            this.GroupBoxCurrentSweepChartConfiguration.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBoxCurrentSweepChartConfiguration.Controls.Add(this.CheckBoxChartAutoScale);
            this.GroupBoxCurrentSweepChartConfiguration.Controls.Add(this.CheckBoxChartAverage);
            this.GroupBoxCurrentSweepChartConfiguration.Controls.Add(this.CheckBoxChartPeak);
            this.GroupBoxCurrentSweepChartConfiguration.Controls.Add(this.PanelChart);
            this.GroupBoxCurrentSweepChartConfiguration.Enabled = false;
            this.GroupBoxCurrentSweepChartConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxCurrentSweepChartConfiguration.Location = new System.Drawing.Point(550, 27);
            this.GroupBoxCurrentSweepChartConfiguration.Name = "GroupBoxCurrentSweepChartConfiguration";
            this.GroupBoxCurrentSweepChartConfiguration.Size = new System.Drawing.Size(437, 457);
            this.GroupBoxCurrentSweepChartConfiguration.TabIndex = 4;
            this.GroupBoxCurrentSweepChartConfiguration.TabStop = false;
            this.GroupBoxCurrentSweepChartConfiguration.Text = "Received Signal Strength";
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
            this.LabelRBW.Location = new System.Drawing.Point(4, 75);
            this.LabelRBW.Name = "LabelRBW";
            this.LabelRBW.Size = new System.Drawing.Size(164, 20);
            this.LabelRBW.TabIndex = 5;
            this.LabelRBW.Text = "Resolution Bandwidth";
            this.ToolTip1.SetToolTip(this.LabelRBW, resources.GetString("LabelRBW.ToolTip"));
            // 
            // ButtonSetConfiguration
            // 
            this.ButtonSetConfiguration.Enabled = false;
            this.ButtonSetConfiguration.Location = new System.Drawing.Point(338, 23);
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
            this.TextBoxRBW.Location = new System.Drawing.Point(168, 71);
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
            this.ButtonGetRfeConfiguration.Location = new System.Drawing.Point(338, 89);
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
            this.LabelStopFrequency.Location = new System.Drawing.Point(46, 51);
            this.LabelStopFrequency.Name = "LabelStopFrequency";
            this.LabelStopFrequency.Size = new System.Drawing.Size(122, 20);
            this.LabelStopFrequency.TabIndex = 4;
            this.LabelStopFrequency.Text = "Stop Frequency";
            this.ToolTip1.SetToolTip(this.LabelStopFrequency, "The frequency at which to stop sampling - plus one bin. The RF Explorer always sa" +
        "mples using 112 bins. Each Bin ");
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
            // GroupBoxCsvConfiguration
            // 
            this.GroupBoxCsvConfiguration.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBoxCsvConfiguration.Controls.Add(this.CheckBoxSaveCsvFiles);
            this.GroupBoxCsvConfiguration.Controls.Add(this.GroupBoxCsvInformation);
            this.GroupBoxCsvConfiguration.Enabled = false;
            this.GroupBoxCsvConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBoxCsvConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxCsvConfiguration.Location = new System.Drawing.Point(14, 379);
            this.GroupBoxCsvConfiguration.Name = "GroupBoxCsvConfiguration";
            this.GroupBoxCsvConfiguration.Size = new System.Drawing.Size(526, 326);
            this.GroupBoxCsvConfiguration.TabIndex = 23;
            this.GroupBoxCsvConfiguration.TabStop = false;
            this.GroupBoxCsvConfiguration.Text = "CSV File Storage";
            // 
            // GroupBoxCsvInformation
            // 
            this.GroupBoxCsvInformation.Controls.Add(this.ButtonPersistClear);
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBoxClientId);
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBoxFloorId);
            this.GroupBoxCsvInformation.Controls.Add(this.GroupBoxMarkerId);
            this.GroupBoxCsvInformation.Enabled = false;
            this.GroupBoxCsvInformation.Location = new System.Drawing.Point(8, 51);
            this.GroupBoxCsvInformation.Name = "GroupBoxCsvInformation";
            this.GroupBoxCsvInformation.Size = new System.Drawing.Size(512, 262);
            this.GroupBoxCsvInformation.TabIndex = 46;
            this.GroupBoxCsvInformation.TabStop = false;
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
            this.GroupBoxFloorId.Controls.Add(this.ButtonFloorId);
            this.GroupBoxFloorId.Controls.Add(this.RadioButtonFloorIncrement);
            this.GroupBoxFloorId.Controls.Add(this.RadioButtonFloorDecrement);
            this.GroupBoxFloorId.Controls.Add(this.NumericUpDownFloorNumber);
            this.GroupBoxFloorId.Controls.Add(this.TextBoxFloorName);
            this.GroupBoxFloorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxFloorId.Location = new System.Drawing.Point(20, 121);
            this.GroupBoxFloorId.Name = "GroupBoxFloorId";
            this.GroupBoxFloorId.Size = new System.Drawing.Size(358, 63);
            this.GroupBoxFloorId.TabIndex = 42;
            this.GroupBoxFloorId.TabStop = false;
            this.GroupBoxFloorId.Text = "Collection Floor";
            // 
            // ButtonFloorId
            // 
            this.ButtonFloorId.BackColor = System.Drawing.Color.Olive;
            this.ButtonFloorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonFloorId.Location = new System.Drawing.Point(192, 22);
            this.ButtonFloorId.Name = "ButtonFloorId";
            this.ButtonFloorId.Size = new System.Drawing.Size(75, 29);
            this.ButtonFloorId.TabIndex = 42;
            this.ButtonFloorId.Text = "Enable";
            this.ButtonFloorId.UseVisualStyleBackColor = false;
            this.ButtonFloorId.Click += new System.EventHandler(this.ButtonFloorId_Click);
            // 
            // RadioButtonFloorIncrement
            // 
            this.RadioButtonFloorIncrement.AutoSize = true;
            this.RadioButtonFloorIncrement.Checked = true;
            this.RadioButtonFloorIncrement.Enabled = false;
            this.RadioButtonFloorIncrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonFloorIncrement.Location = new System.Drawing.Point(277, 38);
            this.RadioButtonFloorIncrement.Name = "RadioButtonFloorIncrement";
            this.RadioButtonFloorIncrement.Size = new System.Drawing.Size(72, 17);
            this.RadioButtonFloorIncrement.TabIndex = 41;
            this.RadioButtonFloorIncrement.TabStop = true;
            this.RadioButtonFloorIncrement.Text = "Increment";
            this.RadioButtonFloorIncrement.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFloorDecrement
            // 
            this.RadioButtonFloorDecrement.AutoSize = true;
            this.RadioButtonFloorDecrement.Enabled = false;
            this.RadioButtonFloorDecrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonFloorDecrement.Location = new System.Drawing.Point(277, 21);
            this.RadioButtonFloorDecrement.Name = "RadioButtonFloorDecrement";
            this.RadioButtonFloorDecrement.Size = new System.Drawing.Size(77, 17);
            this.RadioButtonFloorDecrement.TabIndex = 40;
            this.RadioButtonFloorDecrement.Text = "Decrement";
            this.RadioButtonFloorDecrement.UseVisualStyleBackColor = true;
            // 
            // NumericUpDownFloorNumber
            // 
            this.NumericUpDownFloorNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.NumericUpDownFloorNumber.Enabled = false;
            this.NumericUpDownFloorNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDownFloorNumber.Location = new System.Drawing.Point(142, 21);
            this.NumericUpDownFloorNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownFloorNumber.Name = "NumericUpDownFloorNumber";
            this.NumericUpDownFloorNumber.Size = new System.Drawing.Size(46, 31);
            this.NumericUpDownFloorNumber.TabIndex = 39;
            this.NumericUpDownFloorNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDownFloorNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownFloorNumber.ValueChanged += new System.EventHandler(this.NumericUpDownAutoText_ValueChanged);
            // 
            // TextBoxFloorName
            // 
            this.TextBoxFloorName.Enabled = false;
            this.TextBoxFloorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxFloorName.Location = new System.Drawing.Point(6, 23);
            this.TextBoxFloorName.Name = "TextBoxFloorName";
            this.TextBoxFloorName.Size = new System.Drawing.Size(132, 26);
            this.TextBoxFloorName.TabIndex = 37;
            this.TextBoxFloorName.Text = "Floor";
            this.TextBoxFloorName.TextChanged += new System.EventHandler(this.TextBoxFloorLabel_TextChanged);
            // 
            // GroupBoxMarkerId
            // 
            this.GroupBoxMarkerId.Controls.Add(this.TextBoxMarkerName);
            this.GroupBoxMarkerId.Controls.Add(this.CheckBoxAutoIncrementMarkerNumber);
            this.GroupBoxMarkerId.Controls.Add(this.NumericUpDownMarkerNumber);
            this.GroupBoxMarkerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxMarkerId.Location = new System.Drawing.Point(20, 191);
            this.GroupBoxMarkerId.Name = "GroupBoxMarkerId";
            this.GroupBoxMarkerId.Size = new System.Drawing.Size(358, 63);
            this.GroupBoxMarkerId.TabIndex = 37;
            this.GroupBoxMarkerId.TabStop = false;
            this.GroupBoxMarkerId.Text = "Collection Site Marker";
            // 
            // TextBoxMarkerName
            // 
            this.TextBoxMarkerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxMarkerName.Location = new System.Drawing.Point(6, 27);
            this.TextBoxMarkerName.Name = "TextBoxMarkerName";
            this.TextBoxMarkerName.Size = new System.Drawing.Size(132, 26);
            this.TextBoxMarkerName.TabIndex = 30;
            this.TextBoxMarkerName.Text = "M";
            this.TextBoxMarkerName.TextChanged += new System.EventHandler(this.TextBoxCollectionSite_TextChanged);
            // 
            // CheckBoxAutoIncrementMarkerNumber
            // 
            this.CheckBoxAutoIncrementMarkerNumber.AutoSize = true;
            this.CheckBoxAutoIncrementMarkerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxAutoIncrementMarkerNumber.Location = new System.Drawing.Point(224, 32);
            this.CheckBoxAutoIncrementMarkerNumber.Name = "CheckBoxAutoIncrementMarkerNumber";
            this.CheckBoxAutoIncrementMarkerNumber.Size = new System.Drawing.Size(101, 17);
            this.CheckBoxAutoIncrementMarkerNumber.TabIndex = 29;
            this.CheckBoxAutoIncrementMarkerNumber.Text = "Auto Increment ";
            this.CheckBoxAutoIncrementMarkerNumber.UseVisualStyleBackColor = true;
            this.CheckBoxAutoIncrementMarkerNumber.CheckedChanged += new System.EventHandler(this.CheckBoxAutoIncrement_CheckedChanged);
            // 
            // NumericUpDownMarkerNumber
            // 
            this.NumericUpDownMarkerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDownMarkerNumber.Location = new System.Drawing.Point(142, 25);
            this.NumericUpDownMarkerNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownMarkerNumber.Name = "NumericUpDownMarkerNumber";
            this.NumericUpDownMarkerNumber.Size = new System.Drawing.Size(46, 31);
            this.NumericUpDownMarkerNumber.TabIndex = 18;
            this.NumericUpDownMarkerNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDownMarkerNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownMarkerNumber.ValueChanged += new System.EventHandler(this.NumericUpDownLocation_ValueChanged);
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
            // LabelCopyright
            // 
            this.LabelCopyright.AutoSize = true;
            this.LabelCopyright.BackColor = System.Drawing.SystemColors.Control;
            this.LabelCopyright.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelCopyright.Location = new System.Drawing.Point(771, 717);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(207, 13);
            this.LabelCopyright.TabIndex = 25;
            this.LabelCopyright.Text = "Copyright 2018 - Skyhawk Consulting, Inc.";
            // 
            // GroupBoxConfiguration
            // 
            this.GroupBoxConfiguration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(11)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.GroupBoxConfiguration.Controls.Add(this.ComboBoxPreset);
            this.GroupBoxConfiguration.Controls.Add(this.CheckBoxHoldStep);
            this.GroupBoxConfiguration.Controls.Add(this.CheckBoxHoldStop);
            this.GroupBoxConfiguration.Controls.Add(this.CheckBoxHoldStart);
            this.GroupBoxConfiguration.Controls.Add(this.ButtonGetRfeConfiguration);
            this.GroupBoxConfiguration.Controls.Add(this.LabelPresets);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRightAntennaGainUnit);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxRightAntennaGain);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRightAntennaGain);
            this.GroupBoxConfiguration.Controls.Add(this.LabelLeftAntennaGainUnit);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxLeftAntennaGain);
            this.GroupBoxConfiguration.Controls.Add(this.LabelLeftAntennaGain);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxStepFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxRBW);
            this.GroupBoxConfiguration.Controls.Add(this.LabelStopFrequencyUnit);
            this.GroupBoxConfiguration.Controls.Add(this.LabelStartFrequencyUnit);
            this.GroupBoxConfiguration.Controls.Add(this.ButtonSetConfiguration);
            this.GroupBoxConfiguration.Controls.Add(this.LabelFrequencyStepUnit);
            this.GroupBoxConfiguration.Controls.Add(this.LabelStartFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.LabelFrequencyStep);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxStartFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxStopFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.LabelStopFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRBWUnit);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRBW);
            this.GroupBoxConfiguration.Enabled = false;
            this.GroupBoxConfiguration.Location = new System.Drawing.Point(16, 21);
            this.GroupBoxConfiguration.Name = "GroupBoxConfiguration";
            this.GroupBoxConfiguration.Size = new System.Drawing.Size(490, 274);
            this.GroupBoxConfiguration.TabIndex = 10;
            this.GroupBoxConfiguration.TabStop = false;
            this.GroupBoxConfiguration.Text = "Current Configuration";
            // 
            // CheckBoxHoldStep
            // 
            this.CheckBoxHoldStep.AutoSize = true;
            this.CheckBoxHoldStep.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxHoldStep.Enabled = false;
            this.CheckBoxHoldStep.Location = new System.Drawing.Point(272, 97);
            this.CheckBoxHoldStep.Name = "CheckBoxHoldStep";
            this.CheckBoxHoldStep.Size = new System.Drawing.Size(61, 24);
            this.CheckBoxHoldStep.TabIndex = 30;
            this.CheckBoxHoldStep.Text = "Hold";
            this.CheckBoxHoldStep.UseVisualStyleBackColor = false;
            // 
            // CheckBoxHoldStop
            // 
            this.CheckBoxHoldStop.AutoSize = true;
            this.CheckBoxHoldStop.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxHoldStop.Enabled = false;
            this.CheckBoxHoldStop.Location = new System.Drawing.Point(272, 49);
            this.CheckBoxHoldStop.Name = "CheckBoxHoldStop";
            this.CheckBoxHoldStop.Size = new System.Drawing.Size(61, 24);
            this.CheckBoxHoldStop.TabIndex = 29;
            this.CheckBoxHoldStop.Text = "Hold";
            this.CheckBoxHoldStop.UseVisualStyleBackColor = false;
            // 
            // CheckBoxHoldStart
            // 
            this.CheckBoxHoldStart.AutoSize = true;
            this.CheckBoxHoldStart.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxHoldStart.Enabled = false;
            this.CheckBoxHoldStart.Location = new System.Drawing.Point(272, 25);
            this.CheckBoxHoldStart.Name = "CheckBoxHoldStart";
            this.CheckBoxHoldStart.Size = new System.Drawing.Size(61, 24);
            this.CheckBoxHoldStart.TabIndex = 28;
            this.CheckBoxHoldStart.Text = "Hold";
            this.CheckBoxHoldStart.UseVisualStyleBackColor = false;
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
            this.LabelRightAntennaGainUnit.Location = new System.Drawing.Point(224, 161);
            this.LabelRightAntennaGainUnit.Name = "LabelRightAntennaGainUnit";
            this.LabelRightAntennaGainUnit.Size = new System.Drawing.Size(29, 20);
            this.LabelRightAntennaGainUnit.TabIndex = 24;
            this.LabelRightAntennaGainUnit.Text = "dB";
            // 
            // TextBoxRightAntennaGain
            // 
            this.TextBoxRightAntennaGain.Enabled = false;
            this.TextBoxRightAntennaGain.Location = new System.Drawing.Point(168, 157);
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
            this.LabelRightAntennaGain.Location = new System.Drawing.Point(18, 161);
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
            this.LabelLeftAntennaGainUnit.Location = new System.Drawing.Point(224, 135);
            this.LabelLeftAntennaGainUnit.Name = "LabelLeftAntennaGainUnit";
            this.LabelLeftAntennaGainUnit.Size = new System.Drawing.Size(29, 20);
            this.LabelLeftAntennaGainUnit.TabIndex = 21;
            this.LabelLeftAntennaGainUnit.Text = "dB";
            // 
            // TextBoxLeftAntennaGain
            // 
            this.TextBoxLeftAntennaGain.Enabled = false;
            this.TextBoxLeftAntennaGain.Location = new System.Drawing.Point(168, 131);
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
            this.LabelLeftAntennaGain.Location = new System.Drawing.Point(28, 135);
            this.LabelLeftAntennaGain.Name = "LabelLeftAntennaGain";
            this.LabelLeftAntennaGain.Size = new System.Drawing.Size(140, 20);
            this.LabelLeftAntennaGain.TabIndex = 19;
            this.LabelLeftAntennaGain.Text = "Left Antenna Gain";
            // 
            // TextBoxStepFrequency
            // 
            this.TextBoxStepFrequency.Enabled = false;
            this.TextBoxStepFrequency.Location = new System.Drawing.Point(168, 95);
            this.TextBoxStepFrequency.Name = "TextBoxStepFrequency";
            this.TextBoxStepFrequency.Size = new System.Drawing.Size(56, 26);
            this.TextBoxStepFrequency.TabIndex = 18;
            this.TextBoxStepFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LabelStopFrequencyUnit
            // 
            this.LabelStopFrequencyUnit.AutoSize = true;
            this.LabelStopFrequencyUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelStopFrequencyUnit.Location = new System.Drawing.Point(224, 51);
            this.LabelStopFrequencyUnit.Name = "LabelStopFrequencyUnit";
            this.LabelStopFrequencyUnit.Size = new System.Drawing.Size(42, 20);
            this.LabelStopFrequencyUnit.TabIndex = 16;
            this.LabelStopFrequencyUnit.Text = "MHz";
            // 
            // LabelStartFrequencyUnit
            // 
            this.LabelStartFrequencyUnit.AutoSize = true;
            this.LabelStartFrequencyUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelStartFrequencyUnit.Location = new System.Drawing.Point(224, 27);
            this.LabelStartFrequencyUnit.Name = "LabelStartFrequencyUnit";
            this.LabelStartFrequencyUnit.Size = new System.Drawing.Size(42, 20);
            this.LabelStartFrequencyUnit.TabIndex = 15;
            this.LabelStartFrequencyUnit.Text = "MHz";
            // 
            // LabelFrequencyStepUnit
            // 
            this.LabelFrequencyStepUnit.AutoSize = true;
            this.LabelFrequencyStepUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelFrequencyStepUnit.Location = new System.Drawing.Point(224, 99);
            this.LabelFrequencyStepUnit.Name = "LabelFrequencyStepUnit";
            this.LabelFrequencyStepUnit.Size = new System.Drawing.Size(39, 20);
            this.LabelFrequencyStepUnit.TabIndex = 9;
            this.LabelFrequencyStepUnit.Text = "KHz";
            // 
            // LabelStartFrequency
            // 
            this.LabelStartFrequency.AutoSize = true;
            this.LabelStartFrequency.BackColor = System.Drawing.Color.Transparent;
            this.LabelStartFrequency.Location = new System.Drawing.Point(45, 27);
            this.LabelStartFrequency.Name = "LabelStartFrequency";
            this.LabelStartFrequency.Size = new System.Drawing.Size(123, 20);
            this.LabelStartFrequency.TabIndex = 2;
            this.LabelStartFrequency.Text = "Start Frequency";
            // 
            // LabelFrequencyStep
            // 
            this.LabelFrequencyStep.AutoSize = true;
            this.LabelFrequencyStep.BackColor = System.Drawing.Color.Transparent;
            this.LabelFrequencyStep.Location = new System.Drawing.Point(46, 99);
            this.LabelFrequencyStep.Name = "LabelFrequencyStep";
            this.LabelFrequencyStep.Size = new System.Drawing.Size(122, 20);
            this.LabelFrequencyStep.TabIndex = 8;
            this.LabelFrequencyStep.Text = "Frequency Step";
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
            this.TextBoxStopFrequency.Location = new System.Drawing.Point(168, 47);
            this.TextBoxStopFrequency.Name = "TextBoxStopFrequency";
            this.TextBoxStopFrequency.Size = new System.Drawing.Size(56, 26);
            this.TextBoxStopFrequency.TabIndex = 7;
            this.TextBoxStopFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxStopFrequency.TextChanged += new System.EventHandler(this.TextBoxStopFrequency_TextChanged);
            // 
            // LabelRBWUnit
            // 
            this.LabelRBWUnit.AutoSize = true;
            this.LabelRBWUnit.BackColor = System.Drawing.Color.Transparent;
            this.LabelRBWUnit.Location = new System.Drawing.Point(224, 75);
            this.LabelRBWUnit.Name = "LabelRBWUnit";
            this.LabelRBWUnit.Size = new System.Drawing.Size(39, 20);
            this.LabelRBWUnit.TabIndex = 6;
            this.LabelRBWUnit.Text = "KHz";
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
            this.MenuStripMenuItemPreset.Size = new System.Drawing.Size(92, 22);
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
            this.TabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // TabControlMainConnection
            // 
            this.TabControlMainConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.TabControlMainConnection.Controls.Add(this.LabelPortText);
            this.TabControlMainConnection.Controls.Add(this.LabelModel);
            this.TabControlMainConnection.Controls.Add(this.LabelDevice);
            this.TabControlMainConnection.Controls.Add(this.ButtonFindCOMPorts);
            this.TabControlMainConnection.Controls.Add(this.LabelFirmwareText);
            this.TabControlMainConnection.Controls.Add(this.LabelRFEComPort);
            this.TabControlMainConnection.Controls.Add(this.LabelFirmware);
            this.TabControlMainConnection.Controls.Add(this.LabelDeviceText);
            this.TabControlMainConnection.Controls.Add(this.LabelModelText);
            this.TabControlMainConnection.Controls.Add(this.GroupBoxDocumentation);
            this.TabControlMainConnection.Location = new System.Drawing.Point(4, 29);
            this.TabControlMainConnection.Name = "TabControlMainConnection";
            this.TabControlMainConnection.Padding = new System.Windows.Forms.Padding(3);
            this.TabControlMainConnection.Size = new System.Drawing.Size(524, 313);
            this.TabControlMainConnection.TabIndex = 0;
            this.TabControlMainConnection.Text = "Connection";
            // 
            // LabelPortText
            // 
            this.LabelPortText.AutoSize = true;
            this.LabelPortText.BackColor = System.Drawing.Color.Transparent;
            this.LabelPortText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelPortText.Location = new System.Drawing.Point(275, 33);
            this.LabelPortText.Name = "LabelPortText";
            this.LabelPortText.Size = new System.Drawing.Size(82, 20);
            this.LabelPortText.TabIndex = 18;
            this.LabelPortText.Text = "COM Port:";
            // 
            // GroupBoxDocumentation
            // 
            this.GroupBoxDocumentation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBoxDocumentation.Controls.Add(this.BaudRate);
            this.GroupBoxDocumentation.Controls.Add(this.ButtonDocumentation);
            this.GroupBoxDocumentation.Controls.Add(this.button1);
            this.GroupBoxDocumentation.Controls.Add(this.RadioButtonGenerator);
            this.GroupBoxDocumentation.Controls.Add(this.RadioButtonAnalyzer);
            this.GroupBoxDocumentation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GroupBoxDocumentation.Location = new System.Drawing.Point(35, 132);
            this.GroupBoxDocumentation.Name = "GroupBoxDocumentation";
            this.GroupBoxDocumentation.Size = new System.Drawing.Size(455, 169);
            this.GroupBoxDocumentation.TabIndex = 21;
            this.GroupBoxDocumentation.TabStop = false;
            this.GroupBoxDocumentation.Text = "Documentation and USB Trouble Shooting";
            // 
            // BaudRate
            // 
            this.BaudRate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BaudRate.Location = new System.Drawing.Point(35, 98);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(179, 51);
            this.BaudRate.TabIndex = 19;
            this.BaudRate.Text = "USB Trouble Shooting";
            this.BaudRate.UseVisualStyleBackColor = true;
            this.BaudRate.Click += new System.EventHandler(this.BaudRate_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(247, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 51);
            this.button1.TabIndex = 20;
            this.button1.Text = "USB 6.7.5 Driver Download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TabControlMainOmniDirectional
            // 
            this.TabControlMainOmniDirectional.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TabControlMainOmniDirectional.Controls.Add(this.GroupBoxConfiguration);
            this.TabControlMainOmniDirectional.Location = new System.Drawing.Point(4, 29);
            this.TabControlMainOmniDirectional.Name = "TabControlMainOmniDirectional";
            this.TabControlMainOmniDirectional.Padding = new System.Windows.Forms.Padding(3);
            this.TabControlMainOmniDirectional.Size = new System.Drawing.Size(524, 313);
            this.TabControlMainOmniDirectional.TabIndex = 1;
            this.TabControlMainOmniDirectional.Text = "OmniDirectional";
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
            // LabelTrueNorthText
            // 
            this.LabelTrueNorthText.AutoSize = true;
            this.LabelTrueNorthText.Location = new System.Drawing.Point(215, 250);
            this.LabelTrueNorthText.Name = "LabelTrueNorthText";
            this.LabelTrueNorthText.Size = new System.Drawing.Size(84, 20);
            this.LabelTrueNorthText.TabIndex = 36;
            this.LabelTrueNorthText.Text = "True North";
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
            // StripStatusMainForm
            // 
            this.StripStatusMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatusLabelPreset,
            this.StripStatusLabelDivision1,
            this.StripStatusLabelCsvDirectory});
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1001, 734);
            this.Controls.Add(this.LabelCopyright);
            this.Controls.Add(this.StripStatusMainForm);
            this.Controls.Add(this.TabControlMain);
            this.Controls.Add(this.GroupBoxCurrentSweepChartConfiguration);
            this.Controls.Add(this.GroupBoxSweepConfiguration);
            this.Controls.Add(this.GroupBoxCsvConfiguration);
            this.Controls.Add(this.MenuStripMainForm);
            this.MainMenuStrip = this.MenuStripMainForm;
            this.Name = "MainForm";
            this.Text = "OnSite";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSweeps)).EndInit();
            this.GroupBoxSweepConfiguration.ResumeLayout(false);
            this.GroupBoxSweepConfiguration.PerformLayout();
            this.GroupBoxCurrentSweepChartConfiguration.ResumeLayout(false);
            this.GroupBoxCurrentSweepChartConfiguration.PerformLayout();
            this.GroupBoxCsvConfiguration.ResumeLayout(false);
            this.GroupBoxCsvConfiguration.PerformLayout();
            this.GroupBoxCsvInformation.ResumeLayout(false);
            this.GroupBoxClientId.ResumeLayout(false);
            this.GroupBoxClientId.PerformLayout();
            this.GroupBoxFloorId.ResumeLayout(false);
            this.GroupBoxFloorId.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownFloorNumber)).EndInit();
            this.GroupBoxMarkerId.ResumeLayout(false);
            this.GroupBoxMarkerId.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownMarkerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRadialAzimuth)).EndInit();
            this.GroupBoxConfiguration.ResumeLayout(false);
            this.GroupBoxConfiguration.PerformLayout();
            this.MenuStripMainForm.ResumeLayout(false);
            this.MenuStripMainForm.PerformLayout();
            this.TabControlMain.ResumeLayout(false);
            this.TabControlMainConnection.ResumeLayout(false);
            this.TabControlMainConnection.PerformLayout();
            this.GroupBoxDocumentation.ResumeLayout(false);
            this.GroupBoxDocumentation.PerformLayout();
            this.TabControlMainOmniDirectional.ResumeLayout(false);
            this.TabControlMainRadial.ResumeLayout(false);
            this.TabControlMainRadial.PerformLayout();
            this.TabControlSiteImage.ResumeLayout(false);
            this.TabControlSiteImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.TabControlCalibration.ResumeLayout(false);
            this.TabControlCalibration.PerformLayout();
            this.StripStatusMainForm.ResumeLayout(false);
            this.StripStatusMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


         

        private Button ButtonFindCOMPorts;
        private Button ButtonStartSweeps;
        private GroupBox GroupBoxSweepConfiguration;
        private Label LabelDeviceText;
        private Label LabelModelText;
        private Label LabelFirmware;
        private Label LabelFirmwareText;
        private Label LabelRFEComPort;
        private Label LabelStartSweeps;
        private NumericUpDown NumericUpDownSweeps;
        private ProgressBar TaskProgressBar;
        private CheckBox CheckBoxSaveCsvFiles;
        private CheckBox CheckBoxChartPeak;
        private CheckBox CheckBoxChartAverage;
        private CheckBox CheckBoxChartAutoScale;
        private Label LabelDevice;
        private Label LabelModel;
        private ToolTip ToolTip1;
        private GroupBox GroupBoxCsvConfiguration;
        private TextBox TextBoxCsvFileName;
        private TextBox TextBoxCollectionLocation;
        private RadioButton RadioButtonGenerator;
        private RadioButton RadioButtonAnalyzer;
        private Label LabelProgressWriteCsvFile;
        private Button ButtonDocumentation;
        private Label LabelCopyright;
        private Button ButtonCancelSweeps;
        private Label LabelTaskCount;
        private Label LabelExecTask;
        private CheckBox CheckBoxRadialAzimuth;
        private NumericUpDown NumericUpDownMarkerNumber;
        private TextBox TextBoxMarkerName;
        private CheckBox CheckBoxAutoIncrementMarkerNumber;
        private TextBox TextBoxClient;
        private GroupBox GroupBoxConfiguration;
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
        private TextBox TextBoxFloorName;
        private GroupBox GroupBoxFloorId;
        private RadioButton RadioButtonFloorIncrement;
        private RadioButton RadioButtonFloorDecrement;
        private NumericUpDown NumericUpDownFloorNumber;
        private GroupBox GroupBoxMarkerId;
        private TabControl TabControlMain;
        private TabPage TabControlMainConnection;
        private TabPage TabControlMainOmniDirectional;
        private TabPage TabControlMainRadial;
        private Label LabelTrueNorthText;
        private Label LabelPortText;
        private GroupBox GroupBoxClientId;
        private Button ButtonFloorId;
        private Button ButtonCaptureImage;
        private TabPage TabControlSiteImage;
        private PictureBox PictureBox;
        private Label LabelCaptured;
        private Button ButtonPersistClear;
        private StatusStrip StripStatusMainForm;
        private GroupBox GroupBoxCsvInformation;
        private GroupBox GroupBoxCurrentSweepChartConfiguration;
        private Panel PanelChart;
        private ToolStripStatusLabel StripStatusLabelPreset;
        private ToolStripStatusLabel StripStatusLabelCsvDirectory;
        private ToolStripStatusLabel StripStatusLabelDivision1;
        private Button BaudRate;
        private Button button1;
        private GroupBox GroupBoxDocumentation;
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
    }
}

