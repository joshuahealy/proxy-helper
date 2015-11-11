namespace ProxyHelper.App
{
    partial class StatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
            this.systrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.systrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.miSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.systrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // systrayIcon
            // 
            this.systrayIcon.ContextMenuStrip = this.systrayMenu;
            this.systrayIcon.Text = "Proxy Helper";
            this.systrayIcon.Visible = true;
            this.systrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.systrayIcon_MouseDoubleClick);
            // 
            // systrayMenu
            // 
            this.systrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowLog,
            this.miSeperator,
            this.miExit});
            this.systrayMenu.Name = "systrayMenu";
            this.systrayMenu.Size = new System.Drawing.Size(127, 54);
            // 
            // miShowLog
            // 
            this.miShowLog.Name = "miShowLog";
            this.miShowLog.Size = new System.Drawing.Size(126, 22);
            this.miShowLog.Text = "Show Log";
            this.miShowLog.Click += new System.EventHandler(this.miShowLog_Click);
            // 
            // miSeperator
            // 
            this.miSeperator.Name = "miSeperator";
            this.miSeperator.Size = new System.Drawing.Size(123, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(126, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(0, 0);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(692, 327);
            this.lbLog.TabIndex = 0;
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 327);
            this.Controls.Add(this.lbLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatusForm";
            this.Text = "Proxy Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatusForm_FormClosing);
            this.Load += new System.EventHandler(this.StatusForm_Load);
            this.systrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon systrayIcon;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.ContextMenuStrip systrayMenu;
        private System.Windows.Forms.ToolStripMenuItem miShowLog;
        private System.Windows.Forms.ToolStripSeparator miSeperator;
        private System.Windows.Forms.ToolStripMenuItem miExit;
    }
}

