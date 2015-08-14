using System;
using System.Text;

using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging.Layout {
	/// <summary>
	/// Extract the value of a property from the <see cref="LoggingEvent"/>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Extract the value of a property from the <see cref="LoggingEvent"/>
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	public class RawPropertyLayout : IRawLayout {
		#region Constructors

		/// <summary>
		/// Constructs a RawPropertyLayout
		/// </summary>
		public RawPropertyLayout() {
		}

		#endregion

		private string m_key;

		/// <summary>
		/// The name of the value to lookup in the LoggingEvent Properties collection.
		/// </summary>
		/// <value>
		/// Value to lookup in the LoggingEvent Properties collection
		/// </value>
		/// <remarks>
		/// <para>
		/// String name of the property to lookup in the <see cref="LoggingEvent"/>.
		/// </para>
		/// </remarks>
		public string Key {
			get { return m_key; }
			set { m_key = value; }
		}

		#region Implementation of IRawLayout

		/// <summary>
		/// Lookup the property for <see cref="Key"/>
		/// </summary>
		/// <param name="loggingEvent">The event to format</param>
		/// <returns>returns property value</returns>
		/// <remarks>
		/// <para>
		/// Looks up and returns the object value of the property
		/// named <see cref="Key"/>. If there is no property defined
		/// with than name then <c>null</c> will be returned.
		/// </para>
		/// </remarks>
		public virtual object Format(LoggingEvent loggingEvent) {
			return loggingEvent.LookupProperty(m_key);
		}

		#endregion
	}
}
