using System;
using System.Globalization;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class HexLiteralNode : BaseNode {
		private object _value;

		public HexLiteralNode() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			if (_value == null) {
				lock (this) {
					if (_value == null) {
						string n = this.getText();
						try {
							_value = Int32.Parse(n.Substring(2), NumberStyles.HexNumber);
						} catch (OverflowException) {
							_value = Int64.Parse(n.Substring(2), NumberStyles.HexNumber);
						}
					}
				}
			}
			return _value;
		}
	}
}
