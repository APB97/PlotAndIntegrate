using NUnit.Framework;
using System;

namespace APB97.Math.Tests
{
    public class LogarithmicFunctionTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(float.MinValue)]
        [TestCase(-float.Epsilon)]
        public void LogarithmBase_DoesNotApplyIncorrectValuesTest(float logBase)
        {
            var function = new LogarithmicFunction(2);
            function.LogarithmBase = logBase;
            Assert.AreNotEqual(logBase, function.LogarithmBase);
        }

        [TestCase(4)]
        [TestCase(16)]
        [TestCase(MathF.PI)]
        [TestCase(MathF.E)]
        [TestCase(1 + 1E-5f)]
        [TestCase(1 - 1E-5f)]
        [TestCase(1E-5f)]
        public void LogarithmBase_AppliesCorrectValuesTest(float logBase)
        {
            var function = new LogarithmicFunction(2);
            function.LogarithmBase = logBase;
            Assert.AreEqual(logBase, function.LogarithmBase);
        }
    }
}
