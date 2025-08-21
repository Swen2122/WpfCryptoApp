using System.Collections.Generic;
using WpfCryptoApp.Models.CoinGecko;
using WpfCryptoApp.Services.CoinGecko;

namespace WpfCryptoApp.ViewModels
{
    internal class CoinDataViewModel : BaseViewModel
    {
        private List<CoinData> data = new List<CoinData>();
        public List<CoinData> CoinData
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }
        public async void LoadDataAsyn(string id)
        {
            var apiService = new CoinGeckoApi();
            var result = await apiService.GetCoinData(id);
            CoinData = result;
        }

    }
}
