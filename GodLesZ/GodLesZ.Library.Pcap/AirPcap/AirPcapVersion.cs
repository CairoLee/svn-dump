using System;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Version
	/// </summary>
	public class AirPcapVersion {
		/// <summary>
		/// Returns the version in separate fields
		/// </summary>
		/// <param name="Major"></param>
		/// <param name="Minor"></param>
		/// <param name="Rev"></param>
		/// <param name="Build"></param>
		/// <returns></returns>
		public static void Version(out uint Major, out uint Minor, out uint Rev, out uint Build) {
			UInt32 major, minor, rev, build;

			AirPcapSafeNativeMethods.AirpcapGetVersion(out major, out minor, out rev, out build);

			Major = (uint)major;
			Minor = (uint)minor;
			Rev = (uint)rev;
			Build = (uint)build;
		}

		/// <summary>
		/// Returns the version in a.b.c.d format
		/// </summary>
		/// <returns></returns>
		public static string VersionString() {
			uint Major, Minor, Rev, Build;
			Version(out Major, out Minor, out Rev, out Build);

			return string.Format("{0}.{1}.{2}.{3}",
								 Major,
								 Minor,
								 Rev,
								 Build);
		}
	}
}
