using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Context {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface ISessionState : ICollection, IEnumerable {
		/// <summary>
		/// Adds a new item to the session-state collection
		/// </summary>
		/// <param name="name">The name of the item to add to the session-state collection.</param>
		/// <param name="value">The value of the item to add to the session-state collection.</param>
		void Add(string name, Object value);
		/// <summary>
		/// Removes all keys and values from the session-state collection. 
		/// </summary>
		void Clear();
		/// <summary>
		/// Deletes an item from the session-state collection.
		/// </summary>
		/// <param name="name">The name of the item to delete from the session-state collection.</param>
		/// <remarks>If the session-state collection does not contain an element with the specified name, the collection remains unchanged. No exception is thrown.</remarks>
		void Remove(string name);
		/// <summary>
		/// Removes all keys and values from the session-state collection. 
		/// </summary>
		void RemoveAll();
		/// <summary>
		/// Deletes an item at a specified index from the session-state collection.
		/// </summary>
		/// <param name="index">The index of the item to remove from the session-state collection.</param>
		void RemoveAt(int index);
		/// <summary>
		/// Gets the unique identifier for the session. 
		/// </summary>
		string SessionID { get; }
		/// <summary>
		/// Gets or sets a session value by name.
		/// </summary>
		/// <param name="name">The key name of the session value.</param>
		/// <returns>The session-state value with the specified name.</returns>
		Object this[string name] { get; set; }
		/// <summary>
		/// Gets or sets a session value by numerical index.
		/// </summary>
		/// <param name="index">The numerical index of the session value.</param>
		/// <returns>The session-state value stored at the specified index.</returns>
		Object this[int index] { get; set; }
	}
}
