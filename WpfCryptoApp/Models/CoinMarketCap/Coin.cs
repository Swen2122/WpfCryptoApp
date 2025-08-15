using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCryptoApp.Models.CoinMarketCap;

namespace WpfCryptoApp.Models
{
    //todo: fix this govnocode
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
