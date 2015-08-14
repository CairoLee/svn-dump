// .NET Compact Framework 1.0 has no support for ASP.NET
// SSCLI 1.0 has no support for ASP.NET
#if !NETCF && !SSCLI && !CLIENT_PROFILE

using System.IO;
using System.Web;
using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Converter for items in the <see cref="HttpContext" />.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Outputs an item from the <see cref="HttpContext" />.
	/// </para>
	/// </remarks>
	/// <author>Ron Grabowski</author>
	internal sealed class AspNetContextPatternConverter : AspNetPatternLayoutConverter {
		/// <summary>
		/// Write the ASP.Net HttpContext item to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">The <see cref="LoggingEvent" /> on which the pattern converter should be executed.</param>
		/// <param name="httpContext">The <see cref="HttpContext" /> under which the ASP.Net request is running.</param>
		/// <remarks>
		/// <para>
		/// Writes out the value of a named property. The property name
		/// should be set in the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/>
		/// property.
		/// </para>
		/// </remarks>
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent, HttpContext httpContext) {
			if (Option != null) {
				WriteObject(writer, loggingEvent.Repository, httpContext.Items[Option]);
			} else {
				WriteObject(writer, loggingEvent.Repository, httpContext.Items);
			}
		}
	}
}

#endif