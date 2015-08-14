
using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	class MathVariable : MathLiteral {
		public string Name;

		public MathVariable() {
			MutateVariable();
		}

		private void MutateVariable() {
			string variables = "xy";
			int index = Tool.GetInt( variables.Length );
			Name = variables[ index ].ToString();
		}

		public override void Mutate() {
			if( Tool.Mutate( 20 ) ) {
				MutateVariable();
			}
		}

		public override string ToString() {
			return Name;
		}

		public override double Evaluate( IEngine engine ) {
			return engine.GetVariable( Name );
		}

		public override MathLiteral Clone() {
			MathVariable clone = new MathVariable();
			clone.Name = Name;
			return clone;
		}

		public override bool IsStatic() {
			return false;
		}
	}
}
