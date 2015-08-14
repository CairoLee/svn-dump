
namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0NullWriter : IAMFWriter {
		public AMF0NullWriter() {
		}

		#region IAMFWriter Members

		public bool IsPrimitive { get { return true; } }

		public void WriteData(AMFWriter writer, object data) {
			writer.WriteNull();
		}

		#endregion
	}
}
