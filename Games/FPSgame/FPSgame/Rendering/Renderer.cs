using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace FPSgame {

	public class Renderer {

		public FreeCamera Camera;
		public Vector3 LightColor;
		public Vector3 FogColor;
		public GraphicsDevice GraphicsDevice;


		public Renderer(Game game) {
			Vector2 screensize = new Vector2(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
			Camera = new FreeCamera(Vector3.Zero, 0.3f, 15, screensize);
			FogColor = new Vector3(0.45f, 0.43f, 0.4f) * 2;
			LightColor = new Vector3(0.9f, 0.9f, 0.9f);
			GraphicsDevice = game.GraphicsDevice;
		}



		public void Update(GameTime gameTime) {
			Camera.Update((float)gameTime.TotalGameTime.TotalSeconds);
		}

		public void DrawModel(OBJ obj) {

			Matrix[] transforms = new Matrix[obj.Model.Bones.Count];
			obj.Model.CopyAbsoluteBoneTransformsTo(transforms);


			foreach (ModelMesh mesh in obj.Model.Meshes) {
				foreach (BasicEffect effect in mesh.Effects) {
					effect.EnableDefaultLighting();

					effect.View = Camera.View;
					effect.Projection = Camera.Projection;
					effect.World = obj.World * transforms[mesh.ParentBone.Index];

					effect.DirectionalLight0.Direction = new Vector3(1, -1, 1);
					effect.DirectionalLight0.Enabled = true;
					effect.DirectionalLight0.DiffuseColor = LightColor;

					effect.DirectionalLight1.Direction = new Vector3(-1, -1, -1);
					effect.DirectionalLight1.Enabled = true;
					effect.DirectionalLight1.DiffuseColor = new Vector3(0.1f, 0.4f, 0.8f);

					effect.DirectionalLight2.Direction = new Vector3(-1, -1, 1);
					effect.DirectionalLight2.Enabled = true;
					effect.DirectionalLight2.DiffuseColor = new Vector3(0.7f, 0.5f, 0.3f);


					effect.FogEnabled = true;
					effect.FogEnd = 200;
					effect.FogStart = 1;
					effect.FogColor = FogColor;


					effect.DiffuseColor = new Vector3(0.9f, 0.9f, 0.9f);
					effect.SpecularColor = new Vector3(0.01f, 0.01f, 0.01f);
					effect.SpecularPower = 20;
					effect.LightingEnabled = true;
					effect.PreferPerPixelLighting = true;
				}
				mesh.Draw();
			}
		}

		public void DrawModel(Model model, Matrix world) {

			Matrix[] transforms = new Matrix[model.Bones.Count];
			model.CopyAbsoluteBoneTransformsTo(transforms);

			foreach (ModelMesh mesh in model.Meshes) {
				foreach (BasicEffect effect in mesh.Effects) {
					effect.EnableDefaultLighting();

					effect.View = Camera.View;
					effect.Projection = Camera.Projection;
					effect.World = world * transforms[mesh.ParentBone.Index];

					effect.DirectionalLight0.Direction = new Vector3(1, -1, 1);
					effect.DirectionalLight0.Enabled = true;
					effect.DirectionalLight0.DiffuseColor = LightColor;

					effect.DirectionalLight1.Direction = new Vector3(-1, -1, -1);
					effect.DirectionalLight1.Enabled = true;
					effect.DirectionalLight1.DiffuseColor = new Vector3(0.1f, 0.4f, 0.8f);

					effect.DirectionalLight2.Direction = new Vector3(-1, -1, 1);
					effect.DirectionalLight2.Enabled = true;
					effect.DirectionalLight2.DiffuseColor = new Vector3(0.7f, 0.5f, 0.3f);

					effect.FogEnabled = true;
					effect.FogEnd = 200;
					effect.FogStart = 1;
					effect.FogColor = new Vector3(0.45f, 0.43f, 0.4f) * 2;

					effect.DiffuseColor = new Vector3(0.9f, 0.9f, 0.9f);
					effect.SpecularColor = new Vector3(0.01f, 0.01f, 0.01f);
					effect.SpecularPower = 20;
					effect.LightingEnabled = true;
					effect.PreferPerPixelLighting = true;
				}
				mesh.Draw();
			}
		}

		public void DrawSkinModel(OBJ obj) {

			foreach (ModelMesh mesh in obj.Model.Meshes) {
				foreach (Effect effect in mesh.Effects) {
					effect.Parameters["Bones"].SetValue(obj.AnimationPlayer.GetSkinTransforms());
					effect.Parameters["View"].SetValue(Camera.View);
					effect.Parameters["Projection"].SetValue(Camera.Projection);
					effect.Parameters["CameraPosition"].SetValue(Camera.Position);
					effect.Parameters["FogColor"].SetValue(FogColor);
					effect.Parameters["FogNear"].SetValue(1);
					effect.Parameters["FogFar"].SetValue(200);
				}

				mesh.Draw();
			}

		}

	}

}
