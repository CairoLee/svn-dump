using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace GLibary {

	public partial class Utility {
		private static VectorRenderer vectorRenderer = null;

		public static VectorRenderer VectorRenderer {
			get {
				if( vectorRenderer == null ) {
					VectorRenderer = new VectorRenderer();
				}
				return vectorRenderer;
			}
			set {
				if( vectorRenderer != null ) {
					RemoveService<VectorRendererService>();
				}
				vectorRenderer = value;
				AddService<VectorRendererService>(
					new VectorRendererService( vectorRenderer ) );
			}
		}
	}

	public interface IVectorRendererService {
		VectorRenderer VectorRenderer {
			get;
		}
	}

	public class VectorRendererService : IVectorRendererService {

		public VectorRendererService( VectorRenderer VectorRenderer ) {
			this.vectorRenderer = VectorRenderer;
		}

		private VectorRenderer vectorRenderer;

		public VectorRenderer VectorRenderer {
			get {
				return vectorRenderer;
			}
		}

		public static implicit operator
						VectorRenderer( VectorRendererService vr ) {
			return vr.VectorRenderer;
		}
	}

	public class VectorRenderer {
		private Effect effect = null;
		private Matrix viewProjMatrix = Matrix.Identity;
		private Matrix worldMatrix = Matrix.Identity;

		private EffectParameter m_paramVP = null;
		private EffectParameter m_paramWorld = null;

		private VertexDeclaration vertexDecl = null;

		private const int maxPoints = 8;
		private VertexPositionColor[] vertices =
					new VertexPositionColor[ maxPoints ];

		private const int maxIndices = 24;
		private short[] indices = new short[ maxIndices ];

		private int currentPass = -1;


		public VectorRenderer() {
			effect = Utility.Game.Content.Load<Effect>( "vectorLineRenderer" );

			m_paramVP = effect.Parameters[ "mVP" ];
			m_paramWorld = effect.Parameters[ "mWorld" ];

			vertexDecl = Utility.GraphicsDevice.CreateDeclaration(
									VertexPositionColor.VertexElements );

			SetColor( Color.White );

			// Setup Indices
			// setup box indices
			indices[ 0 ] = 0;
			indices[ 1 ] = 1;
			indices[ 2 ] = 1;
			indices[ 3 ] = 2;
			indices[ 4 ] = 2;
			indices[ 5 ] = 3;
			indices[ 6 ] = 3;
			indices[ 7 ] = 0;

			indices[ 8 ] = 4;
			indices[ 9 ] = 5;
			indices[ 10 ] = 5;
			indices[ 11 ] = 6;
			indices[ 12 ] = 6;
			indices[ 13 ] = 7;
			indices[ 14 ] = 7;
			indices[ 15 ] = 4;

			indices[ 16 ] = 0;
			indices[ 17 ] = 4;
			indices[ 18 ] = 1;
			indices[ 19 ] = 5;
			indices[ 20 ] = 2;
			indices[ 21 ] = 6;
			indices[ 22 ] = 3;
			indices[ 23 ] = 7;
		}


		// void SetWorldMatrix(Matrix pworldMatrix)
		public void SetWorldMatrix( Matrix pworldMatrix ) {
			worldMatrix = pworldMatrix;
		}



		// void SetViewProjMatrix(Matrix pviewProjMatrix)
		public void SetViewProjMatrix( Matrix pviewProjMatrix ) {
			viewProjMatrix = pviewProjMatrix;
		}


		// void SetColor
		public void SetColor( Color color ) {
			for( int i = 0; i < maxPoints; ++i ) {
				vertices[ i ].Color = color;
			}
		}

		public void SetColor( Vector3 color ) {
			for( int i = 0; i < maxPoints; ++i ) {
				vertices[ i ].Color = new Color( color );
			}
		}



		// void DrawLine(Vector3 p0, Vector3 p1)
		public void DrawLine( Vector3 p0, Vector3 p1 ) {
			this.SetViewProjMatrix( Utility.Camera.ViewProjection );

			vertices[ 0 ].Position = p0;
			vertices[ 1 ].Position = p1;

			Predraw( 0 );
			Utility.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
				PrimitiveType.LineList, vertices, 0, 1 );
			Postdraw();
		}


		// void DrawLine(int x0, int y0, int x1, int y1)
		public void DrawLine( int x0, int y0, int x1, int y1 ) {
			vertices[ 0 ].Position = new Vector3(
				-1.0f + 2.0f * x0 / Utility.GraphicsDevice.Viewport.Width,
				1.0f - 2.0f * y0 / Utility.GraphicsDevice.Viewport.Height, 0 );

			vertices[ 1 ].Position = new Vector3(
				-1.0f + 2.0f * x1 / Utility.GraphicsDevice.Viewport.Width,
				1.0f - 2.0f * y1 / Utility.GraphicsDevice.Viewport.Height, 0 );

			Predraw( 1 );
			Utility.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
				PrimitiveType.LineList, vertices, 0, 1 );
			Postdraw();
		}


		// void DrawLine2D(Vector3 p0, Vector3 p1)
		public void DrawLine2D( Vector3 p0, Vector3 p1 ) {
			DrawLine( (int)p0.X, (int)p0.Y, (int)p1.X, (int)p1.Y );

		}


		// void DrawBoundingBox(BoundingBox box)
		public void DrawBoundingBox( BoundingBox box ) {
			this.SetViewProjMatrix( Utility.Camera.ViewProjection );


			vertices[ 0 ].Position = new Vector3( box.Min.X, box.Min.Y, box.Min.Z );
			vertices[ 1 ].Position = new Vector3( box.Max.X, box.Min.Y, box.Min.Z );
			vertices[ 2 ].Position = new Vector3( box.Max.X, box.Min.Y, box.Max.Z );
			vertices[ 3 ].Position = new Vector3( box.Min.X, box.Min.Y, box.Max.Z );

			vertices[ 4 ].Position = new Vector3( box.Min.X, box.Max.Y, box.Min.Z );
			vertices[ 5 ].Position = new Vector3( box.Max.X, box.Max.Y, box.Min.Z );
			vertices[ 6 ].Position = new Vector3( box.Max.X, box.Max.Y, box.Max.Z );
			vertices[ 7 ].Position = new Vector3( box.Min.X, box.Max.Y, box.Max.Z );

			Predraw( 0 );
			Utility.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
				PrimitiveType.LineList, vertices,
				0,
				8,
				indices,
				0,
				12 );
			Postdraw();
		}


		// void DrawBoundingSphere(BoundingSphere sphere)
		public void DrawBoundingSphere( BoundingSphere sphere ) {
			this.SetViewProjMatrix( Utility.Camera.ViewProjection );

			const int numCircleSegments = 12;

			float step = 2.0f * (float)Math.PI / numCircleSegments;

			for( int i = 0; i < numCircleSegments; ++i ) {
				float u0 = (float)Math.Cos( step * i ) * sphere.Radius;
				float v0 = (float)Math.Sin( step * i ) * sphere.Radius;
				float u1 = (float)Math.Cos( step * ( i + 1 ) ) * sphere.Radius;
				float v1 = (float)Math.Sin( step * ( i + 1 ) ) * sphere.Radius;

				// xy
				DrawLine( new Vector3( u0, v0, 0 ) + sphere.Center,
						 new Vector3( u1, v1, 0 ) + sphere.Center );

				// xz
				DrawLine( new Vector3( u0, 0, v0 ) + sphere.Center,
						 new Vector3( u1, 0, v1 ) + sphere.Center );

				// yz
				DrawLine( new Vector3( 0, u0, v0 ) + sphere.Center,
						 new Vector3( 0, u1, v1 ) + sphere.Center );
			}
		}



		// void Predraw(int pass)
		private void Predraw( int pass ) {
			currentPass = pass;

			effect.Begin();

			m_paramVP.SetValue( viewProjMatrix );
			m_paramWorld.SetValue( worldMatrix );

			effect.Techniques[ 0 ].Passes[ currentPass ].Begin();

			Utility.GraphicsDevice.VertexDeclaration = vertexDecl;
		}


		// void PostDraw()
		private void Postdraw() {
			effect.Techniques[ 0 ].Passes[ currentPass ].End();
			effect.End();

			currentPass = -1;
		}



	}
}

