using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya_Enchant_Calculator {

	public static class Extensions {

		public static string FormatShaiya( this int Number ) {
			string strNum = Number.ToString( "#,#" );
			if( Number < 1000 )
				return strNum;
			if( Number < 1000000 )
				return strNum + "k";
			if( Number < 1000000000 )
				return strNum + "kk";
			return strNum + "kkk";
		}

	}

}
