using System.Collections;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ListInitializerNode : NodeWithArguments {
		public ListInitializerNode() {
		}

		/// <summary>
		/// Creates new instance of the list defined by this node.
		/// </summary>
		/// <param name="context">Context to evaluate expressions against.</param>
		/// <param name="evalContext">Current expression evaluation context.</param>
		/// <returns>Node's value.</returns>
		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object[] values = ResolveArguments(evalContext);
			return new ArrayList(values);
		}
	}
}
