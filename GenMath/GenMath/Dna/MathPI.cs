using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public class MathPI : MathLiteral {
		public double Value;
		public MathPI() {
			Value = Math.PI;
		}

		public override void Mutate() {

		}

		public override string ToString() {
			return "PI";
		}

		public override double Evaluate( IEngine engine ) {
			return Value;
		}

		public override MathLiteral Clone() {
			MathPI clone = new MathPI();
			clone.Value = Value;
			return clone;
		}

		public override bool IsStatic() {
			return true;
		}
	}
}
