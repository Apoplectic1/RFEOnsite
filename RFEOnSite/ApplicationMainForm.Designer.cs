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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonFindCOMPorts = new System.Windows.Forms.Button();
            this.labelRFEComPort = new System.Windows.Forms.Label();
            this.labelStartFrequency = new System.Windows.Forms.Label();
            this.textBoxStartFrequency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRBW = new System.Windows.Forms.Label();
            this.labelRBWKhz = new System.Windows.Forms.Label();
            this.textBoxStopFrequency = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFrequencyStep = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxStepSize = new System.Windows.Forms.TextBox();
            this.textBoxRBW = new System.Windows.Forms.TextBox();
            this.labelStopMHz = new System.Windows.Forms.Label();
            this.labelStartMHz = new System.Windows.Forms.Label();
            this.radioButtonSize = new System.Windows.Forms.RadioButton();
            this.radioButtonRBW = new System.Windows.Forms.RadioButton();
            this.radioButtonStop = new System.Windows.Forms.RadioButton();
            this.radioButtonStart = new System.Windows.Forms.RadioButton();
            this.buttonSetConfiguration = new System.Windows.Forms.Button();
            this.comboBoxProgramMode = new System.Windows.Forms.ComboBox();
            this.groupBoxSerialConnection = new System.Windows.Forms.GroupBox();
            this.labelFirmware = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelFoundModel = new System.Windows.Forms.Label();
            this.labelFoundDevice = new System.Windows.Forms.Label();
            this.buttonStartSweeps = new System.Windows.Forms.Button();
            this.labelStartSweeps = new System.Windows.Forms.Label();
            this.numericUpDownSweeps = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SweepPanel = new System.Windows.Forms.Panel();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.ConnectionPanel = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartPanel = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxSerialConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweeps)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SweepPanel.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            this.ConnectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.ChartPanel.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stop Frequency";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxStepSize);
            this.groupBox1.Controls.Add(this.textBoxRBW);
            this.groupBox1.Controls.Add(this.labelStopMHz);
            this.groupBox1.Controls.Add(this.labelStartMHz);
            this.groupBox1.Controls.Add(this.radioButtonSize);
            this.groupBox1.Controls.Add(this.radioButtonRBW);
            this.groupBox1.Controls.Add(this.radioButtonStop);
            this.groupBox1.Controls.Add(this.radioButtonStart);
            this.groupBox1.Controls.Add(this.buttonSetConfiguration);
            this.groupBox1.Controls.Add(this.labelFrequencyStep);
            this.groupBox1.Controls.Add(this.labelStartFrequency);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxStartFrequency);
            this.groupBox1.Controls.Add(this.textBoxStopFrequency);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelRBWKhz);
            this.groupBox1.Controls.Add(this.labelRBW);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 186);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Configuration";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(218, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "dB";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(196, 157);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(20, 20);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Right SMA Attenuator";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "dB";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(196, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Left SMA Attenuator";
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
            this.buttonSetConfiguration.Location = new System.Drawing.Point(278, 58);
            this.buttonSetConfiguration.Name = "buttonSetConfiguration";
            this.buttonSetConfiguration.Size = new System.Drawing.Size(75, 23);
            this.buttonSetConfiguration.TabIndex = 10;
            this.buttonSetConfiguration.Text = "Set";
            this.buttonSetConfiguration.UseVisualStyleBackColor = true;
            this.buttonSetConfiguration.Click += new System.EventHandler(this.buttonSetConfiguration_Click);
            // 
            // comboBoxProgramMode
            // 
            this.comboBoxProgramMode.FormattingEnabled = true;
            this.comboBoxProgramMode.Items.AddRange(new object[] {
            "Direct Control",
            "Survey Mode"});
            this.comboBoxProgramMode.Location = new System.Drawing.Point(65, 68);
            this.comboBoxProgramMode.Name = "comboBoxProgramMode";
            this.comboBoxProgramMode.Size = new System.Drawing.Size(100, 21);
            this.comboBoxProgramMode.TabIndex = 11;
            this.comboBoxProgramMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxProgramMode_SelectedIndexChanged);
            // 
            // groupBoxSerialConnection
            // 
            this.groupBoxSerialConnection.Controls.Add(this.labelModel);
            this.groupBoxSerialConnection.Controls.Add(this.label3);
            this.groupBoxSerialConnection.Controls.Add(this.labelFirmware);
            this.groupBoxSerialConnection.Controls.Add(this.label6);
            this.groupBoxSerialConnection.Controls.Add(this.labelFoundModel);
            this.groupBoxSerialConnection.Controls.Add(this.comboBoxProgramMode);
            this.groupBoxSerialConnection.Controls.Add(this.labelFoundDevice);
            this.groupBoxSerialConnection.Controls.Add(this.buttonFindCOMPorts);
            this.groupBoxSerialConnection.Controls.Add(this.labelRFEComPort);
            this.groupBoxSerialConnection.Location = new System.Drawing.Point(3, 4);
            this.groupBoxSerialConnection.Name = "groupBoxSerialConnection";
            this.groupBoxSerialConnection.Size = new System.Drawing.Size(366, 110);
            this.groupBoxSerialConnection.TabIndex = 12;
            this.groupBoxSerialConnection.TabStop = false;
            this.groupBoxSerialConnection.Text = "RF Explorer Connection";
            this.groupBoxSerialConnection.Enter += new System.EventHandler(this.groupBoxSerialConnection_Enter);
            // 
            // labelFirmware
            // 
            this.labelFirmware.AutoSize = true;
            this.labelFirmware.Location = new System.Drawing.Point(284, 20);
            this.labelFirmware.Name = "labelFirmware";
            this.labelFirmware.Size = new System.Drawing.Size(0, 13);
            this.labelFirmware.TabIndex = 5;
            this.labelFirmware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Firmware:";
            // 
            // labelFoundModel
            // 
            this.labelFoundModel.AutoSize = true;
            this.labelFoundModel.Location = new System.Drawing.Point(284, 68);
            this.labelFoundModel.Name = "labelFoundModel";
            this.labelFoundModel.Size = new System.Drawing.Size(0, 13);
            this.labelFoundModel.TabIndex = 3;
            // 
            // labelFoundDevice
            // 
            this.labelFoundDevice.AutoSize = true;
            this.labelFoundDevice.Location = new System.Drawing.Point(284, 42);
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
            200,
            0,
            0,
            0});
            this.numericUpDownSweeps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSweeps.Name = "numericUpDownSweeps";
            this.numericUpDownSweeps.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownSweeps.TabIndex = 15;
            this.numericUpDownSweeps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSweeps.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.progressBar1);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(190, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Sweep Chart";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 87);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(343, 23);
            this.progressBar1.TabIndex = 16;
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
            this.ConfigurationPanel.Controls.Add(this.groupBox1);
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
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
           
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(12, 24);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(344, 377);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // ChartPanel
            // 
            this.ChartPanel.Controls.Add(this.checkBox4);
            this.ChartPanel.Controls.Add(this.checkBox3);
            this.ChartPanel.Controls.Add(this.checkBox2);
            this.ChartPanel.Controls.Add(this.chart1);
            this.ChartPanel.Controls.Add(this.groupBox3);
            this.ChartPanel.Location = new System.Drawing.Point(399, 8);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(368, 457);
            this.ChartPanel.TabIndex = 21;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(57, 420);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(74, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Real Time";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(168, 420);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Average";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(271, 420);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(76, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Peak Hold";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 448);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Charting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Device:";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(210, 67);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(39, 13);
            this.labelModel.TabIndex = 13;
            this.labelModel.Text = "Model:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 475);
            this.Controls.Add(this.ChartPanel);
            this.Controls.Add(this.ConnectionPanel);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.SweepPanel);
            this.Name = "MainForm";
            this.Text = "OnSite";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSerialConnection.ResumeLayout(false);
            this.groupBoxSerialConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweeps)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SweepPanel.ResumeLayout(false);
            this.ConfigurationPanel.ResumeLayout(false);
            this.ConnectionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ChartPanel.ResumeLayout(false);
            this.ChartPanel.PerformLayout();
            this.ResumeLayout(false);

    }
        #endregion

        private Button buttonFindCOMPorts;
        private Button buttonSetConfiguration;
        private Button buttonStartSweeps;
        private ComboBox comboBoxProgramMode;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBoxSerialConnection;
        private Label label10;
        private Label label11;
        private Label label1;
        private Label label2;
        private Label labelFoundDevice;
        private Label labelFoundModel;
        private Label label6;
        private Label labelFirmware;
        private Label label8;
        private Label label9;
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
        private ProgressBar progressBar1;
        private RadioButton radioButtonRBW;
        private RadioButton radioButtonSize;
        private RadioButton radioButtonStart;
        private RadioButton radioButtonStop;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBoxRBW;
        private TextBox textBoxStartFrequency;
        private TextBox textBoxStepSize;
        private TextBox textBoxStopFrequency;
        private CheckBox checkBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Panel ChartPanel;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private GroupBox groupBox3;
        private Label label3;
        private Label labelModel;
    }
}

