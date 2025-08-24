
using System.Net.Http;
using System.Windows.Controls;


namespace WpfCryptoApp.Views
{
    /// <summary>
    /// Interaction logic for ErrorPage.xaml
    /// </summary>
    public partial class ErrorPage : Page
    {
        public ErrorPage(HttpRequestException msg)
        {
            InitializeComponent();
            var viewModel = new ViewModels.ErrorViewModel(msg);
            DataContext = viewModel;
        }
    }
}
