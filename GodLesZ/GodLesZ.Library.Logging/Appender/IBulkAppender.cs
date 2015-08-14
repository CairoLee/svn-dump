using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Appender {
	/// <summary>
	/// Interface for appenders that support bulk logging.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This interface extends the <see cref="IAppender"/> interface to
	/// support bulk logging of <see cref="LoggingEvent"/> objects. Appenders
	/// should only implement this interface if they can bulk log efficiently.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	public interface IBulkAppender : IAppender {
		/// <summary>
		/// Log the array of logging events in Appender specific way.
		/// </summary>
		/// <param name="loggingEvents">The events to log</param>
		/// <remarks>
		/// <para>
		/// This method is called to log an array of events into this appender.
		/// </para>
		/// </remarks>
		void DoAppend(LoggingEvent[] loggingEvents);
	}
}
