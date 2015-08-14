using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace FreeWorld.Engine.PipelineExtension.Map {

	[ContentImporter(".bmap", DisplayName = "Free World Map Importer", DefaultProcessor = "TileMapProcessor")]
	public class TileMapImporter : ContentImporter<TileMapImporterData> {
		public override TileMapImporterData Import(string filename, ContentImporterContext context) {
			var data = new TileMapImporterData(File.ReadAllBytes(filename));
			return data;
		}

	}

}
