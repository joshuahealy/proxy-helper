using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyHelper.App
{
    public partial class StatusForm : Form
    {
        private int _logSize;
        private NetworkWatcher _networkWatcher;
        private ProxyHandler _proxyHandler;
        private RuleSetManager _ruleSetManager;
        private List<string> _logEntries = new List<string>();
        private bool _loaded;
        private bool _exiting;
        private FormWindowState _previousWindowState;

        public StatusForm()
        {
            InitializeComponent();
            systrayIcon.Icon = Icon;
            lbLog.BackgroundImage = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ProxyHelper.App.Icon256.png"));
            var config = Configuration.LoadFromConfigFile();
            _ruleSetManager = new RuleSetManager(
                InvokeAddLogEntry,
                InvokeNotify,
                config.RuleSets.ToArray()
            );
            _logSize = config.LogSize;
            _networkWatcher = new NetworkWatcher(_ruleSetManager, InvokeAddLogEntry);
            _proxyHandler = new ProxyHandler(config.Port, _ruleSetManager, InvokeAddLogEntry);
        }

        public void InvokeAddLogEntry(string text)
        {
            if (_exiting)
            {
                return;
            }
            if (!_loaded)
            {
                _logEntries.Add(text);
            }
            else
            {
                Invoke(new MethodInvoker(() => AddLogEntry(text)));
            }
        }

        public void AddLogEntry(string text)
        {
            lbLog.BeginUpdate();
            lbLog.Items.Add(text);
            if (lbLog.Items.Count > _logSize)
            {
                lbLog.Items.RemoveAt(0);
            }
            lbLog.TopIndex = lbLog.Items.Count - 1;
            lbLog.EndUpdate();
        }

        public void InvokeNotify(string title, string text)
        {
            if (_exiting)
            {
                return;
            }
            if (!_loaded)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(200);
                    InvokeNotify(title, text);
                });
                return;
            }
            Invoke(new MethodInvoker(() => Notify(title, text)));
        }

        public void Notify(string title, string text)
        {
            systrayIcon.ShowBalloonTip(1000, title, text, ToolTipIcon.Info);
        }

        private void HideForm()
        {
            _previousWindowState = WindowState;
            Hide();
            ShowInTaskbar = false;
            systrayIcon.ShowBalloonTip(2500, "Proxy Helper is still running", "Proxy Helper will continue to run in the background.  To close, right click on the System Tray icon and click Exit.", ToolTipIcon.Info);
        }

        private void ShowForm()
        {
            Show();
            ShowInTaskbar = true;
            BringToFront();
            WindowState = _previousWindowState;
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
            _loaded = true;
            foreach (var entry in _logEntries.ToList())
            {
                AddLogEntry(entry);
            }
        }

        private void StatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_exiting)
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void systrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            _exiting = true;
            Application.Exit();
        }

        private void miShowLog_Click(object sender, EventArgs e)
        {
            ShowForm();
        }
    }
}
