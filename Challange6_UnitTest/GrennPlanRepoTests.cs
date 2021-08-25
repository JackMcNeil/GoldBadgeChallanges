using Challange6_ClassLibrary;
using Challange6_ClassLibrary.CarTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challange6_UnitTest
{
    [TestClass]
    public class GrennPlanRepoTests
    {
        private GreenPlanRepo _repo;
        private Electric _electric;
        private Gas _gas;
        private Hybrid _hybird;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new GreenPlanRepo();
            _electric = new Electric("Tesla", "S", 2020, 1, 4, 300);
            _gas = new Gas("Ford", "F-150", 2019, 2, 5.5, 30);
            _hybird = new Hybrid("Toyota", "Rav-4", 2018, 3, 30, 3);

            _repo.AddCarToDirectory(_electric);
            _repo.AddCarToDirectory(_gas);
            _repo.AddCarToDirectory(_hybird);
        }
        [TestMethod]
        public void GetElectricByIdTest_ShouldGetRightCar()
        {
            //Electric
            Electric car = _repo.GetElectricById(1);
            Electric car2 = _repo.GetElectricById(2);
            //Gas
            Gas car3 = _repo.GetGasById(1);
            Gas car4 = _repo.GetGasById(2);

            //Electric
            Assert.AreEqual("Tesla", car.Make);
            Assert.IsNull(car2);
            //Gas
            Assert.AreEqual("Ford", car4.Make);
            Assert.IsNull(car3);
        }

        [TestMethod]
        public void GetListCheckTests()
        {
            List<Hybrid> gasList = _repo.GetAllHybrid();
            bool contains = gasList.Contains(_hybird);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void UpdateChecksTests()
        {
            Electric newTesla = new Electric("Tesla", "3", 2020, 1, 4, 300);
            Electric car = _repo.GetElectricById(1);
            Console.WriteLine($"{car.Make} {car.Model}");
            bool updated = _repo.UpdateElectric(newTesla);
            Electric car2 = _repo.GetElectricById(1);
            Assert.IsTrue(updated);
            Console.WriteLine($"{car.Make} {car.Model}");
        }

        [TestMethod]
        public void AddTest()
        {
            bool add = _repo.AddCarToDirectory(_gas);

            Assert.IsTrue(add);
        }

        [TestMethod]
        public void ReturnAllTest()
        {
            List<Car> cars = _repo.GetAllCars();
            bool contain = cars.Contains(_gas);

            Assert.IsTrue(contain);

        }

        [TestMethod]
        public void RemoveTests()
        {
            bool remove = _repo.DeleteACar(_hybird);

            Assert.IsTrue(remove);
        }
    }
}
