using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ItemDB2SQL {

	public class Program {

		public static void Main( string[] args ) {
			args = new string[ 1 ]{
				@"D:\Desktop\SenseRO\server\db\item_db2.txt"
			};

			if( args == null || args.Length == 0 ) {
				Console.WriteLine( "drop item_db.txt on the exe!" );
				Console.Read();
				return;
			}

			Regex lineRegex = new Regex( "([0-9]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),{" );
			string[] Lines = File.ReadAllLines( args[ 0 ] );
			List<string> MySQlLines = new List<string>();
			for( int i = 0; i < Lines.Length; i++ ) {
				string line = Lines[ i ].Trim();
				if( line.StartsWith( "//" ) == true || line.Length == 0 ) {
					continue;
				}

				if( lineRegex.IsMatch( line ) == false ) {
					Console.WriteLine();
					continue;
				}

				Match m = lineRegex.Match( line );
				// 1189,Krasnaya,Krasnaya,4,0,,3800,220,,1,3,0x00004082,2,2,34,2,50,1,3,{ if(readparam(bStr)>=95) bonus bAtk,20; },{},{}
				// ([0-9]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),{([^}]*)},{([^}]*)},{([^}]*)}

				string sqlLine = "REPLACE INTO `item_db2` VALUES (";
				for( int g = 1; g < m.Groups.Count; g++ ) {
					sqlLine += "'" + Escape( m.Groups[ g ].Value ) + "', ";
				}

				// ,{ if(readparam(bStr)>=95) bonus bAtk,20; },{},{}
				line = line.Substring( line.IndexOf( ",{" ) + 2 );
				string[] parts = line.Split( new string[] { "},{" }, StringSplitOptions.None );
				string s1 = parts[ 0 ].Trim();
				string s2 = parts[ 1 ].Trim();
				string s3 = parts[ 2 ].Trim();
				s3 = s3.Substring( 0, s3.LastIndexOf( "}" ) ).Trim(); // kill last }
				if( s3.Contains( "//" ) == true ) {
					s3 = s3.Substring( 0, s3.IndexOf( "//" ) ).Trim();
				}
				sqlLine += "'" + Escape( s1 ) + "', '" + Escape( s2 ) + "', '" + Escape( s3 ) + "'";
				sqlLine += ");";
				MySQlLines.Add( sqlLine );
			}

			if( MySQlLines.Count > 0 ) {
				File.WriteAllLines( @"D:\Desktop\item_dump.sql", MySQlLines.ToArray() );
			}

		}



		public static string Escape( string value ) {
			value = value.Replace( @"\", @"\\" );
			value = value.Replace( "'", @"\'" );
			value = value.Replace( "\"", "\\\"" );
			value = value.Replace( "`", @"\`" );
			value = value.Replace( "\x00b4", "\\\x00b4" );
			value = value.Replace( "’", @"\’" );
			value = value.Replace( "‘", @"\‘" );

			return value;
		}

	}

}
