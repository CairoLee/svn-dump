using GodLesZ.Library.Amf.IO;

namespace AmfTest {

	public class DsoAmfBody {

		public string TargetUrl {
			get;
			protected set;
		}

		public string ResponseUrl {
			get;
			protected set;
		}

		public object Object {
			get;
			protected set;
		}

		public DsoAmfBody(string target, string response, object obj) {
			TargetUrl = target;
			ResponseUrl = response;
			Object = obj;
		}


		public static DsoAmfBody Read(AMFReader reader, bool isAmf3) {
			reader.Reset();

			ushort targetUriLen = reader.ReadUInt16();
			string targetUri = reader.ReadUTF(targetUriLen); // When the message holds a response from a remote endpoint, the target URI specifies which method on the local client (i.e. reader request originator) should be invoked to handle the response.
			ushort responseUriLen = reader.ReadUInt16();
			string responseUri = reader.ReadUTF(responseUriLen); // The response's target URI is set to the request's response URI with an '/onResult' suffix to denote a success or an '/onStatus' suffix to denote a failure.

			long dataLen = reader.ReadUInt32();
			if (dataLen >= 2147483648) {
				dataLen = -4294967296;
			}

			object bodyObj;
			// Check for AMF3 kAvmPlusObjectType object type
			if (isAmf3) {
				byte typeMarker = reader.ReadByte();
				if (typeMarker == 17) {
					bodyObj = reader.ReadAMF3Data();
				} else {
					bodyObj = reader.ReadData();
				}
			} else {
				bodyObj = reader.ReadData();
			}


			DsoAmfBody body = new DsoAmfBody(targetUri, responseUri, bodyObj);
			return body;
		}

	}

}
