using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Aviato.Models.Twitter
{
    public class Tweet
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
