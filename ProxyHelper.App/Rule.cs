using System.Collections.Generic;
using System.Linq;

namespace ProxyHelper.App
{
    public class Rule
    {
        public Rule(string gateway, params string[] hostnames)
        {
            Hostnames = hostnames.ToList();
            Gateway = gateway;
        }

        public List<string> Hostnames { get; private set; }
        public string Gateway { get; private set; }
    }
}