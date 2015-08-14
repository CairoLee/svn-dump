using System;
using System.Text;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Web;

namespace WebUtil {

	public class WebInfo {
		public string Useragent = "	Mozilla/5.0 (Windows; U; Windows NT 5.1; de; rv:1.9.1.7) Gecko/20091221 Firefox/3.5.7";
		public string RequestAccept = "	text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
		public string AcceptLanguage = "de-de,de;q=0.8,en-us;q=0.5,en;q=0.3";
		public string AcceptEncoding = "gzip,deflate";
		public string AcceptCharset = "ISO-8859-1,utf-8;q=0.7,*;q=0.7";
		public int KeepAlive = 300;
	}

	public class PostRequest {

		public enum PostTypeEnum {
			Get,
			Post
		}

		private string mUrl = string.Empty;
		private string mUrlReferer = string.Empty;
		private NameValueCollection mValues = new NameValueCollection();
		private PostTypeEnum mType = PostTypeEnum.Get;
		private CookieCollection mCookies = null;
		private WebProxy mProxy = null;
		private int mTimeout = 0;
		private bool mIgnoreCookies = false;

		public static WebInfo WebInfo = new WebInfo();


		/// <summary>
		/// Gets or sets the url to submit the post to.
		/// </summary>
		public string Url {
			get { return mUrl; }
			set { mUrl = value; }
		}
		/// <summary>
		/// Gets or sets the name value collection of items to post.
		/// </summary>
		public NameValueCollection PostItems {
			get { return mValues; }
			set { mValues = value; }
		}
		/// <summary>
		/// Gets or sets the type of action to perform against the url.
		/// </summary>
		public PostTypeEnum Type {
			get { return mType; }
			set { mType = value; }
		}

		public CookieCollection Cookies {
			get { return mCookies; }
			set { mCookies = value; }
		}

		public WebProxy Proxy {
			get { return mProxy; }
			set { mProxy = value; }
		}

		public int Timeout {
			get { return mTimeout; }
			set { mTimeout = value; }
		}

		public bool IgnoreCookies {
			get { return mIgnoreCookies; }
			set { mIgnoreCookies = value; }
		}


		/// <summary>
		/// Default constructor.
		/// </summary>
		public PostRequest() {
		}

		/// <summary>
		/// Constructor that accepts a url as a parameter
		/// </summary>
		/// <param name="url">The url where the post will be submitted to.</param>
		public PostRequest( string url, string urlReferer )
			: this() {
			mUrl = url;
			mUrlReferer = urlReferer;
		}

		/// <summary>
		/// Constructor allowing the setting of the url and items to post.
		/// </summary>
		/// <param name="url">the url for the post.</param>
		/// <param name="values">The values for the post.</param>
		public PostRequest( string url, string urlReferer, NameValueCollection values )
			: this( url, urlReferer ) {
			mValues = values;
		}


		/// <summary>
		/// Posts the supplied data to specified url.
		/// </summary>
		/// <returns>a string containing the result of the post.</returns>
		public PostResult Post() {
			StringBuilder parameters = new StringBuilder();
			for( int i = 0; i < mValues.Count; i++ ) {
				EncodeAndAddItem( ref parameters, mValues.GetKey( i ), mValues[ i ] );
			}

			return PostData( mUrl, parameters.ToString() );
		}
		/// <summary>
		/// Posts the supplied data to specified url.
		/// </summary>
		/// <param name="url">The url to post to.</param>
		/// <returns>a string containing the result of the post.</returns>
		public PostResult Post( string url ) {
			mUrl = url;
			return this.Post();
		}
		/// <summary>
		/// Posts the supplied data to specified url.
		/// </summary>
		/// <param name="url">The url to post to.</param>
		/// <param name="values">The values to post.</param>
		/// <returns>a string containing the result of the post.</returns>
		public PostResult Post( string url, NameValueCollection values ) {
			mValues = values;
			return this.Post( url );
		}



		/// <summary>
		/// Posts data to a specified url. Note that this assumes that you have already url encoded the post data.
		/// </summary>
		/// <param name="postData">The data to post.</param>
		/// <param name="url">the url to post to.</param>
		/// <returns>Returns the result of the post.</returns>
		private PostResult PostData( string url, string postData ) {
			PostResult result = new PostResult();
			HttpWebRequest request = null;
			if( WebInfo == null )
				throw new ArgumentException( "WebInfo cant be <null>!", "WebInfo" );

			if( mType == PostTypeEnum.Get & postData.Length > 0 ) 
				url += "?" + postData;

			Uri uri = new Uri( url );
			request = (HttpWebRequest)WebRequest.Create( uri );
			request.Credentials = CredentialCache.DefaultCredentials;
			request.CookieContainer = new CookieContainer();
			if( mIgnoreCookies == false )
				request.CookieContainer.GetCookies( uri );
			if( Cookies != null )
				request.CookieContainer.Add( this.Cookies );
			if( Proxy != null )
				request.Proxy = Proxy;
			if( mTimeout > 0 )
				request.Timeout = mTimeout;

			request.UserAgent = WebInfo.Useragent;
			request.Accept = WebInfo.RequestAccept;
			request.Headers.Add( HttpRequestHeader.AcceptLanguage, WebInfo.AcceptLanguage );
			request.Headers.Add( HttpRequestHeader.AcceptEncoding, WebInfo.AcceptEncoding );
			request.Headers.Add( HttpRequestHeader.AcceptCharset, WebInfo.AcceptCharset );
			request.Headers.Add( HttpRequestHeader.KeepAlive, WebInfo.KeepAlive.ToString() );
			request.Referer = mUrlReferer;
			request.KeepAlive = true;
			System.Net.ServicePointManager.Expect100Continue = false; // sonst error


			request.Method = mType.ToString().ToUpper();

			if( mType == PostTypeEnum.Post ) {
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = postData.Length;

				try {
					if( postData.Length > 0 ) {
						Stream writeStream = request.GetRequestStream();
						UTF8Encoding encoding = new UTF8Encoding();
						byte[] bytes = encoding.GetBytes( postData );
						writeStream.Write( bytes, 0, bytes.Length );
						writeStream.Close();
					}
				} catch { }
			}

			try {
				using( HttpWebResponse response = (HttpWebResponse)request.GetResponse() ) {
					result.Cookies = response.Cookies;
					using( Stream responseStream = response.GetResponseStream() ) {
						using( StreamReader readStream = new StreamReader( responseStream, Encoding.Default ) ) {
							result.ResponseString = readStream.ReadToEnd();
							if( response.ContentEncoding == "gzip" )
								result.ResponseString = Util.GZipDecompress( result.ResponseString );
							else if( response.ContentEncoding == "deflate" )
								throw new NotSupportedException( "Deflate-compression income - not yet finished :/" );
						}

					}
				}
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
				result.ResponseString = string.Empty;
			}
			return result;
		}


		/// <summary>
		/// Encodes an item and ads it to the string.
		/// </summary>
		/// <param name="baseRequest">The previously encoded data.</param>
		/// <param name="dataItem">The data to encode.</param>
		/// <returns>A string containing the old data and the previously encoded data.</returns>
		private void EncodeAndAddItem( ref StringBuilder baseRequest, string key, string dataItem ) {
			if( baseRequest == null ) {
				baseRequest = new StringBuilder();
			}
			if( baseRequest.Length != 0 ) {
				baseRequest.Append( "&" );
			}
			baseRequest.Append( key );
			baseRequest.Append( "=" );
			baseRequest.Append( HttpUtility.UrlEncode( dataItem ) );
		}

	}
}
