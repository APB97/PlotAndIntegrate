using APB97.Math;
using System.Drawing;

namespace PlotAndIntegrate
{
    public class WinFormsPlotter : IWinFormsPlotter
    {
        private const float ArrowLength = 16f;
        private const float ArrowHeight = 8f;
        private const float DefaultFontSize = 16f;
        private Font _font = new(FontFamily.GenericSansSerif, DefaultFontSize);

        public float FontSizeInPoints { get => _font.SizeInPoints; set => _font = new Font(_font.FontFamily, value); }
        
        public float PixelsPerUnit { get; set; } = 10;

        public float Unit { get; set; } = 1f;

        public Point CenterPoint { get; set; }

        public Pen ThickerPen { get; private set; } = new Pen(Color.Black, 2f);

        public void DrawGrid(Graphics graphics, int width, int height)
        {
            var (startX, startY) = (CenterPoint.X % PixelsPerUnit, CenterPoint.Y % PixelsPerUnit);
            for (float i = startY; i < height; i += PixelsPerUnit)
            {
                graphics.DrawLine(Pens.Gray, new PointF(0, i), new PointF(width, i));
            }
            for (float i = startX; i < width; i += PixelsPerUnit)
            {
                graphics.DrawLine(Pens.Gray, new PointF(i, 0), new PointF(i, height));
            }
        }

        public PointF GetCoordsAtPoint(Point point)
        {
            return new PointF((point.X - CenterPoint.X) / PixelsPerUnit * Unit, (CenterPoint.Y - point.Y) / PixelsPerUnit * Unit);
        }

        public PointF GetPoint(float x, float y)
        {
            return new PointF(CenterPoint.X + x / Unit * PixelsPerUnit, CenterPoint.Y - y / Unit * PixelsPerUnit);
        }

        public void DrawAxes(Graphics graphics, int width, int height)
        {
            var (x, y) = (CenterPoint.X, CenterPoint.Y);

            graphics.DrawLine(ThickerPen, new PointF(0, y), new PointF(width, y));
            graphics.DrawLine(ThickerPen, new PointF(x, 0), new PointF(x, height));

            graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(width, y), new PointF(width - ArrowLength, y + ArrowHeight), new PointF(width - ArrowLength, y - ArrowHeight) });
            graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(x, height), new PointF(x + ArrowHeight, height - ArrowLength), new PointF(x - ArrowHeight, height - ArrowLength) });

            graphics.DrawString("y", _font, Brushes.Black, new PointF(x + ArrowLength, height - 2 * _font.SizeInPoints));
            graphics.DrawString("x", _font, Brushes.Black, new PointF(width - _font.SizeInPoints, y - _font.SizeInPoints - ArrowLength));
        }

        public void DrawPlot(Graphics graphics, IFunction function, int width)
        {
            float xMin = GetCoordsAtPoint(new Point(0, 0)).X;
            float xMax = GetCoordsAtPoint(new Point(width, 0)).X;

            PointF? p = null;
            if (function.IsValueOfXCorrect(xMin))
                p = new PointF(xMin, function.Y(xMin));
            float step = Unit / PixelsPerUnit;
            for (float x = xMin + step; x <= xMax; x += step)
            {
                p = TryConnectNextPoint(graphics, function, p, x);
            }
        }

        private PointF? TryConnectNextPoint(Graphics graphics, IFunction function, PointF? currentPoint, float x)
        {
            if (function.IsValueOfXCorrect(x))
            {
                PointF nextPoint = GetPoint(x, function.Y(x));
                if (currentPoint.HasValue)
                    graphics.DrawLine(Pens.Blue, currentPoint.Value, nextPoint);
                return nextPoint;
            }
            return null;
        }
    }
}
