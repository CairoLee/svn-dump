using System;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3DoubleWriter : IAMFWriter {
		public AMF3DoubleWriter() {
		}

		#region IAMFWriter Members

		public bool IsPrimitive { get { return true; } }

		public void WriteData(AMFWriter writer, object data) {
			double value = Convert.ToDouble(data);
			writer.WriteAMF3Double(value);
		}

		#endregion
	}
}
