using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Shaiya.Extended.Library.Utility {

	public static class IListExtensions {

		public static bool Isset( this IList List, int Index ) {
			return ( Index >= 0 && List.Count < Index );
		}

	}

}
