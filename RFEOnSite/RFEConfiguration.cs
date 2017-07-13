using RFEOnSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFEOnsite
{
    public partial class RFExplorer
    {
        public enum eSignalType
        {
            Realtime,
            Average,
            MaxPeak,
            Min,
            MaxHold,
            TOTAL_ITEMS
        };
        public enum eDSP
        {
            DSP_AUTO = 0,
            DSP_FILTER,
            DSP_FAST,
            DSP_NO_IMG
        };
        public enum eCalculator
        {
            NORMAL = 0,
            MAX,
            AVG,
            OVERWRITE,
            MAX_HOLD,
            MAX_HISTORICAL,
            UNKNOWN = 0xff
        }
        public enum eMode
        {
            MODE_ANALYZER = 0,
            MODE_TRANSMITTER = 1,
            MODE_WIFI_ANALYZER = 2,
            MODE_TRACKING = 5,
            MODE_SNIFFER = 6,
            MODE_GEN_CW = 60,
            MODE_GEN_SWEEP_FREQ = 61,
            MODE_GEN_SWEEP_AMP = 62,
            None = 0xFF
        };
        public enum eModel
        {
            MODEL_433 = 0,
            MODEL_868 = 1,          
            MODEL_915 = 2,          
            MODEL_WSUB1G = 3,       
            MODEL_2400 = 4,         
            MODEL_WSUB3G = 5,       
            MODEL_6G = 6,           
            MODEL_RFGEN = 60,   
            None = 0xFF         
        };
        

        public class RFEConfiguration
        {
            public UInt16 mFreqSpectrumSteps;
            public bool bExpansionBoardActive;
            public double mAmplitudeBottomDdm;
            public double mAmplitudeTopDbm;
            public double mfMaxFreqMHz;
            public double mfMaxSpanMHz;
            public double mfMinFreqMHz;
            private double mResolutionBandwidthKHz;
            private double mfStartMHz;
            private double mfStepMHz;
            public eCalculator eCalculator;
            public eMode eMode;
            public eModel mExpansionModel;
            public eModel mMainModel;
            public float fOffset_dB;
            private string mFirmwareVersion;
            public string mSerialNumber;
            public List<double> mFreqencyList;

            public List<string> mSweepsFromExplorer;  

            public double StartMHz{ get { return mfStartMHz; } }
            public double StepMHz { get { return mfStepMHz; } }
            public double RBWKHz { get { return mResolutionBandwidthKHz; } }
            public string FirmwareVersion { get { return mFirmwareVersion; } set { mFirmwareVersion = value; } }

            public RFEConfiguration()
            {
                mfStartMHz = 0.0;
                mfStepMHz = 0.0;
                mAmplitudeTopDbm = 0.0;
                mAmplitudeBottomDdm = 0.0;
                mFreqSpectrumSteps = 0;
                bExpansionBoardActive = false;
                eMode = eMode.None;
                mfMinFreqMHz = 0.0;
                mfMaxFreqMHz = 0.0;
                mfMaxSpanMHz = 0.0;
                mResolutionBandwidthKHz = 0.0;
                fOffset_dB = 0.0f;
                eCalculator = eCalculator.UNKNOWN;
                mSerialNumber = String.Empty;
                mMainModel = eModel.None;
                mExpansionModel = eModel.None;
                mFirmwareVersion = String.Empty;
                mFreqencyList = new List<double>();
                mSweepsFromExplorer = new List<string>();
            }

            public bool ParseModelAndVersion(string sLine)
            {
                mMainModel = (eModel)Convert.ToUInt16(sLine.Substring(6, 3));
                mExpansionModel = (eModel)Convert.ToUInt16(sLine.Substring(10, 3));
                mFirmwareVersion = sLine.Substring(14, 5);

                return true;
            }
            public bool ParseSerialNumber(string sLine)
            {
                mSerialNumber = sLine.Substring(3, 16);

                return true;
            }
            public bool ParseDSPMode(string sLine)
            {
                return true;
            }
            public bool ParseConfiguration(string sLine)
            {
                
                mfStartMHz = Convert.ToInt32(sLine.Substring(6, 7)) / 1000.0;
                mfStepMHz = Convert.ToInt32(sLine.Substring(14, 7)) / 1000000.0;
                mAmplitudeTopDbm = Convert.ToInt32(sLine.Substring(22, 4));
                mAmplitudeBottomDdm = Convert.ToInt32(sLine.Substring(27, 4));
                mFreqSpectrumSteps = Convert.ToUInt16(sLine.Substring(32, 4));
                bExpansionBoardActive = (sLine[37] == '1');
                eMode = (eMode)Convert.ToUInt16(sLine.Substring(39, 3));
                mfMinFreqMHz = Convert.ToInt32(sLine.Substring(43, 7)) / 1000.0;
                mfMaxFreqMHz = Convert.ToInt32(sLine.Substring(51, 7)) / 1000.0;
                mfMaxSpanMHz = Convert.ToInt32(sLine.Substring(59, 7)) / 1000.0;
                mResolutionBandwidthKHz = Convert.ToInt32(sLine.Substring(67, 5));
                eCalculator = (eCalculator)Convert.ToUInt16(sLine.Substring(73, 3));

                return true;
            }

            public bool ParseCsvDataFromExplorer(IProgress<CsvExport> csvExportProgress)
            {
                CsvExport localCsvExport = new CsvExport();
                double dBm;
                string frequency;

                mFreqencyList.Clear();

                for (int step = 0; step < mFreqSpectrumSteps; step++)
                {
                    mFreqencyList.Add(mfStartMHz + (step * mfStepMHz));
                }

                for (int sweepIndex = 0; sweepIndex < mReceivedSweep.Count; sweepIndex++)
                {
                    localCsvExport.AddRow();

                    for (int index = 0; index != 112; index++)
                    {
                        frequency = mFreqencyList[index].ToString();

                        dBm = -(Convert.ToDouble(Convert.ToUInt32(mReceivedSweep[sweepIndex][index + 3]) >> 1));
 
                        localCsvExport[frequency] = dBm.ToString();
                    }
                }

                csvExportProgress.Report(localCsvExport);
                return true;
            }


            public void ReturnSweepsFromExplorer(IProgress<List<string>> sweepsProgress)
            {
                
                sweepsProgress.Report(mReceivedSweep);
            }

            public bool ParseChartSeriesFromExplorer(IProgress<Series> seriesProgress)
            {
                // This is updating the GUI Spectrum MS Chart with mReceivedData (serial data) from the RF Explorer

                // The GUI spectrum chart Series element is actually what is being updated
                // mReceievedData is local to this thread read from the RF Explorer
                // series is local to the GUI

                Decibels dBm = new Decibels();
                DataPoint dpMaxY;

                mFreqencyList.Clear();
                for (int step = 0; step < mFreqSpectrumSteps; step++)
                {
                    mFreqencyList.Add(mfStartMHz + (step * mfStepMHz));
                }
                
                Series localSeriesPeak = new Series();
                Series localSeriesAverage = new Series();

                localSeriesPeak.ChartType = SeriesChartType.Spline;
                localSeriesAverage.ChartType = SeriesChartType.Spline;

                // Walk across each Sweep Column
                for (int index = 0; index != 112; index++)
                {
                    // Walk DOWN each Sweep Row using the same column index
                    for (int sweepIndex = 0; sweepIndex < mReceivedSweep.Count; sweepIndex++)
                    {
                        dBm.AddDbmList(mReceivedSweep[sweepIndex][index + 3]);
                    }

                    localSeriesPeak.Points.AddXY(mFreqencyList[index], dBm.MaxdBm());
                    //localSeriesAverage.Points.AddXY(mFreqencyList[index], dBm.AveragedBm());

                    dBm.Clear();
                }

                localSeriesPeak.LabelBackColor = System.Drawing.Color.White;

                dpMaxY = localSeriesPeak.Points.FindMaxByValue();
                dpMaxY.Label = dpMaxY.YValues[0].ToString() + " Peak";
                dpMaxY.Font = new System.Drawing.Font("Arial", 10f);
                dpMaxY.MarkerColor = System.Drawing.Color.MediumBlue;
                dpMaxY.MarkerSize = 5;
                dpMaxY.MarkerStyle = MarkerStyle.Circle;

                
                seriesProgress.Report(localSeriesPeak);
                //series.Report(localSeriesAverage);

                return true;
            }
        }
    }
}
