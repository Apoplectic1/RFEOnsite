using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFEOnSite
{
    class UIMethods
    {
        private MainForm mMainForm;

        public UIMethods(MainForm form)
        {
            mMainForm = form;
        }

        public void SendExplorerConfiguration()
        {


            //double startMHz = Convert.ToDouble(mMainForm.StartFrequency.Text);
            //double stopMHz = Convert.ToDouble(mMainForm.StopFrequency.Text);
            //double stepKHZ = Convert.ToDouble(mMainForm.StepSize.Text);

            //gRFEOnSite.Explorer.SendConfiguration(startMHz, stopMHz, -80, -110);

            //gRFEOnSite.Graph.MinX = startMHz;
            //gRFEOnSite.Graph.MaxX = stopMHz;
            //gRFEOnSite.Graph.StepX = stepKHZ / 1000.0;

            //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Maximum = gRFEOnSite.Graph.MaxX;
            //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Minimum = gRFEOnSite.Graph.MinX;

            //gRFEOnSite.Graph.Chart.ChartAreas[0].AxisX.Interval = (gRFEOnSite.Graph.MaxX - gRFEOnSite.Graph.MinX) / 5;

            //ButtonStartSweeps.Enabled = true;
            //string temp = mMainForm.StartFrequency.Text;


            //mMainForm.StartFrequency.Text = "701.0";


        }
    }
}
