using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using System.Diagnostics;

namespace Puzzle3D.Pipeline {

	[ContentProcessor( DisplayName = "Lighting Processor" )]
	public class LightingProcessor : ModelProcessor {

		public override ModelContent Process( NodeContent input, ContentProcessorContext context ) {
			CalculateTangentFrames( input, context );

			ModelContent modelContent = base.Process( input, context );
			foreach( ModelMeshContent modelMesh in modelContent.Meshes ) {
				foreach( ModelMeshPartContent modelMeshPart in modelMesh.MeshParts )
					modelMeshPart.Tag = modelMeshPart.Material.Name;
			}

			return modelContent;
		}

		private void CalculateTangentFrames( NodeContent input, ContentProcessorContext context ) {
			MeshContent inputMesh = input as MeshContent;
			if( inputMesh != null )
				MeshHelper.CalculateTangentFrames( inputMesh, VertexChannelNames.TextureCoordinate( 0 ), VertexChannelNames.Tangent( 0 ), null );

			foreach( NodeContent childNode in input.Children )
				CalculateTangentFrames( childNode, context );
		}

	}

}
