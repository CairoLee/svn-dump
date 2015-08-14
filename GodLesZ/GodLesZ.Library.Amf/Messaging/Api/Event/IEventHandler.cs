
namespace GodLesZ.Library.Amf.Messaging.Api.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IEventHandler {
		/// <summary>
		/// Handle an event.
		/// </summary>
		/// <param name="event">Event to handle.</param>
		/// <returns>true if event was handled, false if it should bubble.</returns>
		bool HandleEvent(IEvent @event);
	}
}
