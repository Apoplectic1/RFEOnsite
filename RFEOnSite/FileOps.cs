using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace RFEOnSite
{
    public class FileOps
    {
        private CsvExport mCsvExport;
        private Decibels mDbm;
        private FolderBrowserDialog mFolderDialog;
        private double mStartMHz;
        private double mStepMHz;
        private double mStopMHz;
        private int mSweepCount;
        private string mFileName;
        private int mFileCount;
        private DateTime mRunStartTime;
        private Stack mCwdQueue;

        public CsvExport ExportCsv { get { return mCsvExport; } set { mCsvExport = value; } }
        public Decibels SweepDdm { get { return mDbm; } set { mDbm = value; } }
        public FolderBrowserDialog FolderDialog { get { return mFolderDialog; } set { mFolderDialog = value; } }
        public double StartMHz { get { return mStartMHz; } set { mStartMHz = value; } }
        public double StepMHz { get { return mStepMHz; } set { mStepMHz = value; } }
        public double StopMHz { get { return mStopMHz; } set { mStopMHz = value; } }
        public int SweepCount { get { return mSweepCount; } set { mSweepCount = value; } }
        public string Path { get { return mFileName; } set { mFileName = value; } }
        public int FileCounter { get { return mFileCount; } set { mFileCount = value; } }
        public DateTime RunStartTime { get { return mRunStartTime; } set { mRunStartTime = value; } }

        public FileOps()
        {
            mFolderDialog = new FolderBrowserDialog();
            mFileName = string.Empty;
            mCwdQueue = new Stack();
        }
        
        public string PeekCwdDirectory()
        {
            return mCwdQueue.Peek().ToString();
        }
        public bool CheckDirectory(string relativePath)
        {
            string cwd;
            string checkPath;

            cwd = Directory.GetCurrentDirectory();

            checkPath = System.IO.Path.Combine(cwd, relativePath);

            return Directory.Exists(checkPath);

        }
        public string CleanCreateEnterDirectory(string relativePath)
        {
            string cwd = Directory.GetCurrentDirectory();
            string errorMessage3 = "Can't Enter directory: " + relativePath + "\nCleanCreateCleanCreateEnterDirectory()";

            string deletePath;

            mCwdQueue.Push(cwd.ToString());
            try
            {
                deletePath = System.IO.Path.Combine(cwd, relativePath);
                if (Directory.Exists(deletePath))
                {
                    // Clean up - DELETE - the directories created by THIS program. Need to ask: "Are you sure?"
                    Directory.Delete(deletePath, true);
                }
            }
            catch (Exception)
            {
                string errorMessage1 = "Can't Delete directory: " + relativePath + "\nfrom:\n" + cwd;
                MessageBox.Show(errorMessage1);
                Application.Exit();
            }

            try
            {
                Directory.CreateDirectory(System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath)));
            }
            catch (Exception)
            {
                string errorMessage2 = "Can't Create directory: " + relativePath + "\nin:\n" + cwd;
                MessageBox.Show(errorMessage2);
                Application.Exit();
            }

            try
            {
                string errorMessage2 = "Can't Enter directory: " + relativePath + "\nfrom:\n" + cwd;
                Directory.SetCurrentDirectory(System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath)));
            }
            catch (Exception)
            {

                MessageBox.Show(errorMessage3);
                Application.Exit();
            }
            return mCwdQueue.Peek().ToString();
        }

        public void RecusiveDeleteDirectory(string relativePath)
        {
            string sDeletePath, sCwd;

            sCwd = Directory.GetCurrentDirectory();

            sDeletePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(sCwd, relativePath));

            if (!Directory.Exists(sDeletePath))
            {
                return;
            }

            try
            {
                Directory.Delete(sDeletePath, true);
            }
            catch
            {
                string errorMessage1 = "Can't Delete Directory(s): " + sDeletePath;
                MessageBox.Show(errorMessage1);
                Application.Exit();
            }

        }

        public string GetFullPathFromRelativePath(string relativePath)
        {
            string cwd = Directory.GetCurrentDirectory();
            string dir = System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath));
            return dir;
        }

        public string SetCurrentDirectory(string relativePath)
        {
            string cwd = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath)));
            Directory.SetCurrentDirectory(System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath)));

            cwd = Directory.GetCurrentDirectory();

            mCwdQueue.Push(cwd.ToString());

            return mCwdQueue.Peek().ToString();
        }
        public string PopToDirectory(int stackIndex)
        {
            while (mCwdQueue.Count > stackIndex)
            {
                PopDirectory();
            }

            return mCwdQueue.Peek().ToString();

        }

        public string CreateEnterDirectory(string relativePath)
        {
            string cwd = Directory.GetCurrentDirectory();
            mCwdQueue.Push(cwd.ToString());
            Directory.CreateDirectory(System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath)));
            Directory.SetCurrentDirectory(System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath)));

            cwd = Directory.GetCurrentDirectory();

            return mCwdQueue.Peek().ToString();
        }

        private string Push(string relativePath)
        {
            string cwd = Directory.GetCurrentDirectory();
            string errorMessage = "Can't enter directory: " + relativePath + " Push()";

            mCwdQueue.Push(cwd.ToString());
            try
            {
                Directory.Delete(System.IO.Path.Combine(cwd, relativePath), true);
            }
            catch (Exception e)
            {
                MessageBox.Show(errorMessage, e.ToString());
                Application.Exit();
            }

            string newCwd = System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath));

            Directory.SetCurrentDirectory(newCwd);
            return mCwdQueue.Peek().ToString();
        }

        public string PushDirectory(string relativePath)
        {
            string cwd = Directory.GetCurrentDirectory();

            mCwdQueue.Push(cwd.ToString());

            string newCwd = System.IO.Path.GetFullPath(System.IO.Path.Combine(cwd, relativePath));

            Directory.SetCurrentDirectory(newCwd);

            return newCwd;
        }

        public string PopDirectory()
        {
            string cwd = mCwdQueue.Pop().ToString();
            Directory.SetCurrentDirectory(System.IO.Path.GetFullPath(cwd));
            return cwd;
        }

        public bool IsValidPath(string path)
        {

            bool isValid = !string.IsNullOrEmpty(path) &&
                !path.Contains(" ") &&
                !path.Contains(".") &&
                path.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) < 0;

            if (!isValid)
            {
                string message;
                string caption = "Illegal Characters Found Surevy Location Identifier:";
                message = path;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the Exception MessageBox.
                result = MessageBox.Show(message, caption, buttons);

                return false;
            }

            return true;
        }


        // *****************************************************************************************
        // *****************************************************************************************
        // ** Write CsvFiles from Swept List Data
        // *****************************************************************************************
        // *****************************************************************************************
        public bool ExportCsvFile(double startMhz, double stopMhz, double stepSize,  List<string> data)
        {
            mCsvExport = new CsvExport();

            string frequency;
            List<double> frequencyList = new List<double>();

            frequencyList.Clear();

            //double stepMHz = stepSize / 1000.0;
            double freq = startMhz;
            for (int step = 0; step < 112; step++)
            {
                frequencyList.Add(freq);
                freq += stepSize;
            }

            for (int sweepIndex = 0; sweepIndex < data.Count; sweepIndex++)
            {
                mCsvExport.AddRow();
                string row = data[sweepIndex];

                for (int index = 0; index != 112; index++)
                {
                    frequency = frequencyList[index].ToString("F8");
                    Int32 dBm = Convert.ToInt16(row[index + 3]);

                    mCsvExport[frequency] = (-(Convert.ToDouble(dBm) / 2.0)).ToString("F1");
                }
            }

            mCsvExport.ExportToFile(mFileName);

            mCsvExport = null;

            return true;
        }
    }
}
