using System;

namespace GodLesZ.Library.Logging.Core {
	/// <summary>
	/// Interface for objects that require fixing.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Interface that indicates that the object requires fixing before it
	/// can be taken outside the context of the appender's 
	/// <see cref="GodLesZ.Library.Logging.Appender.IAppender.DoAppend"/> method.
	/// </para>
	/// <para>
	/// When objects that implement this interface are stored 
	/// in the context properties maps <see cref="GodLesZ.Library.Logging.GlobalContext"/>
	/// <see cref="GodLesZ.Library.Logging.GlobalContext.Properties"/> and <see cref="GodLesZ.Library.Logging.ThreadContext"/>
	/// <see cref="GodLesZ.Library.Logging.ThreadContext.Properties"/> are fixed 
	/// (see <see cref="LoggingEvent.Fix"/>) the <see cref="GetFixedObject"/>
	/// method will be called.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	public interface IFixingRequired {
		/// <summary>
		/// Get a portable version of this object
		/// </summary>
		/// <returns>the portable instance of this object</returns>
		/// <remarks>
		/// <para>
		/// Get a portable instance object that represents the current
		/// state of this object. The portable object can be stored
		/// and logged from any thread with identical results.
		/// </para>
		/// </remarks>
		object GetFixedObject();
	}
}
