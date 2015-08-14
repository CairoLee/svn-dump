using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;

using TImport = FinalSoftware.Games.Defender.Library.DefenderMap;

namespace FinalSoftware.Games.Defender.ContentPipeline {

	[ContentImporter( ".dfmap", DisplayName = "DF Map Importer" )]
	public class DefenderMapImporter : ContentImporter<TImport> {
		public override TImport Import( string filename, ContentImporterContext context ) {
			TImport map;
			XmlSerializer xml = new XmlSerializer( typeof( TImport ) );
			using( FileStream fs = File.OpenRead( filename ) )
				map = (TImport)xml.Deserialize( fs );

			return map;
		}
	}

}
