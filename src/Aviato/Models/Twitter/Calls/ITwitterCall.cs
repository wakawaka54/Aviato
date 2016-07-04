using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviato.Models.Twitter.Calls
{
    public interface ITwitterCall
    {
        Task<string> CallAsync(TwitterClient _client);
    }
}
