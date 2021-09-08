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
        private Pen _plotPen = new(Color.Blue, 2f);

        public float FontSizeInPoints { get => _font.SizeInPoints; set => _font = new Font(_font.FontFamily, value); }
        
        public float PixelsPerUnit { get; set; } = 10;

        public float Unit { get; set; } = 1f;

        public Point CenterPoint { get; set; }

        public Pen ThickerPen { get; private set; } = new Pen(Color.Black, 2f);

        public Color PlotColor { get => _plotPen.Color; set => _plotPen.Color = value; }

        public float PlotWidth { get => _plotPen.Width; set => _plotPen.Width = value; }

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
            DrawAxesLines(graphics, width, height, x, y);
            DrawHorizontalArrowWhenAdequate(graphics, width, x, y);
            DrawVerticalArrowWhenAdequate(graphics, height, x, y);
            DrawAxesLabels(graphics, width, height, x, y);
        }

        private void DrawAxesLines(Graphics graphics, int controlWidth, int controlHeight, int x, int y)
        {
            graphics.DrawLine(ThickerPen, new PointF(0, y), new PointF(controlWidth, y));
            graphics.DrawLine(ThickerPen, new PointF(x, 0), new PointF(x, controlHeight));
        }

        private static void DrawHorizontalArrowWhenAdequate(Graphics graphics, int controlWidth, int x, int y)
        {
            if (x <= controlWidth - ArrowLength)
                graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(controlWidth, y), new PointF(controlWidth - ArrowLength, y + ArrowHeight), new PointF(controlWidth - ArrowLength, y - ArrowHeight) });
        }

        private static void DrawVerticalArrowWhenAdequate(Graphics graphics, int controlHeight, int x, int y)
        {
            if (y <= controlHeight - ArrowLength)
                graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(x, controlHeight), new PointF(x + ArrowHeight, controlHeight - ArrowLength), new PointF(x - ArrowHeight, controlHeight - ArrowLength) });
        }

        private void DrawAxesLabels(Graphics graphics, int controlWidth, int controlHeight, int x, int y)
        {
            graphics.DrawString("y", _font, Brushes.Black, new PointF(x + ArrowLength, controlHeight - 2 * _font.SizeInPoints));
            graphics.DrawString("x", _font, Brushes.Black, new PointF(controlWidth - _font.SizeInPoints, y - _font.SizeInPoints - ArrowLength));
        }

        public void DrawPlot(Graphics graphics, IFunction function, int width)
        {
            float xMin = GetCoordsAtPoint(new Point(0, 0)).X;
            float xMax = GetCoordsAtPoint(new Point(width, 0)).X;

            PointF? p = null;
            if (function.IsValueOfXCorrect(xMin))
                p = GetPoint(xMin, function.Y(xMin));
            float step = Unit / PixelsPerUnit;
            for (float x = xMin; x <= xMax; x += step)
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
                    graphics.DrawLine(_plotPen, currentPoint.Value, nextPoint);
                return nextPoint;
            }
            return null;
        }
    }
}
