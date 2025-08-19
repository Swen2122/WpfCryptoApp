using System;
using System.Windows;
using WpfCryptoApp.Models.CoinGecko;
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
            var candleStick = new CandleSticksViewModel();

            DataContext = new
            {
                TopCoins = viewModel,
                Language = new LanguageViewModel(),
                CandleStick = candleStick
            };
            LoadCandleData(candleStick);

        }
        private async void LoadCandleData(CandleSticksViewModel candleStick)
        {
            await candleStick.LoadDataAsync("bitcoin");
        }
    }
}