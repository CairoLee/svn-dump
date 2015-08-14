using System.Collections.Generic;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Plugins {
	public class PluginHandler {

		public List<IPlugin> Plugins {
			get;
			private set;
		}


		public PluginHandler() {
			Plugins = new List<IPlugin>();

			ReloadPlugins();
		}


		public void ReloadPlugins()
		{
			UnloadPlugins();
		}

		public void UnloadPlugins()
		{
			Plugins.ForEach(p => p.Unload());
			Plugins.Clear();
		}

	}

}