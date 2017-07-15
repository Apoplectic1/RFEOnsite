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
        }

    }
}
