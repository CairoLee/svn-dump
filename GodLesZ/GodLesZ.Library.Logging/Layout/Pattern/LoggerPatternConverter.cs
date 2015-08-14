using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Converter for logger name
	/// </summary>
	/// <remarks>
	/// <para>
	/// Outputs the <see cref="LoggingEvent.LoggerName"/> of the event.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class LoggerPatternConverter : NamedPatternConverter {
		/// <summary>
		/// Gets the fully qualified name of the logger
		/// </summary>
		/// <param name="loggingEvent">the event being logged</param>
		/// <returns>The fully qualified logger name</returns>
		/// <remarks>
		/// <para>
		/// Returns the <see cref="LoggingEvent.LoggerName"/> of the <paramref name="loggingEvent"/>.
		/// </para>
		/// </remarks>
		override protected string GetFullyQualifiedName(LoggingEvent loggingEvent) {
			return loggingEvent.LoggerName;
		}
	}
}
