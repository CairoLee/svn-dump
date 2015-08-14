using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace FreeWorld.Engine.PipelineExtension.Animation {

	/// <summary>
	/// Basic Importer, imports the File Format
	/// </summary>
	[ContentImporter(".bani", DisplayName = "Free World Animation Importer", DefaultProcessor = "TileAnimationProcessor")]
	public class TileAnimationImporter : ContentImporter<TileAnimationImporterData> {
		public override TileAnimationImporterData Import(string filename, ContentImporterContext context) {
			return new TileAnimationImporterData(File.ReadAllBytes(filename));
		}
	}

}