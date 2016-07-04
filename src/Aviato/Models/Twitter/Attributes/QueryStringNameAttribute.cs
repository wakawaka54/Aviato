using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviato.Models.Twitter.Attributes
{
    public class QueryStringNameAttribute : System.Attribute
    {
        public string Name { get; set; }

        public QueryStringNameAttribute(string name)
        {
            Name = name;
        }
    }
}
