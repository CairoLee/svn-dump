using System;
using System.Text;

namespace GodLesZ.Library.MySql.Data.Common {

	internal class SqlTokenizer {
		private bool ansiQuotes;
		private bool backslashEscapes;
		private int index;
		private bool inParamters;
		private string input;
		private bool inSize;
		private bool isSize;
		private bool quoted;

		public SqlTokenizer(string input) {
			this.input = input;
			this.index = -1;
			this.backslashEscapes = true;
		}

		public string NextToken() {
			char ch = '\0';
			bool flag = false;
			char ch2 = '\0';
			StringBuilder builder = new StringBuilder();
			bool flag2 = false;
			bool flag3 = false;
			this.quoted = this.isSize = false;
			while ((this.index + 1) < this.input.Length) {
				char ch3 = this.input[++this.index];
				if (flag) {
					builder.Append(ch3);
					flag = false;
				} else {
					if (ch3 == ch2) {
						this.quoted = true;
						return builder.ToString();
					}
					if (ch2 != '\0') {
						builder.Append(ch3);
					} else if ((((ch3 == '`') || (ch3 == '\'')) || ((ch3 == '"') && this.AnsiQuotes)) && !this.inSize) {
						ch2 = ch3;
					} else if (((ch3 == '/') && (ch == '*')) && flag2) {
						flag2 = false;
					} else if ((ch3 == '*') && (ch == '/')) {
						flag2 = true;
						builder.Remove(builder.Length - 1, 1);
					} else if (flag2 || flag3) {
						if (flag3 && (ch3 == '\n')) {
							flag3 = false;
						}
					} else if ((ch3 == '\\') && this.BackslashEscapes) {
						flag = true;
						builder.Append(ch3);
					} else if (ch3 == '#') {
						flag3 = true;
					} else if ((ch3 == '-') && (ch == '-')) {
						builder.Remove(builder.Length - 1, 1);
						flag3 = true;
					} else {
						if ((((ch3 == ',') || (ch3 == ')')) || (ch3 == '(')) && (builder.Length == 0)) {
							this.inParamters = true;
							return ch3.ToString();
						}
						if ((char.IsWhiteSpace(ch3) || (ch3 == '(')) || ((ch3 == ')') || ((ch3 == ',') && !this.inSize))) {
							if ((ch3 == ',') || ((ch3 == ')') && !this.inSize)) {
								this.index--;
							}
							if ((ch3 == ')') && this.inSize) {
								this.isSize = true;
								this.inSize = false;
							}
							if ((ch3 == '(') && this.inParamters) {
								this.inSize = true;
							}
							if (builder.Length > 0) {
								return builder.ToString();
							}
						} else {
							builder.Append(ch3);
						}
					}
				}
				ch = ch3;
			}
			if (builder.Length > 0) {
				return builder.ToString();
			}
			return null;
		}

		public bool AnsiQuotes {
			get { return this.ansiQuotes; }
			set { this.ansiQuotes = value; }
		}

		public bool BackslashEscapes {
			get { return this.backslashEscapes; }
			set { this.backslashEscapes = value; }
		}

		public int Index {
			get { return this.index; }
		}

		public bool IsSize {
			get { return this.isSize; }
		}

		public bool Quoted {
			get { return this.quoted; }
		}
	}
}

