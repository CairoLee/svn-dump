
namespace GodLesZ.Library.Amf.Messaging.Rtmp.SO {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class SharedObjectTypeMapping {
		public static SharedObjectEventType ToType(byte rtmpType) {
			return (SharedObjectEventType)rtmpType;
		}

		public static byte ToByte(SharedObjectEventType type) {
			switch (type) {
				case SharedObjectEventType.SERVER_CONNECT:
					return 0x01;
				case SharedObjectEventType.SERVER_DISCONNECT:
					return 0x02;
				case SharedObjectEventType.SERVER_SET_ATTRIBUTE:
					return 0x03;
				case SharedObjectEventType.CLIENT_UPDATE_DATA:
					return 0x04;
				case SharedObjectEventType.CLIENT_UPDATE_ATTRIBUTE:
					return 0x05;
				case SharedObjectEventType.SERVER_SEND_MESSAGE:
					return 0x06;
				case SharedObjectEventType.CLIENT_SEND_MESSAGE:
					return 0x06;
				case SharedObjectEventType.CLIENT_STATUS:
					return 0x07;
				case SharedObjectEventType.CLIENT_CLEAR_DATA:
					return 0x08;
				case SharedObjectEventType.CLIENT_DELETE_DATA:
					return 0x09;
				case SharedObjectEventType.SERVER_DELETE_ATTRIBUTE:
					return 0x0A;
				case SharedObjectEventType.CLIENT_INITIAL_DATA:
					return 0x0B;
				default:
					//log.error("Unknown type " + type);
					return 0x00;
			}
		}
	}
}
