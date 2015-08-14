using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Ragnarok3D.Editor {
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
			model = Editor.Content.Load<Model>( @"Models\\skybox" );
			LoadTextures( name );
			Editor.console.Add( "Skybox Initialized" );
		}

		public void LoadTextures( string skyName ) {
			name = skyName;

			try {
				skyBack = Editor.Content.Load<Texture2D>( @"Textures\Skybox\" + skyName + "_bk" );
				skyFront = Editor.Content.Load<Texture2D>( @"Textures\Skybox\" + skyName + "_ft" );
				skyDown = Editor.Content.Load<Texture2D>( @"Textures\Skybox\" + skyName + "_dn" );
				skyUp = Editor.Content.Load<Texture2D>( @"Textures\Skybox\" + skyName + "_up" );
				skyRight = Editor.Content.Load<Texture2D>( @"Textures\Skybox\" + skyName + "_lt" );
				skyLeft = Editor.Content.Load<Texture2D>( @"Textures\Skybox\" + skyName + "_rt" );
			} catch {
				Editor.console.Add( "Skybox not found: " + skyName );
				Editor.console.Add( "Loading default skybox" );
				LoadTextures( "clearblue" );
			}
		}

		public void Update( Vector3 cameraPosition ) {
			world = Matrix.CreateScale( scale ) * Matrix.CreateRotationX( MathHelper.ToRadians( -90f ) ) * Matrix.CreateTranslation( cameraPosition );
		}

		public void Draw( Matrix view, Matrix projection ) {
			Editor.graphics.GraphicsDevice.RenderState.FogEnable = false;
			Editor.graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullCounterClockwiseFace;

			foreach( ModelMesh mesh in model.Meshes ) {
				foreach( BasicEffect meshEffect in mesh.Effects ) {
					meshEffect.World = world;
					meshEffect.View = view;
					meshEffect.Projection = projection;
					meshEffect.TextureEnabled = true;
					meshEffect.LightingEnabled = false;

					switch( mesh.Name ) {
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
					meshEffect.CommitChanges();
				}

				mesh.Draw();
			}
		}
	}
}
