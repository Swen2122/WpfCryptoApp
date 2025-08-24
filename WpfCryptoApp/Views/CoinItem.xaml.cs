using System.Globalization;
using System.Windows.Controls;
using WpfCryptoApp.ViewModels;
using WpfCryptoApp.ViewModels.Financial;

namespace WpfCryptoApp.Views
{
    /// <summary>
    /// Interaction logic for CoinItem.xaml
    /// </summary>
    public partial class CoinItem : Page
    {
        public CoinItem(string coinName)
        {
            InitializeComponent();
            var candleStick = new CandleSticksViewModel();

            LoadCandleData(candleStick, coinName);
            DataContext = new
            {
                CandleStick = candleStick
            };
        }
        private async void LoadCandleData(CandleSticksViewModel candleStick, string coinId = "bitcoin")
        {
            await candleStick.LoadDataAsync(coinId);
        }

    }
}
