using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace LogicTests
{
    [TestClass]
    public class BallsManagerTest
    {
        [TestMethod]
        public void RemoveAllBalls_GetAllBalls_Test()
        {
            LogicAbstactAPI ballManager = LogicAbstactAPI.CreateApi(150, 150);
            ballManager.CreateBallInRandomPlace();
            Assert.AreEqual(1, ballManager.GetAllBalls().Count);
            ballManager.RemoveAllBalls();
            Assert.AreEqual(0, ballManager.GetAllBalls().Count);
        }

        [TestMethod]
        public void MakeBall_Test()
        {
            LogicAbstactAPI ballManager = LogicAbstactAPI.CreateApi(150, 150);
            BallLogicAPI ball = ballManager.MakeBall(15, 15, 5, 5);
            Assert.AreEqual(15, ball.XValue);
            Assert.AreEqual(15, ball.YValue);

        }
    }




}