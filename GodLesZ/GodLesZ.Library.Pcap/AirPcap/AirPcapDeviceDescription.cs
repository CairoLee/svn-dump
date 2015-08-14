
namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Adapter description
	/// </summary>
	public class AirPcapDeviceDescription {
		/// <summary>
		/// Device name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Device description
		/// </summary>
		public string Description { get; set; }

		internal AirPcapDeviceDescription(AirPcapUnmanagedStructures.AirpcapDeviceDescription desc) {
			this.Name = desc.Name;
			this.Description = desc.Description;
		}

		/// <summary>
		/// ToString() override
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public override string ToString() {
			return string.Format("Name: {0}, Description: {1}",
								 Name, Description);
		}
	}
}
