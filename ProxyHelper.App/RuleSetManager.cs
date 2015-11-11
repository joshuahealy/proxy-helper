using System;
using System.Collections.Generic;
using System.Linq;

namespace ProxyHelper.App
{
    public class RuleSetManager
    {
        private readonly Action<string> _addLogEntry;
        private readonly Action<string, string> _notify;
        private static readonly RuleSet DefaultRuleSet = new RuleSet("fallback (no proxy)", null, null);

        private readonly List<RuleSet> _ruleSets;

        private RuleSet _currentRuleSet;

        public RuleSetManager(Action<string> addLogEntry, Action<string, string> notify, params RuleSet[] ruleSets)
        {
            _addLogEntry = addLogEntry;
            _notify = notify;
            _ruleSets = ruleSets.ToList();
            SelectRuleset();
        }

        public RuleSet SelectRuleset()
        {
            var previousRuleSet = _currentRuleSet;
            _currentRuleSet = _ruleSets.FirstOrDefault(ruleSet => ruleSet.TestConnectivity()) ?? DefaultRuleSet;
            var logText = String.Format("Rule Set selected: {0}", _currentRuleSet.Name);
            _addLogEntry(logText);
            if (previousRuleSet != _currentRuleSet)
            {
                _notify("Proxy Helper Rule Set Changed", logText);
            }
            return _currentRuleSet;
        }

        public string GatewayFor(string hostname)
        {
            return _currentRuleSet.GatewayFor(hostname);
        }
    }
}