using System;
using Microsoft.Xna.Framework;
using Tetris.Helpers;
using Tetris.Sounds;

namespace Tetris {

	/// <summary>
	/// TetrisGrid helper class to manage the grid and all block types for
	/// the tetris game.
	/// </summary>
	public class TetrisGrid : Microsoft.Xna.Framework.DrawableGameComponent {
		public const int GridWidth = 12;
		public const int GridHeight = 20;

		/// <summary>
		/// Number of block types we can use for each grid block.
		/// </summary>
		public static readonly int NumOfBlockTypes = Enum.GetNames(typeof(EBlockTypes)).Length;

		/// <summary>
		/// Block colors for each block type.
		/// </summary>
		public static readonly Color[] BlockColor = new Color[] {
			new Color( 60, 60, 60, 128 ), // Empty, color unused
			new Color( 50, 50, 255, 255 ), // Line, blue
			new Color( 160, 160, 160, 255 ), // Block, gray
			new Color( 255, 50, 50, 255 ), // RightT, red
			new Color( 255, 255, 50, 255 ), // LeftT, yellow
			new Color( 50, 255, 255, 255 ), // RightShape, teal
			new Color( 255, 50, 255, 255 ), // LeftShape, purple
			new Color( 50, 255, 50, 255 ), // Triangle, green
		};

		/// <summary>
		/// Unrotated shapes
		/// </summary>
		public static readonly int[][,] BlockTypeShapesNormal = new int[][,] {
			// Empty
			new int[,] { { 0 } },
			// Line
			new int[,] { 
						{ 0, 1, 0 }, 
						{ 0, 1, 0 }, 
						{ 0, 1, 0 }, 
						{ 0, 1, 0 } 
			},
			// Block
			new int[,] {
						{ 1, 1 },
						{ 1, 1 }
			},
			// RightT
			new int[,] {
						{ 1, 1 }, 
						{ 1, 0 }, 
						{ 1, 0 } 
			},
			// LeftT
			new int[,] { 
						{ 1, 1 }, 
						{ 0, 1 }, 
						{ 0, 1 } 
			},
			// RightShape
			new int[,] { 
						{ 0, 1, 1 }, 
						{ 1, 1, 0 } 
			},
			// LeftShape
			new int[,] {
						{ 1, 1, 0 }, 
						{ 0, 1, 1 } 
			},
			// Triangle
			new int[,] {
						{ 0, 1, 0 }, 
						{ 1, 1, 1 }, 
						{ 0, 0, 0 } 
			},
		};

		/// <summary>
		/// Remember game for accessing textures and sprites
		/// </summary>
		private TetrisGame mGame = null;

		/// <summary>
		/// Precalculated Rotated shapes
		/// </summary>
		private static int[,][,] mBlockTypeShapes;

		/// <summary>
		/// The actual grid, contains all blocks,
		/// including the currently falling block.
		/// </summary>
		private EBlockTypes[,] mGrid = new EBlockTypes[GridWidth, GridHeight];
		/// <summary>
		/// Use this simple array to see where the floating parts are.
		/// Simply check from bottom up and putting stuff in the next line.
		/// </summary>
		private bool[,] mFloatingGrid = new bool[GridWidth, GridHeight];

		/// <summary>
		/// Remember current block type and rotation
		/// </summary>
		private int mCurrentBlockType = 0;
		private int mCurrentBlockRot = 0;
		private Point mCurrentBlockPos;

		/// <summary>
		/// Next block game component, does not only store the next block type,
		/// but also displays it.
		/// </summary>
		internal NextBlock mNextBlock;

		/// <summary>
		/// Grid rectangle for drawing.
		/// </summary>
		private Rectangle mGridRect;

		/// <summary>
		/// When game is over, this is set to true, start over then!
		/// </summary>
		public bool GameOver {
			get;
			set;
		}

		/// <summary>
		/// Remember if moving down was blocked, this increases
		/// the game speed because we can force the next block!
		/// </summary>
		public bool MovingDownWasBlocked {
			get;
			set;
		}

		// Current score we got
		public int TotalScore {
			get;
			set;
		}

		// Number of lines we crushed
		public int CrushedLines {
			get;
			set;
		}


		public TetrisGrid(TetrisGame setGame, Rectangle setGridRect, Rectangle setNextBlockRect)
			: base(setGame) {
			mGame = setGame;
			mGridRect = setGridRect;

			mNextBlock = new NextBlock(mGame, setNextBlockRect);
			mGame.Components.Add(mNextBlock);
		}


		public override void Initialize() {
			// Precalculate Rotated shapes, for all types
			mBlockTypeShapes = new int[NumOfBlockTypes, 4][,];
			for (int type = 0; type < NumOfBlockTypes; type++) {
				int[,] shape = BlockTypeShapesNormal[type];
				int width = shape.GetLength(0);
				int height = shape.GetLength(1);
				// Init all precalculated shapes
				mBlockTypeShapes[type, 0] = new int[height, width];
				mBlockTypeShapes[type, 1] = new int[width, height];
				mBlockTypeShapes[type, 2] = new int[height, width];
				mBlockTypeShapes[type, 3] = new int[width, height];
				for (int x = 0; x < width; x++)
					for (int y = 0; y < height; y++) {
						mBlockTypeShapes[type, 0][y, x] = shape[(width - 1) - x, y];
						mBlockTypeShapes[type, 1][x, y] = shape[x, y];
						mBlockTypeShapes[type, 2][y, x] = shape[x, (height - 1) - y];
						mBlockTypeShapes[type, 3][x, y] = shape[(width - 1) - x, (height - 1) - y];
					}
			}

			Restart();
			AddRandomBlock();

			base.Initialize();
		}

		public void Restart() {
			for (int x = 0; x < GridWidth; x++) {
				for (int y = 0; y < GridHeight; y++) {
					mGrid[x, y] = EBlockTypes.Empty;
					mFloatingGrid[x, y] = false;
				}
			}

			// Done automatically: AddRandomBlock();
			Sound.Play(ESoundTypes.Fight);
		}

		/// <summary>
		/// Adds a random block in the top middle
		/// </summary>
		public void AddRandomBlock() {
			// Randomize block type and rotation
			mCurrentBlockType = (int)mNextBlock.SetNewRandomBlock();
			mCurrentBlockRot = RandomHelper.GetRandomInt(4);

			// Get precalculated shape
			int[,] shape = mBlockTypeShapes[mCurrentBlockType, mCurrentBlockRot];
			int xPos = GridWidth / 2 - shape.GetLength(0) / 2;
			// Center block at top most position of our grid
			mCurrentBlockPos = new Point(xPos, 0);

			// Add new block
			for (int x = 0; x < shape.GetLength(0); x++) {
				for (int y = 0; y < shape.GetLength(1); y++) {
					if (shape[x, y] > 0) {
						// Check if there is already something
						if (mGrid[x + xPos, y] != EBlockTypes.Empty) {
							// Then game is over dude!
							GameOver = true;
							Sound.Play(ESoundTypes.Lose);
						} else {
							mGrid[x + xPos, y] = (EBlockTypes)mCurrentBlockType;
							mFloatingGrid[x + xPos, y] = true;
						}
					}
				}
			}

			// Add 1 point per block!
			TotalScore++;
		}

		/// <summary>
		/// Move current floating block to left, right or down.
		/// If anything is blocking, moving is not possible and
		/// nothing gets changed!
		/// </summary>
		/// <returns>Returns true if moving was successful, otherwise false</returns>
		public bool MoveBlock(EMoveTypes moveType) {
			// Clear old pos
			for (int x = 0; x < GridWidth; x++) {
				for (int y = 0; y < GridHeight; y++) {
					if (mFloatingGrid[x, y]) {
						mGrid[x, y] = EBlockTypes.Empty;
					}
				}
			}

			// Move stuff to new position
			bool anythingBlocking = false;
			Point[] newPos = new Point[4];
			int newPosNum = 0;
			if (moveType == EMoveTypes.Left) {
				for (int x = 0; x < GridWidth; x++) {
					for (int y = 0; y < GridHeight; y++) {
						if (mFloatingGrid[x, y]) {
							if (x - 1 < 0 || mGrid[x - 1, y] != EBlockTypes.Empty) {
								anythingBlocking = true;
							} else if (newPosNum < 4) {
								newPos[newPosNum] = new Point(x - 1, y);
								newPosNum++;
							}
						}
					}
				}
			} else if (moveType == EMoveTypes.Right) {
				for (int x = 0; x < GridWidth; x++) {
					for (int y = 0; y < GridHeight; y++) {
						if (mFloatingGrid[x, y]) {
							if (x + 1 >= GridWidth || mGrid[x + 1, y] != EBlockTypes.Empty) {
								anythingBlocking = true;
							} else if (newPosNum < 4) {
								newPos[newPosNum] = new Point(x + 1, y);
								newPosNum++;
							}
						}
					}
				}
			} else if (moveType == EMoveTypes.Down) {
				for (int x = 0; x < GridWidth; x++) {
					for (int y = 0; y < GridHeight; y++) {
						if (mFloatingGrid[x, y]) {
							if (y + 1 >= GridHeight || mGrid[x, y + 1] != EBlockTypes.Empty) {
								anythingBlocking = true;
							} else if (newPosNum < 4) {
								newPos[newPosNum] = new Point(x, y + 1);
								newPosNum++;
							}
						}
					}
				}
				if (anythingBlocking == true) {
					MovingDownWasBlocked = true;
				}
			}

			// If anything is blocking restore old state
			// Or we didn't get all 4 new positions?
			if (anythingBlocking || newPosNum != 4) {
				for (int x = 0; x < GridWidth; x++) {
					for (int y = 0; y < GridHeight; y++) {
						if (mFloatingGrid[x, y]) {
							mGrid[x, y] = (EBlockTypes)mCurrentBlockType;
						}
					}
				}
				return false;
			} else {
				if (moveType == EMoveTypes.Left) {
					mCurrentBlockPos = new Point(mCurrentBlockPos.X - 1, mCurrentBlockPos.Y);
				} else if (moveType == EMoveTypes.Right) {
					mCurrentBlockPos = new Point(mCurrentBlockPos.X + 1, mCurrentBlockPos.Y);
				} else if (moveType == EMoveTypes.Down) {
					mCurrentBlockPos = new Point(mCurrentBlockPos.X, mCurrentBlockPos.Y + 1);
				}

				// Else we can move to the new position, lets do it!
				for (int x = 0; x < GridWidth; x++) {
					for (int y = 0; y < GridHeight; y++) {
						mFloatingGrid[x, y] = false;
					}
				}
				for (int i = 0; i < 4; i++) {
					mGrid[newPos[i].X, newPos[i].Y] = (EBlockTypes)mCurrentBlockType;
					mFloatingGrid[newPos[i].X, newPos[i].Y] = true;
				}

				Sound.Play(ESoundTypes.BlockMove);

				return true;
			}
		}

		public void RotateBlock() {
			// Clear old pos
			for (int x = 0; x < GridWidth; x++) {
				for (int y = 0; y < GridHeight; y++) {
					if (mFloatingGrid[x, y]) {
						mGrid[x, y] = EBlockTypes.Empty;
					}
				}
			}

			// Rotate and check if new position is valid
			bool anythingBlocking = false;
			Point[] newPos = new Point[4];
			int newPosNum = 0;

			int newRotation = (mCurrentBlockRot + 1) % 4;
			int[,] shape = mBlockTypeShapes[mCurrentBlockType, newRotation];
			for (int x = 0; x < shape.GetLength(0); x++) {
				for (int y = 0; y < shape.GetLength(1); y++) {
					if (shape[x, y] > 0) {
						if (mCurrentBlockPos.X + x >= GridWidth ||
							mCurrentBlockPos.Y + y >= GridHeight ||
							mCurrentBlockPos.X + x < 0 ||
							mCurrentBlockPos.Y + y < 0 ||
							mGrid[mCurrentBlockPos.X + x, mCurrentBlockPos.Y + y] != EBlockTypes.Empty) {

							anythingBlocking = true;
						} else if (newPosNum < 4) {
							newPos[newPosNum] = new Point(mCurrentBlockPos.X + x, mCurrentBlockPos.Y + y);
							newPosNum++;
						}
					}
				}
			}

			// If anything is blocking restore old state
			// Or we didn't get all 4 new positions?
			if (anythingBlocking || newPosNum != 4) {
				for (int x = 0; x < GridWidth; x++) {
					for (int y = 0; y < GridHeight; y++) {
						if (mFloatingGrid[x, y]) {
							mGrid[x, y] = (EBlockTypes)mCurrentBlockType;
						}
					}
				}
			} else {
				// Else we can rotate, lets do it!
				mCurrentBlockRot = newRotation;
				for (int x = 0; x < GridWidth; x++) {
					for (int y = 0; y < GridHeight; y++) {
						mFloatingGrid[x, y] = false;
					}
				}

				for (int i = 0; i < 4; i++) {
					mGrid[newPos[i].X, newPos[i].Y] = (EBlockTypes)mCurrentBlockType;
					mFloatingGrid[newPos[i].X, newPos[i].Y] = true;
				}

				Sound.Play(ESoundTypes.BlockRotate);
			}
		}

		/// <summary>
		/// Update whole field, move current floating stuff down
		/// and check if any full lines are given.
		/// Note: Do not use the override Update(gameTime) method here,
		/// Update is ONLY called when 1000ms have passed (level 1), or
		/// 100ms for level 10.
		/// </summary>
		public void Update() {
			if (GameOver || TetrisGame.Paused) {
				return;
			}

			if (MoveBlock(EMoveTypes.Down) == false || MovingDownWasBlocked) {
				for (int x = 0; x < GridWidth; x++) {
					for (int y = 0; y < GridHeight; y++) {
						mFloatingGrid[x, y] = false;
					}
				}
				Sound.Play(ESoundTypes.BlockFalldown);
			}
			MovingDownWasBlocked = false;

			bool canMove = false;
			for (int x = 0; x < GridWidth; x++) {
				for (int y = 0; y < GridHeight; y++) {
					if (mFloatingGrid[x, y]) {
						canMove = true;
					}
				}
			}

			if (canMove == false) {
				int linesKilled = 0;
				for (int y = 0; y < GridHeight; y++) {
					bool fullLine = true;
					for (int x = 0; x < GridWidth; x++) {
						if (mGrid[x, y] == EBlockTypes.Empty) {
							fullLine = false;
							break;
						}
					}

					if (fullLine) {
						for (int yDown = y - 1; yDown > 0; yDown--) {
							for (int x = 0; x < GridWidth; x++) {
								mGrid[x, yDown + 1] = mGrid[x, yDown];
							}
						}

						for (int x = 0; x < GridWidth; x++) {
							mGrid[0, x] = EBlockTypes.Empty;
						}

						TotalScore += 10;
						CrushedLines++;
						linesKilled++;
						Sound.Play(ESoundTypes.LineKill);
					}
				}

				if (linesKilled >= 2) {
					TotalScore += 5;
				}
				if (linesKilled >= 3) {
					TotalScore += 10;
				}
				if (linesKilled >= 4) {
					TotalScore += 25;
				}

				AddRandomBlock();
			}
		}

		public override void Draw(GameTime gameTime) {
			mNextBlock.Draw(gameTime);

			int blockWidth = mGridRect.Width / GridWidth;
			int blockHeight = mGridRect.Height / GridHeight;
			if (blockWidth < 2) {
				blockWidth = 2;
			}
			if (blockHeight < 2) {
				blockHeight = 2;
			}

			for (int x = 0; x < GridWidth; x++) {
				for (int y = 0; y < GridHeight; y++) {
					mGame.BlockSprite.Render(new Rectangle(mGridRect.X + x * blockWidth, mGridRect.Y + y * blockHeight, blockWidth - 1, blockHeight - 1), BlockColor[(int)mGrid[x, y]]);
				}
			}
		}

	}

}
