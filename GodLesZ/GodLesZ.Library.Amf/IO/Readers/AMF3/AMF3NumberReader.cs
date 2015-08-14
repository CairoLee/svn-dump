
namespace GodLesZ.Library.Amf.IO.Readers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3NumberReader : IAMFReader {
		public AMF3NumberReader() {
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader) {
			return reader.ReadDouble();
			//AMF3 undefined = double.NaN
		}

		#endregion
	}
}
