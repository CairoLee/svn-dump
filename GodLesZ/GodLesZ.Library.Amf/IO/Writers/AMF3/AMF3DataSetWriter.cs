using System.Data;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3DataSetWriter : IAMFWriter {
		public AMF3DataSetWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			ASObject aso = TypeHelper.ConvertDataSetToASO(data as DataSet, false);
			writer.WriteByte(AMF3TypeCode.Object);
			writer.WriteAMF3Object(aso);
		}

		#endregion
	}
}
