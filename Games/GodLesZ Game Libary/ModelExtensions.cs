using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace GLibary {
	public static class ModelExtensions {

		public static void SetEffect( this Model model,	Effect effect ) {
			foreach( ModelMesh mesh in model.Meshes )
				foreach( ModelMeshPart mp in mesh.MeshParts )
					mp.Effect = effect;

		}

		public static void Draw( this Model model, Matrix World, Matrix View, Matrix Projection, BasicEffect effect ) {
			model.SetEffect( effect );

			Matrix[] bones = model.GetAboluteBoneTransforms();

			foreach( ModelMesh mesh in model.Meshes ) {
				foreach( BasicEffect eff in mesh.Effects ) {
					eff.World = bones[ mesh.ParentBone.Index ] * World;
					eff.View = View;
					eff.Projection = Projection;
				}
				mesh.Draw();
			}
		}

		public static void Draw( this Model model ) {
			Camera cam = Utility.Camera;
			model.Draw( Matrix.Identity, cam.View, cam.Projection );
		}

		public static void Draw( this Model model,
									 Matrix World ) {
			Camera cam = Utility.Camera;
			model.Draw( World, cam.View, cam.Projection );
		}

		public static void Draw( this Model model, Matrix World, Matrix View, Matrix Projection ) {
			Matrix[] bones = model.GetAboluteBoneTransforms();

			foreach( ModelMesh mesh in model.Meshes ) {
				for( int x = 0; x < mesh.Effects.Count; x++ ) {
					BasicEffect eff = mesh.Effects[ x ] as BasicEffect;
					if( eff != null ) {
						eff.World = bones[ mesh.ParentBone.Index ] * World;
						eff.View = View;
						eff.Projection = Projection;

						eff.EnableDefaultLighting();
						eff.TextureEnabled = true;
					}
				}
				mesh.Draw();
			}
		}

		public static void GetModelMeshTransform( ModelBone bone, ref Matrix mat ) {
			if( bone.Parent == null ) {
				mat = bone.Transform;
			} else {
				GetModelMeshTransform( bone.Parent, ref mat );

				mat = bone.Transform * mat;
			}
		}

		public static void DrawModelMesh( this Model model,	 ModelMesh mesh ) {
			Matrix mat = Matrix.Identity;

			GetModelMeshTransform( mesh.ParentBone, ref mat );

			Matrix View = Utility.Camera.View;
			Matrix Projection = Utility.Camera.Projection;

			for( int x = 0; x < mesh.Effects.Count; x++ ) {
				BasicEffect eff = mesh.Effects[ x ] as BasicEffect;
				if( eff != null ) {
					eff.World = mat;
					eff.View = View;
					eff.Projection = Projection;

					eff.LightingEnabled = true;
					eff.EnableDefaultLighting();
					eff.TextureEnabled = true;
					eff.VertexColorEnabled = true;
				}
			}
			mesh.Draw();
		}

		public static void DrawModelMeshBasic( this Model model, ModelMesh mesh ) {
			Matrix mat = Matrix.Identity;

			GetModelMeshTransform( mesh.ParentBone, ref mat );

			Matrix View = Utility.Camera.View;
			Matrix Projection = Utility.Camera.Projection;

			for( int x = 0; x < mesh.Effects.Count; x++ ) {
				BasicEffect eff = mesh.Effects[ x ] as BasicEffect;
				if( eff != null ) {
					eff.World = mat;
					eff.View = View;
					eff.Projection = Projection;

					eff.LightingEnabled = false;
					eff.TextureEnabled = false;
					eff.FogEnabled = false;
					eff.VertexColorEnabled = false;
				}
			}
			mesh.Draw();
		}

		public static void DrawDummy( this Model model, string dummyName, bool enableDepthBuffer ) {
			Matrix transform = model.GetAbsoluteBoneTransform( dummyName );
			VectorRenderer vectorRenderer = Utility.VectorRenderer;
			GraphicsDevice graphicsDevice = Utility.GraphicsDevice;

			vectorRenderer.SetColor( Color.Red );
			vectorRenderer.SetWorldMatrix( Utility.Camera.ViewProjection );
			vectorRenderer.SetWorldMatrix( transform );

			Vector3 scale, translation;
			Quaternion rot;
			transform.Decompose( out scale, out rot, out translation );

			bool depthWasEnabled = graphicsDevice.RenderState.DepthBufferEnable;
			graphicsDevice.RenderState.DepthBufferEnable = enableDepthBuffer;
			vectorRenderer.DrawBoundingBox(
				new BoundingBox( -Vector3.One * scale.Length() * 2.0f, Vector3.One * scale.Length() * 2.0f ) );

			vectorRenderer.SetColor( Color.Green );
			vectorRenderer.DrawLine( Vector3.Zero, transform.Up * scale.Length() * 2.0f );

			vectorRenderer.SetColor( Color.Yellow );
			vectorRenderer.DrawLine( Vector3.Zero, transform.Forward * scale.Length() * 2.0f );

			vectorRenderer.SetColor( Color.Blue );
			vectorRenderer.DrawLine( Vector3.Zero, transform.Right * scale.Length() * 2.0f );

			graphicsDevice.RenderState.DepthBufferEnable = depthWasEnabled;
		}

		public static int GetBoneIndexByName( this Model model, string boneName ) {
			for( int x = 0; x < model.Bones.Count; x++ )
				if( string.Compare( model.Bones[ x ].Name, boneName, true ) == 0 )
					return x;

			return -1;
		}

		public static Matrix GetAbsoluteBoneTransform( this Model model, string boneName ) {
			int boneIndex = model.GetBoneIndexByName( boneName );
			return GetAbsoluteBoneTransform( model, boneIndex );
		}

		public static Matrix GetAbsoluteBoneTransform( this Model model, int boneIndex ) {
			Matrix ret = Matrix.Identity;

			if( boneIndex != -1 ) {
				Matrix[] boneTransforms = model.GetAboluteBoneTransforms();

				ret = boneTransforms[ boneIndex ];
			}

			return ret;
		}

		public static Matrix[] GetAboluteBoneTransforms( this Model model ) {
			Matrix[] bones = new Matrix[ model.Bones.Count ];
			model.CopyAbsoluteBoneTransformsTo( bones );
			return bones;
		}

		public static int VertexCount( this Model model ) {
			int numVertices = 0;
			foreach( ModelMesh mesh in model.Meshes ) {
				numVertices += VertexCount( mesh );
			}
			return numVertices;
		}

		public static int VertexCount( this ModelMesh mesh ) {
			int numVertices = 0;
			foreach( ModelMeshPart meshPart in mesh.MeshParts )
				if( meshPart.VertexDeclaration.IsPositionDecl() )
					numVertices += meshPart.NumVertices;

			return numVertices;
		}

		public static int IndexCount( this Model model ) {
			int numIndices = 0;
			foreach( ModelMesh mesh in model.Meshes )
				numIndices += IndexCount( mesh );

			return numIndices;
		}

		public static int IndexCount( this ModelMesh mesh ) {
			int numIndices = 0;
			foreach( ModelMeshPart meshPart in mesh.MeshParts )
				numIndices += meshPart.PrimitiveCount * 3;

			return numIndices;
		}
	}
}
