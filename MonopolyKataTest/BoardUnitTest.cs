using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest
{
    [TestClass]
    public class BoardUnitTest
    {
        Board board;

        [TestInitialize]
        public void CreateBoard()
        {
            board = new Board();
        }

        [TestMethod]
        public void SpaceGoIsAtZeroIndex()
        {
            Assert.IsTrue(board.GetSpaceAtLocation(0).GetType() == typeof(Go));
        }

        [TestMethod]
        public void GoToJailIsAtIndexThirty()
        {
            Assert.IsTrue(board.GetSpaceAtLocation(30).GetType() == typeof(GoToJail));
        }

        [TestMethod]
        public void IncomeTaxIsAtIndexFour()
        {
            Assert.IsTrue(board.GetSpaceAtLocation(4).GetType() == typeof(IncomeTax));
        }

        [TestMethod]
        public void LuxurytaxIsAtIndexThirtyEight()
        {
            Assert.IsTrue(board.GetSpaceAtLocation(38).GetType() == typeof(LuxuryTax));
        }
    }
}
