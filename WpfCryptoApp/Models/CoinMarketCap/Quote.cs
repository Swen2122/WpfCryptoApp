using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCryptoApp.Models.CoinMarketCap
{
    public class Quote
    {
        public class USD
        {
            public decimal Price { get; set; }
        }
        public USD Usd { get; set; }
    }
}
