using System.Xml.Linq;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0XElementWriter : IAMFWriter {
		public AMF0XElementWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteXElement(data as XElement);
		}
		#endregion
	}

}
