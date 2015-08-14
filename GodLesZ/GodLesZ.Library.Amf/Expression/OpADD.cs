using System;

using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Represents arithmetic addition operator.
	/// </summary>
	internal class OpADD : BinaryOperator {
		public OpADD() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object left = Left.EvaluateInternal(context, evalContext);
			object right = Right.EvaluateInternal(context, evalContext);

			if (NumberUtils.IsNumber(left) && NumberUtils.IsNumber(right)) {
				return NumberUtils.Add(left, right);
			} else if (left is DateTime && (right is TimeSpan || right is string || NumberUtils.IsNumber(right))) {
				if (NumberUtils.IsNumber(right)) {
					right = TimeSpan.FromDays(System.Convert.ToDouble(right));
				} else if (right is string) {
					right = TimeSpan.Parse((string)right);
				}

				return (DateTime)left + (TimeSpan)right;
			} else if (left is String || right is String) {
				return left.ToString() + right.ToString();
			} else {
				throw new ArgumentException("Cannot add instances of '"
					+ left.GetType().FullName
					+ "' and '"
					+ right.GetType().FullName
					+ "'.");
			}
		}
	}
}
