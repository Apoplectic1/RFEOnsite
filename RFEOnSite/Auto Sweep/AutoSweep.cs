using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

namespace RFESnapShot.AutoSweep
{

    public class StabilityChecker
    {
        private bool mEnabled = false;
        private double mTargetMadDb { get; set; }  // Maximum Median Absolute Deviation in dB
        private int mRequiredCount;
        private Queue<double> mTaps = new Queue<double>();
        private double mRunningSum;

        public void Initialize(bool bEnable, double targetMadDb, int requiredStableCalls)
        {
            mEnabled = bEnable;
            mTargetMadDb = targetMadDb;
            mRequiredCount = requiredStableCalls;
            mRunningSum = 0;
            mTaps.Clear();
        }

        public void Clear()
        {
            mRunningSum = 0;
            mTaps.Clear();
        }

        public bool StableCheck(double currentValue)
        {
            if (!mEnabled)
            {
                mTaps.Clear();
                mRunningSum = 0;
                return false;
            }

            mTaps.Enqueue(currentValue);

            mRunningSum += currentValue;

            // We want to look at only the most recent sweeps
            if (mTaps.Count > mRequiredCount)
            {
                mRunningSum -= mTaps.Dequeue(); // Update running sum when dequeuing
            }

            // If we don't have enough mTaps yet, return false
            if (mTaps.Count < mRequiredCount)
                return false;

            // Calculate the mean of the array
            double mean = mRunningSum / (double)mTaps.Count;

            // Update each element in the array with its absolute difference from the mean
            double absDiffSum = 0;
            foreach (var tap in mTaps)
            {
                absDiffSum += Math.Abs(tap - mean);
            }

            return Math.Abs(absDiffSum / (double)mTaps.Count) <= mTargetMadDb;
        }
    }
}
