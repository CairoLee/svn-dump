using System.Data;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0DataSetWriter : IAMFWriter {
		public AMF0DataSetWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteASO(ObjectEncoding.AMF0, TypeHelper.ConvertDataSetToASO(data as DataSet, true));
		}

		#endregion
	}
}
