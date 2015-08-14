using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Tetris.Graphics;
using Tetris.Helpers;
using Tetris.Sounds;

namespace Tetris.Game {

	public class BaseGame : Microsoft.Xna.Framework.Game {
		protected static int width, height;
		protected static bool mPaused = false;

		protected GraphicsDeviceManager graphics;
		protected ContentManager content;
		protected SpriteFont CopyrightFont;
		protected SpriteBatch spriteBatch;
		private TextureFont font = null;

		public static int Width {
			get { return width; }
		}

		public static int Height {
			get { return height; }
		}

		public static bool Paused {
			get { return mPaused; }
			set { mPaused = value; }
		}


		public BaseGame() {
			graphics = new GraphicsDeviceManager(this);
			content = new ContentManager(Services, "Content");
		}


		protected override void Initialize() {
			width = graphics.GraphicsDevice.Viewport.Width;
			height = graphics.GraphicsDevice.Viewport.Height;

			base.Initialize();
		}

		/// <summary>
		/// Load all graphics content (just our background texture).
		/// Use this method to make sure a device reset event is handled correctly.
		/// </summary>
		/// <param name="loadAllContent">Load everything?</param>
		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			CopyrightFont = content.Load<SpriteFont>("Copyright");
			font = new TextureFont(graphics.GraphicsDevice, content);
			base.LoadContent();
		}

		/// <summary>
		/// Unload graphic content if the device gets lost.
		/// </summary>
		/// <param name="unloadAllContent">Unload everything?</param>
		protected override void UnloadContent() {
			content.Unload();
			SpriteHelper.Dispose();
		}

		protected override void Update(GameTime gameTime) {
			Sound.Update();
			Input.Update();

			// Exit using ESC
			if (Input.KeyboardEscapeJustPressed || Input.GamePadBackJustPressed) {
				this.Exit();
			}

			// Sound mute
			if (Input.KeyboardSounduteJustPressed) {
				Sound.MuteSound = !Sound.MuteSound;
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			SpriteHelper.DrawSprites(width, height);
			font.WriteAll();

			spriteBatch.Begin();
			spriteBatch.DrawString(CopyrightFont, "© 2011 by GodLesZ for Krönchen <3", new Vector2(10, Window.ClientBounds.Height - 18), Color.LightGray);
			if (Paused)
				spriteBatch.DrawString(CopyrightFont, "Pause", new Vector2(Window.ClientBounds.Width / 2 - 65, Window.ClientBounds.Height / 2 - 20), Color.White, 0, Vector2.Zero, 4f, SpriteEffects.None, 0);
			spriteBatch.End();

			base.Draw(gameTime);
		}

	}

}
