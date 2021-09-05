using APB97.Math;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

namespace PlotAndIntegrate
{
    public partial class FormPlot : Form
    {
        private readonly IWinFormsPlotter _plotter;
        private readonly IControlToBitmap _controlToBitmap;
        private IFunction _function = new PolynomialFunction(1, -2, 1, -4);

        public FormPlot(IControlToBitmap controlToBitmap, IWinFormsPlotter plotter)
        {
            InitializeComponent();
            _controlToBitmap = controlToBitmap;
            _controlToBitmap.ControlToSaveBitmapFor = pictureBoxPlot;
            _plotter = plotter;
            _plotter.CenterPoint = new(45, 42);
            textBoxUnit.Text = _plotter.Unit.ToString(CultureInfo.InvariantCulture);
            numericFontSize.Value = (decimal)plotter.FontSizeInPoints;
        }

        private void PictureBoxPlot_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var clipRectangle = e.ClipRectangle;
            var width = clipRectangle.Width;
            var height = clipRectangle.Height;

            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _plotter.DrawGrid(graphics, width, height);
            _plotter.DrawAxes(graphics, width, height);
            _plotter.DrawPlot(graphics, _function, width);
            pictureBoxPlot.Invalidate();
        }

        private void PictureBoxPlot_MouseMove(object sender, MouseEventArgs e)
        {
            DisplayCoordinates(e.Location);
        }

        private void DisplayCoordinates(Point point)
        {
            textBoxCoordinates.Text = _plotter.GetCoordsAtPoint(point).ToString();
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
            if (!float.TryParse(textBoxUnit.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float given) || given <= 0)
                e.Cancel = true;
        }

        private void TextBoxUnit_Validated(object sender, EventArgs e)
        {
            _plotter.Unit = float.Parse(textBoxUnit.Text);
        }

        private void ButtonSaveAsImage_Click(object sender, EventArgs e)
        {
            PromptForSaveLocation();
        }

        private void PromptForSaveLocation()
        {
            using SaveFileDialog saveFileDialog = new() { Filter = "PNG files|*.png", OverwritePrompt = false };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                _controlToBitmap.SaveToLocation(saveFileDialog.FileName, ImageFormat.Png);
        }

        private void ButtonPickNewOne_Click(object sender, EventArgs e)
        {
            using FormFunctionPicker picker = new();
            if (picker.ShowDialog() == DialogResult.OK)
            {
                _function = picker.SelectedFunction;
                pictureBoxPlot.Invalidate();
            }
        }

        private void NumericFontSize_ValueChanged(object sender, EventArgs e)
        {
            _plotter.FontSizeInPoints = (float)numericFontSize.Value;
            pictureBoxPlot.Invalidate();
        }
    }
}
