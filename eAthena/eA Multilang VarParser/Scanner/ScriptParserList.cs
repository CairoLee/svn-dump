using System;
using System.Collections.Generic;
using System.Text;

namespace eA_Script_VarParser {

	public class ScriptParserList : List<ScriptParser> {
		public static int Longest = 0;

		public List<string> GetConstants() {
			List<string> consts = new List<string>();
			for( int i = 0; i < Count; i++ )
				foreach( ScriptMessage msg in this[ i ].Messages.Values ) {
					consts.Add( msg.Constant );
					Longest = Math.Max( msg.Constant.Length, Longest );
				}
			return consts;
		}

	}

}
