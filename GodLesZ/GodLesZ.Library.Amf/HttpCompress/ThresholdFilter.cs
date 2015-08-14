using System.IO;

namespace GodLesZ.Library.Amf.HttpCompress {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ThresholdFilter : HttpOutputFilter {
		MemoryStream _stream;
		Stream _baseStream;
		int _threshold;

		public ThresholdFilter(Stream compressStream, Stream baseStream, int threshold)
			: base(compressStream) {
			_baseStream = baseStream;
			_stream = new MemoryStream();
			_threshold = threshold;
		}

		public override void Write(byte[] buffer, int offset, int count) {
			_stream.Write(buffer, offset, count);
		}

		public override void Flush() {
			_stream.Flush();
		}

		public override void Close() {
			byte[] buffer = _stream.ToArray();
			if (_threshold <= 0 || _stream.Length > _threshold) {
				BaseStream.Write(buffer, 0, buffer.Length);
				BaseStream.Flush();
				BaseStream.Close();
			} else {
				_baseStream.Write(buffer, 0, buffer.Length);
				_baseStream.Flush();
				_baseStream.Close();
			}

			_stream.Close();
		}

		public CompressingFilter CompressingFilter {
			get { return BaseStream as CompressingFilter; }
		}
	}
}
