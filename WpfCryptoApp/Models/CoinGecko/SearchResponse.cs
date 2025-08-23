using Newtonsoft.Json;
using System.Collections.Generic;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class Coin
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    internal class Root
    {
        public List<Coin> Coins { get; set; }
    }
}
