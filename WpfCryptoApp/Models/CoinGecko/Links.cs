using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace WpfCryptoApp.Models.CoinGecko
{
    internal class Links
    {
        [JsonProperty("homepage")]
        public List<string> Homepage { get; set; }
        [JsonProperty("whitepaper")]
        public string Whitepaper { get; set; }
        [JsonProperty("blockchain_site")]
        public List<string> BlockchainSite { get; set; }

        [JsonProperty("official_forum_url")]
        public List<string> OfficialForumUrl { get; set; }

        [JsonProperty("subreddit_url")]
        public string SubredditUrl { get; set; }
    }
}
