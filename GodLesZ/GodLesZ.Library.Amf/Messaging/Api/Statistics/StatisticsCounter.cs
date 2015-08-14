using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Statistics {
	/// <summary>
	/// Counts numbers used by the statistics. Keeps track of current, maximum and total numbers.
	/// </summary>
	public class StatisticsCounter : IStatisticsCounter {
		/// <summary>
		/// Current number.
		/// </summary>
		private int _current;
		/// <summary>
		/// Total number.
		/// </summary>
		private int _total;
		/// <summary>
		/// Maximum number.
		/// </summary>
		private int _max;

		/// <summary>
		/// Increment statistics by one.
		/// </summary>
		public void Increment() {
			System.Threading.Interlocked.Increment(ref _total);
			System.Threading.Interlocked.Increment(ref _current);
			_max = Math.Max(_max, _current);
		}
		/// <summary>
		/// Decrement statistics by one.
		/// </summary>
		public void Decrement() {
			System.Threading.Interlocked.Decrement(ref _current);
		}
		/// <summary>
		/// Gets current number.
		/// </summary>
		public int Current {
			get { return _current; }
		}
		/// <summary>
		/// Gets total number.
		/// </summary>
		public int Total {
			get { return _total; }
		}
		/// <summary>
		/// Gets maximum number.
		/// </summary>
		public int Max {
			get { return _max; }
		}
	}
}
