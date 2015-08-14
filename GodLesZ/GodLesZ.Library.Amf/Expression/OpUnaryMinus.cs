using System;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class OpUnaryMinus : UnaryOperator {
		public OpUnaryMinus() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object n = Operand.EvaluateInternal(context, evalContext);
			if (!NumberUtils.IsNumber(n))
				throw new ArgumentException("Specified operand is not a number. Only numbers support unary minus operator.");
			return NumberUtils.Negate(n);
		}
	}
}
