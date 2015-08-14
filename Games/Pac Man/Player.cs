using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace PacMan {

	/// <summary>
	/// This is the yellow pac man that eat dots and gets killed 
	/// repetitively unless you're good.
	/// </summary>
	public class Player : GameComponent {
		private static Keys[] VALIDKEYS = { Keys.Up, Keys.Down, Keys.Left, Keys.Right };

		private TimeSpan mTimer;
		private SpriteBatch mSpriteBatch;
		private Texture2D mDyingFrames;
		private Texture2D[] mEatingFrames;
		private int[] mUsedFramesIndex;
		private int mUpdatesPerPixel;
		private int mUpdateCount;

		public EGamePlayState State {
			get;
			set;
		}

		public EDirection Direction {
			get;
			private set;
		}

		public EntityPosition Position;


		public Player(Game game) : base(game) {
			Reset();

			mUpdatesPerPixel = Constants.PacManSpeed();
			mSpriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
			mEatingFrames = new Texture2D[] {
                game.Content.Load<Texture2D>("sprites/PacManEating1"),
                game.Content.Load<Texture2D>("sprites/PacManEating2"),
                game.Content.Load<Texture2D>("sprites/PacManEating3"),
                game.Content.Load<Texture2D>("sprites/PacManEating4"),
                game.Content.Load<Texture2D>("sprites/PacManEating5"),
                game.Content.Load<Texture2D>("sprites/PacManEating6"),
                game.Content.Load<Texture2D>("sprites/PacManEating7"),
                game.Content.Load<Texture2D>("sprites/PacManEating8"),
                game.Content.Load<Texture2D>("sprites/PacManEating9"),
            };
			mDyingFrames = Game.Content.Load<Texture2D>("sprites/DyingSheetNew");
		}


		/// <summary>
		/// Allows the Player to update itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime) {

			// First, deal with keyboard input. Get only the direction keys.
			Keys[] pressedKeys = (
				from k in Keyboard.GetState().GetPressedKeys()
				where VALIDKEYS.Contains(k)
				select k
			).ToArray();

			// If the player is pressing more than one key, we don't turn. Trying to filter keys would be
			// either bogus or overly complex for the needs of this game, and yes, this is from experience.
			if (pressedKeys.Length == 1) {

				// At level start, Pac Man is facing right, although he is drawn full. Pressing
				// Right simply makes him start moving in that direction; pressing Left make him change direction
				// first; this must be handled separately from the usual case.
				if (State == EGamePlayState.Start) {
					if (pressedKeys[0] == Keys.Left || pressedKeys[0] == Keys.Right) {
						State = EGamePlayState.Normal;
					}
					if (pressedKeys[0] == Keys.Left) {
						TryTurn(pressedKeys[0]);
					}
				}
					// Normal case : turn if required direction != current direction.
				else if ((Direction.ToString() != pressedKeys[0].ToString())) {
					TryTurn(pressedKeys[0]);
				}
			}

			TryMove();
		}

		/// <summary>
		/// Ensures that if the Pac Man moves, it is a legal move
		/// </summary>
		void TryMove() {
			if (State == EGamePlayState.Start) {
				return;
			}
			// If between two tiles, movement is always allowed since TryTurn()
			// always ensures direction is valid
			if (Position.DeltaPixel != Point.Zero) {
				DoMove();
			}
				// Special case : the tunnel.
			else if ((Position.Tile == new Point(0, 14) && Direction == EDirection.Left) ||
					 (Position.Tile == new Point(27, 14) && Direction == EDirection.Right)) {
				DoMove();
			}
				// If on a tile, we only move if the next tile in our direction is open
			else if ((Direction == EDirection.Up && Grid.TileGrid[Position.Tile.X, Position.Tile.Y - 1].Type == ETileTypes.Open) ||
					  (Direction == EDirection.Down && Grid.TileGrid[Position.Tile.X, Position.Tile.Y + 1].Type == ETileTypes.Open) ||
					  (Direction == EDirection.Left && Grid.TileGrid[Position.Tile.X - 1, Position.Tile.Y].Type == ETileTypes.Open) ||
					  (Direction == EDirection.Right && Grid.TileGrid[Position.Tile.X + 1, Position.Tile.Y].Type == ETileTypes.Open)) {
				DoMove();
			}

		}


		/// <summary>
		/// Effectively moves the Pac Man according to member variable Direction.
		/// </summary>
		void DoMove() {
			// Everytime the updateCount == updatesPerPixel, move one pixel in
			// the desired direction and reset the updateCount.
			mUpdateCount++;
			mUpdateCount %= mUpdatesPerPixel;
			if (mUpdateCount == 0) {

				// Now is a nice time to update our speed, like we do for the ghosts.
				if (Ghost.NextTile(Direction, Position).HasCrump) {
					mUpdatesPerPixel = Constants.PacManSpeed() + 2;
				} else {
					mUpdatesPerPixel = Constants.PacManSpeed();
				}

				// Move one pixel in the desired direction
				if (Direction == EDirection.Up) {
					Position.DeltaPixel.Y--;
				} else if (Direction == EDirection.Down) {
					Position.DeltaPixel.Y++;
				} else if (Direction == EDirection.Left) {
					Position.DeltaPixel.X--;
				} else if (Direction == EDirection.Right) {
					Position.DeltaPixel.X++;
				}

				// By moving one pixel we might have moved to another tile completely
				if (Position.DeltaPixel.X == 16) {
					// Special case : the tunnel
					if (Position.Tile.X == 27) {
						Position.Tile.X = 0;
					} else {
						Position.Tile.X++;
					}
					Position.DeltaPixel.X = 0;
				} else if (Position.DeltaPixel.X == -16) {
					// Special case : the tunnel
					if (Position.Tile.X == 0) {
						Position.Tile.X = 27;
					} else {
						Position.Tile.X--;
					}
					Position.DeltaPixel.X = 0;
				} else if (Position.DeltaPixel.Y == 16) {
					Position.Tile.Y++;
					Position.DeltaPixel.Y = 0;
				} else if (Position.DeltaPixel.Y == -16) {
					Position.Tile.Y--;
					Position.DeltaPixel.Y = 0;
				}
			}
		}

		/// <summary>
		/// Allows the Player to be drawn to the screen. Assumes spritebatch.begin() has been called, and
		/// spritebatch.end() will be called afterwards.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public void Draw(GameTime gameTime, Vector2 boardPosition) {
			// The position is taken as a function of the board position, the tile on which the pac man is, how many
			// pixels he is off from this tile, and the size of the pac man itself versus the size of a tile (16).
			Vector2 position;
			position.X = boardPosition.X + (Position.Tile.X * 16) + Position.DeltaPixel.X - ((mEatingFrames[0].Width - 16) / 2);
			position.Y = boardPosition.Y + (Position.Tile.Y * 16) + Position.DeltaPixel.Y - ((mEatingFrames[0].Height - 16) / 2);

			// At level start, just draw the full pac man and exit
			if (State == EGamePlayState.Start) {
				mSpriteBatch.Draw(mEatingFrames[0], position, Color.White);
			} else if (State == EGamePlayState.Normal) {
				// The frame index is taken as a function of how much the pac man is off from a tile, the size of
				// a tile (always 16 pixels), and how many frames we use for the animation.
				int frame = Math.Abs(Position.DeltaPixel.X + Position.DeltaPixel.Y) / (16 / mUsedFramesIndex.Length);
				frame = (int)MathHelper.Clamp(frame, 0, mUsedFramesIndex.Length - 1);
				RenderSprite(mEatingFrames[mUsedFramesIndex[frame]], null, boardPosition, position);
			} else if (State == EGamePlayState.Dying) {
				int timeBetweenFrames = 90; // Sound "Death" is 1811 milliseconds long, we have 20 frames to go through.
				mTimer += gameTime.ElapsedGameTime;
				int index = (mTimer.Seconds * 1000 + mTimer.Milliseconds) / timeBetweenFrames;
				if (index > 19) {
					return;
				}
				RenderSprite(mDyingFrames, new Rectangle(26 * index, 0, 26, 26), boardPosition, position);
			}

		}


		/// <summary>
		/// Allows rendering across the tunnel, which is tricky.
		/// </summary>
		/// <param name="spriteSheet">Source texture</param>
		/// <param name="rectangle">Portion of the source to render. Pass null for rendering the whole texture.</param>
		/// <param name="boardPosition">Top-left pixel of the board in the screen</param>
		/// <param name="position">Where to render the texture.</param>
		void RenderSprite(Texture2D spriteSheet, Rectangle? rectangle, Vector2 boardPosition, Vector2 position) {

			Rectangle rect = rectangle == null ? new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height) :
												rectangle.Value;

			// What happens when we are crossing to the other end by the tunnel?
			// We detect if part of the pacman is rendered outside of the board.
			// First, to the left.
			if (position.X < boardPosition.X) {
				int deltaPixel = (int)(boardPosition.X - position.X); // Number of pixels off the board
				var leftPortion = new Rectangle(rect.X + deltaPixel, rect.Y, 26 - deltaPixel, 26);
				var leftPortionPosition = new Vector2(boardPosition.X, position.Y);
				var rightPortion = new Rectangle(rect.X, rect.Y, deltaPixel, 26);
				var rightPortionPosition = new Vector2(boardPosition.X + (16 * 28) - deltaPixel, position.Y);
				mSpriteBatch.Draw(spriteSheet, leftPortionPosition, leftPortion, Color.White);
				mSpriteBatch.Draw(spriteSheet, rightPortionPosition, rightPortion, Color.White);
			}
				// Next, to the right
			else if (position.X > (boardPosition.X + (16 * 28) - 26)) {
				int deltaPixel = (int)((position.X + 26) - (boardPosition.X + (16 * 28))); // Number of pixels off the board
				var leftPortion = new Rectangle(rect.X + 26 - deltaPixel, rect.Y, deltaPixel, 26);
				var leftPortionPosition = new Vector2(boardPosition.X, position.Y);
				var rightPortion = new Rectangle(rect.X, rect.Y, 26 - deltaPixel, 26);
				var rightPortionPosition = new Vector2(position.X, position.Y);
				mSpriteBatch.Draw(spriteSheet, leftPortionPosition, leftPortion, Color.White);
				mSpriteBatch.Draw(spriteSheet, rightPortionPosition, rightPortion, Color.White);
			}
				// Draw normally - in one piece
			else {
				mSpriteBatch.Draw(spriteSheet, position, rect, Color.White);
			}
		}

		/// <summary>
		/// Should be called anytime the Pac Man needs to be reset (game start, level start)
		/// </summary>
		void Reset() {
			State = EGamePlayState.Start;
			Direction = EDirection.Right;
			mUsedFramesIndex = new int[] { 0, 1, 2 };
			Position = new EntityPosition { Tile = new Point(13, 23), DeltaPixel = new Point(8, 0) };
			mUpdateCount = 0;
		}



		/// <summary>
		/// Ensures that if the Pac Man turns, it's in a valid direction.
		/// </summary>
		/// <param name="input">Direction the player tries to steer the Pac Man towards</param>
		void TryTurn(Keys input) {

			// If we're between two tiles, we can only turn 180
			if (Position.DeltaPixel != Point.Zero) {
				if ((Direction == EDirection.Up && input == Keys.Down) ||
					(Direction == EDirection.Down && input == Keys.Up) ||
					(Direction == EDirection.Left && input == Keys.Right) ||
					(Direction == EDirection.Right && input == Keys.Left)) {
					// Turning 180 between two tiles implies destination tile is open, 
					// no other validation to be done
					DoTurn(input);
				}
			}
				// Special case : the tunnel.
			else if ((input == Keys.Left && Position.Tile.X == 0) ||
					  (input == Keys.Right && Position.Tile.X == 27)) {
				DoTurn(input);
			}
				// We're exactly on a tile; this is the "general" case
				// Do turn if the destination tile is open
			else if ((input == Keys.Up && Grid.TileGrid[Position.Tile.X, Position.Tile.Y - 1].Type == ETileTypes.Open) ||
					  (input == Keys.Down && Grid.TileGrid[Position.Tile.X, Position.Tile.Y + 1].Type == ETileTypes.Open) ||
					  (input == Keys.Left && Grid.TileGrid[Position.Tile.X - 1, Position.Tile.Y].Type == ETileTypes.Open) ||
					  (input == Keys.Right && Grid.TileGrid[Position.Tile.X + 1, Position.Tile.Y].Type == ETileTypes.Open)) {
				DoTurn(input);
			}

		}


		/// <summary>
		/// This effectively makes Pac Man turn.
		/// We have to update the sprites used for animation,
		/// and if the Pac Man is between two tiles, change his Position.
		/// </summary>
		/// <param name="newDirection">Direction to turn towards</param>
		void DoTurn(Keys newDirection) {

			switch (newDirection) {
				case Keys.Up:
					Direction = EDirection.Up;
					mUsedFramesIndex = new int[] { 0, 7, 8 };
					if (Position.DeltaPixel != Point.Zero) {
						Position.Tile.Y += 1;
						Position.DeltaPixel.Y -= 16;
					}
					break;
				case Keys.Down:
					Direction = EDirection.Down;
					mUsedFramesIndex = new int[] { 0, 3, 4 };
					if (Position.DeltaPixel != Point.Zero) {
						Position.Tile.Y -= 1;
						Position.DeltaPixel.Y += 16;
					}
					break;
				case Keys.Left:
					Direction = EDirection.Left;
					mUsedFramesIndex = new int[] { 0, 5, 6 };
					if (Position.DeltaPixel != Point.Zero) {
						Position.Tile.X += 1;
						Position.DeltaPixel.X -= 16;
					}
					break;
				case Keys.Right:
					Direction = EDirection.Right;
					mUsedFramesIndex = new int[] { 0, 1, 2 };
					if (Position.DeltaPixel != Point.Zero) {
						Position.Tile.X -= 1;
						Position.DeltaPixel.X += 16;
					}
					break;
			}
		}

	}

}