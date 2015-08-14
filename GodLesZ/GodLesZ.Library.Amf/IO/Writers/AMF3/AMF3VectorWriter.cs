using System.Collections.Generic;

namespace GodLesZ.Library.Amf.IO.Writers {
	class AMF3IntVectorWriter : IAMFWriter {
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteByte(AMF3TypeCode.IntVector);
			writer.WriteAMF3IntVector(data as IList<int>);
		}

		#endregion
	}
}
