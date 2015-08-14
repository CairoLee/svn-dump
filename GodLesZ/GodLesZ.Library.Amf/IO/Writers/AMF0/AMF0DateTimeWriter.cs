using System;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0DateTimeWriter : IAMFWriter {
		public AMF0DateTimeWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return true; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteByte(AMF0TypeCode.DateTime);
			writer.WriteDateTime((DateTime)data);
		}

		#endregion
	}
}
