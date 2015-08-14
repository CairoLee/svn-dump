using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNATerrainHeightmap;

namespace FPSgame {

	public class Game1 : Game {
		private readonly GraphicsDeviceManager mGraphics;
		private SpriteBatch mSpriteBatch;

		private Renderer mRendererManager;
		private ParticlePreset mParticle;
		private XNATerrain mTerrain;
		private readonly Random mRand = new Random();

		private Texture2D mCrosshair;
		private Texture2D mScreen;
		private Bug[] mBugtest;
		private OBJ mGuntest;
		private MouseState mMouse;
		private int mTimeGun;
		private Vector2 mTargetCrosshair = new Vector2(1280 / 2, 768 / 2);
		private Vector3 mPositionHit;


		public Game1() {
			mGraphics = new GraphicsDeviceManager(this) {
				PreferredBackBufferWidth = 1280,
				PreferredBackBufferHeight = 768
			};
			mGraphics.PreparingDeviceSettings += GraphicsPreparingDeviceSettings;
			Content.RootDirectory = "Content";
		}


		private void GraphicsPreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e) {
			var pp = e.GraphicsDeviceInformation.PresentationParameters;
			var adapter = e.GraphicsDeviceInformation.Adapter;

			var dispFormat = adapter.CurrentDisplayMode.Format;
			var dephFormat = pp.DepthStencilFormat;

			SurfaceFormat selectedFormat;
			DepthFormat selectedDepthFormat;
			int selectedMultiSampleCount;
			if (adapter.QueryRenderTargetFormat(GraphicsProfile.HiDef, dispFormat, dephFormat, 4, out selectedFormat, out selectedDepthFormat, out selectedMultiSampleCount)) {
				pp.MultiSampleCount = 4;
			} else if (adapter.QueryRenderTargetFormat(GraphicsProfile.HiDef, dispFormat, dephFormat, 2, out selectedFormat, out selectedDepthFormat, out selectedMultiSampleCount)) {
				pp.MultiSampleCount = 2;
			}

		}


		protected override void Initialize() {
			mRendererManager = new Renderer(this);
			mParticle = new ParticlePreset(this, mRendererManager);

			base.Initialize();
		}


		protected override void LoadContent() {
			mBugtest = new Bug[30];

			for (int i = 0; i < mBugtest.Length; i++) {
				mBugtest[i] = new Bug(this, new Vector3(mRand.Next(-100, 100), 0, mRand.Next(-100, 100)), mRand);
			}

			mCrosshair = Content.Load<Texture2D>("Textures/crosshair");
			mScreen = Content.Load<Texture2D>("Textures/screen");

			mGuntest = new OBJ();
			mGuntest.Model = Content.Load<Model>("Models/gun/gun");
			mGuntest.Scale = new Vector3(0.1f);
			mGuntest.SetWorld();
			mGuntest.SkinningSetting("Idle");
			mGuntest.AnimationSpeed = 0.06f;

			mTerrain = Content.Load<XNATerrain>("Terrain/heightmap-512");
			mParticle.LoadContent(this);

			mSpriteBatch = new SpriteBatch(GraphicsDevice);
		}


		protected override void UnloadContent() {

		}


		private Ray CalculateCursorRay() {
			var viewMatrix = mRendererManager.Camera.View;
			var projectionMatrix = mRendererManager.Camera.Projection;
			var nearSource = new Vector3(mTargetCrosshair, 0f);
			var farSource = new Vector3(mTargetCrosshair, 1f);

			var nearPoint = mRendererManager.GraphicsDevice.Viewport.Unproject(nearSource, projectionMatrix, viewMatrix, Matrix.Identity);
			var farPoint = mRendererManager.GraphicsDevice.Viewport.Unproject(farSource, projectionMatrix, viewMatrix, Matrix.Identity);
			var direction = farPoint - nearPoint;
			direction.Normalize();

			return new Ray(nearPoint, direction);
		}

		private void CheckBulletHit(Ray ray) {
			foreach (Bug t in mBugtest) {
				if (t == null) {
					continue;
				}
				if (!RayIntersectsModel(t.Bound, ray)) {
					continue;
				}

				mParticle.ParticleBlood(mPositionHit, Vector3.One);
				mParticle.ParticleSmokeBlood(mPositionHit, Vector3.One);

				t.HP -= 50;
			}
		}

		private bool RayIntersectsModel(BoundingSphere sphere, Ray ray) {
			float? result;
			ray.Intersects(ref sphere, out result);
			result = ray.Intersects(sphere);
			if (result.HasValue) {
				var distance = result.Value;
				var collisionPoint = ray.Position + ray.Direction * distance;
				mPositionHit = collisionPoint;
				return true;
			}

			return false;
		}


		protected override void Update(GameTime gameTime) {
			mMouse = Mouse.GetState();
			mRendererManager.Update(gameTime);
			mParticle.Update(gameTime, mRendererManager, 1);

			foreach (Bug t in mBugtest) {
				if (t == null) {
					continue;
				}

				//bugtest[i].Target = RendererManager.Camera.Position;
				t.Update(gameTime);
				if (mTerrain.IsOnHeightmap(t.Position)) {
					mTerrain.GetHeightAndNormal(t.Position, out t.Position.Y, out t.Normal);
				}
			}

			if (mMouse.LeftButton == ButtonState.Pressed) {
				if (mTimeGun >= 5) {
					mGuntest.PlayAnimation("Fire", "Idle", 15);
					Matrix offset = Matrix.CreateTranslation(new Vector3(-2, -1, 50)) * mGuntest.World;
					mParticle.ParticleGunFlash(offset.Translation);

					mTimeGun = 0;
					CheckBulletHit(CalculateCursorRay());
				}
			}

			mTimeGun += 1;

			mGuntest.Rotation.Y = -mRendererManager.Camera.Angle.Y + (float)Math.PI;
			mGuntest.Rotation.X = mRendererManager.Camera.Angle.X;
			mGuntest.Position = mRendererManager.Camera.Position;
			mGuntest.UpdateSkinngin(gameTime, false);

			Vector3 camNormal;
			float heigth;
			mTerrain.GetHeightAndNormal(mRendererManager.Camera.Position, out heigth, out camNormal);
			mRendererManager.Camera.Position.Y = heigth + 5;

			base.Update(gameTime);
		}



		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(new Color(new Vector3(0.45f, 0.43f, 0.4f) * 2));

			mRendererManager.DrawModel(mTerrain.Model, mTerrain.World);
			//mSpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.SaveState);
			//mGraphics.GraphicsDevice.RenderState.DepthBufferWriteEnable = true;
			//mGraphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
			mSpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
			/*
			mGraphics.GraphicsDevice.DepthStencilState = new DepthStencilState() {
				DepthBufferWriteEnable = true,
				DepthBufferEnable = true
			};
			*/
			foreach (Bug t in mBugtest) {
				if (t != null) {
					mRendererManager.DrawSkinModel(t);
				}
			}

			mRendererManager.DrawSkinModel(mGuntest);

			mParticle.Draw(gameTime, mRendererManager);
			/*
			mGraphics.GraphicsDevice.DepthStencilState = new DepthStencilState() {
				DepthBufferEnable = true
			};
			*/
			mSpriteBatch.End();

			//mSpriteBatch.Begin(SpriteBlendMode.Additive, SpriteSortMode.Immediate, SaveStateMode.SaveState);
			//mGraphics.GraphicsDevice.RenderState.DepthBufferWriteEnable = true;
			//mGraphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
			mSpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
			/*
			mGraphics.GraphicsDevice.DepthStencilState = new DepthStencilState() {
				DepthBufferWriteEnable = true,
				DepthBufferEnable = true
			};

			mParticle.DrawAdditive(gameTime, mRendererManager);
			*/
			mSpriteBatch.End();


			//mSpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.SaveState);
			mSpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
			mSpriteBatch.Draw(mCrosshair, new Vector2(mTargetCrosshair.X - mCrosshair.Width / 2, mTargetCrosshair.Y - mCrosshair.Height / 2), Color.White);
			mSpriteBatch.Draw(mScreen, Vector2.Zero, Color.White);

			mSpriteBatch.End();
			base.Draw(gameTime);
		}

	}

}
