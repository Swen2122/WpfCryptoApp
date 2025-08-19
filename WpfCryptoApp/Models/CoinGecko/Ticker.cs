using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class Ticker
    {
        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("target")]
        public string Target { get; set; }

        [JsonPropertyName("market")]
        public Market Market { get; set; }

        [JsonPropertyName("last")]
        public decimal Last { get; set; }

        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }

        [JsonPropertyName("converted_last")]
        public ConvertedData ConvertedLast { get; set; }

        [JsonPropertyName("converted_volume")]
        public ConvertedData ConvertedVolume { get; set; }

        [JsonPropertyName("trade_url")]
        public string TradeUrl { get; set; }

        [JsonPropertyName("trust_score")]
        public string TrustScore { get; set; }
    }
}
