using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class BallDataTest
    {
        [TestMethod]
        public void Getter_Setter_Test()
        {
            BallDataAPI ballDataAPI = BallDataAPI.CreateBallDataAPI(10, 10, 15, 50, 5, 5);
            Assert.AreEqual(15, ballDataAPI.Radius);
            Assert.AreEqual(5, ballDataAPI.XDirection);
            Assert.AreEqual(5, ballDataAPI.YDirection);
            

            ballDataAPI.XDirection = 0;
            ballDataAPI.YDirection = 1;
            Assert.AreEqual(0, ballDataAPI.XDirection);
            Assert.AreEqual(1, ballDataAPI.YDirection);

        }

        [TestMethod]
        public void XPosition_YPosition_Test()
        {
            BallDataAPI ballDataAPI = BallDataAPI.CreateBallDataAPI(10, 8, 15, 50, 5, 5);
            Assert.AreEqual(10, ballDataAPI.XValue);
            Assert.AreEqual(8, ballDataAPI.YValue);

        }

    }
}
