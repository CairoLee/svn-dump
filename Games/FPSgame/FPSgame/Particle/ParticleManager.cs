using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FPSgame {

	public class ParticleManager {
		private static readonly Vector2 mUpperLeft = new Vector2(0, 0);
		private static readonly Vector2 mUpperRight = new Vector2(1, 0);
		private static readonly Vector2 mBottomLeft = new Vector2(0, 1);
		private static readonly Vector2 mBottomRight = new Vector2(1, 1);

		private readonly Particle[] mParticle;
		private readonly Particle[] mParticleDis;
		private readonly Particle[] mParticleMesh;

		public Model[] Modelset;
		private int mNumParticle = 0;
		private int mNumParticleMesh = 0;

		public Texture2D[] Textureset = new Texture2D[100];
		public Random Rand = new Random();
		public Effect Shader;
		public Effect ShaderTail;
		public Texture2D[] NormTexture = new Texture2D[100];
		public Renderer Renderer;
		public Game Game;


		public ParticleManager(Game game, Renderer renderer) {
			this.Renderer = renderer;
			Game = game;
			mParticle = new Particle[1000];
			mParticleDis = new Particle[20];
			mParticleMesh = new Particle[20];
			Modelset = new Model[100];
		}


		public virtual void LoadContent(Game game) {
		}


		public void AddParticleMesh(int Nummodel, int[] particleNode, Vector3 position, Vector3 power1, Vector3 power2, Vector3 scale, Vector3 scaleup1, Vector3 scaleup2, Vector3 rotation, Vector3 rotationup1, Vector3 rotationup2, int lifeTime) {
			mNumParticleMesh = (mNumParticleMesh + 1) % mParticleMesh.Length;
			mParticleMesh[mNumParticleMesh].Active = true;
			mParticleMesh[mNumParticleMesh].Model = Modelset[Nummodel];
			mParticleMesh[mNumParticleMesh].Position = position;
			mParticleMesh[mNumParticleMesh].PowerUp1 = power1;
			mParticleMesh[mNumParticleMesh].PowerUp2 = power2;
			mParticleMesh[mNumParticleMesh].Rotation = rotation;
			mParticleMesh[mNumParticleMesh].RotationUp1 = rotationup1;
			mParticleMesh[mNumParticleMesh].RotationUp2 = rotationup2;
			mParticleMesh[mNumParticleMesh].Scale = scale;
			mParticleMesh[mNumParticleMesh].ScaleUp1 = scaleup1;
			mParticleMesh[mNumParticleMesh].ScaleUp2 = scaleup2;
			mParticleMesh[mNumParticleMesh].LifeTime = lifeTime;
			mParticleMesh[mNumParticleMesh].ParticleNodes = particleNode;
			mParticleMesh[mNumParticleMesh].AdditiveRender = false;
		}

		public void AddParticle(int Nummodel, int Numtexture, Vector3 position, Vector3 power1, Vector3 power2, Vector3 scale, Vector3 scaleup1, Vector3 scaleup2, Vector3 rotation, Vector3 rotationup1, Vector3 rotationup2, float alpha, float alphaUp1, float alphaup2, Vector3 basecolor, Vector3 basecolorUp1, Vector3 basecolorUp2, int lifeTime, bool add, int tech) {
			mNumParticle = (mNumParticle + 1) % mParticle.Length;
			mParticle[mNumParticle].Active = true;

			mParticle[mNumParticle].Model = Modelset[Nummodel];
			mParticle[mNumParticle].Texture = Textureset[Numtexture];
			mParticle[mNumParticle].Position = position;
			mParticle[mNumParticle].PowerUp1 = power1;
			mParticle[mNumParticle].PowerUp2 = power2;
			mParticle[mNumParticle].Rotation = rotation;
			mParticle[mNumParticle].RotationUp1 = rotationup1;
			mParticle[mNumParticle].RotationUp2 = rotationup2;
			mParticle[mNumParticle].Scale = scale;
			mParticle[mNumParticle].ScaleUp1 = scaleup1;
			mParticle[mNumParticle].ScaleUp2 = scaleup2;
			mParticle[mNumParticle].Alpha = alpha;
			mParticle[mNumParticle].AlphaUp1 = alphaUp1;
			mParticle[mNumParticle].AlphaUp2 = alphaup2;
			mParticle[mNumParticle].BaseColor = basecolor;
			mParticle[mNumParticle].BaseColorUp1 = basecolorUp1;
			mParticle[mNumParticle].BaseColorUp2 = basecolorUp2;
			mParticle[mNumParticle].AdditiveRender = add;
			mParticle[mNumParticle].LifeTime = lifeTime;
			mParticle[mNumParticle].Technic = tech;
		}


		private static VertexPositionTexture[] CreateQuadVertices(int width, int height) {
			int halfWidth = width / 2;
			int halfHeight = height / 2;

			VertexPositionTexture[] vertices = new VertexPositionTexture[4];

			vertices[0] = new VertexPositionTexture(new Vector3(-halfWidth, halfHeight, 0), mUpperLeft);
			vertices[1] = new VertexPositionTexture(new Vector3(halfWidth, halfHeight, 0), mUpperRight);
			vertices[2] = new VertexPositionTexture(new Vector3(-halfWidth, -halfHeight, 0), mBottomLeft);
			vertices[3] = new VertexPositionTexture(new Vector3(halfWidth, -halfHeight, 0), mBottomRight);

			return vertices;
		}


		public void Update(GameTime gameTime, Renderer renderer, float slowTime) {
			for (int i = 0; i < mParticle.Length; i++) {
				if (!mParticle[i].Active) {
					mParticle[i].Scale = Vector3.Zero;
					mParticle[i].World = Matrix.CreateScale(mParticle[i].Scale) * Matrix.CreateRotationZ(mParticle[i].Rotation.Z) * Matrix.CreateBillboard(mParticle[i].Position, renderer.Camera.Position, Vector3.Up, Vector3.Forward);

					continue;
				}

				mParticle[i].Position.X += mParticle[i].PowerUp1.X * slowTime;
				mParticle[i].Position.Y += mParticle[i].PowerUp1.Y * slowTime;
				mParticle[i].Position.Z += mParticle[i].PowerUp1.Z * slowTime;

				mParticle[i].Rotation.X += mParticle[i].RotationUp1.X * slowTime;
				mParticle[i].Rotation.Y += mParticle[i].RotationUp1.Y * slowTime;
				mParticle[i].Rotation.Z += mParticle[i].RotationUp1.Z * slowTime;

				mParticle[i].Scale.X += mParticle[i].ScaleUp1.X * slowTime;
				mParticle[i].Scale.Y += mParticle[i].ScaleUp1.Y * slowTime;
				mParticle[i].Scale.Z += mParticle[i].ScaleUp1.Z * slowTime;

				mParticle[i].Alpha += mParticle[i].AlphaUp1 * slowTime;

				mParticle[i].PowerUp1.X += mParticle[i].PowerUp2.X * slowTime;
				mParticle[i].PowerUp1.Y += mParticle[i].PowerUp2.Y * slowTime;
				mParticle[i].PowerUp1.Z += mParticle[i].PowerUp2.Z * slowTime;


				mParticle[i].RotationUp1.X += mParticle[i].RotationUp2.X * slowTime;
				mParticle[i].RotationUp1.Y += mParticle[i].RotationUp2.Y * slowTime;
				mParticle[i].RotationUp1.Z += mParticle[i].RotationUp2.Z * slowTime;


				mParticle[i].ScaleUp1.X += mParticle[i].ScaleUp2.X * slowTime;
				mParticle[i].ScaleUp1.Y += mParticle[i].ScaleUp2.Y * slowTime;
				mParticle[i].ScaleUp1.Z += mParticle[i].ScaleUp2.Z * slowTime;


				mParticle[i].AlphaUp1 += mParticle[i].AlphaUp2 * slowTime;

				mParticle[i].BaseColor.X += mParticle[i].BaseColorUp1.X * slowTime;
				mParticle[i].BaseColor.Y += mParticle[i].BaseColorUp1.Y * slowTime;
				mParticle[i].BaseColor.Z += mParticle[i].BaseColorUp1.Z * slowTime;

				mParticle[i].BaseColorUp1.X += mParticle[i].BaseColorUp2.X * slowTime;
				mParticle[i].BaseColorUp1.Y += mParticle[i].BaseColorUp2.Y * slowTime;
				mParticle[i].BaseColorUp1.Z += mParticle[i].BaseColorUp2.Z * slowTime;

				mParticle[i].World = Matrix.CreateScale(mParticle[i].Scale) * Matrix.CreateRotationZ(mParticle[i].Rotation.Z) * Matrix.CreateBillboard(mParticle[i].Position, renderer.Camera.Position, Vector3.Up, Vector3.Forward);
				mParticle[i].LifeTime -= 1 * slowTime;
				if (mParticle[i].LifeTime <= 0 || mParticle[i].Alpha <= 0.01f) {
					mParticle[i].Reset();
				}
			}


			for (int i = 0; i < mParticleMesh.Length; i++) {
				if (!mParticleMesh[i].Active) {
					continue;
				}

				mParticleMesh[i].Position.X += mParticleMesh[i].PowerUp1.X * slowTime;
				mParticleMesh[i].Position.Y += mParticleMesh[i].PowerUp1.Y * slowTime;
				mParticleMesh[i].Position.Z += mParticleMesh[i].PowerUp1.Z * slowTime;

				mParticleMesh[i].Rotation.X += mParticleMesh[i].RotationUp1.X * slowTime;
				mParticleMesh[i].Rotation.Y += mParticleMesh[i].RotationUp1.Y * slowTime;
				mParticleMesh[i].Rotation.Z += mParticleMesh[i].RotationUp1.Z * slowTime;

				mParticleMesh[i].Scale.X += mParticleMesh[i].ScaleUp1.X * slowTime;
				mParticleMesh[i].Scale.Y += mParticleMesh[i].ScaleUp1.Y * slowTime;
				mParticleMesh[i].Scale.Z += mParticleMesh[i].ScaleUp1.Z * slowTime;

				mParticleMesh[i].PowerUp1.X += mParticleMesh[i].PowerUp2.X * slowTime;
				mParticleMesh[i].PowerUp1.Y += mParticleMesh[i].PowerUp2.Y * slowTime;
				mParticleMesh[i].PowerUp1.Z += mParticleMesh[i].PowerUp2.Z * slowTime;


				mParticleMesh[i].RotationUp1.X += mParticleMesh[i].RotationUp2.X * slowTime;
				mParticleMesh[i].RotationUp1.Y += mParticleMesh[i].RotationUp2.Y * slowTime;
				mParticleMesh[i].RotationUp1.Z += mParticleMesh[i].RotationUp2.Z * slowTime;


				mParticleMesh[i].ScaleUp1.X += mParticleMesh[i].ScaleUp2.X * slowTime;
				mParticleMesh[i].ScaleUp1.Y += mParticleMesh[i].ScaleUp2.Y * slowTime;
				mParticleMesh[i].ScaleUp1.Z += mParticleMesh[i].ScaleUp2.Z * slowTime;

				mParticleMesh[i].World = Matrix.CreateScale(mParticleMesh[i].Scale) *Matrix.CreateRotationZ(mParticleMesh[i].Rotation.Z) *Matrix.CreateBillboard(mParticleMesh[i].Position, renderer.Camera.Position, Vector3.Up, Vector3.Forward);
				mParticleMesh[i].LifeTime -= 1 * slowTime;
				if (mParticleMesh[i].LifeTime <= 0) {
					mParticleMesh[i].Reset();
				}
			}


			for (int i = 0; i < mParticleDis.Length; i++) {
				if (!mParticleDis[i].Active) {
					continue;
				}

				mParticleDis[i].Position.X += mParticleDis[i].PowerUp1.X * slowTime;
				mParticleDis[i].Position.Y += mParticleDis[i].PowerUp1.Y * slowTime;
				mParticleDis[i].Position.Z += mParticleDis[i].PowerUp1.Z * slowTime;

				mParticleDis[i].Rotation.X += mParticleDis[i].RotationUp1.X * slowTime;
				mParticleDis[i].Rotation.Y += mParticleDis[i].RotationUp1.Y * slowTime;
				mParticleDis[i].Rotation.Z += mParticleDis[i].RotationUp1.Z * slowTime;

				mParticleDis[i].Scale.X += mParticleDis[i].ScaleUp1.X * slowTime;
				mParticleDis[i].Scale.Y += mParticleDis[i].ScaleUp1.Y * slowTime;
				mParticleDis[i].Scale.Z += mParticleDis[i].ScaleUp1.Z * slowTime;

				mParticleDis[i].Alpha += mParticleDis[i].AlphaUp1 * slowTime;

				mParticleDis[i].PowerUp1.X += mParticleDis[i].PowerUp2.X * slowTime;
				mParticleDis[i].PowerUp1.Y += mParticleDis[i].PowerUp2.Y * slowTime;
				mParticleDis[i].PowerUp1.Z += mParticleDis[i].PowerUp2.Z * slowTime;


				mParticleDis[i].RotationUp1.X += mParticleDis[i].RotationUp2.X * slowTime;
				mParticleDis[i].RotationUp1.Y += mParticleDis[i].RotationUp2.Y * slowTime;
				mParticleDis[i].RotationUp1.Z += mParticleDis[i].RotationUp2.Z * slowTime;


				mParticleDis[i].ScaleUp1.X += mParticleDis[i].ScaleUp2.X * slowTime;
				mParticleDis[i].ScaleUp1.Y += mParticleDis[i].ScaleUp2.Y * slowTime;
				mParticleDis[i].ScaleUp1.Z += mParticleDis[i].ScaleUp2.Z * slowTime;


				mParticleDis[i].AlphaUp1 += mParticleDis[i].AlphaUp2 * slowTime;

				mParticleDis[i].BaseColor.X += mParticleDis[i].BaseColorUp1.X * slowTime;
				mParticleDis[i].BaseColor.Y += mParticleDis[i].BaseColorUp1.Y * slowTime;
				mParticleDis[i].BaseColor.Z += mParticleDis[i].BaseColorUp1.Z * slowTime;

				mParticleDis[i].BaseColorUp1.X += mParticleDis[i].BaseColorUp2.X * slowTime;
				mParticleDis[i].BaseColorUp1.Y += mParticleDis[i].BaseColorUp2.Y * slowTime;
				mParticleDis[i].BaseColorUp1.Z += mParticleDis[i].BaseColorUp2.Z * slowTime;

				mParticleDis[i].World = Matrix.CreateScale(mParticleDis[i].Scale) *Matrix.CreateRotationZ(mParticleDis[i].Rotation.Z) *Matrix.CreateBillboard(mParticleDis[i].Position, renderer.Camera.Position, Vector3.Up, Vector3.Forward);
				mParticleDis[i].LifeTime -= 1 * slowTime;
				if (mParticleDis[i].LifeTime <= 0 || mParticleDis[i].Alpha <= 0.01f) {
					mParticleDis[i].Reset();
				}
			}

		}


		public void Draw(GameTime gameTime, Renderer renderer) {
			renderer.GraphicsDevice.DepthStencilState = new DepthStencilState() {
				DepthBufferWriteEnable = false
			};

			for (int i = 0; i < mParticle.Length; i++) {
				if (!mParticle[i].Active || mParticle[i].AdditiveRender) {
					continue;
				}
				DrawModel(ref mParticle[i], renderer, true);
			}
		}


		public void DrawMesh(GameTime gameTime, Renderer renderer) {
			for (int i = 0; i < mParticleMesh.Length; i++) {
				if (mParticleMesh[i].Active && !mParticleMesh[i].AdditiveRender) {
					DrawModel(ref mParticleMesh[i], renderer, false);
				}
			}
		}

		public void DrawAdditive(GameTime gameTime, Renderer renderer) {
			renderer.GraphicsDevice.DepthStencilState = new DepthStencilState() {
				DepthBufferWriteEnable = false
			};
			for (int i = 0; i < mParticle.Length; i++) {
				if (mParticle[i].Active && mParticle[i].AdditiveRender) {
					DrawModel(ref mParticle[i], renderer, true);
				}
			}
		}

		private void DrawModel(ref Particle particle, Renderer renderer, bool texturepath) {
			foreach (ModelMesh mesh in particle.Model.Meshes) {
				foreach (BasicEffect effect in mesh.Effects) {
					effect.EnableDefaultLighting();

					effect.View = renderer.Camera.View;
					effect.Projection = renderer.Camera.Projection;
					effect.World = particle.World;
					effect.Alpha = particle.Alpha;
					if (texturepath) {
						effect.Texture = particle.Texture;
					}
					effect.TextureEnabled = true;
					effect.FogEnabled = true;
					effect.FogEnd = 200;
					effect.FogStart = 1;
					effect.FogColor = renderer.FogColor;
				}
				mesh.Draw();
			}

		}

	}

}
