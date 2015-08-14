using System;
using System.Globalization;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class RealLiteralNode : BaseNode {
		private object _value;

		public RealLiteralNode() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			if (_value == null) {
				lock (this) {
					if (_value == null) {
						string n = this.getText();
						char lastChar = n.ToLower()[n.Length - 1];
						if (Char.IsDigit(lastChar)) {
							_value = Double.Parse(n, NumberFormatInfo.InvariantInfo);
						} else {
							n = n.Substring(0, n.Length - 1);
							if (lastChar == 'm') {
								_value = Decimal.Parse(n, NumberFormatInfo.InvariantInfo);
							} else if (lastChar == 'f') {
								_value = Single.Parse(n, NumberFormatInfo.InvariantInfo);
							} else {
								_value = Double.Parse(n, NumberFormatInfo.InvariantInfo);
							}
						}
					}
				}
			}
			return _value;
		}
	}
}
