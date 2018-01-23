namespace RFEOnSite
{
    partial class FullDownlinkForm
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
            this.CheckBox700M = new System.Windows.Forms.CheckBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.checkBoxAWS = new System.Windows.Forms.CheckBox();
            this.checkBoxPCS = new System.Windows.Forms.CheckBox();
            this.CheckBox850 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckBox700M);
            this.groupBox1.Controls.Add(this.buttonSelect);
            this.groupBox1.Controls.Add(this.checkBoxAWS);
            this.groupBox1.Controls.Add(this.checkBoxPCS);
            this.groupBox1.Controls.Add(this.CheckBox850);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Band(s)";
            // 
            // CheckBox700M
            // 
            this.CheckBox700M.AutoSize = true;
            this.CheckBox700M.Checked = true;
            this.CheckBox700M.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox700M.Location = new System.Drawing.Point(6, 31);
            this.CheckBox700M.Name = "CheckBox700M";
            this.CheckBox700M.Size = new System.Drawing.Size(122, 17);
            this.CheckBox700M.TabIndex = 10;
            this.CheckBox700M.Text = "700 - 714.0 to 770.0";
            this.CheckBox700M.UseVisualStyleBackColor = true;
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
            this.checkBoxAWS.Location = new System.Drawing.Point(6, 100);
            this.checkBoxAWS.Name = "checkBoxAWS";
            this.checkBoxAWS.Size = new System.Drawing.Size(141, 17);
            this.checkBoxAWS.TabIndex = 3;
            this.checkBoxAWS.Text = "AWS - 2105.0 to 2183.4";
            this.checkBoxAWS.UseVisualStyleBackColor = true;
            // 
            // checkBoxPCS
            // 
            this.checkBoxPCS.AutoSize = true;
            this.checkBoxPCS.Checked = true;
            this.checkBoxPCS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPCS.Location = new System.Drawing.Point(6, 77);
            this.checkBoxPCS.Name = "checkBoxPCS";
            this.checkBoxPCS.Size = new System.Drawing.Size(137, 17);
            this.checkBoxPCS.TabIndex = 2;
            this.checkBoxPCS.Text = "PCS - 1929.0 to 1996.2";
            this.checkBoxPCS.UseVisualStyleBackColor = true;
            // 
            // CheckBox850
            // 
            this.CheckBox850.AutoSize = true;
            this.CheckBox850.Checked = true;
            this.CheckBox850.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox850.Location = new System.Drawing.Point(6, 54);
            this.CheckBox850.Name = "CheckBox850";
            this.CheckBox850.Size = new System.Drawing.Size(122, 17);
            this.CheckBox850.TabIndex = 1;
            this.CheckBox850.Text = "850 - 865.0 to 898.6";
            this.CheckBox850.UseVisualStyleBackColor = true;
            // 
            // FullDownlinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 149);
            this.Controls.Add(this.groupBox1);
            this.Name = "FullDownlinkForm";
            this.Text = "Downlink Band Selection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.CheckBox checkBoxAWS;
        private System.Windows.Forms.CheckBox checkBoxPCS;
        private System.Windows.Forms.CheckBox CheckBox850;
        private System.Windows.Forms.CheckBox CheckBox700M;
    }
}