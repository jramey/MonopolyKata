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
        private Mover mover;
        private Player Car;
        private Dice dice;
        private Banker banker;
        private Board board;

        [TestInitialize]
        public void SetupMover()
        {
            dice = new Dice();
            banker = new Banker();
            board = new Board(banker, dice);
            mover = new Mover(dice, banker, board);
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