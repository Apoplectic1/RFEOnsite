using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFE_OnSite
{
    class Charts
    {
        private AntiAliasingStyles mAntiAliasingStyles;
        private Chart mChart;
        private int mHeight;
        private int mMaxX;
        private int mMaxY;
        private int mMinX;
        private int mMinY;
        private int mTickIntervalX;
        private int mTickIntervalY;
        private int mWidth;
        private string mBackColor;
        private string mForeColor;
        private string mTitle;
        private string mTitleX;
        private string mTitleY;
        private string mChartFont;
        private Single mTitleFontSize;
        private int mColumnBegin;
        private bool mShowMarkers;
        private double mRangeStart;
        private double mRangeStop;
        private string mBand;

        private double pointMaxY;
        private double pointMinY;

        public Charts()
        {
            mAntiAliasingStyles = AntiAliasingStyles.All;
            mBackColor = "#f0f0f0";
            mForeColor = "#ffffff";
            mHeight = 450;
            mMaxX = -1;
            mMaxY = -25;
            mMinX = -1;
            mMinY = -105;
            mTickIntervalX = 10;
            mTickIntervalY = 5;
            mTitle = string.Empty;
            mChartFont = "Arial";
            mTitleX = "Set Title";
            mTitleY = "dBm";
            mWidth = 570;
            mTitleFontSize = 30F;
            mShowMarkers = true;
            mBand = string.Empty;
            //    IEnumerable<Strips> mStripList = Strips.GetStrips();
        }

        private void MakeChart(DataTable dataTable)
        {
            MarkerStyle markers = new MarkerStyle();

            markers = (mShowMarkers) ? MarkerStyle.Circle : MarkerStyle.None;

            mChart = new Chart();

            // Set Chart Properties
            mChart.AntiAliasing = mAntiAliasingStyles;
            mChart.BackColor = System.Drawing.ColorTranslator.FromHtml(mBackColor);
            mChart.ChartAreas.Add("");
            mChart.ChartAreas[0].AxisX.Interval = mTickIntervalX;
            mChart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            mChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(mChartFont, 24F);
            //mChart.ChartAreas[0].AxisX.LabelStyle.Enabled = SiteData.RadialSurvey;
            mChart.ChartAreas[0].AxisX.Maximum = mMaxX;
            mChart.ChartAreas[0].AxisX.Minimum = mMinX;
            mChart.ChartAreas[0].AxisX.RoundAxisValues();
            mChart.ChartAreas[0].AxisX.Title = mTitleX;
            mChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font(mChartFont, 30F);
            mChart.ChartAreas[0].AxisY.Interval = mTickIntervalY;
            mChart.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font(mChartFont, 24F);
            mChart.ChartAreas[0].AxisY.RoundAxisValues();
            mChart.ChartAreas[0].AxisY.Title = mTitleY;
            mChart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font(mChartFont, 30F);
            mChart.ForeColor = System.Drawing.ColorTranslator.FromHtml(mForeColor);
            mChart.Height = mHeight;
            mChart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            mChart.Titles.Add(mTitle);
            mChart.Titles[0].Font = new System.Drawing.Font(mChartFont, mTitleFontSize);
            mChart.Width = mWidth;
            mChart.Legends.Add(new Legend("legend1"));
            mChart.Legends["legend1"].Docking = Docking.Bottom;
            mChart.Legends["legend1"].Font = new System.Drawing.Font(mChartFont, 20F);
            mChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;

            // Get all possible degrees to plot
            string[] allColumnNames = (from DataColumn x in dataTable.Columns select x.ColumnName).ToArray();
            string[] slice = allColumnNames.Skip(mColumnBegin).ToArray();

            // Add Series Data43

            mChart.Series.Add("Maximum");
            //mChart.Series.Add("Minimum");
            //mChart.Series.Add("Average");
            //mChart.Series.Add("Mode");

            mChart.Series["Maximum"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            //mChart.Series["Minimum"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            //mChart.Series["Average"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            //mChart.Series["Mode"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;


            mChart.Series["Maximum"].Legend = "legend1";
            //mChart.Series["Maximum"].MarkerStyle = markers;
            //mChart.Series["Minimum"].MarkerStyle = markers;
            //mChart.Series["Average"].MarkerStyle = markers;
            //mChart.Series["Mode"].MarkerStyle = markers;

            mChart.Series["Maximum"].MarkerSize = 10;
            //mChart.Series["Minimum"].MarkerSize = 7;
            //mChart.Series["Average"].MarkerSize = 7;
            //mChart.Series["Mode"].MarkerSize = 7;

            mChart.Series["Maximum"].BorderWidth = 5;

            int index = mColumnBegin;
            int seriesIndex = 0;
            foreach (string str in slice)
            {
                double xValue = Convert.ToDouble(str);

                if (xValue >= mRangeStart && xValue <= mRangeStop)
                {
                    double yMax, yMin, yAverage, yMode;

                    yAverage = Convert.ToDouble(dataTable.Rows[0][index]);
                    yMax = Convert.ToDouble(dataTable.Rows[1][index]);
                    yMin = Convert.ToDouble(dataTable.Rows[2][index]);
                    yMode = Convert.ToDouble(dataTable.Rows[3][index]);


                    mChart.Series["Maximum"].Points.AddXY(xValue, yMax);
                    mChart.Series["Maximum"].LabelBackColor = System.Drawing.Color.White;
                    mChart.Series["Maximum"].Font = new System.Drawing.Font(mChartFont, 15f);
                    //mChart.Series["Minimum"].Points.AddXY(xValue, yMin);
                    //mChart.Series["Average"].Points.AddXY(xValue, yAverage);
                    //mChart.Series["Mode"].Points.AddXY(xValue, yMode);

                    index++;
                    seriesIndex++;
                }
            }
            // Special Case just to make chart pretty
            if (slice[0] == "0" && slice.Length >= 4)
            {
                //mChart.Series["Average"].Points.AddXY(360, Convert.ToDouble(dataTable.Rows[0][mColumnBegin]));
                mChart.Series["Maximum"].Points.AddXY(360, Convert.ToDouble(dataTable.Rows[1][mColumnBegin]));
                //mChart.Series["Minimum"].Points.AddXY(360, Convert.ToDouble(dataTable.Rows[2][mColumnBegin]));
                //mChart.Series["Mode"].Points.AddXY(360, Convert.ToDouble(dataTable.Rows[3][mColumnBegin]));

                DataPoint last = mChart.Series["Maximum"].Points.Last();
                last.Label = last.YValues[0].ToString() + " dBm";
            }

            // Write Min and Max dBm Value on Chart
            DataPoint dpMaxY = new DataPoint();
            DataPoint dpMinY = new DataPoint();
            pointMaxY = -200;
            pointMinY = 200;
            foreach (DataPoint d in mChart.Series["Maximum"].Points)
            {
                d.Label = d.YValues[0].ToString() + " dBm";

                if (d.YValues[0] > pointMaxY)
                {
                    pointMaxY = d.YValues[0];
                    dpMaxY = d;
                }

                if (d.YValues[0] < pointMinY)
                {
                    pointMinY = d.YValues[0];
                    dpMinY = d;
                }
            }

            dpMinY.Label = dpMinY.YValues[0].ToString() + " Min";
            dpMaxY.Label = dpMaxY.YValues[0].ToString() + " Max";
            dpMaxY.Font = new System.Drawing.Font(mChartFont, 20f);
            dpMinY.Font = new System.Drawing.Font(mChartFont, 20f);


            //if (dataTable.Rows[0]["Band"].ToString().Contains("700"))
            //{
            //    if (eDataType == eData.eChannelPower)
            //    {
            //        pointMaxY = TableOps.Get700CpYMax;
            //        pointMinY = TableOps.Get700CpYMin;
            //    }
            //    else
            //    {
            //        pointMaxY = TableOps.Get700ExYMax;
            //        pointMinY = TableOps.Get700ExYMin;
            //    }
            //}


            //if (dataTable.Rows[0]["Band"].ToString().Contains("850"))
            //{
            //    if (eDataType == eData.eChannelPower)
            //    {
            //        pointMaxY = TableOps.Get850CpYMax;
            //        pointMinY = TableOps.Get850CpYMin;
            //    }
            //    else
            //    {
            //        pointMaxY = TableOps.Get850ExYMax;
            //        pointMinY = TableOps.Get850ExYMin;
            //    }
            //}

            //if (dataTable.Rows[0]["Band"].ToString().Contains("PCS"))
            //{
            //    if (eDataType == eData.eChannelPower)
            //    {
            //        pointMaxY = TableOps.GetPcsCpYMax;
            //        pointMinY = TableOps.GetPcsCpYMin;
            //    }
            //    else
            //    {
            //        pointMaxY = TableOps.GetPcsExYMax;
            //        pointMinY = TableOps.GetPcsExYMin;
            //    }
            //}

            //if (dataTable.Rows[0]["Band"].ToString().Contains("AWS"))
            //{
            //    if (eDataType == eData.eChannelPower)
            //    {
            //        pointMaxY = TableOps.GetAwsCpYMax;
            //        pointMinY = TableOps.GetAwsCpYMin;
            //    }
            //    else
            //    {
            //        pointMaxY = TableOps.GetAwsExYMax;
            //        pointMinY = TableOps.GetAwsExYMin;
            //    }
            //}

            //double temp = (pointMaxY - (pointMaxY % mTickIntervalY));
            //temp = (temp == pointMaxY) ? temp + mTickIntervalY : temp;
            //mChart.ChartAreas[0].AxisY.Maximum = temp;

            //if ((pointMinY % mTickIntervalY) != 0)
            //{
            //    pointMinY = (pointMinY - (pointMinY % mTickIntervalY)) - mTickIntervalY;
            //}

            //mChart.ChartAreas[0].AxisY.Minimum = pointMinY;
        }


    }
}
