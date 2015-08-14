using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public class Sub : Operator {
		public override double Eval( double left, double right ) {
			return left - right;
		}

		public override string ToString( string left, string right ) {
			return string.Format( "({0} - {1})", left, right );
		}
	}
}
