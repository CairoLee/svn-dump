using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace GodLesZ.Library.ProcessEditAPI.Inject.Native {

	/// <summary>
	/// A simplistic Win32 API wrapper class.
	/// </summary>
	public class Win32 : IDisposable {
		private readonly IntPtr mProcessHandle;

		internal Win32(uint dwDesiredAccess, int dwProcessId) {
			mProcessHandle = OpenProcess(dwDesiredAccess, true, dwProcessId);
		}

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose() {
			CloseHandle(mProcessHandle);
		}

		#endregion

		// Window states
		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr SetActiveWindow(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		[DllImport("kernel32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern uint GetCurrentThreadId();

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

		// Keyboard input
		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern uint SendInput(uint numberOfInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] INPUT[] input, int structSize);

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		public static extern short VkKeyScan(char ch);

		[DllImport("user32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		public static extern uint MapVirtualKey(uint uCode, uint uMapType);

		// Process
		[DllImport("kernel32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool FreeLibrary(IntPtr h);

		[DllImport("kernel32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		[DllImport("kernel32.dll"), SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		[DllImport("kernel32"), SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr LoadLibrary(string libraryName);

		[DllImport("kernel32", CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

		[DllImport("kernel32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool CloseHandle(IntPtr hHandle);


		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public int WriteBytes(IntPtr address, byte[] val) {
			int written;

			if (mProcessHandle == IntPtr.Zero)
				throw new Exception("There's no current process handle... are you sure you did everything right?");
			if (WriteProcessMemory(mProcessHandle, address, val, (uint)val.Length, out written))
				return written;

			throw new AccessViolationException(string.Format("Could not write the specified bytes! {0} [{1}]", address.ToString("X8"), Marshal.GetLastWin32Error()));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public byte[] ReadBytes(IntPtr address, int count) {
			int numRead;
			byte[] ret = new byte[count];
			if (mProcessHandle == IntPtr.Zero)
				throw new Exception("There's no current process handle... are you sure you did everything right?");
			if (ReadProcessMemory(mProcessHandle, address, ret, count, out numRead) && numRead == count)
				return ret;

			return null;
		}

	}


}