namespace Computers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    [TestClass]
    public class CpuTests
    {
        [TestMethod]
        public void Cpu32ExpectedToReturnProperValueIfNumberIsInRange()
        {
            var motherboardMock = new Mock<IMotherboard>();
            motherboardMock.Setup(x => x.LoadRamValue()).Returns(5);
            var motherboard = motherboardMock.Object;

            var cpu = new Cpu32(2, motherboard);
            cpu.SquareNumber();

            motherboardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("25"))));
        }

        [TestMethod]
        public void Cpu32ExpectedToReturnProperMessageIfNumberIsLessThanZero()
        {
            var motherboardMock = new Mock<IMotherboard>();
            motherboardMock.Setup(x => x.LoadRamValue()).Returns(-5);
            var motherboard = motherboardMock.Object;

            var cpu = new Cpu32(2, motherboard);
            cpu.SquareNumber();
            motherboardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y == "Number too low.")));
        }

        [TestMethod]
        public void Cpu32ExpectedToReturnProperMessageIfNumberIsGreaterThanMaxAllowedValue()
        {
            var motherboardMock = new Mock<IMotherboard>();
            motherboardMock.Setup(x => x.LoadRamValue()).Returns(501);
            var motherboard = motherboardMock.Object;

            var cpu = new Cpu32(2, motherboard);
            cpu.SquareNumber();
            motherboardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y == "Number too high.")));
        }

        [TestMethod]
        public void CpuShouldReturnAllRandomNumbersInTheRange()
        {            
            var motherboardMock = new Mock<IMotherboard>();
            var randomResults = new HashSet<int>();
            motherboardMock.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(param => randomResults.Add(param));
           
            var motherboard = motherboardMock.Object;
            var cpu = new Cpu32(2, motherboard);

            for (int i = 0; i < 1000; i++)
            {
                cpu.rand(1, 11);
            }

            Assert.AreEqual(randomResults.Count, 10);
        }

        [TestMethod]
        public void CpuShouldNotReturnNumberBelowTheGivenRange()
        {
            var motherboardMock = new Mock<IMotherboard>();
            int randomResult = int.MaxValue;
            motherboardMock.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(param => randomResult = Math.Min(param, randomResult));

            var motherboard = motherboardMock.Object;
            var cpu = new Cpu32(2, motherboard);

            for (int i = 0; i < 1000; i++)
            {
                cpu.rand(1, 11);
            }

            Assert.AreEqual(true, randomResult >= 1);
        }

        [TestMethod]
        public void CpuShouldNotReturnNumberAboveTheGivenRange()
        {
            var motherboardMock = new Mock<IMotherboard>();
            int randomResult = int.MinValue;
            motherboardMock.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(param => randomResult = Math.Max(param, randomResult));

            var motherboard = motherboardMock.Object;
            var cpu = new Cpu32(2, motherboard);

            for (int i = 0; i < 1000; i++)
            {
                cpu.rand(1, 11);
            }

            Assert.AreEqual(true, randomResult >= 1);
        }
    }
}
