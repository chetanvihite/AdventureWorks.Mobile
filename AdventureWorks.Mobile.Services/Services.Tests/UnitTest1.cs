using System;
using AdventureWorks.Mobile.Services._002_Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connector = new DbConnector();
            connector.Authenticate(8554983722, "cvihite123");

        }
    }
}
