using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public class Case {
		public double X;
		public double Y;
		public double Result;
		public double CurrentError = int.MaxValue;

		public Case( double x, double y, double result ) {
			this.X = x;
			this.Y = y;
			this.Result = result;
		}
	}
}
