using RFEOnsite;
using System.Collections.Generic;

namespace RFEOnSite
{
    class GlobalData
    {
        private Charts mChart;
        private CsvExport mCsvExport;
        private RFExplorer mRFE;

        private bool mWhoop700;
        private bool mWhoop850;
        private bool mWhoopPCS;
        private bool mWhoopAWS;
        private bool mWhoopPresetActive;

        public GlobalData()
        {
            mChart = new Charts();
            mCsvExport = new CsvExport();
            mRFE = new RFExplorer();

            mWhoopPresetActive = false;
            mWhoop700 = true;
            mWhoop850 = true;
            mWhoopPCS = true;
            mWhoopAWS = true;
        }

        public Charts Graph { get { return mChart; } set { mChart = value; } }
        public CsvExport CsvFiles { get { return mCsvExport; } set { mCsvExport = value; } } 
        public RFExplorer Explorer { get { return mRFE; } set { mRFE = value; } }
        public bool WhoopPresetActive { get { return mWhoopPresetActive; } set { mWhoopPresetActive = value; } }
        public bool Whoop700 { get { return mWhoop700; } set { mWhoop700 = value; } }
        public bool Whoop850 { get { return mWhoop850; } set { mWhoop850 = value; } }
        public bool WhoopPCS { get { return mWhoopPCS; } set { mWhoopPCS = value; } }
        public bool WhoopAWS { get { return mWhoopAWS; } set { mWhoopAWS = value; } }
    }



    public class WhoopTable
    {
        public double start;
        public double stop;

        public static List<WhoopTable> GetData()
        {
            var list = new List<WhoopTable>()
            {
            new WhoopTable() { start =  728.0, stop =  739.2 },
            new WhoopTable() { start =  739.2, stop =  750.4 },
            new WhoopTable() { start =  750.4, stop =  761.6 },

            new WhoopTable() { start =  865.0, stop =  876.2 },
            new WhoopTable() { start =  876.2, stop =  887.4 },
            new WhoopTable() { start =  887.4, stop =  898.6 },

            new WhoopTable() { start = 1929.0, stop = 1940.2 },
            new WhoopTable() { start = 1940.2, stop = 1951.4 },
            new WhoopTable() { start = 1951.4, stop = 1962.6 },
            new WhoopTable() { start = 1962.6, stop = 1973.8 },
            new WhoopTable() { start = 1973.8, stop = 1985.0 },
            new WhoopTable() { start = 1985.0, stop = 1996.2 },

            new WhoopTable() { start = 2105.0, stop = 2116.2 },
            new WhoopTable() { start = 2116.2, stop = 2127.4 },
            new WhoopTable() { start = 2127.4, stop = 2138.6 },
            new WhoopTable() { start = 2138.6, stop = 2149.8 },
            new WhoopTable() { start = 2149.8, stop = 2161.0 }
            };

            return list;
        }
    }
}
