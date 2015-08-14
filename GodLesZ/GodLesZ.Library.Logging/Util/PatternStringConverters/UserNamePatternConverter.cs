using System;
using System.Text;
using System.IO;

using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging.Util.PatternStringConverters {
	/// <summary>
	/// Write the current threads username to the output
	/// </summary>
	/// <remarks>
	/// <para>
	/// Write the current threads username to the output writer
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class UserNamePatternConverter : PatternConverter {
		/// <summary>
		/// Write the current threads username to the output
		/// </summary>
		/// <param name="writer">the writer to write to</param>
		/// <param name="state">null, state is not set</param>
		/// <remarks>
		/// <para>
		/// Write the current threads username to the output <paramref name="writer"/>.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, object state) {
#if (NETCF || SSCLI)
			// On compact framework there's no notion of current Windows user
			writer.Write( SystemInfo.NotAvailableText );
#else
			try {
				System.Security.Principal.WindowsIdentity windowsIdentity = null;
				windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
				if (windowsIdentity != null && windowsIdentity.Name != null) {
					writer.Write(windowsIdentity.Name);
				}
			} catch (System.Security.SecurityException) {
				// This security exception will occur if the caller does not have 
				// some undefined set of SecurityPermission flags.
				LogLog.Debug(declaringType, "Security exception while trying to get current windows identity. Error Ignored.");

				writer.Write(SystemInfo.NotAvailableText);
			}
#endif
		}

		#region Private Static Fields

		/// <summary>
		/// The fully qualified type of the UserNamePatternConverter class.
		/// </summary>
		/// <remarks>
		/// Used by the internal logger to record the Type of the
		/// log message.
		/// </remarks>
		private readonly static Type declaringType = typeof(UserNamePatternConverter);

		#endregion Private Static Fields
	}
}
