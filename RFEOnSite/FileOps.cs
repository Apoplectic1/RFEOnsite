using System.Collections.Generic;
using System.Windows.Forms;


namespace RFEOnSite
{
    public class FileOps
    {
        private FolderBrowserDialog mFolderDialog;
        private string mFileName;
        private double mStartMHz;
        private double mStopMHz;
        private double mStepMHz;
        private int mSweepCount;
        private CsvExport mCsvExport;
        private Decibels mDbm;

        public double StartMHz { get { return mStartMHz; } set { mStartMHz = value; } }
        public double StopMHz { get { return mStopMHz; } set { mStopMHz = value; } }
        public double StepMHz { get { return mStepMHz; } set { mStepMHz = value; } }
        public int SweepCount { get { return mSweepCount; } set { mSweepCount = value; } }
        public FolderBrowserDialog FolderDialog { get { return mFolderDialog; } set { mFolderDialog = value; } }
        public string Path { get { return mFileName; } set { mFileName = value; } }
        public CsvExport ExportCsv { get { return mCsvExport; } set { mCsvExport = value; } }
        public Decibels SweepDdm { get { return mDbm; } set { mDbm = value; } }


        public FileOps()
        {
            mFolderDialog = new FolderBrowserDialog();
        }

    }
}
