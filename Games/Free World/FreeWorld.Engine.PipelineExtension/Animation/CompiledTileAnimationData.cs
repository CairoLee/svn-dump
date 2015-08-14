using FreeWorld.Engine.TileEngine;
using FreeWorld.Engine.TileEngine.Animation;

namespace FreeWorld.Engine.PipelineExtension.Animation {

	/// <summary>
	/// Compiled Data created on the Processor
	/// </summary>
	public class CompiledTileAnimationData {

		public TileAnimation CompiledData {
			get;
			protected set;
		}

		public TileLoadResult Result {
			get;
			protected set;
		}


		public CompiledTileAnimationData(TileAnimation bani, TileLoadResult res) {
			CompiledData = bani;
			Result = res;
		}

	}

}