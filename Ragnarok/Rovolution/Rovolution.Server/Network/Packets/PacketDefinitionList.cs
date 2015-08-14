using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rovolution.Server.Network {

	/// <summary>List of packet definitions.</summary>
	[XmlRoot("Packets")]
	public class PacketDefinitionList : List<PacketDefinition> {

	}

}
