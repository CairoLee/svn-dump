using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PacMan {

	/// <summary>
	/// Defines the position of an entity (player, ghost) on the board. 
	/// </summary>
	public struct EntityPosition {
		/// <summary>
		/// The tile the entity is on.
		/// </summary>
		public Point Tile;
		/// <summary>
		/// How many pixels the entity is off its nominal tile.
		/// </summary>
		public Point DeltaPixel;


		public EntityPosition(Point tile, Point delta) {
			Tile = tile;
			DeltaPixel = delta;
		}
	}

}
