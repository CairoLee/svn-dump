using System;
using System.Collections.Generic;
using System.Text;

namespace eA_Script_VarParser {

	public static class Extensions {

		public static int CountChar( this string Text, char c ) {
			int count = 0;
			for( int i = 0; i < Text.Length; i++ )
				if( Text[ i ] == c )
					count++;
			return count;
		}

	}

}
