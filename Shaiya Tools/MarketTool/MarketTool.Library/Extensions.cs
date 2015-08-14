using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MarketTool.Library {

	public static class Extensions {

		public static Color ToGoldColor( this int Number ) {
			Color col = Color.White;
			if( Number >= 1000000000 ) // 1.000kk
				col = Color.FromArgb( 86, 33, 147 ); // dunkel-lila
			else if( Number >= 100000000 ) // 100kk
				col = Color.FromArgb( 185, 54, 196 ); // lila/rosa
			else if( Number >= 10000000 ) // 10kk
				col = Color.FromArgb( 199, 139, 77 ); // orange
			else if( Number >= 1000000 ) // 1kk
				col = Color.FromArgb( 232, 238, 116 ); // gelb
			else if( Number >= 100000 ) // 100k
				col = Color.FromArgb( 71, 203, 117 ); // hell-grün
			else if( Number >= 10000 ) // 10k
				col = Color.FromArgb( 58, 117, 177 ); // marine-blau
			else if( Number >= 1000 ) // 1k
				col = Color.FromArgb( 171, 237, 225 ); // hell-blau

			return col;
		}


		public static int Clamp( this int Number, int Min, int Max ) {
			return ( Number < Min ? Min : ( Number > Max ? Max : Number ) );
		}

		public static int Clamp( this int Number ) {
			return Number.Clamp( 0, int.MaxValue );
		}




		public static string MakeValidFilename( this string Filename) {
			return Filename.MakeValidFilename( "_" );
		}

		public static string MakeValidFilename( this string Filename, string Replace ) {
			char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
			for( int i = 0; i < invalidChars.Length; i++ ) {
				int index = Filename.IndexOf( invalidChars[ i ] );
				if( index == -1 )
					continue;
				Filename = Filename.Replace( new string( invalidChars[ i ], 1 ), Replace );
			}

			return Filename;
		}

	}

}
