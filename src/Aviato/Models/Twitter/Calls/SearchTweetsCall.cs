using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

using Aviato.Models.Twitter.Attributes;
using Aviato.Models.Twitter.Constants;
using Aviato.Models.Twitter.Utility;

namespace Aviato.Models.Twitter.Calls
{
    public class SearchTweetsCall : ITwitterCall
    {
        [QueryStringName("q")]
        public string Query { get; set; }

        [QueryStringName("lang")]
        public string Language { get; set; }

        [QueryStringName("result_type")]
        public string ResultType { get; set; }

        [QueryStringName("count")]
        public int Count { get; set; }

        public SearchTweetsCall()
        {
            
        }

        public async Task<string> CallAsync(TwitterClient _client)
        {
            UriBuilder builder = new UriBuilder(TwitterUris.Search_Tweets);
            builder.Query = QueryStringConvert.ToQueryString(this);

            return await _client.Get(builder.ToString());
        }
    }
}
