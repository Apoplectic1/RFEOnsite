using System.Collections;
using System.Collections.Generic;

namespace RFEOnSite
{
    public class GlobalData
    {
        private Charts mChart;
        private CsvExport mCsvExport;
        private Decibels mDecibels;
        private FileOps mFileOps;
        private List<string> mRawSweepData;
        private RFExplorer mRFE;
        private WhoopTable mWhoopDownlinkTable;
        private DownlinkTable mDownlinkTable;
        private bool mPresetActive;
        private ePreset mPresetType;
        private bool mRadialSurvey;
        private bool mSweep700;
        private bool mSweep850;
        private bool mSweepAWS;
        private bool mSweepPCS;
        private double mLeftAntennaGain;
        private double mRightAntennaGain;
        private int mRadialDegrees;
        private int mTableIndex;
        private string mClient;
        private string mCollectionLocation;
        private string mCollectionSite;

        private double mStartMHz;
        private double mStopMHz;
        private double mResolutionBandwidth;
        private double mStepSize;

        private bool mCancelActive; // global to stop and reset sweeps
        private bool mCaptureImage;
        private bool mCsvDirectoryValid;

        private bool mApplicationInitialized;


        public double StartFrequency { get { return mStartMHz; } set { mStartMHz = value; } }
        public double StopFrequency { get { return mStopMHz; } set { mStopMHz = value; } }
        public double ResolutionBandWidth { get { return mResolutionBandwidth; } set { mResolutionBandwidth = value; } }
        public double FrequencyStepSize { get { return mStepSize; } set { mStepSize = value; } }




        public GlobalData()
        {
            mChart = new Charts();
            mClient = "Client";
            mCollectionLocation = "Location";
            mCollectionSite = "ID";
            mCsvExport = new CsvExport();
            mDecibels = new Decibels();
            mFileOps = new FileOps();
            mLeftAntennaGain = 5;
            mPresetActive = false;
            mRFE = new RFExplorer();
            mRadialDegrees = 0;
            mRadialSurvey = false;
            mRawSweepData = new List<string>();
            mRightAntennaGain = 5;
            mTableIndex = 0;
            mSweep700 = true;
            mSweep850 = true;
            mSweepAWS = true;
            mWhoopDownlinkTable = new WhoopTable();
            mDownlinkTable = new DownlinkTable();
            mSweepPCS = true;
            mPresetType = ePreset.eManual;
            mCancelActive = false;
            mCsvDirectoryValid = false;
            mCaptureImage = false;
            mApplicationInitialized = false;
        }

        public bool ApplicationInitialized { get { return mApplicationInitialized; } set { mApplicationInitialized = value; } }
        public Charts Graph { get { return mChart; } set { mChart = value; } }
        public CsvExport ExportCsv { get { return mCsvExport; } set { mCsvExport = value; } }
        public Decibels Data { get { return mDecibels; } }
        public FileOps FileOps { get { return mFileOps; } set { mFileOps = value; } }
        public List<string> ExplorerSweepData { get { return mRawSweepData; } }
        public RFExplorer Explorer { get { return mRFE; } set { mRFE = value; } }
        public WhoopTable PresetWhoopDownlinkTable { get { return mWhoopDownlinkTable; } }
        public DownlinkTable PresetDownlinkTable { get { return mDownlinkTable; } }
        public bool Sweep700 { get { return mSweep700; } set { mSweep700 = value; } }
        public bool Sweep850 { get { return mSweep850; } set { mSweep850 = value; } }
        public bool SweepAWS { get { return mSweepAWS; } set { mSweepAWS = value; } }
        public bool SweepPCS { get { return mSweepPCS; } set { mSweepPCS = value; } }
        public bool PresetActive { get { return mPresetActive; } set { mPresetActive = value; } }
        public int PresetTableIndex { get { return mTableIndex; } set { mTableIndex = value; } }
        public ePreset PresetType { get { return mPresetType; } set { mPresetType = value; } }
        public bool RadialSurvey { get { return mRadialSurvey; } set { mRadialSurvey = value; } }
        public int RadialDegrees { get { return mRadialDegrees; } set { mRadialDegrees = value; } }
        public double RightAntennaGain { get { return mRightAntennaGain; } set { mRightAntennaGain = value; } }
        public double LeftAntennaGain { get { return mLeftAntennaGain; } set { mLeftAntennaGain = value; } }
        public string Client { get { return mClient; } set { mClient = value; } }
        public string Location { get { return mCollectionLocation; } set { mCollectionLocation = value; } }
        public string Site { get { return mCollectionSite; } set { mCollectionSite = value; } }
        public bool CancelActive { get { return mCancelActive; } set { mCancelActive = value; } }
        public bool CsvDirectoryValid { get { return mCsvDirectoryValid; } set { mCsvDirectoryValid = value; } }
        public bool CaptureImage { get { return mCaptureImage; } set { mCaptureImage = value; } }
    }

    public enum eBand { e700, e850, ePCS, eAWS, ePublicSafety };
    public enum ePreset { eManual, eWhoopDownlink, eFullDownlink };


    public class PresetTableEntry
    {
        private double mStart;
        private double mStop;
        private eBand mBand;

        public double SweepStart { get { return mStart; } }
        public double SweepStop { get { return mStop; } }
        public eBand SweepBand { get { return mBand; } }
        public bool IsSweepBand (eBand band)
        {
            return (mBand == band) ? true : false;
        }
        
        public PresetTableEntry(double start, double stop, eBand band)
        {
            this.mStart = start;
            this.mStop = stop;
            this.mBand = band;
        }
    }
    public class WhoopTable : IEnumerable<PresetTableEntry>
    {
        public List<PresetTableEntry> mPairs;

        public WhoopTable()
        {
            mPairs = new List<PresetTableEntry>();

            //mPairs.Add(new PresetTableEntry(728.0, 739.2, eBand.e700));
            //mPairs.Add(new PresetTableEntry(739.2, 750.4, eBand.e700));
            //mPairs.Add(new PresetTableEntry(750.4, 761.6, eBand.e700));
            //mPairs.Add(new PresetTableEntry(865.0, 876.2, eBand.e850));
            //mPairs.Add(new PresetTableEntry(876.2, 887.4, eBand.e850));
            //mPairs.Add(new PresetTableEntry(887.4, 898.6, eBand.e850));
            //mPairs.Add(new PresetTableEntry(1929.0, 1940.2, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1940.2, 1951.4, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1951.4, 1962.6, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1962.6, 1973.8, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1973.8, 1985.0, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1985.0, 1996.2, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(2105.0, 2116.2, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2116.2, 2127.4, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2127.4, 2138.6, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2138.6, 2149.8, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2149.8, 2161.0, eBand.eAWS));

            mPairs.Add(new PresetTableEntry(728.0, 739.1, eBand.e700));
            mPairs.Add(new PresetTableEntry(739.1, 750.2, eBand.e700));
            mPairs.Add(new PresetTableEntry(750.2, 761.3, eBand.e700));
            mPairs.Add(new PresetTableEntry(865.0, 876.1, eBand.e850));
            mPairs.Add(new PresetTableEntry(876.1, 887.2, eBand.e850));
            mPairs.Add(new PresetTableEntry(887.2, 898.3, eBand.e850));
            mPairs.Add(new PresetTableEntry(1929.0, 1940.1, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1940.1, 1951.2, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1951.2, 1962.3, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1962.3, 1973.4, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1973.4, 1984.5, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1984.5, 1995.6, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(2105.0, 2116.1, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2116.1, 2127.2, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2127.2, 2138.3, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2138.3, 2149.4, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2149.4, 2160.5, eBand.eAWS));
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
    public class DownlinkTable : IEnumerable<PresetTableEntry>
    {
        public List<PresetTableEntry> mPairs;

        public DownlinkTable()
        {
            mPairs = new List<PresetTableEntry>();

            //mPairs.Add(new PresetTableEntry(714.0, 725.2, eBand.e700));
            //mPairs.Add(new PresetTableEntry(725.2, 736.4, eBand.e700));
            //mPairs.Add(new PresetTableEntry(736.4, 747.6, eBand.e700));
            //mPairs.Add(new PresetTableEntry(747.6, 758.8, eBand.e700));
            //mPairs.Add(new PresetTableEntry(758.8, 770.0, eBand.e700));

            //mPairs.Add(new PresetTableEntry(865.0, 876.2, eBand.e850));
            //mPairs.Add(new PresetTableEntry(876.2, 887.4, eBand.e850));
            //mPairs.Add(new PresetTableEntry(887.4, 898.6, eBand.e850));

            //mPairs.Add(new PresetTableEntry(1929.0, 1940.2, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1940.2, 1951.4, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1951.4, 1962.6, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1962.6, 1973.8, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1973.8, 1985.0, eBand.ePCS));
            //mPairs.Add(new PresetTableEntry(1985.0, 1996.2, eBand.ePCS));


            //mPairs.Add(new PresetTableEntry(2105.0, 2116.2, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2116.2, 2127.4, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2127.4, 2138.6, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2138.6, 2149.8, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2149.8, 2161.0, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2161.0, 2172.2, eBand.eAWS));
            //mPairs.Add(new PresetTableEntry(2172.2, 2183.4, eBand.eAWS));

            mPairs.Add(new PresetTableEntry(714.0, 725.1, eBand.e700));
            mPairs.Add(new PresetTableEntry(725.1, 736.2, eBand.e700));
            mPairs.Add(new PresetTableEntry(736.2, 747.3, eBand.e700));
            mPairs.Add(new PresetTableEntry(747.3, 758.4, eBand.e700));
            mPairs.Add(new PresetTableEntry(758.4, 769.5, eBand.e700));

            mPairs.Add(new PresetTableEntry(865.0, 876.1, eBand.e850));
            mPairs.Add(new PresetTableEntry(876.1, 887.2, eBand.e850));
            mPairs.Add(new PresetTableEntry(887.2, 898.3, eBand.e850));

            mPairs.Add(new PresetTableEntry(1929.0, 1940.1, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1940.1, 1951.2, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1951.2, 1962.3, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1962.3, 1973.4, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1973.4, 1984.5, eBand.ePCS));
            mPairs.Add(new PresetTableEntry(1984.5, 1995.6, eBand.ePCS));


            mPairs.Add(new PresetTableEntry(2105.0, 2116.1, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2116.1, 2127.2, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2127.2, 2138.3, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2138.3, 2149.4, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2149.4, 2160.5, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2160.5, 2171.6, eBand.eAWS));
            mPairs.Add(new PresetTableEntry(2171.6, 2182.7, eBand.eAWS));
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
