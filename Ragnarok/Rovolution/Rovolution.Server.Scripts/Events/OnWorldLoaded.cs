using System;
using System.Collections.Generic;
using System.Text;

using Rovolution.Server;
using GodLesZ.Library;


namespace Rovolution.Server.Scripting {

	public class OnWorldLoaded {

		public static void Initialize() {
			Events.ServerStarted += new ServerStartedEventHandler(Events_ServerStarted);
		}

		private static void Events_ServerStarted() {
			CConsole.DebugLine("global Event OnWorldLoaded.Events_ServerStarted() called :O");
		}


	}

}
