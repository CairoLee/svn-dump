using System.Collections;

namespace GodLesZ.Library.Amf.Diagnostic {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class TraceHeader : DebugEvent {
		public TraceHeader(ArrayList traceStack) {
			this["EventType"] = "trace";
			this["messages"] = traceStack;
		}
	}
}
