using Newtonsoft.Json;
using WpfCryptoApp.Models.CoinMarketCap;

namespace WpfCryptoApp.Models
{
    internal class Coin
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        [JsonProperty("cmc_rank")]
        public string CmcRank { get; set; }
        [JsonProperty("quote")]
        public Quote Quote { get; set; }

    }
}
