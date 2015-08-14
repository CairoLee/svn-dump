using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Shaiya.Extended.Library.Utility {

	public class IP {
		private static Dictionary<IPAddress, IPAddress> mIPAddressTable;

		public static string Intern( string str ) {
			if( str == null )
				return null;
			else if( str.Length == 0 )
				return String.Empty;

			return String.Intern( str );
		}

		public static void Intern( ref string str ) {
			str = Intern( str );
		}


		public static IPAddress Intern( IPAddress ipAddress ) {
			if( mIPAddressTable == null ) 
				mIPAddressTable = new Dictionary<IPAddress, IPAddress>();

			IPAddress interned;
			if( !mIPAddressTable.TryGetValue( ipAddress, out interned ) ) {
				interned = ipAddress;
				mIPAddressTable[ ipAddress ] = interned;
			}

			return interned;
		}

		public static void Intern( ref IPAddress ipAddress ) {
			ipAddress = Intern( ipAddress );
		}

	}

}
