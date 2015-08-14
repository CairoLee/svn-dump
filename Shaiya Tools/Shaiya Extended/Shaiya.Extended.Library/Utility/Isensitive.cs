using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Shaiya.Extended.Library.Utility {

	public class Insensitive {
		private static IComparer mComparer = CaseInsensitiveComparer.Default;

		public static IComparer Comparer {
			get { return mComparer; }
		}




		public static int Compare( string a, string b ) {
			return mComparer.Compare( a, b );
		}

		public static bool Equals( string a, string b ) {
			if( a == null && b == null )
				return true;
			else if( a == null || b == null || a.Length != b.Length )
				return false;

			return ( mComparer.Compare( a, b ) == 0 );
		}

		public static bool StartsWith( string a, string b ) {
			if( a == null || b == null || a.Length < b.Length )
				return false;

			return ( mComparer.Compare( a.Substring( 0, b.Length ), b ) == 0 );
		}

		public static bool EndsWith( string a, string b ) {
			if( a == null || b == null || a.Length < b.Length )
				return false;

			return ( mComparer.Compare( a.Substring( a.Length - b.Length ), b ) == 0 );
		}

		public static bool Contains( string a, string b ) {
			if( a == null || b == null || a.Length < b.Length )
				return false;

			a = a.ToLower();
			b = b.ToLower();

			return ( a.IndexOf( b ) >= 0 );
		}
	}

}
