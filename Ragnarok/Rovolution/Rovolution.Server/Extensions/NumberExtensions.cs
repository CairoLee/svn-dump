using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server {

	public static class NumberExtensions {

		public static int Swap(this int value, ref int swapValue) {
			int curValue = value;
			value = swapValue;
			swapValue = curValue;

			return value;
		}

		public static int Percent(this int value, int fromValue) {
			double perc = 100d * ((double)value / (double)fromValue);

			return (int)Math.Floor(perc);
		}

		public static int Percent(this uint value, uint fromValue) {
			double perc = 100d * ((double)value / (double)fromValue);

			return (int)Math.Floor(perc);
		}


		public static long Diff(this long tick, long tick2) {
			return (tick - tick2);
		}


		public static int CapValue(this int value, int min) {
			return value.CapValue(min, int.MaxValue);
		}
		public static int CapValue(this int value, int min, int max) {
			return Math.Max(Math.Min(value, max), min);
		}

		public static uint CapValue(this uint value, uint min) {
			return value.CapValue(min, uint.MaxValue);
		}
		public static uint CapValue(this uint value, uint min, uint max) {
			return Math.Max(Math.Min(value, max), min);
		}

		public static short CapValue(this short value, short min) {
			return value.CapValue(min, short.MaxValue);
		}
		public static short CapValue(this short value, short min, short max) {
			return Math.Max(Math.Min(value, max), min);
		}

		public static ushort CapValue(this ushort value, ushort min) {
			return value.CapValue(min, ushort.MaxValue);
		}
		public static ushort CapValue(this ushort value, ushort min, ushort max) {
			return Math.Max(Math.Min(value, max), min);
		}

	}

}
