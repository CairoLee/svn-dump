using System.Net;

namespace WebUtil {

	public class PostResult {
		private byte[] mResponseData;
		private string mResponseString;

		public CookieCollection Cookies;

		public byte[] ResponseData {
			get { return mResponseData; }
			set {
				mResponseData = value;
				mResponseString = Util.ByteArrayToString( value );
			}
		}

		public string ResponseString {
			get { return mResponseString; }
			set {
				mResponseString = value;
				mResponseData = Util.StringToByteArray( value );
			}
		}


		public PostResult() {
		}

		public PostResult( byte[] response, CookieCollection cookies ) {
			ResponseData = response;
			Cookies = cookies;
		}

	}

}
