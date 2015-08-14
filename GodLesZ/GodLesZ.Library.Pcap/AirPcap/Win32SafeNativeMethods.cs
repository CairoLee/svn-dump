using System;
using System.Runtime.InteropServices;
using System.Security;

namespace GodLesZ.Library.Pcap.AirPcap {
	[SuppressUnmanagedCodeSecurityAttribute]
	internal static class Win32SafeNativeMethods {
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		internal static extern int WaitForSingleObject(IntPtr hHandle, IntPtr dwMilliseconds);
	}
}
