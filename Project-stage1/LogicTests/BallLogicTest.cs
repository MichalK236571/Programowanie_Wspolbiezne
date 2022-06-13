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
            BallLogicAPI ball = BallLogicAPI.CreateBall(10, 10, 15);
            Assert.AreEqual(10, ball.YValue);
            Assert.AreEqual(10, ball.XValue);
            Assert.AreEqual(15, ball.Radius);


        }

        [TestMethod]
        public void Setter_Test()
        {
            BallLogicAPI ball = BallLogicAPI.CreateBall(10, 10, 15);
            ball.XValue = 15;
            ball.YValue = 12;
            Assert.AreEqual(15, ball.XValue);
            Assert.AreEqual(12, ball.YValue);
        }
    }
}
