using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using WpfCryptoApp.Models;


namespace WpfCryptoApp.Services
{
    internal class CoinMarketCapAPI : ApiBase
    {
        private string API_KEY = "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c";
        private const string ApiKeyHeaderName = "X-CMC_PRO_API_KEY";

        public async Task<List<Coin>> GetCryptoData()
        {
            try
            {
                string url = "https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?start=1&limit=10&sort=market_cap&cryptocurrency_type=all&tag=all";
                var response = await MakeCall(url, API_KEY, ApiKeyHeaderName);
                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("No data received from API.");
                    return null;
                }
                ListingsLatest apiResponse = JsonConvert.DeserializeObject<ListingsLatest>(response);
                return apiResponse.Data;
            }
            catch (WebException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
