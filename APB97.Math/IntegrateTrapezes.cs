using System;

namespace APB97.Math
{
    public class IntegrateTrapezes : IIntegrate
    {
        public int Steps { get; set; }

        public bool TryIntegrate(IFunction function, float fromX, float toX, out float result)
        {
            float sum = 0f;
            result = 0f;
            float x = fromX;
            float step = (toX - fromX) / Steps;
            for (int i = 1; i <= Steps; i++)
            {
                float nextX = fromX + i * step;
                if (!function.IsValueOfXCorrect(nextX))
                    return false;
                sum += function.Y(x) + function.Y(nextX);
                x = nextX;
            }
            result = sum * 0.5f * step;
            return true;
        }
    }
}
