
namespace GodLesZ.Library.Amf.IO.Readers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3BooleanFalseReader : IAMFReader {
		public AMF3BooleanFalseReader() {
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader) {
			return false;
		}

		#endregion
	}
}
