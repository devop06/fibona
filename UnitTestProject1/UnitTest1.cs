using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFibo10()
        {
            ServiceReference1.mainSoapClient mainSoapClient = new ServiceReference1.mainSoapClient();
            Assert.AreEqual(55, mainSoapClient.Fibonacci(10));
        }
    }
}
