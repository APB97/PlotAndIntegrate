using APB97.Math;
using System.Drawing;

namespace PlotAndIntegrate
{
    public class WinFormsPlotter
    {
        const float ArrowLength = 16f;
        const float ArrowHeight = 8f;
        private readonly Font font = new(FontFamily.GenericMonospace, 12f, FontStyle.Bold);

        public float PixelsperUnit { get; set; } = 10;

        public float Unit { get; set; } = 1f;

        public Point CenterPoint { get; set; }

        public Pen ThickerPen { get; private set; } = new Pen(Color.Black, 2f);

        public void DrawGrid(Graphics graphics, int width, int height)
        {
            var (startX, startY) = (CenterPoint.X % PixelsperUnit, CenterPoint.Y % PixelsperUnit);
            for (float i = startY; i < height; i += PixelsperUnit)
            {
                graphics.DrawLine(Pens.Black, new PointF(0, i), new PointF(width, i));
            }
            for (float i = startX; i < width; i += PixelsperUnit)
            {
                graphics.DrawLine(Pens.Black, new PointF(i, 0), new PointF(i, height));
            }
        }

        public PointF GetCoordsAtPoint(Point point)
        {
            return new PointF((point.X - CenterPoint.X) / PixelsperUnit * Unit, (CenterPoint.Y - point.Y) / PixelsperUnit * Unit);
        }

        public PointF GetPoint(float x, float y)
        {
            return new PointF(CenterPoint.X + x / Unit * PixelsperUnit, CenterPoint.Y - y / Unit * PixelsperUnit);
        }

        public void DrawAxes(Graphics graphics, int width, int height)
        {
            var (x, y) = (CenterPoint.X, CenterPoint.Y);

            graphics.DrawLine(ThickerPen, new PointF(0, y), new PointF(width, y));
            graphics.DrawLine(ThickerPen, new PointF(x, 0), new PointF(x, height));
            
            graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(width, y), new PointF(width - ArrowLength, y + ArrowHeight), new PointF(width - ArrowLength, y - ArrowHeight) });
            graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(x, height), new PointF(x + ArrowHeight, height - ArrowLength), new PointF(x - ArrowHeight, height - ArrowLength) });

            graphics.DrawString("y", font, Brushes.Black, new PointF(x + 12f, height - 16f));
            graphics.DrawString("x", font, Brushes.Black, new PointF(width - 16f, y - 24f));
        }

        public void DrawPlot(Graphics graphics, IFunction function, int width)
        {
            float xMin = GetCoordsAtPoint(new Point(0, 0)).X;
            float XMax = GetCoordsAtPoint(new Point(width, 0)).X;

            var p = new PointF(xMin, function.Y(xMin));
            for (float x = xMin + 0.1f; x <= XMax; x += 0.1f)
            {
                var pNext = GetPoint(x, function.Y(x));
                graphics.DrawLine(Pens.Blue, p, pNext);
                p = pNext;
            }
        }
    }
}
