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
        
        [TestMethod]
        public void TestAddWithCascade()
        {
            Assert.AreEqual<string>("100", BigMath.Add("99", "1"));
        }

        [TestMethod]
        public void TestAddBigNumbers()
        {
            Assert.AreEqual<string>("113414649046", BigMath.Add("42342092773", "71072556273"));
        }

        [TestMethod]
        public void AddToZero()
        {
            Assert.AreEqual<string>("10", BigMath.Add("10", "0"));
            Assert.AreEqual<string>("10", BigMath.Add("0", "10"));
        }

        [TestMethod]
        public void TestMultiplySingleDigits()
        {
            Assert.AreEqual<string>("1", BigMath.Multiply("1", "1"));
        }

        [TestMethod]
        public void TestMultiplyTwoDigitsByOneDigit()
        {
            Assert.AreEqual<string>("10", BigMath.Multiply("10", "1"));
        }

        [TestMethod]
        public void TestMultiplyBigNumbers()
        {
            Assert.AreEqual("300936052184715", BigMath.Multiply("42342093", "7107255"));
        }

        [TestMethod]
        public void TestMultiplyAssignment()
        {
            Assert.AreEqual(
                "8539734222673567065463550869546574495034888535765114961879601127067743044893204848617875072216249073013374895871952806582723184",
                BigMath.Multiply(
                    "3141592653589793238462643383279502884197169399375105820974944592",
                    "2718281828459045235360287471352662497757247093699959574966967627"
                )
            );
        }
    }
}
