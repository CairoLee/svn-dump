using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FinalSoftware.Games.Defender.Library.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FinalSoftware.Games.Defender.Library;

namespace FinalSoftware.Games.Defender.Game {

	public class Game : DefenderGame {
		private bool mFirstUpdate;
		private bool mStartDelay;
		private Texture2D mTexMenu;
		private Texture2D mTexMenuButton;
		private Texture2D mTexMenuButtonD;
		private Rectangle mDifSimple;
		private Rectangle mDifNormal;
		private Rectangle mDifHeavy;
		private byte mFadeIn = 50;
		private float mDelayTimer;


		public Game()
			: base() {
		}


		public override void Restart() {
			mWorld = new World(this);
		}


		protected override void Initialize() {
			mWorld = new World(this);

//#if !DEBUG
			Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
			Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
			Graphics.IsFullScreen = true;
//#else
//			Graphics.PreferredBackBufferWidth = 1300;
//			Graphics.PreferredBackBufferHeight = 700;
//#endif
			Graphics.ApplyChanges();
			IsMouseVisible = true;


			mDifSimple = new Rectangle(Window.ClientBounds.Width / 2 - 170, Window.ClientBounds.Height - 200, 100, 40);
			mDifNormal = new Rectangle(Window.ClientBounds.Width / 2 - 50, Window.ClientBounds.Height - 200, 100, 40);
			mDifHeavy = new Rectangle(Window.ClientBounds.Width / 2 + 70, Window.ClientBounds.Height - 200, 100, 40);

			base.Initialize();
		}


		protected override void LoadContent() {
			base.LoadContent();
			mTexMenu = Content.Load<Texture2D>("texMenu");
			mTexMenuButton = Content.Load<Texture2D>("button1");
			mTexMenuButtonD = Content.Load<Texture2D>("button1d");
		}

		protected override void UnloadContent() {
			base.UnloadContent();
		}

		protected override void Update(GameTime gameTime) {
			if (mFirstUpdate == false) {
				mFirstUpdate = true;
				Program.SplashScreen.Close();
			}

			base.Update(gameTime);

			if (!Started) {
				if (mStartDelay) {
					mDelayTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
					if (mDelayTimer > 750)
						Started = true;
				}
				if (Input.WasButtonPressed(EMouseButtons.LeftButton)) {
					bool simple = false, normal = false, heavy = false;
					if ((simple = mDifSimple.Contains(Input.BoundsReal)) || (normal = mDifNormal.Contains(Input.BoundsReal)) || (heavy = mDifHeavy.Contains(Input.BoundsReal))) {
						if (simple) {
							World.SetGameDifficult(EGameDifficult.Easy);
						} else if (normal) {
							World.SetGameDifficult(EGameDifficult.Medium);
						} else if (heavy) {
							World.SetGameDifficult(EGameDifficult.Hard);
						} else {
							// Fallback
							World.SetGameDifficult(EGameDifficult.Easy);
						}
						mStartDelay = true;
						World.Audio.Play3DCue("thud");
					}
				}
			}

			World.Music.Update();
		}

		protected override void Draw(GameTime gameTime) {
			base.Draw(gameTime);
			if (Started == true) {
				return;
			}

			if (mFadeIn < 255) {
				mFadeIn++;
			}

			Color fColor = new Color(mFadeIn, mFadeIn, mFadeIn, mFadeIn);

			World.SpriteBatch.Begin();

			var rec = new Rectangle(
				(int)(Window.ClientBounds.Width / 2f - mTexMenu.Width / 2f),
				(int)(Window.ClientBounds.Height / 2f - mTexMenu.Height / 2f),
				mTexMenu.Width,
				mTexMenu.Height
			);
			World.SpriteBatch.Draw(mTexMenu, rec, fColor);

			#region Button: Simple
			bool simpleDown = false;
			if ((simpleDown = mDifSimple.Contains(Input.BoundsReal)))
				World.SpriteBatch.Draw(mTexMenuButtonD, mDifSimple, new Rectangle(0, 0, mTexMenuButtonD.Width, mTexMenuButtonD.Height), fColor);
			else
				World.SpriteBatch.Draw(mTexMenuButton, mDifSimple, new Rectangle(0, 0, mTexMenuButton.Width, mTexMenuButton.Height), fColor);
			Vector2 simplePos;
			simplePos.X = mDifSimple.X + (mDifSimple.Width / 2) - (int)(Font.MeasureString("Einfach").X * .4f) / 2;
			simplePos.Y = mDifSimple.Y + (mDifSimple.Height / 2) - (int)(Font.MeasureString("Einfach").Y * .4f) / 2;
			if (!simpleDown)
				simplePos -= new Vector2(2, 2);
			World.SpriteBatch.DrawString(Font, "Einfach", simplePos, fColor, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 0f);
			#endregion

			#region Button: Easy
			bool normalDown = false;
			if ((normalDown = mDifNormal.Contains(Input.BoundsReal)))
				World.SpriteBatch.Draw(mTexMenuButtonD, mDifNormal, new Rectangle(0, 0, mTexMenuButtonD.Width, mTexMenuButtonD.Height), fColor);
			else
				World.SpriteBatch.Draw(mTexMenuButton, mDifNormal, new Rectangle(0, 0, mTexMenuButton.Width, mTexMenuButton.Height), fColor);
			Vector2 normalPos;
			normalPos.X = mDifNormal.X + (mDifNormal.Width / 2) - (int)(Font.MeasureString("Easy").X * .4f) / 2;
			normalPos.Y = mDifNormal.Y + (mDifNormal.Height / 2) - (int)(Font.MeasureString("Easy").Y * .4f) / 2;
			if (!normalDown)
				normalPos -= new Vector2(2, 2);
			World.SpriteBatch.DrawString(Font, "Easy", normalPos, fColor, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 0f);
			#endregion

			#region Button: Heavy
			bool heavyDown = false;
			if ((heavyDown = mDifHeavy.Contains(Input.BoundsReal)))
				World.SpriteBatch.Draw(mTexMenuButtonD, mDifHeavy, new Rectangle(0, 0, mTexMenuButtonD.Width, mTexMenuButtonD.Height), fColor);
			else
				World.SpriteBatch.Draw(mTexMenuButton, mDifHeavy, new Rectangle(0, 0, mTexMenuButton.Width, mTexMenuButton.Height), fColor);
			Vector2 heavyPos;
			heavyPos.X = mDifHeavy.X + (mDifHeavy.Width / 2) - (int)(Font.MeasureString("Schwer").X * .4f) / 2;
			heavyPos.Y = mDifHeavy.Y + (mDifHeavy.Height / 2) - (int)(Font.MeasureString("Schwer").Y * .4f) / 2;
			if (!heavyDown)
				heavyPos -= new Vector2(2, 2);
			World.SpriteBatch.DrawString(Font, "Schwer", heavyPos, fColor, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 0f);
			#endregion

			World.SpriteBatch.End();

			DrawVersion();
		}

	}

}
