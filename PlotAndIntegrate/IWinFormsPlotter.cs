using APB97.Math;
using System.Drawing;

namespace PlotAndIntegrate
{
    public interface IWinFormsPlotter
    {
        Point CenterPoint { get; set; }
        float Unit { get; set; }

        void DrawAxes(Graphics graphics, int width, int height);
        void DrawGrid(Graphics graphics, int width, int height);
        void DrawPlot(Graphics graphics, IFunction function, int width);
        PointF GetCoordsAtPoint(Point point);
    }
}