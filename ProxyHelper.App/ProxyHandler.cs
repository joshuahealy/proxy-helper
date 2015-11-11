using System;
using Fiddler;

namespace ProxyHelper.App
{
    public class ProxyHandler
    {
        public const string SystemProxyPlacholderHostName = "[system]";

        private readonly RuleSetManager _ruleSetManager;
        private readonly Action<string> _addLogEntry;

        public ProxyHandler(int port, RuleSetManager ruleSetManager, Action<string> addLogEntry)
        {
            _ruleSetManager = ruleSetManager;
            _addLogEntry = addLogEntry;
            FiddlerApplication.BeforeRequest += BeforeRequest;
            FiddlerApplication.Startup(port, FiddlerCoreStartupFlags.RegisterAsSystemProxy | FiddlerCoreStartupFlags.ChainToUpstreamGateway);
        }

        private void BeforeRequest(Session session)
        {
            var gateway = _ruleSetManager.GatewayFor(session.hostname);
            string logMessage;
            if (String.IsNullOrEmpty(gateway))
            {
                session.bypassGateway = true;
                logMessage = String.Format("Url: {0} | BYPASSING PROXY", session.url);
            }
            else if (!gateway.Equals(SystemProxyPlacholderHostName))
            {
                session["X-OverrideGateway"] = gateway;
                logMessage = String.Format("Url: {0} | PROXY SELECTED: {1}", session.url, gateway);
            }
            else
            {
                logMessage = String.Format("Url: {0} | USING SYSTEM PROXY", session.url);
            }
            _addLogEntry(logMessage);
        }
    }
}