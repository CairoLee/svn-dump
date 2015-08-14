using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Geometry {

	public class MapBlock : WorldObjectList {
		private int mMapID;

		public Map ParentMap {
			get { return Mapcache.Maps[mMapID]; }
		}



		public MapBlock(int mapID) {
			mMapID = mapID;
		}


		public void AddUnit(WorldObject Unit) {
			Add(Unit.WorldID, Unit);
		}

		public void DelUnit(WorldObject Unit) {
			Remove(Unit.WorldID);
		}

	}

}
