using System.Collections.Generic;

namespace APB97.Math
{
    public class PolynomialFunction : IFunction
    {
        public PolynomialFunction(params float[] coefficients)
        {
            Coefficients = coefficients;
        }

        public float[] Coefficients { get; private set; }

        public float Y(float x)
        {
            return Horner(x, Coefficients);
        }

        private static float Horner(float x, float[] coefficients)
        {
            float s = 0;
            foreach (float coefficient in coefficients)
                s = s * x + coefficient;
            return s;
        }

        public bool IsValueOfXCorrect(float x)
        {
            return true;
        }

        public override string ToString()
        {
            return nameof(PolynomialFunction);
        }

        public object Clone()
        {
            return new PolynomialFunction(Coefficients.Clone() as float[]);
        }

        public bool TryPassParameters(string[] splitBySpace)
        {
            List<float> parameters = new();
            foreach (var item in splitBySpace)
            {
                if (!float.TryParse(item, out float param))
                    return false;
                parameters.Add(param);
            }
            Coefficients = parameters.ToArray();
            return true;
        }
    }
}
