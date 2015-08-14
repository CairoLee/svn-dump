using System.IO;
using FreeWorld.Engine.TileEngine;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace FreeWorld.Engine.PipelineExtension.Map {

	/// <summary>
	/// Content Processor, convert the Importer Data to the Compiled Data
	/// </summary>
	[ContentProcessor(DisplayName = "Free World Map Processor")]
	public class TileMapProcessor : ContentProcessor<TileMapImporterData, CompiledTileMapData> {

		public override CompiledTileMapData Process(TileMapImporterData input, ContentProcessorContext context) {
			TileMap map;
			TileLoadResult result;
			using (var ms = new MemoryStream(input.Data)) {
				result = TileMap.Load(ms, out map);
			}

			return new CompiledTileMapData(map, result);
		}

	}

}