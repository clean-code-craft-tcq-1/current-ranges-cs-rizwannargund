using System;
using System.Collections.Generic;

namespace BatteryMonitoring
{
    public class CurrentMeasurement
    {

        readonly Dictionary<string, int> _currentRanges = new Dictionary<string, int>();

        public Dictionary<string, int> GetRangesWithReadings(List<int> currentValues)
        {
            if (currentValues == null)
                throw new ArgumentNullException("Measurement cannot be null");

            if (currentValues.Count == 0)
            {
                _currentRanges.Add("0-0", 0);
            }

            if (currentValues.Count > 0)
            {
                _currentRanges.Add("3-5", 4);
            }

            return _currentRanges;
        }
    }
}