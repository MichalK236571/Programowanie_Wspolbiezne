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
    public class ScreenTests
    {
        [TestMethod()]
        public void makeCircleTest()
        {
            Screen screen = new Screen(100, 150);
            screen.makeCircles(10);
            Assert.AreEqual(10, screen.GetCircles().Count());
        }

        [TestMethod()]
        public void bounceAndMoveTest()
        {
            Screen screen = new Screen(100, 150);
            Circle circle = new Circle(5, 5, 5, -2, -2);
            screen.GetCircles().AddCircle(circle);
            screen.bounceAndMove();
            Assert.AreEqual(circle.XValue, 7);
            Assert.AreEqual(circle.YValue, 7);

        }
    }
}