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
            this.LabelStartFrequency = new System.Windows.Forms.Label();
            this.TextBoxStartFrequency = new System.Windows.Forms.TextBox();
            this.LabelStopFrequency = new System.Windows.Forms.Label();
            this.LabelRBW = new System.Windows.Forms.Label();
            this.LabelRBWKhz = new System.Windows.Forms.Label();
            this.TextBoxStopFrequency = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.LabelFrequencyStep = new System.Windows.Forms.Label();
            this.GroupBoxConfiguration = new System.Windows.Forms.GroupBox();
            this.labelPresets = new System.Windows.Forms.Label();
            this.ComboBoxPreset = new System.Windows.Forms.ComboBox();
            this.LabelRightSmaAttenuationText = new System.Windows.Forms.Label();
            this.TextBoxRightSmaAttentuationValue = new System.Windows.Forms.TextBox();
            this.LabelRightAttentaion = new System.Windows.Forms.Label();
            this.LabelLeftSmaAttenuationText = new System.Windows.Forms.Label();
            this.TextBoxLeftSmaAttenuationValue = new System.Windows.Forms.TextBox();
            this.LabelLeftAttenution = new System.Windows.Forms.Label();
            this.TextBoxStepSize = new System.Windows.Forms.TextBox();
            this.TextBoxRBW = new System.Windows.Forms.TextBox();
            this.LabelStopMHz = new System.Windows.Forms.Label();
            this.labelStartMHz = new System.Windows.Forms.Label();
            this.RadioButtonSize = new System.Windows.Forms.RadioButton();
            this.RadioButtonRBW = new System.Windows.Forms.RadioButton();
            this.RadioButtonStop = new System.Windows.Forms.RadioButton();
            this.RadioButtonStart = new System.Windows.Forms.RadioButton();
            this.ButtonSetConfiguration = new System.Windows.Forms.Button();
            this.GroupBoxSerialConnection = new System.Windows.Forms.GroupBox();
            this.buttonDocumentation = new System.Windows.Forms.Button();
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
            this.LabelProgressWriteCsvFile = new System.Windows.Forms.Label();
            this.TaskProgressBar = new System.Windows.Forms.ProgressBar();
            this.TextBoxCsvFileName = new System.Windows.Forms.TextBox();
            this.CheckBoxSaveCsvFiles = new System.Windows.Forms.CheckBox();
            this.SweepPanel = new System.Windows.Forms.Panel();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.ConnectionPanel = new System.Windows.Forms.Panel();
            this.ChartPanel = new System.Windows.Forms.Panel();
            this.CheckBoxChartPeak = new System.Windows.Forms.CheckBox();
            this.CheckBoxChartAverage = new System.Windows.Forms.CheckBox();
            this.CheckBoxChartAutoScale = new System.Windows.Forms.CheckBox();
            this.GroupBoxChart = new System.Windows.Forms.GroupBox();
            this.PanelChart = new System.Windows.Forms.Panel();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LabelCsvRootText = new System.Windows.Forms.Label();
            this.LabelRootDirectory = new System.Windows.Forms.Label();
            this.TextBoxSweepLocation = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.GroupBoxConfiguration.SuspendLayout();
            this.GroupBoxSerialConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSweeps)).BeginInit();
            this.GroupBoxSweepControl.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            this.ConnectionPanel.SuspendLayout();
            this.ChartPanel.SuspendLayout();
            this.GroupBoxChart.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
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
            // LabelStartFrequency
            // 
            this.LabelStartFrequency.AutoSize = true;
            this.LabelStartFrequency.Location = new System.Drawing.Point(37, 27);
            this.LabelStartFrequency.Name = "LabelStartFrequency";
            this.LabelStartFrequency.Size = new System.Drawing.Size(82, 13);
            this.LabelStartFrequency.TabIndex = 2;
            this.LabelStartFrequency.Text = "Start Frequency";
            // 
            // TextBoxStartFrequency
            // 
            this.TextBoxStartFrequency.Location = new System.Drawing.Point(125, 23);
            this.TextBoxStartFrequency.Name = "TextBoxStartFrequency";
            this.TextBoxStartFrequency.Size = new System.Drawing.Size(40, 20);
            this.TextBoxStartFrequency.TabIndex = 3;
            this.TextBoxStartFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LabelStopFrequency
            // 
            this.LabelStopFrequency.AutoSize = true;
            this.LabelStopFrequency.Location = new System.Drawing.Point(37, 51);
            this.LabelStopFrequency.Name = "LabelStopFrequency";
            this.LabelStopFrequency.Size = new System.Drawing.Size(82, 13);
            this.LabelStopFrequency.TabIndex = 4;
            this.LabelStopFrequency.Text = "Stop Frequency";
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
            // LabelRBWKhz
            // 
            this.LabelRBWKhz.AutoSize = true;
            this.LabelRBWKhz.Location = new System.Drawing.Point(167, 75);
            this.LabelRBWKhz.Name = "LabelRBWKhz";
            this.LabelRBWKhz.Size = new System.Drawing.Size(27, 13);
            this.LabelRBWKhz.TabIndex = 6;
            this.LabelRBWKhz.Text = "KHz";
            // 
            // TextBoxStopFrequency
            // 
            this.TextBoxStopFrequency.Location = new System.Drawing.Point(125, 47);
            this.TextBoxStopFrequency.Name = "TextBoxStopFrequency";
            this.TextBoxStopFrequency.Size = new System.Drawing.Size(40, 20);
            this.TextBoxStopFrequency.TabIndex = 7;
            this.TextBoxStopFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(37, 99);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(82, 13);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Frequency Step";
            // 
            // LabelFrequencyStep
            // 
            this.LabelFrequencyStep.AutoSize = true;
            this.LabelFrequencyStep.Location = new System.Drawing.Point(167, 99);
            this.LabelFrequencyStep.Name = "LabelFrequencyStep";
            this.LabelFrequencyStep.Size = new System.Drawing.Size(27, 13);
            this.LabelFrequencyStep.TabIndex = 9;
            this.LabelFrequencyStep.Text = "KHz";
            // 
            // GroupBoxConfiguration
            // 
            this.GroupBoxConfiguration.Controls.Add(this.labelPresets);
            this.GroupBoxConfiguration.Controls.Add(this.ComboBoxPreset);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRightSmaAttenuationText);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxRightSmaAttentuationValue);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRightAttentaion);
            this.GroupBoxConfiguration.Controls.Add(this.LabelLeftSmaAttenuationText);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxLeftSmaAttenuationValue);
            this.GroupBoxConfiguration.Controls.Add(this.LabelLeftAttenution);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxStepSize);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxRBW);
            this.GroupBoxConfiguration.Controls.Add(this.LabelStopMHz);
            this.GroupBoxConfiguration.Controls.Add(this.labelStartMHz);
            this.GroupBoxConfiguration.Controls.Add(this.RadioButtonSize);
            this.GroupBoxConfiguration.Controls.Add(this.RadioButtonRBW);
            this.GroupBoxConfiguration.Controls.Add(this.RadioButtonStop);
            this.GroupBoxConfiguration.Controls.Add(this.RadioButtonStart);
            this.GroupBoxConfiguration.Controls.Add(this.ButtonSetConfiguration);
            this.GroupBoxConfiguration.Controls.Add(this.LabelFrequencyStep);
            this.GroupBoxConfiguration.Controls.Add(this.LabelStartFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.Label2);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxStartFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.TextBoxStopFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.LabelStopFrequency);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRBWKhz);
            this.GroupBoxConfiguration.Controls.Add(this.LabelRBW);
            this.GroupBoxConfiguration.Location = new System.Drawing.Point(3, 3);
            this.GroupBoxConfiguration.Name = "GroupBoxConfiguration";
            this.GroupBoxConfiguration.Size = new System.Drawing.Size(373, 186);
            this.GroupBoxConfiguration.TabIndex = 10;
            this.GroupBoxConfiguration.TabStop = false;
            this.GroupBoxConfiguration.Text = "Current Configuration";
            // 
            // labelPresets
            // 
            this.labelPresets.AutoSize = true;
            this.labelPresets.Location = new System.Drawing.Point(262, 137);
            this.labelPresets.Name = "labelPresets";
            this.labelPresets.Size = new System.Drawing.Size(42, 13);
            this.labelPresets.TabIndex = 26;
            this.labelPresets.Text = "Presets";
            // 
            // ComboBoxPreset
            // 
            this.ComboBoxPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPreset.FormattingEnabled = true;
            this.ComboBoxPreset.Items.AddRange(new object[] {
            "Manual Configuration",
            "Whoop Downlink"});
            this.ComboBoxPreset.Location = new System.Drawing.Point(216, 157);
            this.ComboBoxPreset.Name = "ComboBoxPreset";
            this.ComboBoxPreset.Size = new System.Drawing.Size(135, 21);
            this.ComboBoxPreset.TabIndex = 25;
            this.ToolTip1.SetToolTip(this.ComboBoxPreset, "Choose a Preset to sweep predefined frequency ranges.");
            this.ComboBoxPreset.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPreset_IndexChanged);
            // 
            // LabelRightSmaAttenuationText
            // 
            this.LabelRightSmaAttenuationText.AutoSize = true;
            this.LabelRightSmaAttenuationText.Location = new System.Drawing.Point(166, 161);
            this.LabelRightSmaAttenuationText.Name = "LabelRightSmaAttenuationText";
            this.LabelRightSmaAttenuationText.Size = new System.Drawing.Size(20, 13);
            this.LabelRightSmaAttenuationText.TabIndex = 24;
            this.LabelRightSmaAttenuationText.Text = "dB";
            this.LabelRightSmaAttenuationText.Click += new System.EventHandler(this.LabelRightSMAAttenuationText_Click);
            // 
            // TextBoxRightSmaAttentuationValue
            // 
            this.TextBoxRightSmaAttentuationValue.Enabled = false;
            this.TextBoxRightSmaAttentuationValue.Location = new System.Drawing.Point(144, 157);
            this.TextBoxRightSmaAttentuationValue.Name = "TextBoxRightSmaAttentuationValue";
            this.TextBoxRightSmaAttentuationValue.Size = new System.Drawing.Size(20, 20);
            this.TextBoxRightSmaAttentuationValue.TabIndex = 23;
            this.TextBoxRightSmaAttentuationValue.Text = "0";
            this.TextBoxRightSmaAttentuationValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxRightSmaAttentuationValue.TextChanged += new System.EventHandler(this.TextBoxRightSMAAttentuationValue_TextChanged);
            // 
            // LabelRightAttentaion
            // 
            this.LabelRightAttentaion.AutoSize = true;
            this.LabelRightAttentaion.Location = new System.Drawing.Point(33, 161);
            this.LabelRightAttentaion.Name = "LabelRightAttentaion";
            this.LabelRightAttentaion.Size = new System.Drawing.Size(110, 13);
            this.LabelRightAttentaion.TabIndex = 22;
            this.LabelRightAttentaion.Text = "Right SMA Attenuator";
            this.LabelRightAttentaion.Click += new System.EventHandler(this.LabelRightAttentaion_Click);
            // 
            // LabelLeftSmaAttenuationText
            // 
            this.LabelLeftSmaAttenuationText.AutoSize = true;
            this.LabelLeftSmaAttenuationText.Location = new System.Drawing.Point(166, 135);
            this.LabelLeftSmaAttenuationText.Name = "LabelLeftSmaAttenuationText";
            this.LabelLeftSmaAttenuationText.Size = new System.Drawing.Size(20, 13);
            this.LabelLeftSmaAttenuationText.TabIndex = 21;
            this.LabelLeftSmaAttenuationText.Text = "dB";
            this.LabelLeftSmaAttenuationText.Click += new System.EventHandler(this.LabelLeftSMAAttenuationText_Click);
            // 
            // TextBoxLeftSmaAttenuationValue
            // 
            this.TextBoxLeftSmaAttenuationValue.Enabled = false;
            this.TextBoxLeftSmaAttenuationValue.Location = new System.Drawing.Point(144, 131);
            this.TextBoxLeftSmaAttenuationValue.Name = "TextBoxLeftSmaAttenuationValue";
            this.TextBoxLeftSmaAttenuationValue.Size = new System.Drawing.Size(20, 20);
            this.TextBoxLeftSmaAttenuationValue.TabIndex = 20;
            this.TextBoxLeftSmaAttenuationValue.Text = "0";
            this.TextBoxLeftSmaAttenuationValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxLeftSmaAttenuationValue.TextChanged += new System.EventHandler(this.TextBoxLeftSMAAttenuationValue_TextChanged);
            // 
            // LabelLeftAttenution
            // 
            this.LabelLeftAttenution.AutoSize = true;
            this.LabelLeftAttenution.Location = new System.Drawing.Point(40, 135);
            this.LabelLeftAttenution.Name = "LabelLeftAttenution";
            this.LabelLeftAttenution.Size = new System.Drawing.Size(103, 13);
            this.LabelLeftAttenution.TabIndex = 19;
            this.LabelLeftAttenution.Text = "Left SMA Attenuator";
            // 
            // TextBoxStepSize
            // 
            this.TextBoxStepSize.Location = new System.Drawing.Point(125, 95);
            this.TextBoxStepSize.Name = "TextBoxStepSize";
            this.TextBoxStepSize.Size = new System.Drawing.Size(40, 20);
            this.TextBoxStepSize.TabIndex = 18;
            this.TextBoxStepSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBoxRBW
            // 
            this.TextBoxRBW.Location = new System.Drawing.Point(125, 71);
            this.TextBoxRBW.Name = "TextBoxRBW";
            this.TextBoxRBW.ReadOnly = true;
            this.TextBoxRBW.Size = new System.Drawing.Size(40, 20);
            this.TextBoxRBW.TabIndex = 17;
            this.TextBoxRBW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip1.SetToolTip(this.TextBoxRBW, "RBW is not directly settable and is based on Span.");
            // 
            // LabelStopMHz
            // 
            this.LabelStopMHz.AutoSize = true;
            this.LabelStopMHz.Location = new System.Drawing.Point(167, 51);
            this.LabelStopMHz.Name = "LabelStopMHz";
            this.LabelStopMHz.Size = new System.Drawing.Size(29, 13);
            this.LabelStopMHz.TabIndex = 16;
            this.LabelStopMHz.Text = "MHz";
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
            // RadioButtonSize
            // 
            this.RadioButtonSize.AutoSize = true;
            this.RadioButtonSize.Enabled = false;
            this.RadioButtonSize.Location = new System.Drawing.Point(210, 97);
            this.RadioButtonSize.Name = "RadioButtonSize";
            this.RadioButtonSize.Size = new System.Drawing.Size(52, 17);
            this.RadioButtonSize.TabIndex = 14;
            this.RadioButtonSize.TabStop = true;
            this.RadioButtonSize.Text = "Solve";
            this.RadioButtonSize.UseVisualStyleBackColor = true;
            // 
            // RadioButtonRBW
            // 
            this.RadioButtonRBW.AutoSize = true;
            this.RadioButtonRBW.Enabled = false;
            this.RadioButtonRBW.Location = new System.Drawing.Point(210, 73);
            this.RadioButtonRBW.Name = "RadioButtonRBW";
            this.RadioButtonRBW.Size = new System.Drawing.Size(52, 17);
            this.RadioButtonRBW.TabIndex = 13;
            this.RadioButtonRBW.TabStop = true;
            this.RadioButtonRBW.Text = "Solve";
            this.RadioButtonRBW.UseVisualStyleBackColor = true;
            // 
            // RadioButtonStop
            // 
            this.RadioButtonStop.AutoSize = true;
            this.RadioButtonStop.Enabled = false;
            this.RadioButtonStop.Location = new System.Drawing.Point(210, 49);
            this.RadioButtonStop.Name = "RadioButtonStop";
            this.RadioButtonStop.Size = new System.Drawing.Size(52, 17);
            this.RadioButtonStop.TabIndex = 12;
            this.RadioButtonStop.TabStop = true;
            this.RadioButtonStop.Text = "Solve";
            this.RadioButtonStop.UseVisualStyleBackColor = true;
            // 
            // RadioButtonStart
            // 
            this.RadioButtonStart.AutoSize = true;
            this.RadioButtonStart.Enabled = false;
            this.RadioButtonStart.Location = new System.Drawing.Point(210, 25);
            this.RadioButtonStart.Name = "RadioButtonStart";
            this.RadioButtonStart.Size = new System.Drawing.Size(52, 17);
            this.RadioButtonStart.TabIndex = 11;
            this.RadioButtonStart.TabStop = true;
            this.RadioButtonStart.Text = "Solve";
            this.RadioButtonStart.UseVisualStyleBackColor = true;
            // 
            // ButtonSetConfiguration
            // 
            this.ButtonSetConfiguration.Enabled = false;
            this.ButtonSetConfiguration.Location = new System.Drawing.Point(274, 61);
            this.ButtonSetConfiguration.Name = "ButtonSetConfiguration";
            this.ButtonSetConfiguration.Size = new System.Drawing.Size(75, 23);
            this.ButtonSetConfiguration.TabIndex = 10;
            this.ButtonSetConfiguration.Text = "Set";
            this.ToolTip1.SetToolTip(this.ButtonSetConfiguration, "Solve for Radio Selected Value");
            this.ButtonSetConfiguration.UseVisualStyleBackColor = true;
            this.ButtonSetConfiguration.Click += new System.EventHandler(this.ButtonSetConfiguration_Click);
            // 
            // GroupBoxSerialConnection
            // 
            this.GroupBoxSerialConnection.Controls.Add(this.buttonDocumentation);
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
            this.GroupBoxSerialConnection.Location = new System.Drawing.Point(3, 4);
            this.GroupBoxSerialConnection.Name = "GroupBoxSerialConnection";
            this.GroupBoxSerialConnection.Size = new System.Drawing.Size(373, 110);
            this.GroupBoxSerialConnection.TabIndex = 12;
            this.GroupBoxSerialConnection.TabStop = false;
            this.GroupBoxSerialConnection.Text = "RF Explorer Connection";
            // 
            // buttonDocumentation
            // 
            this.buttonDocumentation.Location = new System.Drawing.Point(194, 84);
            this.buttonDocumentation.Name = "buttonDocumentation";
            this.buttonDocumentation.Size = new System.Drawing.Size(169, 23);
            this.buttonDocumentation.TabIndex = 16;
            this.buttonDocumentation.Text = "RF Explorer Documentation";
            this.buttonDocumentation.UseVisualStyleBackColor = true;
            this.buttonDocumentation.Click += new System.EventHandler(this.ButtonDocumentation_Click);
            // 
            // RadioButtonGenerator
            // 
            this.RadioButtonGenerator.AutoSize = true;
            this.RadioButtonGenerator.Location = new System.Drawing.Point(12, 86);
            this.RadioButtonGenerator.Name = "RadioButtonGenerator";
            this.RadioButtonGenerator.Size = new System.Drawing.Size(104, 17);
            this.RadioButtonGenerator.TabIndex = 15;
            this.RadioButtonGenerator.TabStop = true;
            this.RadioButtonGenerator.Text = "Signal Generator";
            this.RadioButtonGenerator.UseVisualStyleBackColor = true;
            // 
            // RadioButtonAnalyzer
            // 
            this.RadioButtonAnalyzer.AutoSize = true;
            this.RadioButtonAnalyzer.Location = new System.Drawing.Point(12, 62);
            this.RadioButtonAnalyzer.Name = "RadioButtonAnalyzer";
            this.RadioButtonAnalyzer.Size = new System.Drawing.Size(113, 17);
            this.RadioButtonAnalyzer.TabIndex = 14;
            this.RadioButtonAnalyzer.TabStop = true;
            this.RadioButtonAnalyzer.Text = "Spectrum Analyzer";
            this.RadioButtonAnalyzer.UseVisualStyleBackColor = true;
            // 
            // LabelModel
            // 
            this.LabelModel.AutoSize = true;
            this.LabelModel.Location = new System.Drawing.Point(222, 66);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.Size = new System.Drawing.Size(39, 13);
            this.LabelModel.TabIndex = 13;
            this.LabelModel.Text = "Model:";
            // 
            // LabelDevice
            // 
            this.LabelDevice.AutoSize = true;
            this.LabelDevice.Location = new System.Drawing.Point(217, 43);
            this.LabelDevice.Name = "LabelDevice";
            this.LabelDevice.Size = new System.Drawing.Size(44, 13);
            this.LabelDevice.TabIndex = 12;
            this.LabelDevice.Text = "Device:";
            // 
            // LabelFirmwareText
            // 
            this.LabelFirmwareText.AutoSize = true;
            this.LabelFirmwareText.Location = new System.Drawing.Point(264, 20);
            this.LabelFirmwareText.Name = "LabelFirmwareText";
            this.LabelFirmwareText.Size = new System.Drawing.Size(27, 13);
            this.LabelFirmwareText.TabIndex = 5;
            this.LabelFirmwareText.Text = "N/A";
            this.LabelFirmwareText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelFirmware
            // 
            this.LabelFirmware.AutoSize = true;
            this.LabelFirmware.Location = new System.Drawing.Point(209, 20);
            this.LabelFirmware.Name = "LabelFirmware";
            this.LabelFirmware.Size = new System.Drawing.Size(52, 13);
            this.LabelFirmware.TabIndex = 4;
            this.LabelFirmware.Text = "Firmware:";
            // 
            // LabelModelText
            // 
            this.LabelModelText.AutoSize = true;
            this.LabelModelText.Location = new System.Drawing.Point(264, 66);
            this.LabelModelText.Name = "LabelModelText";
            this.LabelModelText.Size = new System.Drawing.Size(27, 13);
            this.LabelModelText.TabIndex = 3;
            this.LabelModelText.Text = "N/A";
            // 
            // LabelDeviceText
            // 
            this.LabelDeviceText.AutoSize = true;
            this.LabelDeviceText.Location = new System.Drawing.Point(264, 43);
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
            this.ButtonStartSweeps.Size = new System.Drawing.Size(155, 23);
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
            this.NumericUpDownSweeps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericUpDownSweeps.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // GroupBoxSweepControl
            // 
            this.GroupBoxSweepControl.Controls.Add(this.LabelProgressWriteCsvFile);
            this.GroupBoxSweepControl.Controls.Add(this.TaskProgressBar);
            this.GroupBoxSweepControl.Controls.Add(this.LabelStartSweeps);
            this.GroupBoxSweepControl.Controls.Add(this.ButtonStartSweeps);
            this.GroupBoxSweepControl.Controls.Add(this.NumericUpDownSweeps);
            this.GroupBoxSweepControl.Controls.Add(this.TextBoxCsvFileName);
            this.GroupBoxSweepControl.Location = new System.Drawing.Point(14, 446);
            this.GroupBoxSweepControl.Name = "GroupBoxSweepControl";
            this.GroupBoxSweepControl.Size = new System.Drawing.Size(376, 158);
            this.GroupBoxSweepControl.TabIndex = 16;
            this.GroupBoxSweepControl.TabStop = false;
            this.GroupBoxSweepControl.Text = "Sweep Control";
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
            this.TaskProgressBar.Size = new System.Drawing.Size(344, 23);
            this.TaskProgressBar.TabIndex = 16;
            // 
            // TextBoxCsvFileName
            // 
            this.TextBoxCsvFileName.Enabled = false;
            this.TextBoxCsvFileName.Location = new System.Drawing.Point(15, 131);
            this.TextBoxCsvFileName.Name = "TextBoxCsvFileName";
            this.TextBoxCsvFileName.ReadOnly = true;
            this.TextBoxCsvFileName.Size = new System.Drawing.Size(344, 20);
            this.TextBoxCsvFileName.TabIndex = 1;
            // 
            // CheckBoxSaveCsvFiles
            // 
            this.CheckBoxSaveCsvFiles.AutoSize = true;
            this.CheckBoxSaveCsvFiles.Location = new System.Drawing.Point(15, 23);
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
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.GroupBoxConfiguration);
            this.ConfigurationPanel.Location = new System.Drawing.Point(14, 133);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(376, 192);
            this.ConfigurationPanel.TabIndex = 18;
            this.ConfigurationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ConfigurationPanel_Paint);
            // 
            // ConnectionPanel
            // 
            this.ConnectionPanel.Controls.Add(this.GroupBoxSerialConnection);
            this.ConnectionPanel.Location = new System.Drawing.Point(14, 8);
            this.ConnectionPanel.Name = "ConnectionPanel";
            this.ConnectionPanel.Size = new System.Drawing.Size(376, 117);
            this.ConnectionPanel.TabIndex = 22;
            this.ConnectionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ConnectionPanel_Paint);
            // 
            // ChartPanel
            // 
            this.ChartPanel.Controls.Add(this.CheckBoxChartPeak);
            this.ChartPanel.Controls.Add(this.CheckBoxChartAverage);
            this.ChartPanel.Controls.Add(this.CheckBoxChartAutoScale);
            this.ChartPanel.Controls.Add(this.GroupBoxChart);
            this.ChartPanel.Location = new System.Drawing.Point(399, 8);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(368, 457);
            this.ChartPanel.TabIndex = 21;
            // 
            // CheckBoxChartPeak
            // 
            this.CheckBoxChartPeak.AutoSize = true;
            this.CheckBoxChartPeak.Checked = true;
            this.CheckBoxChartPeak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxChartPeak.Location = new System.Drawing.Point(271, 420);
            this.CheckBoxChartPeak.Name = "CheckBoxChartPeak";
            this.CheckBoxChartPeak.Size = new System.Drawing.Size(51, 17);
            this.CheckBoxChartPeak.TabIndex = 3;
            this.CheckBoxChartPeak.Text = "Peak";
            this.CheckBoxChartPeak.UseVisualStyleBackColor = true;
            this.CheckBoxChartPeak.CheckedChanged += new System.EventHandler(this.CheckBoxChartPeak_CheckedChanged);
            // 
            // CheckBoxChartAverage
            // 
            this.CheckBoxChartAverage.AutoSize = true;
            this.CheckBoxChartAverage.Checked = true;
            this.CheckBoxChartAverage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxChartAverage.Location = new System.Drawing.Point(168, 420);
            this.CheckBoxChartAverage.Name = "CheckBoxChartAverage";
            this.CheckBoxChartAverage.Size = new System.Drawing.Size(66, 17);
            this.CheckBoxChartAverage.TabIndex = 2;
            this.CheckBoxChartAverage.Text = "Average";
            this.CheckBoxChartAverage.UseVisualStyleBackColor = true;
            this.CheckBoxChartAverage.CheckedChanged += new System.EventHandler(this.CheckBoxChartAverage_CheckedChanged);
            // 
            // CheckBoxChartAutoScale
            // 
            this.CheckBoxChartAutoScale.AutoSize = true;
            this.CheckBoxChartAutoScale.Checked = true;
            this.CheckBoxChartAutoScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxChartAutoScale.Location = new System.Drawing.Point(57, 420);
            this.CheckBoxChartAutoScale.Name = "CheckBoxChartAutoScale";
            this.CheckBoxChartAutoScale.Size = new System.Drawing.Size(78, 17);
            this.CheckBoxChartAutoScale.TabIndex = 1;
            this.CheckBoxChartAutoScale.Text = "Auto Scale";
            this.CheckBoxChartAutoScale.UseVisualStyleBackColor = true;
            this.CheckBoxChartAutoScale.CheckedChanged += new System.EventHandler(this.CheckBoxChartAutoScale_CheckedChanged);
            // 
            // GroupBoxChart
            // 
            this.GroupBoxChart.Controls.Add(this.PanelChart);
            this.GroupBoxChart.Location = new System.Drawing.Point(4, 5);
            this.GroupBoxChart.Name = "GroupBoxChart";
            this.GroupBoxChart.Size = new System.Drawing.Size(361, 448);
            this.GroupBoxChart.TabIndex = 4;
            this.GroupBoxChart.TabStop = false;
            this.GroupBoxChart.Text = "Spectrum";
            // 
            // PanelChart
            // 
            this.PanelChart.Location = new System.Drawing.Point(6, 19);
            this.PanelChart.Name = "PanelChart";
            this.PanelChart.Size = new System.Drawing.Size(349, 377);
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
            this.LabelCsvRootText.Location = new System.Drawing.Point(15, 48);
            this.LabelCsvRootText.Name = "LabelCsvRootText";
            this.LabelCsvRootText.Size = new System.Drawing.Size(128, 13);
            this.LabelCsvRootText.TabIndex = 3;
            this.LabelCsvRootText.Text = "Root Folder for CSV Files:";
            this.ToolTip1.SetToolTip(this.LabelCsvRootText, resources.GetString("LabelCsvRootText.ToolTip"));
            // 
            // LabelRootDirectory
            // 
            this.LabelRootDirectory.AutoSize = true;
            this.LabelRootDirectory.Enabled = false;
            this.LabelRootDirectory.Location = new System.Drawing.Point(142, 48);
            this.LabelRootDirectory.Name = "LabelRootDirectory";
            this.LabelRootDirectory.Size = new System.Drawing.Size(47, 13);
            this.LabelRootDirectory.TabIndex = 4;
            this.LabelRootDirectory.Text = "Desktop";
            this.ToolTip1.SetToolTip(this.LabelRootDirectory, "All captured data is stored in sub-folders located on the user\'s Desktop.\r\nThe co" +
        "llection location MUST be entered (below) for each collection site.");
            // 
            // TextBoxSweepLocation
            // 
            this.TextBoxSweepLocation.Enabled = false;
            this.TextBoxSweepLocation.Location = new System.Drawing.Point(15, 69);
            this.TextBoxSweepLocation.Name = "TextBoxSweepLocation";
            this.TextBoxSweepLocation.Size = new System.Drawing.Size(344, 20);
            this.TextBoxSweepLocation.TabIndex = 2;
            this.TextBoxSweepLocation.Text = "Enter Collection Identifier";
            this.ToolTip1.SetToolTip(this.TextBoxSweepLocation, "Enter a short site collection location identifier for data that is about to be co" +
        "llected.\nThis identifier will be used to create or enter a Desktop sub-folder to" +
        " store collected data in CSV Files.");
            this.TextBoxSweepLocation.TextChanged += new System.EventHandler(this.TextBoxSweepLocation_TextChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CheckBoxSaveCsvFiles);
            this.GroupBox1.Controls.Add(this.LabelRootDirectory);
            this.GroupBox1.Controls.Add(this.LabelCsvRootText);
            this.GroupBox1.Controls.Add(this.TextBoxSweepLocation);
            this.GroupBox1.Controls.Add(this.SweepPanel);
            this.GroupBox1.Location = new System.Drawing.Point(14, 336);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(376, 102);
            this.GroupBox1.TabIndex = 23;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Collected CSV File Storage";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Button2);
            this.GroupBox2.Controls.Add(this.Button1);
            this.GroupBox2.Location = new System.Drawing.Point(405, 471);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(361, 132);
            this.GroupBox2.TabIndex = 24;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Program Configuration";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(89, 80);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(185, 33);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "Save Program State";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(89, 28);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(185, 34);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Recall Last Saved Program State";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCopyright.Location = new System.Drawing.Point(557, 614);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(207, 13);
            this.labelCopyright.TabIndex = 25;
            this.labelCopyright.Text = "Copyright 2017 - Skyhawk Consulting, Inc.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 636);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBoxSweepControl);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.ChartPanel);
            this.Controls.Add(this.ConnectionPanel);
            this.Controls.Add(this.ConfigurationPanel);
            this.Name = "MainForm";
            this.Text = "OnSite";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.GroupBoxConfiguration.ResumeLayout(false);
            this.GroupBoxConfiguration.PerformLayout();
            this.GroupBoxSerialConnection.ResumeLayout(false);
            this.GroupBoxSerialConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSweeps)).EndInit();
            this.GroupBoxSweepControl.ResumeLayout(false);
            this.GroupBoxSweepControl.PerformLayout();
            this.ConfigurationPanel.ResumeLayout(false);
            this.ConnectionPanel.ResumeLayout(false);
            this.ChartPanel.ResumeLayout(false);
            this.ChartPanel.PerformLayout();
            this.GroupBoxChart.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


         

        private Button ButtonFindCOMPorts;
        private Button ButtonSetConfiguration;
        private Button ButtonStartSweeps;
        private GroupBox GroupBoxConfiguration;
        private GroupBox GroupBoxSweepControl;
        private GroupBox GroupBoxSerialConnection;
        private Label LabelRightAttentaion;
        private Label LabelRightSmaAttenuationText;
        private Label LabelStopFrequency;
        private Label Label2;
        private Label LabelDeviceText;
        private Label LabelModelText;
        private Label LabelFirmware;
        private Label LabelFirmwareText;
        private Label LabelLeftAttenution;
        private Label LabelLeftSmaAttenuationText;
        private Label LabelFrequencyStep;
        private Label LabelRBW;
        private Label LabelRBWKhz;
        private Label LabelRFEComPort;
        private Label LabelStartFrequency;
        private Label labelStartMHz;
        private Label LabelStartSweeps;
        private Label LabelStopMHz;
        private NumericUpDown NumericUpDownSweeps;
        private Panel SweepPanel;
        private Panel ConfigurationPanel;
        private Panel ConnectionPanel;
        private ProgressBar TaskProgressBar;
        private RadioButton RadioButtonRBW;
        private RadioButton RadioButtonSize;
        private RadioButton RadioButtonStart;
        private RadioButton RadioButtonStop;
        private TextBox TextBoxLeftSmaAttenuationValue;
        private TextBox TextBoxRightSmaAttentuationValue;
        private TextBox TextBoxRBW;
        private TextBox TextBoxStartFrequency;
        private TextBox TextBoxStepSize;
        private TextBox TextBoxStopFrequency;
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
        private GroupBox GroupBox1;
        private TextBox TextBoxCsvFileName;
        private TextBox TextBoxSweepLocation;
        private Label LabelCsvRootText;
        private Label LabelRootDirectory;
        private RadioButton RadioButtonGenerator;
        private RadioButton RadioButtonAnalyzer;
        private Label LabelProgressWriteCsvFile;
        private Label labelPresets;
        private ComboBox ComboBoxPreset;
        private GroupBox GroupBox2;
        private Button Button2;
        private Button Button1;
        private Button buttonDocumentation;
        private Label labelCopyright;
    }
}

