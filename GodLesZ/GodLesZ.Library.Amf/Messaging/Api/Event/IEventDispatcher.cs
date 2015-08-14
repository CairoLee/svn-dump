
namespace GodLesZ.Library.Amf.Messaging.Api.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IEventDispatcher {
		/// <summary>
		/// Dispatches an event.
		/// </summary>
		/// <param name="event">Event to dispatch.</param>
		void DispatchEvent(IEvent @event);
	}
}
