using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	class MathFunction : MathLiteral {
		public MathOp BaseOp = new MathOp();

		public override void Mutate() {
			//add
			if( Tool.Mutate( 100 ) ) {
				MathOp op = new MathOp();
				op.Left = BaseOp;
				BaseOp = op;
			}

			BaseOp.Mutate();
		}

		public override string ToString() {
			return BaseOp.ToString();
		}

		public override double Evaluate( IEngine engine ) {
			return BaseOp.Evaluate( engine );
		}

		public override MathLiteral Clone() {
			MathFunction clone = new MathFunction();
			clone.BaseOp = (MathOp)BaseOp.Clone();
			return clone;
		}

		public override bool IsStatic() {
			return BaseOp.IsStatic();
		}

		public MathOp GetRandomNode() {
			List<MathOp> nodes = new List<MathOp>();
			TraverseNode( BaseOp, nodes );

			int index = Tool.GetInt( nodes.Count );
			return nodes[ index ];
		}

		private void TraverseNode( MathOp op, List<MathOp> nodes ) {
			nodes.Add( op );
			if( op.Left is MathOp ) {
				TraverseNode( op.Left as MathOp, nodes );
			}

			if( op.Right is MathOp ) {
				TraverseNode( op.Right as MathOp, nodes );
			}
		}

		public void Collapse() {
			BaseOp.Collapse();
		}
	}
}
