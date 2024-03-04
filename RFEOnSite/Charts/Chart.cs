using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private string mTitleX;
        private string mTitleY;

        public Chart Chart { get; }
        public Series Series { get; set; }
        public bool AutoScale { get; set; }
        public double MaxX { get; set; }
        public double MaxY { get; set; }
        public double MinX { get; set; }
        public double MinY { get; set; }
        public string ChartTitle { get; set; }

        // Constructor
        public Charts()
        {
            AutoScale = false;
            mBackColor = "#e0e0e0";
            mBand = string.Empty;
            Chart = new Chart();
            mChartFont = "Arial";
            mForeColor = "#f0f0f0";
            mFrequencyList = new List<double>();
            MaxX = 2800;
            MaxY = -25;
            MinX = 0;
            MinY = -110;
            mTickIntervalX = 200;
            mTickIntervalY = 10;
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
            Chart.Titles.Add(ChartTitle);
            Chart.Titles[0].Font = new System.Drawing.Font(mChartFont, mTitleFontSize);

            Chart.Palette = ChartColorPalette.Bright;
        }

        public void InitializeSeries()
        {
            mSeriesAverage = new Series
            {
                Color = Color.Green,
                ChartType = SeriesChartType.StepLine
            };
            this.Chart.Series.Add(mSeriesAverage);

            mSeriesPeak = new Series
            {
                Color = Color.Blue,
                ChartType = SeriesChartType.StepLine
            };
            this.Chart.Series.Add(mSeriesPeak);
        }

        public void DrawChart(List<string> stringData)
        {
            Chart.ChartAreas[0].AxisX.Maximum = MaxX;
            Chart.ChartAreas[0].AxisX.Minimum = MinX;
            Chart.ChartAreas[0].AxisX.Interval = (MaxX - MinX) / 5;

            mStepX = (MaxX - MinX) / 112.0;

            Decibels dBm = new Decibels();
            DataPoint dpMaxY = new DataPoint();
            DataPoint dpMinY = new DataPoint();

            mFrequencyList = Enumerable.Range(0, 112)
                                 .Select(index => MinX + mStepX * (index + 1))
                                 .ToList();

            ClearSeries("All");

            mFrequencyList.ForEach(frequency =>
            {
                var columnIndex = mFrequencyList.IndexOf(frequency);

                // Set dBmList and wattsList values
                // dbmList and wattsList are vales for each frequency COLUMN
                stringData.ForEach(row => dBm.ExplorerDbmToLists(row[columnIndex + 3]));

                // Add points to series
                mSeriesPeak.Points.AddXY(frequency, dBm.MaxdBmList());
                mSeriesAverage.Points.AddXY(frequency, dBm.AveragedBmList());
                dBm.Clear();
            });

            if (AutoScale)
            {
                double maxY = mSeriesPeak.Points.FindMaxByValue().YValues[0];
                double minY = mSeriesPeak.Points.FindMinByValue().YValues[0];

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

            Chart.Titles.Clear();

            Chart.Titles.Add("Range: " + Chart.ChartAreas[0].AxisX.Minimum + " to " + Chart.ChartAreas[0].AxisX.Maximum + " MHz");
        }

        public void ClearSeries(string seriesName)
        {
            if (seriesName == "All")
            {
                foreach (Series series in Chart.Series)
                {
                    if (series.Name != "Initialize")
                        series.Points.Clear();
                }
            }
            else
            {
                foreach (Series series in Chart.Series)
                {
                    if (series.Name == seriesName)
                        series.Points.Clear();
                }
            }
        }
    }
}
