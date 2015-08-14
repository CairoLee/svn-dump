using System.IO;

namespace GodLesZ.Library.Amf.Util {
	class BufferStreamReader : TextReader {
		ByteBuffer _buffer;

		public BufferStreamReader(ByteBuffer buffer) {
			_buffer = buffer;
		}

		public override int Read() {
			if (_buffer.Position == _buffer.Length)
				return -1;
			int ch = _buffer.ReadByte();
			return ch;
		}

		public override int Peek() {
			if (_buffer.Position != _buffer.Length)
				return _buffer.Get((int)_buffer.Position);
			return -1;
		}
	}
}
