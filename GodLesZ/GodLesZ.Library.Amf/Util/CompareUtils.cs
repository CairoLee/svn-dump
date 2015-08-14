using System;

namespace GodLesZ.Library.Amf.Util {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	abstract class CompareUtils {
		protected CompareUtils() { }

		/// <summary>Compares two objects.</summary>
		/// <param name="first">First object.</param>
		/// <param name="second">Second object.</param>
		/// <returns>
		/// 0, if objects are equal; 
		/// less than zero, if the first object is smaller than the second one;
		/// greater than zero, if the first object is greater than the second one.</returns>
		public static int Compare(object first, object second) {
			// anything is greater than null, unless both operands are null
			if (first == null) {
				return (second == null ? 0 : -1);
			} else if (second == null) {
				return 1;
			}

			if (!first.GetType().Equals(second.GetType())) {
				if (!CoerceTypes(ref first, ref second)) {
					throw new ArgumentException("Cannot compare instances of ["
						+ first.GetType().FullName
						+ "] and ["
						+ second.GetType().FullName
						+ "] because they cannot be coerced to the same type.");
				}
			}

			if (first is IComparable) {
				return ((IComparable)first).CompareTo(second);
			} else {
				throw new ArgumentException("Cannot compare instances of the type ["
					+ first.GetType().FullName
					+ "] because it doesn't implement IComparable");
			}
		}

		private static bool CoerceTypes(ref object left, ref object right) {
			if (NumberUtils.IsNumber(left) && NumberUtils.IsNumber(right)) {
				NumberUtils.CoerceTypes(ref right, ref left);
				return true;
			}
			return false;
		}
	}
}
