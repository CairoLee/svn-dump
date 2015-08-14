using System;
using System.Collections.Generic;
using System.Text;

namespace eAthenaStudio.Library.Plugin {

	public delegate void PluginActiveChangedHandler(IPlugin Plugin);
	public delegate void PluginAddPageHandler(IPlugin Plugin, frmPluginPage PluginPage, List<string> PluginArgs);

}
