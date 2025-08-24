using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WpfCryptoApp.Models.CoinGecko;
using WpfCryptoApp.Models.TextItems;
using WpfCryptoApp.Services.CoinGecko;

namespace WpfCryptoApp.ViewModels
{
    internal class CoinDataViewModel : BaseViewModel
    {
        private CoinData data;
        private ObservableCollection<TextItem> items = new ObservableCollection<TextItem>();
        private ObservableCollection<MarketItem> markets = new ObservableCollection<MarketItem>();
        private ImageInfo imageUri;
        public CoinData CoinData
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TextItem> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MarketItem> Markets
        {
            get { return markets; }
            set
            {
                markets = value;
                OnPropertyChanged();
            }
        }
        public ImageInfo ImageUri
        {
            get { return imageUri; }
            set
            {
                imageUri = value;
                OnPropertyChanged();
            }
        }
        public async Task LoadDataAsyn(string id)
        {
            var apiService = new CoinGeckoApi();
            var result = await apiService.GetCoinData(id);

            if (result != null)
            {
                CoinData = result;
                if (result.MarketData != null) 
                {
                    var marketData = CoinData.MarketData;
                    string currency = "usd";

                    decimal? currentPrice = marketData.CurrentPrice.ContainsKey(currency) ? marketData.CurrentPrice[currency] : null;
                    decimal? atlValue = marketData.Atl.ContainsKey(currency) ? marketData.Atl[currency] : null;
                    decimal? athValue = marketData.Ath.ContainsKey(currency) ? marketData.Ath[currency] : null;
                    double? priceChangePercentage24h = marketData.PriceChangePercentage24h;
                    
                    Items = new ObservableCollection<TextItem>
                    {
                        new TextItem { Title = "Current price (USD)", Text = $"{currentPrice:C}" },
                        new TextItem { Title = "All-Time High (USD)", Text = $"{athValue:C}" },
                        new TextItem { Title = "All-Time Low (USD)", Text = $"{atlValue:C}" },
                        new TextItem { Title = "Price Change 24h (USD)", Text = $"{(priceChangePercentage24h >= 0 ? "+" : "")}{priceChangePercentage24h:F2}%"}
                    };
                }
                if (result.Image != null)
                {
                    ImageUri = result.Image;
                }
                if (result.Tickers != null) 
                { 
                    Markets = new ObservableCollection<MarketItem>();
                    int count = 0;
                    int limit = 10;
                    foreach (var ticker in result.Tickers)
                    {
                        if (count >= limit) break;
                        string trustScore = ticker.TrustScore ?? "N/A";
                        if (trustScore != "green") continue;
                        count++;
                        string marketName = ticker.Market != null ? ticker.Market.Name : "Unknown Market";
                        string nameReplase = marketName.Replace(" ", "\n");
                        string tradeUrl = !string.IsNullOrEmpty(ticker.TradeUrl) ? ticker.TradeUrl : "N/A";
                        decimal? lastPrice = ticker.Last;
                        decimal? volume = ticker.Volume;
                        Markets.Add(new MarketItem
                        {
                            Title = nameReplase,
                            Text = $"Price: {lastPrice:C}\nVolume: {volume:N}",
                            Url = tradeUrl
                        });
                    }
                }
            }
        }

    }
}
