using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Computers.Tests
{
    [TestClass]
    public class BatteryTests
    {
        [TestMethod]
        public void BatteryPercentageShouldIncreaseProperly()
        {
            var battery = new Battery();
            battery.Percentage = 50;
            battery.Charge(5);
            Assert.AreEqual(55, battery.Percentage);
        }

        [TestMethod]
        public void BatteryPercentageShouldDecreaseProperly()
        {
            var battery = new Battery();
            battery.Percentage = 50;
            battery.Charge(-5);
            Assert.AreEqual(45, battery.Percentage);
        }

        [TestMethod]
        public void BatteryPercentageMinValueShouldBeZero()
        {
            var battery = new Battery();
            battery.Percentage = 0;
            battery.Charge(-5);
            Assert.AreEqual(0, battery.Percentage);

        }

        [TestMethod]
        public void BatteryPercentageMaxValueShouldBeOneHoundred()
        {
            var battery = new Battery();
            battery.Percentage = 50;
            battery.Charge(150);
            Assert.AreEqual(100, battery.Percentage);
        }
    }
}
