namespace APB97.Math
{
    public interface IIntegrate
    {
        bool TryIntegrate(IFunction function, float fromX, float toX, out float result);
    }
}