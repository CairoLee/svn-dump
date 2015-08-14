using System.Threading;

namespace GodLesZ.Library.Amf.Util {
	/// <summary>
	/// Threading utility class.
	/// </summary>
	public abstract class ThreadingUtils {
		private ThreadingUtils() { }

		/// <summary>
		/// Compares a value in a location, and swaps it with a new value if the comparand is equal to original value.
		/// </summary>
		/// <typeparam name="T">The type of the values.</typeparam>
		/// <param name="location">The location of the value to check.</param>
		/// <param name="comparand">The value to compare against the original location.</param>
		/// <param name="newValue">The value to replace the original value with.</param>
		/// <returns>true if the swap succeeded, false if another thread pre-empted the operation.</returns>
		public static bool CompareAndSwap<T>(ref T location, T comparand, T newValue) where T : class {
			return ReferenceEquals(comparand, Interlocked.CompareExchange(ref location, newValue, comparand));
		}

	}
}
