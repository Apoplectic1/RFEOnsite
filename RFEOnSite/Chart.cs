using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFEOnSite
{

    public class Charts
    {
        private Chart mChart;  // Microsoft Class Chart
        private double mMaxX;
        private double mMaxY;
        private double mMinX;
        private double mMinY;
        private double mTickIntervalX;
        private double mTickIntervalY;
        private string mBackColor;
        private string mForeColor;
        private string mTitle;
        private string mTitleX;
        private string mTitleY;
        private string mChartFont;
        private Single mTitleFontSize;
        private string mBand;

        private Series mSeries;
        public Series Series { get { return mSeries; } set { mSeries = value; } }
        
        public double MaxY { get { return mMaxY; } set { mMaxY = value; } }
        public double MinY { get { return mMinY; } set { mMinY = value; } }
        public double MaxX { get { return mMaxX; } set { mMaxX = value; } }
        public double MinX { get { return mMinX; } set { mMinX = value; } }

        public Chart Chart { get { return mChart; } }


        public Charts()
        {
            mBackColor = "#e0e0e0";
            mForeColor = "#f0f0f0";
            mMaxX = 2800;
            mMaxY = -25;
            mMinX = 0;
            mMinY = -110;
            mTickIntervalX = 200;
            mTickIntervalY = 10;
            mTitle = string.Empty;
            mChartFont = "Arial";
            mTitleX = "MHz";
            mTitleY = "dBm";
            mTitleFontSize = 10F;
            mBand = string.Empty;
            mTitle = "Spectrum";

            mChart = new Chart();
        }

        public void BuildChart()
        {
            mChart.Name = "RFE";
            mChart.BackColor = System.Drawing.ColorTranslator.FromHtml(mBackColor);
            mChart.ChartAreas.Add("");
            mChart.ChartAreas[0].AxisX.Interval = mTickIntervalX;
            mChart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            mChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(mChartFont, 10F);
            mChart.ChartAreas[0].AxisX.Maximum = mMaxX;
            mChart.ChartAreas[0].AxisX.Minimum = mMinX;
            mChart.ChartAreas[0].AxisX.RoundAxisValues();
            mChart.ChartAreas[0].AxisX.Title = mTitleX;
            mChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font(mChartFont, 10F);

            mChart.ChartAreas[0].AxisY.Interval = mTickIntervalY;
            mChart.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font(mChartFont, 10F);
            mChart.ChartAreas[0].AxisY.RoundAxisValues();
            mChart.ChartAreas[0].AxisY.Title = mTitleY;
            mChart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font(mChartFont, 10F);
            mChart.ChartAreas[0].AxisY.Maximum = mMaxY;
            mChart.ChartAreas[0].AxisY.Minimum = mMinY;


            mChart.ForeColor = System.Drawing.ColorTranslator.FromHtml(mForeColor);
            mChart.Titles.Add(mTitle);
            mChart.Titles[0].Font = new System.Drawing.Font(mChartFont, mTitleFontSize);

            mChart.Palette = ChartColorPalette.Bright;
        }

        public void DrawChart(string series)
        {

        }

        public void ShowSeries(string seriesName, bool state)
        {
            int foundIndex;

            foundIndex = mChart.Series.IndexOf(seriesName);

            mChart.Series[foundIndex].Enabled = state;
        }

        public void RemoveChartSeries(string seriesName)
        {
            if (seriesName == "All")
            {
                while (mChart.Series.Count > 0)
                {
                    mChart.Series.RemoveAt(0);
                }
            }
            else
            {
               int index = mChart.Series.IndexOf(seriesName);

               mChart.Series.RemoveAt(index);
            }
        }
    }
}
