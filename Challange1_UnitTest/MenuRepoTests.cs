using Challange1_Class_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challange1_UnitTest
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepository _repo;
        private Menu _menuItem;
        [TestInitialize]
        public void Arrange()
        {
            List<string> ingredients = new List<string>() { "meat", "bun", "lettuce", "tomato" };
            _repo = new MenuRepository();
            _menuItem = new Menu(1, "Burger", "A Juicy burger", ingredients, 9.99);

            _repo.AddMenuItem(_menuItem);

        }
        [TestMethod]
        public void AddMenuItemTest()
        {
            //Arrange
            MenuRepository repo = new MenuRepository();
            List<string> ingredients = new List<string>() {"meat","bun","lettuce","tomato" };
            Menu menuItem = new Menu(1,"Burger","A Juicy burger",ingredients,9.99);
            //Act
            bool addResult = repo.AddMenuItem(menuItem);
            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenuItemsTest()
        {
            //Arrange
            //Act
            List<Menu> items = _repo.GetMenuItems();
            bool itemInRepo = items.Contains(_menuItem);
            //Assert
            Assert.IsTrue(itemInRepo);
        }

        [TestMethod]
        public void DeleteMenuItemTest()
        {
            //Arrange
            //Act
            bool deletedItem = _repo.DeleteMenuItems(_menuItem);
            //Assert
            Assert.IsTrue(deletedItem);
        }

        [TestMethod]
        public void GetMenuItemByIDTest()
        {
            //Arrange
            //Act
            Menu menu = _repo.GetMenuItemByID(1);

            Assert.AreEqual(_menuItem, menu);
        }
    }
}
