using System;
using System.Collections.Generic;

namespace RFESnapShot.AutoSweep
{
    public class StabilityChecker
    {
        private bool bEnabled = false;
        private double threshold;
        private int requiredCount;
        private Queue<double> taps = new Queue<double>();
        private int exceedCount;
        private double runningSum;

        public void Initialize(bool bEnable, decimal requiredDbmVariation, decimal requiredStableCalls)
        {
            this.bEnabled = bEnable;
            this.threshold = (double)requiredDbmVariation / 2.0;
            this.requiredCount = (int)requiredStableCalls;
            this.runningSum = 0;
            this.taps.Clear();
        }

        public void Clear()
        {
            runningSum = 0;
            this.taps.Clear();
        }

        // Assume this is declared at the class level

        public bool Stable(double currentValue)
        {
            if (!bEnabled)
            {
                taps.Clear();
                runningSum = 0; // Reset running sum
                return false;
            }

            // Enqueue the current value and update running sum
            taps.Enqueue(currentValue);
            runningSum += currentValue;

            // Ensure the queue does not hold more taps than needed
            if (taps.Count > requiredCount)
            {
                runningSum -= taps.Dequeue(); // Update running sum when dequeuing
            }

            // If we don't have enough taps yet, return false
            if (taps.Count < requiredCount)
                return false;

            double average = runningSum / taps.Count;
            int exceedCount = 0;
            double maxExceedCount = 0.05 * requiredCount;

            // Iterate directly over the queue
            foreach (var value in taps)
            {
                if (Math.Abs(value - average) > threshold)
                {
                    exceedCount++;
                    if (exceedCount > maxExceedCount)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
