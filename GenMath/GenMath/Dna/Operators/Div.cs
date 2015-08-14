using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	class Div : Operator {
		public override double Eval( double left, double right ) {
			if( right == 0 ) {
				return 0; //cheat
			} else {
				return left / right;
			}
		}

		public override string ToString( string left, string right ) {
			return string.Format( "({0} / {1})", left, right );
		}

	}
}
