using Challange4_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challange4_UnitTest
{
    [TestClass]
    public class OutingsRepoTests
    {
        private OutingsRepo _repo;
        private Outings _outing1;
        private Outings _outing2;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new OutingsRepo();
            _outing1 = new Outings(EventTypes.Golf, 10, new DateTime(2021, 12, 14), 200.80);
            _outing2 = new Outings(EventTypes.Bowling, 30, new DateTime(2019, 1, 15), 60.54);

            _repo.AddToCollection(_outing1);
            _repo.AddToCollection(_outing2);
        }

        [TestMethod]
        public void AddToCollectionTest()
        {
            //Arrange
            //Act
            Outings outing = new Outings();
            bool check = _repo.AddToCollection(outing);

            //Assert
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void GetAllOutingsTest()
        {
            List<Outings> outings = _repo.GetAllOutings();
            bool contains = outings.Contains(_outing1);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void GetOutingByTypeTest()
        {
            List<Outings> outings = _repo.GetOutingByType(EventTypes.Golf);
            bool contains1 = outings.Contains(_outing1);
            bool contains2 = outings.Contains(_outing2);

            Assert.IsTrue(contains1);
            Assert.IsFalse(contains2);

        }
    }
}
