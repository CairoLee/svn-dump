using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging.Util.PatternStringConverters {
	/// <summary>
	/// Write the name of the current AppDomain to the output
	/// </summary>
	/// <remarks>
	/// <para>
	/// Write the name of the current AppDomain to the output writer
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class AppDomainPatternConverter : PatternConverter {
		/// <summary>
		/// Write the name of the current AppDomain to the output
		/// </summary>
		/// <param name="writer">the writer to write to</param>
		/// <param name="state">null, state is not set</param>
		/// <remarks>
		/// <para>
		/// Writes name of the current AppDomain to the output <paramref name="writer"/>.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, object state) {
			writer.Write(SystemInfo.ApplicationFriendlyName);
		}
	}
}
