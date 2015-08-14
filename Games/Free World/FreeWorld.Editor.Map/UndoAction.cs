using FreeWorld.Engine.TileEngine;
using Microsoft.Xna.Framework;

namespace FreeWorld.Editor.Map {
	public class UndoAction {
		public int LayerID;
		public TileCell CellTo;
		public TileCell CellFrom;
		public Point Point;

		public UndoAction() {
		}

		public UndoAction(int layer, TileCell to, TileCell from, Point p) {
			LayerID = layer;
			CellTo = (TileCell)to.Clone();
			CellFrom = (TileCell)from.Clone();
			Point = p;
		}
	}
}