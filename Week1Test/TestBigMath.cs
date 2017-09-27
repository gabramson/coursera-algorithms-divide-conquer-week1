using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week1;

namespace Week1Test
{
    [TestClass]
    public class TestBigMath
    {
        [TestMethod]
        public void TestAddNoCarry()
        {
            Assert.AreEqual<string>("2", BigMath.Add("1","1"));
        }

        [TestMethod]
        public void TestAddWithCarry()
        {
            Assert.AreEqual<string>("12", BigMath.Add("6", "6"));
        }

        [TestMethod]
        public void TestAddMultipleDigits()
        {
            Assert.AreEqual<string>("23", BigMath.Add("11", "12"));
        }
    }
}
