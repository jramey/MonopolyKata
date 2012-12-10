using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest
{
    [TestClass]
    public class PlayerUnitTests
    {
        Player Car;
        Player Horse;

        [TestInitialize]
        public void CreatePlayer()
        {
            Car = new Player("Car");
            Horse = new Player("Horse");
        }

        [TestMethod]
        public void StartingPoistionIsZero()
        {
            Assert.AreEqual(0, Car.Position);
        }

        [TestMethod]
        public void StartingBalanceIsFifthteenHundred()
        {
            Assert.AreEqual(1500, Car.Balance);
        }
    }
}
