using System;
using System.IO;
using System.Text;
#if !SILVERLIGHT

#endif

namespace GodLesZ.Library.Amf.IO.Mp4 {
	/// <summary>
	/// Wrapper class for input streams containing MPEG4 data.
	/// Original idea based on code from MediaFrame (http://www.mediaframe.org)
	/// </summary>
	class Mp4DataStream {
		/// <summary>
		/// The input stream
		/// </summary>
		private Stream _stream;
		/// <summary>
		/// The current offset (position) in the stream.
		/// </summary>
		private long _offset = 0;

		public Mp4DataStream(Stream stream) {
			_stream = stream;
		}

		public long ReadBytes(int n) {
			int c = -1;
			long result = 0;
			while ((n-- > 0) && ((c = _stream.ReadByte()) != -1)) {
				result <<= 8;
				result += c & 0xff;
				_offset++;
			}
			if (c == -1)
				throw new EndOfStreamException();
			return result;
		}

		public String ReadString(int n) {
			int c = -1;
			StringBuilder sb = new StringBuilder();
			while ((n-- > 0) && ((c = (char)_stream.ReadByte()) != -1)) {
				sb.Append((char)c);
				_offset++;
			}
			if (c == -1)
				throw new EndOfStreamException();
			return sb.ToString();
		}

		public void SkipBytes(long n) {
			_offset += n;
			_stream.Seek(n, SeekOrigin.Current);
		}

		public long Offset {
			get { return _offset; }
		}

		public void Close() {
			_stream.Close();
		}
	}
}
