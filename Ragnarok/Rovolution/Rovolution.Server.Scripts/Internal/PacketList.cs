using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Rovolution.Server.Scripts.Internal {
	
	[XmlRoot("PacketList")]
	public class PacketList : List<PacketDefinition> {

	}

}
