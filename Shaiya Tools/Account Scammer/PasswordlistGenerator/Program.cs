using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordlistGenerator {

	public class Program {
		public static char[] SIGN_CHARS_HIGH = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
		public static char[] SIGN_CHARS_LOW = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
		public static char[] SIGN_NUMBER = "0123456789".ToCharArray();

		private static EPassState mPassState = EPassState.Low;

		public static void Main( string[] args ) {
			String loweralpha = "abcdefghijklmnopqrstuvwxyz";
			int wordLength = 7;
			for( int i = 1; i <= wordLength; i++ )
				BruteForce( loweralpha, i );
		}

		public static long BruteForce( String charset, int wordLength ) {
			long startw = 0;
			long endw = (long)Math.Pow( charset.Length, wordLength );
			long[] d = new long[ wordLength + 1 ];
			char[] charsetArray = charset.ToCharArray();
			int charsetLength = charset.Length;
			StringBuilder s = new StringBuilder( "" );

			for( int i = wordLength; i >= 0; i-- )
				d[ i ] = (long)Math.Pow( charsetLength, i );

			while( startw < endw ) {
				s.Remove( 0, s.Length );
				long mw = startw;
				for( int i = wordLength; i >= 0; i-- ) {
					int w = (int)( mw / d[ i ] );

					if( i == wordLength ) {
						if( w != 0 )
							s.Append( charsetArray[ w ] );
					} else
						s.Append( charsetArray[ w ] );

					mw = mw - ( w * d[ i ] );
				}

				Console.WriteLine( s );

				startw++;
			}
			return endw;
		}



		private static string GetNextPassword() {
			string password = "";
			for( int i = 0; i < SIGN_CHARS_LOW.Length; i++ ) {
				password += SIGN_CHARS_LOW[ i ];
			}

			return password;
		}

	}


	[Flags()]
	public enum EPassState {
		High = 1,
		Low = 2,
		Number = 4,
	}

}
