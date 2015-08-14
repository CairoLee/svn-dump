// .NET Compact Framework 1.0 has no support for ASP.NET
// SSCLI 1.0 has no support for ASP.NET
#if !NETCF && !SSCLI && !CLIENT_PROFILE

using System.IO;
using System.Web;
using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Converter for items in the ASP.Net Cache.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Outputs an item from the <see cref="HttpRuntime.Cache" />.
	/// </para>
	/// </remarks>
	/// <author>Ron Grabowski</author>
	internal sealed class AspNetSessionPatternConverter : AspNetPatternLayoutConverter {
		/// <summary>
		/// Write the ASP.Net Cache item to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">The <see cref="LoggingEvent" /> on which the pattern converter should be executed.</param>
		/// <param name="httpContext">The <see cref="HttpContext" /> under which the ASP.Net request is running.</param>
		/// <remarks>
		/// <para>
		/// Writes out the value of a named property. The property name
		/// should be set in the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/>
		/// property. If no property has been set, all key value pairs from the Session will
		/// be written to the output.
		/// </para>
		/// </remarks>
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent, HttpContext httpContext) {
			if (httpContext.Session != null) {
				if (Option != null) {
					WriteObject(writer, loggingEvent.Repository, httpContext.Session.Contents[Option]);
				} else {
					WriteObject(writer, loggingEvent.Repository, httpContext.Session);
				}
			} else {
				writer.Write(SystemInfo.NotAvailableText);
			}
		}
	}
}

#endif