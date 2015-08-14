using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace MobDB2SQL {

	public class Program {

		public static void Main( string[] args ) {
			args = new string[ 1 ]{
				@"D:\Desktop\SenseRO\server\db\mob_db2.txt"
			};

			if( args == null || args.Length == 0 ) {
				Console.WriteLine( "drop item_db.txt on the exe!" );
				Console.Read();
				return;
			}

			Regex lineRegex = new Regex( "([0-9]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([^,]*),([0-9]*)" );
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

				string sqlLine = "REPLACE INTO `mob_db2` VALUES (";
				for( int g = 1; g < m.Groups.Count; g++ ) {
					sqlLine += "'" + Escape( m.Groups[ g ].Value ) + "', ";
				}

				sqlLine = sqlLine.Substring( 0, sqlLine.Length - 2 );
				sqlLine += ");";
				MySQlLines.Add( sqlLine );
			}

			if( MySQlLines.Count > 0 ) {
				File.WriteAllLines( @"D:\Desktop\mob_dump.sql", MySQlLines.ToArray() );
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
