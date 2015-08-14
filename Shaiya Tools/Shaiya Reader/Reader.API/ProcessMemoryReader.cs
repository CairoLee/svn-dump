using System;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

namespace Shaiya.Reader.API.ProcessMemoryReaderLib {

	public class ProcessMemoryReader {
		private IntPtr mhProcess = IntPtr.Zero;
		private Process mReadProcess;
		private long mPointerAddress;


		public Process ReadProcess {
			get { return this.mReadProcess; }
			set { this.mReadProcess = value; }
		}



		public void CloseHandle() {
			if( ProcessMemoryReaderApi.CloseHandle( this.mhProcess ) == 0 )
				throw new Exception( "CloseHandle failed" );
		}

		public void loadPointer( long address ) {
			IntPtr ptr;
			byte[] buffer = new byte[ 8 ];
			bool retVal = ProcessMemoryReaderApi.ReadProcessMemory( this.mhProcess, (IntPtr)address, buffer, 8, out ptr );
			this.mPointerAddress = BitConverter.ToInt64( buffer, 0 );
		}

		public bool OpenProcess() {
			// Vista? ><
			if( System.Environment.OSVersion.Version.Major >= 6 ) {
				try {
					System.Diagnostics.Process.EnterDebugMode();
				} catch( Exception e ) {
					System.Windows.Forms.MessageBox.Show( "Fehler beim EnterDebugMode()!\nBitte GodLesZ melden.\n\n" + e.ToString(), "Fehler", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
					return false;
				}
			}
			this.mhProcess = ProcessMemoryReaderApi.OpenProcess( ProcessMemoryReaderApi.PROCESS_VM_READ, 1, (uint)this.mReadProcess.Id );
			return this.mhProcess != IntPtr.Zero;
		}



		public byte[] readMemoryBuffer( long Address, long offset ) {
			IntPtr ptr;
			byte[] buffer = new byte[ 10 ];
			if( ProcessMemoryReaderApi.ReadProcessMemory( this.mhProcess, (IntPtr)( Address + offset ), buffer, 8, out ptr ) == false )
				return new byte[ 0 ];

			return buffer;
		}

		#region ReadLong
		public long readMemoryLong( long offset ) {
			byte[] buf = readMemoryBuffer( this.mPointerAddress, offset );
			if( buf.Length == 0 )
				return -1L;
			return BitConverter.ToInt64( buf, 0 );
		}

		public long readMemoryLong( Constants.EOffsets Offset ) {
			return readMemoryLong( (long)Offset );
		}

		public long readMemoryLong( Constants.EAddress Address ) {
			byte[] buf = readMemoryBuffer( (long)Address, 0 );
			if( buf.Length == 0 )
				return -1L;
			return BitConverter.ToInt64( buf, 0 );
		}
		#endregion

		#region ReadFloat
		public float readMemoryFloat( long offset ) {
			byte[] buf = readMemoryBuffer( this.mPointerAddress, offset );
			if( buf.Length == 0 )
				return -1f;
			return BitConverter.ToSingle( buf, 0 );
		}

		public float readMemoryFloat( Constants.EOffsets Offset ) {
			return readMemoryFloat( (long)Offset );
		}

		public float readMemoryFloat( Constants.EAddress Address ) {
			byte[] buf = readMemoryBuffer( (long)Address, 0 );
			if( buf.Length == 0 )
				return -1f;
			return BitConverter.ToSingle( buf, 0 );
		}
		#endregion

		#region ReadInt32
		public Int32 readMemoryInt32( long offset ) {
			byte[] buf = readMemoryBuffer( this.mPointerAddress, offset );
			if( buf.Length == 0 )
				return -1;
			return BitConverter.ToInt32( buf, 0 );
		}

		public Int32 readMemoryInt32( Constants.EOffsets Offset ) {
			return readMemoryInt32( (long)Offset );
		}

		public Int32 readMemoryInt32( Constants.EAddress Address ) {
			byte[] buf = readMemoryBuffer( (long)Address, 0 );
			if( buf.Length == 0 )
				return -1;
			return BitConverter.ToInt32( buf, 0 );
		}
		#endregion

		#region ReadInt16
		public Int16 readMemoryInt16( long offset ) {
			byte[] buf = readMemoryBuffer( this.mPointerAddress, offset );
			if( buf.Length == 0 )
				return -1;
			return BitConverter.ToInt16( buf, 0 );
		}

		public Int16 readMemoryInt16( Constants.EOffsets Offset ) {
			return readMemoryInt16( (long)Offset );
		}

		public Int16 readMemoryInt16( Constants.EAddress Address ) {
			byte[] buf = readMemoryBuffer( (long)Address, 0 );
			if( buf.Length == 0 )
				return -1;
			return BitConverter.ToInt16( buf, 0 );
		}
		#endregion

		#region ReadString
		public string readMemoryString( long address, int len ) {
			IntPtr ptr;
			byte[] buffer = new byte[ len ];
			string returnString = "";

			ProcessMemoryReaderApi.ReadProcessMemory( this.mhProcess, (IntPtr)address, buffer, (uint)len, out ptr );
			for( int i = 0; i < buffer.Length; i++ ) {
				if( buffer[ i ] == '\0' )
					break;

				returnString += (char)buffer[ i ];
			}

			return returnString;
		}

		public string readMemoryString( Constants.EOffsets Offset, int len ) {
			return readMemoryString( this.mPointerAddress + (long)Offset, len );
		}

		public string readMemoryString( Constants.EAddress Address, int len ) {
			return readMemoryString( (long)Address, len );
		}
		#endregion



		public void writeMemoryLong( IntPtr address, byte[] towrite ) {
			int num;
			ProcessMemoryReaderApi.WriteProcessMemory( this.mhProcess, address, towrite, 8, out num );
		}

		public void writeMemoryLong( long offset, byte[] towrite ) {
			writeMemoryLong( (IntPtr)( this.mPointerAddress + offset ), towrite );
		}

		public void writeMemoryLong( long adress, long offset, byte[] towrite ) {
			writeMemoryLong( (IntPtr)( adress + offset ), towrite );
		}



		public void SwitchToProcWindow() {
			ProcessMemoryReaderApi.ShowWindow( this.mhProcess, 1 );
		}




		public static T Parse<T>( string sourceValue ) where T : IConvertible {
			return (T)Convert.ChangeType( sourceValue, typeof( T ) );
		}




	}

}

