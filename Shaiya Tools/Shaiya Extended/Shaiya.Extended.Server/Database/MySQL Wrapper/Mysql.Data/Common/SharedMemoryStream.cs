namespace Shaiya.Extended.Server.MySql.Data.Common {
	using Microsoft.Win32.SafeHandles;
	using Shaiya.Extended.Server.MySql.Data.MySqlClient;
	using System;
	using System.IO;
	using System.Runtime.InteropServices;
	using System.Threading;

	internal class SharedMemoryStream : Stream {
		private const int BUFFERLENGTH = 0x3e84;
		private int bytesLeft;
		private AutoResetEvent clientRead;
		private AutoResetEvent clientWrote;
		private int connectNumber;
		private IntPtr dataMap;
		private IntPtr dataView;
		private const uint EVENT_MODIFY_STATE = 2;
		private const uint FILE_MAP_WRITE = 2;
		private string memoryName;
		private int position;
		private AutoResetEvent serverRead;
		private AutoResetEvent serverWrote;
		private const uint SYNCHRONIZE = 0x100000;

		public override bool CanRead {
			get { return true; }
		}

		public override bool CanSeek {
			get { return false; }
		}

		public override bool CanWrite {
			get { return true; }
		}

		public override long Length {
			get { throw new NotSupportedException( "SharedMemoryStream does not support seeking - length" ); }
		}

		public override long Position {
			get { throw new NotSupportedException( "SharedMemoryStream does not support seeking - postition" ); }
			set { }
		}


		public SharedMemoryStream( string memName ) {
			this.memoryName = memName;
		}


		public override void Close() {
			UnmapViewOfFile( this.dataView );
			CloseHandle( this.dataMap );
		}

		[DllImport( "kernel32.dll", SetLastError = true )]
		private static extern int CloseHandle( IntPtr hObject );
		public override void Flush() {
			FlushViewOfFile( this.dataView, 0 );
		}

		[DllImport( "kernel32.dll", SetLastError = true )]
		private static extern int FlushViewOfFile( IntPtr address, uint numBytes );
		private void GetConnectNumber( uint timeOut ) {
			AutoResetEvent event2 = new AutoResetEvent( false );
			IntPtr existingHandle = OpenEvent( 0x100002, false, this.memoryName + "_CONNECT_REQUEST" );
			event2.SafeWaitHandle = new SafeWaitHandle( existingHandle, true );
			AutoResetEvent event3 = new AutoResetEvent( false );
			existingHandle = OpenEvent( 0x100002, false, this.memoryName + "_CONNECT_ANSWER" );
			event3.SafeWaitHandle = new SafeWaitHandle( existingHandle, true );
			IntPtr ptr = MapViewOfFile( OpenFileMapping( 2, false, this.memoryName + "_CONNECT_DATA" ), 2, 0, 0, (IntPtr)4 );
			if( !event2.Set() ) {
				throw new MySqlException( "Failed to open shared memory connection" );
			}
			event3.WaitOne( (int)( timeOut * 0x3e8 ), false );
			this.connectNumber = Marshal.ReadInt32( ptr );
		}

		public bool IsClosed() {
			try {
				this.dataView = MapViewOfFile( this.dataMap, 2, 0, 0, (IntPtr)0x3e84 );
				return ( this.dataView == IntPtr.Zero );
			} catch( Exception ) {
				return true;
			}
		}

		[DllImport( "kernel32.dll" )]
		private static extern IntPtr MapViewOfFile( IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, IntPtr dwNumberOfBytesToMap );
		public void Open( uint timeOut ) {
			this.GetConnectNumber( timeOut );
			this.SetupEvents();
		}

		[DllImport( "kernel32.dll" )]
		private static extern IntPtr OpenEvent( uint dwDesiredAccess, bool bInheritHandle, string lpName );
		[DllImport( "kernel32.dll" )]
		private static extern IntPtr OpenFileMapping( uint dwDesiredAccess, bool bInheritHandle, string lpName );
		public override int Read( byte[] buffer, int offset, int count ) {
			while( this.bytesLeft == 0 ) {
				while( !this.serverWrote.WaitOne( 500, false ) ) {
					if( this.IsClosed() ) {
						return 0;
					}
				}
				this.bytesLeft = Marshal.ReadInt32( this.dataView );
				this.position = 4;
			}
			int num = Math.Min( count, this.bytesLeft );
			long num2 = this.dataView.ToInt64() + this.position;
			int num3 = 0;
			while( num3 < num ) {
				buffer[ offset + num3 ] = Marshal.ReadByte( (IntPtr)( num2 + num3 ) );
				num3++;
				this.position++;
			}
			this.bytesLeft -= num;
			if( this.bytesLeft == 0 ) {
				this.clientRead.Set();
			}
			return num;
		}

		public override long Seek( long offset, SeekOrigin origin ) {
			throw new NotSupportedException( "SharedMemoryStream does not support seeking" );
		}

		public override void SetLength( long value ) {
			throw new NotSupportedException( "SharedMemoryStream does not support seeking" );
		}

		private void SetupEvents() {
			string str = this.memoryName + "_" + this.connectNumber;
			this.dataMap = OpenFileMapping( 2, false, str + "_DATA" );
			this.dataView = MapViewOfFile( this.dataMap, 2, 0, 0, (IntPtr)0x3e84 );
			this.serverWrote = new AutoResetEvent( false );
			IntPtr existingHandle = OpenEvent( 0x100002, false, str + "_SERVER_WROTE" );
			this.serverWrote.SafeWaitHandle = new SafeWaitHandle( existingHandle, true );
			this.serverRead = new AutoResetEvent( false );
			existingHandle = OpenEvent( 0x100002, false, str + "_SERVER_READ" );
			this.serverRead.SafeWaitHandle = new SafeWaitHandle( existingHandle, true );
			this.clientWrote = new AutoResetEvent( false );
			existingHandle = OpenEvent( 0x100002, false, str + "_CLIENT_WROTE" );
			this.clientWrote.SafeWaitHandle = new SafeWaitHandle( existingHandle, true );
			this.clientRead = new AutoResetEvent( false );
			existingHandle = OpenEvent( 0x100002, false, str + "_CLIENT_READ" );
			this.clientRead.SafeWaitHandle = new SafeWaitHandle( existingHandle, true );
			this.serverRead.Set();
		}

		[DllImport( "kernel32.dll" )]
		private static extern bool UnmapViewOfFile( IntPtr lpBaseAddress );
		public override void Write( byte[] buffer, int offset, int count ) {
			int num = count;
			int index = offset;
			while( num > 0 ) {
				if( !this.serverRead.WaitOne() ) {
					throw new MySqlException( "Writing to shared memory failed" );
				}
				int val = Math.Min( num, 0x3e84 );
				long num4 = this.dataView.ToInt64() + 4L;
				Marshal.WriteInt32( this.dataView, val );
				int num5 = 0;
				while( num5 < val ) {
					Marshal.WriteByte( (IntPtr)( num4 + num5 ), buffer[ index ] );
					num5++;
					index++;
				}
				num -= val;
				if( !this.clientWrote.Set() ) {
					throw new MySqlException( "Writing to shared memory failed" );
				}
			}
		}


	}

}

