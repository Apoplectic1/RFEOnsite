namespace RFEOnSite
{
    partial class WhoopNodeForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.checkBoxAWS = new System.Windows.Forms.CheckBox();
            this.checkBoxPCS = new System.Windows.Forms.CheckBox();
            this.checkBox850 = new System.Windows.Forms.CheckBox();
            this.checkBox700 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSelect);
            this.groupBox1.Controls.Add(this.checkBoxAWS);
            this.groupBox1.Controls.Add(this.checkBoxPCS);
            this.groupBox1.Controls.Add(this.checkBox850);
            this.groupBox1.Controls.Add(this.checkBox700);
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Whoop Node Supported Downlink Frequencies";
            // 
            // buttonSelect
            // 
            this.buttonSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSelect.Location = new System.Drawing.Point(180, 60);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 9;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // checkBoxAWS
            // 
            this.checkBoxAWS.AutoSize = true;
            this.checkBoxAWS.Checked = true;
            this.checkBoxAWS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAWS.Location = new System.Drawing.Point(6, 102);
            this.checkBoxAWS.Name = "checkBoxAWS";
            this.checkBoxAWS.Size = new System.Drawing.Size(169, 17);
            this.checkBoxAWS.TabIndex = 3;
            this.checkBoxAWS.Text = "AWS - 2110.0  to 2155.0 MHz";
            this.checkBoxAWS.UseVisualStyleBackColor = true;
            // 
            // checkBoxPCS
            // 
            this.checkBoxPCS.AutoSize = true;
            this.checkBoxPCS.Checked = true;
            this.checkBoxPCS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPCS.Location = new System.Drawing.Point(6, 78);
            this.checkBoxPCS.Name = "checkBoxPCS";
            this.checkBoxPCS.Size = new System.Drawing.Size(165, 17);
            this.checkBoxPCS.TabIndex = 2;
            this.checkBoxPCS.Text = "PCS - 1930.0  to 1995.0 MHz";
            this.checkBoxPCS.UseVisualStyleBackColor = true;
            // 
            // checkBox850
            // 
            this.checkBox850.AutoSize = true;
            this.checkBox850.Checked = true;
            this.checkBox850.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox850.Location = new System.Drawing.Point(6, 54);
            this.checkBox850.Name = "checkBox850";
            this.checkBox850.Size = new System.Drawing.Size(150, 17);
            this.checkBox850.TabIndex = 1;
            this.checkBox850.Text = "850 - 869.0  to 894.0 MHz";
            this.checkBox850.UseVisualStyleBackColor = true;
            // 
            // checkBox700
            // 
            this.checkBox700.AutoSize = true;
            this.checkBox700.Checked = true;
            this.checkBox700.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox700.Location = new System.Drawing.Point(6, 30);
            this.checkBox700.Name = "checkBox700";
            this.checkBox700.Size = new System.Drawing.Size(150, 17);
            this.checkBox700.TabIndex = 0;
            this.checkBox700.Text = "700 - 734.0  to 757.0 MHz";
            this.checkBox700.UseVisualStyleBackColor = true;
            this.checkBox700.CheckedChanged += new System.EventHandler(this.CheckBox700_CheckedChanged);
            // 
            // WhoopNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 163);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WhoopNodeForm";
            this.Text = "Downlink Preset";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxAWS;
        private System.Windows.Forms.CheckBox checkBoxPCS;
        private System.Windows.Forms.CheckBox checkBox850;
        private System.Windows.Forms.CheckBox checkBox700;
        private System.Windows.Forms.Button buttonSelect;
    }
}