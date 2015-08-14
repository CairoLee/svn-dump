using System.Runtime.InteropServices;

namespace GodLesZ.Library.Imaging.Mathematic {

	[StructLayout(LayoutKind.Sequential)]
	public struct Range {
		private double mMin;
		private double mMax;

		public double Min {
			get { return mMin; }
			set { mMin = value; }
		}

		public double Max {
			get { return mMax; }
			set { mMax = value; }
		}

		public Range(double min, double max) {
			mMin = min;
			mMax = max;
		}

	}

}

