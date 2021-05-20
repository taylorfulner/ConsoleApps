using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Claims_Repository;

namespace Claims_Tests
{
    [TestClass]
    public class MethodsTests
    {
        [TestMethod]
        public void CreateClaim_GetBoolean() 
        {
            Claims claims = new Claims();
            ClaimsRepository repo = new ClaimsRepository();

            bool wasAddedCorrectly = repo.CreateClaim(claims);

            Assert.IsTrue(wasAddedCorrectly);
        }

        [TestMethod]
        public void GetClaims_ReturnQueue()
        {
            Claims claim = new Claims();
            ClaimsRepository repo = new ClaimsRepository();
            repo.CreateClaim(claim);

            Queue<Claims> claimQueue = repo.GetClaims();

            bool menuHasItems = claimQueue.Contains(claim);
            Assert.IsTrue(menuHasItems);
        }

        private Claims _claim;
        private ClaimsRepository _repo;

        [TestInitialize]
        public void ArrangeItem()
        {
            _repo = new ClaimsRepository();
            _claim = new Claims(1, ClaimType.car, "car accident", 100, new DateTime(2018, 05, 01), new DateTime(2018, 05, 02));

            _repo.CreateClaim(_claim);
        }

        [TestMethod]
        public void GetClaimFromQueue_ReturnClaim()
        {
            Queue<Claims> claim = _repo.GetClaimFromQueue();
            Assert.AreEqual(_claim, claim.Peek());
        }

        [TestMethod]
        public void UpdateClaim_ReturnUpdatedInfo()
        {
            _repo.UpdateClaim(_claim, new Claims(2, ClaimType.car, "car accident", 100, new DateTime(2018, 05, 01), new DateTime(2018, 05, 02)));

            Assert.AreEqual(_claim.ClaimID, 2);
        }

        [TestMethod]
        public void DeleteClaimFromQueue_ReturnTrue()
        {
            Queue<Claims> claim = _repo.DeleteClaimFromQueue();
            Assert.AreEqual(_claim, claim.Peek());
        }
    }
}
