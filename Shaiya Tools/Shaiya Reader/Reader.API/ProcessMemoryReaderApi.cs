using System;
using System.Runtime.InteropServices;

namespace Shaiya.Reader.API.ProcessMemoryReaderLib {

	internal class ProcessMemoryReaderApi {
		public const uint PROCESS_VM_READ = 0x0010;

		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern int CloseHandle( IntPtr hObject );
		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern IntPtr OpenProcess( uint dwDesiredAccess, int bInheritHandle, uint dwProcessId );
		[DllImport( "user32.dll", CharSet = CharSet.Auto )]
		public static extern int PostMessage( IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam );


		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern bool ReadProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesRead );
		[DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		public static extern uint RegisterWindowMessage( string lpString );
		[DllImport( "user32.dll", SetLastError = true )]
		public static extern bool ShowWindow( IntPtr hWnd, int nCmdShow );
		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern int WriteProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten );


    }



}

