
using RFEOnSite;
using System;

namespace RFExplorerCommunicator
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
            MODE_NONE = 0xFF
        };
        public enum eModulation
        {
            MODULATION_OOK_RAW,         //0
            MODULATION_PSK_RAW,         //1
            MODULATION_OOK_STD,         //2
            MODULATION_PSK_STD,         //3
            MODULATION_NONE = 0xFF  //0xFF
        };

        public const UInt32 FCY_CLOCK = 16 * 1000 * 1000;

        public class RFEConfiguration
        {
            public double fStartMHZ; //it is also used as RefFrequency for sniffer and other modes
            public double fStepMHZ;
            public double fAmplitudeTopDBM;
            public double fAmplitudeBottomDBM;
            public UInt16 nFreqSpectrumSteps;
            public bool bExpansionBoardActive;
            public eMode eMode;
            public eModulation eModulation;
            public double fMinFreqMHZ;
            public double fMaxFreqMHZ;
            public double fMaxSpanMHZ;
            public double fRBWKHZ;
            public float fOffset_dB;
            public string sLineString;
            public eCalculator eCalculator;
            public UInt32 nBaudrate;
            public float fThresholdDBM;
 
            public RFEConfiguration()
            {
                fStartMHZ = 0.0;
                fStepMHZ = 0.0;
                fAmplitudeTopDBM = 0.0;
                fAmplitudeBottomDBM = 0.0;
                nFreqSpectrumSteps = 0;
                bExpansionBoardActive = false;
                eMode = eMode.MODE_NONE;
                fMinFreqMHZ = 0.0;
                fMaxFreqMHZ = 0.0;
                fMaxSpanMHZ = 0.0;
                fRBWKHZ = 0.0;
                fOffset_dB = 0.0f;
                nBaudrate = 0;
                eModulation = eModulation.MODULATION_NONE;
                fThresholdDBM = 0.0f;
                eCalculator = eCalculator.UNKNOWN;
            }

            public RFEConfiguration(RFEConfiguration objSource)
            {
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
                nBaudrate = objSource.nBaudrate;
                eModulation = objSource.eModulation;
                fThresholdDBM = objSource.fThresholdDBM;
            }

            public bool ProcessReceivedString(string sLine)
            {
                
            bool bOk = true;

                try
                {
                    sLineString = sLine;

                    if ((sLine.Length >= 60) && ((sLine.StartsWith("#C2-F:")) || (sLine.StartsWith("#C2-f:"))))
                    {
                        //Spectrum Analyzer mode, can be C2-F for steps < 10000 or C2-f for steps >=10000
                        fStartMHZ = Convert.ToInt32(sLine.Substring(6, 7)) / 1000.0; //note it comes in KHZ
                        fStepMHZ = Convert.ToInt32(sLine.Substring(14, 7)) / 1000000.0;  //Note it comes in HZ
                        fAmplitudeTopDBM = Convert.ToInt32(sLine.Substring(22, 4));
                        fAmplitudeBottomDBM = Convert.ToInt32(sLine.Substring(27, 4));
                        int nPos = 32;
                        if (sLine.StartsWith("#C2-f:"))
                        {
                            nFreqSpectrumSteps = Convert.ToUInt16(sLine.Substring(nPos, 5));
                            nPos++;
                        }
                        else
                        {
                            nFreqSpectrumSteps = Convert.ToUInt16(sLine.Substring(nPos, 4));
                        }
                        nPos += 4; //we use this variable to keep state for long step number

                        bExpansionBoardActive = (sLine[nPos + 1] == '1');
                        eMode = (eMode)Convert.ToUInt16(sLine.Substring(nPos + 3, 3));
                        fMinFreqMHZ = Convert.ToInt32(sLine.Substring(nPos + 7, 7)) / 1000.0;
                        fMaxFreqMHZ = Convert.ToInt32(sLine.Substring(nPos + 15, 7)) / 1000.0;
                        fMaxSpanMHZ = Convert.ToInt32(sLine.Substring(nPos + 23, 7)) / 1000.0;

                        if (sLine.Length > nPos + 30)
                        {
                            fRBWKHZ = Convert.ToInt32(sLine.Substring(nPos + 31, 5));
                        }
                        if (sLine.Length > nPos + 36)
                        {
                            fOffset_dB = Convert.ToInt32(sLine.Substring(nPos + 37, 4));
                        }
                        if (sLine.Length > nPos + 41)
                        {
                            eCalculator = (eCalculator)Convert.ToUInt16(sLine.Substring(nPos + 42, 3));
                        }
                    }
                }
                catch (Exception)
                {
                    bOk = false;
                }

                return bOk;
            }
        }

    }
}
