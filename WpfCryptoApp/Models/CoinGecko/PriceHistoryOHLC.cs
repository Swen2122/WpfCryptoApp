﻿
namespace WpfCryptoApp.Models.CoinGecko
{
    internal class PriceHistoryOHLC
    {
        public long Timestamp { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
    }
}
