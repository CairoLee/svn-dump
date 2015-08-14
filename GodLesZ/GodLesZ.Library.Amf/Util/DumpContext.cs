using System;
using System.Text;

namespace GodLesZ.Library.Amf.Util {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class DumpContext {
		string _indent;
		StringBuilder _sb;

		public DumpContext() {
			_sb = new StringBuilder();
			_indent = string.Empty;
		}

		public void Indent() {
			_indent = _indent + "\t";
		}

		public void Unindent() {
			if (_indent != string.Empty)
				_indent = _indent.Remove(_indent.Length - 1, 1);
		}

		public void Append(string text) {
			_sb.Append(text);
		}

		public void AppendLine(string text) {
			_sb.Append(_indent);
			_sb.Append(text);
			_sb.Append(Environment.NewLine);
		}

		public override string ToString() {
			return _sb.ToString();
		}
	}
}
