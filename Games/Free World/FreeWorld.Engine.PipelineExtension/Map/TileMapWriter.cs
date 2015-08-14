using FreeWorld.Engine.TileEngine;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace FreeWorld.Engine.PipelineExtension.Map {

	/// <summary>
	/// Content Writer, writes the Compiled Data to the Output Stream
	/// </summary>
	[ContentTypeWriter]
	public class TileMapWriter : ContentTypeWriter<CompiledTileMapData> {

		protected override void Write(ContentWriter output, CompiledTileMapData value) {
			value.CompiledData.Save(output.BaseStream, "XNATileMap");
		}

		public override string GetRuntimeType(TargetPlatform targetPlatform) {
			return typeof(TileMap).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform) {
			return typeof(TileMapReader).AssemblyQualifiedName;
		}

	}

}
