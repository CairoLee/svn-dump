using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace eACGUI {

	public class ConfParser {

		public static EathenaConfigFileCollection Load( string Name ) {
			EathenaConfigFileCollection files = new EathenaConfigFileCollection();
			EathenaConfigFile config = new EathenaConfigFile();
			if( Directory.Exists( Name ) == false ) {
				if( ConfParser.ReadFile( Name, out config ) == true )
					files.Add( Name.GetPathParts( "conf" ), config );
				return files;
			}

			string[] Files = Directory.GetFiles( Name, "*.conf" );
			for( int i = 0; i < Files.Length; i++ )
				if( ConfParser.ReadFile( Files[ i ], out config ) == true )
					files.Add( Files[ i ].GetPathParts( "conf" ), config );

			string[] Dirs = Directory.GetDirectories( Name );
			for( int i = 0; i < Dirs.Length; i++ )
				files.AddRange( ConfParser.Load( Dirs[ i ] ) );

			return files;
		}


		public static bool ReadFile( string Filename, out EathenaConfigFile Configs ) {
			EathenaConfig Config = new EathenaConfig();
			string line = string.Empty;
			string[] Lines;

			Configs = new EathenaConfigFile();
			Configs.Filename = Filename;

			if( File.Exists( Filename ) == false )
				return false;

			Lines = File.ReadAllLines( Filename );
			for( int i = 0; i < Lines.Length; i++ ) {
				line = Lines[ i ].Trim();
				if( line.IsComment() == true || line.Length < 2 )
					continue;

				if( ExtractSetting( line, out Config ) == false )
					continue;

				Config.Comments = FetchComments( Lines, i - 1 );
				Config.Line = i;
				Configs.Add( Config );
			}

			return true;

		}





		/// <summary>
		/// Parse the whole Line and searchs the Setting and Value
		/// </summary>
		/// <param name="line"></param>
		/// <param name="Config"></param>
		/// <returns></returns>
		private static bool ExtractSetting( string line, out EathenaConfig Config ) {
			string Setting = string.Empty;
			string Value = string.Empty;
			bool bFoundValue = false;
			Config = new EathenaConfig();

			for( int i = 0; i < line.Length; i++ ) {
				if( line.IsComment( i ) == true )
					break;
				if( line[ i ] == ':' ) {
					bFoundValue = true;
					continue;
				}

				if( bFoundValue == true )
					Value += line[ i ];
				else if( line[ i ] != ' ' ) // settings cant store whitespace
					Setting += line[ i ];
			}

			if( Setting.Trim() == string.Empty )
				return false; // no Config found

			//TODO: check the Trim()... maybe eA includes leading/trailing whitespaces in Settings?
			Config.Value = Value.Trim();
			Config.Name = Setting.Trim();

			return true;
		}

		/// <summary>
		/// Iterate recursive through all Lines and saves the Comments
		/// </summary>
		/// <param name="Lines"></param>
		/// <param name="StartIndex"></param>
		/// <returns></returns>
		private static string[] FetchComments( string[] Lines, int StartIndex ) {
			List<string> comments = new List<string>();
			string line = string.Empty;

			for( int i = StartIndex; i > 0; i-- ) {
				line = Lines[ i ].Trim();
				if( line.IsComment() == false )
					break;

				comments.Add( line.Substring( 2 ) ); // skipp starting //
			}

			comments.Reverse(); // we read form last to first comment, so reverse the entrys

			return comments.ToArray();
		}

	}

}
