using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe_Tests
{
    [TestClass]
    public class CafeRepositoryTests
    {
        [TestMethod]
        public void AddItemToMenu_GetCorrectBoolean()
        {
            MenuItem item = new MenuItem();
            MenuRepository repo = new MenuRepository();

            bool wasAddedCorrectly = repo.AddItemToMenu(item);

            Assert.IsTrue(wasAddedCorrectly);
        }

        [TestMethod]
        public void GetMenuItems_ReturnCorrectList()
        {
            MenuItem item = new MenuItem();
            MenuRepository repo = new MenuRepository();
            repo.AddItemToMenu(item);

            List<MenuItem> menu = repo.GetMenuItems();

            bool menuHasItems = menu.Contains(item);
            Assert.IsTrue(menuHasItems);
        }

        private MenuItem _item;
        private MenuRepository _repo;

        [TestInitialize]
        public void ArrangeItem()
        {
            _repo = new MenuRepository();
            _item = new MenuItem(1, "cheeseburger", "cheeseburger", new List<string> { "buns", "cheese", "beef" }, 2.50);
            _repo.AddItemToMenu(_item);

        }

        [TestMethod]
        public void GetItemByName_ReturnCorrectItem()
        {
            MenuItem search = _repo.GetItemByName("cheeseburger");
            Assert.AreEqual(_item, search);
        }

        [TestMethod]
        public void UpdateMenuItem_ReturnUpdatedItem()
        {
            _repo.UpdateMenuItem("cheeseburger", new MenuItem(1, "cheeseburger2", "cheeseburger2", new List<string> { "buns", "cheese", "beef", "second patty" }, 21.50));

            Assert.AreEqual(_item.Name, "cheeseburger2");
        }

        [TestMethod]
        public void DeleteExistingItem_ReturnTrue()
        {
            bool wasDeleted = _repo.DeleteMenuItem("cheeseburger");

            Assert.IsTrue(wasDeleted);
        }
    }
}
