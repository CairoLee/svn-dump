
namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class RawBinary {
		byte[] _buffer;

		/// <summary>
		/// Initializes a new instance of the RawBinary class.
		/// </summary>
		/// <param name="buffer"></param>
		public RawBinary(byte[] buffer) {
			_buffer = buffer;
		}

		public byte[] Buffer { get { return _buffer; } }
	}
}