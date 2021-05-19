using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlotAndIntegrate
{
    public partial class FormPlot : Form
    {
        public FormPlot()
        {
            InitializeComponent();
        }

        private void pictureBoxPlot_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var clipRectangle = e.ClipRectangle;
            var width = clipRectangle.Width;
            var height = clipRectangle.Height;

            graphics.Clear(Color.White);
            DrawGrid(graphics, width, height, 10f);
            pictureBoxPlot.Invalidate();
        }

        private void DrawGrid(Graphics graphics, int width, int height, float pixelsPerUnit)
        {
            for (float i = pixelsPerUnit; i < width || i < height; i += pixelsPerUnit)
            {
                graphics.DrawLine(Pens.Black, new PointF(0, i), new PointF(width, i));
                graphics.DrawLine(Pens.Black, new PointF(i, 0), new PointF(i, height));
            }
        }
    }
}
