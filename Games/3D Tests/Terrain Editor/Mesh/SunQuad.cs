using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ragnarok3D.Editor {
	class SunQuad {
		VertexBuffer vertexBuffer;
		IndexBuffer indexBuffer;
		VertexPositionTexture[] vertex;
		VertexDeclaration vertexDeclaration;

		Matrix world;
		Matrix rotationMatrix;
		Vector3 rotation = Vector3.Zero;
		public float drawScale = 1.0f;

		Effect effect;
		Texture2D texture;

		public float alpha = 1f;
		public float glowFactor = 1f;
		public bool bVisible = true;

		public SunQuad( Vector2 size, string textureName, float scale ) {
			drawScale = scale;
			InitEffect( textureName );
			SetUpVertices( size );
			SetUpIndices();
			Update( Vector3.Zero, Vector3.Zero );
		}

		private void InitEffect( string textureName ) {
			texture = Editor.Content.Load<Texture2D>( @"Textures\LensFlare\" + textureName );
			effect = Editor.Content.Load<Effect>( @"Shaders\sun" );
		}

		private void SetUpVertices( Vector2 size ) {
			vertexDeclaration = new VertexDeclaration( Editor.graphics.GraphicsDevice, VertexPositionTexture.VertexElements );

			size *= .5f;
			Vector3 p0 = new Vector3( -size.X, -size.Y, 0f );
			Vector3 p1 = new Vector3( -size.X, size.Y, 0f );
			Vector3 p2 = new Vector3( size.X, -size.Y, 0f );
			Vector3 p3 = new Vector3( size.X, size.Y, 0f );

			vertex = new VertexPositionTexture[ 4 ];
			vertex[ 0 ] = new VertexPositionTexture( p0, new Vector2( 0f, 0f ) );
			vertex[ 1 ] = new VertexPositionTexture( p1, new Vector2( 0f, 1f ) );
			vertex[ 2 ] = new VertexPositionTexture( p2, new Vector2( 1f, 0f ) );
			vertex[ 3 ] = new VertexPositionTexture( p3, new Vector2( 1f, 1f ) );

			vertexBuffer = new VertexBuffer( Editor.graphics.GraphicsDevice, typeof( VertexPositionTexture ), vertex.Length, BufferUsage.None );
			vertexBuffer.SetData<VertexPositionTexture>( vertex );
		}

		private void SetUpIndices() {
			short[] Indices = new short[ 6 ];

			Indices[ 0 ] = 0;
			Indices[ 1 ] = 2;
			Indices[ 2 ] = 1;

			Indices[ 3 ] = 1;
			Indices[ 4 ] = 2;
			Indices[ 5 ] = 3;

			indexBuffer = new IndexBuffer( Editor.graphics.GraphicsDevice, sizeof( short ) * Indices.Length, BufferUsage.None, IndexElementSize.SixteenBits );
			indexBuffer.SetData<short>( Indices );
		}

		public void Update( Vector3 position, Vector3 camPos ) {
			if( !bVisible && alpha > 0f )
				Fade( -0.03f );
			else if( bVisible && alpha < 1f )
				Fade( 0.1f );

			Vector3 viewNormal = Vector3.Normalize( position - camPos );
			rotationMatrix = MathExtra.MatrixFromNormal( viewNormal );

			world = Matrix.CreateScale( drawScale ) * rotationMatrix * Matrix.CreateTranslation( position );
		}

		public void Draw( Matrix view, Matrix projection ) {
			Editor.graphics.GraphicsDevice.RenderState.DepthBufferEnable = false;
			Editor.graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullCounterClockwiseFace;
			Editor.graphics.GraphicsDevice.RenderState.FillMode = FillMode.Solid;
			Editor.graphics.GraphicsDevice.RenderState.FogEnable = false;

			effect.Begin();

			Matrix worldViewProj = world * view * projection;
			effect.Parameters[ "Material" ].SetValue( texture );
			effect.Parameters[ "WorldViewProj" ].SetValue( worldViewProj );
			effect.Parameters[ "Alpha" ].SetValue( alpha );
			effect.Parameters[ "glow" ].SetValue( glowFactor );

			effect.CommitChanges();

			foreach( EffectPass pass in effect.CurrentTechnique.Passes ) {
				pass.Begin();

				Editor.graphics.GraphicsDevice.VertexDeclaration = vertexDeclaration;
				Editor.graphics.GraphicsDevice.Indices = indexBuffer;
				Editor.graphics.GraphicsDevice.Vertices[ 0 ].SetSource( vertexBuffer, 0, VertexPositionTexture.SizeInBytes );
				Editor.graphics.GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleList, 0, 0, vertex.Length, 0, vertex.Length / 2 );

				pass.End();
			}

			effect.End();
		}

		private void Fade( float amount ) {
			alpha += amount;

			if( alpha < 0f )
				alpha = 0f;
			else if( alpha > 1f )
				alpha = 1f;
		}
	}
}
