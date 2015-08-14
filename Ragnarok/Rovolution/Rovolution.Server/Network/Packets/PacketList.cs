using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rovolution.Server.Network {

	/// <summary>List of packet versions.</summary>
	[XmlRoot("PacketList")]
	public class PacketList : List<PacketVersion> {

	}

}
