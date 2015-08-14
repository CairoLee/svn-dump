using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace PacMan {

	/// <summary>
	/// GameLoop is the main "game" object; tkhis is basically where the action
	/// takes place. It's responsible for coordinating broad game logic,
	/// drawing the board and scores, as well as linking with the menu.
	/// </summary>
	public class GameLoop : DrawableGameComponent {
		private Dictionary<string, Texture2D> mBonus;
		private Texture2D mXLife;
		private Texture2D mBoard;
		private Texture2D mBoardFlash;
		private Texture2D mCrump;
		private Texture2D mPPill;
		private SpriteFont mScoreFont;
		private SpriteFont mScoreEventFont;
		private SoundBank mSoundBank;
		private GraphicsDeviceManager mGraphicsDeviceManager;
		private SpriteBatch mSpriteBatch;

		private List<Ghost> mGhosts;
		private Player mPlayer;
		private TimeSpan mLockTimer;
		private DateTime mEventTimer;
		private int mBonusSpawned;
		private bool mBonusPresent;
		private DateTime mBonusSpawnedTime;
		private Dictionary<string, int> mBonusEaten;
		private bool mPLayerDied;
		private bool mPaChomp;
		private int mXLives;
		private int mScore;
		private int mEatenGhosts;
		private List<ScoreEvent> mScoreEvents;

		/// <summary>
		/// The player's current score.
		/// </summary>
		public int Score {
			get { return mScore; }
			private set {
				if ((value / 10000) > (mScore / 10000)) {
					mSoundBank.PlayCue("ExtraLife");
					mXLives++;
				}
				mScore = value;
			}
		}

		/// <summary>
		/// For how much time we want to lock the game.
		/// </summary>
		private TimeSpan LockTimer {
			get { return mLockTimer; }
			set {
				mEventTimer = DateTime.Now;
				mLockTimer = value;
			}
		}


		public GameLoop(Game game)
			: base(game) {
			// TODO: Construct any child components here
		}


		/// <summary>
		/// Allows the game component to perform any initialization it needs to before starting
		/// to run.  This is where it can query for any required services and load content.
		/// </summary>
		public override void Initialize() {
			// We don't want XNA calling this method each time we resume from the menu,
			// unfortunately, it'll call it whatever we try. So the only thing
			// we can do is check if it has been called already and return. Yes, it's ugly.
			if (mSpriteBatch != null) {
				GhostSoundsManager.ResumeLoops();
				return;
			}
			// Otherwise, this is the first time this component is Initialized, so proceed.

			GhostSoundsManager.Init(Game);

			Grid.Reset();
			Constants.Level = 1;
			mSpriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
			mGraphicsDeviceManager = (GraphicsDeviceManager)Game.Services.GetService(typeof(GraphicsDeviceManager));
			mSoundBank = (SoundBank)Game.Services.GetService(typeof(SoundBank));

			mScoreFont = Game.Content.Load<SpriteFont>("Score");
			mScoreEventFont = Game.Content.Load<SpriteFont>("ScoreEvent");
			mXLife = Game.Content.Load<Texture2D>("sprites/ExtraLife");
			mPPill = Game.Content.Load<Texture2D>("sprites/PowerPill");
			mCrump = Game.Content.Load<Texture2D>("sprites/Crump");
			mBoard = Game.Content.Load<Texture2D>("sprites/Board");
			mBoardFlash = Game.Content.Load<Texture2D>("sprites/BoardFlash");
			mBonusEaten = new Dictionary<string, int>();
			mBonus = new Dictionary<string, Texture2D>(9);
			mBonus.Add("Apple", Game.Content.Load<Texture2D>("bonus/Apple"));
			mBonus.Add("Banana", Game.Content.Load<Texture2D>("bonus/Banana"));
			mBonus.Add("Bell", Game.Content.Load<Texture2D>("bonus/Bell"));
			mBonus.Add("Cherry", Game.Content.Load<Texture2D>("bonus/Cherry"));
			mBonus.Add("Key", Game.Content.Load<Texture2D>("bonus/Key"));
			mBonus.Add("Orange", Game.Content.Load<Texture2D>("bonus/Orange"));
			mBonus.Add("Pear", Game.Content.Load<Texture2D>("bonus/Pear"));
			mBonus.Add("Pretzel", Game.Content.Load<Texture2D>("bonus/Pretzel"));
			mBonus.Add("Strawberry", Game.Content.Load<Texture2D>("bonus/Strawberry"));

			mScoreEvents = new List<ScoreEvent>(5);
			mBonusPresent = false;
			mBonusSpawned = 0;
			mEatenGhosts = 0;
			Score = 0;
			mXLives = 2;
			mPaChomp = true;
			mPLayerDied = false;
			mPlayer = new Player(Game);

			mGhosts = new List<Ghost> { 
				new Ghost(Game, mPlayer, EGhostType.Blinky), 
				new Ghost(Game, mPlayer, EGhostType.Clyde),
				new Ghost(Game, mPlayer, EGhostType.Inky), 
				new Ghost(Game, mPlayer, EGhostType.Pinky)
			};
			mGhosts[2].SetBlinky(mGhosts[0]); // Oh, dirty hack. Inky needs this for his AI.
			mSoundBank.PlayCue("Intro");
			LockTimer = TimeSpan.FromMilliseconds(4500);

			base.Initialize();
		}

		/// <summary>
		/// Allows the game component to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime) {

			// Some events (death, new level, etc.) lock the game for a few moments.
			if (DateTime.Now - mEventTimer < LockTimer) {
				mGhosts.ForEach(g => g.LockTimer(gameTime));
				// Also we need to do the same thing for our own timer concerning bonuses
				mBonusSpawnedTime += gameTime.ElapsedGameTime;
				return;
			}

			// Remove special events older than 5 seconds
			mScoreEvents.RemoveAll(e => DateTime.Now - e.Date > TimeSpan.FromSeconds(5));

			// If the player had died, spawn a new one or end game.
			if (mPLayerDied) {
				// extra lives are decremented here, at the same time the pac man is spawned; this makes those 
				// events seem linked.
				mXLives--;
				//mXLives++; // Give infinite lives to the evil developer;
				if (mXLives >= 0) {
					mPLayerDied = false;
					mPlayer = new Player(Game);
					mGhosts.ForEach(g => g.Reset(false, mPlayer));
					mScoreEvents.Clear();
				} else {
					// The game is over
					Menu.SaveHighScore(Score);
					Game.Components.Add(new Menu(Game, null));
					Game.Components.Remove(this);
					GhostSoundsManager.StopLoops();
					return;
				}
			}

			// When all crumps have been eaten, wait a few seconds and then spawn a new level
			if (noCrumpsLeft()) {
				if (Constants.Level < 21) {
					mBonusSpawned = 0;
					Grid.Reset();
					mPlayer = new Player(Game);
					mGhosts.ForEach(g => g.Reset(true, mPlayer));
					mSoundBank.PlayCue("NewLevel");
					LockTimer = TimeSpan.FromSeconds(2);
					Constants.Level++;
					return;
				} else { // Game over, you win.
					Menu.SaveHighScore(Score);
					Game.Components.Add(new Menu(Game, null));
					Game.Components.Remove(this);
					GhostSoundsManager.StopLoops();
					return;
				}
			}

			Keys[] inputKeys = Keyboard.GetState().GetPressedKeys();
			// The user may escape to the main menu with the escape key
			if (inputKeys.Contains(Keys.Escape)) {
				Game.Components.Add(new Menu(Game, this));
				Game.Components.Remove(this);
				GhostSoundsManager.PauseLoops(); // will be resumed in Initialize(). No need for stopping them
				// if the player subsequently quits the game, since we'll re-initialize GhostSoundManager in
				// Initialize() if the player wants to start a new game.
				return;
			}

			// Eat crumps and power pills.
			if (mPlayer.Position.DeltaPixel == Point.Zero) {
				Point playerTile = mPlayer.Position.Tile;
				if (Grid.TileGrid[playerTile.X, playerTile.Y].HasCrump) {
					mSoundBank.PlayCue(mPaChomp ? "PacMAnEat1" : "PacManEat2");
					mPaChomp = !mPaChomp;
					Score += 10;
					Grid.TileGrid[playerTile.X, playerTile.Y].HasCrump = false;
					if (Grid.TileGrid[playerTile.X, playerTile.Y].HasPowerPill) {
						Score += 40;
						mEatenGhosts = 0;
						for (int i = 0; i < mGhosts.Count; i++) {
							if (mGhosts[i].State == EGhostState.Attack || mGhosts[i].State == EGhostState.Scatter ||
								mGhosts[i].State == EGhostState.Blue) {
								mGhosts[i].State = EGhostState.Blue;
							}
						}
						Grid.TileGrid[playerTile.X, playerTile.Y].HasPowerPill = false;
					}

					// If that was the last crump, lock the game for a while
					if (noCrumpsLeft()) {
						GhostSoundsManager.StopLoops();
						LockTimer = TimeSpan.FromSeconds(2);
						return;
					}
				}
			}

			// Eat bonuses
			if (mBonusPresent && mPlayer.Position.Tile.Y == 17 && ((mPlayer.Position.Tile.X == 13 && mPlayer.Position.DeltaPixel.X == 8) || (mPlayer.Position.Tile.X == 14 && mPlayer.Position.DeltaPixel.X == -8))) {
				LockTimer = TimeSpan.FromSeconds(1.5);
				Score += Constants.BonusScores();
				mScoreEvents.Add(new ScoreEvent(mPlayer.Position, DateTime.Now, Constants.BonusScores()));
				mSoundBank.PlayCue("fruiteat");
				mBonusPresent = false;
				if (mBonusEaten.ContainsKey(Constants.BonusSprite())) {
					mBonusEaten[Constants.BonusSprite()]++;
				} else {
					mBonusEaten.Add(Constants.BonusSprite(), 1);
				}
			}

			// Remove bonus if time's up
			if (mBonusPresent && ((DateTime.Now - mBonusSpawnedTime) > TimeSpan.FromSeconds(10))) {
				mBonusPresent = false;
			}

			// Detect collision between ghosts and the player
			foreach (Ghost ghost in mGhosts) {
				Rectangle playerArea = new Rectangle((mPlayer.Position.Tile.X * 16) + mPlayer.Position.DeltaPixel.X, (mPlayer.Position.Tile.Y * 16) + mPlayer.Position.DeltaPixel.Y, 26, 26);
				Rectangle ghostArea = new Rectangle((ghost.Position.Tile.X * 16) + ghost.Position.DeltaPixel.X, (ghost.Position.Tile.Y * 16) + ghost.Position.DeltaPixel.Y, 22, 22);
				if (!Rectangle.Intersect(playerArea, ghostArea).IsEmpty) {
					// If collision detected, either kill the ghost or kill the pac man, depending on state.

					if (ghost.State == EGhostState.Blue) {
						GhostSoundsManager.StopLoops();
						mSoundBank.PlayCue("EatGhost");
						ghost.State = EGhostState.Dead;
						mEatenGhosts++;
						int bonus = (int)(100 * Math.Pow(2, mEatenGhosts));
						Score += bonus;
						mScoreEvents.Add(new ScoreEvent(ghost.Position, DateTime.Now, bonus));
						LockTimer = TimeSpan.FromMilliseconds(900);
						return;
					} else if (ghost.State != EGhostState.Dead) {
						KillPacMan();
						return;
					}
					// Otherwise ( = the ghost is dead), don't do anything special.
				}
			}

			// Periodically spawn a fruit, when the player isn't on the spawn location
			// otherwise we get an infinite fruit spawning bug
			if ((Grid.NumCrumps == 180 || Grid.NumCrumps == 80) && mBonusSpawned < 2 && !(mPlayer.Position.Tile.Y == 17 && ((mPlayer.Position.Tile.X == 13 && mPlayer.Position.DeltaPixel.X == 8) || (mPlayer.Position.Tile.X == 14 && mPlayer.Position.DeltaPixel.X == -8)))) {
				mBonusPresent = true;
				mBonusSpawned++;
				mBonusSpawnedTime = DateTime.Now;

			}

			// Now is the time to move player based on inputs and ghosts based on AI
			// If we have returned earlier in the method, they stay in place
			mPlayer.Update(gameTime);
			mGhosts.ForEach(g => g.Update(gameTime));

			base.Update(gameTime);
		}


		/// <summary>
		/// Nice to have for debug purposes. We might want the level to end early.
		/// </summary>
		/// <returns>Whether there are no crumps left on the board.</returns>
		bool noCrumpsLeft() {
			return Grid.NumCrumps == 0;
		}


		/// <summary>
		/// AAAARRRGH
		/// </summary>
		void KillPacMan() {
			mPlayer.State = EGamePlayState.Dying;
			GhostSoundsManager.StopLoops();
			mSoundBank.PlayCue("Death");
			LockTimer = TimeSpan.FromMilliseconds(1811);
			mPLayerDied = true;
			mBonusPresent = false;
			mBonusSpawned = 0;
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Draw(GameTime gameTime) {
			base.Draw(gameTime);

			// The GameLoop is a main component, so it is responsible for initializing the sprite batch each frame
			mSpriteBatch.Begin();

			Vector2 boardPosition = new Vector2((mGraphicsDeviceManager.PreferredBackBufferWidth / 2) - (mBoard.Width / 2), (mGraphicsDeviceManager.PreferredBackBufferHeight / 2) - (mBoard.Height / 2));

			// When all crumps have been eaten, flash until new level is spawned
			// Draw the player and nothing else, just end the spritebatch and return.
			if (noCrumpsLeft()) {
				mSpriteBatch.Draw(((DateTime.Now.Second * 1000 + DateTime.Now.Millisecond) / 350) % 2 == 0 ? mBoard : mBoardFlash, boardPosition, Color.White);
				mPlayer.Draw(gameTime, boardPosition);
				mSpriteBatch.End();
				return;
			}
			// Otherwise...

			// Draw the board
			mSpriteBatch.Draw(mBoard, boardPosition, Color.White);

			// Draw crumps and power pills
			GridTile[,] tiles = Grid.TileGrid;
			for (int j = 0; j < Grid.Height; j++) {
				for (int i = 0; i < Grid.Width; i++) {
					if (tiles[i, j].HasPowerPill) {
						mSpriteBatch.Draw(mPPill, new Vector2(
							boardPosition.X + 3 + (i * 16),
							boardPosition.Y + 3 + (j * 16)),
							Color.White);
					} else if (tiles[i, j].HasCrump) {
						mSpriteBatch.Draw(mCrump, new Vector2(
							boardPosition.X + 5 + (i * 16),
							boardPosition.Y + 5 + (j * 16)),
							Color.White);
					}
				}
			}

			// Draw extra lives; no more than 20 though
			for (int i = 0; i < mXLives && i < 20; i++) {
				mSpriteBatch.Draw(mXLife, new Vector2(boardPosition.X + 10 + (20 * i), mBoard.Height + boardPosition.Y + 10), Color.White);
			}

			// Draw current score
			mSpriteBatch.DrawString(mScoreFont, "SCORE", new Vector2(boardPosition.X + 30, boardPosition.Y - 50), Color.White);
			mSpriteBatch.DrawString(mScoreFont, Score.ToString(), new Vector2(boardPosition.X + 30, boardPosition.Y - 30), Color.White);

			// Draw current level
			mSpriteBatch.DrawString(mScoreFont, "LEVEL", new Vector2(boardPosition.X + mBoard.Width - 80, boardPosition.Y - 50), Color.White);
			mSpriteBatch.DrawString(mScoreFont, Constants.Level.ToString(), new Vector2(boardPosition.X + mBoard.Width - 80, boardPosition.Y - 30), Color.White);

			// Draw a bonus fruit if any
			if (mBonusPresent) {
				mSpriteBatch.Draw(mBonus[Constants.BonusSprite()], new Vector2(boardPosition.X + (13 * 16) + 2, boardPosition.Y + (17 * 16) - 8), Color.White);
			}

			// Draw captured bonus fruits at the bottom of the screen
			int k = 0;
			foreach (KeyValuePair<string, int> kvp in mBonusEaten) {
				for (int i = 0; i < kvp.Value; i++) {
					mSpriteBatch.Draw(mBonus[kvp.Key], new Vector2(boardPosition.X + 10 + (22 * (k + i)), mBoard.Height + boardPosition.Y + 22), Color.White);
				}
				k += kvp.Value;
			}

			// Draw ghosts
			mGhosts.ForEach(i => i.Draw(gameTime, boardPosition));

			// Draw player
			mPlayer.Draw(gameTime, boardPosition);

			// Draw special scores (as when a ghost or fruit has been eaten)
			foreach (ScoreEvent se in mScoreEvents) {
				mSpriteBatch.DrawString(mScoreEventFont, se.Score.ToString(), new Vector2(boardPosition.X + (se.Position.Tile.X * 16) + se.Position.DeltaPixel.X + 4, boardPosition.Y + (se.Position.Tile.Y * 16) + se.Position.DeltaPixel.Y + 4), Color.White);
			}

			// Draw GET READY ! at level start
			if (mPlayer.State == EGamePlayState.Start) {
				mSpriteBatch.DrawString(mScoreFont, "GET READY!", new Vector2(boardPosition.X + (mBoard.Width / 2) - 58, boardPosition.Y + 273), Color.Yellow);
			}

			// Display number of crumps (for debug)
			//mSpriteBatch.DrawString(mScoreFont, "Crumps left :" + Grid.NumCrumps.ToString(), Vector2.Zero, Color.White);

			mSpriteBatch.End();
		}

	}

}