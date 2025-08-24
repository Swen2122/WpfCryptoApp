using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class MarketData
    {
        [JsonProperty("current_price")]
        public Dictionary<string, decimal?> CurrentPrice { get; set; }

        [JsonProperty("ath")]
        public Dictionary<string, decimal?> Ath { get; set; } // All-Time High

        [JsonProperty("ath_change_percentage")]
        public Dictionary<string, double?> AthChangePercentage { get; set; }

        [JsonProperty("ath_date")]
        public Dictionary<string, DateTime?> AthDate { get; set; }

        [JsonProperty("atl")]
        public Dictionary<string, decimal?> Atl { get; set; } // All-Time Low

        [JsonProperty("atl_change_percentage")]
        public Dictionary<string, double?> AtlChangePercentage { get; set; }

        [JsonProperty("atl_date")]
        public Dictionary<string, DateTime?> AtlDate { get; set; }

        [JsonProperty("market_cap")]
        public Dictionary<string, decimal?> MarketCap { get; set; }

        [JsonProperty("total_volume")]
        public Dictionary<string, decimal?> TotalVolume { get; set; }

        [JsonProperty("high_24h")]
        public Dictionary<string, decimal?> High24h { get; set; }

        [JsonProperty("low_24h")]
        public Dictionary<string, decimal?> Low24h { get; set; }

        [JsonProperty("price_change_24h")]
        public decimal? PriceChange24h { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public double? PriceChangePercentage24h { get; set; }

        [JsonProperty("price_change_percentage_7d")]
        public double? PriceChangePercentage7d { get; set; }

        [JsonProperty("price_change_percentage_1y")]
        public double? PriceChangePercentage1y { get; set; }

        [JsonProperty("total_supply")]
        public decimal? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }

        [JsonProperty("circulating_supply")]
        public decimal? CirculatingSupply { get; set; }

        [JsonProperty("sparkline_7d")]
        public Sparkline Sparkline7d { get; set; }
    }
}
