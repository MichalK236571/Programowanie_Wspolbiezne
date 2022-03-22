using Microsoft.VisualStudio.TestTools.UnitTesting;
using Współbieżne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Współbieżne.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            int x = 5;
            int y = 12;
           
            Assert.AreEqual(Współbieżne.Program.Add(x, y), 17);
            Assert.AreNotEqual(Współbieżne.Program.Add(x, y), 15);
        }
    }
}