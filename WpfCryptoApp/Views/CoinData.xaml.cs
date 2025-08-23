using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfCryptoApp.ViewModels;
using WpfCryptoApp.ViewModels.Financial;

namespace WpfCryptoApp.Views
{
    /// <summary>
    /// Interaction logic for CoinData.xaml
    /// </summary>
    public partial class CoinData : Page
    {
        public CoinData(string id)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Coin ID cannot be null or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var viewModel = new CoinDataViewModel();
            DataContext = viewModel;
            LoadData(viewModel, id);
        }
        private async void LoadData(CoinDataViewModel viewModel, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Coin ID cannot be null or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            await viewModel.LoadDataAsyn(id);
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
