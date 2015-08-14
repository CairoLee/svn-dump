
namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Represents parsed variable node.
	/// </summary>
	internal class VariableNode : BaseNode {
		public VariableNode() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			string varName = this.getText();
			if (varName == "this") {
				return evalContext.ThisContext;
			} else if (varName == "root") {
				return evalContext.RootContext;
			}
			return evalContext.Variables[varName];
		}
	}
}
