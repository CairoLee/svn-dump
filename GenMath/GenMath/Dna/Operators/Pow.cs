using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	class Pow : Operator {
		public override double Eval( double left, double right ) {
			return Math.Pow( left, right );
		}

		public override string ToString( string left, string right ) {
			return string.Format( "(Math.Pow({0} , {1}))", left, right );
		}
	}
}
