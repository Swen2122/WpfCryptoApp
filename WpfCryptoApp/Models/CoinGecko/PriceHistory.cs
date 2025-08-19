using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCryptoApp.Models.CoinGecko
{
    internal class PriceHistory
    {
        public long Timestamp { get; set; }
        public double Price { get; set; }
    }
}
