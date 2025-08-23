using Newtonsoft.Json;
using System.Collections.Generic;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class Sparkline
    {
        [JsonProperty("price")]
        public List<double> Price { get; set; }
    }
}
