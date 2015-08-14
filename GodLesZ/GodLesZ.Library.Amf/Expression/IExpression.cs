using System.Collections;
using System.Reflection.Emit;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface IExpressionGenerator {
		void Emit(ILGenerator ilg);
	}

	delegate object EvaluateInvoker(object context, IDictionary variables);

	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface IExpression {
		/// <summary>
		/// Evaluates expression value.
		/// </summary>
		/// <param name="context">Object to evaluate expression against.</param>
		/// <param name="variables">Expression variables map.</param>
		/// <returns>Value of the expression.</returns>
		object Evaluate(object context, IDictionary variables);
	}
}
