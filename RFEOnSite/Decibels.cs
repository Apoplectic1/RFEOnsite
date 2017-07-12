using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public double MaxdBm()
        {
            double max = -200.0;
            for (int i = 0; i < mDbmList.Count; i++)
            {
                max = (mDbmList[i] > max) ? mDbmList[i] : max;
            }
            return max;
        }

        public double MaxWatts()
        {
            double max = -200.0;
            for (int i = 0; i < mWattsList.Count; i++)
            {
                max = (mWattsList[i] > max) ? mWattsList[i] : max;
            }
            return max;
        }

        public double AverageWatts()
        {
            double sum = 0;
            for (int i = 0; i < mWattsList.Count; i++)
            {
                sum += mWattsList[i];
            }
            return sum / mWattsList.Count;
        }

        public double AveragedBm()
        {
            double sum = 0;
            for (int i = 0; i < mWattsList.Count; i++)
            {
                sum += mWattsList[i];
            }
            return TodBm(sum / mWattsList.Count);
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

        public void TodBmList(double dBm)
        {
            double watts;

            watts = Math.Pow(10.0, (dBm / 10.0)) / 1000.0;
            mWattsList.Add(watts);
            mDbmList.Add(dBm);
        }

        public void ToWattsList(double watts)
        {
            double dBm;

            dBm = dBm = 10.0 * Math.Log10(1000.0 * watts);
            mDbmList.Add(dBm);
            mWattsList.Add(watts);
        }

        public double TodBm(double watts)
        {
            return 10.0 * Math.Log10(1000.0 * watts);
        }
        public void AddDbmList(char value)
        {
            double dBm;
            dBm = -(Convert.ToDouble(Convert.ToInt16(value)) / 2.0);
            mDbmList.Add(dBm);
            mWattsList.Add(Math.Pow(10.0, (dBm / 10.0)) / 1000.0);
        }
    }
}
