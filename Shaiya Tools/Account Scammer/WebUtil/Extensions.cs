
namespace WebUtil {
	
	public static class Extensions {

		public static string Repeat( this string Text, int Count ) {
			string retStr = string.Empty;
			for( int i = 0; i < Count; i++ )
				retStr += Text;
			return retStr;
		}

		public static bool ToBool( this string Text ) {
			Text = Text.ToLower().Trim();
			if( Text == "true" || Text == "ja" || Text == "yes" || Text == "1" )
				return true;
			if( Text == "false" || Text == "false" || Text == "no" || Text == "0" )
				return false;

			return false;
		}

		public static float Percent( this int Value, int Percent ) {
			return ( (float)Value / 100f ) * (float)Percent;
		}

	}

}
