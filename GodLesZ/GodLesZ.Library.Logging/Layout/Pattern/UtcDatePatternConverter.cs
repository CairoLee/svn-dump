using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Util;
using GodLesZ.Library.Logging.DateFormatter;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Write the TimeStamp to the output
	/// </summary>
	/// <remarks>
	/// <para>
	/// Date pattern converter, uses a <see cref="IDateFormatter"/> to format 
	/// the date of a <see cref="LoggingEvent"/>.
	/// </para>
	/// <para>
	/// Uses a <see cref="IDateFormatter"/> to format the <see cref="LoggingEvent.TimeStamp"/> 
	/// in Universal time.
	/// </para>
	/// <para>
	/// See the <see cref="DatePatternConverter"/> for details on the date pattern syntax.
	/// </para>
	/// </remarks>
	/// <seealso cref="DatePatternConverter"/>
	/// <author>Nicko Cadell</author>
	internal class UtcDatePatternConverter : DatePatternConverter {
		/// <summary>
		/// Write the TimeStamp to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// Pass the <see cref="LoggingEvent.TimeStamp"/> to the <see cref="IDateFormatter"/>
		/// for it to render it to the writer.
		/// </para>
		/// <para>
		/// The <see cref="LoggingEvent.TimeStamp"/> passed is in the local time zone, this is converted
		/// to Universal time before it is rendered.
		/// </para>
		/// </remarks>
		/// <seealso cref="DatePatternConverter"/>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			try {
				m_dateFormatter.FormatDate(loggingEvent.TimeStamp.ToUniversalTime(), writer);
			} catch (Exception ex) {
				LogLog.Error(declaringType, "Error occurred while converting date.", ex);
			}
		}

		#region Private Static Fields

		/// <summary>
		/// The fully qualified type of the UtcDatePatternConverter class.
		/// </summary>
		/// <remarks>
		/// Used by the internal logger to record the Type of the
		/// log message.
		/// </remarks>
		private readonly static Type declaringType = typeof(UtcDatePatternConverter);

		#endregion Private Static Fields
	}
}
