using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Rovolution.Server.Scripts.Internal {
	
	[XmlRoot("Packet")]
	public class PacketDefinition {
		[XmlAttribute()]
		public short ID {
			get;
			set;
		}

		[XmlAttribute()]
		public int Length {
			get;
			set;
		}

		public string HandlerType {
			get;
			set;
		}

		public string HandlerName {
			get;
			set;
		}


		public PacketDefinition() {
		}

	}

}
