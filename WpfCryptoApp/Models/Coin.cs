﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WpfCryptoApp.Models
{
    internal class Coin
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Rank { get; set; }
        public string USD_Price { get; set; }

    }
}
