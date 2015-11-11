using System;
using System.Net.NetworkInformation;

namespace ProxyHelper.App
{
    public class NetworkWatcher
    {
        private readonly RuleSetManager _ruleSetManager;
        private readonly Action<string> _addLogEntry;

        public NetworkWatcher(RuleSetManager ruleSetManager, Action<string> addLogEntry)
        {
            _ruleSetManager = ruleSetManager;
            _addLogEntry = addLogEntry;
            NetworkChange.NetworkAddressChanged += OnNetworkAddressChanged;
        }

        private void OnNetworkAddressChanged(object sender, EventArgs eventArgs)
        {
            _addLogEntry("Network Address Changed");
            _ruleSetManager.SelectRuleset();
        }
    }
}