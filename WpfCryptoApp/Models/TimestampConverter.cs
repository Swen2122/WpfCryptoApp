using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCryptoApp.Models
{
    internal class TimestampConverter
    {
        public DateTime TimestampToDateTime(int timestamp)
        {
            // Convert Unix timestamp to DateTime
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
        }
    }
}
