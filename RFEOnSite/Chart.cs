using System;
using System.Collections.Generic;
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
        private double mStepX;
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
        private Series mSeriesPeak;
        private Series mSeriesAverage;
        private bool mGraphPeak;
        private bool mGraphAverage;
        private List<double> mFrequencyList;
        private bool mAutoScale;

        public Series Series { get { return mSeries; } set { mSeries = value; } }
        public double MaxY { get { return mMaxY; } set { mMaxY = value; } }
        public double MinY { get { return mMinY; } set { mMinY = value; } }
        public double MaxX { get { return mMaxX; } set { mMaxX = value; } }
        public double MinX { get { return mMinX; } set { mMinX = value; } }
        public double StepX { get { return mStepX; } set { mStepX = value; } }
        public Chart Chart { get { return mChart; } }
        public bool GraphPeak { get { return mGraphPeak; } set { mGraphPeak = value; } }
        public bool GraphAverage { get { return mGraphAverage; } set { mGraphAverage = value; } }
        public bool AutoScale { get { return mAutoScale; } set { mAutoScale = value; } }

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
            mGraphPeak = true;
            mGraphAverage = true;
            mFrequencyList = new List<double>();
            mAutoScale = false;
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

        public void DrawChart(List<string> stringData)
        {
            double frequency;

            mChart.ChartAreas[0].AxisX.Maximum = mMaxX;
            mChart.ChartAreas[0].AxisX.Minimum = mMinX;
            mChart.ChartAreas[0].AxisX.Interval = (mMaxX - mMinX) / 5;


            Decibels dBm = new Decibels();
            DataPoint dpMaxY;
            DataPoint dpMinY;

            mFrequencyList.Clear();
            for (int index = 0; index < 112; index++)
            {
                frequency = mMinX + (index * mStepX);
                mFrequencyList.Add(frequency);
            }

            RemoveChartSeries("All");

            mSeriesPeak = new Series();
            mSeriesAverage = new Series();

            mSeriesPeak.ChartType = SeriesChartType.Spline;
            mSeriesAverage.ChartType = SeriesChartType.Spline;

            // Walk across each Sweep Column
            for (int index = 0; index != 112; index++)
            {
                // Walk DOWN each Sweep Row using the same column index
                for (int sweepIndex = 0; sweepIndex < stringData.Count; sweepIndex++)
                {
                    dBm.ExplorerDbmToList(stringData[sweepIndex][index + 3]);
                }


                mSeriesPeak.Points.AddXY(mFrequencyList[index], dBm.MaxdBmList());
                mSeriesAverage.Points.AddXY(mFrequencyList[index], dBm.AveragedBmList());

                dBm.Clear();
            }

            mSeriesPeak.LabelBackColor = System.Drawing.Color.White;
            mSeriesAverage.LabelBackColor = System.Drawing.Color.White;

            dpMaxY = mSeriesPeak.Points.FindMaxByValue();
            dpMaxY.Label = dpMaxY.YValues[0].ToString() + " Peak";
            dpMaxY.Font = new System.Drawing.Font("Arial", 10f);
            dpMaxY.MarkerColor = System.Drawing.Color.MediumBlue;
            dpMaxY.MarkerSize = 5;
            dpMaxY.MarkerStyle = MarkerStyle.Circle;

            if (mAutoScale)
            {
                double maxY = dpMaxY.YValues[0];

                dpMinY = mSeriesAverage.Points.FindMinByValue();
                double minY = dpMinY.YValues[0];

                double temp = (maxY - (maxY % mTickIntervalY));
                temp = (temp == maxY) ? temp + mTickIntervalY : temp;
                mChart.ChartAreas[0].AxisY.Maximum = temp;

                if ((minY % mTickIntervalY) != 0)
                {
                    minY = (minY - (minY % mTickIntervalY)) - mTickIntervalY;
                }

                mChart.ChartAreas[0].AxisY.Minimum = minY;
            }
            else
            {
                mChart.ChartAreas[0].AxisY.Maximum = -30;
                mChart.ChartAreas[0].AxisY.Minimum = -110;
            }



            if (mGraphPeak)
            {
                mChart.Series.Add(mSeriesPeak);
            }
            if (mGraphAverage)
            {
                mChart.Series.Add(mSeriesAverage);
            }
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
