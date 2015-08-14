using System.Data;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3DataTableWriter : IAMFWriter {
		public AMF3DataTableWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			ASObject aso = TypeHelper.ConvertDataTableToASO(data as DataTable, false);
			writer.WriteByte(AMF3TypeCode.Object);
			writer.WriteAMF3Object(aso);
		}

		#endregion
	}
}
