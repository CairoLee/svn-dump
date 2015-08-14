using GodLesZ.Library.Amf.Messaging.Rtmp.Event;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Notify handler for client-side streams.
	/// </summary>
	interface INetStreamEventHandler {
		void OnStreamEvent(Notify notify);
	}
}
