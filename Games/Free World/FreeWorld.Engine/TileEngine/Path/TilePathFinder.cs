using System.Collections.Generic;
using GodLesZ.Library;
using GodLesZ.Library.Xna.Geometry;

namespace FreeWorld.Engine.TileEngine.Path {

	/// <summary>
	/// An A* implementation for finding paths on a 2D map.
	/// </summary>
	public class TilePathFinder {
		/// <summary>
		/// Maximum number of steps allowed to find a path.
		/// The more steps allowed the longer the process 
		/// can take. When the step limit is reached the
		/// search is aborted.
		/// </summary>
		private readonly int mStepLimit;

		/// <summary>
		/// The grid map giving information about the 2D grid.
		/// </summary>
		private readonly TileLayer mLayer;

		/// <summary>
		/// The collision layer giving informations about walkable cells.
		/// </summary>
		private readonly TileCollisionLayer mCollisionLayer;

		/// <summary>
		/// List containing known paths
		/// </summary>
		private readonly Dictionary<TilePathRequest, TilePath> mPathCache = new Dictionary<TilePathRequest, TilePath>();


		/// <summary>
		/// Creates a new Path finder for the specified stragic map.
		/// </summary>
		/// <param name="layer">A strategic layer</param>
		/// <param name="collisionLayer">A collision layer</param>
		/// <param name="stepLimit">Maximum number of steps to find a path</param>
		public TilePathFinder(TileLayer layer, TileCollisionLayer collisionLayer, int stepLimit) {
			mLayer = layer;
			mCollisionLayer = collisionLayer;
			mStepLimit = stepLimit;
		}

		/// <summary>
		/// Creates a new Path finder for the specified stragic layer.
		/// Sets the step limit to 140 steps by default, which is only suitable for
		/// relatively short paths (depending on the grid size).
		/// </summary>
		/// <param name="layer">A strategic layer</param>
		/// <param name="collisionLayer">A collision layer</param>
		public TilePathFinder(TileLayer layer, TileCollisionLayer collisionLayer)
			: this(layer, collisionLayer, 140) {
		}

		/// <summary>
		/// Creates a new Path finder for the first layer of the specified stragic map.
		/// Sets the step limit to 140 steps by default, which is only suitable for
		/// relatively short paths (depending on the grid size).
		/// </summary>
		/// <param name="map">A strategic map</param>
		public TilePathFinder(TileMap map)
			: this(map.Layers[0], map.CollisionLayer) {
		}


		/// <summary>
		/// Calculates a path from start to end. When no path can be found in
		/// reasonable time the search is aborted and an incomplete path is returned. 
		/// When refresh is not set to true a cached path is returned where possible.
		/// </summary>
		/// <param name="start">start position in 2d map space</param>
		/// <param name="end">end position in 2d map space</param>
		/// <param name="refresh">force to recalculate the path</param>
		/// <returns></returns>
		public TilePath CalculatePath(ITileCell start, ITileCell end, bool refresh) {
			return CalculatePath(new Point2D(start.X, start.Y), new Point2D(end.X, end.Y), refresh);
		}

		/// <summary>
		/// Calculates a path from start to end. When no path can be found in
		/// reasonable time the search is aborted and an incomplete path is returned. 
		/// When refresh is not set to true a cached path is returned where possible.
		/// </summary>
		/// <param name="start">start position in 2d map space</param>
		/// <param name="end">end position in 2d map space</param>
		/// <param name="refresh">force to recalculate the path</param>
		/// <returns></returns>
		public TilePath CalculatePath(Point2D start, Point2D end, bool refresh) {
			// swap points to calculate the path backwards (from end to start)
			Point2D temp = end;
			end = start;
			start = temp;

			// Check whether the requested path is already known
			var request = new TilePathRequest(start, end);
			if (!refresh && mPathCache.ContainsKey(request)) {
				return mPathCache[request].Copy();
			}

			// priority queue of nodes that yet have to be explored sorted in 
			// ascending order by node costs (F)
			var open = new AutoPriorityQueue<TilePathNode>();

			// List of nodes that have already been explored
			var closed = new LinkedList<ITileCell>();

			// Start is to be explored first
			var startNode = new TilePathNode(null, mLayer.GetCell(start), end);
			open.Enqueue(startNode);

			var steps = 0;

			do {
				// Examine the cheapest node among the yet to be explored
				var current = open.Dequeue();

				// Finish?
				if (current.Cell.Matches(end) || ++steps > mStepLimit) {
					// Paths which lead to the requested goal are cached for reuse
					var path = new TilePath(current);

					if (mPathCache.ContainsKey(request)) {
						mPathCache[request] = path.Copy();
					} else {
						mPathCache.Add(request, path.Copy());
					}

					return path;
				}

				// Explore all neighbours of the current cell
				var neighbours = mLayer.GetNeighbourCells(current.Cell);

				foreach (var cell in neighbours) {
					// Discard nodes that are not of interest
					var flag = mCollisionLayer[cell.X, cell.Y];
					if (closed.Contains(cell) || (cell.Matches(end) == false && (flag & ECollisionType.NotMoveable) != ECollisionType.NotMoveable)) {
						continue;
					}

					// Successor is one of current's neighbours
					var successor = new TilePathNode(current, cell, end);
					var contained = open.Find(successor);

					if (contained != null && successor.CostTotal >= contained.CostTotal) {
						// This cell is already in the open list represented by
						// another node that is cheaper
						continue;
					}
					if (contained != null && successor.CostTotal < contained.CostTotal) {
						// This cell is already in the open list but on a more expensive
						// path -> "integrate" the node into the current path
						contained.Predecessor = current;
						contained.Update();
						open.Update(contained);
					} else {
						// The cell is not in the open list and therefore still has to
						// be explored
						open.Enqueue(successor);
					}
				}

				// Add current to the list of the already explored nodes
				closed.AddLast(current.Cell);

			} while (open.Peek() != null);

			return null;
		}

	}

}
