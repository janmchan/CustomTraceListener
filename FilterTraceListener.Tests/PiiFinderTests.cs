using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilteredTraceListener;

namespace FilterTraceListener.Tests
{
    [TestClass]
    public class PiiFinderTests
    {
        [TestMethod]
        public void GetPiiList_ReturnsPiiList()
        {
            var result = PiiFinder.GetPiiFields();
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
            Assert.IsTrue(result.Contains("Password"));
        }
    }
}
