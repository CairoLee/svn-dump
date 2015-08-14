using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.SO {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class FlexSharedObjectMessage : SharedObjectMessage {
		public FlexSharedObjectMessage(string name, int version, bool persistent)
			: this(null, name, version, persistent) {
		}

		public FlexSharedObjectMessage(IEventListener source, string name, int version, bool persistent)
			: base(source, name, version, persistent) {
			_dataType = Constants.TypeFlexSharedObject;
		}
	}
}
