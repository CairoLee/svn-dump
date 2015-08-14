using System;
using System.Collections.Generic;
using System.Text;

using Shaiya.Extended.Server;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server.Scripting {

	public class PrioTest0 {
		[CallPriorityAttribute( 0 )]
		public static void Initialize() {
			CConsole.DebugLine( "PrioTest -> 0" );
		}
	}

	public class PrioTest1 {
		[CallPriorityAttribute( 1 )]
		public static void Initialize() {
			CConsole.DebugLine( "PrioTest -> 1" );
		}
	}

	public class PrioTest2 {
		[CallPriorityAttribute( 2 )]
		public static void Initialize() {
			CConsole.DebugLine( "PrioTest -> 2" );
		}
	}

	public class PrioTest3 {
		[CallPriorityAttribute( 3 )]
		public static void Initialize() {
			CConsole.DebugLine( "PrioTest -> 3" );
		}
	}

	public class PrioTest4 {
		[CallPriorityAttribute( 4 )]
		public static void Initialize() {
			CConsole.DebugLine( "PrioTest -> 4" );
		}
	}

	public class PrioTest5 {
		[CallPriorityAttribute( 5 )]
		public static void Initialize() {
			CConsole.DebugLine( "PrioTest -> 5" );
		}
	}

}
