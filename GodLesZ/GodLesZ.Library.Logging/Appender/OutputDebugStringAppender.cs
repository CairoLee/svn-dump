// MONO 1.0 has no support for Win32 OutputDebugString API
#if !MONO
// SSCLI 1.0 has no support for Win32 OutputDebugString API
#if !SSCLI
// We don't want framework or platform specific code in the CLI version of GodLesZ.Library.Logging
#if !CLI_1_0

using System.Runtime.InteropServices;

using GodLesZ.Library.Logging.Layout;
using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Appender {
	/// <summary>
	/// Appends log events to the OutputDebugString system.
	/// </summary>
	/// <remarks>
	/// <para>
	/// OutputDebugStringAppender appends log events to the
	/// OutputDebugString system.
	/// </para>
	/// <para>
	/// The string is passed to the native <c>OutputDebugString</c> 
	/// function.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public class OutputDebugStringAppender : AppenderSkeleton {
		#region Public Instance Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="OutputDebugStringAppender" /> class.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Default constructor.
		/// </para>
		/// </remarks>
		public OutputDebugStringAppender() {
		}

		#endregion // Public Instance Constructors

		#region Override implementation of AppenderSkeleton

		/// <summary>
		/// Write the logging event to the output debug string API
		/// </summary>
		/// <param name="loggingEvent">the event to log</param>
		/// <remarks>
		/// <para>
		/// Write the logging event to the output debug string API
		/// </para>
		/// </remarks>
#if NET_4_0
		[System.Security.SecuritySafeCritical]
#elif !NETCF
		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, UnmanagedCode = true)]
#endif
		override protected void Append(LoggingEvent loggingEvent) {
			OutputDebugString(RenderLoggingEvent(loggingEvent));
		}

		/// <summary>
		/// This appender requires a <see cref="Layout"/> to be set.
		/// </summary>
		/// <value><c>true</c></value>
		/// <remarks>
		/// <para>
		/// This appender requires a <see cref="Layout"/> to be set.
		/// </para>
		/// </remarks>
		override protected bool RequiresLayout {
			get { return true; }
		}

		#endregion // Override implementation of AppenderSkeleton

		#region Protected Static Methods

		/// <summary>
		/// Stub for OutputDebugString native method
		/// </summary>
		/// <param name="message">the string to output</param>
		/// <remarks>
		/// <para>
		/// Stub for OutputDebugString native method
		/// </para>
		/// </remarks>
#if NETCF
		[DllImport("CoreDll.dll")]
#else
		[DllImport("Kernel32.dll")]
#endif
		protected static extern void OutputDebugString(string message);

		#endregion // Protected Static Methods
	}
}

#endif // !CLI_1_0
#endif // !SSCLI
#endif // !MONO
