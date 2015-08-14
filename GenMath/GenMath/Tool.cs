using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	public static class Tool {
		private static Random rnd = new Random();

		public static bool Mutate( int chance ) {
			if( rnd.Next( chance ) == 1 )
				return true;

			return false;
		}

		public static int GetInt( int chance ) {
			return rnd.Next( chance );
		}

		public static double GetDouble() {
			return rnd.NextDouble();
		}
	}
}
