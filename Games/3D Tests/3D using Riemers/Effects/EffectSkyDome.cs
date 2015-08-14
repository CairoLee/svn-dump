using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace Engine3DFromRiemersTutorial {
	public class EffectSkyDome : EffectComponent, IViewDrawable {
		EffectPerlinNoise mNoise;
		Model mSkyDome;
		Camera mCamera;

		public EffectSkyDome( Game game, Camera cam, EffectPerlinNoise noise )
			: base( game ) {
			mCamera = cam;
			mNoise = noise;
		}

		protected override void LoadContent() {
			mSkyDome = Game.Content.Load<Model>( @"Model\dome" );
			mSkyDome.Meshes[ 0 ].MeshParts[ 0 ].Effect = effect.Clone( GraphicsDevice );
			base.LoadContent();
		}

		public void Draw( Matrix viewMatrix ) {
			GraphicsDevice.RenderState.DepthBufferWriteEnable = false;

			Matrix[] modelTransforms = new Matrix[ mSkyDome.Bones.Count ];
			mSkyDome.CopyAbsoluteBoneTransformsTo( modelTransforms );

			Matrix wMatrix = Matrix.CreateTranslation( 0, -0.30f, 0 )
						   * Matrix.CreateScale( 300 )
						   * Matrix.CreateTranslation( mCamera.Position );
			foreach( ModelMesh mesh in mSkyDome.Meshes ) {
				foreach( Effect currentEffect in mesh.Effects ) {
					Matrix worldMatrix = modelTransforms[ mesh.ParentBone.Index ] * wMatrix;
					currentEffect.CurrentTechnique = currentEffect.Techniques[ "SkyDome" ];
					currentEffect.Parameters[ "xWorld" ].SetValue( worldMatrix );
					currentEffect.Parameters[ "xView" ].SetValue( viewMatrix );
					currentEffect.Parameters[ "xProjection" ].SetValue( mCamera.ProjectionMatrix );
					currentEffect.Parameters[ "xTexture" ].SetValue( mNoise.Texture );
					currentEffect.Parameters[ "xEnableLighting" ].SetValue( false );
				}
				mesh.Draw();
			}
			GraphicsDevice.RenderState.DepthBufferWriteEnable = true;

		}

		public override void Draw( GameTime gameTime ) {
			Draw( mCamera.ViewMatrix );
		}

	}
}