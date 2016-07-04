using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviato.Models.Twitter.Constants
{
    public class TwitterUris
    {
        //Base URLs
        public const string BaseUri = "https://api.twitter.com/";
        public const string VersionUri = "1.1/";

        //Authentication and Authorization URLs
        public const string OAuth2_Token = BaseUri + "oauth2/token";

        //Search API
        public const string Search_Tweets = BaseUri + VersionUri + "search/tweets.json";
    }
}
