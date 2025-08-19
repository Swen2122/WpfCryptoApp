using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class ConvertedData
    {
        [JsonPropertyName("btc")]
        public decimal Btc { get; set; }

        [JsonPropertyName("eth")]
        public decimal Eth { get; set; }

        [JsonPropertyName("usd")]
        public decimal Usd { get; set; }
    }
}
