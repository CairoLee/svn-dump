using System;
using GodLesZ.Library.Amf.Messaging.Api.Statistics;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// A broadcast stream that comes from client.
	/// </summary>
	[CLSCompliant(false)]
	public interface IClientBroadcastStream : IClientStream, IBroadcastStream {
		/// <summary>
		/// Notify client that stream is ready for publishing.
		/// </summary>
		void StartPublishing();
		/// <summary>
		/// Gets statistics about the stream.
		/// </summary>
		IClientBroadcastStreamStatistics Statistics { get; }
	}
}
