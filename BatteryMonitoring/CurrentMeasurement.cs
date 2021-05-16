using System;
using System.Collections.Generic;
using System.Linq;

namespace BatteryMonitoring
{
    public class CurrentMeasurement
    {

        readonly Dictionary<string, int> _currentRanges = new Dictionary<string, int>();

        public void CheckIfReadingsAreNullOrEmpty(List<int> currentValues)
        {
            if (currentValues == null || currentValues.Count == 0)
                throw new ArgumentException("currentValues cannot be null or empty");
        }

        public Dictionary<string, int> GetRangesWithReadings(List<int> currentValues)
        {
            CheckIfReadingsAreNullOrEmpty(currentValues);

            int min = currentValues.Min();
            int max = currentValues.Max();

            if (!_currentRanges.ContainsKey(min + "-" + max))
            {
                _currentRanges.Add(min + "-" + max, 0);

                currentValues.Sort();
                _currentRanges[min + "-" + max] = currentValues.Count;
            }

            return _currentRanges;
        }
    }
}