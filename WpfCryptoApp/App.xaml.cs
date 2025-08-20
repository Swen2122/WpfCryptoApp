using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfCryptoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Frame MainFrame { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
