using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Converter to include event NDC
	/// </summary>
	/// <remarks>
	/// <para>
	/// Outputs the value of the event property named <c>NDC</c>.
	/// </para>
	/// <para>
	/// The <see cref="PropertyPatternConverter"/> should be used instead.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class NdcPatternConverter : PatternLayoutConverter {
		/// <summary>
		/// Write the event NDC to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// As the thread context stacks are now stored in named event properties
		/// this converter simply looks up the value of the <c>NDC</c> property.
		/// </para>
		/// <para>
		/// The <see cref="PropertyPatternConverter"/> should be used instead.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			// Write the value for the specified key
			WriteObject(writer, loggingEvent.Repository, loggingEvent.LookupProperty("NDC"));
		}
	}
}
