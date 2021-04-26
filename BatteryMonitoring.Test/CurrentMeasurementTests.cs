using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BatteryMonitoring.Test
{
    [TestClass]
    public class CurrentMeasurementTests
    {
        [TestMethod]
        public void GetRangesWithReadings_NullListAsParam_ReturnsException()
        {
            CurrentMeasurement captureRanges = new CurrentMeasurement();

            Assert.ThrowsException<ArgumentNullException>(() => captureRanges.GetRangesWithReadings(null),
                "Measurement cannot be null");
        }
        
        [TestMethod]
        public void GetRangesWithReadings_EmptyListAsParam_ReturnsNoRange()
        {
            CurrentMeasurement captureRanges = new CurrentMeasurement();
            Dictionary<string, int> actualRanges = captureRanges.GetRangesWithReadings(new List<int>() { });

            Assert.IsTrue(actualRanges.ContainsKey("0-0") && actualRanges["0-0"] == 0);
        }

        [TestMethod]
        public void GetRangesWithReadings_FourCurrentValuesAsListParam_ReturnsRangeWithReading()
        {
            CurrentMeasurement captureRanges = new CurrentMeasurement();
            Dictionary<string, int> actualRanges = captureRanges.GetRangesWithReadings(new List<int>() { 3, 3, 5, 4 });

            Assert.IsTrue(actualRanges.ContainsKey("3-5") && actualRanges["3-5"] == 4);
        }

        [TestMethod]
        public void GetRangesWithReadings_MoreThanFourCurrentValuesAsListParam_ReturnsNoRanges()
        {
            CurrentMeasurement captureRanges = new CurrentMeasurement();
            Dictionary<string, int> actualRanges = captureRanges.GetRangesWithReadings(new List<int>() { 3, 3, 5, 4, 10, 11, 12 });

            Assert.IsTrue(actualRanges.ContainsKey("3-5") && actualRanges["3-5"] == 4 &&
                          actualRanges.ContainsKey("10-12") && actualRanges["10-12"] == 3);
        }
    }
}
