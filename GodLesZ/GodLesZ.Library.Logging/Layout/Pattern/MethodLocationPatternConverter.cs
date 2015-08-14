using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Write the method name to the output
	/// </summary>
	/// <remarks>
	/// <para>
	/// Writes the caller location <see cref="LocationInfo.MethodName"/> to
	/// the output.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class MethodLocationPatternConverter : PatternLayoutConverter {
		/// <summary>
		/// Write the method name to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// Writes the caller location <see cref="LocationInfo.MethodName"/> to
		/// the output.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			writer.Write(loggingEvent.LocationInformation.MethodName);
		}
	}
}
