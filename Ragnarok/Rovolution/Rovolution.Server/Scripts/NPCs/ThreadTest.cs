using System;
using System.IO;
using System.Threading;

namespace Rovolution.Server.Scripts {

	public class ThreadTest {

		public static void OnWorldLoadFinish() {
			Thread.Sleep(1000);
			ServerConsole.DebugLine("ThreadTest: Initialize called! Thread will sleep 5secs...");
			Thread.Sleep(5000);
			ServerConsole.DebugLine("ThreadTest: Initialize released!");
		}


	}

}
