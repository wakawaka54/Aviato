using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using Aviato.Models.Twitter.Authentication;
using Aviato.Models.Twitter.Calls;
using Aviato.Models.Twitter.Constants;

using System.Net.Http;

using Newtonsoft.Json;

using System.Runtime.Serialization.Formatters;

namespace Aviato.Models.Twitter
{
    public class TwitterContext
    {
        OAuth2Authentication _token;
        TwitterClient _client;

        string apiKey = "OY43NcJr0PVylHxo6LG2aigqP";
        string apiSecretKey = "ZVYCKJOkWTyAUsKM3pCBTLyvIGduzkntlN9L7XtVgPC9VrefIN";

        public TwitterContext()
        {

        }

        public async Task<string> Call(ITwitterCall call)
        {
            if(_client == null || _token == null)
            {
                _token = await authenticate();
                _client = new TwitterClient(_token);
            }

            return await call.CallAsync(this._client);
        }

        async Task<OAuth2Authentication> authenticate()
        {
            string apiKeyAndSecret = String.Format("{0}:{1}", apiKey, apiSecretKey);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(TwitterUris.BaseUri);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", TwitterApplication.ApplicationName);
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", Convert.ToBase64String(Encoding.UTF8.GetBytes(apiKeyAndSecret))));
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");

            StringContent content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage tokenResponse = await client.PostAsync(TwitterUris.OAuth2_Token, content);

            return JsonConvert.DeserializeObject<OAuth2Authentication>(await tokenResponse.Content.ReadAsStringAsync());
        }
    }
}
