using System.Xml.Linq;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3XElementWriter : IAMFWriter {
		public AMF3XElementWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteAMF3XElement(data as XElement);
		}
		#endregion
	}
}
