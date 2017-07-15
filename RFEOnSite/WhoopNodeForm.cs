using System;
using System.Windows.Forms;

namespace RFEOnSite
{
    public partial class WhoopNodeForm : Form
    {
        private bool mSelected;
        public bool CheckBox700 { get { return checkBox700.Checked; } set { checkBox700.Checked = value; } }
        public bool CheckBox850 { get { return checkBox850.Checked; } set { checkBox850.Checked = value; } }
        public bool CheckBoxPCS { get { return checkBoxPCS.Checked; } set { checkBoxPCS.Checked = value; } }
        public bool CheckBoxAWS { get { return checkBoxAWS.Checked; } set { checkBoxAWS.Checked = value; } }

        public bool Selected { get { return mSelected; } set { mSelected = value; } }


        public WhoopNodeForm()
        {
            
            mSelected = false;
            
            InitializeComponent();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
           mSelected = true;
        }
    }
}
