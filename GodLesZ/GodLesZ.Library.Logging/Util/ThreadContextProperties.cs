using System;
using System.Collections;

namespace GodLesZ.Library.Logging.Util {
	/// <summary>
	/// Implementation of Properties collection for the <see cref="GodLesZ.Library.Logging.ThreadContext"/>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Class implements a collection of properties that is specific to each thread.
	/// The class is not synchronized as each thread has its own <see cref="PropertiesDictionary"/>.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	public sealed class ThreadContextProperties : ContextPropertiesBase {
		#region Private Instance Fields

		/// <summary>
		/// The thread local data slot to use to store a PropertiesDictionary.
		/// </summary>
		private readonly static LocalDataStoreSlot s_threadLocalSlot = System.Threading.Thread.AllocateDataSlot();

		#endregion Private Instance Fields

		#region Public Instance Constructors

		/// <summary>
		/// Internal constructor
		/// </summary>
		/// <remarks>
		/// <para>
		/// Initializes a new instance of the <see cref="ThreadContextProperties" /> class.
		/// </para>
		/// </remarks>
		internal ThreadContextProperties() {
		}

		#endregion Public Instance Constructors

		#region Public Instance Properties

		/// <summary>
		/// Gets or sets the value of a property
		/// </summary>
		/// <value>
		/// The value for the property with the specified key
		/// </value>
		/// <remarks>
		/// <para>
		/// Gets or sets the value of a property
		/// </para>
		/// </remarks>
		override public object this[string key] {
			get {
				PropertiesDictionary dictionary = GetProperties(false);
				if (dictionary != null) {
					return dictionary[key];
				}
				return null;
			}
			set {
				GetProperties(true)[key] = value;
			}
		}

		#endregion Public Instance Properties

		#region Public Instance Methods

		/// <summary>
		/// Remove a property
		/// </summary>
		/// <param name="key">the key for the entry to remove</param>
		/// <remarks>
		/// <para>
		/// Remove a property
		/// </para>
		/// </remarks>
		public void Remove(string key) {
			PropertiesDictionary dictionary = GetProperties(false);
			if (dictionary != null) {
				dictionary.Remove(key);
			}
		}

		/// <summary>
		/// Clear all properties
		/// </summary>
		/// <remarks>
		/// <para>
		/// Clear all properties
		/// </para>
		/// </remarks>
		public void Clear() {
			PropertiesDictionary dictionary = GetProperties(false);
			if (dictionary != null) {
				dictionary.Clear();
			}
		}

		#endregion Public Instance Methods

		#region Internal Instance Methods

		/// <summary>
		/// Get the <c>PropertiesDictionary</c> for this thread.
		/// </summary>
		/// <param name="create">create the dictionary if it does not exist, otherwise return null if is does not exist</param>
		/// <returns>the properties for this thread</returns>
		/// <remarks>
		/// <para>
		/// The collection returned is only to be used on the calling thread. If the
		/// caller needs to share the collection between different threads then the 
		/// caller must clone the collection before doing so.
		/// </para>
		/// </remarks>
		internal PropertiesDictionary GetProperties(bool create) {
			PropertiesDictionary properties = (PropertiesDictionary)System.Threading.Thread.GetData(s_threadLocalSlot);
			if (properties == null && create) {
				properties = new PropertiesDictionary();
				System.Threading.Thread.SetData(s_threadLocalSlot, properties);
			}
			return properties;
		}

		#endregion Internal Instance Methods
	}
}


