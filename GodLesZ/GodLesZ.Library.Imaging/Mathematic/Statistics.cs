using System;

namespace GodLesZ.Library.Imaging.Mathematic {

	public class Statistics {
		public static double Entropy(int[] values) {
			int total = 0;
			int index = 0;
			int length = values.Length;
			while (index < length) {
				total += values[index];
				index++;
			}
			return Entropy(values, total);
		}

		public static double Entropy(int[] values, int total) {
			int length = values.Length;
			double num2 = 0.0;
			for (int i = 0; i < length; i++) {
				double a = ((double)values[i]) / ((double)total);
				if (a != 0.0) {
					num2 += -a * Math.Log(a, 2.0);
				}
			}
			return num2;
		}

		public static Range GetRange(int[] values, double percent) {
			int num = 0;
			int length = values.Length;
			for (int i = 0; i < length; i++) {
				num += values[i];
			}
			int num7 = (int)(num * (percent + ((1.0 - percent) / 2.0)));
			int index = 0;
			int num6 = num;
			while (index < length) {
				num6 -= values[index];
				if (num6 < num7) {
					break;
				}
				index++;
			}
			int num5 = length - 1;
			num6 = num;
			while (num5 >= 0) {
				num6 -= values[num5];
				if (num6 < num7) {
					break;
				}
				num5--;
			}
			return new Range(index, num5);
		}

		public static double Mean(int[] values) {
			int num2 = 0;
			int num3 = 0;
			int index = 0;
			int length = values.Length;
			while (index < length) {
				int num = values[index];
				num2 += index * num;
				num3 += num;
				index++;
			}
			return (((double)num2) / ((double)num3));
		}

		public static int Median(int[] values) {
			int num = 0;
			int length = values.Length;
			for (int i = 0; i < length; i++) {
				num += values[i];
			}
			int num4 = num / 2;
			int index = 0;
			int num6 = 0;
			while (index < length) {
				num6 += values[index];
				if (num6 >= num4) {
					return index;
				}
				index++;
			}
			return index;
		}

		public static double StdDev(int[] values) {
			double num = Mean(values);
			double num2 = 0.0;
			int num5 = 0;
			int index = 0;
			int length = values.Length;
			while (index < length) {
				int num4 = values[index];
				double num3 = index - num;
				num2 += (num3 * num3) * num4;
				num5 += num4;
				index++;
			}
			return Math.Sqrt(num2 / ((double)num5));
		}
	}
}

