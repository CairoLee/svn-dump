using GodLesZ.Library.Xna.Geometry;

namespace FreeWorld.Engine.TileEngine {

	/// <summary>
	/// A grid cell of a 2D grid map.
	/// </summary>
	public interface ITileCell {

		/// <summary>
		/// X coordinate in 2d grid space (cell index)
		/// </summary>
		int X { get; }

		/// <summary>
		/// Y coordinate in 2d grid space (cell index)
		/// </summary>
		int Y { get; }

		/// <summary>
		/// Weight of this cell. Standard value should be 0.
		/// Can be higher to account for difficult terrain or
		/// occupied cells. To make sure the cell won't be 
		/// part of a path the weight should be very high
		/// compared to the standard or usual weights used.
		/// </summary>
		int Weight { get; }

		/// <summary>
		/// Determines whether the point p corresponds to
		/// this cell, that is its X and Y coordinates are equal
		/// to the cell coordinates X and Y.
		/// </summary>
		/// <param name="p">A point of grid coordinates</param>
		/// <returns>True if the cell matches the given coordinates</returns>
		bool Matches(Point2D p);

	}

}
