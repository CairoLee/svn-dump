using System;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;

namespace PacMan {

	/// <summary>
	/// By who the tile can be traversed
	/// </summary>
	public enum ETileTypes {
		/// <summary>
		/// Everyone can go through
		/// </summary>
		Open,
		/// <summary>
		/// No one can go through
		/// </summary>
		Closed,
		/// <summary>
		/// Under special circumstances ghosts can go there
		/// </summary>
		Home
	}

}
