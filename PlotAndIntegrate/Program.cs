using APB97.Features;
using APB97.Math;
using System;
using System.IO;
using System.Windows.Forms;

namespace PlotAndIntegrate
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _ = new FeatureManager(Path.Combine(Application.UserAppDataPath, "features.txt"));
            Application.Run(new FormPlot(new ControlToBitmap(), new WinFormsPlotter(), new IntegrateTrapezes { Steps = 100_000 }));
        }
    }
}
