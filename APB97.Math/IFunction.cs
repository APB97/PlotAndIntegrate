using System;

namespace APB97.Math
{
    public interface IFunction : ICloneable
    {
        bool IsValueOfXCorrect(float x);
        float Y(float x);
        bool TryPassParameters(string[] splitBySpace);
    }
}
