using System;
using System.IO;
using System.Text;

using GodLesZ.Library.Logging.Util;
using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Layout {
	/// <summary>
	/// A Layout that renders only the Exception text from the logging event
	/// </summary>
	/// <remarks>
	/// <para>
	/// A Layout that renders only the Exception text from the logging event.
	/// </para>
	/// <para>
	/// This Layout should only be used with appenders that utilize multiple
	/// layouts (e.g. <see cref="GodLesZ.Library.Logging.Appender.AdoNetAppender"/>).
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public class ExceptionLayout : LayoutSkeleton {
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <remarks>
		/// <para>
		/// Constructs a ExceptionLayout
		/// </para>
		/// </remarks>
		public ExceptionLayout() {
			this.IgnoresException = false;
		}

		#endregion

		#region Implementation of IOptionHandler

		/// <summary>
		/// Activate component options
		/// </summary>
		/// <remarks>
		/// <para>
		/// Part of the <see cref="IOptionHandler"/> component activation
		/// framework.
		/// </para>
		/// <para>
		/// This method does nothing as options become effective immediately.
		/// </para>
		/// </remarks>
		override public void ActivateOptions() {
			// nothing to do.
		}

		#endregion

		#region Override implementation of LayoutSkeleton

		/// <summary>
		/// Gets the exception text from the logging event
		/// </summary>
		/// <param name="writer">The TextWriter to write the formatted event to</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// Write the exception string to the <see cref="TextWriter"/>.
		/// The exception string is retrieved from <see cref="LoggingEvent.GetExceptionString()"/>.
		/// </para>
		/// </remarks>
		override public void Format(TextWriter writer, LoggingEvent loggingEvent) {
			if (loggingEvent == null) {
				throw new ArgumentNullException("loggingEvent");
			}

			writer.Write(loggingEvent.GetExceptionString());
		}

		#endregion
	}
}
