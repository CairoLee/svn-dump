using System.Collections.Generic;
using System.IO;
using System.Text;
using GodLesZ.Library.Amf.IO;

namespace AmfTest {

	public class DsoAmfHelper {

		public List<object> Header {
			get;
			protected set;
		}

		public List<object> Bodies {
			get;
			protected set;
		}


		public DsoAmfHelper(Stream stream) {
			byte[] buf = new byte[stream.Length];
			stream.Read(buf, 0, buf.Length);

			Read(buf);
		}

		public DsoAmfHelper(string data)
			: this(Encoding.UTF8.GetBytes(data)) {
		}

		public DsoAmfHelper(byte[] data) {
			Read(data);
		}


		public void Read(byte[] data) {
			using (MemoryStream ms = new MemoryStream(data)) {
				using (AMFReader amf = new AMFReader(ms)) {
					Header = new List<object>();
					Bodies = new List<object>();


					// AMF0_VERSION = 0;
					// AMF1_VERSION = 1; // There is no AMF1 but FMS uses it for some reason, hence special casing.
					// AMF3_VERSION = 3;
					ushort version = amf.ReadUInt16();

					// Number of headers
					ushort numHeaders = amf.ReadUInt16();
					while (numHeaders-- > 0) {
						var head = DsoAmfHeader.Read(amf);
						if (head != null) {
							Header.Add(head);
						}
					}

					// Number of bodys
					ushort numBodies = amf.ReadUInt16();
					while (numBodies-- > 0) {
						var body = DsoAmfBody.Read(amf, (version == 3));
						if (body != null) {
							Bodies.Add(body);
						}
					}
				}
			}


		}


	}

}
