using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Screen = System.Windows.Forms.Screen;

namespace NotReady
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();

            int screenIndex = e.Args.Any(arg => arg.StartsWith("-scr=")) ? int.Parse(e.Args.First(arg => arg.StartsWith("-scr=")).Substring(5)) : 0;
            Screen screen = Screen.AllScreens[screenIndex];
            mainWindow.Left = screen.Bounds.Left;
            mainWindow.Top = screen.Bounds.Top;
            mainWindow.Width = screen.Bounds.Width;
            mainWindow.Height = screen.Bounds.Height;

            MainWindow = mainWindow;
            mainWindow.Show();

            mainWindow.WindowState = WindowState.Maximized;
        }
    }
}
