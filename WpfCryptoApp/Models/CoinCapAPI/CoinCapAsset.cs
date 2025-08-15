using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfCryptoApp.Models.CoinCapAPI
{
    internal class CoinCapAsset
    {
        public string Timestamp { get; set; }
        public List<CoinCapData> Data { get; set; }
    }
}
