
using System.IO;
using System.Text;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class StringWriterWithEncoding : StringWriter {
		Encoding _encoding;

		/// <summary>
		/// Initializes a new instance of the StringWriterWithEncoding class.
		/// </summary>
		/// <param name="sb"></param>
		/// <param name="encoding"></param>
		public StringWriterWithEncoding(StringBuilder sb, Encoding encoding)
			: base(sb) {
			_encoding = encoding;
		}

		public override Encoding Encoding {
			get { return _encoding; }
		}
	}
}
