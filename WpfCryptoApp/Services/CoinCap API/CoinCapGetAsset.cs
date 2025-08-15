using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfCryptoApp.Models;
using WpfCryptoApp.Models.CoinCapAPI;

namespace WpfCryptoApp.Services.CoinCap_API
{
    internal class CoinCapGetAsset
    {
        private string _apiKey = "your_apiKey";
        public CoinCapAsset GetAsset(string assetId)
        {
            try
            {
                string response = MakeAPICall(assetId);
                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("No data received from API.");
                    return null;
                }
                CoinCapAsset apiResponse = JsonConvert.DeserializeObject<CoinCapAsset>(response);
                return apiResponse;
            }
            catch (WebException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        private string MakeAPICall(string assetId)
        {
            var url = new UriBuilder($"https://rest.coincap.io/v3/assets?apiKey={_apiKey}&search={assetId}&limit=10&offset=0");
            var client = new WebClient();
            client.Headers.Add("Authorization", $"Bearer {_apiKey}");
            return client.DownloadString(url.ToString());
        }
    }
}
