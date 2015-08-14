using System.IO;
using FreeWorld.Engine.TileEngine;
using FreeWorld.Engine.TileEngine.Animation;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace FreeWorld.Engine.PipelineExtension.Animation {

	/// <summary>
	/// Content Processor, convert the Importer Data to the Compiled Data
	/// </summary>
	[ContentProcessor(DisplayName = "Free World Animation Processor")]
	public class TileAnimationProcessor : ContentProcessor<TileAnimationImporterData, CompiledTileAnimationData> {
	
		public override CompiledTileAnimationData Process(TileAnimationImporterData input, ContentProcessorContext context) {
			TileAnimation ani;
			TileLoadResult result;
			using (MemoryStream ms = new MemoryStream(input.Data))
				result = TileAnimation.Load(ms, out ani);

			return new CompiledTileAnimationData(ani, result);
		}

	}

}