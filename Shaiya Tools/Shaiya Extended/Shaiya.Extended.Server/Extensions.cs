using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya.Extended.Server {

	public static class Extensions {

		public static int UnixTimestamp( this DateTime dt ) {
			return Convert.ToInt32( ( DateTime.Now - new DateTime( 1970, 1, 1 ) ).TotalSeconds );
		}

	}

}
