
using System.Collections;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Diagnostic {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMFRequestHeaders : DebugEvent {
		public AMFRequestHeaders(AMFMessage amfMessage) {
			this["EventType"] = "AmfHeaders";
			Hashtable hashtable = new Hashtable();
			for (int i = 0; i < amfMessage.HeaderCount; i++) {
				AMFHeader amfHeader = amfMessage.GetHeaderAt(i);
				if (amfHeader != null && amfHeader.Name != null)
					hashtable[amfHeader.Name] = amfHeader.Content;
			}
			this["AmfHeaders"] = hashtable;
		}
	}
}
