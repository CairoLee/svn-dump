using System;

namespace GodLesZ.Library.Imaging.Mathematic {

	public class HistogramD {
		private double max;
		private double mean;
		private double median;
		private double min;
		private RangeD range;
		private double stdDev;
		private int total;
		private int[] values;

		public HistogramD(int[] values, RangeD range) {
			int num;
			int num2;
			this.values = values;
			this.range = range;
			int length = values.Length;
			int num4 = length - 1;
			double num5 = range.Max - range.Min;
			this.max = 0.0;
			this.min = length;
			for (num2 = 0; num2 < length; num2++) {
				num = values[num2];
				if (num != 0) {
					if (num2 > this.max) {
						this.max = num2;
					}
					if (num2 < this.min) {
						this.min = num2;
					}
				}
				this.total += num;
				this.mean += (((((double)num2) / ((double)num4)) * num5) + range.Min) * num;
			}
			this.mean /= (double)this.total;
			this.min = ((this.min / ((double)num4)) * num5) + range.Min;
			this.max = ((this.max / ((double)num4)) * num5) + range.Min;
			for (num2 = 0; num2 < length; num2++) {
				num = values[num2];
				this.stdDev += Math.Pow((((((double)num2) / ((double)num4)) * num5) + range.Min) - this.mean, 2.0) * num;
			}
			this.stdDev = Math.Sqrt(this.stdDev / ((double)this.total));
			int num7 = this.total / 2;
			int index = 0;
			num = 0;
			while (this.median < length) {
				num += values[index];
				if (num >= num7) {
					break;
				}
				index++;
			}
			this.median = ((((double)index) / ((double)num4)) * num5) + range.Min;
		}

		public RangeD GetRange(double percent) {
			int num4 = (int)(this.total * (percent + ((1.0 - percent) / 2.0)));
			int length = this.values.Length;
			int num6 = length - 1;
			double num7 = this.range.Max - this.range.Min;
			int index = 0;
			int total = this.total;
			while (index < length) {
				total -= this.values[index];
				if (total < num4) {
					break;
				}
				index++;
			}
			int num2 = length - 1;
			total = this.total;
			while (num2 >= 0) {
				total -= this.values[num2];
				if (total < num4) {
					break;
				}
				num2--;
			}
			return new RangeD(((((double)index) / ((double)num6)) * num7) + this.range.Min, ((((double)num2) / ((double)num6)) * num7) + this.range.Min);
		}

		public double Max {
			get {
				return this.max;
			}
		}

		public double Mean {
			get {
				return this.mean;
			}
		}

		public double Median {
			get {
				return this.median;
			}
		}

		public double Min {
			get {
				return this.min;
			}
		}

		public RangeD Range {
			get {
				return this.range;
			}
		}

		public double StdDev {
			get {
				return this.stdDev;
			}
		}

		public int[] Values {
			get {
				return this.values;
			}
		}
	}
}

