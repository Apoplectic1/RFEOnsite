using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace RFEOnSite
{
    public class FileOps
    {
        private CsvExport mCsvExport;
        private Decibels mDbm;
        private FolderBrowserDialog mFolderDialog;
        private double mStartMHz;
        private double mStepMHz;
        private double mStopMHz;
        private int mSweepCount;
        private string mFileName;

        public CsvExport ExportCsv { get { return mCsvExport; } set { mCsvExport = value; } }
        public Decibels SweepDdm { get { return mDbm; } set { mDbm = value; } }
        public FolderBrowserDialog FolderDialog { get { return mFolderDialog; } set { mFolderDialog = value; } }
        public double StartMHz { get { return mStartMHz; } set { mStartMHz = value; } }
        public double StepMHz { get { return mStepMHz; } set { mStepMHz = value; } }
        public double StopMHz { get { return mStopMHz; } set { mStopMHz = value; } }
        public int SweepCount { get { return mSweepCount; } set { mSweepCount = value; } }
        public string Path { get { return mFileName; } set { mFileName = value; } }
        


        public FileOps()
        {
            mFolderDialog = new FolderBrowserDialog();
            mFileName = string.Empty;
        }



        public bool ExportCsvFile(double start, double stop, List<string> data)
        {
            mCsvExport = new CsvExport();

            string frequency;
            List<double> frequencyList = new List<double>();

            frequencyList.Clear();
            double stepMHz = (stop - start) / 112.0;
            double freq = start;
            for (int step = 0; step < 112; step++)
            {
                frequencyList.Add(freq);
                freq += stepMHz;
            }

            for (int sweepIndex = 0; sweepIndex < data.Count; sweepIndex++)
            {
                mCsvExport.AddRow();
                string row = data[sweepIndex];

                for (int index = 0; index != 112; index++)
                {
                    frequency = frequencyList[index].ToString("F1");
                    Int32 dBm = Convert.ToInt16(row[index + 3]);

                    mCsvExport[frequency] = (-(Convert.ToDouble(dBm) / 2.0)).ToString("F1");
                }
            }

            mCsvExport.ExportToFile(mFileName);

            mCsvExport = null;

            return true;
        }
    }
}
