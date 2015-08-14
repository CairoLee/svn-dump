
#if !(NET_1_1)

#endif
using GodLesZ.Library.Amf.Collections.Generic;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.SO {
	/// <summary>
	/// Shared object message.
	/// </summary>
	interface ISharedObjectMessage : IRtmpEvent {
		/// <summary>
		/// Gets the name of the shared object this message belongs to.
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Returns the version to modify.
		/// </summary>
		int Version { get; }
		/// <summary>
		/// Gets a value indicating whether the message affects a persistent shared object.
		/// </summary>
		bool IsPersistent { get; }
		/// <summary>
		/// Returns a set of ISharedObjectEvent objects containing informations what to change.
		/// </summary>
		IQueue<ISharedObjectEvent> Events { get; }
		/// <summary>
		/// Add a shared object event.
		/// </summary>
		/// <param name="type">Event type.</param>
		/// <param name="key">Handler key.</param>
		/// <param name="value">Event value.</param>
		void AddEvent(SharedObjectEventType type, string key, object value);
		/// <summary>
		/// Add a shared object event.
		/// </summary>
		/// <param name="sharedObjectEvent">Shared object event.</param>
		void AddEvent(ISharedObjectEvent sharedObjectEvent);
		/// <summary>
		/// Clear shared object.
		/// </summary>
		void Clear();
		/// <summary>
		/// Gets a value indicating whether the shared object is empty.
		/// </summary>
		bool IsEmpty { get; }
	}
}
