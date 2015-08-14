using GodLesZ.Library.Xna.Geometry;

namespace FreeWorld.Engine.TileEngine.Path {

	/// <summary>
	/// Description of a path request. The path request
	/// can differ from the path itself, because the exact
	/// path might not exist. The path request stores
	/// what path was requested. The actual found path
	/// is stored in a separate Path instance.
	/// </summary>
	public struct TilePathRequest {
		public Point2D Start;
		public Point2D End;


		public TilePathRequest(Point2D start, Point2D end) {
			Start = start;
			End = end;
		}


		public override bool Equals(object obj) {
			TilePathRequest other = (TilePathRequest)obj;
			return Start.Equals(other.Start) && End.Equals(other.End);
		}

		public override int GetHashCode() {
			return (Start.GetHashCode() ^ End.GetHashCode());
		}
	}

}
