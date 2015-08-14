using System;

namespace GodLesZ.Library.Amf.Json {
	/// <summary>
	/// Builds a string. Unlike StringBuilder this class lets you reuse it's internal buffer.
	/// </summary>
	internal class StringBuffer {
		private char[] _buffer;
		private int _position;

		private static char[] _emptyBuffer = new char[0];

		public int Position {
			get { return _position; }
			set { _position = value; }
		}

		public StringBuffer() {
			_buffer = _emptyBuffer;
		}

		public StringBuffer(int initalSize) {
			_buffer = new char[initalSize];
		}

		public void Append(char value) {
			// test if the buffer array is large enough to take the value
			if (_position + 1 > _buffer.Length) {
				EnsureSize(1);
			}

			// set value and increment poisition
			_buffer[_position++] = value;
		}

		public void Clear() {
			_buffer = _emptyBuffer;
			_position = 0;
		}

		private void EnsureSize(int appendLength) {
			char[] newBuffer = new char[_position + appendLength * 2];

			Array.Copy(_buffer, newBuffer, _position);

			_buffer = newBuffer;
		}

		public override string ToString() {
			return new string(_buffer, 0, _position);
		}
	}
}