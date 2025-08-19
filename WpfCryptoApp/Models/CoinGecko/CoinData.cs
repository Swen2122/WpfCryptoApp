using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class CoinData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public Description Description { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("image")]
        public ImageInfo Image { get; set; }

        [JsonPropertyName("market_cap_rank")]
        public int MarketCapRank { get; set; }

        [JsonPropertyName("market_data")]
        public MarketData MarketData { get; set; }

        [JsonPropertyName("tickers")]
        public List<Ticker> Tickers { get; set; }

        [JsonPropertyName("genesis_date")]
        public DateTime? GenesisDate { get; set; }
    }
}
