using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Sprint3_Tests
    {
        //Matthew 
        [TestMethod]
        public void Add1to1ShouldEqual2()
        {
            int x = 1;
            int y = x + 1;
            Assert.AreEqual(x + 1, y);
        }
    }
}
