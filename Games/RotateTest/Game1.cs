using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RotateTest {
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game {
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public Game1() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		private Vector2[] myVectors;
		private Vector2[] drawVectors;
		protected override void Initialize() {
			// TODO: Add your initialization logic here.
			myVectors = new Vector2[9];
			drawVectors = new Vector2[9];

			base.Initialize();
		}

		private Texture2D SpriteTexture;
		private SpriteBatch ForegroundBatch;
		private Vector2 origin;
		private Vector2 screenpos;
		protected override void LoadContent() {
			// TODO: Load any ResourceManagementMode.Automatic content.
			ForegroundBatch = new SpriteBatch(graphics.GraphicsDevice);
			SpriteTexture = Content.Load<Texture2D>("1002");
			origin.X = SpriteTexture.Width / 2;
			origin.Y = SpriteTexture.Height / 2;
			Viewport viewport = graphics.GraphicsDevice.Viewport;
			screenpos.X = viewport.Width / 2;
			screenpos.Y = viewport.Height / 2;
			// Create unrotated texture locations.
			float texsize = SpriteTexture.Height;
			float[] points = { -texsize, 0, texsize };
			Vector2 offset = Vector2.Zero;

			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 1; j++) {
					offset.X = points[i];
					offset.Y = points[j];
					myVectors[(i * 3) + j] = Vector2.Add(screenpos, offset);
				}

			// TODO: Load any ResourceManagementMode.Manual content.
		}


		protected override void UnloadContent() {
			Content.Unload();
		}


		private float RotationAngle = 0f;
		private Matrix rotationMatrix = Matrix.Identity;
		protected override void Update(GameTime gameTime) {
			// Allows the default game to exit on Xbox 360 and Windows.
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

			RotationAngle += elapsed;
			float circle = MathHelper.Pi * 2;
			RotationAngle = RotationAngle % circle;

			// Copy and rotate the sprite positions.
			drawVectors = (Vector2[])myVectors.Clone();

			UpdateMatrix(ref screenpos, RotationAngle);

			base.Update(gameTime);
		}

		private void UpdateMatrix(ref Vector2 origin, float radians) {
			// Translate sprites to center around screen (0,0), rotate them, and
			// translate them back to their original positions
			Vector3 matrixorigin = new Vector3(origin, 0);
			rotationMatrix = Matrix.Identity * Matrix.Identity * Matrix.CreatePerspective(0.6f, 0.6f, 1.0f, 100.0f);
		}

		protected override void Draw(GameTime gameTime) {
			DrawMatrix();
			base.Draw(gameTime);
		}

		private void DrawMatrix() {
			graphics.GraphicsDevice.Clear(Color.Black);
			// Draw using a rotation matrix with SpriteBatch
			ForegroundBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, rotationMatrix);
			for (int j = 0; j < myVectors.Length; j++)
				ForegroundBatch.Draw(SpriteTexture, myVectors[j], null, Color.White, 0,
					origin, 1.0f, SpriteEffects.None, 0f);
			ForegroundBatch.End();
		}

	}

}
