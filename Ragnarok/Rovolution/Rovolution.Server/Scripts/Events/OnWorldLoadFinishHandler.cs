using System;
using System.Collections.Generic;
using System.Text;

namespace Rovolution.Server.Scripts {

	public class OnWorldLoadFinishHandler {

		public static void OnWorldLoadFinish() {
			ServerConsole.DebugLine("global Event OnWorldLoadFinish called :O");
		}

		public static void OnServerStarted() {
			ServerConsole.DebugLine("global Event OnServerStarted called :O");
		}

	}

}
