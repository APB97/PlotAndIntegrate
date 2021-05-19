using System.Drawing;
using System.Windows.Forms;

namespace PlotAndIntegrate
{
    public partial class FormPlot : Form
    {
        readonly WinFormsPlotter plotter = new();

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
            plotter.DrawGrid(graphics, width, height, 10);
            plotter.DrawAxes(graphics, width, height);
            pictureBoxPlot.Invalidate();
        }
    }
}
