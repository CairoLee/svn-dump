using System.Text;
using System.Text.RegularExpressions;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class OpLike : BinaryOperator {
		public OpLike() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			string text = Left.EvaluateInternal(context, evalContext) as string;
			string pattern = Right.EvaluateInternal(context, evalContext) as string;
			return StrLike(text, pattern);

		}

		private bool StrLike(string text, string pattern) {
			//"" Like "[]" returns True
			if (StringUtils.IsNullOrEmpty(text) && StringUtils.IsNullOrEmpty(pattern))
				return true;
			else if ((StringUtils.IsNullOrEmpty(text) || StringUtils.IsNullOrEmpty(pattern)) && pattern != "[]") {
				return false;
			}
			RegexOptions options = RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;
			string regexString = ConvertLikeExpression(pattern);
			Regex regexpr = new Regex(regexString, options);
			return regexpr.IsMatch(text);
		}

		private string ConvertLikeExpression(string expression) {
			char[] carr = expression.ToCharArray();
			StringBuilder sb = new StringBuilder();
			bool bDigit = false;

			for (int pos = 0; pos < carr.Length; pos++) {
				switch (carr[pos]) {
					case '?':
					case '_'://'_' stands for any single character
						sb.Append('.');
						break;
					case '*':
						sb.Append('.').Append('*');
						break;
					case '%'://'%' stands for any sequence of characters, including the empty sequence
						sb.Append('*');
						break;
					case '#':  // only one digit and only once ->  "^\d{1}$"
						if (bDigit)
							sb.Append('\\').Append('d').Append('{').Append('1').Append('}');
						else {
							sb.Append('^').Append('\\').Append('d').Append('{').Append('1').Append('}');
							bDigit = true;
						}
						break;
					case '[':
						StringBuilder gsb = ConvertGroupSubexpression(carr, ref pos);
						//skip groups of form [], i.e. empty strings
						if (gsb.Length > 2)
							sb.Append(gsb);
						break;
					default:
						sb.Append(carr[pos]);
						break;
				}
			}
			if (bDigit)
				sb.Append('$');
			return sb.ToString();
		}

		private StringBuilder ConvertGroupSubexpression(char[] carr, ref int pos) {
			StringBuilder sb = new StringBuilder();
			bool negate = false;

			while (carr[pos] != ']') {
				if (negate) {
					sb.Append('^');
					negate = false;
				}
				if (carr[pos] == '!') {
					sb.Remove(1, sb.Length - 1);
					negate = true;
				} else
					sb.Append(carr[pos]);
				pos = pos + 1;
			}
			sb.Append(']');
			return sb;
		}
	}
}