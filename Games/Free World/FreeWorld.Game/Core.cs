using System;
using FreeWorld.Game.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FreeWorld.Engine;
using FreeWorld.Game.Components;
using FreeWorld.Game.Screens;
using FreeWorld.Engine.Tools;

namespace FreeWorld.Game {

	public class Core : Microsoft.Xna.Framework.Game {

		public bool IsExiting {
			get;
			protected set;
		}

		public GameScreenManager ScreenManager {
			get;
			protected set;
		}

		public Core Instance {
			get;
			protected set;
		}

		protected GraphicsDeviceManager mGraphics;
		protected GamePlayer mPlayer;


		public Core() {
			if (Instance != null) {
				throw new AccessViolationException("Unable to create more than one instance");
			}

			Instance = this;

			Exiting += Game_Exiting;
			mGraphics = new GraphicsDeviceManager(this);
			ScreenManager = new GameScreenManager(this);

			IsMouseVisible = true;
			//IsFixedTimeStep = false;
		}


		protected override void Initialize() {
			EngineCore.Initialize(@"Content\", GraphicsDevice, Services);
			EngineCore.InitComponents(this);

			Components.Add(ScreenManager);
			Components.Add(new CompFpsDisplay(this));

			// Initialize & LoadContent for Compontents
			base.Initialize();

			//ScreenManager.AddScreen(new ScreenLogin());
			ScreenManager.Add(new ScreenTestInhouse());
		}


		protected override void LoadContent() {
			EngineCore.SpriteBatch = new SpriteBatch(Constants.GraphicsDevice);

			Constants.ColorMoveable = new Color(new Vector4(Color.Green.ToVector3(), 0.35f));
			Constants.ColorNotMoveable = new Color(new Vector4(Color.Red.ToVector3(), 0.35f));
			Constants.TextureMoveable = DrawHelper.Rect2Texture(Constants.TileWidth, Constants.TileHeight, Constants.TileWidth / 2, Constants.ColorMoveable);
			Constants.TextureNotMoveable = DrawHelper.Rect2Texture(Constants.TileWidth, Constants.TileHeight, Constants.TileWidth / 2, Constants.ColorNotMoveable);

			mPlayer = GamePlayer.Create();
		}


		protected override void UnloadContent() {
			EngineCore.ContentLoader.Unload();
		}


		protected override void Update(GameTime gameTime) {
			if (IsExiting) {
				return;
			}

			base.Update(gameTime);

			if (EngineCore.InputHelper.IsKeyReleased(Keys.PrintScreen) || EngineCore.InputHelper.IsKeyReleased(Keys.F12)) {
				ScreenshotHelper.MakeScreenshot();
			}
		}


		protected override void Draw(GameTime gameTime) {
			if (IsExiting) {
				return;
			}

			Constants.GraphicsDevice.Clear(Color.Black);

			base.Draw(gameTime);
		}



		private void Game_Exiting(object sender, EventArgs e) {
			try {
				IsExiting = true;
				var screens = ScreenManager.AsArray();
				foreach (var screen in screens) {
					// Remove screen "by hand" because its faster
					ScreenManager.Remove(screen);
				}

				// @TODO: Notify server
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}

	}



	#region Program.Main
	public static class Program {
		public static void Main(string[] args) {
			using (Core game = new Core())
				game.Run();
		}
	}
	#endregion

}
