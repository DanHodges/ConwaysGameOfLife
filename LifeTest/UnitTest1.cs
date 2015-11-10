using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System.Linq;
using System.Collections.Generic;


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

        [TestMethod]
        public void ArrayToListWorksOnAllFalseThreeByThree()
        {
            List<List<bool>> Actual = new List<List<bool>>();
            Actual.Add(new List<bool>(new bool[] { false, false, false }));
            Actual.Add(new List<bool>(new bool[] { false, false, false }));
            Actual.Add(new List<bool>(new bool[] { false, false, false }));
            RealGameOfLife Arrays = new RealGameOfLife(3);
            List<List<bool>> Expected = Arrays.ToList();
            for (int i = 0; i < Expected.Count; i++)
            {
                CollectionAssert.AreEqual(Expected[i], Actual[i]);
            }
        }

        [TestMethod]
        public void Can_Create_Blinker_Pattern()
        {
            RealGameOfLife ExpectedGame = new RealGameOfLife(1);
            ExpectedGame.Pattern_Selector("Blinker");
            RealGameOfLife ActualGame = new RealGameOfLife(5);
            ActualGame.Flipper(1, 2);
            ActualGame.Flipper(2, 2);
            ActualGame.Flipper(3, 2);
            var expected = ExpectedGame.GetBoard();
            var actual = ActualGame.GetBoard();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Create_Toad_Pattern()
        {
            RealGameOfLife ExpectedGame = new RealGameOfLife(1);
            ExpectedGame.Pattern_Selector("Toad");
            RealGameOfLife ActualGame = new RealGameOfLife(6);
            ActualGame.Flipper(2, 3);
            ActualGame.Flipper(2, 4);
            ActualGame.Flipper(2, 5);
            ActualGame.Flipper(3, 2);
            ActualGame.Flipper(3, 3);
            ActualGame.Flipper(3, 4);
            var expected = ExpectedGame.GetBoard();
            var actual = ActualGame.GetBoard();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Create_Beacon_Pattern()
        {
            RealGameOfLife ExpectedGame = new RealGameOfLife(1);
            ExpectedGame.Pattern_Selector("beacon");
            RealGameOfLife ActualGame = new RealGameOfLife(6);
            ActualGame.Flipper(1, 1);
            ActualGame.Flipper(1, 2);
            ActualGame.Flipper(2, 1);
            ActualGame.Flipper(3, 4);
            ActualGame.Flipper(4, 3);
            ActualGame.Flipper(4, 4);
            var expected = ExpectedGame.GetBoard();
            var actual = ActualGame.GetBoard();
            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public static void Throws_Error_On_Dumb_Input()
        {
            RealGameOfLife game = new RealGameOfLife(1);
            game.Pattern_Selector("nemo");
            //ExceptionAssert.Throws<ArgumentException>(() => game.Pattern_Selector("nemo");
        }
    }
}
