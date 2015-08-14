using System;
using System.Collections.Generic;
using System.Text;

namespace Rovolution.Server.Scripts {

	public class PrioTest0 {
		[CallPriorityAttribute(0)]
		public static void OnWorldLoadFinish() {
			ServerConsole.DebugLine("PrioTest -> 0");
		}
	}

	public class PrioTest1 {
		[CallPriorityAttribute(1)]
		public static void OnWorldLoadFinish() {
			ServerConsole.DebugLine("PrioTest -> 1");
		}
	}

	public class PrioTest2 {
		[CallPriorityAttribute(2)]
		public static void OnWorldLoadFinish() {
			ServerConsole.DebugLine("PrioTest -> 2");
		}
	}

	public class PrioTest3 {
		[CallPriorityAttribute(3)]
		public static void OnWorldLoadFinish() {
			ServerConsole.DebugLine("PrioTest -> 3");
		}
	}

	public class PrioTest4 {
		[CallPriorityAttribute(4)]
		public static void OnWorldLoadFinish() {
			ServerConsole.DebugLine("PrioTest -> 4");
		}
	}

	public class PrioTest5 {
		[CallPriorityAttribute(5)]
		public static void OnWorldLoadFinish() {
			ServerConsole.DebugLine("PrioTest -> 5");
		}
	}

}
