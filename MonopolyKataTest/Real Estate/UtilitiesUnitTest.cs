using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using System.Collections.Generic;

namespace MonopolyKataTest.Real_Estate
{
    [TestClass]
    public class UtilitiesUnitTest
    {
        private Player owner;
        private Player renter;
        private Utilitity electric;
        private Utilitity water;
        private Banker banker;
        private Dice dice;
        private List<Utilitity> utilities;

        [TestInitialize]
        public void Setup()
        {
            owner = new Player("Owner");
            renter = new Player("Renter");
            banker = new Banker();
            dice = new Dice();
            utilities = new List<Utilitity>();
            electric = new Utilitity("Electric Company", 1, 150, utilities, banker, dice);
            water = new Utilitity("Water Works", 2, 150, utilities, banker, dice);
            utilities.AddRange(new[] { water, electric });
        }

        [TestMethod]
        public void LandingOnSpaceWithOneOwnedRentIsFourTimesRoll()
        {
            water.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            dice.Roll();
            var  currentRoll = dice.GetRoll();

            water.LandOn(renter);

            Assert.AreEqual(renterStartingBalance - 4 * currentRoll, renter.Balance);
            Assert.AreEqual(ownerStartingBalance + 4 * currentRoll, owner.Balance);

        }

        [TestMethod]
        public void LandingOnSpaceWithBothOwnedRentIsTenTimesRoll()
        {
            water.LandOn(owner);
            electric.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            dice.Roll();
            var currentRoll = dice.GetRoll();

            water.LandOn(renter);

            Assert.AreEqual(renterStartingBalance - 4 * currentRoll, renter.Balance);
            Assert.AreEqual(ownerStartingBalance + 4 * currentRoll, owner.Balance);

        }
    }
}
