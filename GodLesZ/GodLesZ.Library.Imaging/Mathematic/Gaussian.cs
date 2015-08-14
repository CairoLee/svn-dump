using System;

namespace GodLesZ.Library.Imaging.Mathematic {

	public class Gaussian {
		private double sigma;
		private double sqrSigma;

		public Gaussian() {
			this.sigma = 1.0;
			this.sqrSigma = 1.0;
		}

		public Gaussian(double sigma) {
			this.sigma = 1.0;
			this.sqrSigma = 1.0;
			this.Sigma = sigma;
		}

		public double Function(double x) {
			return (Math.Exp((x * x) / (-2.0 * this.sqrSigma)) / (Math.Sqrt(6.2831853071795862) * this.sigma));
		}

		public double Function2D(double x, double y) {
			return (Math.Exp(((x * x) + (y * y)) / (-2.0 * this.sqrSigma)) / (6.2831853071795862 * this.sqrSigma));
		}

		public double[] Kernel(int size) {
			if ((((size % 2) == 0) || (size < 3)) || (size > 0x65)) {
				throw new ArgumentException();
			}
			int num = size / 2;
			double[] numArray = new double[size];
			int num2 = -num;
			for (int i = 0; i < size; i++) {
				numArray[i] = this.Function((double)num2);
				num2++;
			}
			return numArray;
		}

		public double[,] Kernel2D(int size) {
			if ((((size % 2) == 0) || (size < 3)) || (size > 0x65)) {
				throw new ArgumentException();
			}
			int num = size / 2;
			double[,] numArray = new double[size, size];
			int num2 = -num;
			for (int i = 0; i < size; i++) {
				int num4 = -num;
				for (int j = 0; j < size; j++) {
					numArray[i, j] = this.Function2D((double)num4, (double)num2);
					num4++;
				}
				num2++;
			}
			return numArray;
		}

		public int[] KernelDiscret(int size) {
			double[] numArray = this.Kernel(size);
			double num = numArray[0];
			double num2 = num;
			double maxValue = double.MaxValue;
			for (int i = 1; i <= 5; i++) {
				double num5 = 0.0;
				double num6 = ((double)i) / num;
				for (int k = 0; k < size; k++) {
					double num8 = numArray[k] * num6;
					double num9 = num8 - ((int)num8);
					num5 += num9 * num9;
				}
				if (num5 < maxValue) {
					maxValue = num5;
					num2 = num6;
				}
			}
			int[] numArray2 = new int[size];
			for (int j = 0; j < size; j++) {
				numArray2[j] = (int)(numArray[j] * num2);
			}
			return numArray2;
		}

		public int[,] KernelDiscret2D(int size) {
			double[,] numArray = this.Kernel2D(size);
			double num = numArray[0, 0];
			double num2 = numArray[size >> 1, size >> 1];
			double num3 = num;
			double maxValue = double.MaxValue;
			for (int i = 1; i <= 5; i++) {
				double num6 = 0.0;
				double num7 = ((double)i) / num;
				if ((num2 * num7) > 65535.0) {
					num7 = 65535.0 / num2;
				}
				for (int k = 0; k < size; k++) {
					for (int m = 0; m < size; m++) {
						double num10 = numArray[k, m] * num7;
						double num11 = num10 - ((int)num10);
						num6 += num11 * num11;
					}
				}
				if (num6 < maxValue) {
					maxValue = num6;
					num3 = num7;
				}
			}
			int[,] numArray2 = new int[size, size];
			for (int j = 0; j < size; j++) {
				for (int n = 0; n < size; n++) {
					numArray2[j, n] = (int)(numArray[j, n] * num3);
				}
			}
			return numArray2;
		}

		public double Sigma {
			get {
				return this.sigma;
			}
			set {
				this.sigma = Math.Max(1E-08, value);
				this.sqrSigma = this.sigma * this.sigma;
			}
		}
	}
}

