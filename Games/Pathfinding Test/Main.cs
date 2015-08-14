using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pathfinding {
	public class Game1 : Game {
		GraphicsDeviceManager graphics;
		SpriteBatch mBatch;

		MouseState mNewMouseState;
		MouseState mOldMouseState;

		KeyboardState mNewKeyboardState;
		KeyboardState mOldKeyboardState;

		Texture2D mGroundTex;
		Texture2D mObjectTex;
		SpriteFont mDebugFont;

		float mClearWalkPath = 0f;

		byte[,] PathGrid;
		byte[,] DrawGrid;

		ushort mGridWidth = 200;
		ushort mGridHeight = 200;

		enum DrawType {
			DrawWay,
			DrawWall
		}

		DrawType mDrawType = DrawType.DrawWall;

		Point mStartPoint;
		Point mEndPoint;

		Point mThisMousePos = new Point();
		Point mOldMousePos = new Point();

		PathFinder mPathFinder;
		List<PathReturnNode> foundPath;

		int mTileWidth = 32;

		float elapsedTime = 0.0f;

		MovableObject mMovableObject;
		Vector2 Click;

		float mGlobalScale = 1f;

		Vector2 screenSize = Vector2.Zero;

		Stopwatch mWatch = new Stopwatch();


		public Game1() {
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 600;
			graphics.IsFullScreen = false;
			graphics.SynchronizeWithVerticalRetrace = false;

			screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

			IsFixedTimeStep = false;
			Content.RootDirectory = "Content";
		}

		protected override void Initialize() {
			mGridWidth = 50;
			mGridHeight = 50;

			PathGrid = new byte[mGridWidth, mGridHeight];
			DrawGrid = new byte[mGridWidth, mGridHeight];

			for (int y = 0; y < mGridHeight; y += 1) {
				for (int x = 0; x < mGridWidth; x += 1) {
					PathGrid[x, y] = 1;
					DrawGrid[x, y] = 1;
				}
			}

			mPathFinder = new PathFinder(PathGrid);

			MovableObject.Initalize(mGridWidth, mTileWidth);

			mMovableObject = new MovableObject(new Vector2(16 * mGlobalScale, 16 * mGlobalScale));

			base.Initialize();

		}

		protected override void LoadContent() {
			mBatch = new SpriteBatch(GraphicsDevice);
			mGroundTex = Content.Load<Texture2D>("door_mossy");
			mObjectTex = Content.Load<Texture2D>("poring");
			mDebugFont = Content.Load<SpriteFont>("DebugText");

			IsMouseVisible = true;
		}

		protected override void UnloadContent() {
		}

		private bool WasPressed(Keys Key) {
			return mOldKeyboardState.IsKeyDown(Key) == true && mNewKeyboardState.IsKeyUp(Key) == true;
		}

		public enum EMouseButton {
			LeftButton,
			MiddleButton,
			RightButton
		}
		private bool WasPressed(EMouseButton Btn) {
			ButtonState oldState = ButtonState.Released;
			ButtonState newState = ButtonState.Released;
			switch (Btn) {
				case EMouseButton.LeftButton:
					oldState = mOldMouseState.LeftButton;
					newState = mNewMouseState.LeftButton;
					break;
				case EMouseButton.MiddleButton:
					oldState = mOldMouseState.MiddleButton;
					newState = mNewMouseState.MiddleButton;
					break;
				case EMouseButton.RightButton:
					oldState = mOldMouseState.RightButton;
					newState = mNewMouseState.RightButton;
					break;
			}

			return oldState == ButtonState.Pressed && newState == ButtonState.Released;
		}

		protected override void Update(GameTime gameTime) {
			mOldMouseState = mNewMouseState;
			mOldKeyboardState = mNewKeyboardState;
			mNewMouseState = Mouse.GetState();
			mNewKeyboardState = Keyboard.GetState();

			elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			mOldMousePos = mThisMousePos;

			mThisMousePos.X = mNewMouseState.X / mTileWidth;
			mThisMousePos.Y = mNewMouseState.Y / mTileWidth;

			int mouseDelta = (mOldMouseState.ScrollWheelValue - mNewMouseState.ScrollWheelValue) / 100;
			if (mouseDelta < 0 || (mouseDelta > 0 && mTileWidth > 1)) {
				mTileWidth = Math.Max(mTileWidth - mouseDelta, 1);
				MovableObject.Initalize(mGridWidth, mTileWidth);

				mGlobalScale = (float)mTileWidth / (float)mObjectTex.Width;
				mMovableObject = new MovableObject(new Vector2(16 * mGlobalScale, 16 * mGlobalScale));
			}

			if (WasPressed(Keys.Escape)) {
				this.Exit();
			}
			if (WasPressed(Keys.F1)) {
				graphics.ToggleFullScreen();
			}
			if (WasPressed(Keys.C)) {
				this.Initialize();
			}


			if (WasPressed(Keys.D)) {
				if (mDrawType != DrawType.DrawWay)
					mDrawType = DrawType.DrawWay;
				else
					mDrawType = DrawType.DrawWall;
			}

			if (WasPressed(EMouseButton.RightButton) == true) {
				Click = new Vector2(mNewMouseState.X, mNewMouseState.Y);

				mStartPoint = new Point((int)(mMovableObject.PositionCurrent.X / mTileWidth), (int)(mMovableObject.PositionCurrent.Y / mTileWidth));
				mEndPoint = new Point(mThisMousePos.X, mThisMousePos.Y);

				mWatch = Stopwatch.StartNew();
				if (mStartPoint == mEndPoint) {
					mMovableObject.LinearMove(mMovableObject.PositionCurrent, Click);
				} else {
					Stopwatch timeTest = Stopwatch.StartNew();
					foundPath = mPathFinder.FindPath(mStartPoint, mEndPoint);
					timeTest.Stop();
					Debug.Write("FindPath need " + timeTest.ElapsedMilliseconds + "ms");
					if (foundPath != null) {
						Debug.WriteLine(" [" + foundPath.Count + " steps]");
						mMovableObject.PathMove(ref foundPath, mMovableObject.PositionCurrent, Click);
					} else {
						Debug.WriteLine(" [FAILED TO FIND A WAY]");
					}
				}
			}

			//Wall drawing / removing
			if (mNewMouseState.LeftButton == ButtonState.Pressed) {
				mThisMousePos.X = mNewMouseState.X / mTileWidth;
				mThisMousePos.Y = mNewMouseState.Y / mTileWidth;

				if ((mThisMousePos.X < mGridWidth) && (mThisMousePos.Y < mGridHeight) && (mThisMousePos.X >= 0) && (mThisMousePos.Y >= 0)) {
					switch (mDrawType) {
						case DrawType.DrawWall:
							PathGrid[mThisMousePos.X, mThisMousePos.Y] = 0;
							DrawGrid[mThisMousePos.X, mThisMousePos.Y] = 0;
							break;
						case DrawType.DrawWay:
							PathGrid[mThisMousePos.X, mThisMousePos.Y] = 1;
							DrawGrid[mThisMousePos.X, mThisMousePos.Y] = 1;
							break;
					}
				}
			}

			mMovableObject.Update(elapsedTime);

			ushort GridX = (ushort)(mPathFinder.PathGrid.GetUpperBound(0) + 1);
			ushort GridY = (ushort)(mPathFinder.PathGrid.GetUpperBound(1) + 1);

			if (mMovableObject.PositionChanged == false) {
				if (mWatch.IsRunning == true)
					mWatch.Stop();

				mClearWalkPath += elapsedTime;
				if (mClearWalkPath >= 3f) {
					mClearWalkPath = 0f;
					mPathFinder.WalkedNodes = new byte[GridX, GridY];
				}
			} else {
				mClearWalkPath = 0f;
				if (((int)mMovableObject.PositionCurrent.X / mTileWidth) < GridX && ((int)mMovableObject.PositionCurrent.Y / mTileWidth) < GridY)
					mPathFinder.WalkedNodes[(int)mMovableObject.PositionCurrent.X / mTileWidth, (int)mMovableObject.PositionCurrent.Y / mTileWidth] = 1;
			}

			base.Update(gameTime);


		}

		protected override void Draw(GameTime gameTime) {
			graphics.GraphicsDevice.Clear(Color.Cornsilk);

			Color TextCol = new Color(255, 255, 255, 255);

			mBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

			// Draw Grid
			for (int y = 0; y < mGridHeight; y++) {
				for (int x = 0; x < mGridWidth; x++) {

					Rectangle rect = new Rectangle(x * mTileWidth, y * mTileWidth, mTileWidth, mTileWidth);

					if (DrawGrid[x, y] == 0) {
						mBatch.Draw(mGroundTex, rect, Color.DarkCyan);
					} else if (DrawGrid[x, y] == 1) {
						if (mPathFinder.WalkedNodes[x, y] == 1) {
							mBatch.Draw(mGroundTex, rect, Color.Aqua);
						} else {
							mBatch.Draw(mGroundTex, rect, Color.Silver);
						}
					}
				}
			}

			// Draw Texture on Cursor
			Rectangle mouseRect = new Rectangle(mThisMousePos.X * mTileWidth, mThisMousePos.Y * mTileWidth, mTileWidth, mTileWidth);
			mBatch.Draw(mGroundTex, mouseRect, new Color(Color.Green.R, Color.Green.G, Color.Green.B, 100));

			//Draw Object
			mBatch.Draw(mObjectTex, mMovableObject.PositionCurrent, null, Color.White, mMovableObject.Direction, new Vector2(16, 16), mGlobalScale, SpriteEffects.None, 0f);

			//Draw Text
			float w = screenSize.X - 250;
			mBatch.DrawString(mDebugFont, "Grid Pos: " + mThisMousePos.ToString(), new Vector2(w, 8), Color.White);
			mBatch.DrawString(mDebugFont, "Drawtype (D): " + mDrawType.ToString(), new Vector2(w, 28), Color.White);
			mBatch.DrawString(mDebugFont, "Scale (Scroll): " + mGlobalScale.ToString(), new Vector2(w, 48), Color.White);
			if (mClearWalkPath > 0)
				mBatch.DrawString(mDebugFont, String.Format("PathClear: {0:F2}", 3.0f - mClearWalkPath), new Vector2(w, 68), Color.White);

			mBatch.DrawString(mDebugFont, String.Format("Stopuhr: {0:F2}sec", (float)mWatch.ElapsedMilliseconds / 1000f), new Vector2(w, 88), Color.White);

			mBatch.End();

			base.Draw(gameTime);
		}
	}



	public static class Program {
		public static void Main(string[] args) {
			using (Game1 game = new Game1())
				game.Run();
		}
	}

}
