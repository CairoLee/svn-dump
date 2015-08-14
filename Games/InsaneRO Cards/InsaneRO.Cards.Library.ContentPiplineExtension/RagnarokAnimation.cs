using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using InsaneRO.Cards.Library.Formats;
using Microsoft.Xna.Framework.Content;

namespace InsaneRO.Cards.Library.PiplineExtension {

	[ContentImporter( ".ani", DisplayName = "RagnarokAnimation Importer", DefaultProcessor = "RagnarokAnimationProcessor" )]
	public class RagnarokAnimationImporter : ContentImporter<RagnarokAnimation> {
		public override RagnarokAnimation Import( string filename, ContentImporterContext context ) {
			RagnarokAnimation ani = new RagnarokAnimation();
			ani.Read( filename, true );
			return ani;
		}
	}


	[ContentProcessor( DisplayName = "RagnarokAnimation Processor" )]
	public class RagnarokAnimationProcessor : ContentProcessor<RagnarokAnimation, RagnarokAnimation> {
		public override RagnarokAnimation Process( RagnarokAnimation input, ContentProcessorContext context ) {
			return input;
		}

	}


	[ContentTypeWriter()]
	public class RagnarokAnimationWriter : ContentTypeWriter<RagnarokAnimation> {

		protected override void Write( ContentWriter output, RagnarokAnimation value ) {
			( value as RagnarokAnimation ).Write( output.BaseStream );
		}

		public override string GetRuntimeReader( TargetPlatform targetPlatform ) {
			return typeof( RagnarokAnimationReader ).AssemblyQualifiedName;
		}

	}


}
