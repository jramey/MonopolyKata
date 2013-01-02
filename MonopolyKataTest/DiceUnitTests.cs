using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest
{
    [TestClass]
    public class DiceUnitTests
    {
        private FakeDice fakeDice;
        private Dice dice;

        [TestInitialize]
        public void SetupDice()
        {
            fakeDice = new FakeDice();
            dice = new Dice();
        }

        [TestMethod]
        public void AllPossibleValuesAreRolled()
        {
            var rolledValues = new List<Int32>();

            for (var i = 0; i < 100; i++)
            {
                dice.Roll();
                rolledValues.Add(dice.CurrentRoll);
            }

            Assert.AreEqual(11, rolledValues.Distinct().Count());
        }

        [TestMethod]
        public void RollingDoublesSetIsDoublesToTrue()
        {
            var fakeRolls = new[] { 2, 2 };

            fakeDice.SetFakeRolls(fakeRolls);
            fakeDice.Roll();

            Assert.IsTrue(fakeDice.IsDoubles);
        }

        [TestMethod]
        public void NotRollingDoubleDoesNotSetIsDoublesToTrue()
        {
            var fakeRolls = new[] { 2, 3 };

            fakeDice.SetFakeRolls(fakeRolls);
            fakeDice.Roll();

            Assert.IsFalse(fakeDice.IsDoubles);
        }
    }
}
