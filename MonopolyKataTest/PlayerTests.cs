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
        Player Car;

        [TestInitialize]
        public void CreatePlayer()
        {
            Car = new Player("Car", 0);
        }

        [TestMethod]
        public void StartingPoistionIsZero()
        {
            Assert.AreEqual(0, Car.Position);
        }

        [TestMethod]
        public void MoveSevenFromZeroEndsOnSeven()
        {
            Car.MovePlayer(7);
            Assert.AreEqual(7, Car.Position);
        }

        [TestMethod]
        public void MoveSixFromThirtyNigeEndsOnFive()
        {
            Car.MovePlayer(39);
            Car.MovePlayer(6);
            Assert.AreEqual(5, Car.Position);
        }

        [TestMethod]
        public void MoveSecondPlayerFiveSpaces()
        {
            Player Horse = new Player("Horse", 0);
            var nextPlayer = Horse;
            nextPlayer.MovePlayer(5);

            Assert.AreEqual(5, Horse.Position);

        }
    }
}
