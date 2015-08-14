
namespace GodLesZ.Library.Pcap {
	/// <summary>
	/// Helper class/method to retrieve the version of the GodLesZ.Library.Pcap assembly
	/// </summary>
	public sealed class Version {
		Version() { }

		/// <summary>
		/// Returns the current version string of the GodLesZ.Library.Pcap library
		/// </summary>
		/// <returns>the current version string of the GodLesZ.Library.Pcap library</returns>
		public static string VersionString {
			get {
				System.Reflection.Assembly asm
					= System.Reflection.Assembly.GetAssembly(typeof(GodLesZ.Library.Pcap.Version));
				return asm.GetName().Version.ToString();
			}
		}
	}
}
