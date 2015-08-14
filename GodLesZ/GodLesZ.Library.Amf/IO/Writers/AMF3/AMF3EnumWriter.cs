using System;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3EnumWriter : IAMFWriter {
		public AMF3EnumWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return true; } }

		public void WriteData(AMFWriter writer, object data) {
			int value = Convert.ToInt32(data);
			writer.WriteAMF3Int(value);
		}

		#endregion
	}
}
