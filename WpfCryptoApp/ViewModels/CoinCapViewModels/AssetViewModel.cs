using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCryptoApp.Models.CoinCapAPI;
using WpfCryptoApp.Services.CoinCap_API;

namespace WpfCryptoApp.ViewModels.CoinCapViewModels
{
    internal class AssetViewModel : BaseViewModel
    {
        private CoinCapAsset asset;
        public CoinCapAsset Asset
        {
            get { return asset; }
            set
            {
                asset = value;
                OnPropertyChanged();
            }
        }
        public void LoadData(string id)
        {
            var apiService = new CoinCapGetAsset();
            Asset = apiService.GetAsset(id);
        }

    }
}
