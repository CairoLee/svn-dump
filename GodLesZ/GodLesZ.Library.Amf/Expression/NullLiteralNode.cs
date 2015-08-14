
namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Represents parsed null literal node.
	/// </summary>
	internal class NullLiteralNode : BaseNode {
		public NullLiteralNode() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			return null;
		}

	}
}
