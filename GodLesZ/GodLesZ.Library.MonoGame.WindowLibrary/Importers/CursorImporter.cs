using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace GodLesZ.Library.Xna.WindowLibrary.Importers {


	public class CursorFile {
		public byte[] Data = null;
	}

	[ContentImporter(".cur", DisplayName = "Cursor - Window Library")]
	class CursorImporter : ContentImporter<CursorFile> {
		public override CursorFile Import(string filename, ContentImporterContext context) {
			CursorFile cur = new CursorFile();
			cur.Data = File.ReadAllBytes(filename);
			return cur;
		}

	}

	[ContentTypeWriter]
	class CursorWriter : ContentTypeWriter<CursorFile> {

		protected override void Write(ContentWriter output, CursorFile value) {
			output.Write(value.Data.Length);
			output.Write(value.Data);
		}

		public override string GetRuntimeType(TargetPlatform targetPlatform) {
			return typeof(CursorFile).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform) {
			return "GodLesZ.Library.Xna.WindowLibrary.Controls.CursorReader, GodLesZ.Library.Xna.WindowLibrary.Controls";
		}

	}

}