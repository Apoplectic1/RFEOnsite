using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFEOnSite
{
    public class Charts
    {
        private List<double> mFrequencyList;
        private Series mSeriesAverage;
        private Series mSeriesPeak;
        private Single mTitleFontSize;
        private double mStepX;
        private double mTickIntervalX;
        private double mTickIntervalY;
        private string mBackColor;
        private string mBand;
        private string mChartFont;
        private string mForeColor;
        private string mTitle;
        private string mTitleX;
        private string mTitleY;

        public Chart Chart { get; }
        public Series Series { get; set; }
        public bool AutoScale { get; set; }
        public bool GraphAverage { get; set; }
        public bool GraphPeak { get; set; }
        public double MaxX { get; set; }
        public double MaxY { get; set; }
        public double MinX { get; set; }
        public double MinY { get; set; }


        public Charts()
        {
            AutoScale = false;
            mBackColor = "#e0e0e0";
            mBand = string.Empty;
            Chart = new Chart();
            mChartFont = "Arial";
            mForeColor = "#f0f0f0";
            mFrequencyList = new List<double>();
            GraphAverage = true;
            GraphPeak = true;
            MaxX = 2800;
            MaxY = -25;
            MinX = 0;
            MinY = -110;
            mTickIntervalX = 200;
            mTickIntervalY = 10;
            mTitle = "Current Sweep Range";
            mTitleFontSize = 10F;
            mTitleX = "MHz";
            mTitleY = "dBm";
            mStepX = -1.0;
        }

        public void BuildChart()
        {
            Chart.Name = "RFE";
            Chart.BackColor = System.Drawing.ColorTranslator.FromHtml(mBackColor);
            Chart.ChartAreas.Add("");

            Chart.ChartAreas[0].AxisX.Interval = mTickIntervalX;
            Chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(mChartFont, 10F);
            Chart.ChartAreas[0].AxisX.LabelStyle.Format = "F1";
            Chart.ChartAreas[0].AxisX.Maximum = MaxX;
            Chart.ChartAreas[0].AxisX.Minimum = MinX;
            Chart.ChartAreas[0].AxisX.RoundAxisValues();
            Chart.ChartAreas[0].AxisX.Title = mTitleX;
            Chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font(mChartFont, 10F);

            Chart.ChartAreas[0].AxisY.Interval = mTickIntervalY;
            Chart.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font(mChartFont, 10F);
            Chart.ChartAreas[0].AxisY.RoundAxisValues();
            Chart.ChartAreas[0].AxisY.LabelStyle.Format = "F0";
            Chart.ChartAreas[0].AxisY.Title = mTitleY;
            Chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font(mChartFont, 10F);
            Chart.ChartAreas[0].AxisY.Maximum = MaxY;
            Chart.ChartAreas[0].AxisY.Minimum = MinY;


            Chart.ForeColor = System.Drawing.ColorTranslator.FromHtml(mForeColor);
            Chart.Titles.Add(mTitle);
            Chart.Titles[0].Font = new System.Drawing.Font(mChartFont, mTitleFontSize);

            Chart.Palette = ChartColorPalette.Bright;
        }

        public void DrawChart(bool maxChart, bool avgChart, List<string> stringData)
        {
            double frequency;

            Chart.ChartAreas[0].AxisX.Maximum = MaxX;
            Chart.ChartAreas[0].AxisX.Minimum = MinX;
            Chart.ChartAreas[0].AxisX.Interval = (MaxX - MinX) / 5;


            Decibels dBm = new Decibels();
            DataPoint dpMaxY = new DataPoint();
            DataPoint dpMinY = new DataPoint();

            mFrequencyList.Clear();
            mStepX = (MaxX - MinX) / 112.0;
            frequency = MinX;
            for (int index = 0; index < 112; index++)
            {
                frequency += mStepX;
                mFrequencyList.Add(frequency);
            }

            RemoveChartSeries("All");

            if (avgChart)
            {
                mSeriesAverage = new Series();
                mSeriesAverage.Color = Color.Green;
                mSeriesAverage.ChartType = SeriesChartType.Spline;
            }

            if (maxChart)
            {
                mSeriesPeak = new Series();
                mSeriesPeak.Color = Color.Blue;
                mSeriesPeak.ChartType = SeriesChartType.Spline;
            }
            // Walk across each Sweep Column
            for (int index = 0; index != 112; index++)
            {
                // Walk DOWN each Sweep Row using the same column index
                for (int sweepIndex = 0; sweepIndex < stringData.Count; sweepIndex++)
                {
                    dBm.ExplorerDbmToList(stringData[sweepIndex][index + 3]);
                }

                if (maxChart)
                {
                    mSeriesPeak.Points.AddXY(mFrequencyList[index], dBm.MaxdBmList());
                }

                if (avgChart)
                {
                    mSeriesAverage.Points.AddXY(mFrequencyList[index], dBm.AveragedBmList());
                }

                dBm.Clear();
            }

            if (maxChart)
            {
                mSeriesPeak.LabelBackColor = System.Drawing.Color.White;
                dpMaxY = mSeriesPeak.Points.FindMaxByValue();
                dpMaxY.Label = dpMaxY.YValues[0].ToString() + " Peak";
                dpMaxY.Font = new System.Drawing.Font("Arial", 10f);
                dpMaxY.MarkerColor = System.Drawing.Color.Blue;
                dpMaxY.MarkerSize = 5;
                dpMaxY.MarkerStyle = MarkerStyle.Circle;
            }

            if (avgChart && !maxChart)
            {
                mSeriesAverage.LabelBackColor = System.Drawing.Color.White;
                dpMaxY = mSeriesAverage.Points.FindMaxByValue();
                dpMaxY.Label = Math.Round(dpMaxY.YValues[0], 1).ToString() + " Avg Peak";
                dpMaxY.Font = new System.Drawing.Font("Arial", 10f);
                dpMaxY.MarkerColor = System.Drawing.Color.Green;
                dpMaxY.MarkerSize = 5;
                dpMaxY.MarkerStyle = MarkerStyle.Circle;
            }

            if (AutoScale)
            {
                double maxY = dpMaxY.YValues[0];

                if (avgChart)
                {
                    dpMinY = mSeriesAverage.Points.FindMinByValue();
                }

                if (!avgChart)
                {
                    dpMinY = mSeriesPeak.Points.FindMinByValue();
                }

                double minY = dpMinY.YValues[0];

                double temp = (maxY - (maxY % mTickIntervalY));
                temp = (temp == maxY) ? temp + mTickIntervalY : temp;
                Chart.ChartAreas[0].AxisY.Maximum = temp;

                if ((minY % mTickIntervalY) != 0)
                {
                    minY = (minY - (minY % mTickIntervalY)) - mTickIntervalY;
                }

                Chart.ChartAreas[0].AxisY.Minimum = minY;

            }
            else
            {
                Chart.ChartAreas[0].AxisY.Maximum = -30;
                Chart.ChartAreas[0].AxisY.Minimum = -110;
            }



            if (GraphPeak)
            {
                Chart.Series.Add(mSeriesPeak);
            }
            if (GraphAverage)
            {
                Chart.Series.Add(mSeriesAverage);
            }
        }

        public void ShowSeries(string seriesName, bool state)
        {
            int foundIndex;

            foundIndex = Chart.Series.IndexOf(seriesName);

            Chart.Series[foundIndex].Enabled = state;
        }

        public void RemoveChartSeries(string seriesName)
        {
            if (seriesName == "All")
            {
                while (Chart.Series.Count > 0)
                {
                    Chart.Series.RemoveAt(0);
                }
            }
            else
            {
                int index = Chart.Series.IndexOf(seriesName);

                if (index >= 0)
                {
                    Chart.Series.RemoveAt(index);
                }
            }
        }
    }
}
