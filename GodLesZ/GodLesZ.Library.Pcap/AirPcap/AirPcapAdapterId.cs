
namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Types of airpcap adapters
	/// </summary>
	public enum AirPcapAdapterId : int {
		/// <summary>
		/// Class
		/// </summary>
		Classic = 0,

		/// <summary>
		/// Class release 2
		/// </summary>
		ClassicRelease2,

		/// <summary>
		/// AirPcap TX
		/// </summary>
		Tx,

		/// <summary>
		/// AirPcap EX
		/// </summary>
		Ex,

		/// <summary>
		/// AirPcap N
		/// </summary>
		N,

		/// <summary>
		/// AirPcap Nx
		/// </summary>
		Nx
	};
}
