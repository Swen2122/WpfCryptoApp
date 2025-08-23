using Newtonsoft.Json;
using System;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class ImageInfo
    {
        [JsonProperty("thumb")]
        public Uri Thumb { get; set; }

        [JsonProperty("small")]
        public Uri Small { get; set; }

        [JsonProperty("large")]
        public Uri Large { get; set; }
    }
}
