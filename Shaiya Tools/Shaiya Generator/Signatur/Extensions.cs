using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya_Signatur_Generator {

	public static class ListExtensions {

		public static void Swap( this System.Collections.IList List, int ToSwap, int AddToIndex ) {
			int futureDir = ToSwap + AddToIndex;
			object temp = List[ ToSwap ];

			List[ ToSwap ] = List[ futureDir ];
			List[ futureDir ] = temp;
		}

	}

}
