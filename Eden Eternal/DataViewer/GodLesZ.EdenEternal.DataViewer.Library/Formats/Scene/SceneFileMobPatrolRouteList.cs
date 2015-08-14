using System.Collections.Generic;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats.Scene {

	public class SceneFileMobPatrolRouteList : Dictionary<int, SceneFileMobPatrolRoute> {

		public SceneFileMobPatrolRouteList()
			: base() {
		}


		public void Add(SceneFileMobPatrolRoute route) {
			Add(route.RouteID, route);
		}

	}

}