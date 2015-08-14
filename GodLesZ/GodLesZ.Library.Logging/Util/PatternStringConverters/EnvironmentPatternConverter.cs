// .NET Compact Framework 1.0 has no support for Environment.GetEnvironmentVariable()
#if !NETCF

using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Util;
using GodLesZ.Library.Logging.DateFormatter;
using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Util.PatternStringConverters {
	/// <summary>
	/// Write an environment variable to the output
	/// </summary>
	/// <remarks>
	/// <para>
	/// Write an environment variable to the output writer.
	/// The value of the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/> determines 
	/// the name of the variable to output.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class EnvironmentPatternConverter : PatternConverter {
		/// <summary>
		/// Write an environment variable to the output
		/// </summary>
		/// <param name="writer">the writer to write to</param>
		/// <param name="state">null, state is not set</param>
		/// <remarks>
		/// <para>
		/// Writes the environment variable to the output <paramref name="writer"/>.
		/// The name of the environment variable to output must be set
		/// using the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/>
		/// property.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, object state) {
			try {
				if (this.Option != null && this.Option.Length > 0) {
					// Lookup the environment variable
					string envValue = Environment.GetEnvironmentVariable(this.Option);

#if NET_2_0
					// If we didn't see it for the process, try a user level variable.
					if (envValue == null) {
						envValue = Environment.GetEnvironmentVariable(this.Option, EnvironmentVariableTarget.User);
					}

					// If we still didn't find it, try a system level one.
					if (envValue == null) {
						envValue = Environment.GetEnvironmentVariable(this.Option, EnvironmentVariableTarget.Machine);
					}
#endif

					if (envValue != null && envValue.Length > 0) {
						writer.Write(envValue);
					}
				}
			} catch (System.Security.SecurityException secEx) {
				// This security exception will occur if the caller does not have 
				// unrestricted environment permission. If this occurs the expansion 
				// will be skipped with the following warning message.
				LogLog.Debug(declaringType, "Security exception while trying to expand environment variables. Error Ignored. No Expansion.", secEx);
			} catch (Exception ex) {
				LogLog.Error(declaringType, "Error occurred while converting environment variable.", ex);
			}
		}

		#region Private Static Fields

		/// <summary>
		/// The fully qualified type of the EnvironmentPatternConverter class.
		/// </summary>
		/// <remarks>
		/// Used by the internal logger to record the Type of the
		/// log message.
		/// </remarks>
		private readonly static Type declaringType = typeof(EnvironmentPatternConverter);

		#endregion Private Static Fields
	}
}

#endif // !NETCF
