using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eAthenaStudio.Library.Plugin {

	public partial class frmPluginPage : Form {
		protected PluginBase mPlugin;

		public PluginBase Plugin {
			get { return mPlugin; }
			set { mPlugin = value; }
		}


		/// <summary>
		/// just for Designer..
		/// </summary>
		public frmPluginPage() {
			InitializeComponent();
		}

		public frmPluginPage(PluginBase plugin, List<string> PluginArgs)
			: this() {
			Plugin = plugin;
			InitializeComponent();
		}

	}

}
