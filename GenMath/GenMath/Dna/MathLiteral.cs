using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public abstract class MathLiteral {
		public abstract void Mutate();

		public MathLiteral CreateRandomNode() {
			List<Type> types = new List<Type>();
			types.Add( typeof( MathOp ) );
			types.Add( typeof( MathValue ) );
			types.Add( typeof( MathPI ) );
			types.Add( typeof( MathVariable ) );

			int index = Tool.GetInt( types.Count );

			Type type = types[ index ];

			MathLiteral lit = (MathLiteral)Activator.CreateInstance( type );
			return lit;
		}

		public override string ToString() {
			return "FEL";
		}

		public abstract double Evaluate( IEngine engine );

		public abstract MathLiteral Clone();

		public abstract bool IsStatic();
	}
}
