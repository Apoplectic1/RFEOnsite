using System;
using System.Windows.Forms;
using static RFExplorerCommunicator.RFExplorer;

namespace RFE_SerialTest
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelStopMHz = new System.Windows.Forms.Label();
            this.labelStartMHz = new System.Windows.Forms.Label();
            this.radioButtonSize = new System.Windows.Forms.RadioButton();
            this.radioButtonRBW = new System.Windows.Forms.RadioButton();
            this.radioButtonStop = new System.Windows.Forms.RadioButton();
            this.radioButtonStart = new System.Windows.Forms.RadioButton();
            this.buttonSetConfiguration = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFindCOMPorts
            // 
            this.buttonFindCOMPorts.Location = new System.Drawing.Point(12, 12);
            this.buttonFindCOMPorts.Name = "buttonFindCOMPorts";
            this.buttonFindCOMPorts.Size = new System.Drawing.Size(109, 35);
            this.buttonFindCOMPorts.TabIndex = 0;
            this.buttonFindCOMPorts.Text = "Connect RF Explorer";
            this.buttonFindCOMPorts.UseVisualStyleBackColor = true;
            this.buttonFindCOMPorts.Click += new System.EventHandler(this.ButtonFindPorts_Click);
            // 
            // labelRFEComPort
            // 
            this.labelRFEComPort.Location = new System.Drawing.Point(128, 23);
            this.labelRFEComPort.Name = "labelRFEComPort";
            this.labelRFEComPort.Size = new System.Drawing.Size(108, 13);
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
            this.labelFrequencyStep.Size = new System.Drawing.Size(29, 13);
            this.labelFrequencyStep.TabIndex = 9;
            this.labelFrequencyStep.Text = "MHz";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 132);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Configuration";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(125, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 261);
            this.Controls.Add(this.labelRFEComPort);
            this.Controls.Add(this.buttonFindCOMPorts);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "OnSite";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }
        private Button buttonFindCOMPorts;
        private Label labelRFEComPort;
        private Label labelStartFrequency;
        private TextBox textBoxStartFrequency;



        #endregion

        private Label label1;
        private Label labelRBW;
        private Label labelRBWKhz;
        private TextBox textBoxStopFrequency;
        private Label label2;
        private Label labelFrequencyStep;
        private GroupBox groupBox1;
        private RadioButton radioButtonSize;
        private RadioButton radioButtonRBW;
        private RadioButton radioButtonStop;
        private RadioButton radioButtonStart;
        private Button buttonSetConfiguration;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label labelStopMHz;
        private Label labelStartMHz;
    }
}

