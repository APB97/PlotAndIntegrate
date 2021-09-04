using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PlotAndIntegrate
{
    public class ControlToBitmap : IControlToBitmap
    {
        public Control ControlToSaveBitmapFor { get; set; }

        public void SaveToLocation(string location, ImageFormat imageFormat)
        {
            if (ControlToSaveBitmapFor == null)
                return;

            Bitmap bitmap = new Bitmap(ControlToSaveBitmapFor.Width, ControlToSaveBitmapFor.Height);
            ControlToSaveBitmapFor.DrawToBitmap(bitmap, new Rectangle(Point.Empty, ControlToSaveBitmapFor.Size));
            bitmap.Save(location, imageFormat);
        }
    }
}
