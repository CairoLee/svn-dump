using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class OpNotEqual : BinaryOperator {
		public OpNotEqual() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object left = Left.EvaluateInternal(context, evalContext);
			object right = Right.EvaluateInternal(context, evalContext);

			if (left == null) {
				return (right != null);
			} else if (right == null) {
				return true;
			} else if (left.GetType() == right.GetType()) {
				return !left.Equals(right);
			} else {
				return CompareUtils.Compare(left, right) != 0;
			}
		}
	}
}
