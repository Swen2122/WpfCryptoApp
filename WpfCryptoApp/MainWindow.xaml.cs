using System.Windows;
using WpfCryptoApp.ViewModels;
using WpfCryptoApp.ViewModels.CoinCapViewModels;
using WpfCryptoApp.ViewModels.Financial;

namespace WpfCryptoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var viewModel = new CoinViewModel();
            viewModel.LoadData();
            var candleStickViewModel = new CandlesticksViewModel();
            
            DataContext = new
            {
                TopCoins = viewModel,
                Language = new LanguageViewModel(),
            };
        }
    }
}