using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net;

using Aviato.Models.Twitter.Attributes;

using System.Reflection;

namespace Aviato.Models.Twitter.Utility
{
    public static class QueryStringConvert
    {
        public static Dictionary<string, string> ToNameValueCollection(object ob)
        {
            Dictionary<string, string> nameValueCollection = new Dictionary<string, string>();

            foreach (PropertyInfo info in ob.GetType().GetProperties())
            {
                QueryStringNameAttribute queryAttr = info.GetCustomAttribute<QueryStringNameAttribute>();

                if (queryAttr != null)
                {
                    nameValueCollection.Add(queryAttr.Name, info.GetValue(ob).ToString());
                }
            }

            return nameValueCollection;
        }

        public static string ToQueryString(object ob)
        {
            Dictionary<string, string> collection = ToNameValueCollection(ob);

            List<string> queries = new List<string>();

            foreach(string key in collection.Keys)
            {
                queries.Add(key + "=" + collection[key]);
            }

            return string.Join("&", queries.ToArray());
        }
    }
}
