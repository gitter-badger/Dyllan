using System;
using ImpossibleMission.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImpossibleMissionUT
{
    [TestClass]
    public class TestCommonEbbinghaus
    {
        [TestMethod]
        public void TestMethod1()
        {
            CommonEbbinghausTemplate commonEbbinghaus = CommonEbbinghausTemplate.Instance;
            var periods = commonEbbinghaus.Periods;

            Assert.AreEqual(periods.Count, 4);
            Assert.AreEqual(periods[0], 1);
            Assert.AreEqual(periods[1], 5);
            Assert.AreEqual(periods[2], 13);
            Assert.AreEqual(periods[3], 28);

            periods.Add(65);
            Assert.AreEqual(periods.Count, 5);
            periods = commonEbbinghaus.Periods;
            Assert.AreEqual(periods.Count, 4);
        }
    }
}
