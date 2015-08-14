using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public class BOr : Operator {
		public override double Eval( double left, double right ) {
			int l = (int)left;
			int r = (int)right;

			return l | r;
		}

		public override string ToString( string left, string right ) {
			return string.Format( "((int)({0}) | (int)({1}))", left, right );
		}
	}
}
