using FreeWorld.Engine.TileEngine;
using GodLesZ.Library.Xna.Geometry;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;

namespace FreeWorld.Engine.Geometry.Camera {

	public interface IEngineCamera : ICamera2D {
		
		/// <summary>Gets or sets the width of a tile.</summary>
		int TileWidth {
			get;
		}

		/// <summary>Gets or sets the height of a tile.</summary>
		int TileHeight {
			get;
		}

		void Apply(Point p, TileMap map);
		void Apply(IPoint p, TileMap map);
		void Apply(IPoint2D p, TileMap map);
		void Apply(int x, int y, TileMap map);
		 
	}

}