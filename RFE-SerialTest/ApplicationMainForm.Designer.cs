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
            this.label3 = new System.Windows.Forms.Label();
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
            this.labelStartFrequency.Location = new System.Drawing.Point(37, 68);
            this.labelStartFrequency.Name = "labelStartFrequency";
            this.labelStartFrequency.Size = new System.Drawing.Size(82, 13);
            this.labelStartFrequency.TabIndex = 2;
            this.labelStartFrequency.Text = "Start Frequency";
            // 
            // textBoxStartFrequency
            // 
            this.textBoxStartFrequency.Location = new System.Drawing.Point(125, 64);
            this.textBoxStartFrequency.Name = "textBoxStartFrequency";
            this.textBoxStartFrequency.Size = new System.Drawing.Size(58, 20);
            this.textBoxStartFrequency.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stop Frequency";
            // 
            // labelRBW
            // 
            this.labelRBW.AutoSize = true;
            this.labelRBW.Location = new System.Drawing.Point(9, 112);
            this.labelRBW.Name = "labelRBW";
            this.labelRBW.Size = new System.Drawing.Size(110, 13);
            this.labelRBW.TabIndex = 5;
            this.labelRBW.Text = "Resolution Bandwidth";
            // 
            // labelRBWKhz
            // 
            this.labelRBWKhz.AutoSize = true;
            this.labelRBWKhz.Location = new System.Drawing.Point(125, 112);
            this.labelRBWKhz.Name = "labelRBWKhz";
            this.labelRBWKhz.Size = new System.Drawing.Size(27, 13);
            this.labelRBWKhz.TabIndex = 6;
            this.labelRBWKhz.Text = "KHz";
            // 
            // textBoxStopFrequency
            // 
            this.textBoxStopFrequency.Location = new System.Drawing.Point(125, 89);
            this.textBoxStopFrequency.Name = "textBoxStopFrequency";
            this.textBoxStopFrequency.Size = new System.Drawing.Size(58, 20);
            this.textBoxStopFrequency.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Frequency Step";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxStopFrequency);
            this.Controls.Add(this.labelRBWKhz);
            this.Controls.Add(this.labelRBW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStartFrequency);
            this.Controls.Add(this.labelStartFrequency);
            this.Controls.Add(this.labelRFEComPort);
            this.Controls.Add(this.buttonFindCOMPorts);
            this.Name = "MainForm";
            this.Text = "7";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label label3;
    }
}

