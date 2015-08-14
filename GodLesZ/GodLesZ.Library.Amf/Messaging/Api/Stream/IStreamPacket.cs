using System;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Packet containing stream data.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamPacket {
		/// <summary>
		/// Type of the packet.
		/// </summary>
		byte DataType { get; }
		/// <summary>
		/// Timestamp of this packet in milliseconds.
		/// </summary>
		int Timestamp { get; }
		/// <summary>
		/// Packet contents.
		/// </summary>
		ByteBuffer Data { get; }
	}
}
