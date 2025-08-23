using Newtonsoft.Json;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class Market
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
}
