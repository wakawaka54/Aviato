using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Aviato.Models.Twitter;
using Aviato.Models.Twitter.Calls;

namespace Aviato.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            TwitterContext context = new TwitterContext();

            SearchTweetsCall call = new SearchTweetsCall();
            call.Count = 4;
            call.ResultType = "recent";
            call.Language = "en";
            call.Query = "twitter";

            string test = await context.Call(call);

            return View();
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
