using System.Collections;

namespace GodLesZ.Library.Amf.Context {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IApplicationState : IEnumerable {
		/// <summary>
		/// Gets the value of a single ApplicationState object by name.
		/// </summary>
		/// <param name="name">The name of the object in the collection.</param>
		/// <returns>The object referenced by name.</returns>
		object this[string name] { get; set; }
		/// <summary>
		/// Removes the named object from an ApplicationState collection.
		/// </summary>
		/// <param name="key">The name of the object to be removed from the collection.</param>
		void Remove(string key);
		/// <summary>
		/// Adds a new object to the ApplicationState collection.
		/// </summary>
		/// <param name="name">The name of the object to be added to the collection.</param>
		/// <param name="value">The value of the object.</param>
		void Add(string name, object value);
		/// <summary>
		/// Locks access to an IApplicationState variable to facilitate access synchronization.
		/// </summary>
		void Lock();
		/// <summary>
		/// Unlocks access to an IApplicationState variable to facilitate access synchronization.
		/// </summary>
		void UnLock();
	}
}
