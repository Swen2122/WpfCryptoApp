using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCryptoApp.ViewModels;
using WpfCryptoApp.ViewModels.CoinCapViewModels;
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
                Language = new LanguageViewModel(),
                CandleStick = candleStick
            };
        }
        private async void LoadCandleData(CandleSticksViewModel candleStick, string coinId = "bitcoin")
        {
            try
            {
                await candleStick.LoadDataAsync(coinId);
                System.Diagnostics.Debug.WriteLine($"Load finished. Series length = {candleStick.Series?.Length}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadCandleData error: " + ex);
            }
        }

    }
}
