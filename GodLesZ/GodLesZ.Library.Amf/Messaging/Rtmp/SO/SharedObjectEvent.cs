using System;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.SO {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class SharedObjectEvent : ISharedObjectEvent {
		private SharedObjectEventType _type;
		private string _key;
		private object _value;

		/// <summary>
		/// Initializes a new instance of the SharedObjectEvent class with the given initial value.
		/// </summary>
		/// <param name="type">Type of the event.</param>
		/// <param name="key">Key of the event.</param>
		/// <param name="value">Value of the event.</param>
		public SharedObjectEvent(SharedObjectEventType type, String key, Object value) {
			_type = type;
			_key = key;
			_value = value;
		}

		#region ISharedObjectEvent Members

		/// <summary>
		/// Gets the type of the event.
		/// </summary>
		public SharedObjectEventType Type {
			get {
				return _type;
			}
		}
		/// <summary>
		/// Gets the key of the event.
		/// </summary>
		public string Key {
			get {
				return _key;
			}
		}
		/// <summary>
		/// Gets the value of the event.
		/// </summary>
		public object Value {
			get {
				return _value;
			}
		}

		#endregion

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString() {
			return "SOEvent(" + _type + ", " + _key + ", " + _value + ")";
		}
	}
}
