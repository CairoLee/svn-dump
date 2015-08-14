using System;
using System.Collections.Generic;
using GodLesZ.Library.XNA.ScreenSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Games.SettlersofCatan.Screens {

	public class ScreenGame : ScreenBase {
		private Dictionary<string, Texture2D> mGroundTextures;
		private string[,] mGrid;



		public ScreenGame(ScreenManager mgr)
			: base(mgr) {
			Name = "ScreenGame";
			IsActive = true;
			InputHandle = true;

			mGroundTextures = new Dictionary<string, Texture2D>();
		}


		public override void Initialize() {
			if (mInitialized) {
				return;
			}

			base.Initialize();
		}

		public override void LoadContent() {
			if (mContentLoaded) {
				return;
			}

			mGroundTextures.Add("leer", Game.Content.Load<Texture2D>("map/kachel_leer"));
			mGroundTextures.Add("wasser", Game.Content.Load<Texture2D>("map/kachel_wasser"));
			mGroundTextures.Add("weide", Game.Content.Load<Texture2D>("map/kachel_weide"));
			mGroundTextures.Add("lehm", Game.Content.Load<Texture2D>("map/kachel_lehm"));
			mGroundTextures.Add("wald", Game.Content.Load<Texture2D>("map/kachel_wald"));
			mGroundTextures.Add("korn", Game.Content.Load<Texture2D>("map/kachel_korn"));

			mGrid = new string[10, 15];

			for (int y = 0; y < mGrid.GetLength(1); y++) {
				for (int x = 0; x < mGrid.GetLength(0); x++) {
					mGrid[x, y] = GetRandomTile();
				}
			}

			base.LoadContent();
		}

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);
		}

		public override void HandleInput(GameTime gameTime) {
			base.HandleInput(gameTime);
		}

		public override void Draw(GameTime gameTime) {
			Game.GraphicsDevice.Clear(Color.Black);

			float scale = 0.5f;
			Vector2 gridSize = new Vector2(188 * scale, 158 * scale);

			// Draw 10 fields
			Vector2 texPos = new Vector2(0, -gridSize.Y / 2);
			Texture2D tex;

			ScreenManager.SpriteBatch.Begin();
			for (int y = 0; y < mGrid.GetLength(1); y++) {
				for (int x = 0; x < mGrid.GetLength(0); x++) {
					tex = mGroundTextures[mGrid[x, y]];
					ScreenManager.SpriteBatch.Draw(tex, texPos, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);

					texPos.X += gridSize.X + gridSize.X / 2;
				}

				texPos.Y += gridSize.Y / 2;
				if ((y % 2) == 0) {
					texPos.X = gridSize.X - gridSize.X / 4;
				} else {
					texPos.X = 0;
				}
			}
			ScreenManager.SpriteBatch.End();

			base.Draw(gameTime);
		}


		private Random mRandom = new Random();
		public string GetRandomTile() {
			switch (mRandom.Next(4)) {
				case 0:
					return "wasser";
				case 1:
					return "weide";
				case 2:
					return "lehm";
				case 3:
					return "wald";
				case 4:
					return "korn";
			}

			return "leer";
		}

	}

}
