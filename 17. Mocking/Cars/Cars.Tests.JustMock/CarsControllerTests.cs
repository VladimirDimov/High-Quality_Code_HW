namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;
    using Moq;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            //: this(new JustMockCarsRepository())
         : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DetailsShouldThrowWhenNullCarIsReturnedByTheRepository()
        {
            var repositoryMock = new Mock<ICarsRepository>();
            repositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();

            var carsController = new CarsController(repositoryMock.Object);

            carsController.Details(0);
        }

        [TestMethod]
        public void SortingShoulReturnSortedCollectionWhenMakeIsPassed()
        {
            var sortedByMake = this.GetModel(() => this.controller.Sort("make"));
            var isSorted = true;
            for (int i = 1; i < (sortedByMake as List<Car>).Count; i++)
            {
                if ((sortedByMake as List<Car>)[i].Make.CompareTo((sortedByMake as List<Car>)[i - 1].Make) < 0)
                {
                    isSorted = false;
                }
            }

            Assert.IsTrue(isSorted);         
        }

        [TestMethod]
        public void SortingShoulReturnSortedCollectionWhenYearIsPassed()
        {
            var sortedByMake = this.GetModel(() => this.controller.Sort("make"));
            var isSorted = true;
            for (int i = 1; i < (sortedByMake as List<Car>).Count; i++)
            {
                if ((sortedByMake as List<Car>)[i].Make.CompareTo((sortedByMake as List<Car>)[i - 1].Make) < 0)
                {
                    isSorted = false;
                }
            }

            Assert.IsTrue(isSorted);
        }

        [TestMethod]
        public void SearchingShouldReturnAppropriateResultWhenMakeMatches()
        {
            var make = "BMW";
            var matchedResults = this.GetModel(() => this.controller.Search(make)) as List<Car>;

            Assert.IsTrue(matchedResults.Count > 0);
            foreach (var car in matchedResults)
            {
                Assert.AreEqual(make, car.Make);
            }
        }

        [TestMethod]
        public void SearchingShouldReturnAppropriateResultWhenModelMatches()
        {
            var model = "A5";
            var matchedResults = this.GetModel(() => this.controller.Search(model)) as List<Car>;

            Assert.IsTrue(matchedResults.Count > 0);
            foreach (var car in matchedResults)
            {
                Assert.AreEqual(model, car.Model);
            }
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
