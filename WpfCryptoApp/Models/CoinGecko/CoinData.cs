using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class CoinData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("image")]
        public ImageInfo Image { get; set; }

        [JsonProperty("market_cap_rank")]
        public int MarketCapRank { get; set; }

        [JsonProperty("market_data")]
        public MarketData MarketData { get; set; }

        [JsonProperty("tickers")]
        public List<Ticker> Tickers { get; set; }

        [JsonProperty("genesis_date")]
        public DateTime? GenesisDate { get; set; }
    }
}
