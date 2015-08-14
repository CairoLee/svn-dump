

namespace GodLesZ.Library.Amf.Json {
	public class Identifier {
		private string _name;

		public string Name {
			get { return _name; }
		}

		public Identifier(string name) {
			_name = name;
		}

		private static bool IsAsciiLetter(char c) {
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}

		public override bool Equals(object obj) {
			Identifier function = obj as Identifier;

			return Equals(function);
		}

		public bool Equals(Identifier function) {
			return (_name == function.Name);
		}

		public static bool Equals(Identifier a, Identifier b) {
			if (a == b)
				return true;

			if (a != null && b != null)
				return a.Equals(b);

			return false;
		}

		public override int GetHashCode() {
			return _name.GetHashCode();
		}

		public override string ToString() {
			return _name;
		}

		public static bool operator ==(Identifier a, Identifier b) {
			return Identifier.Equals(a, b);
		}

		public static bool operator !=(Identifier a, Identifier b) {
			return !Identifier.Equals(a, b);
		}
	}
}