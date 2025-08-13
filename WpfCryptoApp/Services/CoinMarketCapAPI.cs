using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;


namespace WpfCryptoApp.Services
{
    internal class CoinMarketCapAPI
    {
        private static string API_KEY = "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c";

        public string GetCryptoData()
        {
            try
            {
                return MakeAPICall();
            }
            catch (WebException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        private string MakeAPICall()
        {
            var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/trending/latest?start=1&limit=10&time_period=24h");

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            Console.WriteLine($"Making API call to: {URL}");
            return client.DownloadString(URL.ToString());
        }
    }
}
