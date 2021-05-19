using System;

namespace APB97.Math
{
    public class LogarithmicFunction : IFunction
    {
        public LogarithmicFunction(double logarithmBase)
        {
            if (logarithmBase is not > 0 or 1.0)
                throw new ArgumentOutOfRangeException(nameof(logarithmBase), "Logarithm's base mut be a postitive number other than 1");
            LogarithmBase = logarithmBase;
        }

        public double LogarithmBase { get; }

        public double Y(double x)
        {
            if (IsValueOfXCorrect(x))
                return System.Math.Log(x, LogarithmBase);
            throw new ArgumentOutOfRangeException(nameof(x), "x must be a positive number");
        }

        public bool IsValueOfXCorrect(double x)
        {
            return x is > 0;
        }
    }
}
