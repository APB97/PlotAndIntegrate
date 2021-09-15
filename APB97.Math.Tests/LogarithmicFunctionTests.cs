using NUnit.Framework;

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
    }
}
