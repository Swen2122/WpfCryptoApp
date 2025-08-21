using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace WpfCryptoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Frame MainFrame { get; private set; }
        public static Frame HomeFrame { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        }
        public static void SetHomePage(Frame frame)
        {
            HomeFrame = frame;
        }
        public static void SetMainPage(Frame frame)
        {
            MainFrame = frame;
        }
    }
}
