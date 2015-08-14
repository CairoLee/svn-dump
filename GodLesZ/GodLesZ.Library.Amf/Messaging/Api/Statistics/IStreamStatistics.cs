
namespace GodLesZ.Library.Amf.Messaging.Api.Statistics {
	/// <summary>
	/// Interface for all stream statistics.
	/// </summary>
	public interface IStreamStatistics : IStatisticsBase {
		/// <summary>
		/// Gets the currently active timestamp inside the stream.
		/// </summary>
		int CurrentTimestamp { get; }
	}
}
