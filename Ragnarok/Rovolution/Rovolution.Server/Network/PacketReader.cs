using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rovolution.Server.Network {

	public class PacketReader {
		private byte[] mData;
		private int mSize;
		private int mIndex;

		public byte[] Buf {
			get { return mData; }
		}

		public int Size {
			get { return mSize; }
		}


		public PacketReader( byte[] data, int size, int startIndex ) {
			mData = data;
			mSize = size;
			mIndex = startIndex;
		}


		public int Seek( int offset, SeekOrigin origin ) {
			switch( origin ) {
				case SeekOrigin.Begin:
					mIndex = offset;
					break;
				case SeekOrigin.Current:
					mIndex += offset;
					break;
				case SeekOrigin.End:
					mIndex = mSize - offset;
					break;
			}

			return mIndex;
		}


		public bool IsSafeChar( int c ) {
			return ( c >= 32 && c < 65534 ); // #TODO# rly need this range? [replace <int c> with <byte c> if not]
		}



		public int ReadInt32() {
			if( ( mIndex + 4 ) > mSize )
				return 0;
			return ( mData[ mIndex++ ] << 24 ) | ( mData[ mIndex++ ] << 16 ) | ( mData[ mIndex++ ] << 8 ) | mData[ mIndex++ ];
		}

		public short ReadInt16() {
			if( ( mIndex + 2 ) > mSize )
				return 0;
			return (short)( ( mData[ mIndex++ ] << 8 ) | mData[ mIndex++ ] );
		}

		public byte ReadByte() {
			if( ( mIndex + 1 ) > mSize )
				return 0;
			return mData[ mIndex++ ];
		}

		public uint ReadUInt32() {
			if( ( mIndex + 4 ) > mSize )
				return 0;
			return (uint)( ( mData[ mIndex++ ] << 24 ) | ( mData[ mIndex++ ] << 16 ) | ( mData[ mIndex++ ] << 8 ) | mData[ mIndex++ ] );
		}

		public ushort ReadUInt16() {
			if( ( mIndex + 2 ) > mSize )
				return 0;
			return (ushort)( ( mData[ mIndex++ ] << 8 ) | mData[ mIndex++ ] );
		}

		public sbyte ReadSByte() {
			if( ( mIndex + 1 ) > mSize )
				return 0;
			return (sbyte)mData[ mIndex++ ];
		}

		public bool ReadBoolean() {
			if( ( mIndex + 1 ) > mSize )
				return false;
			return ( mData[ mIndex++ ] > 0 );
		}



		public string ReadString() {
			StringBuilder sb = new StringBuilder();
			int c;
			while( mIndex < mSize && ( c = mData[ mIndex++ ] ) > 0 )
				sb.Append( (char)c );

			return sb.ToString();
		}

		public string ReadStringSafe() {
			StringBuilder sb = new StringBuilder();
			int c;
			while( mIndex < mSize && ( c = mData[ mIndex++ ] ) > 0 ) 
				if( IsSafeChar( c ) )
					sb.Append( (char)c );

			return sb.ToString();
		}

		public string ReadString( int fixedLength ) {
			int bound = mIndex + fixedLength;
			int end = bound;
			if( bound > mSize )
				bound = mSize;

			StringBuilder sb = new StringBuilder();
			int c;
			while( mIndex < bound && ( c = mData[ mIndex++ ] ) > 0 )
				sb.Append( (char)c );

			mIndex = end;
			return sb.ToString();
		}

		public string ReadStringSafe( int fixedLength ) {
			int bound = mIndex + fixedLength;
			int end = bound;
			if( bound > mSize )
				bound = mSize;

			StringBuilder sb = new StringBuilder();
			int c;
			while( mIndex < bound && ( c = mData[ mIndex++ ] ) > 0 ) 
				if( IsSafeChar( c ) )
					sb.Append( (char)c );

			mIndex = end;
			return sb.ToString();
		}


	}

}
