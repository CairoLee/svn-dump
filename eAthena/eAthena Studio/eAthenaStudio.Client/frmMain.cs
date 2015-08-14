using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using eAthenaStudio.Library;
using eAthenaStudio.Library.Plugin;
using eAthenaStudio.Library.IniParser;
using eAthenaStudio.Client.Controls;

namespace eAthenaStudio.Client {

	public partial class frmMain : frmPluginClient {
		private readonly string[] mStartArgs;


		public frmMain(string[] args)
			: base() {
			InitializeComponent();

			mStartArgs = args;

			LoadSettings();
			// using Client logger for main messages/logs
			SafeIo.Initialize(Logger);
			MsgHelper.Initialize(Logger);

			LoadPlugins(AppDomain.CurrentDomain.BaseDirectory + @"\Plugins\");
		}


		#region Form Events
		private void frmMain_Load(object sender, EventArgs e) {
			// enable instant start of Plugins aka "fast load"
			if (mStartArgs != null && mStartArgs.Length > 0)
				ParseStartArgs();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			foreach (IPlugin p in Plugins.Values)
				((PluginBase)p).Dispose();

			Logger.Debug("Client wurde erfolgreich beendet.");
		}
		#endregion

		#region MenuProgram Events
		private void MenuProgramClose_Click(object sender, EventArgs e) {
			Close();
		}
		#endregion

		#region MenuSettings Events
		private void MenuSettingsOptions_Click(object sender, EventArgs e) {
			using (frmSettings frm = new frmSettings())
				frm.ShowDialog(this);
		}
		#endregion

		#region Plugin Events
		private void ButtonPlugin_Click(object sender, EventArgs e) {
			ButtonPlugin btn = sender as ButtonPlugin;
			if (btn == null) // wtf oO
				return;

			((PluginBase)btn.Tag).OnPluginAddPage(this);
		}

		private void Plugi_PluginPageClose(object sender, EventArgs e) {
			WindowState = FormWindowState.Normal;
			BringToFront();
			Focus();
		}
		#endregion



		private void LoadSettings() {
			var parser = new FileIniDataParser();
			Settings = parser.LoadFile(AppDomain.CurrentDomain.BaseDirectory + @"\eAthena Studio.conf");
		}

		public void LoadPlugins(string basePath) {
			if (basePath != null) {
				string[] files = Directory.GetFiles(Path.GetDirectoryName(basePath), "Plugin.*.dll");
				if (files.Length == 0)
					return;

				Plugins.Clear();
				Logger.Debug("Loading " + files.Length + " plugins from: " + basePath);
				for (int i = 0; i < files.Length; i++)
					LoadPlugin(files[i]);
			}
		}



		#region Helper
		private void ParseStartArgs() {
			var pluginStart = false;
			for (var i = 0; i < mStartArgs.Length; i++) {
				var plugName = mStartArgs[i];
				var pluginArgs = new List<string>();
				if (plugName.Contains(";") == true) {
					// Plugin-args are seperated by ;
					pluginArgs.AddRange(plugName.Split(';'));
					plugName = pluginArgs[0];
					pluginArgs.RemoveAt(0);
				}

				if (Plugins.ContainsKey(plugName) == false) {
					MsgHelper.Error("Fehler beim Plugin laden", "Das Plugin \"" + plugName + "\" existiert nicht!\nBitte achte auf die korrekte Groß- und Kleinschreibung.");
					continue;
				}

				Logger.Info("start Plugin \"" + plugName + "\" from Parameterinfo");
				((PluginBase)Plugins[plugName]).OnPluginAddPage(this, pluginArgs);
				pluginStart = true;
			}

			if (pluginStart == true) // we start a Plugin, so minimize Client
				WindowState = FormWindowState.Minimized;
		}

		private void LoadPlugin(string path) {
			var a = Assembly.LoadFile(path);
			foreach (var t in a.GetTypes()) {
				if (t.IsAbstract || t.IsInterface)
					continue;
				if (t.GetInterface(typeof(IPlugin).FullName) == null)
					continue;

				var p = (PluginBase)a.CreateInstance(t.FullName, false, BindingFlags.CreateInstance, null, new object[] { this }, null, null);
				if (p.Name == "PluginBase")
					continue;

				Logger.Info("load Plugin: " + p.Name);

				#region load Plugin Settings
				KeyDataCollection sec = Settings[p.Name];
				if (sec != null) {
					KeyData data;
					foreach (PropertyInfo i in t.GetProperties()) {
						if (i.GetCustomAttributes(typeof(SaveAttribute), true).Length == 0)
							continue;
						if ((data = sec[i.Name]) == null)
							continue;

						object val;
						if (i.PropertyType.IsEnum)
							val = Enum.Parse(i.PropertyType, data.Value);
						else
							val = Convert.ChangeType(data.Value, i.PropertyType);
						i.SetValue(p, val, null);
					}
				}
				#endregion

				p.PluginPageClose += Plugi_PluginPageClose;
				Plugins.Add(p.Name, p);
				AddPluginButton(p);
			}

		}

		private void AddPluginButton(PluginBase p) {
			var offsetX = (pnlPlugins.Controls.Count % 3) * 16; // 3 per row
			var offsetY = (pnlPlugins.Controls.Count / 3) * 16;
			var btn = new ButtonPlugin(p);
			offsetX += (pnlPlugins.Controls.Count % 3) * btn.Width;
			offsetY += (pnlPlugins.Controls.Count / 3) * btn.Height;
			btn.Location = new Point(offsetX, offsetY);
			btn.Click += ButtonPlugin_Click;

			pnlPlugins.Controls.Add(btn);
		}
		#endregion

	}

}
