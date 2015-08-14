using System.Xml.Linq;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0XDocumentWriter : IAMFWriter {
		public AMF0XDocumentWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteXDocument(data as XDocument);
		}
		#endregion
	}

}
