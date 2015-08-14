using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// AMF3 stream send message.
	/// </summary>
	class FlexStreamSend : Notify {
		internal FlexStreamSend() {
			_dataType = Constants.TypeFlexStreamEnd;
		}

		internal FlexStreamSend(ByteBuffer data)
			: this() {
			_data = data;
		}

		internal FlexStreamSend(byte[] data)
			: this() {
			_data = ByteBuffer.Wrap(data);
		}
	}
}
