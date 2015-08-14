
namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Base class for unary operators.
	/// </summary>
	internal abstract class BinaryOperator : BaseNode {
		public BinaryOperator() {
		}

		/// <summary>
		/// Gets the left operand.
		/// </summary>
		/// <value>The left operand.</value>
		public BaseNode Left {
			get { return (BaseNode)this.getFirstChild(); }
		}

		/// <summary>
		/// Gets the right operand.
		/// </summary>
		/// <value>The right operand.</value>
		public BaseNode Right {
			get { return (BaseNode)this.getFirstChild().getNextSibling(); }
		}


	}
}
