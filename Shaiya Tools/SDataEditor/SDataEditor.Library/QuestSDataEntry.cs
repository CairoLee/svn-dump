using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDataEditor.Library {

	public class QuestSDataEntry {
		public string text;
		public string str3;
		public int num5;
		public string str4;
		public int num6;
		public string str5;
		public string str6;
		public int num10;
		public string str7;
		public int num11;
		public string str2;


		public object[] ToRow( int RowNum ) {
			List<object> obj = new List<object>();

			obj.Add( RowNum );
			obj.Add( text );
			obj.Add( str3 );
			obj.Add( num5 );
			obj.Add( str4 );
			obj.Add( num6 );
			obj.Add( str5 );
			obj.Add( str6 );
			obj.Add( num10 );
			obj.Add( str7 );
			obj.Add( num11 );
			obj.Add( str2 );

			return obj.ToArray();
		}

	}

}
