using System;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3GuidWriter : IAMFWriter {
		public AMF3GuidWriter() {
		}

		#region IAMFWriter Members

		public bool IsPrimitive { get { return true; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteAMF3String(((Guid)data).ToString());
		}

		#endregion
	}
}
