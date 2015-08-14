using System;
using System.Collections;

using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Api.SO {
	/// <summary>
	/// Serverside access to shared objects. Changes to the shared objects are
	/// propagated to all subscribed clients.
	/// 
	/// If you want to modify multiple attributes and notify the clients about all
	/// changes at once, you can use code like this:
	/// <p>
	/// <code>
	/// sharedObject.BeginUpdate();<br />
	/// sharedObject.SetAttribute("One", "1");<br />
	/// sharedObject.SetAttribute("Two", "2");<br />
	/// sharedObject.RemoveAttribute("Three");<br />
	/// sharedObject.EndUpdate();<br />
	/// </code>
	/// </p>
	/// 
	/// All changes between BeginUpdate and EndUpdate will be sent to the clients.
	/// using one notification event.
	/// </summary>
	[CLSCompliant(false)]
	public interface ISharedObject : IBasicScope, ISharedObjectSecurityService, ISharedObjectHandlerProvider {
		/// <summary>
		/// Returns the version of the shared object. The version is incremented
		/// automatically on each modification.
		/// </summary>
		int Version { get; }
		/// <summary>
		/// Checks if the object has been created as persistent shared object by the client.
		/// </summary>
		bool IsPersistentObject { get; }
		/// <summary>
		/// Sends a message to a handler of the shared object.
		/// </summary>
		/// <param name="handler">The name of the handler to call.</param>
		/// <param name="arguments">A list of objects that should be passed as arguments to the handler.</param>
		void SendMessage(string handler, IList arguments);
		/// <summary>
		/// Start performing multiple updates to the shared object from serverside code.
		/// </summary>
		void BeginUpdate();
		/// <summary>
		/// Start performing multiple updates to the shared object from a connected client.
		/// </summary>
		/// <param name="source"></param>
		void BeginUpdate(IEventListener source);
		/// <summary>
		/// The multiple updates are complete, notify clients about all changes at once.
		/// </summary>
		void EndUpdate();
		/// <summary>
		/// Register object that will be notified about update events.
		/// </summary>
		/// <param name="listener">The object to notify.</param>
		void AddSharedObjectListener(ISharedObjectListener listener);
		/// <summary>
		/// Unregister object to not longer receive update events.
		/// </summary>
		/// <param name="listener">The object to unregister.</param>
		void RemoveSharedObjectListener(ISharedObjectListener listener);
		/// <summary>
		/// Returns the locked state of this SharedObject.
		/// </summary>
		bool IsLocked { get; }
		/// <summary>
		/// Deletes all the attributes and sends a clear event to all listeners. The
		/// persistent data object is also removed from a persistent shared object.
		/// </summary>
		/// <returns></returns>
		bool Clear();
		/// <summary>
		/// Detaches a reference from this shared object, this will destroy the
		/// reference immediately. This is useful when you don't want to proxy a
		/// shared object any longer.
		/// </summary>
		void Close();
		/// <summary>
		/// Indicates that the value of a property in the shared object has changed.
		/// In most cases, such as when the value of a property is a primitive type like String or Number, you can call SetAttribute() instead of calling SetDirty(). However, when the value of a property is an object that contains its own properties, call SetDirty() to indicate when a value within the object has changed.
		/// </summary>
		/// <param name="propertyName">The name of the property that has changed.</param>
		void SetDirty(string propertyName);
	}
}
