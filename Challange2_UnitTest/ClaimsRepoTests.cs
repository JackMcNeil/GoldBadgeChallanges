using Challange2_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Challange2_UnitTest
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private ClaimsRepository _repo;
        private Claim _claimItem;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _claimItem = new Claim(3, ClaimTypes.Home, "Home Alone happend in your house", 420.50, new DateTime(2010, 12, 25), new DateTime(2011, 1, 4));

            _repo.AddClaim(_claimItem);
        }

        [TestMethod]
        public void AddClaimIsTrue()
        {
            bool worked = _repo.AddClaim(new Claim());

            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void GetAllClaimsTest()
        {
            //Arrange
            //Act
            Queue<Claim> queue = _repo.GetAllClaims();
            bool claimInRepo = queue.Contains(_claimItem);

            //Assert
            Assert.IsTrue(claimInRepo);
        }

        [TestMethod]
        public void DeleteClaimTest()
        {
            //Act
            _repo.DeleteClaim();
            Queue<Claim> queue = _repo.GetAllClaims();
            bool claimInRepo = queue.Contains(_claimItem);

            //Assert
            Assert.IsFalse(claimInRepo);
        }

        [TestMethod]
        public void TestForTimeSpan()
        {
            DateTime claim = new DateTime(2021, 08, 21);
            DateTime incident1 = new DateTime(2021, 08, 1);
            DateTime incident2 = new DateTime(2021, 07, 1);

            TimeSpan length = claim - incident1;
            TimeSpan length2 = claim - incident2;

            bool greaterThan30 = length2.TotalDays > 30;
            Console.WriteLine(length);
            Console.WriteLine(length2);

            Assert.IsTrue(greaterThan30);
        }
    }
}
