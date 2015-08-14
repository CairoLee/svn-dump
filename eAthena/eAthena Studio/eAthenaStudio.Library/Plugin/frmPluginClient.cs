using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Logging;

namespace eAthenaStudio.Library.Plugin {

	public partial class frmPluginClient : Form {
		private IniParser.IniData mSettings;
		private readonly SortedDictionary<string, IPlugin> mPlugins;


		public IniParser.IniData Settings {
			get { return mSettings; }
			set { mSettings = value; }
		}

		public ILog Logger {
			get;
			protected set;
		}

		public SortedDictionary<string, IPlugin> Plugins {
			get { return mPlugins; }
		}



		public frmPluginClient() {
			InitializeComponent();
			
			mPlugins = new SortedDictionary<string, IPlugin>();
			Logger = LogManager.GetLogger("eaStudio");
		}

	}

}
