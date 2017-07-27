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
            this.GroupBoxSerialConnection = new System.Windows.Forms.GroupBox();
            this.ButtonCloseSerialPort = new System.Windows.Forms.Button();
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
            this.GroupBoxSweepControl = new System.Windows.Forms.GroupBox();
            this.LabelActualSweeps = new System.Windows.Forms.Label();
            this.LabelTask = new System.Windows.Forms.Label();
            this.LabelExecTask = new System.Windows.Forms.Label();
            this.ButtonCancelSweeps = new System.Windows.Forms.Button();
            this.LabelProgressWriteCsvFile = new System.Windows.Forms.Label();
            this.TaskProgressBar = new System.Windows.Forms.ProgressBar();
            this.TextBoxCsvFileName = new System.Windows.Forms.TextBox();
            this.CheckBoxSaveCsvFiles = new System.Windows.Forms.CheckBox();
            this.SweepPanel = new System.Windows.Forms.Panel();
            this.ChartPanel = new System.Windows.Forms.Panel();
            this.CheckBoxChartPeak = new System.Windows.Forms.CheckBox();
            this.CheckBoxChartAverage = new System.Windows.Forms.CheckBox();
            this.CheckBoxChartAutoScale = new System.Windows.Forms.CheckBox();
            this.GroupBoxChart = new System.Windows.Forms.GroupBox();
            this.PanelChart = new System.Windows.Forms.Panel();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LabelCsvRootText = new System.Windows.Forms.Label();
            this.TextBoxCollectionLocation = new System.Windows.Forms.TextBox();
            this.LabelRBW = new System.Windows.Forms.Label();
            this.ButtonSetConfiguration = new System.Windows.Forms.Button();
            this.TextBoxRBW = new System.Windows.Forms.TextBox();
            this.ComboBoxPreset = new System.Windows.Forms.ComboBox();
            this.ButtonGetConfiguration = new System.Windows.Forms.Button();
            this.LabelStopFrequency = new System.Windows.Forms.Label();
            this.GroupBoxCsvConfiguration = new System.Windows.Forms.GroupBox();
            this.LabelCsvDirectory = new System.Windows.Forms.Label();
            this.LabelRadialAzimuth = new System.Windows.Forms.Label();
            this.NumericUpDownRadialAzimuth = new System.Windows.Forms.NumericUpDown();
            this.LabelCsvLocation = new System.Windows.Forms.Label();
            this.LabelCsvCollectionSite = new System.Windows.Forms.Label();
            this.LabelAtAutoIncrement = new System.Windows.Forms.Label();
            this.TextBoxCollectionSite = new System.Windows.Forms.TextBox();
            this.CheckBoxAutoIncrement = new System.Windows.Forms.CheckBox();
            this.TextBoxClient = new System.Windows.Forms.TextBox();
            this.NumericUpDownLocation = new System.Windows.Forms.NumericUpDown();
            this.GroupBoxSerialize = new System.Windows.Forms.GroupBox();
            this.ButtonSaveProgramState = new System.Windows.Forms.Button();
            this.ButtonRecallProgramState = new System.Windows.Forms.Button();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.GroupBoxConfiguration = new System.Windows.Forms.GroupBox();
            this.LabelPresets = new System.Windows.Forms.Label();
            this.LabelRightAntennaGainUnit = new System.Windows.Forms.Label();
            this.TextBoxRightAntennaGain = new System.Windows.Forms.TextBox();
            this.LabelRightAntennaGain = new System.Windows.Forms.Label();
            this.LabelLeftAntennaGainUnit = new System.Windows.Forms.Label();
            this.TextBoxLeftAntennaGain = new System.Windows.Forms.TextBox();
            this.LabelLeftAntennaGain = new System.Windows.Forms.Label();
            this.TextBoxStepFrequency = new System.Windows.Forms.TextBox();
            this.LabelStopFrequencyUnit = new System.Windows.Forms.Label();
            this.labelStartFrequencyUnit = new System.Windows.Forms.Label();
            this.LabelFrequencyStepUnit = new System.Windows.Forms.Label();
            this.LabelStartFrequency = new System.Windows.Forms.Label();
            this.LabelFrequencyStep = new System.Windows.Forms.Label();
            this.TextBoxStartFrequency = new System.Windows.Forms.TextBox();
            this.TextBoxStopFrequency = new System.Windows.Forms.TextBox();
            this.LabelRBWUnit = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckBoxHoldStart = new System.Windows.Forms.CheckBox();
            this.CheckBoxHoldStop = new System.Windows.Forms.CheckBox();
            this.CheckBoxHoldStep = new System.Windows.Forms.CheckBox();
            this.GroupBoxSerialConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSweeps)).BeginInit();
            this.GroupBoxSweepControl.SuspendLayout();
            this.ChartPanel.SuspendLayout();
            this.GroupBoxChart.SuspendLayout();
            this.GroupBoxCsvConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRadialAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLocation)).BeginInit();
            this.GroupBoxSerialize.SuspendLayout();
            this.GroupBoxConfiguration.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonFindCOMPorts
            // 
            this.ButtonFindCOMPorts.Location = new System.Drawing.Point(9, 20);
            this.ButtonFindCOMPorts.Name = "ButtonFindCOMPorts";
            this.ButtonFindCOMPorts.Size = new System.Drawing.Size(91, 35);
            this.ButtonFindCOMPorts.TabIndex = 0;
            this.ButtonFindCOMPorts.Text = "Connect RF Explorer";
            this.ButtonFindCOMPorts.UseVisualStyleBackColor = true;
            this.ButtonFindCOMPorts.Click += new System.EventHandler(this.ButtonFindPorts_Click);
            // 
            // LabelRFEComPort
            // 
            this.LabelRFEComPort.Location = new System.Drawing.Point(108, 31);
            this.LabelRFEComPort.Name = "LabelRFEComPort";
            this.LabelRFEComPort.Size = new System.Drawing.Size(82, 13);
            this.LabelRFEComPort.TabIndex = 1;
            this.LabelRFEComPort.Text = "Not Connected";
            // 
            // CheckBoxRadialAzimuth
            // 
            this.CheckBoxRadialAzimuth.AutoSize = true;
            this.CheckBoxRadialAzimuth.Enabled = false;
            this.CheckBoxRadialAzimuth.Location = new System.Drawing.Point(238, 21);
            this.CheckBoxRadialAzimuth.Name = "CheckBoxRadialAzimuth";
            this.CheckBoxRadialAzimuth.Size = new System.Drawing.Size(92, 17);
            this.CheckBoxRadialAzimuth.TabIndex = 28;
            this.CheckBoxRadialAzimuth.Text = "Radial Survey";
            this.ToolTip1.SetToolTip(this.CheckBoxRadialAzimuth, resources.GetString("CheckBoxRadialAzimuth.ToolTip"));
            this.CheckBoxRadialAzimuth.UseVisualStyleBackColor = true;
            this.CheckBoxRadialAzimuth.CheckedChanged += new System.EventHandler(this.CheckBoxRadial_CheckedChanged);
            // 
            // GroupBoxSerialConnection
            // 
            this.GroupBoxSerialConnection.Controls.Add(this.ButtonCloseSerialPort);
            this.GroupBoxSerialConnection.Controls.Add(this.ButtonDocumentation);
            this.GroupBoxSerialConnection.Controls.Add(this.RadioButtonGenerator);
            this.GroupBoxSerialConnection.Controls.Add(this.RadioButtonAnalyzer);
            this.GroupBoxSerialConnection.Controls.Add(this.LabelModel);
            this.GroupBoxSerialConnection.Controls.Add(this.LabelDevice);
            this.GroupBoxSerialConnection.Controls.Add(this.LabelFirmwareText);
            this.GroupBoxSerialConnection.Controls.Add(this.LabelFirmware);
            this.GroupBoxSerialConnection.Controls.Add(this.LabelModelText);
            this.GroupBoxSerialConnection.Controls.Add(this.LabelDeviceText);
            this.GroupBoxSerialConnection.Controls.Add(this.ButtonFindCOMPorts);
            this.GroupBoxSerialConnection.Controls.Add(this.LabelRFEComPort);
            this.GroupBoxSerialConnection.Location = new System.Drawing.Point(14, 26);
            this.GroupBoxSerialConnection.Name = "GroupBoxSerialConnection";
            this.GroupBoxSerialConnection.Size = new System.Drawing.Size(376, 153);
            this.GroupBoxSerialConnection.TabIndex = 12;
            this.GroupBoxSerialConnection.TabStop = false;
            this.GroupBoxSerialConnection.Text = "RF Explorer Connection";
            // 
            // ButtonCloseSerialPort
            // 
            this.ButtonCloseSerialPort.Location = new System.Drawing.Point(293, 25);
            this.ButtonCloseSerialPort.Name = "ButtonCloseSerialPort";
            this.ButtonCloseSerialPort.Size = new System.Drawing.Size(71, 24);
            this.ButtonCloseSerialPort.TabIndex = 17;
            this.ButtonCloseSerialPort.Text = "Disconnect";
            this.ButtonCloseSerialPort.UseVisualStyleBackColor = true;
            this.ButtonCloseSerialPort.Click += new System.EventHandler(this.ButtonCloseSerialPort_Click);
            // 
            // ButtonDocumentation
            // 
            this.ButtonDocumentation.Location = new System.Drawing.Point(9, 122);
            this.ButtonDocumentation.Name = "ButtonDocumentation";
            this.ButtonDocumentation.Size = new System.Drawing.Size(169, 23);
            this.ButtonDocumentation.TabIndex = 16;
            this.ButtonDocumentation.Text = "RF Explorer Documentation";
            this.ButtonDocumentation.UseVisualStyleBackColor = true;
            this.ButtonDocumentation.Click += new System.EventHandler(this.ButtonDocumentation_Click);
            // 
            // RadioButtonGenerator
            // 
            this.RadioButtonGenerator.AutoSize = true;
            this.RadioButtonGenerator.Location = new System.Drawing.Point(12, 94);
            this.RadioButtonGenerator.Name = "RadioButtonGenerator";
            this.RadioButtonGenerator.Size = new System.Drawing.Size(104, 17);
            this.RadioButtonGenerator.TabIndex = 15;
            this.RadioButtonGenerator.TabStop = true;
            this.RadioButtonGenerator.Text = "Signal Generator";
            this.RadioButtonGenerator.UseVisualStyleBackColor = true;
            this.RadioButtonGenerator.CheckedChanged += new System.EventHandler(this.RadioButtonGenerator_CheckedChanged);
            // 
            // RadioButtonAnalyzer
            // 
            this.RadioButtonAnalyzer.AutoSize = true;
            this.RadioButtonAnalyzer.Location = new System.Drawing.Point(12, 66);
            this.RadioButtonAnalyzer.Name = "RadioButtonAnalyzer";
            this.RadioButtonAnalyzer.Size = new System.Drawing.Size(113, 17);
            this.RadioButtonAnalyzer.TabIndex = 14;
            this.RadioButtonAnalyzer.TabStop = true;
            this.RadioButtonAnalyzer.Text = "Spectrum Analyzer";
            this.RadioButtonAnalyzer.UseVisualStyleBackColor = true;
            this.RadioButtonAnalyzer.CheckedChanged += new System.EventHandler(this.RadioButtonAnalyzer_CheckedChanged);
            // 
            // LabelModel
            // 
            this.LabelModel.AutoSize = true;
            this.LabelModel.Location = new System.Drawing.Point(218, 128);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.Size = new System.Drawing.Size(39, 13);
            this.LabelModel.TabIndex = 13;
            this.LabelModel.Text = "Model:";
            // 
            // LabelDevice
            // 
            this.LabelDevice.AutoSize = true;
            this.LabelDevice.Location = new System.Drawing.Point(213, 105);
            this.LabelDevice.Name = "LabelDevice";
            this.LabelDevice.Size = new System.Drawing.Size(44, 13);
            this.LabelDevice.TabIndex = 12;
            this.LabelDevice.Text = "Device:";
            // 
            // LabelFirmwareText
            // 
            this.LabelFirmwareText.AutoSize = true;
            this.LabelFirmwareText.Location = new System.Drawing.Point(260, 82);
            this.LabelFirmwareText.Name = "LabelFirmwareText";
            this.LabelFirmwareText.Size = new System.Drawing.Size(27, 13);
            this.LabelFirmwareText.TabIndex = 5;
            this.LabelFirmwareText.Text = "N/A";
            this.LabelFirmwareText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelFirmware
            // 
            this.LabelFirmware.AutoSize = true;
            this.LabelFirmware.Location = new System.Drawing.Point(205, 82);
            this.LabelFirmware.Name = "LabelFirmware";
            this.LabelFirmware.Size = new System.Drawing.Size(52, 13);
            this.LabelFirmware.TabIndex = 4;
            this.LabelFirmware.Text = "Firmware:";
            // 
            // LabelModelText
            // 
            this.LabelModelText.AutoSize = true;
            this.LabelModelText.Location = new System.Drawing.Point(260, 128);
            this.LabelModelText.Name = "LabelModelText";
            this.LabelModelText.Size = new System.Drawing.Size(27, 13);
            this.LabelModelText.TabIndex = 3;
            this.LabelModelText.Text = "N/A";
            // 
            // LabelDeviceText
            // 
            this.LabelDeviceText.AutoSize = true;
            this.LabelDeviceText.Location = new System.Drawing.Point(260, 105);
            this.LabelDeviceText.Name = "LabelDeviceText";
            this.LabelDeviceText.Size = new System.Drawing.Size(27, 13);
            this.LabelDeviceText.TabIndex = 2;
            this.LabelDeviceText.Text = "N/A";
            // 
            // ButtonStartSweeps
            // 
            this.ButtonStartSweeps.Enabled = false;
            this.ButtonStartSweeps.Location = new System.Drawing.Point(15, 53);
            this.ButtonStartSweeps.Name = "ButtonStartSweeps";
            this.ButtonStartSweeps.Size = new System.Drawing.Size(114, 23);
            this.ButtonStartSweeps.TabIndex = 13;
            this.ButtonStartSweeps.Text = "Capture";
            this.ToolTip1.SetToolTip(this.ButtonStartSweeps, resources.GetString("ButtonStartSweeps.ToolTip"));
            this.ButtonStartSweeps.UseVisualStyleBackColor = true;
            this.ButtonStartSweeps.Click += new System.EventHandler(this.ButtonStartSweeps_Click);
            // 
            // LabelStartSweeps
            // 
            this.LabelStartSweeps.AutoSize = true;
            this.LabelStartSweeps.Location = new System.Drawing.Point(14, 29);
            this.LabelStartSweeps.Name = "LabelStartSweeps";
            this.LabelStartSweeps.Size = new System.Drawing.Size(45, 13);
            this.LabelStartSweeps.TabIndex = 14;
            this.LabelStartSweeps.Text = "Sweeps";
            this.ToolTip1.SetToolTip(this.LabelStartSweeps, "Fill each FFT bin with the selected number of samples.");
            // 
            // NumericUpDownSweeps
            // 
            this.NumericUpDownSweeps.Location = new System.Drawing.Point(65, 25);
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
            this.NumericUpDownSweeps.Size = new System.Drawing.Size(50, 20);
            this.NumericUpDownSweeps.TabIndex = 15;
            this.NumericUpDownSweeps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDownSweeps.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // GroupBoxSweepControl
            // 
            this.GroupBoxSweepControl.Controls.Add(this.LabelActualSweeps);
            this.GroupBoxSweepControl.Controls.Add(this.LabelTask);
            this.GroupBoxSweepControl.Controls.Add(this.LabelExecTask);
            this.GroupBoxSweepControl.Controls.Add(this.ButtonCancelSweeps);
            this.GroupBoxSweepControl.Controls.Add(this.LabelProgressWriteCsvFile);
            this.GroupBoxSweepControl.Controls.Add(this.TaskProgressBar);
            this.GroupBoxSweepControl.Controls.Add(this.LabelStartSweeps);
            this.GroupBoxSweepControl.Controls.Add(this.ButtonStartSweeps);
            this.GroupBoxSweepControl.Controls.Add(this.NumericUpDownSweeps);
            this.GroupBoxSweepControl.Controls.Add(this.TextBoxCsvFileName);
            this.GroupBoxSweepControl.Enabled = false;
            this.GroupBoxSweepControl.Location = new System.Drawing.Point(399, 492);
            this.GroupBoxSweepControl.Name = "GroupBoxSweepControl";
            this.GroupBoxSweepControl.Size = new System.Drawing.Size(274, 158);
            this.GroupBoxSweepControl.TabIndex = 16;
            this.GroupBoxSweepControl.TabStop = false;
            this.GroupBoxSweepControl.Text = "Sweep Control";
            // 
            // LabelActualSweeps
            // 
            this.LabelActualSweeps.AutoSize = true;
            this.LabelActualSweeps.Location = new System.Drawing.Point(239, 114);
            this.LabelActualSweeps.Name = "LabelActualSweeps";
            this.LabelActualSweeps.Size = new System.Drawing.Size(0, 13);
            this.LabelActualSweeps.TabIndex = 21;
            this.LabelActualSweeps.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelTask
            // 
            this.LabelTask.AutoSize = true;
            this.LabelTask.Location = new System.Drawing.Point(223, 30);
            this.LabelTask.Name = "LabelTask";
            this.LabelTask.Size = new System.Drawing.Size(24, 13);
            this.LabelTask.TabIndex = 20;
            this.LabelTask.Text = "Idle";
            // 
            // LabelExecTask
            // 
            this.LabelExecTask.AutoSize = true;
            this.LabelExecTask.Location = new System.Drawing.Point(133, 30);
            this.LabelExecTask.Name = "LabelExecTask";
            this.LabelExecTask.Size = new System.Drawing.Size(84, 13);
            this.LabelExecTask.TabIndex = 19;
            this.LabelExecTask.Text = "Executing Task:";
            // 
            // ButtonCancelSweeps
            // 
            this.ButtonCancelSweeps.Enabled = false;
            this.ButtonCancelSweeps.Location = new System.Drawing.Point(152, 53);
            this.ButtonCancelSweeps.Name = "ButtonCancelSweeps";
            this.ButtonCancelSweeps.Size = new System.Drawing.Size(114, 23);
            this.ButtonCancelSweeps.TabIndex = 18;
            this.ButtonCancelSweeps.Text = "Cancel";
            this.ToolTip1.SetToolTip(this.ButtonCancelSweeps, "Stops the current data collection and stores the any data collected (if enabled w" +
        "ith \'Save  Collected CSV Files\'). ");
            this.ButtonCancelSweeps.UseVisualStyleBackColor = true;
            this.ButtonCancelSweeps.Click += new System.EventHandler(this.ButtonCancelSweeps_Click);
            // 
            // LabelProgressWriteCsvFile
            // 
            this.LabelProgressWriteCsvFile.AutoSize = true;
            this.LabelProgressWriteCsvFile.Enabled = false;
            this.LabelProgressWriteCsvFile.Location = new System.Drawing.Point(15, 114);
            this.LabelProgressWriteCsvFile.Name = "LabelProgressWriteCsvFile";
            this.LabelProgressWriteCsvFile.Size = new System.Drawing.Size(50, 13);
            this.LabelProgressWriteCsvFile.TabIndex = 17;
            this.LabelProgressWriteCsvFile.Text = "CSV File:";
            // 
            // TaskProgressBar
            // 
            this.TaskProgressBar.Location = new System.Drawing.Point(15, 87);
            this.TaskProgressBar.Name = "TaskProgressBar";
            this.TaskProgressBar.Size = new System.Drawing.Size(251, 23);
            this.TaskProgressBar.TabIndex = 16;
            // 
            // TextBoxCsvFileName
            // 
            this.TextBoxCsvFileName.Enabled = false;
            this.TextBoxCsvFileName.Location = new System.Drawing.Point(15, 131);
            this.TextBoxCsvFileName.Name = "TextBoxCsvFileName";
            this.TextBoxCsvFileName.ReadOnly = true;
            this.TextBoxCsvFileName.Size = new System.Drawing.Size(251, 20);
            this.TextBoxCsvFileName.TabIndex = 1;
            // 
            // CheckBoxSaveCsvFiles
            // 
            this.CheckBoxSaveCsvFiles.AutoSize = true;
            this.CheckBoxSaveCsvFiles.Location = new System.Drawing.Point(9, 21);
            this.CheckBoxSaveCsvFiles.Name = "CheckBoxSaveCsvFiles";
            this.CheckBoxSaveCsvFiles.Size = new System.Drawing.Size(184, 17);
            this.CheckBoxSaveCsvFiles.TabIndex = 17;
            this.CheckBoxSaveCsvFiles.Text = "Save Collected Data to CSV Files";
            this.ToolTip1.SetToolTip(this.CheckBoxSaveCsvFiles, "Checking this box will cause CSV files to be saved in a selected sub-folder on th" +
        "e user\'s Desktop.");
            this.CheckBoxSaveCsvFiles.UseVisualStyleBackColor = true;
            this.CheckBoxSaveCsvFiles.CheckedChanged += new System.EventHandler(this.CheckBoxSaveCsvFiles_CheckedChanged);
            // 
            // SweepPanel
            // 
            this.SweepPanel.Location = new System.Drawing.Point(481, 0);
            this.SweepPanel.Name = "SweepPanel";
            this.SweepPanel.Size = new System.Drawing.Size(376, 132);
            this.SweepPanel.TabIndex = 17;
            // 
            // ChartPanel
            // 
            this.ChartPanel.Controls.Add(this.CheckBoxChartPeak);
            this.ChartPanel.Controls.Add(this.CheckBoxChartAverage);
            this.ChartPanel.Controls.Add(this.CheckBoxChartAutoScale);
            this.ChartPanel.Controls.Add(this.GroupBoxChart);
            this.ChartPanel.Enabled = false;
            this.ChartPanel.Location = new System.Drawing.Point(399, 26);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(437, 457);
            this.ChartPanel.TabIndex = 21;
            // 
            // CheckBoxChartPeak
            // 
            this.CheckBoxChartPeak.AutoSize = true;
            this.CheckBoxChartPeak.Checked = true;
            this.CheckBoxChartPeak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxChartPeak.Location = new System.Drawing.Point(300, 420);
            this.CheckBoxChartPeak.Name = "CheckBoxChartPeak";
            this.CheckBoxChartPeak.Size = new System.Drawing.Size(51, 17);
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
            this.CheckBoxChartAverage.Location = new System.Drawing.Point(197, 420);
            this.CheckBoxChartAverage.Name = "CheckBoxChartAverage";
            this.CheckBoxChartAverage.Size = new System.Drawing.Size(66, 17);
            this.CheckBoxChartAverage.TabIndex = 2;
            this.CheckBoxChartAverage.Text = "Average";
            this.ToolTip1.SetToolTip(this.CheckBoxChartAverage, "For each FFT bin, compute and display the average power for that bin.");
            this.CheckBoxChartAverage.UseVisualStyleBackColor = true;
            this.CheckBoxChartAverage.CheckedChanged += new System.EventHandler(this.CheckBoxChartAverage_CheckedChanged);
            // 
            // CheckBoxChartAutoScale
            // 
            this.CheckBoxChartAutoScale.AutoSize = true;
            this.CheckBoxChartAutoScale.Checked = true;
            this.CheckBoxChartAutoScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxChartAutoScale.Location = new System.Drawing.Point(86, 420);
            this.CheckBoxChartAutoScale.Name = "CheckBoxChartAutoScale";
            this.CheckBoxChartAutoScale.Size = new System.Drawing.Size(78, 17);
            this.CheckBoxChartAutoScale.TabIndex = 1;
            this.CheckBoxChartAutoScale.Text = "Auto Scale";
            this.ToolTip1.SetToolTip(this.CheckBoxChartAutoScale, "When checked, scale the plot data to fill the graph area. Unchecked will only plo" +
        "t captured data points between -30 dBm and -110 dBm.");
            this.CheckBoxChartAutoScale.UseVisualStyleBackColor = true;
            this.CheckBoxChartAutoScale.CheckedChanged += new System.EventHandler(this.CheckBoxChartAutoScale_CheckedChanged);
            // 
            // GroupBoxChart
            // 
            this.GroupBoxChart.Controls.Add(this.PanelChart);
            this.GroupBoxChart.Enabled = false;
            this.GroupBoxChart.Location = new System.Drawing.Point(4, 5);
            this.GroupBoxChart.Name = "GroupBoxChart";
            this.GroupBoxChart.Size = new System.Drawing.Size(430, 448);
            this.GroupBoxChart.TabIndex = 4;
            this.GroupBoxChart.TabStop = false;
            this.GroupBoxChart.Text = "Spectrum";
            // 
            // PanelChart
            // 
            this.PanelChart.Location = new System.Drawing.Point(6, 19);
            this.PanelChart.Name = "PanelChart";
            this.PanelChart.Size = new System.Drawing.Size(418, 377);
            this.PanelChart.TabIndex = 0;
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 20000;
            this.ToolTip1.InitialDelay = 1000;
            this.ToolTip1.ReshowDelay = 1000;
            // 
            // LabelCsvRootText
            // 
            this.LabelCsvRootText.AutoSize = true;
            this.LabelCsvRootText.Enabled = false;
            this.LabelCsvRootText.Location = new System.Drawing.Point(9, 47);
            this.LabelCsvRootText.Name = "LabelCsvRootText";
            this.LabelCsvRootText.Size = new System.Drawing.Size(128, 13);
            this.LabelCsvRootText.TabIndex = 3;
            this.LabelCsvRootText.Text = "Root Folder for CSV Files:";
            this.ToolTip1.SetToolTip(this.LabelCsvRootText, resources.GetString("LabelCsvRootText.ToolTip"));
            // 
            // TextBoxCollectionLocation
            // 
            this.TextBoxCollectionLocation.Enabled = false;
            this.TextBoxCollectionLocation.Location = new System.Drawing.Point(9, 142);
            this.TextBoxCollectionLocation.Name = "TextBoxCollectionLocation";
            this.TextBoxCollectionLocation.Size = new System.Drawing.Size(344, 20);
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
            this.LabelRBW.Location = new System.Drawing.Point(9, 75);
            this.LabelRBW.Name = "LabelRBW";
            this.LabelRBW.Size = new System.Drawing.Size(110, 13);
            this.LabelRBW.TabIndex = 5;
            this.LabelRBW.Text = "Resolution Bandwidth";
            this.ToolTip1.SetToolTip(this.LabelRBW, resources.GetString("LabelRBW.ToolTip"));
            // 
            // ButtonSetConfiguration
            // 
            this.ButtonSetConfiguration.Enabled = false;
            this.ButtonSetConfiguration.Location = new System.Drawing.Point(268, 23);
            this.ButtonSetConfiguration.Name = "ButtonSetConfiguration";
            this.ButtonSetConfiguration.Size = new System.Drawing.Size(85, 46);
            this.ButtonSetConfiguration.TabIndex = 10;
            this.ButtonSetConfiguration.Text = "Set Explorer Configuration";
            this.ToolTip1.SetToolTip(this.ButtonSetConfiguration, resources.GetString("ButtonSetConfiguration.ToolTip"));
            this.ButtonSetConfiguration.UseVisualStyleBackColor = true;
            this.ButtonSetConfiguration.Click += new System.EventHandler(this.ButtonSetConfiguration_Click);
            // 
            // TextBoxRBW
            // 
            this.TextBoxRBW.Location = new System.Drawing.Point(125, 71);
            this.TextBoxRBW.Name = "TextBoxRBW";
            this.TextBoxRBW.ReadOnly = true;
            this.TextBoxRBW.Size = new System.Drawing.Size(40, 20);
            this.TextBoxRBW.TabIndex = 17;
            this.TextBoxRBW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip1.SetToolTip(this.TextBoxRBW, "RBW is not directly settable. It is determined by table lookup in the RF Explorer" +
        " and is based on Span.");
            // 
            // ComboBoxPreset
            // 
            this.ComboBoxPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPreset.Enabled = false;
            this.ComboBoxPreset.FormattingEnabled = true;
            this.ComboBoxPreset.Items.AddRange(new object[] {
            "Manual",
            "Whoop Downlink",
            "Full Downlink"});
            this.ComboBoxPreset.Location = new System.Drawing.Point(216, 179);
            this.ComboBoxPreset.Name = "ComboBoxPreset";
            this.ComboBoxPreset.Size = new System.Drawing.Size(135, 21);
            this.ComboBoxPreset.TabIndex = 25;
            this.ToolTip1.SetToolTip(this.ComboBoxPreset, resources.GetString("ComboBoxPreset.ToolTip"));
            this.ComboBoxPreset.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPreset_IndexChanged);
            // 
            // ButtonGetConfiguration
            // 
            this.ButtonGetConfiguration.Enabled = false;
            this.ButtonGetConfiguration.Location = new System.Drawing.Point(278, 84);
            this.ButtonGetConfiguration.Name = "ButtonGetConfiguration";
            this.ButtonGetConfiguration.Size = new System.Drawing.Size(65, 31);
            this.ButtonGetConfiguration.TabIndex = 27;
            this.ButtonGetConfiguration.Text = "Get Config";
            this.ToolTip1.SetToolTip(this.ButtonGetConfiguration, "Request and display the current RF Explorer configuration.");
            this.ButtonGetConfiguration.UseVisualStyleBackColor = true;
            this.ButtonGetConfiguration.Click += new System.EventHandler(this.ButtonGetConfiguration_Click);
            // 
            // LabelStopFrequency
            // 
            this.LabelStopFrequency.AutoSize = true;
            this.LabelStopFrequency.Location = new System.Drawing.Point(37, 51);
            this.LabelStopFrequency.Name = "LabelStopFrequency";
            this.LabelStopFrequency.Size = new System.Drawing.Size(82, 13);
            this.LabelStopFrequency.TabIndex = 4;
            this.LabelStopFrequency.Text = "Stop Frequency";
            this.ToolTip1.SetToolTip(this.LabelStopFrequency, "The frequency at which to stop sampling - plus one bin. The RF Explorer always sa" +
        "mples using 112 bins. Each Bin ");
            // 
            // GroupBoxCsvConfiguration
            // 
            this.GroupBoxCsvConfiguration.Controls.Add(this.LabelCsvDirectory);
            this.GroupBoxCsvConfiguration.Controls.Add(this.LabelRadialAzimuth);
            this.GroupBoxCsvConfiguration.Controls.Add(this.LabelCsvRootText);
            this.GroupBoxCsvConfiguration.Controls.Add(this.NumericUpDownRadialAzimuth);
            this.GroupBoxCsvConfiguration.Controls.Add(this.LabelCsvLocation);
            this.GroupBoxCsvConfiguration.Controls.Add(this.LabelCsvCollectionSite);
            this.GroupBoxCsvConfiguration.Controls.Add(this.LabelAtAutoIncrement);
            this.GroupBoxCsvConfiguration.Controls.Add(this.TextBoxCollectionSite);
            this.GroupBoxCsvConfiguration.Controls.Add(this.CheckBoxAutoIncrement);
            this.GroupBoxCsvConfiguration.Controls.Add(this.CheckBoxRadialAzimuth);
            this.GroupBoxCsvConfiguration.Controls.Add(this.TextBoxClient);
            this.GroupBoxCsvConfiguration.Controls.Add(this.NumericUpDownLocation);
            this.GroupBoxCsvConfiguration.Controls.Add(this.CheckBoxSaveCsvFiles);
            this.GroupBoxCsvConfiguration.Controls.Add(this.TextBoxCollectionLocation);
            this.GroupBoxCsvConfiguration.Controls.Add(this.SweepPanel);
            this.GroupBoxCsvConfiguration.Enabled = false;
            this.GroupBoxCsvConfiguration.Location = new System.Drawing.Point(14, 415);
            this.GroupBoxCsvConfiguration.Name = "GroupBoxCsvConfiguration";
            this.GroupBoxCsvConfiguration.Size = new System.Drawing.Size(376, 234);
            this.GroupBoxCsvConfiguration.TabIndex = 23;
            this.GroupBoxCsvConfiguration.TabStop = false;
            this.GroupBoxCsvConfiguration.Text = "Collected CSV File Storage";
            // 
            // LabelCsvDirectory
            // 
            this.LabelCsvDirectory.AutoSize = true;
            this.LabelCsvDirectory.Enabled = false;
            this.LabelCsvDirectory.Location = new System.Drawing.Point(9, 69);
            this.LabelCsvDirectory.Name = "LabelCsvDirectory";
            this.LabelCsvDirectory.Size = new System.Drawing.Size(49, 13);
            this.LabelCsvDirectory.TabIndex = 36;
            this.LabelCsvDirectory.Text = "Directory";
            // 
            // LabelRadialAzimuth
            // 
            this.LabelRadialAzimuth.AutoSize = true;
            this.LabelRadialAzimuth.Enabled = false;
            this.LabelRadialAzimuth.Location = new System.Drawing.Point(302, 42);
            this.LabelRadialAzimuth.Name = "LabelRadialAzimuth";
            this.LabelRadialAzimuth.Size = new System.Drawing.Size(44, 13);
            this.LabelRadialAzimuth.TabIndex = 35;
            this.LabelRadialAzimuth.Text = "Azimuth";
            // 
            // NumericUpDownRadialAzimuth
            // 
            this.NumericUpDownRadialAzimuth.Enabled = false;
            this.NumericUpDownRadialAzimuth.Location = new System.Drawing.Point(238, 38);
            this.NumericUpDownRadialAzimuth.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.NumericUpDownRadialAzimuth.Name = "NumericUpDownRadialAzimuth";
            this.NumericUpDownRadialAzimuth.Size = new System.Drawing.Size(57, 20);
            this.NumericUpDownRadialAzimuth.TabIndex = 34;
            this.NumericUpDownRadialAzimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabelCsvLocation
            // 
            this.LabelCsvLocation.AutoSize = true;
            this.LabelCsvLocation.Enabled = false;
            this.LabelCsvLocation.Location = new System.Drawing.Point(9, 120);
            this.LabelCsvLocation.Name = "LabelCsvLocation";
            this.LabelCsvLocation.Size = new System.Drawing.Size(48, 13);
            this.LabelCsvLocation.TabIndex = 33;
            this.LabelCsvLocation.Text = "Location";
            // 
            // LabelCsvCollectionSite
            // 
            this.LabelCsvCollectionSite.AutoSize = true;
            this.LabelCsvCollectionSite.Enabled = false;
            this.LabelCsvCollectionSite.Location = new System.Drawing.Point(9, 171);
            this.LabelCsvCollectionSite.Name = "LabelCsvCollectionSite";
            this.LabelCsvCollectionSite.Size = new System.Drawing.Size(74, 13);
            this.LabelCsvCollectionSite.TabIndex = 32;
            this.LabelCsvCollectionSite.Text = "Collection Site";
            // 
            // LabelAtAutoIncrement
            // 
            this.LabelAtAutoIncrement.AutoSize = true;
            this.LabelAtAutoIncrement.Enabled = false;
            this.LabelAtAutoIncrement.Location = new System.Drawing.Point(186, 197);
            this.LabelAtAutoIncrement.Name = "LabelAtAutoIncrement";
            this.LabelAtAutoIncrement.Size = new System.Drawing.Size(17, 13);
            this.LabelAtAutoIncrement.TabIndex = 31;
            this.LabelAtAutoIncrement.Text = "At";
            // 
            // TextBoxCollectionSite
            // 
            this.TextBoxCollectionSite.Enabled = false;
            this.TextBoxCollectionSite.Location = new System.Drawing.Point(9, 193);
            this.TextBoxCollectionSite.Name = "TextBoxCollectionSite";
            this.TextBoxCollectionSite.Size = new System.Drawing.Size(165, 20);
            this.TextBoxCollectionSite.TabIndex = 30;
            this.TextBoxCollectionSite.Text = "ID at Location";
            this.TextBoxCollectionSite.TextChanged += new System.EventHandler(this.TextBoxCollectionSite_TextChanged);
            // 
            // CheckBoxAutoIncrement
            // 
            this.CheckBoxAutoIncrement.AutoSize = true;
            this.CheckBoxAutoIncrement.Enabled = false;
            this.CheckBoxAutoIncrement.Location = new System.Drawing.Point(265, 195);
            this.CheckBoxAutoIncrement.Name = "CheckBoxAutoIncrement";
            this.CheckBoxAutoIncrement.Size = new System.Drawing.Size(101, 17);
            this.CheckBoxAutoIncrement.TabIndex = 29;
            this.CheckBoxAutoIncrement.Text = "Auto Increment ";
            this.CheckBoxAutoIncrement.UseVisualStyleBackColor = true;
            this.CheckBoxAutoIncrement.CheckedChanged += new System.EventHandler(this.CheckBoxAutoIncrement_CheckedChanged);
            // 
            // TextBoxClient
            // 
            this.TextBoxClient.Enabled = false;
            this.TextBoxClient.Location = new System.Drawing.Point(9, 91);
            this.TextBoxClient.Name = "TextBoxClient";
            this.TextBoxClient.Size = new System.Drawing.Size(344, 20);
            this.TextBoxClient.TabIndex = 20;
            this.TextBoxClient.Text = "Client";
            this.TextBoxClient.TextChanged += new System.EventHandler(this.TextBoxClient_TextChanged);
            // 
            // NumericUpDownLocation
            // 
            this.NumericUpDownLocation.Enabled = false;
            this.NumericUpDownLocation.Location = new System.Drawing.Point(206, 193);
            this.NumericUpDownLocation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownLocation.Name = "NumericUpDownLocation";
            this.NumericUpDownLocation.Size = new System.Drawing.Size(46, 20);
            this.NumericUpDownLocation.TabIndex = 18;
            this.NumericUpDownLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDownLocation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownLocation.ValueChanged += new System.EventHandler(this.NumericUpDownLocation_ValueChanged);
            // 
            // GroupBoxSerialize
            // 
            this.GroupBoxSerialize.Controls.Add(this.ButtonSaveProgramState);
            this.GroupBoxSerialize.Controls.Add(this.ButtonRecallProgramState);
            this.GroupBoxSerialize.Enabled = false;
            this.GroupBoxSerialize.Location = new System.Drawing.Point(679, 471);
            this.GroupBoxSerialize.Name = "GroupBoxSerialize";
            this.GroupBoxSerialize.Size = new System.Drawing.Size(157, 161);
            this.GroupBoxSerialize.TabIndex = 24;
            this.GroupBoxSerialize.TabStop = false;
            this.GroupBoxSerialize.Text = "Program Configuration";
            // 
            // ButtonSaveProgramState
            // 
            this.ButtonSaveProgramState.Enabled = false;
            this.ButtonSaveProgramState.Location = new System.Drawing.Point(24, 91);
            this.ButtonSaveProgramState.Name = "ButtonSaveProgramState";
            this.ButtonSaveProgramState.Size = new System.Drawing.Size(109, 40);
            this.ButtonSaveProgramState.TabIndex = 1;
            this.ButtonSaveProgramState.Text = "Save Program State";
            this.ButtonSaveProgramState.UseVisualStyleBackColor = true;
            // 
            // ButtonRecallProgramState
            // 
            this.ButtonRecallProgramState.Enabled = false;
            this.ButtonRecallProgramState.Location = new System.Drawing.Point(24, 37);
            this.ButtonRecallProgramState.Name = "ButtonRecallProgramState";
            this.ButtonRecallProgramState.Size = new System.Drawing.Size(109, 40);
            this.ButtonRecallProgramState.TabIndex = 0;
            this.ButtonRecallProgramState.Text = "Recall Last Saved Program State";
            this.ButtonRecallProgramState.UseVisualStyleBackColor = true;
            // 
            // LabelCopyright
            // 
            this.LabelCopyright.AutoSize = true;
            this.LabelCopyright.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelCopyright.Location = new System.Drawing.Point(631, 658);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(207, 13);
            this.LabelCopyright.TabIndex = 25;
            this.LabelCopyright.Text = "Copyright 2017 - Skyhawk Consulting, Inc.";
            // 
            // GroupBoxConfiguration
            // 
            this.GroupBoxConfiguration.Controls.Add(this.CheckBoxHoldStep);
            this.GroupBoxConfiguration.Controls.Add(this.CheckBoxHoldStop);
            this.GroupBoxConfiguration.Controls.Add(this.CheckBoxHoldStart);
            this.GroupBoxConfiguration.Controls.Add(this.ButtonGetConfiguration);
            this.GroupBoxConfiguration.Controls.Add(this.LabelPresets);
            this.GroupBoxConfiguration.Controls.Add(this.ComboBoxPreset);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRightAntennaGainUnit);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxRightAntennaGain);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRightAntennaGain);
            this.GroupBoxConfiguration.Controls.Add(this.LabelLeftAntennaGainUnit);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxLeftAntennaGain);
            this.GroupBoxConfiguration.Controls.Add(this.LabelLeftAntennaGain);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxStepFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxRBW);
            this.GroupBoxConfiguration.Controls.Add(this.LabelStopFrequencyUnit);
            this.GroupBoxConfiguration.Controls.Add(this.labelStartFrequencyUnit);
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
            this.GroupBoxConfiguration.Location = new System.Drawing.Point(14, 189);
            this.GroupBoxConfiguration.Name = "GroupBoxConfiguration";
            this.GroupBoxConfiguration.Size = new System.Drawing.Size(376, 216);
            this.GroupBoxConfiguration.TabIndex = 10;
            this.GroupBoxConfiguration.TabStop = false;
            this.GroupBoxConfiguration.Text = "Current Configuration";
            // 
            // LabelPresets
            // 
            this.LabelPresets.AutoSize = true;
            this.LabelPresets.Location = new System.Drawing.Point(216, 157);
            this.LabelPresets.Name = "LabelPresets";
            this.LabelPresets.Size = new System.Drawing.Size(42, 13);
            this.LabelPresets.TabIndex = 26;
            this.LabelPresets.Text = "Presets";
            // 
            // LabelRightAntennaGainUnit
            // 
            this.LabelRightAntennaGainUnit.AutoSize = true;
            this.LabelRightAntennaGainUnit.Enabled = false;
            this.LabelRightAntennaGainUnit.Location = new System.Drawing.Point(167, 184);
            this.LabelRightAntennaGainUnit.Name = "LabelRightAntennaGainUnit";
            this.LabelRightAntennaGainUnit.Size = new System.Drawing.Size(20, 13);
            this.LabelRightAntennaGainUnit.TabIndex = 24;
            this.LabelRightAntennaGainUnit.Text = "dB";
            // 
            // TextBoxRightAntennaGain
            // 
            this.TextBoxRightAntennaGain.Enabled = false;
            this.TextBoxRightAntennaGain.Location = new System.Drawing.Point(126, 180);
            this.TextBoxRightAntennaGain.Name = "TextBoxRightAntennaGain";
            this.TextBoxRightAntennaGain.Size = new System.Drawing.Size(40, 20);
            this.TextBoxRightAntennaGain.TabIndex = 23;
            this.TextBoxRightAntennaGain.Text = "0";
            this.TextBoxRightAntennaGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxRightAntennaGain.TextChanged += new System.EventHandler(this.TextBoxRightAntennaGain_TextChanged);
            // 
            // LabelRightAntennaGain
            // 
            this.LabelRightAntennaGain.AutoSize = true;
            this.LabelRightAntennaGain.Enabled = false;
            this.LabelRightAntennaGain.Location = new System.Drawing.Point(19, 184);
            this.LabelRightAntennaGain.Name = "LabelRightAntennaGain";
            this.LabelRightAntennaGain.Size = new System.Drawing.Size(100, 13);
            this.LabelRightAntennaGain.TabIndex = 22;
            this.LabelRightAntennaGain.Text = "Right Antenna Gain";
            // 
            // LabelLeftAntennaGainUnit
            // 
            this.LabelLeftAntennaGainUnit.AutoSize = true;
            this.LabelLeftAntennaGainUnit.Enabled = false;
            this.LabelLeftAntennaGainUnit.Location = new System.Drawing.Point(167, 158);
            this.LabelLeftAntennaGainUnit.Name = "LabelLeftAntennaGainUnit";
            this.LabelLeftAntennaGainUnit.Size = new System.Drawing.Size(20, 13);
            this.LabelLeftAntennaGainUnit.TabIndex = 21;
            this.LabelLeftAntennaGainUnit.Text = "dB";
            // 
            // TextBoxLeftAntennaGain
            // 
            this.TextBoxLeftAntennaGain.Enabled = false;
            this.TextBoxLeftAntennaGain.Location = new System.Drawing.Point(126, 154);
            this.TextBoxLeftAntennaGain.Name = "TextBoxLeftAntennaGain";
            this.TextBoxLeftAntennaGain.Size = new System.Drawing.Size(40, 20);
            this.TextBoxLeftAntennaGain.TabIndex = 20;
            this.TextBoxLeftAntennaGain.Text = "0";
            this.TextBoxLeftAntennaGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxLeftAntennaGain.TextChanged += new System.EventHandler(this.TextBoxLeftAntennaGain_TextChanged);
            // 
            // LabelLeftAntennaGain
            // 
            this.LabelLeftAntennaGain.AutoSize = true;
            this.LabelLeftAntennaGain.Enabled = false;
            this.LabelLeftAntennaGain.Location = new System.Drawing.Point(26, 158);
            this.LabelLeftAntennaGain.Name = "LabelLeftAntennaGain";
            this.LabelLeftAntennaGain.Size = new System.Drawing.Size(93, 13);
            this.LabelLeftAntennaGain.TabIndex = 19;
            this.LabelLeftAntennaGain.Text = "Left Antenna Gain";
            // 
            // TextBoxStepFrequency
            // 
            this.TextBoxStepFrequency.Enabled = false;
            this.TextBoxStepFrequency.Location = new System.Drawing.Point(125, 95);
            this.TextBoxStepFrequency.Name = "TextBoxStepFrequency";
            this.TextBoxStepFrequency.Size = new System.Drawing.Size(40, 20);
            this.TextBoxStepFrequency.TabIndex = 18;
            this.TextBoxStepFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LabelStopFrequencyUnit
            // 
            this.LabelStopFrequencyUnit.AutoSize = true;
            this.LabelStopFrequencyUnit.Location = new System.Drawing.Point(167, 51);
            this.LabelStopFrequencyUnit.Name = "LabelStopFrequencyUnit";
            this.LabelStopFrequencyUnit.Size = new System.Drawing.Size(29, 13);
            this.LabelStopFrequencyUnit.TabIndex = 16;
            this.LabelStopFrequencyUnit.Text = "MHz";
            // 
            // labelStartFrequencyUnit
            // 
            this.labelStartFrequencyUnit.AutoSize = true;
            this.labelStartFrequencyUnit.Location = new System.Drawing.Point(167, 27);
            this.labelStartFrequencyUnit.Name = "labelStartFrequencyUnit";
            this.labelStartFrequencyUnit.Size = new System.Drawing.Size(29, 13);
            this.labelStartFrequencyUnit.TabIndex = 15;
            this.labelStartFrequencyUnit.Text = "MHz";
            // 
            // LabelFrequencyStepUnit
            // 
            this.LabelFrequencyStepUnit.AutoSize = true;
            this.LabelFrequencyStepUnit.Location = new System.Drawing.Point(167, 99);
            this.LabelFrequencyStepUnit.Name = "LabelFrequencyStepUnit";
            this.LabelFrequencyStepUnit.Size = new System.Drawing.Size(27, 13);
            this.LabelFrequencyStepUnit.TabIndex = 9;
            this.LabelFrequencyStepUnit.Text = "KHz";
            // 
            // LabelStartFrequency
            // 
            this.LabelStartFrequency.AutoSize = true;
            this.LabelStartFrequency.Location = new System.Drawing.Point(37, 27);
            this.LabelStartFrequency.Name = "LabelStartFrequency";
            this.LabelStartFrequency.Size = new System.Drawing.Size(82, 13);
            this.LabelStartFrequency.TabIndex = 2;
            this.LabelStartFrequency.Text = "Start Frequency";
            // 
            // LabelFrequencyStep
            // 
            this.LabelFrequencyStep.AutoSize = true;
            this.LabelFrequencyStep.Location = new System.Drawing.Point(37, 99);
            this.LabelFrequencyStep.Name = "LabelFrequencyStep";
            this.LabelFrequencyStep.Size = new System.Drawing.Size(82, 13);
            this.LabelFrequencyStep.TabIndex = 8;
            this.LabelFrequencyStep.Text = "Frequency Step";
            // 
            // TextBoxStartFrequency
            // 
            this.TextBoxStartFrequency.Enabled = false;
            this.TextBoxStartFrequency.Location = new System.Drawing.Point(125, 23);
            this.TextBoxStartFrequency.Name = "TextBoxStartFrequency";
            this.TextBoxStartFrequency.Size = new System.Drawing.Size(40, 20);
            this.TextBoxStartFrequency.TabIndex = 3;
            this.TextBoxStartFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxStartFrequency.TextChanged += new System.EventHandler(this.TextBoxStartFrequency_TextChanged);
            // 
            // TextBoxStopFrequency
            // 
            this.TextBoxStopFrequency.Enabled = false;
            this.TextBoxStopFrequency.Location = new System.Drawing.Point(125, 47);
            this.TextBoxStopFrequency.Name = "TextBoxStopFrequency";
            this.TextBoxStopFrequency.Size = new System.Drawing.Size(40, 20);
            this.TextBoxStopFrequency.TabIndex = 7;
            this.TextBoxStopFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxStopFrequency.TextChanged += new System.EventHandler(this.TextBoxStopFrequency_TextChanged);
            // 
            // LabelRBWUnit
            // 
            this.LabelRBWUnit.AutoSize = true;
            this.LabelRBWUnit.Location = new System.Drawing.Point(167, 75);
            this.LabelRBWUnit.Name = "LabelRBWUnit";
            this.LabelRBWUnit.Size = new System.Drawing.Size(27, 13);
            this.LabelRBWUnit.TabIndex = 6;
            this.LabelRBWUnit.Text = "KHz";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem1.Text = "Exit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItemFileExit_Click);
            // 
            // CheckBoxHoldStart
            // 
            this.CheckBoxHoldStart.AutoSize = true;
            this.CheckBoxHoldStart.Location = new System.Drawing.Point(208, 25);
            this.CheckBoxHoldStart.Name = "CheckBoxHoldStart";
            this.CheckBoxHoldStart.Size = new System.Drawing.Size(48, 17);
            this.CheckBoxHoldStart.TabIndex = 28;
            this.CheckBoxHoldStart.Text = "Hold";
            this.CheckBoxHoldStart.UseVisualStyleBackColor = true;
            // 
            // CheckBoxHoldStop
            // 
            this.CheckBoxHoldStop.AutoSize = true;
            this.CheckBoxHoldStop.Location = new System.Drawing.Point(208, 49);
            this.CheckBoxHoldStop.Name = "CheckBoxHoldStop";
            this.CheckBoxHoldStop.Size = new System.Drawing.Size(48, 17);
            this.CheckBoxHoldStop.TabIndex = 29;
            this.CheckBoxHoldStop.Text = "Hold";
            this.CheckBoxHoldStop.UseVisualStyleBackColor = true;
            // 
            // CheckBoxHoldStep
            // 
            this.CheckBoxHoldStep.AutoSize = true;
            this.CheckBoxHoldStep.Location = new System.Drawing.Point(208, 97);
            this.CheckBoxHoldStep.Name = "CheckBoxHoldStep";
            this.CheckBoxHoldStep.Size = new System.Drawing.Size(48, 17);
            this.CheckBoxHoldStep.TabIndex = 30;
            this.CheckBoxHoldStep.Text = "Hold";
            this.CheckBoxHoldStep.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 680);
            this.Controls.Add(this.GroupBoxSerialConnection);
            this.Controls.Add(this.GroupBoxConfiguration);
            this.Controls.Add(this.LabelCopyright);
            this.Controls.Add(this.GroupBoxSerialize);
            this.Controls.Add(this.GroupBoxSweepControl);
            this.Controls.Add(this.GroupBoxCsvConfiguration);
            this.Controls.Add(this.ChartPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "OnSite";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.GroupBoxSerialConnection.ResumeLayout(false);
            this.GroupBoxSerialConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSweeps)).EndInit();
            this.GroupBoxSweepControl.ResumeLayout(false);
            this.GroupBoxSweepControl.PerformLayout();
            this.ChartPanel.ResumeLayout(false);
            this.ChartPanel.PerformLayout();
            this.GroupBoxChart.ResumeLayout(false);
            this.GroupBoxCsvConfiguration.ResumeLayout(false);
            this.GroupBoxCsvConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRadialAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLocation)).EndInit();
            this.GroupBoxSerialize.ResumeLayout(false);
            this.GroupBoxConfiguration.ResumeLayout(false);
            this.GroupBoxConfiguration.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


         

        private Button ButtonFindCOMPorts;
        private Button ButtonStartSweeps;
        private GroupBox GroupBoxSweepControl;
        private GroupBox GroupBoxSerialConnection;
        private Label LabelDeviceText;
        private Label LabelModelText;
        private Label LabelFirmware;
        private Label LabelFirmwareText;
        private Label LabelRFEComPort;
        private Label LabelStartSweeps;
        private NumericUpDown NumericUpDownSweeps;
        private Panel SweepPanel;
        private ProgressBar TaskProgressBar;
        private CheckBox CheckBoxSaveCsvFiles;
        private Panel ChartPanel;
        private CheckBox CheckBoxChartPeak;
        private CheckBox CheckBoxChartAverage;
        private CheckBox CheckBoxChartAutoScale;
        private GroupBox GroupBoxChart;
        private Label LabelDevice;
        private Label LabelModel;
        private Panel PanelChart;
        private ToolTip ToolTip1;
        private GroupBox GroupBoxCsvConfiguration;
        private TextBox TextBoxCsvFileName;
        private TextBox TextBoxCollectionLocation;
        private Label LabelCsvRootText;
        private RadioButton RadioButtonGenerator;
        private RadioButton RadioButtonAnalyzer;
        private Label LabelProgressWriteCsvFile;
        private GroupBox GroupBoxSerialize;
        private Button ButtonSaveProgramState;
        private Button ButtonRecallProgramState;
        private Button ButtonDocumentation;
        private Label LabelCopyright;
        private Button ButtonCancelSweeps;
        private Label LabelTask;
        private Label LabelExecTask;
        private CheckBox CheckBoxRadialAzimuth;
        private NumericUpDown NumericUpDownLocation;
        private TextBox TextBoxCollectionSite;
        private CheckBox CheckBoxAutoIncrement;
        private TextBox TextBoxClient;
        private Label LabelAtAutoIncrement;
        private GroupBox GroupBoxConfiguration;
        private Button ButtonGetConfiguration;
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
        private Label labelStartFrequencyUnit;
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
        private Label LabelCsvLocation;
        private Label LabelCsvCollectionSite;
        private Label LabelCsvDirectory;
        private Label LabelActualSweeps;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItemFile;
        private ToolStripMenuItem toolStripMenuItem1;
        private Button ButtonCloseSerialPort;
        private CheckBox CheckBoxHoldStep;
        private CheckBox CheckBoxHoldStop;
        private CheckBox CheckBoxHoldStart;
    }
}

