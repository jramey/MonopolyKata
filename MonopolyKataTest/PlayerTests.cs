using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest
{
    [TestClass]
    public class PlayerTests
    {
        Player player;

        [TestInitialize]
        public void CreatePlayer()
        {
            player = new Player();
        }

        [TestMethod]
        public void StartingPoistionIsZero()
        {
            Assert.AreEqual(0, player.Position);
        }

        [TestMethod]
        public void MoveSevenFromZeroEndsOnSeven()
        {
            player.MovePlayer(7);
            Assert.AreEqual(7, player.Position);
        }

        [TestMethod]
        public void MoveSixFromThirtyNigeEndsOnFive()
        {
            player.MovePlayer(39);
            player.MovePlayer(6);
            Assert.AreEqual(5, player.Position);
        }
    }
}
