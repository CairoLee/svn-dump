using System;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Represents logical equality operator.
	/// </summary>
	class OpEqual : BinaryOperator {
		public OpEqual() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object left = Left.EvaluateInternal(context, evalContext);
			object right = Right.EvaluateInternal(context, evalContext);

			if (left == null) {
				return (right == null);
			} else if (right == null) {
				return false;
			} else if (left.GetType() == right.GetType()) {
				return left.Equals(right);
			} else if (left.GetType().IsEnum && right is string) {
				return left.Equals(Enum.Parse(left.GetType(), (string)right));
			} else if (right.GetType().IsEnum && left is string) {
				return right.Equals(Enum.Parse(right.GetType(), (string)left));
			} else {
				return CompareUtils.Compare(left, right) == 0;
			}
		}

	}
}
