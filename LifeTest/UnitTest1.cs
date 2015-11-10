using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System.Linq;


namespace LifeTest
{
    [TestClass]
    public class ConstructorBuildsArray
    {
        [TestMethod]
        public void SmallArray()
        {
            RealGameOfLife game = new RealGameOfLife(1);
            bool actual = game.cellStatus(0, 0);
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void bigArray()
        {
            RealGameOfLife game = new RealGameOfLife(11);
            bool actual = game.cellStatus(10, 10);
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }

        public void flipArray()
        {
            RealGameOfLife game = new RealGameOfLife(11);
            bool original = game.cellStatus(10, 10);
            game.Flipper(10, 10);
            bool newValue = game.cellStatus(10, 10);
            Assert.AreNotEqual(original, newValue);
        }

        [TestMethod]
        public void CanCheckNumberOfLiveNeighbors()
        {
            RealGameOfLife game = new RealGameOfLife(3);
            game.Flipper(1, 0);
            game.Flipper(1, 1);
            game.Flipper(1, 2);
            int Nays = game.CheckNeighbors(1, 1);
            Assert.AreEqual(Nays, 2);
        }

        [TestMethod]
        public void TickOnSingleLiveCellKillsCell()
        {
            RealGameOfLife game = new RealGameOfLife(8);
            game.Flipper(0, 0);
            game.Tick();
            Assert.IsFalse(game.cellStatus(0,0));
        }

        [TestMethod]
        public void TickOnThreeByThree()
        {
            RealGameOfLife game = new RealGameOfLife(3);
            game.Flipper(1, 0);
            game.Flipper(1, 1);
            game.Flipper(1, 2);
            game.Tick();
            RealGameOfLife game2 = new RealGameOfLife(3);
            game2.Flipper(0, 1);
            game2.Flipper(1, 1);
            game2.Flipper(2, 1);
            var first = game.GetBoard();
            var second = game2.GetBoard();
            CollectionAssert.AreEqual(first, second);
        }
    }
}
