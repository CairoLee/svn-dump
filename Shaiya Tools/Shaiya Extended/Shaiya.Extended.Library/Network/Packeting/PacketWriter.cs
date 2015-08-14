using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Library.Network {

	public class PacketWriter {
		private static Stack<PacketWriter> mPool = new Stack<PacketWriter>();

		private MemoryStream mStream;
		private int mCapacity;
		private static byte[] mBuffer = new byte[ 4 ];


		public long Length {
			get { return mStream.Length; }
		}

		public long Position {
			get { return mStream.Position; }
			set { mStream.Position = value; }
		}

		public MemoryStream BaseStream {
			get { return mStream; }
		}



		public PacketWriter()
			: this( 32 ) {
		}


		public PacketWriter( int capacity ) {
			mStream = new MemoryStream( capacity );
			mCapacity = capacity;
		}



		public static PacketWriter CreateInstance() {
			return CreateInstance( 32 );
		}

		public static PacketWriter CreateInstance( int capacity ) {
			PacketWriter pw = null;

			lock( mPool ) {
				if( mPool.Count > 0 ) {
					pw = mPool.Pop();

					if( pw != null ) {
						pw.mCapacity = capacity;
						pw.mStream.SetLength( 0 );
					}
				}
			}

			if( pw == null )
				pw = new PacketWriter( capacity );

			return pw;
		}

		public static void ReleaseInstance( PacketWriter pw ) {
			lock( mPool ) {
				if( !mPool.Contains( pw ) ) {
					mPool.Push( pw );
				} else {
					try {
						//#TODO# move to global Logger
						using( StreamWriter op = new StreamWriter( "neterr.log" ) ) {
							op.WriteLine( "{0}\tInstance pool contains writer", DateTime.Now );
						}
					} catch {
						CConsole.ErrorLine( "Error on Logging PacketWriter.ReleaseInstance() Error" );
					}
				}
			}
		}


		public void Write( bool value ) {
			mStream.WriteByte( (byte)( value ? 1 : 0 ) );
		}

		public void Write( byte value ) {
			mStream.WriteByte( value );
		}

		public void Write( sbyte value ) {
			mStream.WriteByte( (byte)value );
		}

		public void Write( short value ) {
			mBuffer[ 0 ] = (byte)( value >> 8 );
			mBuffer[ 1 ] = (byte)value;

			mStream.Write( mBuffer, 0, 2 );
		}

		public void Write( ushort value ) {
			mBuffer[ 0 ] = (byte)( value >> 8 );
			mBuffer[ 1 ] = (byte)value;

			mStream.Write( mBuffer, 0, 2 );
		}

		public void Write( int value ) {
			mBuffer[ 0 ] = (byte)( value >> 24 );
			mBuffer[ 1 ] = (byte)( value >> 16 );
			mBuffer[ 2 ] = (byte)( value >> 8 );
			mBuffer[ 3 ] = (byte)value;

			mStream.Write( mBuffer, 0, 4 );
		}

		public void Write( uint value ) {
			mBuffer[ 0 ] = (byte)( value >> 24 );
			mBuffer[ 1 ] = (byte)( value >> 16 );
			mBuffer[ 2 ] = (byte)( value >> 8 );
			mBuffer[ 3 ] = (byte)value;

			mStream.Write( mBuffer, 0, 4 );
		}

		public void Write( byte[] buffer, int offset, int size ) {
			mStream.Write( buffer, offset, size );
		}

		public void Write( string Text ) {
			Write( Text, Text.Length );
		}

		public void Write( string Text, int size ) {
			int length = Text.Length;

			mStream.SetLength( mStream.Length + size );

			if( length >= size )
				mStream.Position += Encoding.ASCII.GetBytes( Text, 0, size, mStream.GetBuffer(), (int)mStream.Position );
			else {
				Encoding.ASCII.GetBytes( Text, 0, length, mStream.GetBuffer(), (int)mStream.Position );
				mStream.Position += size;
			}
		}


		public void Fill() {
			Fill( (int)( mCapacity - mStream.Length ) );
		}

		public void Fill( int length ) {
			if( mStream.Position == mStream.Length ) {
				mStream.SetLength( mStream.Length + length );
				mStream.Seek( 0, SeekOrigin.End );
			} else {
				mStream.Write( new byte[ length ], 0, length );
			}
		}



		public long Seek( long offset, SeekOrigin origin ) {
			return mStream.Seek( offset, origin );
		}

		public byte[] ToArray() {
			return mStream.ToArray();
		}


	}

}
