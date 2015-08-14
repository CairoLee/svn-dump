
namespace GodLesZ.Library.Amf.Messaging.Api.Statistics {
	/// <summary>
	/// Base interface for all statistics informations.
	/// </summary>
	public interface IStatisticsBase {
		/// <summary>
		/// Gets the timestamp the object was created.
		/// </summary>
		/// <value>The timestamp in milliseconds since midnight, January 1, 1970 UTC.</value>
		long CreationTime { get; }
	}
}
