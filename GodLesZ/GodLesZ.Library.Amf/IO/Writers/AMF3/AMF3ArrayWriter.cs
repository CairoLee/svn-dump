using System;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3ArrayWriter : IAMFWriter {
		public AMF3ArrayWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteByte(AMF3TypeCode.Array);
			writer.WriteAMF3Array(data as Array);
		}

		#endregion
	}
}
