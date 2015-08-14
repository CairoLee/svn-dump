
using GodLesZ.Library.Amf.IO;
namespace AuthTest {

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


		public static DsoAmfBody Read(AMFReader reader) {
			reader.Reset();

			ushort targetUriLen = reader.ReadUInt16();
			string targetUri = reader.ReadUTF(targetUriLen); // When the message holds a response from a remote endpoint, the target URI specifies which method on the local client (i.e. reader request originator) should be invoked to handle the response.
			ushort responseUriLen = reader.ReadUInt16();
			string responseUri = reader.ReadUTF(responseUriLen); // The response's target URI is set to the request's response URI with an '/onResult' suffix to denote a success or an '/onStatus' suffix to denote a failure.

			int numBytes = 4;
			uint dataLen = 0;
			while (numBytes-- > 0)
				dataLen = (dataLen << 8) | reader.ReadByte();

			// Need to skip 1 byte more, dont know why..
			reader.ReadByte();
			object bodyObj = reader.ReadData(); // turn the element into real data


			DsoAmfBody body = new DsoAmfBody(targetUri, responseUri, bodyObj);
			return body;
		}

	}

}
