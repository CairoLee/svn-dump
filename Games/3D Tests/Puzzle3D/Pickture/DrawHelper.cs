using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Puzzle3D {

	static class DrawHelper {

		public static void SetState() {
			RenderState state = Puzzle3D.Instance.GraphicsDevice.RenderState;

			state.AlphaBlendEnable = true;
			state.SourceBlend = Blend.SourceAlpha;
			state.DestinationBlend = Blend.InverseSourceAlpha;
			state.AlphaSourceBlend = Blend.SourceAlpha;
			state.AlphaDestinationBlend = Blend.InverseSourceAlpha;

			state.DepthBufferEnable = true;
			state.DepthBufferWriteEnable = true;
		}

		public static void DrawMeshPart( ModelMesh mesh, ModelMeshPart part, Effect effect ) {
			GraphicsDevice device = Puzzle3D.Instance.GraphicsDevice;

			foreach( EffectPass pass in effect.CurrentTechnique.Passes ) {
				pass.Begin();

				device.VertexDeclaration = part.VertexDeclaration;
				device.Vertices[ 0 ].SetSource( mesh.VertexBuffer, part.StreamOffset, part.VertexStride );
				device.Indices = mesh.IndexBuffer;

				device.DrawIndexedPrimitives( PrimitiveType.TriangleList, part.BaseVertex, 0, part.NumVertices, part.StartIndex, part.PrimitiveCount );

				pass.End();
			}
		}

	}

}
