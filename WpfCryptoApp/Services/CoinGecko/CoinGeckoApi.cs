using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfCryptoApp.Models;
using WpfCryptoApp.Models.CoinGecko;

namespace WpfCryptoApp.Services.CoinGecko
{
    internal class CoinGeckoApi
    {
        private string API_KEY = "CG-key";
        public async Task<List<PriceHistory>> GetPriceHistory(string rawId, string currency, int days)
        {
            try
            {
                var id = await Search(rawId);
                var options = new RestClientOptions($"https://api.coingecko.com/api/v3/coins/{id}/market_chart?vs_currency={currency}&days={days}&interval=daily&precision=10");
                var response = await MakeCall(options);

                var apiResponse = JsonConvert.DeserializeObject<List<PriceHistory>>(response.Content);
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
                var options = new RestClientOptions($"https://api.coingecko.com/api/v3/coins/{id}/ohlc?vs_currency={currency}&days={days}&precision={precision}");
                var response = await MakeCall(options);

                var raw = JsonConvert.DeserializeObject<List<List<object>>>(response.Content);
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
        public async Task<List<CoinData>> GetCoinData(string rawId)
        {
            try
            {
                var id = await Search(rawId);
                var options = new RestClientOptions($"https://api.coingecko.com/api/v3/coins/{id}?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=true'");
                var response = await MakeCall(options);

                var apiResponse = JsonConvert.DeserializeObject<CoinData>(response.Content);
                return new List<CoinData> { apiResponse };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        private async Task<string> Search(string symbol)
        {
            var options = new RestClientOptions($"https://api.coingecko.com/api/v3/search?query={symbol}");
            var response = await MakeCall(options);
            var apiResponse = JsonConvert.DeserializeObject<Root>(response.Content);
            try
            {
                var coin = apiResponse.Coins
                    .FirstOrDefault(c => string.Equals(c.Id, symbol, StringComparison.OrdinalIgnoreCase));
                if (coin == null) coin = apiResponse.Coins
                    .FirstOrDefault(c => string.Equals(c.Symbol, symbol, StringComparison.OrdinalIgnoreCase));
                if (coin == null) coin = apiResponse.Coins
                    .FirstOrDefault(c => string.Equals(c.Name, symbol, StringComparison.OrdinalIgnoreCase));
                return coin.Id;
            }
            catch
            {
                return null;
            }

        }

        private async Task<RestResponse> MakeCall(RestClientOptions url)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("x-cg-demo-api-key", API_KEY);

            var response = await client.GetAsync(request);
            if (response == null || string.IsNullOrEmpty(response.Content))
            {
                MessageBox.Show("No data received from API.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            return response;
        }
    }
}
