using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfCryptoApp.Models.CoinGecko;

namespace WpfCryptoApp.Services.CoinGecko
{
    internal class CoinGeckoApi
    {
        private string API_KEY = "your_apiKey";
        public async Task<List<PriceHistory>> GetPriceHistory(string coinId, string currency, int days)
        {
            try
            {
                var options = new RestClientOptions($"https://api.coingecko.com/api/v3/coins/{coinId}/market_chart?vs_currency={currency}&days={days}&interval=daily&precision=10");
                var response = await MakeCall(options);
                if (response == null || string.IsNullOrEmpty(response.Content))
                {
                    Console.WriteLine("No data received from API.");
                    return null;
                }
                var apiResponse = JsonConvert.DeserializeObject<List<PriceHistory>>(response.Content);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<PriceHistoryOHLC>> GetPriceHistoryOHLC(string coinId, string currency = "usd", int days = 7, int precision = 3)
        {
            try
            {
                var options = new RestClientOptions($"https://api.coingecko.com/api/v3/coins/{coinId}/ohlc?vs_currency={currency}&days={days}&precision={precision}");
                var response = await MakeCall(options);
                if (response == null || string.IsNullOrEmpty(response.Content))
                {
                    Console.WriteLine("No data received from API.");
                    return null;
                }

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
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<CoinData>> GetCoinData(string id)
        {
            try
            {
                var options = new RestClientOptions($"https://api.coingecko.com/api/v3/coins/{id}?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=true'");
                var response = await MakeCall(options);
                if (response == null || string.IsNullOrEmpty(response.Content))
                {
                    Console.WriteLine("No data received from API.");
                    return null;
                }
                var apiResponse = JsonConvert.DeserializeObject<List<CoinData>>(response.Content);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
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
            return response;
        }
    }
}
