using System.Collections;
using System.Collections.Generic;

namespace RFEOnSite
{
    public class GlobalData
    {
        private Charts mChart;
        //private CsvExport mCsvExport;
        private Decibels mDecibels;
        private FileOps mFileOps;
        private List<string> mRawSweepData;
        private RFExplorer mRFE;
        private WhoopTable mWhoopDownlinkTable;
        private bool mWhoop700;
        private bool mWhoop850;
        private bool mWhoopAWS;
        private bool mWhoopPCS;
        private bool mPresetActive;
        private int mTableIndex;

        public GlobalData()
        {
            mChart = new Charts();
            //mCsvExport = new CsvExport();
            mDecibels = new Decibels();
            mFileOps = new FileOps();
            mRFE = new RFExplorer();
            mRawSweepData = new List<string>();
            mWhoop700 = true;
            mWhoop850 = true;
            mWhoopAWS = true;
            mWhoopDownlinkTable = new WhoopTable();
            mWhoopPCS = true;
            mPresetActive = false;
            mTableIndex = 0;
        }


        public Charts Graph { get { return mChart; } set { mChart = value; } }
        //public CsvExport ExportCsv { get { return mCsvExport; } set { mCsvExport = value; } }
        public Decibels Data { get { return mDecibels; } }
        public FileOps FileOps { get { return mFileOps; } set { mFileOps = value; } }
        public List<string> ExplorerSweepData { get { return mRawSweepData; } }
        public RFExplorer Explorer { get { return mRFE; } set { mRFE = value; } }
        public WhoopTable PresetTable { get { return mWhoopDownlinkTable; } }
        public bool Whoop700 { get { return mWhoop700; } set { mWhoop700 = value; } }
        public bool Whoop850 { get { return mWhoop850; } set { mWhoop850 = value; } }
        public bool WhoopAWS { get { return mWhoopAWS; } set { mWhoopAWS = value; } }
        public bool WhoopPCS { get { return mWhoopPCS; } set { mWhoopPCS = value; } }
        public bool WhoopPresetActive { get { return mPresetActive; } set { mPresetActive = value; } }
        public int PresetTableIndex { get { return mTableIndex; } set { mTableIndex = value; } }
        
    }




    public class PresetTableEntry
    {
        public double start;
        public double stop;
        

        public PresetTableEntry(double start, double stop)
        {
            this.start = start;
            this.stop = stop;
        }
    }
    public class WhoopTable : IEnumerable<PresetTableEntry>
    {
        private List<PresetTableEntry> mPairs;

        public WhoopTable()
        {
            mPairs = new List<PresetTableEntry>();
            mPairs.Add(new PresetTableEntry( 728.0,  739.2));
            mPairs.Add(new PresetTableEntry( 739.2,  750.4));
            mPairs.Add(new PresetTableEntry( 750.4,  761.6));
            mPairs.Add(new PresetTableEntry( 865.0,  876.2));
            mPairs.Add(new PresetTableEntry( 876.2,  887.4));
            mPairs.Add(new PresetTableEntry( 887.4,  898.6));
            mPairs.Add(new PresetTableEntry(1929.0, 1940.2));
            mPairs.Add(new PresetTableEntry(1940.2, 1951.4));
            mPairs.Add(new PresetTableEntry(1951.4, 1962.6));
            mPairs.Add(new PresetTableEntry(1962.6, 1973.8));
            mPairs.Add(new PresetTableEntry(1973.8, 1985.0));
            mPairs.Add(new PresetTableEntry(1985.0, 1996.2));
            mPairs.Add(new PresetTableEntry(2105.0, 2116.2));
            mPairs.Add(new PresetTableEntry(2116.2, 2127.4));
            mPairs.Add(new PresetTableEntry(2127.4, 2138.6));
            mPairs.Add(new PresetTableEntry(2138.6, 2149.8));
            mPairs.Add(new PresetTableEntry(2149.8, 2161.0));
        }

        public IEnumerator<PresetTableEntry> GetEnumerator()
        {
            return mPairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mPairs.GetEnumerator();
        }
    }
}
