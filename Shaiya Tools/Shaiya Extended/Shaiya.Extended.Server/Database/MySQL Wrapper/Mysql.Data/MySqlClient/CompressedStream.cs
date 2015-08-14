using Shaiya.Extended.Server.MySql.Data.MySqlClient.Properties;
using System;
using System.IO;
using Shaiya.Extended.Server.MySql.Zlib;

namespace Shaiya.Extended.Server.MySql.Data.MySqlClient {

	internal class CompressedStream : Stream {
		private Stream baseStream;
		private MemoryStream cache;
		private byte[] inBuffer;
		private WeakReference inBufferRef;
		private int inPos;
		private byte[] localByte;
		private int maxInPos;
		private ZInputStream zInStream;

		public CompressedStream( Stream baseStream ) {
			this.baseStream = baseStream;
			this.localByte = new byte[ 1 ];
			this.cache = new MemoryStream();
			this.inBufferRef = new WeakReference( this.inBuffer, false );
		}

		public override void Close() {
			this.baseStream.Close();
			base.Close();
		}

		private void CompressAndSendCache() {
			long length;
			long num2;
			byte[] buffer = this.cache.GetBuffer();
			byte num3 = buffer[ 3 ];
			buffer[ 3 ] = 0;
			MemoryStream stream = this.CompressCache();
			if( stream == null ) {
				length = this.cache.Length;
				num2 = 0L;
			} else {
				length = stream.Length;
				num2 = this.cache.Length;
			}
			this.baseStream.WriteByte( (byte)( length & 0xffL ) );
			this.baseStream.WriteByte( (byte)( ( length >> 8 ) & 0xffL ) );
			this.baseStream.WriteByte( (byte)( ( length >> 0x10 ) & 0xffL ) );
			this.baseStream.WriteByte( num3 );
			this.baseStream.WriteByte( (byte)( num2 & 0xffL ) );
			this.baseStream.WriteByte( (byte)( ( num2 >> 8 ) & 0xffL ) );
			this.baseStream.WriteByte( (byte)( ( num2 >> 0x10 ) & 0xffL ) );
			if( stream == null ) {
				this.baseStream.Write( buffer, 0, (int)this.cache.Length );
			} else {
				byte[] buffer2 = stream.GetBuffer();
				this.baseStream.Write( buffer2, 0, (int)stream.Length );
			}
			this.baseStream.Flush();
			this.cache.SetLength( 0L );
		}

		private MemoryStream CompressCache() {
			if( this.cache.Length < 50L ) {
				return null;
			}
			byte[] buffer = this.cache.GetBuffer();
			MemoryStream stream = new MemoryStream();
			ZOutputStream stream2 = new ZOutputStream( stream, -1 );
			stream2.Write( buffer, 0, (int)this.cache.Length );
			stream2.finish();
			if( stream.Length >= this.cache.Length ) {
				return null;
			}
			return stream;
		}

		public override void Flush() {
			if( this.InputDone() ) {
				this.CompressAndSendCache();
			}
		}

		private bool InputDone() {
			if( this.cache.Length < 4L ) {
				return false;
			}
			byte[] buffer = this.cache.GetBuffer();
			int num = ( buffer[ 0 ] + ( buffer[ 1 ] << 8 ) ) + ( buffer[ 2 ] << 0x10 );
			if( this.cache.Length < ( num + 4 ) ) {
				return false;
			}
			return true;
		}

		private void PrepareNextPacket() {
			byte num = (byte)this.baseStream.ReadByte();
			byte num2 = (byte)this.baseStream.ReadByte();
			byte num3 = (byte)this.baseStream.ReadByte();
			int len = ( num + ( num2 << 8 ) ) + ( num3 << 0x10 );
			this.baseStream.ReadByte();
			int num5 = ( this.baseStream.ReadByte() + ( this.baseStream.ReadByte() << 8 ) ) + ( this.baseStream.ReadByte() << 0x10 );
			if( num5 == 0 ) {
				num5 = len;
				this.zInStream = null;
			} else {
				this.ReadNextPacket( len );
				MemoryStream stream = new MemoryStream( this.inBuffer );
				this.zInStream = new ZInputStream( stream );
				this.zInStream.maxInput = len;
			}
			this.inPos = 0;
			this.maxInPos = num5;
		}

		public override int Read( byte[] buffer, int offset, int count ) {
			int num2;
			if( buffer == null ) {
				throw new ArgumentNullException( "buffer", Resources.BufferCannotBeNull );
			}
			if( ( offset < 0 ) || ( offset >= buffer.Length ) ) {
				throw new ArgumentOutOfRangeException( "offset", Resources.OffsetMustBeValid );
			}
			if( ( offset + count ) > buffer.Length ) {
				throw new ArgumentException( Resources.BufferNotLargeEnough, "buffer" );
			}
			if( this.inPos == this.maxInPos ) {
				this.PrepareNextPacket();
			}
			int len = Math.Min( count, this.maxInPos - this.inPos );
			if( this.zInStream != null ) {
				num2 = this.zInStream.read( buffer, offset, len );
			} else {
				num2 = this.baseStream.Read( buffer, offset, len );
			}
			this.inPos += num2;
			if( this.inPos == this.maxInPos ) {
				this.zInStream = null;
				this.inBufferRef.Target = this.inBuffer;
				this.inBuffer = null;
			}
			return num2;
		}

		public override int ReadByte() {
			this.Read( this.localByte, 0, 1 );
			return this.localByte[ 0 ];
		}

		private void ReadNextPacket( int len ) {
			int num3;
			this.inBuffer = (byte[])this.inBufferRef.Target;
			if( ( this.inBuffer == null ) || ( this.inBuffer.Length < len ) ) {
				this.inBuffer = new byte[ len ];
			}
			int offset = 0;
			for( int i = len; i > 0; i -= num3 ) {
				num3 = this.baseStream.Read( this.inBuffer, offset, i );
				offset += num3;
			}
		}

		public override long Seek( long offset, SeekOrigin origin ) {
			return this.baseStream.Seek( offset, origin );
		}

		public override void SetLength( long value ) {
			throw new NotSupportedException( Resources.CSNoSetLength );
		}

		public override void Write( byte[] buffer, int offset, int count ) {
			this.cache.Write( buffer, offset, count );
		}

		public override void WriteByte( byte value ) {
			this.cache.WriteByte( value );
		}

		public override bool CanRead {
			get { return this.baseStream.CanRead; }
		}

		public override bool CanSeek {
			get { return this.baseStream.CanSeek; }
		}

		public override bool CanWrite {
			get { return this.baseStream.CanWrite; }
		}

		public override long Length {
			get { return this.baseStream.Length; }
		}

		public override long Position {
			get { return this.baseStream.Position; }
			set { this.baseStream.Position = value; }
		}
	}
}

