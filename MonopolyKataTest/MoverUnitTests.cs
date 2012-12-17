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
        Game game;
        Mover mover;
        Player Car;
        Player Horse;

        [TestInitialize]
        public void SetupMover()
        {
            game = new Game();
            mover = new Mover();
            Car = new Player("Car");
            Horse = new Player("Horse");
        }

        [TestMethod]
        public void PlayerRollsDiceFromStartingPositionAndPositionIsCorrect()
        {
            mover.PlayerRolls();
            mover.MovePlayerOnBoard(Car);
            var expectedPostion = mover.GetCurrentRollForPlayer();

            Assert.AreEqual(expectedPostion, Car.Position);
        }
 
        [TestMethod]
        public void LandingOnGoIncreaseBalanceByTwoHundres()
        {
            mover.SetSpacesToMove(40);
            mover.MovePlayerOnBoard(Car);
            var exprectBalance = 1700;

            Assert.AreEqual(exprectBalance, Car.Balance);
        }

        [TestMethod]
        public void PassingGoIncreaseBalanceByTwoHundred()
        {
            mover.SetSpacesToMove(20);
            mover.MovePlayerOnBoard(Car);
            mover.SetSpacesToMove(21);
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 1700;

            Assert.AreEqual(expectedBalance, Car.Balance);
        }

        [TestMethod]
        public void LandingOnGoToJailMovesPlayerToJustVisiting()
        {
            mover.SetSpacesToMove(30);
            mover.MovePlayerOnBoard(Car);
            var expectedPosition = 10;

            Assert.AreEqual(expectedPosition, Car.Position);
        }

        [TestMethod]
        public void PassingOverGoIncreaseBalanceByFourHundred()
        {
            mover.SetSpacesToMove(20);
            mover.MovePlayerOnBoard(Car);
            mover.SetSpacesToMove(21);
            mover.MovePlayerOnBoard(Car);
            mover.SetSpacesToMove(21);
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 1900;

            Assert.AreEqual(expectedBalance, Car.Balance);
        }

        [TestMethod]
        public void LandingOnANormalSpaceDoesNotChangePosition()
        {
            mover.SetSpacesToMove(20);
            mover.MovePlayerOnBoard(Car);
            var expectedPosition = 20;

            Assert.AreEqual(expectedPosition, Car.Position);
        }

        [TestMethod]
        public void LandingOnTimcomeTaxWithTotalWorthOfEighteenHundredDecreaseBalanceByOneHundredEight()
        {
            Car.ModifyPlayerBalance(300);
            var currentBalance = Car.Balance;
            mover.SetSpacesToMove(4);
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 1620;

            Assert.AreEqual(currentBalance - expectedBalance, 180);
        }

        [TestMethod]
        public void LandingOnTimcomeTaxWithTotalWorthOfTwentyTwoHundredDecreaseBalanceByTwonHundred()
        {
            Car.ModifyPlayerBalance(700);
            var currentBalance = Car.Balance;
            mover.SetSpacesToMove(4);
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 2000;

            Assert.AreEqual(currentBalance - expectedBalance, 200);
        }

        [TestMethod]
        public void LandingOnTimcomeTaxWithTotalWorthOfTwoThousandDecreaseBalanceByTwonHundred()
        {
            Car.ModifyPlayerBalance(500);
            var currentBalance = Car.Balance;
            mover.SetSpacesToMove(4);
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 1800;

            Assert.AreEqual(currentBalance - expectedBalance, 200);
        }

        [TestMethod]
        public void LandingOnTimcomeTaxWithTotalWorthOfZeroDecreaseBalanceByZero()
        {
            Car.ModifyPlayerBalance(-1500);
            mover.SetSpacesToMove(4);
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 0;

            Assert.AreEqual(expectedBalance, Car.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverIncomeTaxBalanceIsNotDecreased()
        {
            mover.SetSpacesToMove(5);
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 1500;

            Assert.AreEqual(expectedBalance, Car.Balance);
        }

        [TestMethod] 
        public void LandingOnLuxuryTaxDecreasesBalanceBySeventyFive()
        {
            mover.SetSpacesToMove(38);
            var currentBalance = Car.Balance;
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 1425;

            Assert.AreEqual(currentBalance - expectedBalance, 75);
        }

        [TestMethod]
        public void PassingByLuxuryTaxDoesNotDecreasesBalance()
        {
            mover.SetSpacesToMove(39);
            mover.MovePlayerOnBoard(Car);
            var expectedBalance = 1500;

            Assert.AreEqual(expectedBalance, Car.Balance);
        }
    }
}

