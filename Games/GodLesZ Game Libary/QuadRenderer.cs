
//Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GLibary {
	public partial class Utility {

		private static QuadRenderer quadRenderer = null;

		public static QuadRenderer QuadRenderer {
			get {
				if( quadRenderer == null ) {
					QuadRenderer = new QuadRenderer();
				}
				return quadRenderer;
			}
			set {
				if( quadRenderer != null ) {
					RemoveService<QuadService>();
				}
				quadRenderer = value;
				AddService<QuadService>( new QuadService( quadRenderer ) );
			}
		}
	}

	public interface IQuadService {
		QuadRenderer QuadRenderer {
			get;
		}
	}

	public class QuadService : IQuadService {

		public QuadService( QuadRenderer quadRenderer ) {
			this.quadRenderer = quadRenderer;
		}

		private QuadRenderer quadRenderer;

		public QuadRenderer QuadRenderer {
			get {
				return quadRenderer;
			}
		}

		public static implicit operator QuadRenderer( QuadService cs ) {
			return cs.QuadRenderer;
		}
	}

	public class QuadRenderer {
		VertexDeclaration vertexDecl;
		VertexPositionTexture[] vertices;
		short[] indices;
		BasicEffect basicEffect;

		public QuadRenderer() {

			vertexDecl = Utility.GraphicsDevice.CreateDeclaration(
				VertexPositionTexture.VertexElements );

			basicEffect = new BasicEffect( Utility.GraphicsDevice, null );


			vertices = new VertexPositionTexture[]
            {
                new VertexPositionTexture(
                    Vector3.Zero,
                    Vector2.One),
                new VertexPositionTexture(
                    Vector3.Zero,
                    Vector2.UnitY),
                new VertexPositionTexture(
                    Vector3.Zero,
                    Vector2.Zero),
                new VertexPositionTexture(
                    Vector3.Zero,
                    Vector2.UnitX)
            };

			indices = new short[] { 0, 1, 2, 2, 3, 0 };
		}

		public void DrawQuad( Vector2 min,
							 Vector2 max,
							 BasicEffect effect ) {
			effect.Begin();
			effect.Techniques[ 0 ].Passes[ 0 ].Begin();
			DrawQuad( min, max );
			effect.Techniques[ 0 ].Passes[ 0 ].End();
			effect.End();
		}



		public void DrawQuad( Rectangle rect, Texture2D tex ) {
			Viewport vp = Utility.GraphicsDevice.Viewport;

			Vector2 min = new Vector2( ( ( ( ( (float)rect.Left / (float)vp.Width ) * 2.0f ) - 1.0f ) ),
									  -( ( ( ( (float)rect.Bottom / (float)vp.Height ) * 2.0f ) - 1.0f ) ) );
			Vector2 max = new Vector2( ( ( ( ( (float)rect.Right / (float)vp.Width ) * 2.0f ) - 1.0f ) ),
									  -( ( ( ( (float)rect.Top / (float)vp.Height ) * 2.0f ) - 1.0f ) ) );

			DrawQuad( min, max, tex );
		}

		public void DrawQuad( Vector2 min,
							 Vector2 max,
							 Texture2D texture ) {
			basicEffect.Texture = texture;
			basicEffect.TextureEnabled = true;
			basicEffect.Begin();
			basicEffect.Techniques[ 0 ].Passes[ 0 ].Begin();
			DrawQuad( min, max );
			basicEffect.Techniques[ 0 ].Passes[ 0 ].End();
			basicEffect.End();
		}


		public void DrawQuad( Vector2 min,
							 Vector2 max ) {
			Utility.GraphicsDevice.VertexDeclaration = vertexDecl;
			Viewport vp = Utility.GraphicsDevice.Viewport;
			vertices[ 0 ].Position.X = max.X;
			vertices[ 0 ].Position.Y = min.Y;

			vertices[ 1 ].Position.X = min.X;
			vertices[ 1 ].Position.Y = min.Y;

			vertices[ 2 ].Position.X = min.X;
			vertices[ 2 ].Position.Y = max.Y;

			vertices[ 3 ].Position.X = max.X;
			vertices[ 3 ].Position.Y = max.Y;


			Utility.GraphicsDevice.DrawUserIndexedPrimitives
				<VertexPositionTexture>(
					PrimitiveType.TriangleList,
					vertices,
					0,
					4,
					indices,
					0,
					2 );

		}


	}
}

