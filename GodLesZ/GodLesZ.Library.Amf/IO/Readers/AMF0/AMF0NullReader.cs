
namespace GodLesZ.Library.Amf.IO.Readers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0NullReader : IAMFReader {
		public AMF0NullReader() {
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader) {
			return null;
		}

		#endregion
	}
}
