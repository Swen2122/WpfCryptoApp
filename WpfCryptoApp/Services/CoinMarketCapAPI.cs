using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using WpfCryptoApp.Models;


namespace WpfCryptoApp.Services
{
    internal class CoinMarketCapAPI
    {
        private string API_KEY = "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c";

        public List<Coin> GetCryptoData()
        {
            try
            {
                string response = MakeAPICall();
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
        private string MakeAPICall()
        {
            var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?start=1&limit=10&sort=market_cap&cryptocurrency_type=all&tag=all");

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }
    }
}
