using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest.Spaces
{
    [TestClass]
    public class IncomeTaxUnitTest
    {
        private Banker banker;
        private IncomeTax incomeTax;
        private Player player;

        [TestInitialize]
        public void Setup()
        {
            banker = new Banker();
            incomeTax = new IncomeTax("Income Tax", 4, banker);
            player = new Player("Player");
        }

        [TestMethod]
        public void TotalWorthOfEighteenHundredFeeIsOneHundredEight()
        {
            player.ModifyPlayerBalance(300);
            var playerStartingBalance = player.Balance;

            incomeTax.LandOn(player);

            Assert.AreEqual(180, playerStartingBalance - player.Balance);
        }

        [TestMethod]
        public void TotalWorthOfTwentyTwoHundredFeeIsTwoHundred()
        {
            player.ModifyPlayerBalance(700);
            var playerStartingBalance = player.Balance;

            incomeTax.LandOn(player);

            Assert.AreEqual(200, playerStartingBalance - player.Balance);
        }

        [TestMethod]
        public void TotalWorthOfTwoThousanddFeeIsTwoHundred()
        {
            player.ModifyPlayerBalance(500);
            var playerStartingBalance = player.Balance;

            incomeTax.LandOn(player);

            Assert.AreEqual(200, playerStartingBalance - player.Balance);
        }

        [TestMethod]
        public void TotalWorthOfZerodFeeIsZero()
        {
            player.ModifyPlayerBalance(-1500);
            var playerStartingBalance = player.Balance;

            incomeTax.LandOn(player);

            Assert.AreEqual(0, playerStartingBalance - player.Balance);
        }
    }
}
