using System;
using System.Windows.Forms;

namespace RFEOnSite
{
    public partial class WhoopNodeForm : Form
    {
        public bool PresetFormCheckBox700 { get { return checkBox700.Checked; } set { checkBox700.Checked = value; } }
        public bool PresetFormCheckBox850 { get { return checkBox850.Checked; } set { checkBox850.Checked = value; } }
        public bool PresetFormCheckBoxPCS { get { return checkBoxPCS.Checked; } set { checkBoxPCS.Checked = value; } }
        public bool PresetFormCheckBoxAWS { get { return checkBoxAWS.Checked; } set { checkBoxAWS.Checked = value; } }

        public bool Selected { get; set; }


        public WhoopNodeForm()
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
