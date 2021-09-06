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
        private IIntegrate _integrator;
        private IFunction _function = new PolynomialFunction(1, -2, 1, -4);
        private bool _mousePressedOnPlot = false;
        private Point _lastCenterPoint;
        private Point _pressedAtLocation;

        public FormPlot(IControlToBitmap controlToBitmap, IWinFormsPlotter plotter, IIntegrate integrateMethod)
        {
            InitializeComponent();
            _controlToBitmap = controlToBitmap;
            _plotter = plotter;
            _integrator = integrateMethod;
            _controlToBitmap.ControlToSaveBitmapFor = pictureBoxPlot;
            pictureBoxPlot.MouseWheel += PictureBoxPlot_MouseWheel;
            _lastCenterPoint = _plotter.CenterPoint = new(45, 42);
            textBoxUnit.Text = _plotter.Unit.ToString(CultureInfo.InvariantCulture);
            numericFontSize.Value = (decimal)plotter.FontSizeInPoints;
            textBoxFunction.Text = _function.FormatAsString();
        }

        private void PictureBoxPlot_MouseWheel(object sender, MouseEventArgs e)
        {
            _plotter.Unit = _plotter.Unit * (Math.Sign(e.Delta) == 1 ? 1/1.1f : 1.1f);
            textBoxUnit.Text = _plotter.Unit.ToString(CultureInfo.InvariantCulture);
            pictureBoxPlot.Invalidate();
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
        }

        private void PictureBoxPlot_MouseMove(object sender, MouseEventArgs e)
        {
            DisplayCoordinates(e.Location);
            MoveCenterIfMousePressed(e.Location);
        }

        private void MoveCenterIfMousePressed(Point location)
        {
            if (!_mousePressedOnPlot) return;
            
            _plotter.CenterPoint = new Point(_lastCenterPoint.X + location.X - _pressedAtLocation.X, _lastCenterPoint.Y + location.Y - _pressedAtLocation.Y);
            pictureBoxPlot.Invalidate();
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
            if (float.TryParse(textBoxUnit.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float unit) && unit > 0)
                _plotter.Unit = unit;
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
                textBoxFunction.Text = _function.FormatAsString();
                pictureBoxPlot.Invalidate();
            }
        }

        private void NumericFontSize_ValueChanged(object sender, EventArgs e)
        {
            _plotter.FontSizeInPoints = (float)numericFontSize.Value;
            pictureBoxPlot.Invalidate();
        }

        private void PictureBoxPlot_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePressedOnPlot = true;
            _pressedAtLocation = e.Location;
        }

        private void PictureBoxPlot_MouseUp(object sender, MouseEventArgs e)
        {
            _mousePressedOnPlot = false;
            _lastCenterPoint = _plotter.CenterPoint;
        }

        private void ButtonIntegrate_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBoxFrom.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float fromX) &&
                float.TryParse(textBoxTo.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float toX) &&
                _function.IsValueOfXCorrect(fromX) &&
                _function.IsValueOfXCorrect(toX) &&
                _integrator.TryIntegrate(_function, fromX, toX, out float result))
            {
                textBoxResult.Text = result.ToString("F4", CultureInfo.InvariantCulture);
            }
            else
                MessageBox.Show("Application couldn't calculate the integral. Ensure all inputs are correct and the calculation is possible.");
        }

        private void NumericPlotWidth_ValueChanged(object sender, EventArgs e)
        {
            _plotter.PlotWidth = (float)numericPlotWidth.Value;
            pictureBoxPlot.Invalidate();
        }

        private void ButtonPlotColor_Click(object sender, EventArgs e)
        {
            using ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            buttonPlotColor.BackColor = _plotter.PlotColor = colorDialog.Color;
            pictureBoxPlot.Invalidate();
        }
    }
}
