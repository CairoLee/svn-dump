
using System.Collections.Generic;

namespace FreeWorld.Engine.TileEngine.Path {

	/// <summary>
	/// Representation of a path.
	/// Contains a implicitly linked list of PathNodes.
	/// </summary>
	public class TilePath {
		/// <summary>
		/// Current node
		/// </summary>
		private TilePathNode mCurrent;

		/// <summary>
		/// Original start node
		/// </summary>
		private readonly TilePathNode mStart;

		/// <summary>
		/// Returns true, if the path should be at its end
		/// </summary>
		public bool Finished {
			get { return mCurrent == null; }
		}

		/// <summary>
		/// Peeks at the next path node without removing it from the path
		/// </summary>
		public TilePathNode Next {
			get { return mCurrent; }
		}


		/// <summary>
		/// Creates a new path beginning at the specified start
		/// </summary>
		/// <param name="start">start path node</param>
		public TilePath(TilePathNode start) {
			mCurrent = start;
			mStart = start;
		}


		/// <summary>
		/// Delivers the next waypoint and moves on in the path,
		/// discarding the returned node.
		/// </summary>
		/// <returns></returns>
		public ITileCell GetNextWaypoint() {
			var next = mCurrent;
			mCurrent = mCurrent.Predecessor;
			return next.Cell;
		}

		public List<ITileCell> GetWaypoints() {
			var spots = new List<ITileCell>();
			while (Finished == false) {
				spots.Add(GetNextWaypoint());
			}
			return spots;
		}

		/// <summary>
		/// Copies this instance of the path.
		/// </summary>
		/// <returns></returns>
		public TilePath Copy() {
			var copy = new TilePath(mStart);
			return copy;
		}

	}

}
