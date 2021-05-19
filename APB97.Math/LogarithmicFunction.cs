using System;

namespace APB97.Math
{
    public class LogarithmicFunction : IFunction
    {
        public float LogarithmBase { get; }

        public LogarithmicFunction(float logarithmBase)
        {
            if (logarithmBase is not > 0 or 1)
                throw new ArgumentOutOfRangeException(nameof(logarithmBase), "Logarithm's base mut be a postitive number other than 1");
            LogarithmBase = logarithmBase;
        }

        public float Y(float x)
        {
            if (IsValueOfXCorrect(x))
                return MathF.Log(x, LogarithmBase);
            throw new ArgumentOutOfRangeException(nameof(x), "x must be a positive number");
        }

        public bool IsValueOfXCorrect(float x)
        {
            return x is > 0;
        }
    }
}
