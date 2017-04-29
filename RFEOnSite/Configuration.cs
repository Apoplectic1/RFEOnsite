using System;

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
            MODE_SPECTRUM_ANALYZER = 0,
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
            public UInt16 nFreqSpectrumSteps;
            public bool bExpansionBoardActive;
            public double fAmplitudeBottomDBM;
            public double fAmplitudeTopDBM;
            public double fMaxFreqMHZ;
            public double fMaxSpanMHZ;
            public double fMinFreqMHZ;
            public double fRBWKHZ;
            public double fStartMHZ;
            public double fStepMHZ;
            public eCalculator eCalculator;
            public eMode eMode;
            public eModel mExpansionModel;
            public eModel mMainModel;
            public float fOffset_dB;
            public string mFirmwareVersion;
            public string mSerialNumber;


            public RFEConfiguration()
            {
                fStartMHZ = 0.0;
                fStepMHZ = 0.0;
                fAmplitudeTopDBM = 0.0;
                fAmplitudeBottomDBM = 0.0;
                nFreqSpectrumSteps = 0;
                bExpansionBoardActive = false;
                eMode = eMode.None;
                fMinFreqMHZ = 0.0;
                fMaxFreqMHZ = 0.0;
                fMaxSpanMHZ = 0.0;
                fRBWKHZ = 0.0;
                fOffset_dB = 0.0f;
                eCalculator = eCalculator.UNKNOWN;
                mSerialNumber = String.Empty;
                mMainModel = eModel.None;
                mExpansionModel = eModel.None;
                mFirmwareVersion = String.Empty;
            }

            public bool CopyRFEConfiguration(RFEConfiguration objSource)
            {
                if (objSource == null) return false;

                fStartMHZ = objSource.fStartMHZ;
                fStepMHZ = objSource.fStepMHZ;
                fAmplitudeTopDBM = objSource.fAmplitudeTopDBM;
                fAmplitudeBottomDBM = objSource.fAmplitudeBottomDBM;
                nFreqSpectrumSteps = objSource.nFreqSpectrumSteps;
                bExpansionBoardActive = objSource.bExpansionBoardActive;
                eMode = objSource.eMode;
                fMinFreqMHZ = objSource.fMinFreqMHZ;
                fMaxFreqMHZ = objSource.fMaxFreqMHZ;
                fMaxSpanMHZ = objSource.fMaxSpanMHZ;
                fRBWKHZ = objSource.fRBWKHZ;
                fOffset_dB = objSource.fOffset_dB;
                eCalculator = objSource.eCalculator;
                mSerialNumber = objSource.mSerialNumber;
                mMainModel = objSource.mMainModel;

                return true;
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
                mSerialNumber = sLine.Substring(3,16);

                return true;
            }
            public bool ParseDSPMode(string sLine)
            {
                return true;
            }
            public bool ParseConfigurationString(string sLine)
            {
                fStartMHZ = Convert.ToInt32(sLine.Substring(6, 7)) / 1000.0;
                fStepMHZ = Convert.ToInt32(sLine.Substring(14, 7)) / 1000000.0;
                fAmplitudeTopDBM = Convert.ToInt32(sLine.Substring(22, 4));
                fAmplitudeBottomDBM = Convert.ToInt32(sLine.Substring(27, 4));
                nFreqSpectrumSteps = Convert.ToUInt16(sLine.Substring(32, 4));
                bExpansionBoardActive = (sLine[37] == '1');
                eMode = (eMode)Convert.ToUInt16(sLine.Substring(39, 3));
                fMinFreqMHZ = Convert.ToInt32(sLine.Substring(43, 7)) / 1000.0;
                fMaxFreqMHZ = Convert.ToInt32(sLine.Substring(51, 7)) / 1000.0;
                fMaxSpanMHZ = Convert.ToInt32(sLine.Substring(59, 7)) / 1000.0;
                fRBWKHZ = Convert.ToInt32(sLine.Substring(67, 5));
                eCalculator = (eCalculator)Convert.ToUInt16(sLine.Substring(73, 3));

                return true;
            }

            public bool ParseSweepData()
            {
                double[] frequencyHeader = new double[nFreqSpectrumSteps];

                for(int step = 0; step < nFreqSpectrumSteps; step++)
                {
                    frequencyHeader[step] = fStartMHZ + (step * fStepMHZ);
                }


                //gRFE.

                
                return true;
            }

            
        }

    }
}
