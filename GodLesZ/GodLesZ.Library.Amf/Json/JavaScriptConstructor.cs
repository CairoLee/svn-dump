using System;
using System.Text;

namespace GodLesZ.Library.Amf.Json {
	/// <summary>
	/// Represents a JavaScript constructor.
	/// </summary>
	public class JavaScriptConstructor {
		private string _name;
		private JavaScriptParameters _parameters;

		public JavaScriptParameters Parameters {
			get { return _parameters; }
		}

		public string Name {
			get { return _name; }
		}

		public JavaScriptConstructor(string name, JavaScriptParameters parameters) {
			if (name == null)
				throw new ArgumentNullException("name");

			if (name.Length == 0)
				throw new ArgumentException("Constructor name cannot be empty.", "name");

			_name = name;
			_parameters = parameters != null ? parameters : JavaScriptParameters.Empty;
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();

			sb.Append("new ");
			sb.Append(_name);
			sb.Append("(");
			if (_parameters != null) {
				for (int i = 0; i < _parameters.Count; i++) {
					sb.Append(_parameters[i]);
				}
			}
			sb.Append(")");

			return sb.ToString();
		}
	}
}