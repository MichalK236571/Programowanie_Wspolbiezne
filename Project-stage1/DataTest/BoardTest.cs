using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void CreateBall_Test()
        {
            BoardAPI boardAPI = BoardAPI.createAPI(20, 20);
            boardAPI.createDataBallAPI(10, 10, 10, 10);
            Assert.AreEqual(1, boardAPI.getBalls().Count);
        }

        [TestMethod]
        public void createAPI_Test()
        {
            BoardAPI boardAPI = BoardAPI.createAPI(20, 20);
            Assert.AreEqual(20,boardAPI.Width);
            Assert.AreEqual(20,boardAPI.Height);
        }
    }
}