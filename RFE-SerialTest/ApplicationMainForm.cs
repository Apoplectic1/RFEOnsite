using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFE_SerialTest;

namespace RFE_SerialTest
{
    public partial class MainForm : Form
    {
        RFExplorer gRFE;
        
        

        public MainForm()
        {
            InitializeComponent();

            gRFE = new RFExplorer();
        }

        private void buttonFindPorts_Click(object sender, EventArgs e)
        {
            bool bStatus;

            gRFE.Initialize();

            
        }
    }
}
