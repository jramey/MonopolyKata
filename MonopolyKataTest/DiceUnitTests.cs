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
        Dice dice;

        [TestInitialize]
        public void SetupDice()
        {
            dice = new Dice();
        }

        [TestMethod]
        public void DiceRollsAreRandom()
        {
            var listOfRolls = new List<Int32>();
            for(int i = 0; i < 100; i++)
            {
                dice.Roll();
                listOfRolls.Add(dice.GetRoll());
            }

            Assert.AreEqual(11, listOfRolls.Distinct().Count());
        }
    }
}
