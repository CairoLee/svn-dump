using FreeWorld.Engine.TileEngine.Animation;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace FreeWorld.Engine.PipelineExtension.Animation {

	/// <summary>
	/// Content Writer, writes the Compiled Data to the Output Stream
	/// </summary>
	[ContentTypeWriter]
	public class TileAnimationWriter : ContentTypeWriter<CompiledTileAnimationData> {

		protected override void Write(ContentWriter output, CompiledTileAnimationData value) {
			value.CompiledData.Save(output.BaseStream, "XNATileAnimation");
		}

		public override string GetRuntimeType(TargetPlatform targetPlatform) {
			return typeof(TileAnimation).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform) {
			return typeof(TileAnimationReader).AssemblyQualifiedName;
		}

	}

}