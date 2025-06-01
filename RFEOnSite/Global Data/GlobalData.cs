using RFESnapShot.AutoSweep;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RFEOnSite
{
    public class GlobalData
    {
        public Charts Chart { get; set; }
        public CsvExport ExportCsv { get; set; }
        public Decibels Data { get; }
        public DownlinkTable PresetDownlinkTable { get; }
        public BlockTableList BlockTableList { get; }
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
        public int Sweeps { get; set; }
        public int CurrentSweepNumber { get; set; }
        public bool CalibrationActive { get; set; } = false;
        public double CalibarationSourceDbm { get; set; } = -75;
        public int CalibrationPointsPerSweepInterval { get; set; } = 3;
        public int Stable_MinimumStableSweeps { get; set; } = 300;
        public double Stable_Mad { get; set; } = 0.1;
        public StabilityChecker StableSweep { get; set; }

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
            Chart = new Charts();
            LeftAntennaGain = 5;
            Location = "Client Location";
            PresetActive = false;
            PresetDownlinkTable = new DownlinkTable();
            BlockTableList = new BlockTableList();
            PresetTableIndex = 0;
            PresetType = ePreset.eFullDownlink;
            RadialDegrees = 0;
            RadialSurvey = false;
            RightAntennaGain = 5;
            Site = "ID";
            StableSweep = new StabilityChecker();
        }
    }

    public enum eBand { e600, e700, eCEL, ePCS, eAWS, eWCS };
    public enum ePreset { eContinuous, eSingle, eFullDownlink };

    public class PresetTable
    {
        public double SweepStart { get; }
        public double SweepStop { get; }
        public eBand SweepBand { get; }
        public bool IsSweepBand(eBand band)
        {
            return (SweepBand == band);
        }
        public string SweepBlock { get; }

        // 
        public PresetTable(double start, double stop, eBand band, string block = "")
        {
            SweepStart = start;
            SweepStop = stop;
            SweepBand = band;
            SweepBlock = block;
        }
    }

    public class DownlinkTable : IEnumerable<PresetTable>
    {
        public List<PresetTable> Item;

        public void SetDownlinkTableBands(bool e600, bool e700, bool eCEL, bool ePCS, bool eAWS, bool eWCS)
        {
            Item.Clear();

            if (e600)
            {
                Item.Add(new PresetTable(612.3, 623.4, eBand.e600));
                Item.Add(new PresetTable(623.5, 634.6, eBand.e600));
                Item.Add(new PresetTable(634.7, 645.8, eBand.e600));
                Item.Add(new PresetTable(645.9, 657.0, eBand.e600));
            }

            if (e700)
            {
                Item.Add(new PresetTable(725.0, 736.1, eBand.e700));
                Item.Add(new PresetTable(736.2, 747.3, eBand.e700));
                Item.Add(new PresetTable(747.4, 758.5, eBand.e700));
                Item.Add(new PresetTable(758.6, 769.7, eBand.e700));
            }

            if (eCEL)
            {
                Item.Add(new PresetTable(855.0, 866.1, eBand.eCEL));
                Item.Add(new PresetTable(866.2, 877.3, eBand.eCEL));
                Item.Add(new PresetTable(877.4, 888.5, eBand.eCEL));
                Item.Add(new PresetTable(888.6, 899.7, eBand.eCEL));
            }

            if (ePCS)
            {
                Item.Add(new PresetTable(1929.0, 1940.1, eBand.ePCS));
                Item.Add(new PresetTable(1940.2, 1951.3, eBand.ePCS));
                Item.Add(new PresetTable(1951.4, 1962.5, eBand.ePCS));
                Item.Add(new PresetTable(1962.6, 1973.7, eBand.ePCS));
                Item.Add(new PresetTable(1973.8, 1984.9, eBand.ePCS));
                Item.Add(new PresetTable(1985.0, 1996.1, eBand.ePCS));
                Item.Add(new PresetTable(1996.2, 2007.3, eBand.ePCS));
            }

            if (eAWS)
            {
                Item.Add(new PresetTable(2105.0, 2116.1, eBand.eAWS));
                Item.Add(new PresetTable(2116.2, 2127.3, eBand.eAWS));
                Item.Add(new PresetTable(2127.4, 2138.5, eBand.eAWS));
                Item.Add(new PresetTable(2138.6, 2149.7, eBand.eAWS));
                Item.Add(new PresetTable(2149.8, 2160.9, eBand.eAWS));
                Item.Add(new PresetTable(2161.0, 2172.1, eBand.eAWS));
                Item.Add(new PresetTable(2172.2, 2183.3, eBand.eAWS));
                Item.Add(new PresetTable(2183.4, 2194.5, eBand.eAWS));
                Item.Add(new PresetTable(2194.6, 2205.7, eBand.eAWS));
            }

            if (eWCS)
            {
                Item.Add(new PresetTable(2309.9, 2321.0, eBand.eWCS));
                Item.Add(new PresetTable(2321.1, 2332.2, eBand.eWCS));
                Item.Add(new PresetTable(2332.3, 2343.4, eBand.eWCS));
                Item.Add(new PresetTable(2343.5, 2354.6, eBand.eWCS));
                Item.Add(new PresetTable(2354.7, 2365.8, eBand.eWCS));
            }
        }

        public DownlinkTable()
        {
            Item = new List<PresetTable>
            {
                new PresetTable(612.3, 623.4, eBand.e600),
                new PresetTable(623.5, 634.6, eBand.e600),
                new PresetTable(634.7, 645.8, eBand.e600),
                new PresetTable(645.9, 657.0, eBand.e600),

                new PresetTable(725.0, 736.1, eBand.e700),
                new PresetTable(736.2, 747.3, eBand.e700),
                new PresetTable(747.4, 758.5, eBand.e700),
                new PresetTable(758.6, 769.7, eBand.e700),

                new PresetTable(855.0, 866.1, eBand.eCEL),
                new PresetTable(866.2, 877.3, eBand.eCEL),
                new PresetTable(877.4, 888.5, eBand.eCEL),
                new PresetTable(888.6, 899.7, eBand.eCEL),

                new PresetTable(1929.0, 1940.1, eBand.ePCS),
                new PresetTable(1940.2, 1951.3, eBand.ePCS),
                new PresetTable(1951.4, 1962.5, eBand.ePCS),
                new PresetTable(1962.6, 1973.7, eBand.ePCS),
                new PresetTable(1973.8, 1984.9, eBand.ePCS),
                new PresetTable(1985.0, 1996.1, eBand.ePCS),
                new PresetTable(1996.2, 2007.3, eBand.ePCS),

                new PresetTable(2105.0, 2116.1, eBand.eAWS),
                new PresetTable(2116.2, 2127.3, eBand.eAWS),
                new PresetTable(2127.4, 2138.5, eBand.eAWS),
                new PresetTable(2138.6, 2149.7, eBand.eAWS),
                new PresetTable(2149.8, 2160.9, eBand.eAWS),
                new PresetTable(2161.0, 2172.1, eBand.eAWS),
                new PresetTable(2172.2, 2183.3, eBand.eAWS),
                new PresetTable(2183.4, 2194.5, eBand.eAWS),
                new PresetTable(2194.6, 2205.7, eBand.eAWS),

                new PresetTable(2309.9, 2321.0, eBand.eWCS),
                new PresetTable(2321.1, 2332.2, eBand.eWCS),
                new PresetTable(2332.3, 2343.4, eBand.eWCS),
                new PresetTable(2343.5, 2354.6, eBand.eWCS),
                new PresetTable(2354.7, 2365.8, eBand.eWCS)
            };
        }

        public IEnumerator<PresetTable> GetEnumerator()
        {
            return Item.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Item.GetEnumerator();
        }
    }

    public class BlockTableList : IEnumerable<PresetTable>
    {
        public List<PresetTable> ItemList { get; set; }

        public BlockTableList()
        {
            ItemList = new List<PresetTable>
            {
                new PresetTable(617.0, 622.0, eBand.e600, "A Block"),
                new PresetTable(622.0, 627.0, eBand.e600, "B Block"),
                new PresetTable(627.0, 632.0, eBand.e600, "C Block"),
                new PresetTable(632.0, 637.0, eBand.e600, "D Block"),
                new PresetTable(637.0, 642.0, eBand.e600, "E Block"),
                new PresetTable(642.0, 647.0, eBand.e600, "F Block"),
                new PresetTable(647.0, 652.0, eBand.e600, "G Block"),

                new PresetTable(728.0, 734.0, eBand.e700, "Lower A"),
                new PresetTable(734.0, 740.0, eBand.e700, "Lower B"),
                new PresetTable(740.0, 746.0, eBand.e700, "Lower C"),
                new PresetTable(746.0, 757.0, eBand.e700, "Upper C"),
                new PresetTable(758.0, 768.0, eBand.e700, "Upper D"),

                new PresetTable(861.0, 861.5, eBand.eCEL, "SMR A"),
                new PresetTable(861.5, 863.0, eBand.eCEL, "SMR B"),
                new PresetTable(863.0, 869.0, eBand.eCEL, "SMR X"),
                new PresetTable(869.0, 880.0, eBand.eCEL, "Lower A"),
                new PresetTable(880.0, 890.0, eBand.eCEL, "Lower B"),
                new PresetTable(890.0, 891.5, eBand.eCEL, "Upper A"),
                new PresetTable(891.5, 894.0, eBand.eCEL, "Upper B"),

                new PresetTable(1930.0, 1935.0, eBand.ePCS, "A7 Block"),
                new PresetTable(1935.0, 1940.0, eBand.ePCS, "A9 Block"),
                new PresetTable(1940.0, 1945.0, eBand.ePCS, "A11 Block"),
                new PresetTable(1945.0, 1950.0, eBand.ePCS, "D Block"),
                new PresetTable(1950.0, 1955.0, eBand.ePCS, "B7 Block"),
                new PresetTable(1955.0, 1960.0, eBand.ePCS, "B9 Block"),
                new PresetTable(1960.0, 1965.0, eBand.ePCS, "B11 Block"),
                new PresetTable(1965.0, 1970.0, eBand.ePCS, "E Block"),
                new PresetTable(1970.0, 1975.0, eBand.ePCS, "F Block"),
                new PresetTable(1975.0, 1980.0, eBand.ePCS, "C7 Block"),
                new PresetTable(1980.0, 1985.0, eBand.ePCS, "C9 Block"),
                new PresetTable(1985.0, 1990.0, eBand.ePCS, "C11 Block"),
                new PresetTable(1990.0, 1995.0, eBand.ePCS, "G Block"),

                new PresetTable(1995.0, 2000.0, eBand.eAWS, "HH Block"),
                new PresetTable(2110.0, 2115.0, eBand.eAWS, "1A5 Block"),
                new PresetTable(2115.0, 2120.0, eBand.eAWS, "1A6 Block"),
                new PresetTable(2120.0, 2125.0, eBand.eAWS, "1B5 Block"),
                new PresetTable(2125.0, 2130.0, eBand.eAWS, "1B6 Block"),
                new PresetTable(2130.0, 2135.0, eBand.eAWS, "C Block"),
                new PresetTable(2135.0, 2140.0, eBand.eAWS, "D Block"),
                new PresetTable(2140.0, 2145.0, eBand.eAWS, "E Block"),
                new PresetTable(2145.0, 2250.0, eBand.eAWS, "1F5 Block"),
                new PresetTable(2150.0, 2155.0, eBand.eAWS, "1F6 Block"),
                new PresetTable(2155.0, 2160.0, eBand.eAWS, "G Block"),
                new PresetTable(2160.0, 2165.0, eBand.eAWS, "H Block"),
                new PresetTable(2165.0, 2170.0, eBand.eAWS, "I Block"),
                new PresetTable(2170.0, 2180.0, eBand.eAWS, "J Block"),
                new PresetTable(2180.0, 2190.0, eBand.eAWS, "4A Block"),
                new PresetTable(2190.0, 2200.0, eBand.eAWS, "4B Block"),

                new PresetTable(2315.0, 2320.0, eBand.eWCS, "C Block"),
                new PresetTable(2350.0, 2355.0, eBand.eWCS, "UA Block"),
                new PresetTable(2355.0, 2360.0, eBand.eWCS, "UB Block"),
            };
        }

        public PresetTable GetBlockItem(double frequency)
        {
            return ItemList.First(item => (frequency >= item.SweepStart && frequency < item.SweepStop));
        }

        public string GetBlockName(double frequency)
        {
            return ItemList.First(item => (frequency >= item.SweepStart && frequency < item.SweepStop)).SweepBlock;
        }

        public double GetStartFrequency(string blockName)
        {
            return ItemList.First(item => (item.SweepBlock == blockName)).SweepStart;
        }

        public double GetStartFrequency(double frequency)
        {
            return ItemList.First(item => (frequency >= item.SweepStart && frequency < item.SweepStop)).SweepStart;
        }

        public double GetStopFrequency(string blockName)
        {
            return ItemList.First(item => (item.SweepBlock == blockName)).SweepStop;
        }

        public double GetStopFrequency(double frequency)
        {
            return ItemList.First(item => (frequency >= item.SweepStart && frequency < item.SweepStop)).SweepStop;
        }

        public List<PresetTable> GetBlockList(double startFrequency, double stopFrequency)
        {
            return ItemList
                            .Where(block => block.SweepStop > startFrequency && block.SweepStart < stopFrequency)
                            .OrderBy(block => block.SweepStart)
                            .ToList();
        }

        public IEnumerator<PresetTable> GetEnumerator()
        {
            return ItemList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ItemList.GetEnumerator();
        }
    }
}
