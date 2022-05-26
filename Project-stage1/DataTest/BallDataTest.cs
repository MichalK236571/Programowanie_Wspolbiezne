using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void Getter_Setter_Test()
        {
            BallDataAPI ballDataAPI = BallDataAPI.CreateBallDataAPI(10,10,15,50,5,5);
            Assert.AreEqual(15, ballDataAPI.Radius);
            Assert.AreEqual(50, ballDataAPI.Weight);
            Assert.AreEqual(5, ballDataAPI.XDirection);
            Assert.AreEqual(5, ballDataAPI.YDirection);

            ballDataAPI.XValue = 15;
            ballDataAPI.YValue = 15;
            Assert.AreEqual(15, ballDataAPI.XValue);
            Assert.AreEqual(15, ballDataAPI.YValue);
        }

    }
}
