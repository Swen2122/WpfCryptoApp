using System.Collections.Generic;
using WpfCryptoApp.Services;
using WpfCryptoApp.Models;
using System.Threading.Tasks;

namespace WpfCryptoApp.ViewModels
{
    internal class TopCoinsViewModel : BaseViewModel
    {
        private List<Coin> _coins;
        public List<Coin> Coins
        {
            get { return _coins; }
            set
            {
                _coins = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadData() 
        {
            var apiService = new CoinMarketCapAPI();
            Coins = await apiService.GetCryptoData();
        }
    }
}
