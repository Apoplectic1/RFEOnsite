using System;
using System.Collections.Generic;

namespace RFEOnSite
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
            MODEL_6G_PLUS = 10,
            MODEL_RFGEN = 60,   
            None = 0xFF         
        };

        public enum eConfigState { eInvalid, eUiValid, eUIUpdate, eExplorerUpdate, eExplorerValid };

        public class RFEConfiguration
        {
            public UInt16 mFreqSpectrumSteps;
            public bool bExpansionBoardActive;
            public double mAmplitudeBottomDdm;
            public double mAmplitudeTopDbm;
            public double mfMaxFreqMHz;
            public double mfMaxSpanMHz;
            public double mfMinFreqMHz;
            public eCalculator eCalculator;
            public eMode eMode;
            public eModel mExpansionModel;
            public eModel mMainModel;
            public eConfigState mConfigurationState;
            public float fOffset_dB;
            public string mSerialNumber;
            public List<double> mFreqencyList;
            public List<string> mSweepsFromExplorer;

            public double StartMHz { get; private set; }
            public double StepMHz { get; private set; }
            public double RBWKHz { get; private set; }
            public string FirmwareVersion { get; set; }

            public RFEConfiguration()
            {
                StartMHz = 0.0;
                StepMHz = 0.0;
                mAmplitudeTopDbm = 0.0;
                mAmplitudeBottomDdm = 0.0;
                mFreqSpectrumSteps = 0;
                bExpansionBoardActive = false;
                eMode = eMode.None;
                mfMinFreqMHz = 0.0;
                mfMaxFreqMHz = 0.0;
                mfMaxSpanMHz = 0.0;
                RBWKHz = 0.0;
                fOffset_dB = 0.0f;
                eCalculator = eCalculator.UNKNOWN;
                mSerialNumber = String.Empty;
                mMainModel = eModel.None;
                mExpansionModel = eModel.None;
                FirmwareVersion = String.Empty;
                mFreqencyList = new List<double>();
                mSweepsFromExplorer = new List<string>();
                mConfigurationState = eConfigState.eInvalid;
            }

            public bool ParseModelAndVersion(string sLine)
            {
                mMainModel = (eModel)Convert.ToUInt16(sLine.Substring(6, 3));
                mExpansionModel = (eModel)Convert.ToUInt16(sLine.Substring(10, 3));
                FirmwareVersion = sLine.Substring(14, 5);
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
                StartMHz = Convert.ToInt32(sLine.Substring(6, 7)) / 1000.0;
                StepMHz = Convert.ToInt32(sLine.Substring(14, 7)) / 1000000.0;
                mAmplitudeTopDbm = Convert.ToInt32(sLine.Substring(22, 4));
                mAmplitudeBottomDdm = Convert.ToInt32(sLine.Substring(27, 4));
                mFreqSpectrumSteps = Convert.ToUInt16(sLine.Substring(32, 4));
                bExpansionBoardActive = (sLine[37] == '1');
                eMode = (eMode)Convert.ToUInt16(sLine.Substring(39, 3));
                mfMinFreqMHz = Convert.ToInt32(sLine.Substring(43, 7)) / 1000.0;
                mfMaxFreqMHz = Convert.ToInt32(sLine.Substring(51, 7)) / 1000.0;
                mfMaxSpanMHz = Convert.ToInt32(sLine.Substring(59, 7)) / 1000.0;
                RBWKHz = Convert.ToInt32(sLine.Substring(67, 5));
                eCalculator = (eCalculator)Convert.ToUInt16(sLine.Substring(73, 3));
                mConfigurationState = eConfigState.eExplorerValid;
                return true;
            }
        }
    }
}
