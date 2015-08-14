using System;


namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class BooleanLiteralNode : BaseNode {
		private object _value;

		public BooleanLiteralNode() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			if (_value == null) {
				lock (this) {
					if (_value == null) {
						_value = Boolean.Parse(this.getText());
					}
				}
			}
			return _value;
		}
	}
}
