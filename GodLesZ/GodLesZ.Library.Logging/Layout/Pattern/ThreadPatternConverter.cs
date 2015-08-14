using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Converter to include event thread name
	/// </summary>
	/// <remarks>
	/// <para>
	/// Writes the <see cref="LoggingEvent.ThreadName"/> to the output.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class ThreadPatternConverter : PatternLayoutConverter {
		/// <summary>
		/// Write the ThreadName to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// Writes the <see cref="LoggingEvent.ThreadName"/> to the <paramref name="writer" />.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			writer.Write(loggingEvent.ThreadName);
		}
	}
}
