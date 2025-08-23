using Newtonsoft.Json;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class ConvertedData
    {
        [JsonProperty("btc")]
        public decimal Btc { get; set; }

        [JsonProperty("eth")]
        public decimal Eth { get; set; }

        [JsonProperty("usd")]
        public decimal Usd { get; set; }
    }
}
