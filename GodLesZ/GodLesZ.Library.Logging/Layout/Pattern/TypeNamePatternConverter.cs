using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Pattern converter for the class name
	/// </summary>
	/// <remarks>
	/// <para>
	/// Outputs the <see cref="LocationInfo.ClassName"/> of the event.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class TypeNamePatternConverter : NamedPatternConverter {
		/// <summary>
		/// Gets the fully qualified name of the class
		/// </summary>
		/// <param name="loggingEvent">the event being logged</param>
		/// <returns>The fully qualified type name for the caller location</returns>
		/// <remarks>
		/// <para>
		/// Returns the <see cref="LocationInfo.ClassName"/> of the <paramref name="loggingEvent"/>.
		/// </para>
		/// </remarks>
		override protected string GetFullyQualifiedName(LoggingEvent loggingEvent) {
			return loggingEvent.LocationInformation.ClassName;
		}
	}
}
