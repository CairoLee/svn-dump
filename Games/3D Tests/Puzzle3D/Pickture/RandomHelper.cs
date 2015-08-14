using System;
using System.Collections.Generic;

namespace Puzzle3D {

	public static class RandomHelper {
		static Random random = new Random();

		public static Random Random {
			get { return random; }
		}


		public static float Next( float min, float max ) {
			return min + (float)( Random.NextDouble() * ( max - min ) );
		}

		public static bool NextBool() {
			return Random.Next( 2 ) == 0;
		}

		public static void Randomize<T>( IList<T> list ) {
			for( int i = 0; i < list.Count - 1; i++ ) {
				int randomIndex = Random.Next( i, list.Count );

				T swap = list[ randomIndex ];
				list[ randomIndex ] = list[ i ];
				list[ i ] = swap;
			}
		}

	}

}