
using GodLesZ.Library.Amf.Exceptions;

namespace GodLesZ.Library.Amf.IO.Readers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMFUnknownTagReader : IAMFReader {
		public AMFUnknownTagReader() {
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader) {
			throw new UnexpectedAMF();
		}

		#endregion
	}

	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class MovieclipMarker : IAMFReader {
		public MovieclipMarker() {
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader) {
			throw new UnexpectedAMF();
		}

		#endregion
	}

	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class UnsupportedMarker : IAMFReader {
		public UnsupportedMarker() {
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader) {
			throw new UnexpectedAMF();
		}

		#endregion
	}
}
