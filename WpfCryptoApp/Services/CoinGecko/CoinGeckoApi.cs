using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfCryptoApp.Models.CoinGecko;

namespace WpfCryptoApp.Services.CoinGecko
{
    internal class CoinGeckoApi : ApiBase
    {
        private string API_KEY = "CG-key"; // unsafe storage of the API key
        private const string ApiKeyHeaderName = "x-cg-demo-api-key";

        public async Task<List<PriceHistory>> GetPriceHistory(string rawId, string currency, int days)
        {
            try
            {
                var id = await Search(rawId);
                if (string.IsNullOrEmpty(id)) return null;

                string url = $"https://api.coingecko.com/api/v3/coins/{id}/market_chart?vs_currency={currency}&days={days}&interval=daily&precision=10";
                var jsonResponse = await MakeCall(url, API_KEY, ApiKeyHeaderName);
                if (string.IsNullOrEmpty(jsonResponse)) return null;

                var apiResponse = JsonConvert.DeserializeObject<List<PriceHistory>>(jsonResponse);
                return apiResponse;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public async Task<List<PriceHistoryOHLC>> GetPriceHistoryOHLC(string rawId, string currency = "usd", int days = 7, int precision = 3)
        {
            try
            {
                var id = await Search(rawId);
                if (string.IsNullOrEmpty(id)) return null;

                string url = $"https://api.coingecko.com/api/v3/coins/{id}/ohlc?vs_currency={currency}&days={days}&precision={precision}";
                var jsonResponse = await MakeCall(url, API_KEY, ApiKeyHeaderName);
                if (string.IsNullOrEmpty(jsonResponse)) return null;

                var raw = JsonConvert.DeserializeObject<List<List<object>>>(jsonResponse);
                var result = new List<PriceHistoryOHLC>();
                foreach (var item in raw)
                {
                    if (item.Count == 5)
                    {
                        result.Add(new PriceHistoryOHLC
                        {
                            Timestamp = Convert.ToInt64(item[0]),
                            Open = Convert.ToDouble(item[1]),
                            High = Convert.ToDouble(item[2]),
                            Low = Convert.ToDouble(item[3]),
                            Close = Convert.ToDouble(item[4])
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public async Task<CoinData> GetCoinData(string rawId)
        {
            try
            {
                var id = await Search(rawId);
                if (string.IsNullOrEmpty(id)) return null;

                string url = $"https://api.coingecko.com/api/v3/coins/{id}?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=true";
                var jsonResponse = await MakeCall(url, API_KEY, ApiKeyHeaderName);
                if (string.IsNullOrEmpty(jsonResponse)) return null;

                var apiResponse = JsonConvert.DeserializeObject<CoinData>(jsonResponse);
                return apiResponse;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private async Task<string> Search(string symbol)
        {
            string url = $"https://api.coingecko.com/api/v3/search?query={symbol}";
            var jsonResponse = await MakeCall(url, API_KEY, ApiKeyHeaderName);
            if (string.IsNullOrEmpty(jsonResponse)) return null;

            var apiResponse = JsonConvert.DeserializeObject<Root>(jsonResponse);
            try
            {
                var coin = apiResponse.Coins
                    .FirstOrDefault(c => string.Equals(c.Id, symbol, StringComparison.OrdinalIgnoreCase));
                if (coin == null) coin = apiResponse.Coins
                    .FirstOrDefault(c => string.Equals(c.Symbol, symbol, StringComparison.OrdinalIgnoreCase));
                if (coin == null) coin = apiResponse.Coins
                    .FirstOrDefault(c => string.Equals(c.Name, symbol, StringComparison.OrdinalIgnoreCase));

                return coin?.Id;
            }
            catch
            {
                MessageBox.Show($"Coin not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}