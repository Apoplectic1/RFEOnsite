using System;
using System.Collections.Generic;
using System.Linq;

namespace RFEOnSite
{
    public class Decibels
    {
        public List<double> mDbmList;
        public List<double> mWattsList;
        public List<double> mDistinctDbmList;
        public Dictionary<double, int> mDistinctDbmCountDict;
        private Random mRandom;
        public double Compensation { get; set; } = 0.0;

        public Decibels()
        {
            mDbmList = new List<double>();
            mWattsList = new List<double>();
            mDistinctDbmList = new List<double>();
            mDistinctDbmCountDict = new Dictionary<double, int>();
            mRandom = new Random();
        }

        public void Clear()
        {
            mDbmList.Clear();
            mWattsList.Clear();
            mDistinctDbmList.Clear();
            mDistinctDbmCountDict.Clear();
        }

        public double ExplorerDbm(char value)
        {
            return -((double)(value >> 1));
        }

        public double ExplorerWatts(char value)
        {
            return DbmToWatts(ExplorerDbm(value));
        }

        public void AddExplorerValue(char value)
        {
            mDbmList.Add(ExplorerDbm(value));
            mWattsList.Add(ExplorerWatts(value));
        }

        public void AddExplorerSweep(string sweepDataFromRFExplorer)
        {
            for (int columnIndex = 0; columnIndex != 112; columnIndex++)
            {
                // Convert ASCII string sample data to 1. dBm and add to mDbmList and 2. Watts and add to mWattsList
                AddExplorerValue(sweepDataFromRFExplorer[columnIndex + 3]);
            }
        }

        public void AddExplorerSweepList(List<string> sweepDataFromRFExplorerList)
        {
            for (int columnIndex = 0; columnIndex != 112; columnIndex++)
            {
                // Walk down each sweepDataFromRFExplorerList Row using the same Column index
                for (int rowIndex = 0; rowIndex != sweepDataFromRFExplorerList.Count; rowIndex++)
                {
                    // Create a lists from each RF Explorer swept frequency in this column
                    // Convert ASCII string sample data to 1. dBm and add to mDbmList and 2. Watts and add to mWattsList
                    AddExplorerValue(sweepDataFromRFExplorerList[rowIndex][columnIndex + 3]);
                }
            }
        }

        public void AddDbm(double dBm)
        {
            mWattsList.Add(DbmToWatts(dBm));
            mDbmList.Add(dBm);
        }

        public void AddWatts(double watts)
        {
            mWattsList.Add(watts);
            mDbmList.Add(WattsToDbm(watts));
        }

        public void DistinctDbm()
        {
            mDistinctDbmList = mDbmList.Distinct().ToList();
            mDistinctDbmCountDict = mDbmList.GroupBy(x => x)
                                    .ToDictionary(g => g.Key, g => g.Count());
        }

        public int GetDistinctDbmCount(double dBm)
        {
            return mDistinctDbmCountDict[dBm];
        }

        public int GetDistinctDbmCountMinimum()
        {
            return mDistinctDbmCountDict.Values.Min();
        }
        public int GetDistinctDbmCountMaximum()
        {
            return mDistinctDbmCountDict.Values.Max();
        }

        public double GetDistinctDbmMinimum()
        {
            var minCountKey = mDistinctDbmCountDict.OrderBy(kvp => kvp.Value).First().Key;
            return minCountKey;
        }

        public double GetDistinctDbmMaximum()
        {
            var maxCountKey = mDistinctDbmCountDict.OrderByDescending(kvp => kvp.Value).First().Key;
            return maxCountKey;
        }

        public double GetDistinctDbmAt(int index, bool bDither = false)
        {
            if (bDither)
                return mDistinctDbmList[index] + (mRandom.NextDouble() * 1.0 - 0.5);
            else
                return mDistinctDbmList[index];
        }

        public int DistinctCount()
        {
            return mDistinctDbmList.Count;
        }

        public double GetDbmAt(int index)
        {
            return mDbmList[index];
        }

        public double MaximumDbm()
        {
            return mDbmList.Max();
        }

        public double MaximumWatts()
        {
            return mWattsList.Max();
        }

        public double AverageWatts()
        {
            return mWattsList.Average();
        }

        public double TotalPowerWatts()
        {
            return mWattsList.Sum();
        }
        public double TotalPowerDbm()
        {
            return WattsToDbm(mWattsList.Sum());
        }

        public double AveragePowerDbm()
        {
            return WattsToDbm(mWattsList.Average());
        }

        public double AverageRssi()
        {
            return mDbmList.Average();
        }

        public double AveragePowerWatts()
        {
            return mWattsList.Average();
        }

        public double DbmToWatts(double dBm)
        {
            return Math.Pow(10.0, (dBm / 10.0)) / 1000.0;
        }

        public double WattsToDbm(double watts)
        {
            return 10.0 * Math.Log10(1000.0 * watts);
        }

        public double MedianPowerDbm()
        {
            List<double> sortedNumbers = mWattsList.OrderBy(x => x).ToList();

            int middle = sortedNumbers.Count / 2;

            if (sortedNumbers.Count % 2 == 0)
            {
                // If there is an even number of elements, average the two middle mTaps.
                double median = (sortedNumbers[middle - 1] + sortedNumbers[middle]) / 2.0;
                return WattsToDbm(median);
            }
            else
            {
                // If there is an odd number of elements, return the middle value.
                return WattsToDbm(sortedNumbers[middle]);
            }
        }

        public double MedianPowerWatts()
        {
            List<double> sortedNumbers = mWattsList.OrderBy(x => x).ToList();

            int middle = sortedNumbers.Count / 2;

            if (sortedNumbers.Count % 2 == 0)
            {
                // If there is an even number of elements, average the two middle mTaps.
                double median = (sortedNumbers[middle - 1] + sortedNumbers[middle]) / 2.0;
                return median;
            }
            else
            {
                // If there is an odd number of elements, return the middle value.
                return sortedNumbers[middle];
            }
        }
    }
}
