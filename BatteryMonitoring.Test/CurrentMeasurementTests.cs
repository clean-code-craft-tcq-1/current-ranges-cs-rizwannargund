using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BatteryMonitoring.Test
{
    [TestClass]
    public class CurrentMeasurementTests
    {
        CurrentMeasurement captureRanges = new CurrentMeasurement();
        [TestMethod]
        public void CheckIfReadingsAreNull_NullListAsParam_ReturnsException()
        {
            Assert.ThrowsException<ArgumentException>(() => captureRanges.CheckIfReadingsAreNullOrEmpty(null),
                "currentValues cannot be null or empty");

        }
        
        [TestMethod]
        public void CheckIfReadingsAreNullOrEmpty_EmptyListAsParam_ReturnsNoRange()
        {
            Assert.ThrowsException<ArgumentException>(() => captureRanges.CheckIfReadingsAreNullOrEmpty(new List<int>()),
                "currentValues cannot be null or empty");
        }

        [TestMethod]
        public void GetRangesWithReadings_FourCurrentValuesAsListParam_ReturnsRangeWithReading()
        {
            Dictionary<string, int> actualRanges = captureRanges.GetRangesWithReadings(new List<int>() { 3, 3, 5, 4 });

            Assert.IsTrue(actualRanges.ContainsKey("3-5") && actualRanges["3-5"] == 4);
        }

        [TestMethod]
        public void GetRangesWithReadings_MoreThanFourCurrentValuesAsListParam_ReturnsNoRanges()
        {
            Dictionary<string, int> actualRanges = captureRanges.GetRangesWithReadings(new List<int>() { 3, 3, 5, 4, 10, 11, 12 });

            Assert.IsTrue(actualRanges.ContainsKey("3-5") && actualRanges["3-5"] == 4 &&
                          actualRanges.ContainsKey("10-12") && actualRanges["10-12"] == 3);
        }
    }
}
