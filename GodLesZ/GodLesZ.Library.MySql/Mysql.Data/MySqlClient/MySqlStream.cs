using GodLesZ.Library.MySql.Data.Common;
using GodLesZ.Library.MySql.Properties;
using System;
using System.IO;
using System.Text;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class MySqlStream {
		private MemoryStream bufferStream;
		private byte[] byteBuffer;
		private System.Text.Encoding encoding;
		private ulong inLength;
		private ulong inPos;
		private Stream inStream;
		private bool isLastPacket;
		private int maxBlockSize;
		private ulong maxPacketSize;
		private ulong outLength;
		private ulong outPos;
		private Stream outStream;
		private int peekByte;
		private byte sequenceByte;
		private DBVersion version;

		public MySqlStream(System.Text.Encoding encoding) {
			this.maxPacketSize = ulong.MaxValue;
			this.maxBlockSize = 0x7fffffff;
			this.encoding = encoding;
			this.bufferStream = new MemoryStream();
			this.byteBuffer = new byte[1];
			this.peekByte = -1;
		}

		public MySqlStream(Stream baseStream, System.Text.Encoding encoding, bool compress)
			: this(encoding) {
			this.inStream = new BufferedStream(baseStream);
			this.outStream = new BufferedStream(baseStream);
			if (compress) {
				this.inStream = new CompressedStream(this.inStream);
				this.outStream = new CompressedStream(this.outStream);
			}
		}

		public void Close() {
			this.inStream.Close();
		}

		public void Flush() {
			if (this.outLength == 0L) {
				if (this.bufferStream.Length > 0L) {
					byte[] buffer = this.bufferStream.GetBuffer();
					this.StartOutput((ulong)this.bufferStream.Length, false);
					this.Write(buffer, 0, (int)this.bufferStream.Length);
				}
				this.bufferStream.SetLength(0L);
				this.bufferStream.Position = 0L;
			}
			try {
				this.outStream.Flush();
			} catch (IOException exception) {
				throw new MySqlException(Resources.WriteToStreamFailed, true, exception);
			}
		}

		public void LoadPacket() {
			try {
				int num = this.inStream.ReadByte();
				int num2 = this.inStream.ReadByte();
				int num3 = this.inStream.ReadByte();
				int num4 = this.inStream.ReadByte();
				if (((num == -1) || (num2 == -1)) || ((num3 == -1) || (num4 == -1))) {
					throw new MySqlException(Resources.ConnectionBroken, true, null);
				}
				this.sequenceByte = (byte)(++num4);
				this.inLength = (ulong)((num + (num2 << 8)) + (num3 << 0x10));
				this.inPos = 0L;
			} catch (IOException exception) {
				throw new MySqlException(Resources.ReadFromStreamFailed, true, exception);
			}
		}

		public void OpenPacket() {
			if (this.HasMoreData) {
				this.SkipBytes((int)(this.inLength - this.inPos));
			}
			this.LoadPacket();
			int num = this.PeekByte();
			if (num == 0xff) {
				this.ReadByte();
				int errno = this.ReadInteger(2);
				string msg = this.ReadString();
				if (msg.StartsWith("#")) {
					msg.Substring(1, 5);
					msg = msg.Substring(6);
				}
				throw new MySqlException(msg, errno);
			}
			this.isLastPacket = (num == 0xfe) && (this.inLength < 9L);
		}

		public int PeekByte() {
			if (this.peekByte == -1) {
				this.peekByte = this.ReadByte();
				this.inPos -= (ulong)1L;
			}
			return this.peekByte;
		}

		public int Read(byte[] buffer, int offset, int count) {
			int num = 0;
			while (count > 0) {
				if (this.peekByte != -1) {
					buffer[offset++] = (byte)this.ReadByte();
					count--;
					num++;
				} else {
					if (this.inPos == this.inLength) {
						if (this.inLength < (ulong)this.maxBlockSize) {
							return 0;
						}
						this.LoadPacket();
					}
					int num2 = Math.Min(count, (int)(this.inLength - this.inPos));
					try {
						int num3 = this.inStream.Read(buffer, offset, num2);
						if (num3 == 0)
							return num;

						count -= num3;
						offset += num3;
						num += num3;
						this.inPos += (ulong)num3;
						continue;
					} catch (IOException exception) {
						throw new MySqlException(Resources.ReadFromStreamFailed, true, exception);
					}
				}
			}
			return num;
		}

		public int ReadByte() {
			if (this.peekByte != -1) {
				int num = this.PeekByte();
				this.peekByte = -1;
				this.inPos += (ulong)1L;
				return num;
			}
			if (this.Read(this.byteBuffer, 0, 1) <= 0) {
				return -1;
			}
			return this.byteBuffer[0];
		}

		public long ReadFieldLength() {
			byte num = (byte)this.ReadByte();
			switch (num) {
				case 0xfb:
					return -1L;

				case 0xfc:
					return (long)this.ReadInteger(2);

				case 0xfd:
					return (long)this.ReadInteger(3);

				case 0xfe:
					return (long)this.ReadInteger(8);
			}
			return (long)num;
		}

		public int ReadInteger(int numbytes) {
			return (int)this.ReadLong(numbytes);
		}

		public string ReadLenString() {
			long length = this.ReadPackedInteger();
			return this.ReadString(length);
		}

		public ulong ReadLong(int numbytes) {
			ulong num = 0L;
			int num2 = 1;
			for (int i = 0; i < numbytes; i++) {
				int num4 = this.ReadByte();
				num += (ulong)(num4 * num2);
				num2 *= 0x100;
			}
			return num;
		}

		public int ReadNBytes() {
			byte numbytes = (byte)this.ReadByte();
			if ((numbytes < 1) || (numbytes > 4)) {
				throw new MySqlException(Resources.IncorrectTransmission);
			}
			return this.ReadInteger(numbytes);
		}

		public int ReadPackedInteger() {
			byte num = (byte)this.ReadByte();
			switch (num) {
				case 0xfb:
					return -1;

				case 0xfc:
					return this.ReadInteger(2);

				case 0xfd:
					return this.ReadInteger(3);

				case 0xfe:
					return this.ReadInteger(4);
			}
			return num;
		}

		public string ReadString() {
			MemoryStream stream = new MemoryStream();
			for (int i = this.ReadByte(); (i != 0) && (i != -1); i = this.ReadByte()) {
				stream.WriteByte((byte)i);
			}
			return this.encoding.GetString(stream.GetBuffer(), 0, (int)stream.Length);
		}

		public string ReadString(long length) {
			if (length == 0L) {
				return string.Empty;
			}
			byte[] buffer = new byte[length];
			this.Read(buffer, 0, (int)length);
			return this.encoding.GetString(buffer, 0, buffer.Length);
		}

		public void SendEmptyPacket() {
			this.outLength = 0L;
			this.outPos = 0L;
			this.WriteHeader();
			this.outStream.Flush();
		}

		public void SendEntirePacketDirectly(byte[] buffer, int count) {
			byte num;
			buffer[0] = (byte)(count & 0xff);
			buffer[1] = (byte)((count >> 8) & 0xff);
			buffer[2] = (byte)((count >> 0x10) & 0xff);
			this.sequenceByte = (byte)((num = this.sequenceByte) + 1);
			buffer[3] = num;
			this.outStream.Write(buffer, 0, count + 4);
			this.outStream.Flush();
		}

		public void SkipBytes(int len) {
			while (len-- > 0) {
				this.ReadByte();
			}
		}

		public void SkipPacket() {
			byte[] buffer = new byte[0x400];
			while (this.inPos < this.inLength) {
				int count = (int)Math.Min((ulong)buffer.Length, this.inLength - this.inPos);
				this.Read(buffer, 0, count);
			}
		}

		public void StartOutput(ulong length, bool resetSequence) {
			this.outLength = (ulong)(this.outPos = 0L);
			if (length > 0L) {
				if (length > this.maxPacketSize) {
					throw new MySqlException(Resources.QueryTooLarge, 0x481);
				}
				this.outLength = length;
			}
			if (resetSequence) {
				this.sequenceByte = 0;
			}
		}

		public void Write(byte[] buffer) {
			this.Write(buffer, 0, buffer.Length);
		}

		public void Write(byte[] buffer, int offset, int count) {
			if (this.outLength == 0L) {
				this.bufferStream.Write(buffer, offset, count);
			} else {
				int num = 0;
				while (count > 0) {
					int num2 = (int)Math.Min(this.outLength - this.outPos, (ulong)count);
					num2 = Math.Min(this.maxBlockSize - ((int)(this.outPos % ((ulong)this.maxBlockSize))), num2);
					if ((this.outPos % ((ulong)this.maxBlockSize)) == 0L) {
						this.WriteHeader();
					}
					try {
						this.outStream.Write(buffer, num, num2);
					} catch (IOException exception) {
						throw new MySqlException(Resources.WriteToStreamFailed, true, exception);
					}
					this.outPos += (ulong)num2;
					num += num2;
					count -= num2;
				}
			}
		}

		public void WriteByte(byte value) {
			this.byteBuffer[0] = value;
			this.Write(this.byteBuffer, 0, 1);
		}

		private void WriteHeader() {
			byte num2;
			int num = (int)Math.Min(this.outLength - this.outPos, (ulong)this.maxBlockSize);
			this.outStream.WriteByte((byte)(num & 0xff));
			this.outStream.WriteByte((byte)((num >> 8) & 0xff));
			this.outStream.WriteByte((byte)((num >> 0x10) & 0xff));
			this.sequenceByte = (byte)((num2 = this.sequenceByte) + 1);
			this.outStream.WriteByte(num2);
		}

		public void WriteInteger(long v, int numbytes) {
			long num = v;
			for (int i = 0; i < numbytes; i++) {
				this.WriteByte((byte)(num & 0xffL));
				num = num >> 8;
			}
		}

		public void WriteLength(long length) {
			if (length < 0xfbL) {
				this.WriteByte((byte)length);
			} else if (length < 0x10000L) {
				this.WriteByte(0xfc);
				this.WriteInteger(length, 2);
			} else if (length < 0x1000000L) {
				this.WriteByte(0xfd);
				this.WriteInteger(length, 3);
			} else {
				this.WriteByte(0xfe);
				this.WriteInteger(length, 4);
			}
		}

		public void WriteLenString(string s) {
			byte[] bytes = this.encoding.GetBytes(s);
			this.WriteLength((long)bytes.Length);
			this.Write(bytes, 0, bytes.Length);
		}

		public void WriteString(string v) {
			this.WriteStringNoNull(v);
			this.WriteByte(0);
		}

		public void WriteStringNoNull(string v) {
			byte[] bytes = this.encoding.GetBytes(v);
			this.Write(bytes, 0, bytes.Length);
		}

		public System.Text.Encoding Encoding {
			get { return this.encoding; }
			set { this.encoding = value; }
		}

		public bool HasMoreData {
			get {
				if (this.inLength <= 0L)
					return false;
				if (this.inLength != (ulong)this.maxBlockSize)
					return (this.inPos < this.inLength);
				return true;
			}
		}

		public MemoryStream InternalBuffer {
			get { return this.bufferStream; }
		}

		public bool IsLastPacket {
			get { return this.isLastPacket; }
		}

		public int MaxBlockSize {
			get { return this.maxBlockSize; }
			set { this.maxBlockSize = value; }
		}

		public ulong MaxPacketSize {
			get { return this.maxPacketSize; }
			set { this.maxPacketSize = value; }
		}

		public byte SequenceByte {
			get { return this.sequenceByte; }
			set { this.sequenceByte = value; }
		}

		public DBVersion Version {
			get { return this.version; }
			set { this.version = value; }
		}
	}
}

