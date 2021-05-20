using APB97.Math;
using System;
using System.Drawing;
using System.Drawing.Imaging;
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
            textBoxUnit.Text = plotter.Unit.ToString();
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
            DisplayCoordinates(e.Location);
        }

        private void DisplayCoordinates(Point point)
        {
            textBoxCoordinates.Text = plotter.GetCoordsAtPoint(point).ToString();
        }

        private void PictureBoxPlot_SizeChanged(object sender, EventArgs e)
        {
            SyncWidth(textBoxCoordinates, pictureBoxPlot);
        }

        private static void SyncWidth(Control target, Control source)
        {
            target.Width = source.Width;
        }

        private void TextBoxUnit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!float.TryParse(textBoxUnit.Text, out float given) || given is <= 0)
                e.Cancel = true;
        }

        private void TextBoxUnit_Validated(object sender, EventArgs e)
        {
            plotter.Unit = float.Parse(textBoxUnit.Text);
        }

        private void ButtonSaveAsImage_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new() { Filter = "PNG files|*.png", OverwritePrompt = false };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new(pictureBoxPlot.Width, pictureBoxPlot.Height);
                pictureBoxPlot.DrawToBitmap(bitmap, new Rectangle(0, 0, Width, Height));
                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }
    }
}
