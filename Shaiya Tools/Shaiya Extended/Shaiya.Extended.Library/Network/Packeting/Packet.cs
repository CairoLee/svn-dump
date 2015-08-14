using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Library.Network {

	[Flags()]
	public enum PacketState {
		Inactive = 0x00,
		Static = 0x01,
		Acquired = 0x02,
		Accessed = 0x04,
		Buffered = 0x08,
		Warned = 0x10
	}

	public abstract class Packet {

		private const int BufferSize = 4096;
		private static BufferPool mBuffers = new BufferPool( "Compressed", 16, BufferSize );

		protected PacketWriter mStream;
		private int mPacketID;
		private int mLength;
		private PacketState mState;
		private byte[] mCompiledBuffer;
		private int mCompiledLength;

		public int PacketID {
			get { return mPacketID; }
		}

		public PacketWriter BaseStream {
			get { return mStream; }
		}


		public Packet( int packetID )
			: this( packetID, 0 ) {
		}

		public Packet( int packetID, int packetLength ) {
			mPacketID = packetID;
			mLength = packetLength;

			mStream = PacketWriter.CreateInstance();
			mStream.Write( (short)mPacketID );
			mStream.Write( mLength );

			PacketSendProfile prof = PacketSendProfile.Acquire( GetType() );
			if( prof != null )
				prof.Created++;
		}


		public void EnsureCapacity( int length ) {
			mStream = PacketWriter.CreateInstance( length );
			mStream.Write( (short)mPacketID );
		}


		public static Packet SetStatic( Packet p ) {
			p.SetStatic();
			return p;
		}

		public static Packet Acquire( Packet p ) {
			p.Acquire();
			return p;
		}

		public static void Release( ref Packet p ) {
			if( p != null )
				p.Release();

			p = null;
		}

		public static void Release( Packet p ) {
			if( p != null )
				p.Release();
		}

		public void SetStatic() {
			mState |= PacketState.Static | PacketState.Acquired;
		}

		public void Acquire() {
			mState |= PacketState.Acquired;
		}

		public void OnSend() {
			if( ( mState & ( PacketState.Acquired | PacketState.Static ) ) == 0 )
				Free();
		}

		private void Free() {
			if( mCompiledBuffer == null )
				return;

			if( ( mState & PacketState.Buffered ) != 0 )
				mBuffers.ReleaseBuffer( mCompiledBuffer );

			mState &= ~( PacketState.Static | PacketState.Acquired | PacketState.Buffered );

			mCompiledBuffer = null;
		}

		public void Release() {
			if( ( mState & PacketState.Acquired ) != 0 )
				Free();
		}


		public byte[] Compile( out int length ) {
			if( mCompiledBuffer == null ) {
				if( ( mState & PacketState.Accessed ) == 0 ) {
					mState |= PacketState.Accessed;
				} else {
					if( ( mState & PacketState.Warned ) == 0 ) {
						mState |= PacketState.Warned;

						try {
							using( StreamWriter op = new StreamWriter( "net_opt.log", true ) ) {
								op.WriteLine( "Redundant compile for packet {0}, use Acquire() and Release()", this.GetType() );
								op.WriteLine( new System.Diagnostics.StackTrace() );
							}
						} catch { }
					}

					mCompiledBuffer = new byte[ 0 ];
					mCompiledLength = 0;

					length = mCompiledLength;
					return mCompiledBuffer;
				}

				InternalCompile();
			}

			length = mCompiledLength;
			return mCompiledBuffer;
		}

		private void InternalCompile() {
			if( mLength == 0 )
				mLength = (int)mStream.Length;

			if( mStream.Length != mLength ) {
				int diff = (int)mStream.Length - mLength;
				CConsole.ErrorLine( "Packet {0:X4}: Bad packet length! ({1}{2} bytes)", mPacketID, diff >= 0 ? "+" : "", diff );
			}

			mStream.Seek( 2, SeekOrigin.Begin );
			mStream.Write( mLength );

			MemoryStream ms = mStream.BaseStream;
			mCompiledBuffer = ms.GetBuffer();
			mCompiledLength = (int)ms.Length;

			PacketWriter.ReleaseInstance( mStream );
			mStream = null;
		}

	}

}
