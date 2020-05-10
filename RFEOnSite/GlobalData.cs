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
        public CP4Table PresetCP4DownlinkTable { get; }
        public bool ApplicationInitialized { get; set; }
        public bool CancelActive { get; set; }
        public bool CaptureImage { get; set; }
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
            CaptureImage = false;
            Client = "Client";
            CsvDirectoryValid = false;
            Data = new Decibels();
            Explorer = new RFExplorer();
            ExplorerSweepData = new List<string>();
            ExportCsv = new CsvExport();
            FileOps = new FileOps();
            Graph = new Charts();
            LeftAntennaGain = 5;
            Location = "Location";
            PresetActive = false;
            PresetDownlinkTable = new DownlinkTable();
            PresetTableIndex = 0;
            PresetType = ePreset.eSingle;
            PresetCP4DownlinkTable = new CP4Table();
            RadialDegrees = 0;
            RadialSurvey = false;
            RightAntennaGain = 5;
            Site = "ID";
        }

    }

    public enum eBand { e700, e850, ePCS, eAWS, ePublicSafety };
    public enum ePreset { eContinuous, eSingle, eCP4Downlink, eFullDownlink };


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
    public class CP4Table : IEnumerable<PresetTableEntry>
    {
        public List<PresetTableEntry> mPairs;

        public CP4Table()
        {
            mPairs = new List<PresetTableEntry>
            {
                new PresetTableEntry(728.0, 739.1, eBand.e700),
                new PresetTableEntry(739.2, 750.3, eBand.e700),
                new PresetTableEntry(750.4, 761.5, eBand.e700),
                new PresetTableEntry(865.0, 876.1, eBand.e850),
                new PresetTableEntry(876.2, 887.3, eBand.e850),
                new PresetTableEntry(887.4, 898.5, eBand.e850),
                new PresetTableEntry(1929.0, 1940.1, eBand.ePCS),
                new PresetTableEntry(1940.2, 1951.3, eBand.ePCS),
                new PresetTableEntry(1951.4, 1962.5, eBand.ePCS),
                new PresetTableEntry(1962.6, 1973.7, eBand.ePCS),
                new PresetTableEntry(1973.8, 1984.9, eBand.ePCS),
                new PresetTableEntry(1985.0, 1996.1, eBand.ePCS),
                new PresetTableEntry(2105.0, 2116.1, eBand.eAWS),
                new PresetTableEntry(2116.2, 2127.3, eBand.eAWS),
                new PresetTableEntry(2127.4, 2138.5, eBand.eAWS),
                new PresetTableEntry(2138.6, 2149.7, eBand.eAWS),
                new PresetTableEntry(2149.8, 2160.9, eBand.eAWS)
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
    public class DownlinkTable : IEnumerable<PresetTableEntry>
    {
        public List<PresetTableEntry> mPairs;

        public DownlinkTable()
        {
            mPairs = new List<PresetTableEntry>
            {
                new PresetTableEntry(714.0, 725.1, eBand.e700),
                new PresetTableEntry(725.2, 736.3, eBand.e700),
                new PresetTableEntry(736.4, 747.5, eBand.e700),
                new PresetTableEntry(747.6, 758.7, eBand.e700),
                new PresetTableEntry(758.8, 769.9, eBand.e700),

                new PresetTableEntry(850.6, 861.7, eBand.e850),
                new PresetTableEntry(865.0, 876.1, eBand.e850),
                new PresetTableEntry(876.2, 887.3, eBand.e850),
                new PresetTableEntry(887.4, 898.5, eBand.e850),

                new PresetTableEntry(1929.0, 1940.1, eBand.ePCS),
                new PresetTableEntry(1940.2, 1951.3, eBand.ePCS),
                new PresetTableEntry(1951.4, 1962.5, eBand.ePCS),
                new PresetTableEntry(1962.6, 1973.7, eBand.ePCS),
                new PresetTableEntry(1973.8, 1984.9, eBand.ePCS),
                new PresetTableEntry(1985.0, 1996.1, eBand.ePCS),


                new PresetTableEntry(2105.0, 2116.1, eBand.eAWS),
                new PresetTableEntry(2116.2, 2127.3, eBand.eAWS),
                new PresetTableEntry(2127.4, 2138.5, eBand.eAWS),
                new PresetTableEntry(2138.6, 2149.7, eBand.eAWS),
                new PresetTableEntry(2149.8, 2160.9, eBand.eAWS),
                new PresetTableEntry(2161.0, 2172.1, eBand.eAWS),
                new PresetTableEntry(2172.2, 2183.3, eBand.eAWS)
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
