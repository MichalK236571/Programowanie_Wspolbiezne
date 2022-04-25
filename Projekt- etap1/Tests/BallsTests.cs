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
        private LogicAbstactAPI _logic = LogicAbstactAPI.CreateApi(500, 1000);

        [TestMethod()]
        public void init()
        {
            Assert.AreEqual(0, _logic.GetAllBalls().Count);
        }

        [TestMethod()]
        public void CreateBall()
        {
            _logic.generateBalls();
            Assert.AreEqual(1, _logic.GetAllBalls().Count);
        }

        [TestMethod()]
        public void NoneBall()
        {
            _logic.generateBalls();
            Assert.AreNotEqual(0, _logic.GetAllBalls().Count);
        }

        [TestMethod()]
        public void MakeBalls()
        {
            _logic.makeBalls(10);
            Assert.AreEqual(10, _logic.GetAllBalls().Count);
        }

        [TestMethod()]
        public void RemoveBalls()
        {
            _logic.makeBalls(10);
            Assert.AreEqual(10, _logic.GetAllBalls().Count);
            _logic.RemoveAllBalls();
            Assert.AreEqual(0, _logic.GetAllBalls().Count);
        }
        [TestMethod()]
        public void BounceAndMoveTest()
        {
            
            //Ball ball = new Ball(5, 5, 5, -2, -2);
            _logic.AddBallToList(5, 5, 5, -2, -2);
            Ball ball = _logic.GetBall(0);
            _logic.BounceAndMove();
            Assert.AreEqual(ball.XValue, 7);
            Assert.AreEqual(ball.YValue, 7);

        }


        /* [TestMethod()]
         public void makeCircleTest()
         {
             BallsManager screen = new BallsManager(100, 150);
             screen.makeCircles(10);
             Assert.AreEqual(10, screen.GetCircles().Count());
         }

         */




    }
}