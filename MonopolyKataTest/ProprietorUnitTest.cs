using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using System.Collections.Generic;

namespace MonopolyKataTest
{
    [TestClass]
    public class ProprietorUnitTest
    {
        private Player player;
        private Player player2;
        private Dice dice;
        private Banker banker;
        private List<Property> red;
        private Property property;
        private Proprietor proprietor;

        [TestInitialize]
        public void Setup()
        {
            dice = new Dice();
            player = new Player("Player");
            player2 = new Player("Player2");
            banker = new Banker();
            proprietor = new Proprietor(banker);
            red = new List<Property>();
            property = new Property("Property", 1, 50, 10, red, banker);
            red.Add(property);
        }


        [TestMethod]
        public void BalanceIsIncreasedNintyPercentOfPuchasePrice()
        {
            property.LandOn(player);

            var startingBalance = player.Balance;
            var mortgagedAmount = property.BuyingCost * .9;

            proprietor.MortgageProperty(player, property);

            Assert.IsTrue(property.IsMortgaged);
            Assert.AreEqual(startingBalance + mortgagedAmount, player.Balance);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void PlayerCannotMortgagedPropertyThatIsAlreadyMortgaged()
        {
            property.LandOn(player);
            proprietor.MortgageProperty(player, property);
            proprietor.MortgageProperty(player, property);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void MortgagedFailsWhenPropertyIsNotOwned()
        {
            proprietor.MortgageProperty(player, property);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void MortgagedFailsWhenOwnerDoesNotOwnTheProperty()
        {
            var player2 = new Player("Player2");
            proprietor.MortgageProperty(player, property);
        }

        [TestMethod]
        public void PlayPaysBackMortagesBalanceIsDescreasedByPropertyCost()
        {
            property.LandOn(player);
            proprietor.MortgageProperty(player, property);

            var startingBalance = player.Balance;
            proprietor.CollectMortgagePayment(player, property);

            Assert.IsFalse(property.IsMortgaged);
            Assert.AreEqual(startingBalance - property.BuyingCost, player.Balance);
        }

        [TestMethod, ExpectedException(typeof (InvalidOperationException))]
        public void MortgagePaymentFailsIfPropertyIsNotMortgaged()
        {
            property.IsMortgaged = false;
            proprietor.CollectMortgagePayment(player, property);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void MortgagePaymentFailsIfPropertyIsNotOwned()
        {
            property.Owner = null;
            proprietor.CollectMortgagePayment(player, property);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void MortgagePaymentFailsIfPropertyIsNotOwnedByPlayer()
        {
            property.LandOn(player2);
            proprietor.CollectMortgagePayment(player, property);
        }
    }
}
