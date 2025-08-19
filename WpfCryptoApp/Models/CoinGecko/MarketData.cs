using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class MarketData
    {
        [JsonPropertyName("current_price")]
        public Dictionary<string, decimal?> CurrentPrice { get; set; }

        [JsonPropertyName("ath")]
        public Dictionary<string, decimal?> Ath { get; set; } // All-Time High

        [JsonPropertyName("ath_change_percentage")]
        public Dictionary<string, double?> AthChangePercentage { get; set; }

        [JsonPropertyName("ath_date")]
        public Dictionary<string, DateTime?> AthDate { get; set; }

        [JsonPropertyName("atl")]
        public Dictionary<string, decimal?> Atl { get; set; } // All-Time Low

        [JsonPropertyName("atl_change_percentage")]
        public Dictionary<string, double?> AtlChangePercentage { get; set; }

        [JsonPropertyName("atl_date")]
        public Dictionary<string, DateTime?> AtlDate { get; set; }

        [JsonPropertyName("market_cap")]
        public Dictionary<string, decimal?> MarketCap { get; set; }

        [JsonPropertyName("total_volume")]
        public Dictionary<string, decimal?> TotalVolume { get; set; }

        [JsonPropertyName("high_24h")]
        public Dictionary<string, decimal?> High24h { get; set; }

        [JsonPropertyName("low_24h")]
        public Dictionary<string, decimal?> Low24h { get; set; }

        [JsonPropertyName("price_change_24h")]
        public decimal? PriceChange24h { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public double? PriceChangePercentage24h { get; set; }

        [JsonPropertyName("price_change_percentage_7d")]
        public double? PriceChangePercentage7d { get; set; }

        [JsonPropertyName("price_change_percentage_1y")]
        public double? PriceChangePercentage1y { get; set; }

        [JsonPropertyName("total_supply")]
        public decimal? TotalSupply { get; set; }

        [JsonPropertyName("max_supply")]
        public decimal? MaxSupply { get; set; }

        [JsonPropertyName("circulating_supply")]
        public decimal? CirculatingSupply { get; set; }

        [JsonPropertyName("sparkline_7d")]
        public Sparkline Sparkline7d { get; set; }
    }
}
