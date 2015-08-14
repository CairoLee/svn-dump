#define readkey

using System;

namespace MatrixEffect {

	public class Program {
		private static Random mRnd = new Random();
		private static bool mThistime = false;

		public static char R {
			get {
				int t = mRnd.Next( 10 );
				if( t < 3 ) {
					return (char)( '0' + mRnd.Next( 10 ) );
				} else if( t < 5 ) {
					return (char)( 'a' + mRnd.Next( 27 ) );
				} else if( t < 7 ) {
					return (char)( 'A' + mRnd.Next( 27 ) );
				}
				return (char)mRnd.Next( 32, 255 );
			}
		}


		public static void Main( string[] args ) {
			Console.Title = "The Matrix Effect";
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WindowLeft = Console.WindowTop = 0;
			Console.WindowHeight = Console.BufferHeight = (int)( Console.LargestWindowHeight * 0.75f );
			Console.WindowWidth = Console.BufferWidth = (int)( Console.LargestWindowWidth * 0.75f );
#if readkey
			Console.WriteLine( "Press any Key to start!" );
			Console.ReadKey();
#endif
			Console.CursorVisible = false;

			int width, height;
			int[] y;
			int[] l;

			Initialize( out width, out height, out y, out l );

			int ms;
			while( true ) {
				DateTime t1 = DateTime.Now;
				MatrixStep( width, height, y, l );
				ms = 10 - (int)( (TimeSpan)( DateTime.Now - t1 ) ).TotalMilliseconds;
				if( ms > 0 ) {
					System.Threading.Thread.Sleep( ms );
				}

				if( Console.KeyAvailable ) {
					if( Console.ReadKey().Key == ConsoleKey.F5 ) {
						Initialize( out width, out height, out y, out l );
					}
				}
			}

		}


		public static int inBoxY( int n, int height ) {
			n = n % height;
			if( n < 0 ) {
				return n + height;
			}
			return n;
		}


		private static void MatrixStep( int width, int height, int[] y, int[] l ) {
			int x;
			mThistime = !mThistime;
			for( x = 0; x < width; ++x ) {
				if( x % 11 == 10 ) {
					if( !mThistime ) {
						continue;
					}

					Console.ForegroundColor = ConsoleColor.White;
				} else {
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.SetCursorPosition( x, inBoxY( y[ x ] - 2 - ( l[ x ] / 40 * 2 ), height ) );
					Console.Write( R );
					Console.ForegroundColor = ConsoleColor.Green;
				}

				Console.SetCursorPosition( x, y[ x ] );
				Console.Write( R );
				y[ x ] = inBoxY( y[ x ] + 1, height );
				Console.SetCursorPosition( x, inBoxY( y[ x ] - l[ x ], height ) );
				Console.Write( ' ' );
			}
		}

		private static void Initialize( out int width, out int height, out int[] y, out int[] l ) {
			int h1;
			int h2 = ( h1 = ( height = Console.WindowHeight ) / 2 ) / 2;

			width = Console.WindowWidth - 1;
			y = new int[ width ];
			l = new int[ width ];

			int x;
			Console.Clear();
			for( x = 0; x < width; ++x ) {
				y[ x ] = mRnd.Next( height );
				l[ x ] = mRnd.Next( h2 * ( ( x % 11 != 10 ) ? 2 : 1 ), h1 * ( ( x % 11 != 10 ) ? 2 : 1 ) );
			}

		}

	}

}