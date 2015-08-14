using GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Messages;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	enum FrameDropperState {
		/// <summary>
		/// Send keyframes, interframes and disposable interframes.
		/// </summary>
		SEND_ALL = 0,
		/// <summary>
		/// Send keyframes and interframes.
		/// </summary>
		SEND_INTERFRAMES = 1,
		/// <summary>
		/// Send keyframes only.
		/// </summary>
		SEND_KEYFRAMES = 2,
		/// <summary>
		/// Send keyframes only and switch to SEND_INTERFRAMES later.
		/// </summary>
		SEND_KEYFRAMES_CHECK = 3
	}

	/// <summary>
	/// Interface for classes that implement logic to drop frames.
	/// </summary>
	interface IFrameDropper {
		/// <summary>
		/// Checks if a message may be sent to the subscriber.
		/// </summary>
		/// <param name="message">The message to check.</param>
		/// <param name="pending">The number of pending messages.</param>
		/// <returns><code>true</code> if the packet may be sent, otherwise <code>false</code>.</returns>
		bool CanSendPacket(RtmpMessage message, long pending);
		/// <summary>
		/// Notify that a packet has been dropped.
		/// </summary>
		/// <param name="message">The message that was dropped.</param>
		void DropPacket(RtmpMessage message);
		/// <summary>
		/// Notify that a message has been sent.
		/// </summary>
		/// <param name="message">The message that was sent.</param>
		void SendPacket(RtmpMessage message);
		/// <summary>
		/// Reset the frame dropper.
		/// </summary>
		void Reset();
		/// <summary>
		/// Reset the frame dropper to a given state.
		/// </summary>
		/// <param name="state">The state to reset the frame dropper to.</param>
		void Reset(FrameDropperState state);
	}
}
