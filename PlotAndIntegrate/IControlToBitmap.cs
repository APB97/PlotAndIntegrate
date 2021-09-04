using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PlotAndIntegrate
{
    public interface IControlToBitmap
    {
        Control ControlToSaveBitmapFor { get; set; }

        void SaveToLocation(string location, ImageFormat imageFormat);
    }
}