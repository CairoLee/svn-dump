using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace WebUtil {

	public class WebUtil {
		public static CookieCollection Cookies = new CookieCollection();

		public static PostResult GetPage( string Uri, string UriReferer, PostRequest.PostTypeEnum Method, List<string> Params ) {
			PostRequest mClient;
			mClient = new PostRequest( Uri, UriReferer );
			mClient.Type = Method;
			if( Cookies != null )
				mClient.Cookies = Cookies;
			for( int i = 0; i < Params.Count; i += 2 )
				mClient.PostItems.Add( Params[ i ], Params[ i + 1 ] );

			return mClient.Post();
		}
		public static PostResult GetPage( string Uri, string UriReferer, string Params ) {
			List<string> newParams = new List<string>();
			Params = Params.Trim();
			if( Params.Length > 0 ) {
				foreach( string splitPair in Params.Split( new char[] { '&' } ) )
					newParams.AddRange( splitPair.Split( new char[] { '=' } ) );
			}

			return GetPage( Uri, UriReferer, PostRequest.PostTypeEnum.Post, newParams );
		}
		public static PostResult GetPage( string Uri, string UriReferer, PostRequest.PostTypeEnum Method, string Params ) {
			List<string> newParams = new List<string>();
			Params = Params.Trim();
			if( Params.Length > 0 ) {
				foreach( string splitPair in Params.Split( new char[] { '&' } ) )
					newParams.AddRange( splitPair.Split( new char[] { '=' } ) );
			}

			return GetPage( Uri, UriReferer, Method, newParams );
		}

	}

}
