using APB97.Features;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static APB97.Math.FunctionFormatter;

namespace APB97.Math
{
    public class PolynomialFunction : IFunction
    {
        public PolynomialFunction() => Coefficients = System.Array.Empty<float>();

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
            return FeatureManager.IsEnabled(FeaturesList.FunctionsFactory) ? FormatAsString() : nameof(PolynomialFunction);
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
                if (!float.TryParse(item, NumberStyles.Float, CultureInfo.InvariantCulture, out float param))
                    return false;
                parameters.Add(param);
            }
            Coefficients = parameters.ToArray();
            return true;
        }

        public string FormatAsString()
        {
            IEnumerable<(float First, int Second)> coefficientPowerPairs = Coefficients.Zip(Enumerable.Range(0, Coefficients.Length).Reverse());
            IEnumerable<string> formattedWithoutZerosAndEmpties = coefficientPowerPairs.Select(SelectAsString).Where(s => !string.IsNullOrEmpty(s) && s != "0");
            string joinedElements = string.Join(string.Empty, formattedWithoutZerosAndEmpties);
            return string.IsNullOrEmpty(joinedElements) ? "0" : joinedElements;
        }

        private string SelectAsString((float coefficient, int powerOfX) tuple)
        {
            return FormatCoefficientWithPower(tuple.coefficient, "x", tuple.powerOfX, Coefficients.Length - 1);
        }
    }
}
