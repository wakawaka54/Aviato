using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

using Aviato.Models.Twitter.Authentication;
using Aviato.Models.Twitter.Constants;

namespace Aviato.Models.Twitter
{
    public class TwitterClient : HttpClient
    {
        public TwitterClient(OAuth2Authentication token)
            :base()
        {
            BaseAddress = new Uri(TwitterUris.BaseUri);
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Add("Authorization", String.Format("{0} {1}", token.TokenType, token.AccessToken));
            DefaultRequestHeaders.Add("User-Agent", TwitterApplication.ApplicationName);
            DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
        }

        public async Task<string> Get(string endpoint)
        {
            HttpResponseMessage message = await GetAsync(endpoint);

            return await message.Content.ReadAsStringAsync();
        }

        public void Post(string endpoint)
        {

        }
    }
}
