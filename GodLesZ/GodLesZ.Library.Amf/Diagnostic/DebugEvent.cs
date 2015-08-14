using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Diagnostic {

	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class DebugEvent : Hashtable {
		public DebugEvent() {
			this["Source"] = "Server";
			this["EventType"] = "DebugEvent";
			this["Date"] = DateTime.UtcNow;
			this["Time"] = DateTime.UtcNow;
		}
	}
}
