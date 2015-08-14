using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public class MathValue : MathLiteral {
		public double Value;

		public MathValue() {
			MutateValue();
		}

		public override void Mutate() {
			if( Tool.Mutate( 50 ) ) {
				MutateValue();
			}

			if( Tool.Mutate( 100 ) ) {
				int digits = Tool.GetInt( 5 );
				Value = Math.Round( Value, digits );
			}

			if( Tool.Mutate( 200 ) ) {
				Value = (int)Value;
			}
		}

		private void MutateValue() {
			double noise = ( Tool.GetDouble() - 0.5 ) * 10;

			Value += noise;
		}

		public override string ToString() {
			return Value.ToString( "G" );
		}

		public override double Evaluate( IEngine engine ) {
			return Value;
		}

		public override MathLiteral Clone() {
			MathValue clone = new MathValue();
			clone.Value = Value;
			return clone;
		}

		public override bool IsStatic() {
			return true;
		}
	}
}
