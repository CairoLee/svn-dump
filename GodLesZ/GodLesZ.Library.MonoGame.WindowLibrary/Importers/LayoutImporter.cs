using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace GodLesZ.Library.Xna.WindowLibrary.Importers {

	public class LayoutXmlDocument : XmlDocument { }

	[ContentImporter(".xml", DisplayName = "Layout - Window Library")]
	class LayoutImporter : ContentImporter<LayoutXmlDocument> {
		public override LayoutXmlDocument Import(string filename, ContentImporterContext context) {
			LayoutXmlDocument doc = new LayoutXmlDocument();
			doc.Load(filename);

			return doc;
		}

	}

	[ContentTypeWriter]
	class LayoutWriter : ContentTypeWriter<LayoutXmlDocument> {

		protected override void Write(ContentWriter output, LayoutXmlDocument value) {
			output.Write(value.InnerXml);
		}

		public override string GetRuntimeType(TargetPlatform targetPlatform) {
			return typeof(LayoutXmlDocument).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform) {
			if (targetPlatform == TargetPlatform.Xbox360) {
				return "GodLesZ.Library.Xna.WindowLibrary.Controls.LayoutReader, GodLesZ.Library.Xna.WindowLibrary.Controls.360";
			} else {
				return "GodLesZ.Library.Xna.WindowLibrary.Controls.LayoutReader, GodLesZ.Library.Xna.WindowLibrary.Controls";
			}
		}

	}

}