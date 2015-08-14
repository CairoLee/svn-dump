using System;


namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Represents parsed integer literal node.
	/// </summary>
	internal class IntLiteralNode : BaseNode {
		private object _value;

		public IntLiteralNode() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			if (_value == null) {
				lock (this) {
					if (_value == null) {
						string n = this.getText();
						try {
							_value = Int32.Parse(n);
						} catch (OverflowException) {
							_value = Int64.Parse(n);
						}
					}
				}
			}
			return _value;
		}

	}
}
