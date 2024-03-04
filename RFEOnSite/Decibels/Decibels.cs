using System;
using System.Collections.Generic;
using System.Linq;

namespace RFEOnSite
{
    public class Decibels
    {
        private List<double> mDbmList;
        private List<double> mWattsList;
        

        public Decibels()
        {
            mDbmList = new List<double>();
            mWattsList = new List<double>();
        }

        public void Clear()
        {
            mDbmList.Clear();
            mWattsList.Clear();
        }

        public double GetDbmAt(int index)
        {
            return mDbmList[index];
        }

        public double MaxdBmList()
        {
            double max = mDbmList.Max();
            return max;
        }

        public double MaxWattsList()
        {
            double max = mWattsList.Max();
            return max;
        }

        public double AverageWattsList()
        {
            double sum = mWattsList.Sum();
            return sum / mWattsList.Count;
        }

        public double AveragedBmList()
        {
            double sum = mWattsList.Sum();
            return ConvertTodBm(sum / mWattsList.Count);
        }
        public double ConvertToWatts(double dBm)
        {
            double watts;
            watts = Math.Pow(10.0, (dBm / 10.0)) / 1000.0;
            return watts;
        }

        public double ConvertToDbm(double watts)
        {
            double dBm;
            dBm = 10.0 * Math.Log10(1000.0 * watts);
            return watts;
        }

        public void DbmToList(double dBm)
        {
            double watts;

            watts = Math.Pow(10.0, (dBm / 10.0)) / 1000.0;
            mWattsList.Add(watts);
            mDbmList.Add(dBm);
        }

        public void WattsToList(double watts)
        {
            double dBm;

            dBm = dBm = 10.0 * Math.Log10(1000.0 * watts);
            mDbmList.Add(dBm);
            mWattsList.Add(watts);
        }

        public double ConvertTodBm(double watts)
        {
            return 10.0 * Math.Log10(1000.0 * watts);
        }
        public void ExplorerDbmToLists(char value)
        {
            double dBm;
            dBm = -(Convert.ToDouble(Convert.ToInt16(value)) / 2.0);
            mDbmList.Add(dBm);
            mWattsList.Add(Math.Pow(10.0, (dBm / 10.0)) / 1000.0);
        }
    }
}
