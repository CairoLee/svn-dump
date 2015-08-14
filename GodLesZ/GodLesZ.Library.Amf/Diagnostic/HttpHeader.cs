
using System.Collections;
using System.Web;

namespace GodLesZ.Library.Amf.Diagnostic {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class HttpHeader : DebugEvent {
		public HttpHeader() {
			this["EventType"] = "HttpRequestHeaders";
			Hashtable hashtable = new Hashtable();
			if (HttpContext.Current != null) {
				foreach (string key in HttpContext.Current.Request.Headers.AllKeys) {
					string value = HttpContext.Current.Request.Headers[key];
					hashtable[key] = value;
				}
			}
			this["HttpHeaders"] = hashtable;
		}
	}
}
