
namespace GodLesZ.Library.Imaging.Mathematic {

	public class Histogram {
		private int max;
		private double mean;
		private int median;
		private int min;
		private double stdDev;
		private int[] values;

		public Histogram(int[] values) {
			this.values = values;
			int length = values.Length;
			this.max = 0;
			this.min = length;
			for (int i = 0; i < length; i++) {
				if (values[i] != 0) {
					if (i > this.max) {
						this.max = i;
					}
					if (i < this.min) {
						this.min = i;
					}
				}
			}
			this.mean = Statistics.Mean(values);
			this.stdDev = Statistics.StdDev(values);
			this.median = Statistics.Median(values);
		}

		public Range GetRange(double percent) {
			return Statistics.GetRange(this.values, percent);
		}

		public int Max {
			get {
				return this.max;
			}
		}

		public double Mean {
			get {
				return this.mean;
			}
		}

		public int Median {
			get {
				return this.median;
			}
		}

		public int Min {
			get {
				return this.min;
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

