using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprite_Reader {
	public static class RLE {
		public static char[] Decode( char[] Data ) {
			string ReturnData = String.Empty;

			for( int Offset = 0; Offset < Data.Length; Offset++ ) {
				char c = Data[ Offset ];
				if( c == 0 ) {
					char len = Data[ Offset + 1 ];
					if( len != 0 ) {
						Offset++;
						for( int j = 0; j < len; j++ )
							ReturnData += '\0';
					}
				} else
					ReturnData += c;
			}
			
			return ReturnData.ToCharArray();
		}

	}

}
