
namespace ZenAIConfigPanel.Expression {
	static class ErrorFormator {
		internal static string FormatError(Error code, int pos) {
			return string.Format(SR.ErrorFormat, code.ToString(), pos, (int)code);
		}
	}
}
