using System;
using System.Text;

using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging.Layout {
	/// <summary>
	/// Extract the date from the <see cref="LoggingEvent"/>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Extract the date from the <see cref="LoggingEvent"/>
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public class RawTimeStampLayout : IRawLayout {
		#region Constructors

		/// <summary>
		/// Constructs a RawTimeStampLayout
		/// </summary>
		public RawTimeStampLayout() {
		}

		#endregion

		#region Implementation of IRawLayout

		/// <summary>
		/// Gets the <see cref="LoggingEvent.TimeStamp"/> as a <see cref="DateTime"/>.
		/// </summary>
		/// <param name="loggingEvent">The event to format</param>
		/// <returns>returns the time stamp</returns>
		/// <remarks>
		/// <para>
		/// Gets the <see cref="LoggingEvent.TimeStamp"/> as a <see cref="DateTime"/>.
		/// </para>
		/// <para>
		/// The time stamp is in local time. To format the time stamp
		/// in universal time use <see cref="RawUtcTimeStampLayout"/>.
		/// </para>
		/// </remarks>
		public virtual object Format(LoggingEvent loggingEvent) {
			return loggingEvent.TimeStamp;
		}

		#endregion
	}
}
