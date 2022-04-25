using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestClass()]
    public class BallsTests
    {
        [TestMethod()]
        public void makeCircleTest()
        {
            BallsManager screen = new BallsManager(100, 150);
            screen.makeCircles(10);
            Assert.AreEqual(10, screen.GetCircles().Count());
        }

        [TestMethod()]
        public void bounceAndMoveTest()
        {
            BallsManager screen = new BallsManager(100, 150);
            Circle circle = new Circle(5, 5, 5, -2, -2);
            screen.GetCircles().Add(circle);
            screen.bounceAndMove();
            Assert.AreEqual(circle.XValue, 7);
            Assert.AreEqual(circle.YValue, 7);

        }




    }
}