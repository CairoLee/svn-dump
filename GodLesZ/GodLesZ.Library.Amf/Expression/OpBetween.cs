using System;
using System.Collections;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class OpBetween : BinaryOperator {
		public OpBetween() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object value = Left.EvaluateInternal(context, evalContext);
			IList range = Right.EvaluateInternal(context, evalContext) as IList;

			if (range == null || range.Count != 2) {
				throw new ArgumentException("Right operand for the 'between' operator has to be a two-element list.");
			}

			object low = range[0];
			object high = range[1];

			return (CompareUtils.Compare(value, low) >= 0 && CompareUtils.Compare(value, high) <= 0);
		}
	}
}