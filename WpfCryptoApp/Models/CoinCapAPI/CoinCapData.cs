﻿using Newtonsoft.Json;

namespace WpfCryptoApp.Models.CoinCapAPI
{
    internal class CoinCapData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("supply")]
        public double? Supply { get; set; }

        [JsonProperty("maxSupply")]
        public double? MaxSupply { get; set; }

        [JsonProperty("marketCapUsd")]
        public double? MarketCapUsd { get; set; }

        [JsonProperty("volumeUsd24Hr")]
        public double? VolumeUsd24Hr { get; set; }

        [JsonProperty("priceUsd")]
        public decimal? PriceUsd { get; set; }

        [JsonProperty("changePercent24Hr")]
        public decimal? ChangePercent24Hr { get; set; }

        [JsonProperty("vwap24Hr")]
        public decimal? Vwap24Hr { get; set; }

        [JsonProperty("explorer")]
        public string Explorer { get; set; }
    }
}
