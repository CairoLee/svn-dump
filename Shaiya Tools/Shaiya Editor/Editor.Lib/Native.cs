using System;
using System.Runtime.InteropServices;

namespace Editor.Lib {

	public class Native {
		[DllImport( "winmm.dll" )]
		public static extern bool PlaySound( ref byte snd, IntPtr hmod, uint fdwSound );
		[DllImport( "winmm.dll" )]
		public static extern int PlaySound( string lpszName, int hModule, int dwFlags );
		[DllImport( "winmm" )]
		public static extern bool PlaySound( string szSound, IntPtr hMod, PlaySoundFlags flags );

		public enum PlayingFlags : uint {
			SND_ALIAS = 0x10000,
			SND_ALIAS_ID = 0x110000,
			SND_ALIAS_START = 0,
			SND_ASYNC = 1,
			SND_FILENAME = 0x20000,
			SND_LOOP = 8,
			SND_MEMORY = 4,
			SND_NODEFAULT = 2,
			SND_NOSTOP = 0x10,
			SND_NOWAIT = 0x2000,
			SND_PURGE = 0x40,
			SND_RESOURCE = 0x40004,
			SND_SYNC = 0,
			SND_VALID = 0x1f
		}

		[Flags]
		public enum PlaySoundFlags {
			SND_ALIAS = 0x10000,
			SND_ALIAS_ID = 0x110000,
			SND_ASYNC = 1,
			SND_FILENAME = 0x20000,
			SND_LOOP = 8,
			SND_MEMORY = 4,
			SND_NODEFAULT = 2,
			SND_NOSTOP = 0x10,
			SND_NOWAIT = 0x2000,
			SND_RESOURCE = 0x40004,
			SND_SYNC = 0
		}

	}

}
