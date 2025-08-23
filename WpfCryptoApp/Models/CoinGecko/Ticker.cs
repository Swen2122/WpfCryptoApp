using Newtonsoft.Json;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class Ticker
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("market")]
        public Market Market { get; set; }

        [JsonProperty("last")]
        public decimal? Last { get; set; }

        [JsonProperty("volume")]
        public decimal? Volume { get; set; }

        [JsonProperty("converted_last")]
        public ConvertedData ConvertedLast { get; set; }

        [JsonProperty("converted_volume")]
        public ConvertedData ConvertedVolume { get; set; }

        [JsonProperty("trade_url")]
        public string TradeUrl { get; set; }

        [JsonProperty("trust_score")]
        public string TrustScore { get; set; }
    }
}
