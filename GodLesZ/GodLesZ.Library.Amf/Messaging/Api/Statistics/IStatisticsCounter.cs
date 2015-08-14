namespace GodLesZ.Library.Amf.Messaging.Api.Statistics {
	/// <summary>
	/// Counts numbers used by the statistics. Keeps track of current, maximum and total numbers.
	/// </summary>
	public interface IStatisticsCounter {
		/// <summary>
		/// Increment statistics by one.
		/// </summary>
		void Increment();
		/// <summary>
		/// Decrement statistics by one.
		/// </summary>
		void Decrement();
		/// <summary>
		/// Gets current number.
		/// </summary>
		int Current { get; }
		/// <summary>
		/// Gets total number.
		/// </summary>
		int Total { get; }
		/// <summary>
		/// Gets maximum number.
		/// </summary>
		int Max { get; }
	}
}
