using System;
using System.Globalization;

using antlr.collections;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class DateLiteralNode : BaseNode {
		private object _value;

		public DateLiteralNode() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			if (_value == null) {
				lock (this) {
					if (_value == null) {
						AST dateString = this.getFirstChild();
						if (getNumberOfChildren() == 2) {
							AST dateFormat = dateString.getNextSibling();
							_value = DateTime.ParseExact(dateString.getText(), dateFormat.getText(), CultureInfo.InvariantCulture);
						} else {
							_value = DateTime.Parse(dateString.getText());
						}
					}
				}
			}
			return _value;
		}

	}
}
