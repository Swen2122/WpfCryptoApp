using Newtonsoft.Json;
using System.Collections.Generic;

namespace WpfCryptoApp.Models
{
    internal class ListingsLatest
    {
        [JsonProperty("data")]
        public List<Coin> Data { get; set; }
    }
}
