using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PacMan {

	/// <summary>
	/// A square of the maze
	/// </summary>
	public class GridTile {
		private bool mHasCrumb;

		/// <summary>
		/// The type of the tile
		/// </summary>
		public ETileTypes Type {
			get;
			set;
		}

		/// <summary>
		/// Whether the tile has a crump
		/// </summary>
		public bool HasCrump {
			get { return mHasCrumb; }
			set {
				if (value != mHasCrumb) {
					Grid.NumCrumps += value ? 1 : -1;
				}
				mHasCrumb = value;
			}
		}

		/// <summary>
		/// Whether the tile has a power pill
		/// </summary>
		public bool HasPowerPill {
			get;
			set;
		}

		public bool IsOpen {
			get { return Type == ETileTypes.Open; }
		}

		public Point ToPoint {
			get;
			private set;
		}

		/// <summary>
		/// Sets the different attributes
		/// </summary>
		/// <param name="type">The type of tile</param>
		/// <param name="hasCrump">Whether the tile has a crump</param>
		/// <param name="hasPowerPill">Whether the tile has a power pill</param>
		public GridTile(ETileTypes type, bool hasCrump, bool hasPowerPill, Point position) {
			Type = type;
			mHasCrumb = hasCrump;
			if (hasCrump) {
				Grid.NumCrumps++;
			}
			HasPowerPill = hasPowerPill;
			ToPoint = position;
		}
	}

}