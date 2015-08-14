using System;

namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public interface IRtmpHandler {
		/// <summary>
		/// Connection open event.
		/// </summary>
		/// <param name="connection">Connection object.</param>
		void ConnectionOpened(RtmpConnection connection);
		/// <summary>
		/// Message recieved.
		/// </summary>
		/// <param name="connection">Connection object.</param>
		/// <param name="message">Message object.</param>
		void MessageReceived(RtmpConnection connection, object message);
		/// <summary>
		/// Message sent.
		/// </summary>
		/// <param name="connection">Connection object.</param>
		/// <param name="message">Message object.</param>
		void MessageSent(RtmpConnection connection, object message);
		/// <summary>
		/// Connection closed.
		/// </summary>
		/// <param name="connection">Connection object.</param>
		void ConnectionClosed(RtmpConnection connection);
	}
}
