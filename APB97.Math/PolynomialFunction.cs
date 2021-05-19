namespace APB97.Math
{
    public class PolynomialFunction : IFunction
    {
        public PolynomialFunction(params float[] coefficients)
        {
            Coefficients = coefficients;
        }

        public float[] Coefficients { get; }

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
    }
}
