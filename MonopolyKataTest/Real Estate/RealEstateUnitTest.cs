using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using System.Collections.Generic;

namespace MonopolyKataTest.Real_Estate
{
    [TestClass]
    public class UnitTest1
    {
        private Player owner;
        private Player renter;
        private Property boardwalk;
        private Property parkPlace;
        private Banker banker;
        private List<Property> blue;
        
        [TestInitialize]
        public void Setup()
        {
            owner = new Player("Owner");
            renter = new Player("Renter");
            banker = new Banker();
            blue = new List<Property>();
            boardwalk = new Property("Boardwalk", 1, 400, 50, blue, banker);
            parkPlace = new Property("Park Place", 1, 350, 35, blue, banker);
            blue.AddRange(new[] { boardwalk, parkPlace });
        }

        [TestMethod]
        public void LandingOnPropertyNotAllOwnedBySamePlayerRentIsNormal()
        {
            boardwalk.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            boardwalk.LandOn(renter);

            Assert.AreEqual(renterStartingBalance - boardwalk.Rent, renter.Balance);
            Assert.AreEqual(ownerStartingBalance + boardwalk.Rent, owner.Balance);
        }

        [TestMethod]
        public void LandingOnPropertyTwofTwoOwnedBySamePlayerRentIsTwiceStandardRent()
        {
            boardwalk.LandOn(owner);
            parkPlace.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            boardwalk.LandOn(renter);

            Assert.AreEqual(renterStartingBalance - 2 * boardwalk.Rent, renter.Balance);
            Assert.AreEqual(ownerStartingBalance + 2 * boardwalk.Rent, owner.Balance);
        }

        [TestMethod]
        public void LandingOnPropertyAllOwnedBySamePlayerRentIsTwiceStandardRent()
        {
            var red = new List<Property>();

            var kentuckyAve = new Property("Kentucky Ave.", 21, 100, 12, red, banker);
            var indianaave = new Property("Indiana Ave.", 23, 100, 12, red, banker);
            var illinoisAve = new Property("Illinois Ave.", 24, 100, 12, red, banker);

            red.AddRange(new [] { kentuckyAve, indianaave, illinoisAve } );

            kentuckyAve.LandOn(owner);
            indianaave.LandOn(owner);
            illinoisAve.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            illinoisAve.LandOn(renter);

            Assert.AreEqual(renterStartingBalance - 2 * illinoisAve.Rent, renter.Balance);
            Assert.AreEqual(ownerStartingBalance + 2 * illinoisAve.Rent, owner.Balance);
        }
    }
}
