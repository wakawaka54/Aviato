using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Aviato.Models.Twitter;
using Aviato.Models.Twitter.Calls;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aviato.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TwitterFeed()
        {
            TwitterContext context = new TwitterContext();

            SearchTweetsCall call = new SearchTweetsCall();
            call.Count = 4;
            call.ResultType = "recent";
            call.Language = "en";
            call.Query = "twitter";

            var test = context.Call(call).Result;

            var statuses = JObject.Parse(test).SelectToken("statuses").ToString();

            List<Tweet> tweets = JsonConvert.DeserializeObject<List<Tweet>>(statuses);

            return PartialView(tweets);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
