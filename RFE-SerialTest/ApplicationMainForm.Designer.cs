using System.Windows.Forms;

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
            labelRFEComPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFindCOMPorts
            // 
            this.buttonFindCOMPorts.Location = new System.Drawing.Point(12, 12);
            this.buttonFindCOMPorts.Name = "buttonFindCOMPorts";
            this.buttonFindCOMPorts.Size = new System.Drawing.Size(109, 23);
            this.buttonFindCOMPorts.TabIndex = 0;
            this.buttonFindCOMPorts.Text = "Find RF Explorer";
            this.buttonFindCOMPorts.UseVisualStyleBackColor = true;
            this.buttonFindCOMPorts.Click += new System.EventHandler(this.buttonFindPorts_Click);
            // 
            // labelRFEComPort
            // 
            labelRFEComPort.AutoSize = false;
            labelRFEComPort.Location = new System.Drawing.Point(128, 17);
            labelRFEComPort.Name = "labelRFEComPort";
            labelRFEComPort.Size = new System.Drawing.Size(108, 13);
            labelRFEComPort.TabIndex = 1;
            labelRFEComPort.Text = "RF Explorer Com Port";
            // 
            // applicationMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(labelRFEComPort);
            this.Controls.Add(this.buttonFindCOMPorts);
            this.Name = "applicationMainForm";
            this.Text = "RFE Serial Port Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonFindCOMPorts;
        private static Label labelRFEComPort;
        public static string ComPortLabel { get { return labelRFEComPort.Text; } set { labelRFEComPort.Text = value; } }
    }
}

