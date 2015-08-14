using System;
using GodLesZ.Library.Xna.Geometry;

namespace FreeWorld.Engine.TileEngine.Path {

	/// <summary>
	/// A node in an A* calculated path. 
	/// </summary>
	public class TilePathNode : IComparable, IComparable<TilePathNode>, IEquatable<TilePathNode> {
		/// <summary>
		/// Destination coordinates in 2d map space
		/// </summary>
		private Point2D mGoal;

		/// <summary>
		/// base cost summed up for every already visited node
		/// </summary>
		public float CostVisited {
			get;
			private set;
		}

		/// <summary>
		/// cost regarding to the heuristic, estimating the left distance
		/// to the goal.
		/// </summary>
		public float CostLeftGoal {
			get;
			private set;
		}

		/// <summary>
		/// total cost of this node (CostLeftGoal + CostVisited)
		/// </summary>        
		public float CostTotal {
			get;
			private set;
		}

		/// <summary>
		/// The grid cell on the 2d map represented by this node
		/// </summary>
		public ITileCell Cell {
			get;
			private set;
		}

		/// <summary>
		/// The preceding node which lead to this node
		/// </summary>
		public TilePathNode Predecessor {
			get;
			set;
		}


		/// <summary>
		/// Creates a new path node. The cost (or weight) of this node is automatically
		/// calculated according to the predecessor, cell and goal.
		/// </summary>
		/// <param name="predecessor">preceding node</param>
		/// <param name="cell">grid cell represented by the node</param>
		/// <param name="goal">goal coordinate in 2d map space</param>
		public TilePathNode(TilePathNode predecessor, ITileCell cell, Point2D goal) {
			Cell = cell;
			Predecessor = predecessor;
			mGoal = goal;

			Update();
		}


		/// <summary>
		/// Recalculates the costs. This is neccessary when the predecessor has changed.
		/// </summary>
		public void Update() {
			if (Cell.Matches(mGoal)) {
				// The path ends here
				CostVisited = 1;
				CostLeftGoal = 1;
				CostTotal = 1;
			} else {
				// cost for moving from start to this node
				CostVisited = (Predecessor != null ? Predecessor.CostVisited : 0) + Cell.Weight;

				// heuristic estimating the cost for moving from this node to the goal by Manhattan distance
				CostLeftGoal = 10 * (Math.Abs(Cell.X - mGoal.X) + Math.Abs(Cell.Y - mGoal.Y));

				// the combined cost is later used to compare nodes
				CostTotal = CostVisited + CostLeftGoal;
			}
		}

		/// <summary>
		/// Path nodes are soley compared by comparing their costs (F).
		/// </summary>
		/// <param name="obj">An other PathNode</param>
		/// <returns>Returns -1 when the the other path node is more expensive, 1 if it is less expensive and 0 otherwise</returns>
		/// <exception cref="ArgumentException">Obj needs to an instance of TilePathNode</exception>
		public int CompareTo(object obj) {
			var node = obj as TilePathNode;
			if (node == null) {
				throw new ArgumentException("Obj needs to an instance of TilePathNode", "obj");
			}

			if (node.CostTotal < CostTotal) {
				return 1;
			}
			if (node.CostTotal > CostTotal) {
				return -1;
			}

			return 0;
		}

		/// <summary>
		/// Two path nodes are equal when they represent the same grid cell.
		/// </summary>
		/// <param name="other">Another path node</param>
		/// <returns>True if both nodes represent the same grid cell</returns>
		public bool Equals(TilePathNode other) {
			return Cell == other.Cell;
		}

		/// <summary>
		/// Path nodes are soley compared by comparing their costs (F).
		/// </summary>
		/// <param name="other">An other PathNode</param>
		/// <returns>Returns -1 when the the other path node is more expensive, 1 if it is less expensive and 0 otherwise</returns>       
		public int CompareTo(TilePathNode other) {
			if (other.CostTotal < CostTotal) {
				return 1;
			}
			if (other.CostTotal > CostTotal) {
				return -1;
			}

			return 0;
		}

	}

}
