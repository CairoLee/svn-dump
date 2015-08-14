using FreeWorld.Engine.TileEngine;

namespace FreeWorld.Engine.PipelineExtension.Map {

	/// <summary>
	/// Compiled Data created on the Processor
	/// </summary>
	public class CompiledTileMapData {
		public TileMap CompiledData {
			get;
			protected set;
		}

		public TileLoadResult Result {
			get;
			protected set;
		}


		public CompiledTileMapData(TileMap bmap, TileLoadResult res) {
			CompiledData = bmap;
			Result = res;
		}

	}
}