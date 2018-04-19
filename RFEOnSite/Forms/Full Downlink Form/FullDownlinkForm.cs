using System;
using System.Windows.Forms;


namespace RFEOnSite
{
    public partial class FullDownlinkForm : Form
    {
        public bool PresetFormCheckBox700 { get { return CheckBox700M.Checked; } set { CheckBox700M.Checked = value; } }
        public bool PresetFormCheckBox850 { get { return CheckBox850.Checked; } set { CheckBox850.Checked = value; } }
        public bool PresetFormCheckBoxPCS { get { return checkBoxPCS.Checked; } set { checkBoxPCS.Checked = value; } }
        public bool PresetFormCheckBoxAWS { get { return checkBoxAWS.Checked; } set { checkBoxAWS.Checked = value; } }

        public bool Selected { get; set; }

        public FullDownlinkForm()
        {
            Selected = false;

            InitializeComponent();
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            Selected = true;
        }
    }
}
