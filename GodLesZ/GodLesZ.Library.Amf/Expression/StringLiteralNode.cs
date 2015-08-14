
namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Represents parsed string literal node.
	/// </summary>
	internal class StringLiteralNode : BaseNode {
		public StringLiteralNode() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			return this.getText();
		}

	}
}
