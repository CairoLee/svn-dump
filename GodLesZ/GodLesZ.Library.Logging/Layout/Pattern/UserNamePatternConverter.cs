using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Converter to include event user name
	/// </summary>
	/// <author>Douglas de la Torre</author>
	/// <author>Nicko Cadell</author>
	internal sealed class UserNamePatternConverter : PatternLayoutConverter {
		/// <summary>
		/// Convert the pattern to the rendered message
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			writer.Write(loggingEvent.UserName);
		}
	}
}
