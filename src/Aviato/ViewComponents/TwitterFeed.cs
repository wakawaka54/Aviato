using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Aviato.Models.Twitter.Calls;
using Aviato.Models.Twitter;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aviato.ViewComponents
{
    public class TwitterFeed : ViewComponent
    {
        public TwitterFeed()
        {

        }

        public IViewComponentResult Invoke()
        {
            TwitterContext context = new TwitterContext();

            SearchTweetsCall call = new SearchTweetsCall();
            call.Count = 12;
            call.ResultType = "recent";
            call.Language = "en";
            call.Query = "microsoft";

            var test = context.Call(call).Result;

            var statuses = JObject.Parse(test).SelectToken("statuses").ToString();

            List<Tweet> tweets = JsonConvert.DeserializeObject<List<Tweet>>(statuses);

            return View(tweets);
        }
    }
}
