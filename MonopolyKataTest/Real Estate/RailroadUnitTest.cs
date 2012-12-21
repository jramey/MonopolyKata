using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest.Real_Estate
{
    [TestClass]
    public class RailroadUnitTest
    {
        private Player owner;
        private Player renter;
        private Banker banker;
        private  List<Property> railroads;
        private Railroad reading;
        private Railroad bO;
        private Railroad shortline;
        private Railroad penn;

        [TestInitialize]
        public void Setup()
        {
            owner = new Player("Owner");
            renter = new Player("Renter");
            banker = new Banker();
            railroads = new List<Property>();
            reading = new Railroad("Reading", 1, 200, 25, railroads, banker);
            bO = new Railroad("bO", 1, 200, 25, railroads, banker);
            shortline = new Railroad("shortline", 1, 200, 25, railroads, banker);
            penn = new Railroad("penn", 1, 200, 25, railroads, banker);
            railroads.AddRange( new [] { reading, bO, shortline, penn });
        }

        [TestMethod]
        public void LandingOnSpaceWhenOwnerOwnsOneRRRentIsTwentyFive()
        {
            reading.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            reading.LandOn(renter);

            Assert.AreEqual(25, renterStartingBalance - renter.Balance);
            Assert.AreEqual(25, owner.Balance - ownerStartingBalance);
        }

        [TestMethod]
        public void LandingOnSpaceWhenOwnerOwnsTwoRRRentIsFifty()
        {
            reading.LandOn(owner);
            bO.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            reading.LandOn(renter);

            Assert.AreEqual(50, renterStartingBalance - renter.Balance);
            Assert.AreEqual(50, owner.Balance - ownerStartingBalance);
        }

        [TestMethod]
        public void LandingOnSpaceWhenOwnerOwnsThreeRRRentIsOneHundred()
        {
            reading.LandOn(owner);
            bO.LandOn(owner);
            shortline.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            reading.LandOn(renter);

            Assert.AreEqual(100, renterStartingBalance - renter.Balance);
            Assert.AreEqual(100, owner.Balance - ownerStartingBalance);
        }

        [TestMethod]
        public void LandingOnSpaceWhenOwnerOwnsFourRRRentIsTwoHundred()
        {
            reading.LandOn(owner);
            bO.LandOn(owner);
            shortline.LandOn(owner);
            penn.LandOn(owner);

            var ownerStartingBalance = owner.Balance;
            var renterStartingBalance = renter.Balance;

            reading.LandOn(renter);

            Assert.AreEqual(200, renterStartingBalance - renter.Balance);
            Assert.AreEqual(200, owner.Balance - ownerStartingBalance);
        }
    }
}

