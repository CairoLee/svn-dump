using System;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Represents logical AND operator.
	/// </summary>
	internal class OpAND : BinaryOperator {
		public OpAND() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			return Convert.ToBoolean(Left.EvaluateInternal(context, evalContext))
				&& Convert.ToBoolean(Right.EvaluateInternal(context, evalContext));
		}

	}
}
