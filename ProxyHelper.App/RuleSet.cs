using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace ProxyHelper.App
{
    public class RuleSet
    {
        private readonly Dictionary<string, string> _rules = new Dictionary<string, string>(); 

        public RuleSet(string name, string defaultGateway, string pingHost, params Rule[] rules)
        {
            Name = name;
            DefaultGateway = defaultGateway;
            PingHost = pingHost;
            foreach (var rule in rules)
            {
                AddRule(rule);
            }
        }

        public string Name { get; private set; }
        public string DefaultGateway { get; private set; }
        public string PingHost { get; private set; }

        public bool TestConnectivity()
        {
            if (PingHost == null)
            {
                return true;
            }
            try
            {
                var pong = new Ping().Send(PingHost);
                return pong != null && pong.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

        public void AddRule(string hostname, string gateway)
        {
            if (_rules.ContainsKey(hostname))
            {
                _rules[hostname] = gateway;
            }
            else
            {
                _rules.Add(hostname, gateway);
            }
        }

        public void AddRule(Rule rule)
        {
            rule.Hostnames.ForEach(hostname => AddRule(hostname, rule.Gateway));
        }

        public string GatewayFor(string hostname)
        {
            var pieces = hostname.Split('.').ToList();
            while (pieces.Any())
            {
                var host = String.Join(".", pieces);
                if (_rules.ContainsKey(host))
                {
                    return _rules[host];
                }
                pieces.RemoveAt(0);
            }
            return DefaultGateway;
        }
    }
}