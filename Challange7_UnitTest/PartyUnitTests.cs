using Challange7_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challange7_UnitTest
{
    [TestClass]
    public class PartyUnitTests
    {
        private PartyRepo _repo;
        private Party _party;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new PartyRepo();
            _party = new Party(100, 100, 100.1,13);

            _repo.AddParty(_party);
        }
        [TestMethod]
        public void TestForAddMethod()
        {
           
            bool added = _repo.AddParty(new Party(10, 10, 13,13));

            Assert.IsTrue(added);
        }

        [TestMethod]
        public void TestForGetAllMethod()
        {
            List<Party> all = _repo.GetAllParties();
            bool check = all.Contains(_party);

            Assert.IsTrue(check);
        }
    }
}
