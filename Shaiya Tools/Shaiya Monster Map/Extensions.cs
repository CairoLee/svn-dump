using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShaiyaMonsterMap {

	public static class ListeViewExtensions {

		public static SizeF MesureString( this System.Windows.Forms.ListView List, string Text ) {
			SizeF size;
			using( Graphics g = List.CreateGraphics() )
				size = g.MeasureString( Text, List.Font );

			return size;
		}

	}

	public static class StreamExtensions {

		public static byte[] ReadAll( this System.IO.Stream s ) {
			if( s.CanSeek == false )
				return new byte[ 0 ];

			s.Seek( 0, System.IO.SeekOrigin.Begin );
			if( s.CanRead == false )
				return new byte[ 0 ];

			byte[] buffer = new byte[ s.Length ];
			s.Read( buffer, 0, buffer.Length );

			return buffer;
		}

	}


	public static class IntegerExtensions {

		public static int Clamb( this int Value, int min, int max ) {
			int result = Value;
			if( result > max )
				result = max;
			if( result < min )
				result = min;

			return result;
		}

	}

	public static class StringExtensions {

		public static Color ToColor( this string HexColor ) {
			return System.Drawing.ColorTranslator.FromHtml( HexColor );
		}

	}

	public static class ColorExtensions {
		private static char[] hexDigits = {
			'0', '1', '2', '3', '4', '5', '6', '7',
			'8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
		};


		public static string ToHex( this Color color ) {
			byte[] bytes = new byte[ 3 ];
			bytes[ 0 ] = color.R;
			bytes[ 1 ] = color.G;
			bytes[ 2 ] = color.B;
			char[] chars = new char[ bytes.Length * 2 ];
			for( int i = 0; i < bytes.Length; i++ ) {
				int b = bytes[ i ];
				chars[ i * 2 ] = hexDigits[ b >> 4 ];
				chars[ i * 2 + 1 ] = hexDigits[ b & 0xF ];
			}
			return "#" + new string( chars );
		}

	}

}
