using System.Collections.Generic;
using System.Linq;

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

        public string FormatAsString()
        {
            return string.Join(' ',
                Coefficients.Zip(Enumerable.Range(0, Coefficients.Length).Reverse())
                .Select(SelectAsString).Where(s => !string.IsNullOrEmpty(s)));
        }

        private string SelectAsString((float coefficient, int powerOfX) tuple)
        {
            if (Coefficients.Length == 1)
                return $"{tuple.coefficient}";
            if (tuple.coefficient == 0)
                return string.Empty;
            if (tuple.powerOfX != Coefficients.Length - 1 && tuple.coefficient > 0)
                return $"+{tuple.coefficient}{PowerOfXAsString(tuple.powerOfX)}";
            return $"{tuple.coefficient}{PowerOfXAsString(tuple.powerOfX)}";
        }

        private static string PowerOfXAsString(int power)
        {
            if (power == 0)
                return string.Empty;
            if (power == 1)
                return "x";
            return $"x^{power}";
        }
    }
}
