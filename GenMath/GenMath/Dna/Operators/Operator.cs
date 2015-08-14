using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public abstract class Operator {
		public abstract double Eval( double left, double right );
		public abstract string ToString( string left, string right );
	}
}
