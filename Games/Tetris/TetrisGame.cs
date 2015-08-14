using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tetris.Game;
using Tetris.Graphics;
using Tetris.Helpers;
using Tetris.Sounds;

namespace Tetris {

	public class TetrisGame : BaseGame {
		private Texture2D mBackgroundTexture;
		private Texture2D mBlockTexture;
		private Texture2D mBackgroundSmallBoxTexture;
		private Texture2D mBackgroundBigBoxTexture;
		private SpriteHelper mBlock;
		private SpriteHelper mBackground;
		private SpriteHelper mBackgroundSmallBox;
		private SpriteHelper mBackgroundBigBox;
		private TetrisGrid mTetrisGrid;

		private int mLevel = 0;
		private int mHighscore;

		private int mElapsedGameMs = 0;
		private int mPressedLeftMs = 0;
		private int mPressedRightMs = 0;
		private int mPressedDownMs = 0;

		public SpriteHelper BlockSprite {
			get { return mBlock; }
		}


		public TetrisGame() {
			mTetrisGrid = new TetrisGrid(this, new Rectangle(512 - 200, 40, 400, 768 - (40 + 44)), new Rectangle(512 - 480 + 10, 40, 290 - 50, 280));
			Components.Add(mTetrisGrid);
		}


		protected override void LoadContent() {
			mBackgroundTexture = content.Load<Texture2D>("SpaceBackground");
			mBlockTexture = content.Load<Texture2D>("Block");
			mBackgroundSmallBoxTexture = content.Load<Texture2D>("BackgroundSmallBox");
			mBackgroundBigBoxTexture = content.Load<Texture2D>("BackgroundBigBox");

			mBlock = new SpriteHelper(mBlockTexture, null);
			mBackground = new SpriteHelper(mBackgroundTexture, null);
			mBackgroundSmallBox = new SpriteHelper(mBackgroundSmallBoxTexture, null);
			mBackgroundBigBox = new SpriteHelper(mBackgroundBigBoxTexture, null);

			base.LoadContent();
		}

		protected override void Update(GameTime gameTime) {
			if (Paused == true) {
				if (Input.KeyboardKeyJustPressed(Keys.P) == false) {
					base.Update(gameTime);
					return;
				}
				Paused = false;
			} else if (Input.KeyboardKeyJustPressed(Keys.P) == true) {
				Paused = true;
				base.Update(gameTime);
				return;
			}

			int oldGameMs = mElapsedGameMs;
			int frameMs = (int)gameTime.ElapsedGameTime.TotalMilliseconds;
			mElapsedGameMs += frameMs;

			// Game tick time, 1000 for difficutly=0, 100 for difficutly=9
			int gameTickTime = 1000 / (mLevel + 1);
			if (mElapsedGameMs / gameTickTime != oldGameMs / gameTickTime || mTetrisGrid.MovingDownWasBlocked == true) {
				mTetrisGrid.Update();
			}

			// Official way to raise level - after 10 crushed lines
			if ((mTetrisGrid.CrushedLines / 10) > mLevel) {
				mLevel++;
				Sound.Play(ESoundTypes.Victory);
			}

			// We sum up the elapsed time after a button/key was pressed.
			// If some time has been reached, the action will be executed.
			// If we just execute it after the button/key was pressed,
			// the block would move extrem fast.
			// Current speed of 75ms is kind enough.
			if (Input.KeyboardLeftPressed || Input.GamePadLeftPressed) {
				mPressedLeftMs += frameMs;
			} else {
				mPressedLeftMs = 0;
			}
			if (Input.KeyboardRightPressed || Input.GamePadRightPressed) {
				mPressedRightMs += frameMs;
			} else {
				mPressedRightMs = 0;
			}
			if (Input.KeyboardDownPressed || Input.GamePadDownPressed || Input.Keyboard.IsKeyDown(Keys.Space) || Input.GamePadAPressed) {
				mPressedDownMs += frameMs;
			} else {
				mPressedDownMs = 0;
			}

			if (Input.KeyboardLeftJustPressed || Input.GamePadLeftJustPressed || mPressedLeftMs > 200) {
				if (mPressedLeftMs > 75) {
					mPressedLeftMs -= 75;
				}
				mTetrisGrid.MoveBlock(EMoveTypes.Left);
			} else if (Input.KeyboardRightJustPressed || Input.GamePadRightJustPressed || mPressedRightMs > 200) {
				if (mPressedRightMs > 75) {
					mPressedRightMs -= 75;
				}
				mTetrisGrid.MoveBlock(EMoveTypes.Right);
			} else if (Input.KeyboardDownJustPressed || Input.GamePadDownJustPressed || Input.KeyboardSpaceJustPressed || Input.GamePadAJustPressed || mPressedDownMs > 150) {
				if (mPressedDownMs > 50) {
					mPressedDownMs -= 50;
				}
				mTetrisGrid.MoveBlock(EMoveTypes.Down);
			} else if (Input.KeyboardUpJustPressed || Input.GamePadUpJustPressed) {
				mTetrisGrid.RotateBlock();
			}

			if (mTetrisGrid.TotalScore != mHighscore) {
				mHighscore = mTetrisGrid.TotalScore;
			}

			// Restart using Enter
			if (mTetrisGrid.GameOver && (Input.KeyboardSpaceJustPressed || Input.GamePadAJustPressed || Input.KeyboardEnterJustPressed)) {
				mTetrisGrid.GameOver = false;
				mTetrisGrid.TotalScore = 0;
				mTetrisGrid.CrushedLines = 0;
				mLevel = 0;
				mTetrisGrid.Restart();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			mBackground.Render();

			mBackgroundBigBox.Render(new Rectangle((512 - 200) - 15, 40 - 12, 400 + 23, (768 - (40 + 41)) + 16));
			mBackgroundSmallBox.Render(new Rectangle((512 - 480) - 15 + 10, 40 - 10, 290 - 30, 300));
			mBackgroundSmallBox.Render(new Rectangle((512 + 240) - 15 - 10, 40 - 10, 290 - 30, 190));

			mTetrisGrid.Draw(gameTime);

			TextureFont.WriteText(512 + 230, 50, "Level: ");
			TextureFont.WriteText(512 + 400, 50, (mLevel + 1).ToString());
			TextureFont.WriteText(512 + 230, 90, "Score: ");
			TextureFont.WriteText(512 + 400, 90, mTetrisGrid.TotalScore.ToString());
			TextureFont.WriteText(512 + 230, 130, "Lines: ");
			TextureFont.WriteText(512 + 400, 130, mTetrisGrid.CrushedLines.ToString());
			TextureFont.WriteText(512 + 230, 170, "Highscore: ");
			TextureFont.WriteText(512 + 400, 170, mHighscore.ToString());

			base.Draw(gameTime);

			if (mTetrisGrid.GameOver) {
				spriteBatch.Begin();
				spriteBatch.DrawString(CopyrightFont, "Game Over", new Vector2(Window.ClientBounds.Width / 2 - 65, Window.ClientBounds.Height / 2 - 20), Color.White, 0, Vector2.Zero, 3f, SpriteEffects.None, 0);
				spriteBatch.End();
			}
		}


	}

}