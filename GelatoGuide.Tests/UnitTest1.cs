using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GelatoGuide.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(4)]
        public void TestMethod1(int a)
        {

        }
    }
}