using System;
using System.Collections.Generic;
using System.Text;

using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server.Scripting {

	public class OnWorldLoaded {

		public static void Initialize() {
			Events.ServerStarted += new ServerStartedEventHandler( Events_ServerStarted );
		}

		private static void Events_ServerStarted() {
			CConsole.DebugLine( "global Event OnWorldLoaded.Events_ServerStarted() called :O" );
		}


	}

}
