using System;

namespace GodLesZ.Library.Imaging.Mathematic {

	public class FourierTransform {
		private static Complex[,][] complexRotation = new Complex[14, 2][];
		private const int maxBits = 14;
		private const int maxLength = 0x4000;
		private const int minBits = 1;
		private const int minLength = 2;
		private static int[][] reversedBits = new int[14][];

		public static void DFT(Complex[] data, FourierDirection direction) {
			int length = data.Length;
			Complex[] complexArray = new Complex[length];
			for (int i = 0; i < length; i++) {
				complexArray[i] = Complex.Zero;
				double num2 = (((((double)-((int)direction)) * 2.0) * 3.1415926535897931) * i) / ((double)length);
				for (int j = 0; j < length; j++) {
					double num3 = Math.Cos(j * num2);
					double num4 = Math.Sin(j * num2);
					complexArray[i].Re += (float)((data[j].Re * num3) - (data[j].Im * num4));
					complexArray[i].Im += (float)((data[j].Re * num4) + (data[j].Im * num3));
				}
			}
			if (direction == FourierDirection.Forward) {
				for (int k = 0; k < length; k++) {
					data[k].Re = complexArray[k].Re / ((float)length);
					data[k].Im = complexArray[k].Im / ((float)length);
				}
			} else {
				for (int m = 0; m < length; m++) {
					data[m].Re = complexArray[m].Re;
					data[m].Im = complexArray[m].Im;
				}
			}
		}

		public static void DFT2(Complex[,] data, FourierDirection direction) {
			double num3;
			double num4;
			double num5;
			int length = data.GetLength(0);
			int num2 = data.GetLength(1);
			Complex[] complexArray = new Complex[Math.Max(length, num2)];
			for (int i = 0; i < length; i++) {
				for (int k = 0; k < num2; k++) {
					complexArray[k] = Complex.Zero;
					num3 = (((((double)-((int)direction)) * 2.0) * 3.1415926535897931) * k) / ((double)num2);
					for (int m = 0; m < num2; m++) {
						num4 = Math.Cos(m * num3);
						num5 = Math.Sin(m * num3);
						complexArray[k].Re += (float)((data[i, m].Re * num4) - (data[i, m].Im * num5));
						complexArray[k].Im += (float)((data[i, m].Re * num5) + (data[i, m].Im * num4));
					}
				}
				if (direction == FourierDirection.Forward) {
					for (int n = 0; n < num2; n++) {
						data[i, n].Re = complexArray[n].Re / ((float)num2);
						data[i, n].Im = complexArray[n].Im / ((float)num2);
					}
				} else {
					for (int num10 = 0; num10 < num2; num10++) {
						data[i, num10].Re = complexArray[num10].Re;
						data[i, num10].Im = complexArray[num10].Im;
					}
				}
			}
			for (int j = 0; j < num2; j++) {
				for (int num12 = 0; num12 < length; num12++) {
					complexArray[num12] = Complex.Zero;
					num3 = (((((double)-((int)direction)) * 2.0) * 3.1415926535897931) * num12) / ((double)length);
					for (int num13 = 0; num13 < length; num13++) {
						num4 = Math.Cos(num13 * num3);
						num5 = Math.Sin(num13 * num3);
						complexArray[num12].Re += (float)((data[num13, j].Re * num4) - (data[num13, j].Im * num5));
						complexArray[num12].Im += (float)((data[num13, j].Re * num5) + (data[num13, j].Im * num4));
					}
				}
				if (direction == FourierDirection.Forward) {
					for (int num14 = 0; num14 < length; num14++) {
						data[num14, j].Re = complexArray[num14].Re / ((float)length);
						data[num14, j].Im = complexArray[num14].Im / ((float)length);
					}
				} else {
					for (int num15 = 0; num15 < length; num15++) {
						data[num15, j].Re = complexArray[num15].Re;
						data[num15, j].Im = complexArray[num15].Im;
					}
				}
			}
		}

		public static void FFT(Complex[] data, FourierDirection direction) {
			int length = data.Length;
			int num2 = Tools.Log2(length);
			ReorderData(data);
			int num3 = 1;
			for (int i = 1; i <= num2; i++) {
				Complex[] complexRotation = GetComplexRotation(i, direction);
				int num4 = num3;
				num3 = num3 << 1;
				for (int j = 0; j < num4; j++) {
					Complex complex = complexRotation[j];
					for (int k = j; k < length; k += num3) {
						int index = k + num4;
						Complex complex2 = data[k];
						Complex complex3 = data[index];
						float num9 = (complex3.Re * complex.Re) - (complex3.Im * complex.Im);
						float num10 = (complex3.Re * complex.Im) + (complex3.Im * complex.Re);
						data[k].Re += num9;
						data[k].Im += num10;
						data[index].Re = complex2.Re - num9;
						data[index].Im = complex2.Im - num10;
					}
				}
			}
			if (direction == FourierDirection.Forward) {
				for (int m = 0; m < length; m++) {
					data[m].Re /= (float)length;
					data[m].Im /= (float)length;
				}
			}
		}

		public static void FFT2(Complex[,] data, FourierDirection direction) {
			int length = data.GetLength(0);
			int x = data.GetLength(1);
			if (((!Tools.IsPowerOf2(length) || !Tools.IsPowerOf2(x)) || ((length < 2) || (length > 0x4000))) || ((x < 2) || (x > 0x4000))) {
				throw new ArgumentException();
			}
			Complex[] complexArray = new Complex[x];
			for (int i = 0; i < length; i++) {
				for (int k = 0; k < x; k++) {
					complexArray[k] = data[i, k];
				}
				FFT(complexArray, direction);
				for (int m = 0; m < x; m++) {
					data[i, m] = complexArray[m];
				}
			}
			Complex[] complexArray2 = new Complex[length];
			for (int j = 0; j < x; j++) {
				for (int n = 0; n < length; n++) {
					complexArray2[n] = data[n, j];
				}
				FFT(complexArray2, direction);
				for (int num8 = 0; num8 < length; num8++) {
					data[num8, j] = complexArray2[num8];
				}
			}
		}

		private static Complex[] GetComplexRotation(int numberOfBits, FourierDirection direction) {
			int num = (direction == FourierDirection.Forward) ? 0 : 1;
			if (complexRotation[numberOfBits - 1, num] == null) {
				int num2 = ((int)1) << (numberOfBits - 1);
				float re = 1f;
				float im = 0f;
				double d = (3.1415926535897931 / ((double)num2)) * ((double)direction);
				float num6 = (float)Math.Cos(d);
				float num7 = (float)Math.Sin(d);
				Complex[] complexArray = new Complex[num2];
				for (int i = 0; i < num2; i++) {
					complexArray[i] = new Complex(re, im);
					float num8 = (re * num7) + (im * num6);
					re = (re * num6) - (im * num7);
					im = num8;
				}
				complexRotation[numberOfBits - 1, num] = complexArray;
			}
			return complexRotation[numberOfBits - 1, num];
		}

		private static int[] GetReversedBits(int numberOfBits) {
			if ((numberOfBits < 1) || (numberOfBits > 14)) {
				throw new ArgumentOutOfRangeException();
			}
			if (reversedBits[numberOfBits - 1] == null) {
				int num = Tools.Pow2(numberOfBits);
				int[] numArray = new int[num];
				for (int i = 0; i < num; i++) {
					int num3 = i;
					int num4 = 0;
					for (int j = 0; j < numberOfBits; j++) {
						num4 = (num4 << 1) | (num3 & 1);
						num3 = num3 >> 1;
					}
					numArray[i] = num4;
				}
				reversedBits[numberOfBits - 1] = numArray;
			}
			return reversedBits[numberOfBits - 1];
		}

		private static void ReorderData(Complex[] data) {
			int length = data.Length;
			if (((length < 2) || (length > 0x4000)) || !Tools.IsPowerOf2(length)) {
				throw new ArgumentException();
			}
			int[] reversedBits = GetReversedBits(Tools.Log2(length));
			for (int i = 0; i < length; i++) {
				int index = reversedBits[i];
				if (index > i) {
					Complex complex = data[i];
					data[i] = data[index];
					data[index] = complex;
				}
			}
		}
	}
}

