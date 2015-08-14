using System.Collections;
using System.Text;

namespace GodLesZ.Library.Amf.Util {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// Pretty-print code formatted using line breaks and indentation.
	/// </summary>
	sealed class Layouter {
		StringBuilder _sb;
		Stack _blockStack;
		int _indent;

		public Layouter() {
			_sb = new StringBuilder();
			_blockStack = new Stack();
			_indent = 0;
		}
		/// <summary>
		/// Begin a block.
		/// </summary>
		public void Begin() {
			_blockStack.Push(_indent);
			_indent += 4;
		}
		/// <summary>
		/// Ends the innermost block.
		/// </summary>
		public void End() {
			_indent = (int)_blockStack.Pop();
		}
		/// <summary>
		/// Appends a formatted string, which contains zero or more format specifications, to this instance. Each format specification is replaced by the string representation of a corresponding object argument.
		/// </summary>
		/// <param name="format">A string containing zero or more format specifications.</param>
		/// <param name="args">An array of objects to format.</param>
		/// <returns>A reference to this instance with format appended. Any format specification in format is replaced by the string representation of the corresponding object argument.</returns>
		public StringBuilder AppendFormat(string format, params object[] args) {
			_sb.Append(new string(' ', _indent));
			_sb.AppendFormat(format, args);
			return _sb.Append("\n");
		}
		/// <summary>
		/// Appends a copy of the specified string to the end of this instance.
		/// </summary>
		/// <param name="value">The String to append.</param>
		/// <returns>A reference to this instance after the append operation has occurred.</returns>
		public StringBuilder Append(string value) {
			_sb.Append(new string(' ', _indent));
			_sb.Append(value);
			return _sb.Append("\n");
		}

		public override string ToString() {
			return _sb.ToString();
		}

		public StringBuilder Builder {
			get { return _sb; }
		}
	}
}
