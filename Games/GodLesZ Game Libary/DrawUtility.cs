using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace GLibary {
	public static class GraphicsDeviceExtensions {

		public static void DrawIndexedPrimitives( this GraphicsDevice GraphicsDevice, PrimitiveType primitiveType, int numVertices, int primitiveCount, Effect eff ) {
			eff.Begin();
			foreach( EffectPass pass in eff.CurrentTechnique.Passes ) {
				pass.Begin();
				GraphicsDevice.DrawIndexedPrimitives( primitiveType, 0, 0, numVertices, 0, primitiveCount );
				pass.End();
			}
			eff.End();
		}

		public static void DrawIndexedPrimitives( this GraphicsDevice GraphicsDevice, PrimitiveType primitiveType, int numVertices, int primitiveCount ) {
			GraphicsDevice.DrawIndexedPrimitives( primitiveType, 0, 0, numVertices, 0, primitiveCount );
		}

		public static void DrawUserIndexedPrimitives<TVertexType>( this GraphicsDevice GraphicsDevice, PrimitiveType primitiveType, TVertexType[] vertices, int[] indices ) where TVertexType : struct {
			GraphicsDevice.DrawUserIndexedPrimitives<TVertexType>( primitiveType, vertices, indices );
		}
		public static void DrawUserIndexedPrimitives<TVertexType>( this GraphicsDevice GraphicsDevice, PrimitiveType primitiveType, TVertexType[] vertices, int[] indices, VertexDeclaration decl ) where TVertexType : struct {
			GraphicsDevice.VertexDeclaration = decl;
			GraphicsDevice.DrawUserIndexedPrimitives<TVertexType>( primitiveType, vertices, indices );
		}

		public static void DrawUserIndexedPrimitives<TVertexType>( this GraphicsDevice GraphicsDevice, TVertexType[] vertices, int[] indices ) where TVertexType : struct {
			GraphicsDevice.DrawUserIndexedPrimitives<TVertexType>( PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3 );
		}
		public static void DrawUserIndexedPrimitives<TVertexType>( this GraphicsDevice GraphicsDevice, TVertexType[] vertices, int[] indices, VertexDeclaration decl ) where TVertexType : struct {
			GraphicsDevice.VertexDeclaration = decl;
			GraphicsDevice.DrawUserIndexedPrimitives<TVertexType>( PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3 );
		}



		public static void DrawUserIndexedPrimitives<TVertexType>( this GraphicsDevice GraphicsDevice, PrimitiveType primitiveType, TVertexType[] vertices, short[] indices ) where TVertexType : struct {
			GraphicsDevice.DrawUserIndexedPrimitives<TVertexType>( primitiveType, vertices, indices );
		}
		public static void DrawUserIndexedPrimitives<TVertexType>( this GraphicsDevice GraphicsDevice, PrimitiveType primitiveType, TVertexType[] vertices, short[] indices, VertexDeclaration decl ) where TVertexType : struct {
			GraphicsDevice.VertexDeclaration = decl;
			GraphicsDevice.DrawUserIndexedPrimitives<TVertexType>( primitiveType, vertices, indices );
		}

		public static void DrawUserIndexedPrimitives<TVertexType>( this GraphicsDevice GraphicsDevice, TVertexType[] vertices, short[] indices ) where TVertexType : struct {
			GraphicsDevice.DrawUserIndexedPrimitives<TVertexType>( PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3 );
		}
		public static void DrawUserIndexedPrimitives<TVertexType>( this GraphicsDevice GraphicsDevice, TVertexType[] vertices, short[] indices, VertexDeclaration decl ) where TVertexType : struct {
			GraphicsDevice.VertexDeclaration = decl;
			GraphicsDevice.DrawUserIndexedPrimitives<TVertexType>( PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3 );
		}

		public static void DrawIndexedPrimitives( this GraphicsDevice GraphicsDevice, VertexBuffer vb, IndexBuffer ib, VertexDeclaration decl, Effect eff ) {
			GraphicsDevice.SetVertexBuffer( vb, decl, ib );

			GraphicsDevice.DrawIndexedPrimitives( vb.GetVertexBufferCount(), ib.GetIndexBufferPrimitiveCount(), eff );

		}

		public static void DrawIndexedPrimitives( this GraphicsDevice GraphicsDevice, VertexBuffer vb, IndexBuffer ib, VertexDeclaration decl ) {
			GraphicsDevice.SetVertexBuffer( vb, decl, ib );
			GraphicsDevice.DrawIndexedPrimitives( vb.GetVertexBufferCount(), ib.GetIndexBufferPrimitiveCount() );
		}

		public static void DrawIndexedPrimitives( this GraphicsDevice GraphicsDevice, int numVertices, int primitiveCount, Effect eff ) {
			eff.Begin();
			foreach( EffectPass pass in eff.CurrentTechnique.Passes ) {
				pass.Begin();
				GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleList, 0, 0, numVertices, 0, primitiveCount );
				pass.End();
			}

			eff.End();


		}

		public static void DrawIndexedPrimitives( this GraphicsDevice GraphicsDevice, int numVertices, int primitiveCount ) {
			GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleList, 0, 0, numVertices, 0, primitiveCount );
		}
	}
}
