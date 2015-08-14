using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public class Organism {
		private MathFunction root;
		private Problem problem;
		public double Error = double.MaxValue;

		public Organism( Problem problem ) {
			this.problem = problem;
			root = new MathFunction();
		}

		public void Collapse() {
			root.Collapse();
		}

		public override string ToString() {
			//MathFunction clone = root.Clone() as MathFunction;
			//clone.Collapse();
			//return clone.ToString ();
			return root.ToString();
		}

		public double Evaluate( double x, double y ) {
			Engine engine = new Engine();
			engine.SetVariable( "x", x );
			engine.SetVariable( "y", y );
			double res = root.Evaluate( engine );
			return res;
		}

		public void Tick() {
			Engine engine = new Engine();
			MathFunction clone = null;

			clone = (MathFunction)root.Clone();
			clone.Mutate();

			if( clone.ToString() == root.ToString() )
				return;

			double totNewError = 0;
			double totOldError = 0;
			foreach( Case currentCase in problem.Cases ) {
				engine.SetVariable( "x", currentCase.X );
				engine.SetVariable( "y", currentCase.Y );
				double newResult = clone.Evaluate( engine );
				double oldResult = root.Evaluate( engine );

				double newError = Math.Abs( currentCase.Result - newResult );
				double oldError = Math.Abs( currentCase.Result - oldResult );

				totNewError += newError;
				totOldError += oldError;

			}


			//its a good match
			if( totNewError < totOldError ||
				( ( clone.ToString().Length < root.ToString().Length ) && totNewError < totOldError + double.Epsilon ) ) {
				//Console.WriteLine(clone.ToString ());
				//  Console.WriteLine(totNewError.ToString("0.0000000000") + "   " + clone.ToString());
				root = clone;
				this.Error = totNewError;
			}
		}

		public Organism Clone() {
			Organism clone = new Organism( problem );
			clone.root = (MathFunction)this.root.Clone();
			return clone;
		}

		public Organism MakeCrossOver( Organism father ) {
			Organism child = this.Clone();
			MathOp fatherDna = (MathOp)father.GetRandomNode().Clone();
			MathOp motherDna = child.GetRandomNode();
			motherDna.Left = fatherDna.Left;
			motherDna.Right = fatherDna.Right;

			return child;
		}

		private MathOp GetRandomNode() {
			return root.GetRandomNode();
		}


	}
}
