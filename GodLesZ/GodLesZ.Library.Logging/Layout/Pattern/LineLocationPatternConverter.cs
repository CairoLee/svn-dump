using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Write the caller location line number to the output
	/// </summary>
	/// <remarks>
	/// <para>
	/// Writes the value of the <see cref="LocationInfo.LineNumber"/> for
	/// the event to the output writer.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class LineLocationPatternConverter : PatternLayoutConverter {
		/// <summary>
		/// Write the caller location line number to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// Writes the value of the <see cref="LocationInfo.LineNumber"/> for
		/// the <paramref name="loggingEvent"/> to the output <paramref name="writer"/>.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			writer.Write(loggingEvent.LocationInformation.LineNumber);
		}
	}
}
