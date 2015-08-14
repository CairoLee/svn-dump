using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// ISubscriberStream is a stream from subscriber's point of view. That is, it provides methods for common stream operations like play, pause or seek.
	/// </summary>
	[CLSCompliant(false)]
	public interface ISubscriberStream : IClientStream {
		/// <summary>
		/// Start playing.
		/// </summary>
		void Play();
		/// <summary>
		/// Pause at a position for current playing item.
		/// </summary>
		/// <param name="position">Position for pause in millisecond.</param>
		void Pause(int position);
		/// <summary>
		/// Resume from a position for current playing item.
		/// </summary>
		/// <param name="position">Position for resume in millisecond.</param>
		void Resume(int position);
		/// <summary>
		/// Seek into a position for current playing item.
		/// </summary>
		/// <param name="position">Position for seek in millisecond.</param>
		void Seek(int position);
		/// <summary>
		/// Gets whether the stream is currently paused.
		/// </summary>
		bool IsPaused { get; }
		/// <summary>
		/// Should the stream send video to the client.
		/// </summary>
		/// <param name="receive"></param>
		void ReceiveVideo(bool receive);
		/// <summary>
		/// Should the stream send audio to the client.
		/// </summary>
		/// <param name="receive"></param>
		void ReceiveAudio(bool receive);
	}
}
