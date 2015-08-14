using System.Collections.Generic;
using System.Xml.Serialization;

namespace FinalSoftware.Games.Defender.Library.Map {

	[XmlRoot(ElementName = "Crossroads")]
	public class CrossroadList : List<Crossroad> {

		public int PathCount {
			get { return GetPathCount(); }
		}


		public CrossroadList()
			: base() {
		}

		public CrossroadList(params Crossroad[] roads)
			: base() {
			AddRange(roads);
		}


		public int GetPathCount() {
			int paths = 0;
			for (int i = 0; i < Count; i++)
				for (int j = 0; j < this[i].Connections.Count; j++)
					paths++;

			return paths;
		}

	}

}
