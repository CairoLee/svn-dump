using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ragnarok3D.Editor {
	public class Triangle {
		VertexBuffer vertexBuffer;
		IndexBuffer indexBuffer;
		VertexPositionColor[] vertex;
		VertexDeclaration vertexDeclaration;

		Matrix world;

		Effect effect;
		EffectParameter worldViewProjParam;
		EffectParameter colorParam;
		Vector4 myColor = Vector4.One;

		public Triangle( Vector3 p1, Vector3 p2, Vector3 p3, Color color ) {
			myColor = color.ToVector4();
			InitEffect();
			SetUpVertices( p1, p2, p3, color );
			SetUpIndices();
			Update();
		}

		private void InitEffect() {
			effect = Editor.Content.Load<Effect>( @"Shaders\color" );
			worldViewProjParam = effect.Parameters[ "WorldViewProj" ];
			colorParam = effect.Parameters[ "color" ];
		}

		private void SetUpVertices( Vector3 p1, Vector3 p2, Vector3 p3, Color color ) {
			vertexDeclaration = new VertexDeclaration( Editor.graphics.GraphicsDevice, VertexPositionColor.VertexElements );
			vertex = new VertexPositionColor[ 3 ];
			vertex[ 0 ] = new VertexPositionColor( p1 + new Vector3( 0f, 1f, 0f ), color );
			vertex[ 1 ] = new VertexPositionColor( p2 + new Vector3( 0f, 1f, 0f ), color );
			vertex[ 2 ] = new VertexPositionColor( p3 + new Vector3( 0f, 1f, 0f ), color );
			vertexBuffer = new VertexBuffer( Editor.graphics.GraphicsDevice, typeof( VertexPositionColor ), vertex.Length, BufferUsage.None );
			vertexBuffer.SetData<VertexPositionColor>( vertex );
		}

		private void SetUpIndices() {
			short[] Indices = new short[ 3 ];
			Indices[ 0 ] = 0;
			Indices[ 1 ] = 2;
			Indices[ 2 ] = 1;
			indexBuffer = new IndexBuffer( Editor.graphics.GraphicsDevice, sizeof( short ) * Indices.Length, BufferUsage.None, IndexElementSize.SixteenBits );
			indexBuffer.SetData<short>( Indices );
		}

		public void SetNewCoordinates( Vector3 p1, Vector3 p2, Vector3 p3, Color color ) {
			myColor = color.ToVector4();
			SetUpVertices( p1, p2, p3, color );
			SetUpIndices();
			Update();
		}

		public void Update() {
			world = Matrix.CreateTranslation( Vector3.Zero );
			worldViewProjParam.SetValue( world );
		}

		public void Draw( Matrix view, Matrix projection ) {
			Editor.graphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
			Editor.graphics.GraphicsDevice.RenderState.CullMode = CullMode.None;
			Editor.graphics.GraphicsDevice.RenderState.FillMode = FillMode.WireFrame;

			Matrix WorldViewProj = world * view * projection;

			effect.Begin();

			worldViewProjParam.SetValue( WorldViewProj );
			colorParam.SetValue( myColor );

			effect.CommitChanges();

			foreach( EffectPass pass in effect.CurrentTechnique.Passes ) {
				pass.Begin();

				Editor.graphics.GraphicsDevice.VertexDeclaration = vertexDeclaration;
				Editor.graphics.GraphicsDevice.Indices = indexBuffer;
				Editor.graphics.GraphicsDevice.Vertices[ 0 ].SetSource( vertexBuffer, 0, VertexPositionColor.SizeInBytes );
				Editor.graphics.GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleList, 0, 0, vertex.Length, 0, vertex.Length / 3 );

				pass.End();
			}

			effect.End();
		}

	}
}
