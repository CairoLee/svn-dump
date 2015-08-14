
using GodLesZ.Library.Amf.IO;
namespace AuthTest {

	public class DsoAmfHeader {

		public string Name {
			get;
			protected set;
		}

		public bool Required {
			get;
			protected set;
		}

		public object Object {
			get;
			protected set;
		}

		public DsoAmfHeader(string name, bool required, object obj) {
			Name = name;
			Required = required;
			Object = obj;
		}


		public static DsoAmfHeader Read(AMFReader reader) {
			reader.Reset();

			ushort nameLen = reader.ReadUInt16();
			string name = reader.ReadUTF(nameLen);
			bool required = (reader.ReadByte() > 0); // find the must understand flag
			uint dataLen = reader.ReadUInt32();
			object headObj = reader.ReadData();

			DsoAmfHeader header = new DsoAmfHeader(name, required, headObj);
			return header;
		}

	}

}
