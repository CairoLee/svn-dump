using System;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class OpNOT : UnaryOperator {
		public OpNOT() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			return !Convert.ToBoolean(Operand.EvaluateInternal(context, evalContext));
		}
	}
}
