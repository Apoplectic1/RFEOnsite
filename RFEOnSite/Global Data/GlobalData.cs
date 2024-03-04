using System.Collections;
using System.Collections.Generic;

namespace RFEOnSite
{
    public class GlobalData
    {
        public Charts Graph { get; set; }
        public CsvExport ExportCsv { get; set; }
        public Decibels Data { get; }
        public DownlinkTable PresetDownlinkTable { get; }
        public FileOps FileOps { get; set; }
        public List<string> ExplorerSweepData { get; }
        public RFExplorer Explorer { get; set; }
        public bool ApplicationInitialized { get; set; }
        public bool CancelActive { get; set; }
        public bool VideoCapture { get; set; }
        public bool CsvDirectoryValid { get; set; }
        public bool PresetActive { get; set; }
        public bool RadialSurvey { get; set; }
        public double FrequencyStepSize { get; set; }
        public double LeftAntennaGain { get; set; }
        public double ResolutionBandWidth { get; set; }
        public double RightAntennaGain { get; set; }
        public double StartFrequency { get; set; }
        public double StopFrequency { get; set; }
        public ePreset PresetType { get; set; } = ePreset.eContinuous;
        public int PresetTableIndex { get; set; }
        public int RadialDegrees { get; set; }
        public string Client { get; set; }
        public string Location { get; set; }
        public string Site { get; set; }
        public string SerialNumebr { get; set; } = string.Empty;

        public bool CalibrationActive { get; set; } = false;
        public double CalibarationSourceDbm { get; set; } = -75;
        public int CalibrationPointsPerSweepInterval { get; set; } = 3;


        public GlobalData()
        {
            ApplicationInitialized = false;
            CancelActive = false;
            VideoCapture = false;
            Client = "Client Name";
            CsvDirectoryValid = false;
            Data = new Decibels();
            Explorer = new RFExplorer();
            ExplorerSweepData = new List<string>();
            ExportCsv = new CsvExport();
            FileOps = new FileOps();
            Graph = new Charts();
            LeftAntennaGain = 5;
            Location = "Client Location";
            PresetActive = false;
            PresetDownlinkTable = new DownlinkTable();
            PresetTableIndex = 0;
            PresetType = ePreset.eFullDownlink;
            RadialDegrees = 0;
            RadialSurvey = false;
            RightAntennaGain = 5;
            Site = "ID";
        }

    }

    public enum eBand { e600, e700, eCEL, ePCS, eAWS, eWCS };
    public enum ePreset { eContinuous, eSingle, eFullDownlink };


    public class PresetTableEntry
    {
        public double SweepStart { get; }
        public double SweepStop { get; }
        public eBand SweepBand { get; }
        public bool IsSweepBand (eBand band)
        {
            return (SweepBand == band) ? true : false;
        }
        
        public PresetTableEntry(double start, double stop, eBand band)
        {
            SweepStart = start;
            SweepStop = stop;
            SweepBand = band;
        }
    }

   
   
    public class DownlinkTable : IEnumerable<PresetTableEntry>
    {
        public List<PresetTableEntry> mPairs;

        public void SetDownlinkTableBands(bool e600, bool e700, bool eCEL, bool ePCS, bool eAWS, bool eWCS)
        {
            mPairs.Clear();

            if (e600)
            {
                mPairs.Add(new PresetTableEntry(612.3, 623.4, eBand.e600));
                mPairs.Add(new PresetTableEntry(623.5, 634.6, eBand.e600));
                mPairs.Add(new PresetTableEntry(634.7, 645.8, eBand.e600));
                mPairs.Add(new PresetTableEntry(645.9, 657.0, eBand.e600));
            }

            if (e700)
            {
                mPairs.Add(new PresetTableEntry(725.0, 736.1, eBand.e700));
                mPairs.Add(new PresetTableEntry(736.2, 747.3, eBand.e700));
                mPairs.Add(new PresetTableEntry(747.4, 758.5, eBand.e700));
                mPairs.Add(new PresetTableEntry(758.6, 769.7, eBand.e700));
            }

            if (eCEL)
            {
                mPairs.Add(new PresetTableEntry(855.0, 866.1, eBand.eCEL));
                mPairs.Add(new PresetTableEntry(866.2, 877.3, eBand.eCEL));
                mPairs.Add(new PresetTableEntry(877.4, 888.5, eBand.eCEL));
                mPairs.Add(new PresetTableEntry(888.6, 899.7, eBand.eCEL));
            }

            if (ePCS)
            {
                mPairs.Add(new PresetTableEntry(1929.0, 1940.1, eBand.ePCS));
                mPairs.Add(new PresetTableEntry(1940.2, 1951.3, eBand.ePCS));
                mPairs.Add(new PresetTableEntry(1951.4, 1962.5, eBand.ePCS));
                mPairs.Add(new PresetTableEntry(1962.6, 1973.7, eBand.ePCS));
                mPairs.Add(new PresetTableEntry(1973.8, 1984.9, eBand.ePCS));
                mPairs.Add(new PresetTableEntry(1985.0, 1996.1, eBand.ePCS));
                mPairs.Add(new PresetTableEntry(1996.2, 2007.3, eBand.ePCS));
            }

            if (eAWS)
            {
                mPairs.Add(new PresetTableEntry(2105.0, 2116.1, eBand.eAWS));
                mPairs.Add(new PresetTableEntry(2116.2, 2127.3, eBand.eAWS));
                mPairs.Add(new PresetTableEntry(2127.4, 2138.5, eBand.eAWS));
                mPairs.Add(new PresetTableEntry(2138.6, 2149.7, eBand.eAWS));
                mPairs.Add(new PresetTableEntry(2149.8, 2160.9, eBand.eAWS));
                mPairs.Add(new PresetTableEntry(2161.0, 2172.1, eBand.eAWS));
                mPairs.Add(new PresetTableEntry(2172.2, 2183.3, eBand.eAWS));
                mPairs.Add(new PresetTableEntry(2183.4, 2194.5, eBand.eAWS));
                mPairs.Add(new PresetTableEntry(2194.6, 2205.7, eBand.eAWS));
            }

            if (eWCS)
            {
                mPairs.Add(new PresetTableEntry(2309.9, 2321.0, eBand.eWCS));
                mPairs.Add(new PresetTableEntry(2321.1, 2332.2, eBand.eWCS));
                mPairs.Add(new PresetTableEntry(2332.3, 2343.4, eBand.eWCS));
                mPairs.Add(new PresetTableEntry(2343.5, 2354.6, eBand.eWCS));
                mPairs.Add(new PresetTableEntry(2354.7, 2365.8, eBand.eWCS));
            }
        }

        public DownlinkTable()
        {
            mPairs = new List<PresetTableEntry>
            {
                new PresetTableEntry(612.3, 623.4, eBand.e600),
                new PresetTableEntry(623.5, 634.6, eBand.e600),
                new PresetTableEntry(634.7, 645.8, eBand.e600),
                new PresetTableEntry(645.9, 657.0, eBand.e600),

                new PresetTableEntry(725.0, 736.1, eBand.e700),
                new PresetTableEntry(736.2, 747.3, eBand.e700),
                new PresetTableEntry(747.4, 758.5, eBand.e700),
                new PresetTableEntry(758.6, 769.7, eBand.e700),

                new PresetTableEntry(855.0, 866.1, eBand.eCEL),
                new PresetTableEntry(866.2, 877.3, eBand.eCEL),
                new PresetTableEntry(877.4, 888.5, eBand.eCEL),
                new PresetTableEntry(888.6, 899.7, eBand.eCEL),

                new PresetTableEntry(1929.0, 1940.1, eBand.ePCS),
                new PresetTableEntry(1940.2, 1951.3, eBand.ePCS),
                new PresetTableEntry(1951.4, 1962.5, eBand.ePCS),
                new PresetTableEntry(1962.6, 1973.7, eBand.ePCS),
                new PresetTableEntry(1973.8, 1984.9, eBand.ePCS),
                new PresetTableEntry(1985.0, 1996.1, eBand.ePCS),
                new PresetTableEntry(1996.2, 2007.3, eBand.ePCS),

                new PresetTableEntry(2105.0, 2116.1, eBand.eAWS),
                new PresetTableEntry(2116.2, 2127.3, eBand.eAWS),
                new PresetTableEntry(2127.4, 2138.5, eBand.eAWS),
                new PresetTableEntry(2138.6, 2149.7, eBand.eAWS),
                new PresetTableEntry(2149.8, 2160.9, eBand.eAWS),
                new PresetTableEntry(2161.0, 2172.1, eBand.eAWS),
                new PresetTableEntry(2172.2, 2183.3, eBand.eAWS),
                new PresetTableEntry(2183.4, 2194.5, eBand.eAWS),
                new PresetTableEntry(2194.6, 2205.7, eBand.eAWS),

                new PresetTableEntry(2309.9, 2321.0, eBand.eWCS),
                new PresetTableEntry(2321.1, 2332.2, eBand.eWCS),
                new PresetTableEntry(2332.3, 2343.4, eBand.eWCS),
                new PresetTableEntry(2343.5, 2354.6, eBand.eWCS),
                new PresetTableEntry(2354.7, 2365.8, eBand.eWCS)
            };
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
