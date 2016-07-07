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

        public DateTime CreatedAt_DateTime
        {
            get
            {
                if(string.IsNullOrEmpty(CreatedAt)) { return DateTime.MinValue; }

                int timeZone = CreatedAt.IndexOf('+');
                string dateString = CreatedAt.Remove(timeZone, 6);

                return DateTime.ParseExact(dateString, "ddd MMM dd HH:mm:ss yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("id_str")]
        public string ID { get; set; }

        [JsonProperty("retweet_count")]
        public int RetweetCount { get; set; }
    }

    
    public class Coordinates
    {
        [JsonProperty("coordinates")]
        public double[] Coorindates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
