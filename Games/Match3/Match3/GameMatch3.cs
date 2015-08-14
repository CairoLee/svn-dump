using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GodLesZ.Games.Match3 {

	public class GameMatch3 : Game {

		private readonly GraphicsDeviceManager mGraphics;
		private Sprite mBackground;
		private SpriteFont mFont;
		private Texture2D mForeground;
		private InputHelper mInputState;
		private SpriteBatch mSpriteBatch;


		public GameMatch3() {
			mGraphics = new GraphicsDeviceManager(this) {
				PreferredBackBufferHeight = 480,
				PreferredBackBufferWidth = 640
			};
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}


		protected override void Initialize() {
			mSpriteBatch = new SpriteBatch(GraphicsDevice);
			Services.AddService(mSpriteBatch);
			
			mInputState = new InputHelper();
			Services.AddService(mInputState);

			Components.Add(new Board(this));

			base.Initialize();
		}

		protected override void LoadContent() {
			mFont = Content.Load<SpriteFont>("Tahoma");
			Services.AddService(mFont);
			
			mBackground = new Sprite(Content.Load<Texture2D>(@"Texture\background"), 6, 24, true);
			mForeground = Content.Load<Texture2D>(@"Texture\foreground");

			base.LoadContent();
		}

		protected override void Update(GameTime gameTime) {
			mInputState.Update();

			if (mInputState.IsNewPressed(Keys.Escape)) {
				Exit();
				return;
			}

			mBackground.Update(gameTime);

			base.Update(gameTime);
		}


		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.AntiqueWhite);
			
			mSpriteBatch.Begin();

			mSpriteBatch.Draw(mForeground, Vector2.Zero, Color.White);

			base.Draw(gameTime);

			mSpriteBatch.End();
		}

	}

}