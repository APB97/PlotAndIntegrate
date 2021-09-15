using NUnit.Framework;

namespace APB97.Math.Tests
{
    public class FunctionFormatterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("x", 2, "x^2")]
        [TestCase("y", 2, "y^2")]
        [TestCase("x", 3, "x^3")]
        [TestCase("x", 1, "x")]
        [TestCase("y", 1, "y")]
        [TestCase("x", 0, "")]
        [TestCase("y", 0, "")]
        [TestCase("x", -1, "x^(-1)")]
        [TestCase("x", -2, "x^(-2)")]
        public void FormatAsPowerOfTest(string letter, int power, string expected)
        {
            string result = FunctionFormatter.FormatPowerOf(letter, power);
            Assert.AreEqual(expected, result);
        }

        [TestCase(0f, "x", 0, 4, "0")]
        [TestCase(1f, "x", 3, 4, "+1x^3")]
        [TestCase(1f, "x", 4, 4, "1x^4")]
        [TestCase(-1f, "x", 4, 4, "-1x^4")]
        [TestCase(-1f, "x", 3, 4, "-1x^3")]
        public void FormatCoefficientWithPowerTest(float coefficient, string letter, int power, int highestPower, string expected)
        {
            string result = FunctionFormatter.FormatCoefficientWithPower(coefficient, letter, power, highestPower);
            Assert.AreEqual(expected, result);
        }
    }
}