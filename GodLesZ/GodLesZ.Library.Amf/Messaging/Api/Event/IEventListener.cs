
namespace GodLesZ.Library.Amf.Messaging.Api.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IEventListener {
		/// <summary>
		/// Event notification. 
		/// </summary>
		/// <param name="event">The event object.</param>
		void NotifyEvent(IEvent @event);
	}
}
