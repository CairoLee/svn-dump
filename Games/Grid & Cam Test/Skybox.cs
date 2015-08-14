using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cam_Test {

	public class Skybox {
		Texture2D skyUp;
		Texture2D skyDown;
		Texture2D skyLeft;
		Texture2D skyRight;
		Texture2D skyFront;
		Texture2D skyBack;

		Model model;

		Matrix world;
		float scale = 100f;

		public string name = "clearblue";

		public Skybox() {
			model = CamTest.content.Load<Model>(@"Skybox\skybox");
			LoadTextures(name);
		}

		public void LoadTextures(string skyName) {
			name = skyName;

			try {
				skyBack = CamTest.content.Load<Texture2D>(@"Skybox\" + skyName + "_bk");
				skyFront = CamTest.content.Load<Texture2D>(@"Skybox\" + skyName + "_ft");
				skyDown = CamTest.content.Load<Texture2D>(@"Skybox\" + skyName + "_dn");
				skyUp = CamTest.content.Load<Texture2D>(@"Skybox\" + skyName + "_up");
				skyRight = CamTest.content.Load<Texture2D>(@"Skybox\" + skyName + "_lt");
				skyLeft = CamTest.content.Load<Texture2D>(@"Skybox\" + skyName + "_rt");
			} catch {
			}
		}

		public void Update(Vector3 cameraPosition) {
			world = Matrix.CreateScale(scale) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateTranslation(cameraPosition);
		}

		public void Draw(Matrix view, Matrix projection) {
			//CamTest.graphics.GraphicsDevice.RenderState.FogEnable = false;
			CamTest.graphics.GraphicsDevice.RasterizerState = new RasterizerState {
				CullMode = Microsoft.Xna.Framework.Graphics.CullMode.CullCounterClockwiseFace
			};

			foreach (ModelMesh mesh in model.Meshes) {
				foreach (BasicEffect meshEffect in mesh.Effects) {
					meshEffect.World = world;
					meshEffect.View = view;
					meshEffect.Projection = projection;
					meshEffect.TextureEnabled = true;
					meshEffect.LightingEnabled = false;

					switch (mesh.Name) {
						case "up":
							meshEffect.Texture = skyUp;
							break;
						case "left":
							meshEffect.Texture = skyLeft;
							break;
						case "right":
							meshEffect.Texture = skyRight;
							break;
						case "back":
							meshEffect.Texture = skyBack;
							break;
						case "front":
							meshEffect.Texture = skyFront;
							break;
						case "down":
							meshEffect.Texture = skyDown;
							break;
					}

					meshEffect.DiffuseColor = Vector3.One;
				}

				mesh.Draw();
			}
		}
	}
}
