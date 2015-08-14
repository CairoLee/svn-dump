using System.Collections;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class ExpressionEvaluator {
		public ExpressionEvaluator() {
		}

		/// <summary>
		/// Parses and evaluates the specified expression.
		/// </summary>
		/// <param name="root">Root object.</param>
		/// <param name="expression">Expression to evaluate.</param>
		/// <param name="variables">Expression variables map.</param>
		/// <returns>Value of the last node in the expression.</returns>
		public static object Evaluate(object root, string expression, IDictionary variables) {
			return Expression.Parse(expression).Evaluate(root, variables);
		}
	}
}
