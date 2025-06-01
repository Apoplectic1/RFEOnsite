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
        private Series Series_Bin_Average;
        private Series Series_Bin_Peak;
        private Series Series_Bin_PeakHold;
        private Series Series_Bin_Population;
        private Series Series_Block_Average;

        public double ResolutionBandWidth { get; set; }
        public Chart Chart { get; }
        public Series Series { get; set; }
        public bool AutoScaleChart { get; set; }
        public double MaxX { get; set; }
        public double YAxisMax { get; set; }
        public double MinX { get; set; }
        public double YAxisMin { get; set; }
        public string Title { get; set; }

        private double SweepCount;
        private double[] AverageSweepWatts;
        private double[] PeakHoldSweepWatts;
        private Decibels dBm;
        private List<double> allYValues;
        private bool Initialized { get; set; }

        // Constructor
        public Charts()
        {
            AutoScaleChart = false;
            Chart = new Chart();
            mFrequencyList = new List<double>();
            MaxX = 2800;
            YAxisMax = -25;
            MinX = 0;
            YAxisMin = -110;
            SweepCount = 0;
            ResolutionBandWidth = 0.1;
            dBm = new Decibels();
            AverageSweepWatts = new double[112];
            PeakHoldSweepWatts = new double[112];
            allYValues = new List<double>();
            InitializeChart();
        }

        public void BuildChart()
        {
            Chart.Name = "RFE";
            Chart.BackColor = System.Drawing.ColorTranslator.FromHtml("#e0e0e0");
            Chart.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
            Chart.Titles.Clear();
            Chart.Titles.Add("Range 100 to 2700 MHz");
            Chart.Titles[0].Font = new System.Drawing.Font("Arial", 14F);
            Chart.ChartAreas.Add("");

            Chart.ChartAreas[0].AxisX.Interval = 100;
            Chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 10F);
            Chart.ChartAreas[0].AxisX.LabelStyle.Format = "F0";
            Chart.ChartAreas[0].AxisX.Maximum = 2700;
            Chart.ChartAreas[0].AxisX.Minimum = 100;
            Chart.ChartAreas[0].AxisX.RoundAxisValues();
            Chart.ChartAreas[0].AxisX.Title = "MHz";
            Chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial", 14F);
            Chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(128, Color.SlateBlue);
            Chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            Chart.ChartAreas[0].AxisY.Interval = 10;
            Chart.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 10F);
            Chart.ChartAreas[0].AxisY.RoundAxisValues();
            Chart.ChartAreas[0].AxisY.LabelStyle.Format = "F0";
            Chart.ChartAreas[0].AxisY.Title = "dBm";
            Chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial", 14F);
            Chart.ChartAreas[0].AxisY.Maximum = -50;
            Chart.ChartAreas[0].AxisY.Minimum = -110;
            Chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(128, Color.SlateBlue);
            Chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            Chart.Palette = ChartColorPalette.Bright;
        }

        public void AddChartSeries()
        {
            if (Series_Bin_Peak == null)
            {
                Series_Bin_Peak = new Series
                {
                    Name = "Bin_Peak",
                    Color = Color.FromArgb(128, Color.Blue),
                    MarkerSize = 1,
                    MarkerStyle = MarkerStyle.Square,
                    ChartType = SeriesChartType.StepLine,
                    Enabled = false
                };
                Chart.Series.Add(Series_Bin_Peak);
            }

            if (Series_Bin_Average == null)
            {
                Series_Bin_Average = new Series
                {
                    Name = "Bin_Average",
                    Color = Color.ForestGreen,
                    MarkerSize = 2,
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Square,
                    ChartType = SeriesChartType.StepLine,
                    Enabled = true
                };
                Chart.Series.Add(Series_Bin_Average);
            }

            if (Series_Bin_PeakHold == null)
            {
                Series_Bin_PeakHold = new Series
                {
                    Name = "Bin_PeakHold",
                    Color = Color.Black,
                    MarkerSize = 2,
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Square,
                    ChartType = SeriesChartType.StepLine,
                    Enabled = true
                };
                Chart.Series.Add(Series_Bin_PeakHold);
            }

            if (Series_Block_Average == null)
            {
                Series_Block_Average = new Series
                {
                    Name = "Block_Average",
                    Color = Color.ForestGreen,
                    MarkerSize = 2,
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Square,
                    ChartType = SeriesChartType.StepLine,
                    Enabled = true
                };
                Chart.Series.Add(Series_Block_Average);
            }

            if (Series_Bin_Population == null)
            {
                Series_Bin_Population = new Series
                {
                    Name = "Bin_Population",
                    Color = Color.Black,
                    MarkerSize = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    ChartType = SeriesChartType.Point,
                    Enabled = true
                };
                Chart.Series.Add(Series_Bin_Population);
            }
        }

        public void InitializeChart()
        {
            ClearSeries("All");

            for (int columnIndex = 0; columnIndex != 112; columnIndex++)
            {
                PeakHoldSweepWatts[columnIndex] = 0;
                AverageSweepWatts[columnIndex] = 0;
            }

            SweepCount = 0;
        }

        public void SetChartYLimits()
        {
            if (!AutoScaleChart)
            {
                Chart.ChartAreas[0].AxisY.Maximum = -50;
                Chart.ChartAreas[0].AxisY.Minimum = -110;
                Chart.ChartAreas[0].AxisY.Interval = 10;
                Chart.ChartAreas[0].AxisY.IntervalOffset = 0;
                return;
            }

            // *********************************************************************************************************************

            allYValues.Clear();

            if (Series_Bin_Average.Points.Count > 0)
            {
                allYValues.Add(Series_Bin_Average.Points.FindMaxByValue().YValues[0]);
                allYValues.Add(Series_Bin_Average.Points.FindMinByValue().YValues[0]);
            }

            if (Series_Bin_PeakHold.Points.Count > 0)
            {
                allYValues.Add(Series_Bin_PeakHold.Points.FindMaxByValue().YValues[0]);
                allYValues.Add(Series_Bin_PeakHold.Points.FindMinByValue().YValues[0]);
            }

            if (Series_Bin_Population.Points.Count > 0)
            {
                allYValues.Add(Series_Bin_Population.Points.FindMaxByValue().YValues[0]);
                allYValues.Add(Series_Bin_Population.Points.FindMinByValue().YValues[0]);
            }

            if (Series_Block_Average.Points.Count > 0)
            {
                allYValues.Add(Series_Block_Average.Points.FindMaxByValue().YValues[0]);
                allYValues.Add(Series_Block_Average.Points.FindMinByValue().YValues[0]);
            }

            // *********************************************************************************************************************

            if (allYValues.Any())
            {
                double maxY = allYValues.Max();
                double minY = allYValues.Min();

                double tempMax = maxY;
                double tempMin = minY;

                double dBmSpan = Math.Abs(maxY - minY);

                if (dBmSpan < 10)
                {
                    maxY = SetGridLimit(maxY, 5);
                    minY = SetGridLimit(minY, -5);
                    Chart.ChartAreas[0].AxisY.Interval = 5;
                }
                else
                {
                    maxY = SetGridLimit(maxY, 10);
                    minY = SetGridLimit(minY, -10);
                    Chart.ChartAreas[0].AxisY.Interval = 10;
                }

                if (!Initialized)
                {
                    if (maxY < YAxisMax)
                        maxY = YAxisMax;

                    if (minY > YAxisMin)
                        minY = YAxisMin;

                    if (minY == maxY)
                    {
                        maxY += 5;
                        minY -= 5;

                        if (maxY < YAxisMax)
                            maxY = YAxisMax;

                        if (minY > YAxisMin)
                            minY = YAxisMin;
                    }
                }

                Chart.ChartAreas[0].AxisY.Maximum = maxY;
                Chart.ChartAreas[0].AxisY.Minimum = minY;

                YAxisMax = maxY;
                YAxisMin = minY;
            }

            Initialized = false;
        }


        public double SetGridLimit(double yAxis, double interval)
        {
            if (interval == 0)
                return yAxis;

            if (yAxis % interval == 0)
            {
                Chart.ChartAreas[0].AxisY.IntervalOffset = 0;
                return yAxis + interval;
            }

            double remainder = Math.Truncate(yAxis) % interval;

            if (interval > 0)
            {
                Chart.ChartAreas[0].AxisY.IntervalOffset = 0;
                // Positive interval: Ceiling
                return Math.Truncate(yAxis) - remainder;
            }
            else
            {
                Chart.ChartAreas[0].AxisY.IntervalOffset = 0;
                // Negative interval: Floor
                return Math.Truncate(yAxis) - remainder + interval;
            }
        }

        public void DrawChart(string stringData, int sweepNumber)
        {
            Chart.ChartAreas[0].AxisX.Maximum = Math.Ceiling(MaxX);
            Chart.ChartAreas[0].AxisX.Minimum = Math.Floor(MinX);
            Chart.ChartAreas[0].AxisX.Interval = (MaxX - MinX) / 5;

            DataPoint dpMaxY = new DataPoint();
            DataPoint dpMinY = new DataPoint();

            mFrequencyList = Enumerable.Range(0, 112)
                  .Select(index => Math.Round(MinX + ResolutionBandWidth * (index + 1), 2))
                  .ToList();

            // Set the X Axis Min and Max dbmValue
            // These mTaps are set in InitializeChart() and are the same for all sweeps

            Chart.ChartAreas[0].AxisX.Interval = 1;

            Series_Bin_Peak.Points.Clear();
            Series_Bin_Average.Points.Clear();
            Series_Bin_PeakHold.Points.Clear();

            Series_Bin_Peak.Color = Series_Bin_Peak.Enabled ? Color.FromArgb(128, Color.Black) : Color.Transparent;
            Series_Bin_Average.Color = Series_Bin_Average.Enabled ? Color.ForestGreen : Color.Transparent;
            Series_Bin_PeakHold.Color = Series_Bin_PeakHold.Enabled ? Color.Black : Color.Transparent;

            // Walk across each Sweep Column. Each Sweep column has 112 mTaps.
            double sampleFrequency = mFrequencyList[0];

            SweepCount += 1;

            dBm.Clear();

            for (int columnIndex = 0; columnIndex != 112; columnIndex++)
            {
                double dBmValue = dBm.ExplorerDbm(stringData[columnIndex + 3]);
                double wattsValue = dBm.DbmToWatts(dBmValue);

                // Compute moving average
                AverageSweepWatts[columnIndex] = AverageSweepWatts[columnIndex] + ((wattsValue - AverageSweepWatts[columnIndex]) / SweepCount);

                // Update peak hold
                if (wattsValue > PeakHoldSweepWatts[columnIndex])
                    PeakHoldSweepWatts[columnIndex] = wattsValue;

                Series_Bin_Peak.Points.Insert(columnIndex, new DataPoint(sampleFrequency, dBmValue));
                Series_Bin_Average.Points.Insert(columnIndex, new DataPoint(sampleFrequency, dBm.WattsToDbm(AverageSweepWatts[columnIndex])));
                Series_Bin_PeakHold.Points.Insert(columnIndex, new DataPoint(sampleFrequency, dBm.WattsToDbm(PeakHoldSweepWatts[columnIndex])));

                sampleFrequency += ResolutionBandWidth;
            }

            Chart.Titles.Clear();
            string title = "Range: " + MinX + " to " + MaxX + " MHz";
            Chart.Titles.Add($"{title}   {sweepNumber}");
            Chart.Titles[0].Font = new System.Drawing.Font("Arial", 14F);
        }

        public double DrawSweepBlock(BlockTableList blockTable)
        {
            // Why NonLinearSum? We display composite power on a linear scale and want the stability logic
            // to trigger when the statistical sweep-over-sweep differences are small.
            double allBlocksDbm_NonLinearSum = 0.0;

            double startFrequency = mFrequencyList[0];
            double stopFrequency = mFrequencyList[111];

            var blockList = blockTable.GetBlockList(startFrequency, stopFrequency);


            // Draw vertical lines for each block
            /*
          foreach (var block in blockList)
          {
              double startMhz = block.SweepStart;
              double stopMhz = block.SweepStop;

              // Draw vertical lines for each block - Start
              var startMhzAnnotation = this.Chart.Annotations.FindByName(block.SweepBlock);
              if (startMhzAnnotation == null)
              {
                  VerticalLineAnnotation verticalLineStart = new VerticalLineAnnotation();
                  verticalLineStart.AxisX = this.Chart.ChartAreas[0].AxisX;
                  verticalLineStart.AllowMoving = false; // Set to false if you don't want it to be moveable
                  verticalLineStart.IsInfinitive = true; // This makes the line span the entire chart
                  verticalLineStart.ClipToChartArea = this.Chart.ChartAreas[0].Name;
                  verticalLineStart.LineColor = Color.Black;
                  verticalLineStart.LineWidth = 1;
                  verticalLineStart.X = startMhz;
                  verticalLineStart.Name = block.SweepBlock;
                  this.Chart.Annotations.Add(verticalLineStart);
              }

              // Draw vertical lines for each block - Stop
              var stopMhzAnnotation = this.Chart.Annotations.FindByName(block.SweepBlock);
              if (stopMhzAnnotation == null)
              {
                  VerticalLineAnnotation verticalLineStop = new VerticalLineAnnotation();
                  verticalLineStop.AxisX = this.Chart.ChartAreas[0].AxisX;
                  verticalLineStop.AllowMoving = false; // Set to false if you don't want it to be moveable
                  verticalLineStop.IsInfinitive = true; // This makes the line span the entire chart
                  verticalLineStop.ClipToChartArea = this.Chart.ChartAreas[0].Name;
                  verticalLineStop.LineColor = Color.Black;
                  verticalLineStop.LineWidth = 1;
                  verticalLineStop.X = stopMhz;
                  verticalLineStop.Name = block.SweepBlock;
                  this.Chart.Annotations.Add(verticalLineStop);
              }
          }
          */

            Series_Block_Average.Points.Clear();
            Series_Block_Average.Color = Series_Block_Average.Enabled ? Color.ForestGreen : Color.Transparent;

            var pointGroups = Series_Bin_Average.Points
                                .GroupBy(point => blockList.FirstOrDefault(block => point.XValue >= block.SweepStart && point.XValue < block.SweepStop))
                                .Where(group => group.Key != null) // Ensure the group has a matching block.
                                .ToList();

            foreach (var group in pointGroups)
            {
                var blockTableItem = group.Key;
                double totalWatts = group.Sum(point => dBm.DbmToWatts(point.YValues[0]));
                double compositePowerDbm = dBm.WattsToDbm(totalWatts);

                // Directly add points to Series_Block_Average.
                foreach (var point in group)
                {
                    Series_Block_Average.Points.AddXY(Math.Round(point.XValue, 2), compositePowerDbm);
                }

                // One value per block being displayed
                allBlocksDbm_NonLinearSum += compositePowerDbm;
            }

            return allBlocksDbm_NonLinearSum;
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
