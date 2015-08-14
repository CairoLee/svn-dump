using System.Collections;
using GodLesZ.Library.Amf.Collections;

namespace GodLesZ.Library.Amf.Json {
	public class JavaScriptParameters : ReadOnlyList {
		public static readonly JavaScriptParameters Empty = new JavaScriptParameters(new ArrayList());

		public JavaScriptParameters(IList list)
			: base(list) {
		}
	}
}