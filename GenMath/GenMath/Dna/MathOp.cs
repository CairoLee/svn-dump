using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public class MathOp : MathLiteral {
		private static List<Operator> Operators = GetOperators();

		private static List<Operator> GetOperators() {
			List<Operator> ops = new List<Operator>();
			ops.Add( new Add() );
			ops.Add( new Sub() );
			ops.Add( new Mul() );
			ops.Add( new Div() );
			ops.Add( new BAnd() );
			ops.Add( new BOr() );
			//  ops.Add(new Xor());

			return ops;
		}
		public MathLiteral Left;
		public MathLiteral Right;
		public Operator Operator;

		public MathOp() {
			MutateOp();
			Left = new MathValue();
			Right = new MathValue();
		}

		public override double Evaluate( IEngine engine ) {
			double left = Left.Evaluate( engine );
			double right = Right.Evaluate( engine );
			return Operator.Eval( left, right );
		}

		public void Collapse() {
			if( Left is MathOp ) {
				( (MathOp)Left ).Collapse();
			}
			if( Right is MathOp ) {
				( (MathOp)Right ).Collapse();
			}
			if( Left.IsStatic() ) {
				MathValue val = new MathValue();
				val.Value = Left.Evaluate( null );
				Left = val;
			}
			if( Right.IsStatic() ) {
				MathValue val = new MathValue();
				val.Value = Right.Evaluate( null );
				Right = val;
			}
		}

		public override void Mutate() {
			//swap
			if( Tool.Mutate( 100 ) ) {
				MathLiteral tmp = Left;
				Left = Right;
				Right = tmp;
			}

			if( Tool.Mutate( 100 ) ) {
				this.Collapse();
			}

			if( Tool.Mutate( 15 ) ) {
				if( Left.IsStatic() ) {
					MathValue val = new MathValue();
					val.Value = Left.Evaluate( null );
					Left = val;
				}
			}

			if( Tool.Mutate( 15 ) ) {
				if( Right.IsStatic() ) {
					MathValue val = new MathValue();
					val.Value = Right.Evaluate( null );
					Right = val;
				}
			}

			//delete
			if( Tool.Mutate( 15 ) ) {
				if( Left is MathOp ) {
					MathLiteral grandChild = ( (MathOp)Left ).Left;
					Left = grandChild;
				}

			}

			//delete
			if( Tool.Mutate( 15 ) ) {
				if( Left is MathOp ) {
					MathLiteral grandChild = ( (MathOp)Left ).Right;
					Left = grandChild;
				}

			}

			//delete
			if( Tool.Mutate( 15 ) ) {
				if( Right is MathOp ) {
					MathLiteral grandChild = ( (MathOp)Right ).Right;
					Right = grandChild;
				}

			}

			//delete
			if( Tool.Mutate( 15 ) ) {
				if( Right is MathOp ) {
					MathLiteral grandChild = ( (MathOp)Right ).Left;
					Right = grandChild;
				}

			}

			//add
			if( Tool.Mutate( 100 ) ) {
				MathOp op = new MathOp();
				op.Left = Left;
				Left = op;
			}

			//add
			if( Tool.Mutate( 100 ) ) {
				MathOp op = new MathOp();
				op.Right = Right;
				Right = op;
			}

			//replace
			if( Tool.Mutate( 30 ) ) {
				MathLiteral newLeft = CreateRandomNode();
				Left = newLeft;
			}

			//replace
			if( Tool.Mutate( 30 ) ) {
				MathLiteral newRight = CreateRandomNode();
				Right = newRight;
			}

			Left.Mutate();
			Right.Mutate();
			if( Tool.Mutate( 50 ) ) {
				MutateOp();
			}
		}

		private void MutateOp() {
			int index = Tool.GetInt( Operators.Count );
			Operator = Operators[ index ];
		}

		public override string ToString() {
			string res = Operator.ToString( Left.ToString(), Right.ToString() );
			return res;
		}


		public override MathLiteral Clone() {
			MathOp clone = new MathOp();
			clone.Operator = Operator;
			clone.Left = Left.Clone();
			clone.Right = Right.Clone();

			return clone;
		}

		public override bool IsStatic() {
			return ( Left.IsStatic() && Right.IsStatic() );
		}

	}
}
