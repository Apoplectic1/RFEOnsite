using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFEOnSite
{
    public partial class WhoopNodeForm : Form
    {
        

        public WhoopNodeForm()
        {
            InitializeComponent();
            mSelected = false;
        
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
           mSelected = true;
        }
    }
}
