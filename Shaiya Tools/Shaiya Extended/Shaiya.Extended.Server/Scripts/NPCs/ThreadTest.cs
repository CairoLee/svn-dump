using System;
using System.IO;
using System.Threading;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server.Scripting {

	public class ThreadTest : NpcScript {

		public static void Core( object[] args ) {
			Thread.Sleep( 1000 );
			CConsole.StatusLine( "ThreadTest: Core called! {0} parameters!", ( args == null ? "0 (null)" : args.Length.ToString() ) );
		}

		public static void Initialize() {
			Thread.Sleep( 1000 );
			CConsole.StatusLine( "ThreadTest: Initialize called! Thread will sleep 5secs..." );
			Thread.Sleep( 5000 );
			CConsole.StatusLine( "ThreadTest: Initialize released!" );
		}


	}

}
