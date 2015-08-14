using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Listener that is notified about packets received from a stream.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamListener {
		/// <summary>
		/// Notification that a packet has been received from a stream.
		/// </summary>
		/// <param name="stream">The stream the packet has been received for.</param>
		/// <param name="packet">The packet received.</param>
		void PacketReceived(IBroadcastStream stream, IStreamPacket packet);
	}
}
