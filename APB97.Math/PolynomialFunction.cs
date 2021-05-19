namespace APB97.Math
{
    public class PolynomialFunction : IFunction
    {
        public PolynomialFunction(params double[] coefficients)
        {
            Coefficients = coefficients;
        }

        public double[] Coefficients { get; }

        public double Y(double x)
        {
            return Horner(x, Coefficients);
        }

        private static double Horner(double x, double[] coefficients)
        {
            double s = 0;
            foreach (double coefficient in coefficients)
                s = s * x + coefficient;
            return s;
        }

        public bool IsValueOfXCorrect(double x)
        {
            return true;
        }
    }
}
