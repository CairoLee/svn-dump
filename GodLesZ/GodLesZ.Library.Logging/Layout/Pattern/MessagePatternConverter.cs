using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Writes the event message to the output
	/// </summary>
	/// <remarks>
	/// <para>
	/// Uses the <see cref="LoggingEvent.WriteRenderedMessage"/> method
	/// to write out the event message.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class MessagePatternConverter : PatternLayoutConverter {
		/// <summary>
		/// Writes the event message to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// Uses the <see cref="LoggingEvent.WriteRenderedMessage"/> method
		/// to write out the event message.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			loggingEvent.WriteRenderedMessage(writer);
		}
	}
}
