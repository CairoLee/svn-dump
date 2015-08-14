namespace Shaiya.Extended.Server.MySql.Data.Common {
	using System;

	internal class Platform {
		private Platform() {
		}

		public static bool IsWindows() {
			switch( Environment.OSVersion.Platform ) {
				case PlatformID.Win32S:
				case PlatformID.Win32Windows:
				case PlatformID.Win32NT:
					return true;
			}
			return false;
		}
	}
}

