using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest.Spaces
{
    [TestClass]
    public class LuxuryTaxUnitTest
    {

        [TestMethod]
        public void LandingOnLuxuryTaxDecreasesBalanceBySeventyFive()
        {
            var player = new Player("Player");
            var banker = new Banker();
            var luxuryTax = new LuxuryTax("Luxury Tax", 38, banker); 
            var playerStartingBalance = player.Balance;

            luxuryTax.LandOn(player);

            Assert.AreEqual(75, playerStartingBalance - player.Balance);
        }
    }
}
