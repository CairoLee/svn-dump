using System.Collections;
using GodLesZ.Library.Amf.Messaging.Rtmp;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmpt {
	class RtmptRequest {
		string _url;
		string _protocol;
		string _httpMethod;
		Hashtable _headers;
		ByteBuffer _data;
		RtmpConnection _connection;

		public RtmptRequest(RtmpConnection connection, string url, string protocol, string httpMethod, Hashtable headers) {
			_connection = connection;
			_url = url;
			_protocol = protocol;
			_httpMethod = httpMethod;
			_headers = headers;
		}

		public string Url { get { return _url; } }
		public string Protocol { get { return _protocol; } }
		public string HttpMethod { get { return _httpMethod; } }
		public Hashtable Headers { get { return _headers; } }

		public int ContentLength {
			get {
				if (_headers.Contains("Content-Length")) {
					int contentLength = System.Convert.ToInt32(_headers["Content-Length"]);
					return contentLength;
				}
				return 0;
			}
		}

		public int HttpVersion {
			get { return _protocol == "HTTP/1.1" ? 1 : 0; }
		}

		public ByteBuffer Data {
			get { return _data; }
			set { _data = value; }
		}

		public RtmpConnection Connection {
			get { return _connection; }
		}
	}
}
