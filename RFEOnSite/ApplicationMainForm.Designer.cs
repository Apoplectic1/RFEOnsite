using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFEOnsite
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
            this.buttonFindCOMPorts = new System.Windows.Forms.Button();
            this.labelRFEComPort = new System.Windows.Forms.Label();
            this.labelStartFrequency = new System.Windows.Forms.Label();
            this.textBoxStartFrequency = new System.Windows.Forms.TextBox();
            this.labelStopFrequency = new System.Windows.Forms.Label();
            this.labelRBW = new System.Windows.Forms.Label();
            this.labelRBWKhz = new System.Windows.Forms.Label();
            this.textBoxStopFrequency = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFrequencyStep = new System.Windows.Forms.Label();
            this.groupBoxConfiguration = new System.Windows.Forms.GroupBox();
            this.labelRightSMAAttenuationText = new System.Windows.Forms.Label();
            this.textBoxRightSMAAttentuationValue = new System.Windows.Forms.TextBox();
            this.labelRightAttentaion = new System.Windows.Forms.Label();
            this.labelLeftSMAAttenuationText = new System.Windows.Forms.Label();
            this.textBoxLeftSMAAttenuationValue = new System.Windows.Forms.TextBox();
            this.labelLeftAttenution = new System.Windows.Forms.Label();
            this.textBoxStepSize = new System.Windows.Forms.TextBox();
            this.textBoxRBW = new System.Windows.Forms.TextBox();
            this.labelStopMHz = new System.Windows.Forms.Label();
            this.labelStartMHz = new System.Windows.Forms.Label();
            this.radioButtonSize = new System.Windows.Forms.RadioButton();
            this.radioButtonRBW = new System.Windows.Forms.RadioButton();
            this.radioButtonStop = new System.Windows.Forms.RadioButton();
            this.radioButtonStart = new System.Windows.Forms.RadioButton();
            this.buttonSetConfiguration = new System.Windows.Forms.Button();
            this.groupBoxSerialConnection = new System.Windows.Forms.GroupBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFirmwareText = new System.Windows.Forms.Label();
            this.labelFirmware = new System.Windows.Forms.Label();
            this.labelFoundModel = new System.Windows.Forms.Label();
            this.labelFoundDevice = new System.Windows.Forms.Label();
            this.buttonStartSweeps = new System.Windows.Forms.Button();
            this.labelStartSweeps = new System.Windows.Forms.Label();
            this.numericUpDownSweeps = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxSaveCsvFiles = new System.Windows.Forms.CheckBox();
            this.TaskProgressBar = new System.Windows.Forms.ProgressBar();
            this.SweepPanel = new System.Windows.Forms.Panel();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.ConnectionPanel = new System.Windows.Forms.Panel();
            this.ChartPanel = new System.Windows.Forms.Panel();
            this.checkBoxChartPeakHold = new System.Windows.Forms.CheckBox();
            this.checkBoxChartAverage = new System.Windows.Forms.CheckBox();
            this.checkBoxChartRealTime = new System.Windows.Forms.CheckBox();
            this.groupBoxChart = new System.Windows.Forms.GroupBox();
            this.panelChart = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRootDirectory = new System.Windows.Forms.Label();
            this.labelCsvRootText = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxCsvFileName = new System.Windows.Forms.TextBox();
            this.buttonSelectCsvFolder = new System.Windows.Forms.Button();
            this.radioButtonAnalyzer = new System.Windows.Forms.RadioButton();
            this.radioButtonGenerator = new System.Windows.Forms.RadioButton();
            this.groupBoxConfiguration.SuspendLayout();
            this.groupBoxSerialConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweeps)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SweepPanel.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            this.ConnectionPanel.SuspendLayout();
            this.ChartPanel.SuspendLayout();
            this.groupBoxChart.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFindCOMPorts
            // 
            this.buttonFindCOMPorts.Location = new System.Drawing.Point(9, 20);
            this.buttonFindCOMPorts.Name = "buttonFindCOMPorts";
            this.buttonFindCOMPorts.Size = new System.Drawing.Size(91, 35);
            this.buttonFindCOMPorts.TabIndex = 0;
            this.buttonFindCOMPorts.Text = "Connect RF Explorer";
            this.buttonFindCOMPorts.UseVisualStyleBackColor = true;
            this.buttonFindCOMPorts.Click += new System.EventHandler(this.ButtonFindPorts_Click);
            // 
            // labelRFEComPort
            // 
            this.labelRFEComPort.Location = new System.Drawing.Point(108, 31);
            this.labelRFEComPort.Name = "labelRFEComPort";
            this.labelRFEComPort.Size = new System.Drawing.Size(82, 13);
            this.labelRFEComPort.TabIndex = 1;
            this.labelRFEComPort.Text = "Not Connected";
            // 
            // labelStartFrequency
            // 
            this.labelStartFrequency.AutoSize = true;
            this.labelStartFrequency.Location = new System.Drawing.Point(37, 27);
            this.labelStartFrequency.Name = "labelStartFrequency";
            this.labelStartFrequency.Size = new System.Drawing.Size(82, 13);
            this.labelStartFrequency.TabIndex = 2;
            this.labelStartFrequency.Text = "Start Frequency";
            // 
            // textBoxStartFrequency
            // 
            this.textBoxStartFrequency.Location = new System.Drawing.Point(125, 23);
            this.textBoxStartFrequency.Name = "textBoxStartFrequency";
            this.textBoxStartFrequency.Size = new System.Drawing.Size(40, 20);
            this.textBoxStartFrequency.TabIndex = 3;
            this.textBoxStartFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelStopFrequency
            // 
            this.labelStopFrequency.AutoSize = true;
            this.labelStopFrequency.Location = new System.Drawing.Point(37, 51);
            this.labelStopFrequency.Name = "labelStopFrequency";
            this.labelStopFrequency.Size = new System.Drawing.Size(82, 13);
            this.labelStopFrequency.TabIndex = 4;
            this.labelStopFrequency.Text = "Stop Frequency";
            // 
            // labelRBW
            // 
            this.labelRBW.AutoSize = true;
            this.labelRBW.Location = new System.Drawing.Point(9, 75);
            this.labelRBW.Name = "labelRBW";
            this.labelRBW.Size = new System.Drawing.Size(110, 13);
            this.labelRBW.TabIndex = 5;
            this.labelRBW.Text = "Resolution Bandwidth";
            // 
            // labelRBWKhz
            // 
            this.labelRBWKhz.AutoSize = true;
            this.labelRBWKhz.Location = new System.Drawing.Point(167, 75);
            this.labelRBWKhz.Name = "labelRBWKhz";
            this.labelRBWKhz.Size = new System.Drawing.Size(27, 13);
            this.labelRBWKhz.TabIndex = 6;
            this.labelRBWKhz.Text = "KHz";
            // 
            // textBoxStopFrequency
            // 
            this.textBoxStopFrequency.Location = new System.Drawing.Point(125, 47);
            this.textBoxStopFrequency.Name = "textBoxStopFrequency";
            this.textBoxStopFrequency.Size = new System.Drawing.Size(40, 20);
            this.textBoxStopFrequency.TabIndex = 7;
            this.textBoxStopFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Frequency Step";
            // 
            // labelFrequencyStep
            // 
            this.labelFrequencyStep.AutoSize = true;
            this.labelFrequencyStep.Location = new System.Drawing.Point(167, 99);
            this.labelFrequencyStep.Name = "labelFrequencyStep";
            this.labelFrequencyStep.Size = new System.Drawing.Size(27, 13);
            this.labelFrequencyStep.TabIndex = 9;
            this.labelFrequencyStep.Text = "KHz";
            // 
            // groupBoxConfiguration
            // 
            this.groupBoxConfiguration.Controls.Add(this.labelRightSMAAttenuationText);
            this.groupBoxConfiguration.Controls.Add(this.textBoxRightSMAAttentuationValue);
            this.groupBoxConfiguration.Controls.Add(this.labelRightAttentaion);
            this.groupBoxConfiguration.Controls.Add(this.labelLeftSMAAttenuationText);
            this.groupBoxConfiguration.Controls.Add(this.textBoxLeftSMAAttenuationValue);
            this.groupBoxConfiguration.Controls.Add(this.labelLeftAttenution);
            this.groupBoxConfiguration.Controls.Add(this.textBoxStepSize);
            this.groupBoxConfiguration.Controls.Add(this.textBoxRBW);
            this.groupBoxConfiguration.Controls.Add(this.labelStopMHz);
            this.groupBoxConfiguration.Controls.Add(this.labelStartMHz);
            this.groupBoxConfiguration.Controls.Add(this.radioButtonSize);
            this.groupBoxConfiguration.Controls.Add(this.radioButtonRBW);
            this.groupBoxConfiguration.Controls.Add(this.radioButtonStop);
            this.groupBoxConfiguration.Controls.Add(this.radioButtonStart);
            this.groupBoxConfiguration.Controls.Add(this.buttonSetConfiguration);
            this.groupBoxConfiguration.Controls.Add(this.labelFrequencyStep);
            this.groupBoxConfiguration.Controls.Add(this.labelStartFrequency);
            this.groupBoxConfiguration.Controls.Add(this.label2);
            this.groupBoxConfiguration.Controls.Add(this.textBoxStartFrequency);
            this.groupBoxConfiguration.Controls.Add(this.textBoxStopFrequency);
            this.groupBoxConfiguration.Controls.Add(this.labelStopFrequency);
            this.groupBoxConfiguration.Controls.Add(this.labelRBWKhz);
            this.groupBoxConfiguration.Controls.Add(this.labelRBW);
            this.groupBoxConfiguration.Location = new System.Drawing.Point(3, 3);
            this.groupBoxConfiguration.Name = "groupBoxConfiguration";
            this.groupBoxConfiguration.Size = new System.Drawing.Size(366, 186);
            this.groupBoxConfiguration.TabIndex = 10;
            this.groupBoxConfiguration.TabStop = false;
            this.groupBoxConfiguration.Text = "Current Configuration";
            // 
            // labelRightSMAAttenuationText
            // 
            this.labelRightSMAAttenuationText.AutoSize = true;
            this.labelRightSMAAttenuationText.Location = new System.Drawing.Point(218, 161);
            this.labelRightSMAAttenuationText.Name = "labelRightSMAAttenuationText";
            this.labelRightSMAAttenuationText.Size = new System.Drawing.Size(20, 13);
            this.labelRightSMAAttenuationText.TabIndex = 24;
            this.labelRightSMAAttenuationText.Text = "dB";
            // 
            // textBoxRightSMAAttentuationValue
            // 
            this.textBoxRightSMAAttentuationValue.Location = new System.Drawing.Point(196, 157);
            this.textBoxRightSMAAttentuationValue.Name = "textBoxRightSMAAttentuationValue";
            this.textBoxRightSMAAttentuationValue.Size = new System.Drawing.Size(20, 20);
            this.textBoxRightSMAAttentuationValue.TabIndex = 23;
            this.textBoxRightSMAAttentuationValue.Text = "0";
            this.textBoxRightSMAAttentuationValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelRightAttentaion
            // 
            this.labelRightAttentaion.AutoSize = true;
            this.labelRightAttentaion.Location = new System.Drawing.Point(85, 161);
            this.labelRightAttentaion.Name = "labelRightAttentaion";
            this.labelRightAttentaion.Size = new System.Drawing.Size(110, 13);
            this.labelRightAttentaion.TabIndex = 22;
            this.labelRightAttentaion.Text = "Right SMA Attenuator";
            // 
            // labelLeftSMAAttenuationText
            // 
            this.labelLeftSMAAttenuationText.AutoSize = true;
            this.labelLeftSMAAttenuationText.Location = new System.Drawing.Point(218, 135);
            this.labelLeftSMAAttenuationText.Name = "labelLeftSMAAttenuationText";
            this.labelLeftSMAAttenuationText.Size = new System.Drawing.Size(20, 13);
            this.labelLeftSMAAttenuationText.TabIndex = 21;
            this.labelLeftSMAAttenuationText.Text = "dB";
            // 
            // textBoxLeftSMAAttenuationValue
            // 
            this.textBoxLeftSMAAttenuationValue.Location = new System.Drawing.Point(196, 131);
            this.textBoxLeftSMAAttenuationValue.Name = "textBoxLeftSMAAttenuationValue";
            this.textBoxLeftSMAAttenuationValue.Size = new System.Drawing.Size(20, 20);
            this.textBoxLeftSMAAttenuationValue.TabIndex = 20;
            this.textBoxLeftSMAAttenuationValue.Text = "0";
            this.textBoxLeftSMAAttenuationValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLeftAttenution
            // 
            this.labelLeftAttenution.AutoSize = true;
            this.labelLeftAttenution.Location = new System.Drawing.Point(92, 135);
            this.labelLeftAttenution.Name = "labelLeftAttenution";
            this.labelLeftAttenution.Size = new System.Drawing.Size(103, 13);
            this.labelLeftAttenution.TabIndex = 19;
            this.labelLeftAttenution.Text = "Left SMA Attenuator";
            // 
            // textBoxStepSize
            // 
            this.textBoxStepSize.Location = new System.Drawing.Point(125, 95);
            this.textBoxStepSize.Name = "textBoxStepSize";
            this.textBoxStepSize.Size = new System.Drawing.Size(40, 20);
            this.textBoxStepSize.TabIndex = 18;
            this.textBoxStepSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRBW
            // 
            this.textBoxRBW.Location = new System.Drawing.Point(125, 71);
            this.textBoxRBW.Name = "textBoxRBW";
            this.textBoxRBW.ReadOnly = true;
            this.textBoxRBW.Size = new System.Drawing.Size(40, 20);
            this.textBoxRBW.TabIndex = 17;
            this.textBoxRBW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelStopMHz
            // 
            this.labelStopMHz.AutoSize = true;
            this.labelStopMHz.Location = new System.Drawing.Point(167, 51);
            this.labelStopMHz.Name = "labelStopMHz";
            this.labelStopMHz.Size = new System.Drawing.Size(29, 13);
            this.labelStopMHz.TabIndex = 16;
            this.labelStopMHz.Text = "MHz";
            // 
            // labelStartMHz
            // 
            this.labelStartMHz.AutoSize = true;
            this.labelStartMHz.Location = new System.Drawing.Point(167, 27);
            this.labelStartMHz.Name = "labelStartMHz";
            this.labelStartMHz.Size = new System.Drawing.Size(29, 13);
            this.labelStartMHz.TabIndex = 15;
            this.labelStartMHz.Text = "MHz";
            // 
            // radioButtonSize
            // 
            this.radioButtonSize.AutoSize = true;
            this.radioButtonSize.Location = new System.Drawing.Point(210, 97);
            this.radioButtonSize.Name = "radioButtonSize";
            this.radioButtonSize.Size = new System.Drawing.Size(52, 17);
            this.radioButtonSize.TabIndex = 14;
            this.radioButtonSize.TabStop = true;
            this.radioButtonSize.Text = "Solve";
            this.radioButtonSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonRBW
            // 
            this.radioButtonRBW.AutoSize = true;
            this.radioButtonRBW.Location = new System.Drawing.Point(210, 73);
            this.radioButtonRBW.Name = "radioButtonRBW";
            this.radioButtonRBW.Size = new System.Drawing.Size(52, 17);
            this.radioButtonRBW.TabIndex = 13;
            this.radioButtonRBW.TabStop = true;
            this.radioButtonRBW.Text = "Solve";
            this.radioButtonRBW.UseVisualStyleBackColor = true;
            // 
            // radioButtonStop
            // 
            this.radioButtonStop.AutoSize = true;
            this.radioButtonStop.Location = new System.Drawing.Point(210, 49);
            this.radioButtonStop.Name = "radioButtonStop";
            this.radioButtonStop.Size = new System.Drawing.Size(52, 17);
            this.radioButtonStop.TabIndex = 12;
            this.radioButtonStop.TabStop = true;
            this.radioButtonStop.Text = "Solve";
            this.radioButtonStop.UseVisualStyleBackColor = true;
            // 
            // radioButtonStart
            // 
            this.radioButtonStart.AutoSize = true;
            this.radioButtonStart.Location = new System.Drawing.Point(210, 25);
            this.radioButtonStart.Name = "radioButtonStart";
            this.radioButtonStart.Size = new System.Drawing.Size(52, 17);
            this.radioButtonStart.TabIndex = 11;
            this.radioButtonStart.TabStop = true;
            this.radioButtonStart.Text = "Solve";
            this.radioButtonStart.UseVisualStyleBackColor = true;
            // 
            // buttonSetConfiguration
            // 
            this.buttonSetConfiguration.Location = new System.Drawing.Point(274, 61);
            this.buttonSetConfiguration.Name = "buttonSetConfiguration";
            this.buttonSetConfiguration.Size = new System.Drawing.Size(75, 23);
            this.buttonSetConfiguration.TabIndex = 10;
            this.buttonSetConfiguration.Text = "Set";
            this.toolTip1.SetToolTip(this.buttonSetConfiguration, "Solve for Radio Selected Value");
            this.buttonSetConfiguration.UseVisualStyleBackColor = true;
            this.buttonSetConfiguration.Click += new System.EventHandler(this.buttonSetConfiguration_Click);
            // 
            // groupBoxSerialConnection
            // 
            this.groupBoxSerialConnection.Controls.Add(this.radioButtonGenerator);
            this.groupBoxSerialConnection.Controls.Add(this.radioButtonAnalyzer);
            this.groupBoxSerialConnection.Controls.Add(this.labelModel);
            this.groupBoxSerialConnection.Controls.Add(this.label3);
            this.groupBoxSerialConnection.Controls.Add(this.labelFirmwareText);
            this.groupBoxSerialConnection.Controls.Add(this.labelFirmware);
            this.groupBoxSerialConnection.Controls.Add(this.labelFoundModel);
            this.groupBoxSerialConnection.Controls.Add(this.labelFoundDevice);
            this.groupBoxSerialConnection.Controls.Add(this.buttonFindCOMPorts);
            this.groupBoxSerialConnection.Controls.Add(this.labelRFEComPort);
            this.groupBoxSerialConnection.Location = new System.Drawing.Point(3, 4);
            this.groupBoxSerialConnection.Name = "groupBoxSerialConnection";
            this.groupBoxSerialConnection.Size = new System.Drawing.Size(366, 110);
            this.groupBoxSerialConnection.TabIndex = 12;
            this.groupBoxSerialConnection.TabStop = false;
            this.groupBoxSerialConnection.Text = "RF Explorer Connection";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(213, 67);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(39, 13);
            this.labelModel.TabIndex = 13;
            this.labelModel.Text = "Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Device:";
            // 
            // labelFirmwareText
            // 
            this.labelFirmwareText.AutoSize = true;
            this.labelFirmwareText.Location = new System.Drawing.Point(265, 20);
            this.labelFirmwareText.Name = "labelFirmwareText";
            this.labelFirmwareText.Size = new System.Drawing.Size(0, 13);
            this.labelFirmwareText.TabIndex = 5;
            this.labelFirmwareText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFirmware
            // 
            this.labelFirmware.AutoSize = true;
            this.labelFirmware.Location = new System.Drawing.Point(200, 20);
            this.labelFirmware.Name = "labelFirmware";
            this.labelFirmware.Size = new System.Drawing.Size(52, 13);
            this.labelFirmware.TabIndex = 4;
            this.labelFirmware.Text = "Firmware:";
            // 
            // labelFoundModel
            // 
            this.labelFoundModel.AutoSize = true;
            this.labelFoundModel.Location = new System.Drawing.Point(265, 68);
            this.labelFoundModel.Name = "labelFoundModel";
            this.labelFoundModel.Size = new System.Drawing.Size(0, 13);
            this.labelFoundModel.TabIndex = 3;
            // 
            // labelFoundDevice
            // 
            this.labelFoundDevice.AutoSize = true;
            this.labelFoundDevice.Location = new System.Drawing.Point(265, 42);
            this.labelFoundDevice.Name = "labelFoundDevice";
            this.labelFoundDevice.Size = new System.Drawing.Size(0, 13);
            this.labelFoundDevice.TabIndex = 2;
            // 
            // buttonStartSweeps
            // 
            this.buttonStartSweeps.Location = new System.Drawing.Point(15, 53);
            this.buttonStartSweeps.Name = "buttonStartSweeps";
            this.buttonStartSweeps.Size = new System.Drawing.Size(155, 23);
            this.buttonStartSweeps.TabIndex = 13;
            this.buttonStartSweeps.Text = "Capture";
            this.toolTip1.SetToolTip(this.buttonStartSweeps, "Begin Capture and logging of RF Explorer dBm Data");
            this.buttonStartSweeps.UseVisualStyleBackColor = true;
            this.buttonStartSweeps.Click += new System.EventHandler(this.buttonStartWeeps_Click);
            // 
            // labelStartSweeps
            // 
            this.labelStartSweeps.AutoSize = true;
            this.labelStartSweeps.Location = new System.Drawing.Point(14, 29);
            this.labelStartSweeps.Name = "labelStartSweeps";
            this.labelStartSweeps.Size = new System.Drawing.Size(45, 13);
            this.labelStartSweeps.TabIndex = 14;
            this.labelStartSweeps.Text = "Sweeps";
            // 
            // numericUpDownSweeps
            // 
            this.numericUpDownSweeps.Location = new System.Drawing.Point(65, 25);
            this.numericUpDownSweeps.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSweeps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSweeps.Name = "numericUpDownSweeps";
            this.numericUpDownSweeps.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownSweeps.TabIndex = 15;
            this.numericUpDownSweeps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSweeps.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxSaveCsvFiles);
            this.groupBox2.Controls.Add(this.TaskProgressBar);
            this.groupBox2.Controls.Add(this.labelStartSweeps);
            this.groupBox2.Controls.Add(this.buttonStartSweeps);
            this.groupBox2.Controls.Add(this.numericUpDownSweeps);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 125);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sweep Control";
            // 
            // checkBoxSaveCsvFiles
            // 
            this.checkBoxSaveCsvFiles.AutoSize = true;
            this.checkBoxSaveCsvFiles.Location = new System.Drawing.Point(203, 10);
            this.checkBoxSaveCsvFiles.Name = "checkBoxSaveCsvFiles";
            this.checkBoxSaveCsvFiles.Size = new System.Drawing.Size(106, 17);
            this.checkBoxSaveCsvFiles.TabIndex = 17;
            this.checkBoxSaveCsvFiles.Text = "Save to CSV File";
            this.checkBoxSaveCsvFiles.UseVisualStyleBackColor = true;
            this.checkBoxSaveCsvFiles.CheckedChanged += new System.EventHandler(this.checkBoxSaveCsvFiles_CheckedChanged);
            // 
            // TaskProgressBar
            // 
            this.TaskProgressBar.Location = new System.Drawing.Point(15, 87);
            this.TaskProgressBar.Name = "TaskProgressBar";
            this.TaskProgressBar.Size = new System.Drawing.Size(343, 23);
            this.TaskProgressBar.TabIndex = 16;
            // 
            // SweepPanel
            // 
            this.SweepPanel.Controls.Add(this.groupBox2);
            this.SweepPanel.Location = new System.Drawing.Point(14, 333);
            this.SweepPanel.Name = "SweepPanel";
            this.SweepPanel.Size = new System.Drawing.Size(376, 132);
            this.SweepPanel.TabIndex = 17;
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.groupBoxConfiguration);
            this.ConfigurationPanel.Location = new System.Drawing.Point(14, 133);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(376, 192);
            this.ConfigurationPanel.TabIndex = 18;
            // 
            // ConnectionPanel
            // 
            this.ConnectionPanel.Controls.Add(this.groupBoxSerialConnection);
            this.ConnectionPanel.Location = new System.Drawing.Point(14, 8);
            this.ConnectionPanel.Name = "ConnectionPanel";
            this.ConnectionPanel.Size = new System.Drawing.Size(376, 117);
            this.ConnectionPanel.TabIndex = 22;
            // 
            // ChartPanel
            // 
            this.ChartPanel.Controls.Add(this.checkBoxChartPeakHold);
            this.ChartPanel.Controls.Add(this.checkBoxChartAverage);
            this.ChartPanel.Controls.Add(this.checkBoxChartRealTime);
            this.ChartPanel.Controls.Add(this.groupBoxChart);
            this.ChartPanel.Location = new System.Drawing.Point(399, 8);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(368, 457);
            this.ChartPanel.TabIndex = 21;
            // 
            // checkBoxChartPeakHold
            // 
            this.checkBoxChartPeakHold.AutoSize = true;
            this.checkBoxChartPeakHold.Checked = true;
            this.checkBoxChartPeakHold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChartPeakHold.Location = new System.Drawing.Point(271, 420);
            this.checkBoxChartPeakHold.Name = "checkBoxChartPeakHold";
            this.checkBoxChartPeakHold.Size = new System.Drawing.Size(76, 17);
            this.checkBoxChartPeakHold.TabIndex = 3;
            this.checkBoxChartPeakHold.Text = "Peak Hold";
            this.checkBoxChartPeakHold.UseVisualStyleBackColor = true;
            // 
            // checkBoxChartAverage
            // 
            this.checkBoxChartAverage.AutoSize = true;
            this.checkBoxChartAverage.Location = new System.Drawing.Point(168, 420);
            this.checkBoxChartAverage.Name = "checkBoxChartAverage";
            this.checkBoxChartAverage.Size = new System.Drawing.Size(66, 17);
            this.checkBoxChartAverage.TabIndex = 2;
            this.checkBoxChartAverage.Text = "Average";
            this.checkBoxChartAverage.UseVisualStyleBackColor = true;
            // 
            // checkBoxChartRealTime
            // 
            this.checkBoxChartRealTime.AutoSize = true;
            this.checkBoxChartRealTime.Checked = true;
            this.checkBoxChartRealTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChartRealTime.Location = new System.Drawing.Point(57, 420);
            this.checkBoxChartRealTime.Name = "checkBoxChartRealTime";
            this.checkBoxChartRealTime.Size = new System.Drawing.Size(74, 17);
            this.checkBoxChartRealTime.TabIndex = 1;
            this.checkBoxChartRealTime.Text = "Real Time";
            this.checkBoxChartRealTime.UseVisualStyleBackColor = true;
            // 
            // groupBoxChart
            // 
            this.groupBoxChart.Controls.Add(this.panelChart);
            this.groupBoxChart.Location = new System.Drawing.Point(4, 5);
            this.groupBoxChart.Name = "groupBoxChart";
            this.groupBoxChart.Size = new System.Drawing.Size(361, 448);
            this.groupBoxChart.TabIndex = 4;
            this.groupBoxChart.TabStop = false;
            this.groupBoxChart.Text = "Spectrum";
            // 
            // panelChart
            // 
            this.panelChart.Location = new System.Drawing.Point(6, 19);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(349, 377);
            this.panelChart.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 1000;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelRootDirectory);
            this.groupBox1.Controls.Add(this.labelCsvRootText);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBoxCsvFileName);
            this.groupBox1.Controls.Add(this.buttonSelectCsvFolder);
            this.groupBox1.Location = new System.Drawing.Point(14, 476);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 119);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output CSV File Structure";
            // 
            // labelRootDirectory
            // 
            this.labelRootDirectory.AutoSize = true;
            this.labelRootDirectory.Location = new System.Drawing.Point(143, 63);
            this.labelRootDirectory.Name = "labelRootDirectory";
            this.labelRootDirectory.Size = new System.Drawing.Size(47, 13);
            this.labelRootDirectory.TabIndex = 4;
            this.labelRootDirectory.Text = "Desktop";
            // 
            // labelCsvRootText
            // 
            this.labelCsvRootText.AutoSize = true;
            this.labelCsvRootText.Location = new System.Drawing.Point(18, 63);
            this.labelCsvRootText.Name = "labelCsvRootText";
            this.labelCsvRootText.Size = new System.Drawing.Size(128, 13);
            this.labelCsvRootText.TabIndex = 3;
            this.labelCsvRootText.Text = "Root Folder for CSV Files:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(206, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBoxCsvFileName
            // 
            this.textBoxCsvFileName.Location = new System.Drawing.Point(18, 82);
            this.textBoxCsvFileName.Name = "textBoxCsvFileName";
            this.textBoxCsvFileName.Size = new System.Drawing.Size(362, 20);
            this.textBoxCsvFileName.TabIndex = 1;
            // 
            // buttonSelectCsvFolder
            // 
            this.buttonSelectCsvFolder.Location = new System.Drawing.Point(18, 30);
            this.buttonSelectCsvFolder.Name = "buttonSelectCsvFolder";
            this.buttonSelectCsvFolder.Size = new System.Drawing.Size(106, 23);
            this.buttonSelectCsvFolder.TabIndex = 0;
            this.buttonSelectCsvFolder.Text = "Select Folder";
            this.buttonSelectCsvFolder.UseVisualStyleBackColor = true;
            this.buttonSelectCsvFolder.Click += new System.EventHandler(this.buttonSelectCsvFolder_Click);
            // 
            // radioButtonAnalyzer
            // 
            this.radioButtonAnalyzer.AutoSize = true;
            this.radioButtonAnalyzer.Location = new System.Drawing.Point(12, 62);
            this.radioButtonAnalyzer.Name = "radioButtonAnalyzer";
            this.radioButtonAnalyzer.Size = new System.Drawing.Size(113, 17);
            this.radioButtonAnalyzer.TabIndex = 14;
            this.radioButtonAnalyzer.TabStop = true;
            this.radioButtonAnalyzer.Text = "Spectrum Analyzer";
            this.radioButtonAnalyzer.UseVisualStyleBackColor = true;
            // 
            // radioButtonGenerator
            // 
            this.radioButtonGenerator.AutoSize = true;
            this.radioButtonGenerator.Location = new System.Drawing.Point(12, 86);
            this.radioButtonGenerator.Name = "radioButtonGenerator";
            this.radioButtonGenerator.Size = new System.Drawing.Size(104, 17);
            this.radioButtonGenerator.TabIndex = 15;
            this.radioButtonGenerator.TabStop = true;
            this.radioButtonGenerator.Text = "Signal Generator";
            this.radioButtonGenerator.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 597);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChartPanel);
            this.Controls.Add(this.ConnectionPanel);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.SweepPanel);
            this.Name = "MainForm";
            this.Text = "OnSite";
            this.groupBoxConfiguration.ResumeLayout(false);
            this.groupBoxConfiguration.PerformLayout();
            this.groupBoxSerialConnection.ResumeLayout(false);
            this.groupBoxSerialConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweeps)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SweepPanel.ResumeLayout(false);
            this.ConfigurationPanel.ResumeLayout(false);
            this.ConnectionPanel.ResumeLayout(false);
            this.ChartPanel.ResumeLayout(false);
            this.ChartPanel.PerformLayout();
            this.groupBoxChart.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


         

        private Button buttonFindCOMPorts;
        private Button buttonSetConfiguration;
        private Button buttonStartSweeps;
        private GroupBox groupBoxConfiguration;
        private GroupBox groupBox2;
        private GroupBox groupBoxSerialConnection;
        private Label labelRightAttentaion;
        private Label labelRightSMAAttenuationText;
        private Label labelStopFrequency;
        private Label label2;
        private Label labelFoundDevice;
        private Label labelFoundModel;
        private Label labelFirmware;
        private Label labelFirmwareText;
        private Label labelLeftAttenution;
        private Label labelLeftSMAAttenuationText;
        private Label labelFrequencyStep;
        private Label labelRBW;
        private Label labelRBWKhz;
        private Label labelRFEComPort;
        private Label labelStartFrequency;
        private Label labelStartMHz;
        private Label labelStartSweeps;
        private Label labelStopMHz;
        private NumericUpDown numericUpDownSweeps;
        private Panel SweepPanel;
        private Panel ConfigurationPanel;
        private Panel ConnectionPanel;
        private ProgressBar TaskProgressBar;
        private RadioButton radioButtonRBW;
        private RadioButton radioButtonSize;
        private RadioButton radioButtonStart;
        private RadioButton radioButtonStop;
        private TextBox textBoxLeftSMAAttenuationValue;
        private TextBox textBoxRightSMAAttentuationValue;
        private TextBox textBoxRBW;
        private TextBox textBoxStartFrequency;
        private TextBox textBoxStepSize;
        private TextBox textBoxStopFrequency;
        private CheckBox checkBoxSaveCsvFiles;
        private Panel ChartPanel;
        private CheckBox checkBoxChartPeakHold;
        private CheckBox checkBoxChartAverage;
        private CheckBox checkBoxChartRealTime;
        private GroupBox groupBoxChart;
        private Label label3;
        private Label labelModel;
        private Panel panelChart;
        private ToolTip toolTip1;
        private GroupBox groupBox1;
        private TextBox textBoxCsvFileName;
        private Button buttonSelectCsvFolder;
        private TextBox textBox2;
        private Label labelCsvRootText;
        private Label labelRootDirectory;
        private RadioButton radioButtonGenerator;
        private RadioButton radioButtonAnalyzer;
    }
}

