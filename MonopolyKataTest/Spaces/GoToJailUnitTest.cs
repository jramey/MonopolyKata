using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest.Spaces
{
    [TestClass]
    public class GoToJailUnitTest
    {
        [TestMethod]
        public void LandingOnGoToJailMovesPlayerToJustVisiting()
        {
            var banker = new Banker();
            var goToJail = new GoToJail("Go To Jail", 30, banker);
            Player player = new Player("Player");
            goToJail.LandOn(player);

            Assert.AreEqual(10, player.Position);
        }
    }
}
