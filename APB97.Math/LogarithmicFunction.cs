using System;
using System.Globalization;

namespace APB97.Math
{
    public class LogarithmicFunction : IFunction
    {
        private float logarithmBase = 2;

        public float LogarithmBase
        {
            get => logarithmBase;
            set
            {
                if (logarithmBase is > 0 and not 1)
                    logarithmBase = value;
            }
        }

        public LogarithmicFunction(float logarithmBase)
        {
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

        public override string ToString()
        {
            return nameof(LogarithmicFunction);
        }

        public object Clone()
        {
            return new LogarithmicFunction(LogarithmBase);
        }

        public bool TryPassParameters(string[] splitBySpace)
        {
            if (splitBySpace.Length is not 1 || !float.TryParse(splitBySpace[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float param))
                return false;
            LogarithmBase = param;
            return true;
        }

        public string FormatAsString()
        {
            return $"log_{logarithmBase}(x)";
        }
    }
}
