using System;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.Imaging.Mathematic {

	[StructLayout(LayoutKind.Sequential)]
	public struct Complex {
		public float Re;
		public float Im;
		public static Complex Zero {
			get {
				return new Complex(0f, 0f);
			}
		}
		public float Magnitude {
			get {
				return (float)Math.Sqrt((double)((this.Re * this.Re) + (this.Im * this.Im)));
			}
		}
		public float Phase {
			get {
				return (float)Math.Atan((double)(this.Im / this.Re));
			}
		}
		public float SquaredMagnitude {
			get {
				return ((this.Re * this.Re) + (this.Im * this.Im));
			}
		}
		public Complex(float re, float im) {
			this.Re = re;
			this.Im = im;
		}

		public Complex(Complex c) {
			this.Re = c.Re;
			this.Im = c.Im;
		}

		public override string ToString() {
			return string.Format("{0}{1}{2}i", this.Re, (this.Im < 0f) ? '-' : '+', Math.Abs(this.Im));
		}

		public static Complex operator +(Complex a, Complex b) {
			return new Complex(a.Re + b.Re, a.Im + b.Im);
		}

		public static Complex operator -(Complex a, Complex b) {
			return new Complex(a.Re - b.Re, a.Im - b.Im);
		}

		public static Complex operator *(Complex a, Complex b) {
			return new Complex((a.Re * b.Re) - (a.Im * b.Im), (a.Re * b.Im) + (a.Im * b.Re));
		}

		public static Complex operator /(Complex a, Complex b) {
			float num = (b.Re * b.Re) + (b.Im * b.Im);
			if (num == 0f) {
				throw new DivideByZeroException();
			}
			return new Complex(((a.Re * b.Re) + (a.Im * b.Im)) / num, ((a.Im * b.Re) - (a.Re * b.Im)) / num);
		}
	}
}

