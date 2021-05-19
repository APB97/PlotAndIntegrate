using System.Drawing;

namespace PlotAndIntegrate
{
    public class WinFormsPlotter
    {
        const float ArrowLength = 16f;
        const float ArrowHeight = 8f;
        private readonly Font font = new(FontFamily.GenericMonospace, 12f, FontStyle.Bold);

        public Point CenterPoint { get; set; }

        public Pen ThickerPen { get; private set; } = new Pen(Color.Black, 2f);

        public void DrawGrid(Graphics graphics, int width, int height, int pixelsPerUnit)
        {
            var (startX, startY) = (CenterPoint.X % pixelsPerUnit, CenterPoint.Y % pixelsPerUnit);
            for (float i = startY; i < height; i += pixelsPerUnit)
            {
                graphics.DrawLine(Pens.Black, new PointF(0, i), new PointF(width, i));
            }
            for (float i = startX; i < width; i += pixelsPerUnit)
            {
                graphics.DrawLine(Pens.Black, new PointF(i, 0), new PointF(i, height));
            }
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
    }
}
