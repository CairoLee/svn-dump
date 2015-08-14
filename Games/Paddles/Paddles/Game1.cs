using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Paddles {

	public class Game1 : Microsoft.Xna.Framework.Game {
		GraphicsDeviceManager graphics;
		ContentManager content;
		ScreenManager sManager;

		public static SpriteBatch sBatch;
		public static Texture2D pixel;
		public static SpriteFont gSFont;
		public static Vector2 windowSize;

		public static bool quit;

		public Game1() {
			graphics = new GraphicsDeviceManager(this);
			content = new ContentManager(Services, "Content");
		}


		protected override void Initialize() {
			windowSize = new Vector2((float)Window.ClientBounds.Width, (float)Window.ClientBounds.Height);
			quit = false;

			base.Initialize();
		}


		protected override void LoadContent() {
			sBatch = new SpriteBatch(graphics.GraphicsDevice);
			pixel = content.Load<Texture2D>("singlePixel");
			gSFont = content.Load<SpriteFont>("gSFont");

			sManager = new ScreenManager(this);
			this.Components.Add(sManager);
		}


		protected override void UnloadContent() {
			content.Unload();
		}


		protected override void Update(GameTime gameTime) {
			if (Keyboard.GetState().IsKeyDown(Keys.Escape) || quit)
				this.Exit();

			base.Update(gameTime);
		}


		protected override void Draw(GameTime gameTime) {
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			sBatch.Begin();

			base.Draw(gameTime);
			sBatch.End();
		}

	}

}
