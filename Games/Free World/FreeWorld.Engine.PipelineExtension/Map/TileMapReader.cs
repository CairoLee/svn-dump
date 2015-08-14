using FreeWorld.Engine.TileEngine;
using Microsoft.Xna.Framework.Content;

namespace FreeWorld.Engine.PipelineExtension.Map {

	/// <summary>
	/// Content Reader, reads the Binary compiled File and Convert it to readable Data
	/// </summary>
	public class TileMapReader : ContentTypeReader<TileMap> {

		protected override TileMap Read(ContentReader input, TileMap existingInstance) {
			TileMap map;
			TileMap.Load(input.BaseStream, out map);

			return map;
		}

	}

}
