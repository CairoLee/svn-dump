using System.Data;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0DataTableWriter : IAMFWriter {
		public AMF0DataTableWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteASO(ObjectEncoding.AMF0, TypeHelper.ConvertDataTableToASO(data as DataTable, true));
		}

		#endregion
	}
}
