using System.Xml;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0XmlDocumentWriter : IAMFWriter {
		public AMF0XmlDocumentWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteXmlDocument(data as XmlDocument);
		}
		#endregion
	}
}
