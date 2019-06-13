using System;
using System.ServiceModel;
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

        [TestMethod]
        public void TestFiboLowerThan0ShouldReturnException()
        {
            ServiceReference1.mainSoapClient mainSoapClient = new ServiceReference1.mainSoapClient();
            Assert.ThrowsException<FaultException>(() => mainSoapClient.Fibonacci(-10));
        }

        [TestMethod]
        public void TestFiboGreaterThan100ShouldReturnException()
        {
            ServiceReference1.mainSoapClient mainSoapClient = new ServiceReference1.mainSoapClient();
            Assert.ThrowsException<FaultException>(() => mainSoapClient.Fibonacci(101));
        }
    }
}
