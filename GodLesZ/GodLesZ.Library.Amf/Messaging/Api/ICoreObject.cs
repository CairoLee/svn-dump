
using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// Base interface containing common methods and attributs for all core objects.
	/// </summary>
	public interface ICoreObject : IAttributeStore, IEventDispatcher, IEventHandler, IEventListener {
	}
}
