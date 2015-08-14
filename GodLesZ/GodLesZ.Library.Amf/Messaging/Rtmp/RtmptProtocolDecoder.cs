using System;
using System.Collections;

#if !(NET_1_1)

#endif
#if !SILVERLIGHT
using log4net;
#endif
using GodLesZ.Library.Amf.Util;
using GodLesZ.Library.Amf.Messaging.Rtmpt;

namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class RtmptProtocolDecoder {
#if !SILVERLIGHT
		private static readonly ILog log = LogManager.GetLogger(typeof(RtmptProtocolDecoder));
#endif

		public static RtmptRequest DecodeBuffer(RtmpConnection connection, ByteBuffer stream) {
			RtmpContext context = connection.Context;
			int position = (int)stream.Position;
			try {
				BufferStreamReader sr = new BufferStreamReader(stream);
				string request = sr.ReadLine();
				string[] tokens = request.Split(new char[] { ' ' });
				string method = tokens[0];
				string url = tokens[1];
				// Decode all encoded parts of the URL using the built in URI processing class
				int i = 0;
				while ((i = url.IndexOf("%", i)) != -1) {
					url = url.Substring(0, i) + Uri.HexUnescape(url, ref i) + url.Substring(i);
				}
				// Lets just make sure we are using HTTP, thats about all I care about
				string protocol = tokens[2];// "HTTP/"
				//Read headers
				Hashtable headers = new Hashtable();
				string line;
				string name = null;
				while ((line = sr.ReadLine()) != null && line != string.Empty) {
					// If the value begins with a space or a hard tab then this
					// is an extension of the value of the previous header and
					// should be appended
					if (name != null && Char.IsWhiteSpace(line[0])) {
						headers[name] += line;
						continue;
					}
					// Headers consist of [NAME]: [VALUE] + possible extension lines
					int firstColon = line.IndexOf(":");
					if (firstColon != -1) {
						name = line.Substring(0, firstColon);
						string value = line.Substring(firstColon + 1).Trim();
						headers[name] = value;
					} else {
						//400, "Bad header: " + line
						break;
					}
				}
				RtmptRequest rtmptRequest = new RtmptRequest(connection, url, protocol, method, headers);
				if (stream.Remaining == rtmptRequest.ContentLength) {
					stream.Compact();
					rtmptRequest.Data = ByteBuffer.Wrap(stream.ToArray());
					stream.Flip();
					return rtmptRequest;
				} else {
					// Move the position back to the start
					stream.Position = position;
				}
			} catch {
				// Move the position back to the start
				stream.Position = position;
				throw;
			}
			return null;
		}
	}
}
