using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using TWrite = FinalSoftware.Games.Defender.Library.DefenderMap;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace FinalSoftware.Games.Defender.ContentPipeline {

	[ContentTypeWriter]
	public class DefenderMapWriter : ContentTypeWriter<TWrite> {
		protected override void Write( ContentWriter output, TWrite value ) {
			XmlSerializer xml = new XmlSerializer( typeof( TWrite ) );
			xml.Serialize( output.BaseStream, value );
		}


		public override string GetRuntimeType( TargetPlatform targetPlatform ) {
			return typeof( TWrite ).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader( TargetPlatform targetPlatform ) {
			return typeof( DefenderMapReader ).AssemblyQualifiedName;
		}
	}

}
