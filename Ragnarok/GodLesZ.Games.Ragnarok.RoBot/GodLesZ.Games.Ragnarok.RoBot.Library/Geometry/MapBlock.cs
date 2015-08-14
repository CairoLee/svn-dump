using GodLesZ.Games.Ragnarok.RoBot.Library.Objects;
using Rovolution.Server.Geometry;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Geometry {

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
