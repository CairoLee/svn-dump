using System.Xml.Serialization;

namespace GodLesZ.SiedlerOnline.TradeListener.Library {

	[XmlRoot("bbmsg")]
	public class DsoChatPacketMessageDetails {
		[XmlAttribute("playertag")]
		public string PLayerTag {
			get;
			set;
		}

		[XmlAttribute("playerid")]
		public int PlayerID {
			get;
			set;
		}

		[XmlAttribute("playername")]
		public string Player {
			get;
			set;
		}

		public DsoChatPacketMessageDetails() {
		}

	}

}
