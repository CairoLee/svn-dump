using GodLesZ.Library.MySql.Data.MySqlClient;
using GodLesZ.Library.MySql.Properties;
using System;
using System.IO;

namespace GodLesZ.Library.MySql.Data.Common {

	internal class NamedPipeStream : Stream {
		private FileAccess _mode;
		private int pipeHandle;

		public NamedPipeStream(string host, FileAccess mode) {
			this.Open(host, mode);
		}

		public override void Close() {
			if (this.pipeHandle != 0) {
				NativeMethods.CloseHandle((IntPtr)this.pipeHandle);
				this.pipeHandle = 0;
			}
		}

		public override void Flush() {
			if (this.pipeHandle != 0) {
				NativeMethods.FlushFileBuffers((IntPtr)this.pipeHandle);
			}
		}

		public void Open(string host, FileAccess mode) {
			this._mode = mode;
			uint desiredAccess = 0;
			if ((mode & FileAccess.Read) > 0) {
				desiredAccess |= 0x80000000;
			}
			if ((mode & FileAccess.Write) > 0) {
				desiredAccess |= 0x40000000;
			}
			this.pipeHandle = NativeMethods.CreateFile(host, desiredAccess, 0, null, 3, 0, 0);
		}

		public override int Read(byte[] buffer, int offset, int count) {
			uint num;
			if (buffer == null) {
				throw new ArgumentNullException("buffer", Resources.BufferCannotBeNull);
			}
			if (buffer.Length < (offset + count)) {
				throw new ArgumentException(Resources.BufferNotLargeEnough);
			}
			if (offset < 0) {
				throw new ArgumentOutOfRangeException("offset", offset, Resources.OffsetCannotBeNegative);
			}
			if (count < 0) {
				throw new ArgumentOutOfRangeException("count", count, Resources.CountCannotBeNegative);
			}
			if (!this.CanRead) {
				throw new NotSupportedException(Resources.StreamNoRead);
			}
			if (this.pipeHandle == 0) {
				throw new ObjectDisposedException("NamedPipeStream", Resources.StreamAlreadyClosed);
			}
			byte[] lpBuffer = new byte[count];
			if (!NativeMethods.ReadFile((IntPtr)this.pipeHandle, lpBuffer, (uint)count, out num, IntPtr.Zero)) {
				this.Close();
				throw new MySqlException(Resources.ReadFromStreamFailed, true, null);
			}
			Array.Copy(lpBuffer, 0, buffer, offset, (int)num);
			return (int)num;
		}

		public override long Seek(long offset, SeekOrigin origin) {
			throw new NotSupportedException(Resources.NamedPipeNoSeek);
		}

		public override void SetLength(long length) {
			throw new NotSupportedException(Resources.NamedPipeNoSetLength);
		}

		public override void Write(byte[] buffer, int offset, int count) {
			bool flag;
			if (buffer == null) {
				throw new ArgumentNullException("buffer", Resources.BufferCannotBeNull);
			}
			if (buffer.Length < (offset + count)) {
				throw new ArgumentException(Resources.BufferNotLargeEnough, "buffer");
			}
			if (offset < 0) {
				throw new ArgumentOutOfRangeException("offset", offset, Resources.OffsetCannotBeNegative);
			}
			if (count < 0) {
				throw new ArgumentOutOfRangeException("count", count, Resources.CountCannotBeNegative);
			}
			if (!this.CanWrite) {
				throw new NotSupportedException(Resources.StreamNoWrite);
			}
			if (this.pipeHandle == 0) {
				throw new ObjectDisposedException("NamedPipeStream", Resources.StreamAlreadyClosed);
			}
			uint numberOfBytesWritten = 0;
			if ((offset == 0) && (count <= 0xffff)) {
				flag = NativeMethods.WriteFile((IntPtr)this.pipeHandle, buffer, (uint)count, out numberOfBytesWritten, IntPtr.Zero);
			} else {
				byte[] destinationArray = new byte[0xffff];
				flag = true;
				while ((count != 0) && flag) {
					uint num2;
					int length = Math.Min(count, 0xffff);
					Array.Copy(buffer, offset, destinationArray, 0, length);
					flag = NativeMethods.WriteFile((IntPtr)this.pipeHandle, destinationArray, (uint)length, out num2, IntPtr.Zero);
					numberOfBytesWritten += num2;
					count -= length;
					offset += length;
				}
			}
			if (!flag) {
				this.Close();
				throw new MySqlException(Resources.WriteToStreamFailed, true, null);
			}
			if (numberOfBytesWritten < count) {
				throw new IOException("Unable to write entire buffer to stream");
			}
		}

		public override bool CanRead {
			get { return ((this._mode & FileAccess.Read) > 0); }
		}

		public override bool CanSeek {
			get { throw new NotSupportedException(Resources.NamedPipeNoSeek); }
		}

		public override bool CanWrite {
			get { return ((this._mode & FileAccess.Write) > 0); }
		}

		public override long Length {
			get { throw new NotSupportedException(Resources.NamedPipeNoSeek); }
		}

		public override long Position {
			get { throw new NotSupportedException(Resources.NamedPipeNoSeek); }
			set { }
		}
	}
}

