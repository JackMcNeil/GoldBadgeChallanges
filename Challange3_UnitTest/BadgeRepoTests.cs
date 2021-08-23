using Challange3_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challange3_UnitTest
{
    [TestClass]
    public class BadgeRepoTests
    {
        private BadgeRepo _repo;
        private Badge _aBadge;

        [TestInitialize]
        public void Arrange()
        {
            List<string> roomAccess = new List<string>() { "A5", "B7", "C9" };
            _repo = new BadgeRepo();
            _aBadge = new Badge(420, roomAccess);

            _repo.AddNewBadge(_aBadge);
        }

        [TestMethod]
        public void AddNewBadgeTest()
        {
            Badge badge = new Badge();
            bool addResult = _repo.AddNewBadge(badge);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllBadgesTest()
        {
            Dictionary<int, List<string>> dict = _repo.GetAllBadges();
            bool inDict = dict.ContainsKey(_aBadge.BadgeID);

            Assert.IsTrue(inDict);
        }

        [TestMethod]
        public void GetBadgeByIdTest()
        {
            Badge theBadge = _repo.GetBadgeById(420);

            Assert.AreEqual(theBadge.BadgeID, _aBadge.BadgeID);
        }

        [TestMethod]
        public void UpdateandRemoveDoorToBadgeTests()
        {
            //Update
            Badge badgeToCheck = _repo.GetBadgeById(420);
            Console.WriteLine(string.Join(", ", badgeToCheck.DoorNames));

            bool check = _repo.UpdateExistingBadge(420, "D7");

            Console.WriteLine(string.Join(", ", badgeToCheck.DoorNames));
            Assert.IsTrue(check);

            //Remove
            bool removeTest = _repo.RemoveExisitngDoor(420, "D7");
            Console.WriteLine(string.Join(", ", badgeToCheck.DoorNames));
            Assert.IsTrue(removeTest);
        }
    }
}
