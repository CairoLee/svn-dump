using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Stream data packet.
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface IStreamData {
		ByteBuffer Data { get; }
	}
}
