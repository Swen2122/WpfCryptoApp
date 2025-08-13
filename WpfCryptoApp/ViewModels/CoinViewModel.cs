using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCryptoApp.Services;
using WpfCryptoApp.Models;

namespace WpfCryptoApp.ViewModels
{
    internal class CoinViewModel : BaseViewModel
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

        public void LoadData() 
        {
            var apiService = new CoinMarketCapAPI();
            Coins = apiService.GetCryptoData();
        }
    }
}
