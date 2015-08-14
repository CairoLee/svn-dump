using FinalSoftware.Games.Defender.Library.Interface;
using FinalSoftware.Games.Defender.Library.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalSoftware.Games.Defender.Library {

	public class DefenderGame : Game {
		protected DefenderWorld mWorld;

		private readonly GraphicsDeviceManager mGraphics;
		private const string VersionNumber = "2.0a";

		public GraphicsDeviceManager Graphics {
			get { return mGraphics; }
		}

		public InputHelper Input {
			get { return mWorld.Input; }
		}

		public virtual DefenderWorld World {
			get { return mWorld; }
		}

		public SpriteFont Font {
			get;
			private set;
		}

		public bool Started {
			get;
			set;
		}


		public DefenderGame()
			: base() {
			Started = false;
			mGraphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}


		protected override void Initialize() {
			if (mWorld == null) {
				mWorld = new DefenderWorld(this);
				Components.Add(mWorld);
			}

			base.Initialize();
			LoadContent();
		}

		public virtual void Restart() {
			// TODO: fix me
			mWorld = new DefenderWorld(this);
		}


		protected override void LoadContent() {
			base.LoadContent();

			Font = Content.Load<SpriteFont>("TahomaFont");
		}

		protected override void UnloadContent() {
			Content.Unload();
		}

		protected override void Update(GameTime gameTime) {
			base.Update(gameTime);
			if (mWorld.GameRestart == true) {
				mWorld.GameRestart = false;
				Restart();
			}

			if (Started) {
				if (!mWorld.Status.Lost) {
					World.UpdateWorld(gameTime);
				}
				mWorld.Interface.UpdateInput();
			}

			if (Input.WasKeyPressed(Keys.F12) || Input.WasKeyPressed(Keys.PrintScreen) || Input.WasKeyPressed(Keys.Print)) {
				ScreenshotHelper.MakeScreenshot();
			}
		}

		protected override void Draw(GameTime gameTime) {
			mGraphics.GraphicsDevice.Clear(Color.Black);

			if (Started) {
				World.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, World.Interface.Camera.Matrix);
				World.SpriteBatchAdditive.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, World.Interface.Camera.Matrix);

				World.DrawWorldBG(gameTime);
				World.Interface.DrawUIBack();
				World.DrawWorldFG(gameTime);
				World.DrawProjectiles();

				World.DrawTime();

				World.SpriteBatch.End();
				World.SpriteBatchAdditive.End();

				World.SpriteBatch.Begin();
				World.Interface.DrawUIFront();
				World.SpriteBatch.End();

				base.Draw(gameTime);
				return;
			}

			DrawVersion();

			base.Draw(gameTime);
		}

		protected void DrawVersion() {
			World.SpriteBatch.Begin();

			string version = "Build " + VersionNumber;
			int xPos = 5;
			int yPos = (int)(Window.ClientBounds.Height - Font.MeasureString(version).Y * .35f);
			World.SpriteBatch.DrawString(Font, version, new Vector2(xPos, yPos), Color.White, 0f, Vector2.Zero, .35f, SpriteEffects.None, 1f);

			string copy = "Copyright © 2010 GodLesZ";
			int xCopy = (int)(Window.ClientBounds.Width - Font.MeasureString(copy).X * .35f - 10);
			int yCopy = (int)(Window.ClientBounds.Height - Font.MeasureString(copy).Y * .35f);
			World.SpriteBatch.DrawString(Font, copy, new Vector2(xCopy, yCopy), Color.White, 0f, Vector2.Zero, .35f, SpriteEffects.None, 1f);

			World.SpriteBatch.End();
		}

	}

}
