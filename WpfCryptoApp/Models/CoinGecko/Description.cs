using Newtonsoft.Json;


namespace WpfCryptoApp.Models.CoinGecko
{
    internal class Description
    {
        [JsonProperty("en")]
        public string En { get; set; }
    }
}
