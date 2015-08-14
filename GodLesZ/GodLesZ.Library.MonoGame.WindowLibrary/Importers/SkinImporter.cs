using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace GodLesZ.Library.Xna.WindowLibrary.Importers {

	class SkinXmlDocument : XmlDocument { }

	[ContentImporter(".xml", DisplayName = "Skin - Window Library")]
	class SkinImporter : ContentImporter<SkinXmlDocument> {
		public override SkinXmlDocument Import(string filename, ContentImporterContext context) {
			SkinXmlDocument doc = new SkinXmlDocument();
			doc.Load(filename);

			return doc;
		}

	}

	[ContentTypeWriter]
	class SkinWriter : ContentTypeWriter<SkinXmlDocument> {

		protected override void Write(ContentWriter output, SkinXmlDocument value) {
			output.Write(value.InnerXml);
		}

		public override string GetRuntimeType(TargetPlatform targetPlatform) {
			return typeof(SkinXmlDocument).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform) {
			if (targetPlatform == TargetPlatform.Xbox360) {
				return "GodLesZ.Library.Xna.WindowLibrary.Controls.SkinReader, GodLesZ.Library.Xna.WindowLibrary.Controls.360";
			} else {
				return "GodLesZ.Library.Xna.WindowLibrary.Controls.SkinReader, GodLesZ.Library.Xna.WindowLibrary.Controls";
			}
		}

	}

}