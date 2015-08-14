using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace eAthenaStudio.Library.Plugin {

	public interface IPlugin {
		bool Active {
			get;
			set;
		}

		string Name {
			get;
		}

		string Description {
			get;
		}

		string Author {
			get;
		}

		Version Version {
			get;
		}

		Image MenuImage {
			get;
		}


		event PluginActiveChangedHandler PluginActiveChanged;
		event PluginAddPageHandler PluginAddPage;

	}

}
