using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class Unknown : BaseEvent {
		protected ByteBuffer _data;

		public Unknown(ByteBuffer data)
			: base(EventType.SYSTEM) {
			_dataType = Constants.TypeUnknown;
			_data = data;
		}

		public Unknown(byte dataType, ByteBuffer data)
			: base(EventType.SYSTEM) {
			_dataType = dataType;
			_data = data;
		}

		public Unknown(byte dataType, byte[] data)
			: this(dataType, ByteBuffer.Wrap(data)) {
		}

		public ByteBuffer Data {
			get { return _data; }
		}
	}
}
