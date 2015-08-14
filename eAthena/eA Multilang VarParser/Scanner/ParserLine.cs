using System;
using System.Collections.Generic;
using System.Text;

namespace eA_Script_VarParser {

	public struct ParserLine {
		public int Index;
		public string Line;

		public ParserLine( int LineNum, string Line ) {
			this.Index = LineNum;
			this.Line = Line;
		}

	}

}
