using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class OpIn : BinaryOperator {
		public OpIn() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object left = Left.EvaluateInternal(context, evalContext);
			object right = Right.EvaluateInternal(context, evalContext);

			if (right == null) {
				return false;
			} else if (right is IList) {
				return ((IList)right).Contains(left);
			} else if (right is IDictionary) {
				return ((IDictionary)right).Contains(left);
			} else {
				throw new ArgumentException("Right hand parameter for 'in' operator has to be an instance of IList or IDictionary.");
			}
		}
	}
}