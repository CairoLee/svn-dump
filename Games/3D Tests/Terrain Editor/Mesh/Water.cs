using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ragnarok3D.Editor {
	public class Water {
		Vector3 position = Vector3.Zero;
		Vector2 size = Vector2.Zero;

		VertexBuffer vertexBuffer;
		//IndexBuffer indexBuffer;
		VertexDeclaration vertexDeclaration;
		VertexPositionTexture[] vertex;

		Matrix world;
		//Matrix worldViewIT;
		Matrix windDirection;

		Effect effect;
		private Texture2D[] texture;
		//private TextureCube textureCube;
		private float elapsedTime;

		public bool bFollowCamera = false;

		public Water( Nullable<Vector2> wSize, bool bHorizonMode ) {
			if( Editor.bDrawWater == false )
				return;

			texture = new Texture2D[ 2 ];
			texture[ 0 ] = Editor.Content.Load<Texture2D>( @"Textures\Water\\water" );
			texture[ 1 ] = Editor.Content.Load<Texture2D>( @"Textures\Water\\water_bump" );

			if( wSize != null )
				size = wSize.Value;

			bFollowCamera = bHorizonMode;

			Init();
			Editor.console.Add( "Water Initialized" );
		}

		private void Init() {
			if( size == Vector2.Zero )
				size = new Vector2( Editor.heightmap.size.X * Editor.heightmap.cellSize.X, Editor.heightmap.size.Y * Editor.heightmap.cellSize.Y );

			InitEffect();
			SetUpVertices();
		}

		private void InitEffect() {
			effect = Editor.Content.Load<Effect>( @"Shaders\basic_water" );
		}

		private void SetUpVertices() {
			vertexDeclaration = new VertexDeclaration( Editor.graphics.GraphicsDevice, VertexPositionTexture.VertexElements );

			vertex = new VertexPositionTexture[ 6 ];

			vertex[ 0 ] = new VertexPositionTexture( new Vector3( 0f, Editor.waterHeight, 0f ), new Vector2( 0, 1 ) );
			vertex[ 2 ] = new VertexPositionTexture( new Vector3( size.X, Editor.waterHeight, size.Y ), new Vector2( 1, 0 ) );
			vertex[ 1 ] = new VertexPositionTexture( new Vector3( 0f, Editor.waterHeight, size.Y ), new Vector2( 0, 0 ) );

			vertex[ 3 ] = new VertexPositionTexture( new Vector3( 0f, Editor.waterHeight, 0f ), new Vector2( 0, 1 ) );
			vertex[ 5 ] = new VertexPositionTexture( new Vector3( size.X, Editor.waterHeight, 0f ), new Vector2( 1, 1 ) );
			vertex[ 4 ] = new VertexPositionTexture( new Vector3( size.X, Editor.waterHeight, size.Y ), new Vector2( 1, 0 ) );

			vertexBuffer = new VertexBuffer( Editor.graphics.GraphicsDevice, typeof( VertexPositionTexture ), vertex.Length, BufferUsage.None );
			vertexBuffer.SetData<VertexPositionTexture>( vertex );
		}

		public void Update( GameTime gameTime ) {
			elapsedTime += (float)gameTime.ElapsedGameTime.Milliseconds / 100000.0f;

			position.Y = Editor.waterHeight;

			if( bFollowCamera ) {
				position.X = Editor.camera.targetPos.X - size.X * .5f;
				position.Z = Editor.camera.targetPos.Z - size.Y * .5f;
			}

			world = Matrix.CreateTranslation( position );
			windDirection = Matrix.CreateRotationY( MathHelper.PiOver2 );
		}

		public void Reset() {
			size = Vector2.Zero;
			Init();
		}

		public void Draw( Matrix view, Matrix projection, Matrix reflectionView, Texture2D reflectionMap, Texture2D refractionMap ) {
			Editor.graphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
			Editor.graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullClockwiseFace;

			if( Editor.bUseFog )
				Editor.graphics.GraphicsDevice.RenderState.FogEnable = true;

			Editor.graphics.GraphicsDevice.VertexDeclaration = vertexDeclaration;

			Matrix worldViewProj = world * view * projection;

			effect.Begin();

			effect.Parameters[ "WorldViewProj" ].SetValue( worldViewProj );
			effect.Parameters[ "baseTex" ].SetValue( texture[ 0 ] );
			//effect.Parameters["baseDetail"].SetValue(textureCube);
			effect.Parameters[ "time" ].SetValue( elapsedTime );

			effect.CommitChanges();

			foreach( EffectPass pass in effect.CurrentTechnique.Passes ) {
				pass.Begin();

				//Game1.graphics.GraphicsDevice.Indices = indexBuffer;
				Editor.graphics.GraphicsDevice.Vertices[ 0 ].SetSource( vertexBuffer, 0, VertexPositionTexture.SizeInBytes );
				Editor.graphics.GraphicsDevice.DrawUserPrimitives( PrimitiveType.TriangleList, vertex, 0, 2 );

				pass.End();
			}

			effect.End();
		}
	}
}
