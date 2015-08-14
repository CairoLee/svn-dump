using System;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Plugins
{
	public class AbtractPlugin : IPlugin
	{
		public void Load()
		{
			Console.WriteLine(GetType() + ".Load()");
		}

		public void Unload() {
			Console.WriteLine(GetType() + ".Unload()");
		}
	}
}