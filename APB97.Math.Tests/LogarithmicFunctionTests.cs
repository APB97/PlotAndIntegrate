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

        [TestCase(2, "-4")]
        [TestCase(2, "-16")]
        [TestCase(2, "1")]
        [TestCase(2, "0")]
        [TestCase(2, "0 1")]
        [TestCase(2, "0 1 3")]
        [TestCase(2, "0", "1", "3")]
        [TestCase(2, "0,1")]
        [TestCase(2, "0,1.3")]
        public void TryPassParameters_IngoresIncorrectInputsTest(float originalBase, params string[] inputs)
        {
            var function = new LogarithmicFunction(originalBase);
            function.TryPassParameters(inputs);
            Assert.AreEqual(originalBase, function.LogarithmBase);
        }

        [TestCase(4, "4")]
        [TestCase(16, "16")]
        [TestCase(3, "3")]
        [TestCase(3.1416f, "3.1416")]
        [TestCase(1.414f, "1.414")]
        [TestCase(2.75f, "2.75")]
        [TestCase(1.00001f, "1.00001")]
        [TestCase(0.99999f, "0.99999")]
        public void TryPassParameters_AcceptsCorrectInputsTest(float expectedBase, params string[] inputs)
        {
            var function = new LogarithmicFunction(2);
            function.TryPassParameters(inputs);
            Assert.AreEqual(expectedBase, function.LogarithmBase);
        }
    }
}
