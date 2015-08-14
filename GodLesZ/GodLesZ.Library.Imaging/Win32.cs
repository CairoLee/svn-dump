namespace GodLesZ.Library.Imaging {
	using System;
	using System.Runtime.InteropServices;

	internal class Win32 {
		[DllImport("ntdll.dll")]
		public static extern IntPtr memcpy(IntPtr dst, IntPtr src, int count);
		[DllImport("ntdll.dll")]
		public static extern unsafe byte* memcpy(byte* dst, byte* src, int count);
		[DllImport("ntdll.dll")]
		public static extern IntPtr memset(IntPtr dst, int filler, int count);
	}
}

