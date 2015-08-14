using System;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Represents arithmetic subtraction operator.
	/// </summary>
	internal class OpSUBTRACT : BinaryOperator {
		public OpSUBTRACT() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object left = Left.EvaluateInternal(context, evalContext);
			object right = Right.EvaluateInternal(context, evalContext);

			if (NumberUtils.IsNumber(left) && NumberUtils.IsNumber(right)) {
				return NumberUtils.Subtract(left, right);
			} else if (left is DateTime && (right is TimeSpan || right is string || NumberUtils.IsNumber(right))) {
				if (NumberUtils.IsNumber(right)) {
					right = TimeSpan.FromDays(GodLesZ.Library.Amf.Util.Convert.ToDouble(right));
				} else if (right is string) {
					right = TimeSpan.Parse((string)right);
				}
				return (DateTime)left - (TimeSpan)right;
			} else if (left is DateTime && right is DateTime) {
				return (DateTime)left - (DateTime)right;
			} else {
				throw new ArgumentException("Cannot subtract instances of '"
					+ left.GetType().FullName
					+ "' and '"
					+ right.GetType().FullName
					+ "'.");
			}
		}
	}
}
