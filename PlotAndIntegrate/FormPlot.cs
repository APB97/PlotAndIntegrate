using APB97.Math;
using System.Drawing;
using System.Windows.Forms;

namespace PlotAndIntegrate
{
    public partial class FormPlot : Form
    {
        readonly WinFormsPlotter plotter = new();

        IFunction function = new PolynomialFunction(1, -2, 1, -4);

        public FormPlot()
        {
            InitializeComponent();
            plotter.CenterPoint = new(45, 42);
        }

        private void PictureBoxPlot_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var clipRectangle = e.ClipRectangle;
            var width = clipRectangle.Width;
            var height = clipRectangle.Height;

            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            plotter.DrawGrid(graphics, width, height);
            plotter.DrawAxes(graphics, width, height);
            plotter.DrawPlot(graphics, function, width);
            pictureBoxPlot.Invalidate();
        }

        private void PictureBoxPlot_MouseMove(object sender, MouseEventArgs e)
        {
            var p = e.Location;
            textBoxCoordinates.Text = plotter.GetCoordsAtPoint(p).ToString();
        }
    }
}
