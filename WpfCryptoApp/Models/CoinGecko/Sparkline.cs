using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class Sparkline
    {
        [JsonPropertyName("price")]
        public List<double> Price { get; set; }
    }
}
