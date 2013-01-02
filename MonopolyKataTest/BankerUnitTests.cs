using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest
{
    [TestClass]
    public class BankerUnitTests
    {
        private Player owner;
        private Player renter;
        private Banker banker;
        private List<Space> spaces;
        private List<Property> properties;

        [TestInitialize]
        public void Setup()
        {
            owner = new Player("Owner");
            renter = new Player("Renter");
            banker = new Banker();
            properties = new List<Property>();
            spaces = new List<Space>();
        }

        [TestMethod]
        public void PlayerBuysSpaceTheyLandOn()
        {
            var property = new Property("Property", 1, 20, 20, properties, banker);
            properties.Add(property);
            property.LandOn(owner);

            Assert.AreEqual(property.Owner, owner);
        }

        [TestMethod]
        public void PlayerLandsPropertyTheyOwn()
        {
            var property = new Property("Property", 1, 20, 20, properties, banker);
            property.LandOn(owner);
            var playerStartingBalance = owner.Balance;
            property.LandOn(owner);

            Assert.AreEqual(playerStartingBalance, owner.Balance);
        }

        [TestMethod]
        public void PlayerPaysRentToOwnerWhenLandingOnOwnedProperty()
        {
            var renter = new Player("Renter");
            var property = new Property("Property", 1, 20, 20, properties, banker);
            property.LandOn(owner);

            var renterStartingBalance = renter.Balance;

            property.LandOn(renter);

            Assert.AreEqual(renterStartingBalance - 2 * property.Rent, renter.Balance);
        }
    }
}