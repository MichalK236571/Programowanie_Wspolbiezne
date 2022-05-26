using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;



namespace LogicTests
{
    [TestClass]
    public class BallLogicTest
    {
        [TestMethod]
        public void CreateBall_Test()
        {
            BallLogicAPI ball = BallLogicAPI.CreateBall(10, 10, 15, 10, 2, 2);
            Assert.AreEqual(10, ball.XValue);
            Assert.AreEqual(10, ball.YValue);
            Assert.AreEqual(15, ball.Radius);
            Assert.AreEqual(10, ball.Weight);
            Assert.AreEqual(2,ball.XDirection);
            Assert.AreEqual(2,ball.YDirection);
        }

        [TestMethod]
        public void Setter_Test()
        {
            BallLogicAPI ball = BallLogicAPI.CreateBall(10, 10, 15, 10, 2, 2);
            ball.XValue = 15;
            Assert.AreEqual(15, ball.XValue);  
        }
    }
}
