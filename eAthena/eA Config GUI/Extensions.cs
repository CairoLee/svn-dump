using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace eACGUI {

	public static class ColorExtensions {

		public static string ToHtml( this System.Drawing.Color Color ) {
			return System.Drawing.ColorTranslator.ToHtml( Color );
		}

	}

	public static class StringExtensions {

		public static bool IsNullOrEmpty( this string Text ) {
			return String.IsNullOrEmpty( Text );
		}

		/// <summary>
		/// checks if the Line contains //
		/// <para>start checking on the StartIndex</para>
		/// </summary>
		/// <param name="Line">the Stringline to check</param>
		/// <param name="StartIndex">index in the Stringline to begin checking</param>
		/// <returns>true if is an Comment, otherwise false</returns>
		public static bool IsComment( this string Line, int StartIndex ) {
			if( Line.Length < StartIndex + 2 )
				return false;
			return ( Line[ StartIndex ] == '/' && Line[ StartIndex + 1 ] == '/' );
		}

		/// <summary>
		/// checks if the Line contains //
		/// </summary>
		/// <param name="Line">the Stringline to check</param>
		/// <returns>true if is an Comment, otherwise false</returns>
		public static bool IsComment( this string Line ) {
			return Line.IsComment( 0 );
		}


		/// <summary>
		/// returns the Path beginning on StartPart
		/// </summary>
		/// <param name="FilePath"></param>
		/// <param name="StartPart"></param>
		/// <returns></returns>
		public static string GetPathParts( this string FilePath, string StartPart ) {
			string[] parts = FilePath.Split( new char[] { '\\' } );
			if( parts.Length == 0 )
				return string.Empty;
			if( parts.Contains<string>( StartPart ) == false )
				return string.Empty;

			int i;
			for( i = 0; i < parts.Length; i++ )
				if( parts[ i ].Equals( StartPart, StringComparison.OrdinalIgnoreCase ) == true )
					break;
			if( i >= parts.Length ) // huh? could this rly happen? <.<
				return string.Empty;

			string path = string.Empty;
			for( ; i < parts.Length; i++ )
				path += parts[ i ] + "\\";

			return path.Substring( 0, path.Length - 1 );
		}

		public static string ArrayToFile( this string[] StringArray ) {
			if( StringArray.Length == 0 )
				return string.Empty;

			string retValue = string.Empty;
			for( int i = 0; i < StringArray.Length; i++ )
				retValue += string.Format( "{0}\n", StringArray[ i ] );

			return retValue.Substring( 0, retValue.Length - 2 ); // remove last \n
		}
	}


}
