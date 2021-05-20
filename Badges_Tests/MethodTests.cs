using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Badges_Repository;
using System;

namespace Badges_Tests
{
    [TestClass]
    public class MethodTests
    {
        [TestMethod]
        public void CreateNewBadge_CorrectBoolean()
        {
            int badge = 3;
            List<string> door = new List<string>();
            BadgesRepository repo = new BadgesRepository();

            bool wasAddedCorrectly = repo.CreateNewBadge(badge, door);

            Assert.IsTrue(wasAddedCorrectly);
        }

        [TestMethod]
        public void GetBadgeAccess_ReturnDictionary()
        {
            int badge = 3;
            List<string> door = new List<string>();
            BadgesRepository repo = new BadgesRepository();
            repo.CreateNewBadge(3, door);

            Dictionary<int, List<string>> dict = repo.GetBadgeAccess();

            bool DictHasBadge = dict.ContainsKey(badge);
            Assert.IsTrue(DictHasBadge);
        }

        private Badges _badge;
        private BadgesRepository _repo;

        [TestInitialize]
        public void ArrangeItem()
        {
            _repo = new BadgesRepository();
            _badge = new Badges(1, new List<string> { "A1" });
            _repo.CreateNewBadge(_badge.BadgeID, _badge.DoorName);

        }

        [TestMethod]
        public void SeeBadgeByID_ReturnKeyList()
        {
            List<string> door = new List<string>();
            BadgesRepository repo = new BadgesRepository();
            repo.CreateNewBadge(3, door);

            Dictionary<int, List<string>> dict = repo.GetBadgeAccess();

            bool DictHasDoor = dict.ContainsValue(door);
            Assert.IsTrue(DictHasDoor);
        }

        [TestMethod]
        public void AddDoor_ReturnBoolean()
        {
            BadgesRepository repo = new BadgesRepository();

            _repo.AddDoor(1, "A3");
            bool wasDoorAdded = _repo.AddDoor(1, "A3");

            Assert.IsTrue(wasDoorAdded);
        }

        [TestMethod]
        public void DeleteDoor_ReturnBoolean()
        {
            BadgesRepository repo = new BadgesRepository();

            _repo.DeleteDoor(1, "A1");
            bool wasDoorAdded = _repo.DeleteDoor(1, "A1");

            Assert.IsTrue(wasDoorAdded);
        }
    }
}
