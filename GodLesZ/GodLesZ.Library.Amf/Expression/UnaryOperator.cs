
namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	abstract class UnaryOperator : BaseNode {
		public UnaryOperator() {
		}

		/// <summary>
		/// Gets the operand.
		/// </summary>
		/// <value>The operand.</value>
		public BaseNode Operand {
			get { return (BaseNode)this.getFirstChild(); }
		}
	}
}
