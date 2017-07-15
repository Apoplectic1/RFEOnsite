using System.Collections.Generic;
using System.Windows.Forms;

namespace RFEOnSite
{
    public class FileOps
    {
        private FolderBrowserDialog mFolderDialog;
        private string mFileName;
        
        public FileOps()
        {
            mFolderDialog = new FolderBrowserDialog();
        }

        public FolderBrowserDialog FolderDialog { get { return mFolderDialog; } set { mFolderDialog = value; } }
        public string Path { get { return mFileName; } set { mFileName = value; } }

        public bool ExportCsvFile()
        {
            
        //        string frequency;
        //        List<double> frequencyList = new List<double>();

        //        frequencyList.Clear();

        //        for (int step = 0; step < 112; step++)
        //        {
                
        //            frequencyList.Add(Graph.MinX + (step * Graph.MaxX));
        //        }
        //        for (int sweepIndex = 0; sweepIndex < Explorer.SweepCount; sweepIndex++)
        //        {
        //            ExportCsv.AddRow();

        //            for (int index = 0; index != 112; index++)
        //            {
        //                frequency = frequencyList[index].ToString();

        //                ExportCsv[frequency] = Data.GetDbmAt(index).ToString();
        //            }
        //        }

        //      ExportCsv.ExportToFile("path");
            

            return true;
        }
    }
}
