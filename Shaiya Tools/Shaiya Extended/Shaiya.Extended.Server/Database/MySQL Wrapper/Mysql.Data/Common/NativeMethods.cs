namespace Shaiya.Extended.Server.MySql.Data.Common {
	using System;
	using System.Runtime.InteropServices;

	internal class NativeMethods {
		public const uint FILE_FLAG_NO_BUFFERING = 0x20000000;
		public const uint FILE_FLAG_OVERLAPPED = 0x40000000;
		public const uint GENERIC_READ = 0x80000000;
		public const uint GENERIC_WRITE = 0x40000000;
		public const int INVALIDpipeHandle_VALUE = -1;
		public const uint OPEN_EXISTING = 3;

		private NativeMethods() {
		}

		[return: MarshalAs( UnmanagedType.Bool )]
		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern bool CloseHandle( IntPtr handle );
		[DllImport( "ws2_32.dll", SetLastError = true )]
		public static extern int connect( IntPtr socket, byte[] addr, int addrlen );
		[DllImport( "Kernel32" )]
		public static extern int CreateFile( string fileName, uint desiredAccess, uint shareMode, SecurityAttributes securityAttributes, uint creationDisposition, uint flagsAndAttributes, uint templateFile );
		[return: MarshalAs( UnmanagedType.Bool )]
		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern bool FlushFileBuffers( IntPtr handle );
		[DllImport( "ws2_32.dll", SetLastError = true )]
		public static extern int ioctlsocket( IntPtr socket, uint cmd, ref uint arg );
		[return: MarshalAs( UnmanagedType.Bool )]
		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern bool PeekNamedPipe( IntPtr handle, byte[] buffer, uint nBufferSize, ref uint bytesRead, ref uint bytesAvail, ref uint BytesLeftThisMessage );
		[return: MarshalAs( UnmanagedType.Bool )]
		[DllImport( "kernel32.dll", SetLastError = true )]
		internal static extern bool ReadFile( IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped );
		[DllImport( "ws2_32.dll", SetLastError = true )]
		public static extern int recv( IntPtr socket, byte[] buff, int len, int flags );
		[DllImport( "ws2_32.Dll", SetLastError = true )]
		public static extern int send( IntPtr socket, byte[] buff, int len, int flags );
		[DllImport( "ws2_32.dll", SetLastError = true )]
		public static extern IntPtr socket( int af, int type, int protocol );
		[return: MarshalAs( UnmanagedType.Bool )]
		[DllImport( "Kernel32" )]
		internal static extern bool WriteFile( IntPtr hFile, [In] byte[] buffer, uint numberOfBytesToWrite, out uint numberOfBytesWritten, IntPtr lpOverlapped );
		[DllImport( "ws2_32.dll", SetLastError = true )]
		public static extern int WSAGetLastError();
		[DllImport( "ws2_32.dll", SetLastError = true )]
		public static extern int WSAIoctl( IntPtr s, uint dwIoControlCode, byte[] inBuffer, uint cbInBuffer, byte[] outBuffer, uint cbOutBuffer, IntPtr lpcbBytesReturned, IntPtr lpOverlapped, IntPtr lpCompletionRoutine );

		[StructLayout( LayoutKind.Sequential )]
		public class SecurityAttributes {
			public int Length = Marshal.SizeOf( typeof( NativeMethods.SecurityAttributes ) );
			public IntPtr securityDescriptor = IntPtr.Zero;
			public bool inheritHandle;
		}
	}
}

