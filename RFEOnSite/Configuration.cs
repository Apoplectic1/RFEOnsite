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
            MODEL_433 = 0,  //0
            MODEL_868,      //1
            MODEL_915,      //2
            MODEL_WSUB1G,   //3
            MODEL_2400,     //4
            MODEL_WSUB3G,   //5
            MODEL_6G,       //6

            MODEL_RFGEN = 60, //60
            None = 0xFF //0xFF
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
            public string mFirmwareVersion;
            public string mSerialNumber;
            public List<double> mFreqencyList;

            public List<string> mSweepsFromExplorer;  

            public double GetExplorer_StartMHz{ get { return mfStartMHz; } }
            public double GetExplorer_StepMHz { get { return mfStepMHz; } }
            public double GetExplorer_RBWKHz { get { return mResolutionBandwidthKHz; } }

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

            public bool ParseCurrentSetup(string sLine)
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
            public bool GetConfigurationFromExplorer(string sLine)
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

            public bool BuildCsvDataFromExplorer(IProgress<CsvExport> csvExport)
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

                        dBm = -(Convert.ToDouble(Convert.ToInt32(mReceivedSweep[sweepIndex][index + 3])) / 2.0);
 
                        localCsvExport[frequency] = dBm.ToString();
                    }
                }

                csvExport.Report(localCsvExport);
                return true;
            }


            public void ReturnSweepsFromExplorer(IProgress<List<string>> sweeps)
            {
                sweeps.Report(mReceivedSweep);
            }

            public bool BuildChartSeriesFromExplorer(IProgress<Series> series)
            {
                // This is updating the GUI Spectrum MS Chart with mReceivedData (serial data) from the RF Explorer

                // The GUI spectrum chart Series element is actually what is being updated
                // mReceievedData is local to this thread read from the RF Explorer
                // series is local to the GUI
                List<double> averageDbm;
                averageDbm = new List<double>();
                averageDbm.Clear();

                double dBm, maxDbm;
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
                    maxDbm = -1000;

                    // Walk DOWN each Sweep Row using the same column index
                    for (int sweepIndex = 0; sweepIndex < mReceivedSweep.Count; sweepIndex++)
                    {
                        dBm = -(Convert.ToDouble(Convert.ToInt32(mReceivedSweep[sweepIndex][index + 3])) / 2.0);

                        averageDbm.Add(dBm);

                        maxDbm = (dBm > maxDbm) ? dBm : maxDbm;
                    }

                    localSeriesPeak.Points.AddXY(mFreqencyList[index], maxDbm);

                    localSeriesAverage.Points.AddXY(mFreqencyList[index], averageDbm.Average());
                }

                localSeriesPeak.LabelBackColor = System.Drawing.Color.White;

                dpMaxY = localSeriesPeak.Points.FindMaxByValue();
                dpMaxY.Label = dpMaxY.YValues[0].ToString() + " Peak";
                dpMaxY.Font = new System.Drawing.Font("Arial", 10f);
                dpMaxY.MarkerColor = System.Drawing.Color.MediumBlue;
                dpMaxY.MarkerSize = 5;
                dpMaxY.MarkerStyle = MarkerStyle.Circle;

                series.Report(localSeriesPeak);

                return true;
            }
        }
    }
}
