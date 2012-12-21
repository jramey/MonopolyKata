using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest.Spaces
{
    [TestClass]
    public class GoUnitTests
    {
        [TestMethod]
        public void LandingOnGoIncreaseBalanceByTwoHundres()
        {
            var banker = new Banker();
            var go = new Go("Go", 0, banker);
            Player player = new Player("Player");
            var playerStartingBalance = player.Balance;
            go.LandOn(player);      
      
            Assert.AreEqual(200, player.Balance - playerStartingBalance);
        }
    }
}
