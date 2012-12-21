using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest
{
    [TestClass]
    public class MoverUnitTests
    {
        Mover mover;
        Player Car;

        [TestInitialize]
        public void SetupMover()
        {
            mover = new Mover();
            Car = new Player("Car");
        }

        [TestMethod]
        public void PlayerRollsDiceFromStartingPositionAndPositionIsCorrect()
        {
            mover.PlayerRolls();
            mover.MovePlayerOnBoard(Car);
            var expectedPostion = mover.GetCurrentRollForPlayer();

            Assert.AreEqual(expectedPostion, Car.Position);
        }
    }
}