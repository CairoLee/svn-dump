using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Util;
using GodLesZ.Library.Logging.DateFormatter;

namespace GodLesZ.Library.Logging.Util.PatternStringConverters {
	/// <summary>
	/// Write the UTC date time to the output
	/// </summary>
	/// <remarks>
	/// <para>
	/// Date pattern converter, uses a <see cref="IDateFormatter"/> to format 
	/// the current date and time in Universal time.
	/// </para>
	/// <para>
	/// See the <see cref="DatePatternConverter"/> for details on the date pattern syntax.
	/// </para>
	/// </remarks>
	/// <seealso cref="DatePatternConverter"/>
	/// <author>Nicko Cadell</author>
	internal class UtcDatePatternConverter : DatePatternConverter {
		/// <summary>
		/// Write the current date and time to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="state">null, state is not set</param>
		/// <remarks>
		/// <para>
		/// Pass the current date and time to the <see cref="IDateFormatter"/>
		/// for it to render it to the writer.
		/// </para>
		/// <para>
		/// The date is in Universal time when it is rendered.
		/// </para>
		/// </remarks>
		/// <seealso cref="DatePatternConverter"/>
		override protected void Convert(TextWriter writer, object state) {
			try {
				m_dateFormatter.FormatDate(DateTime.UtcNow, writer);
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
