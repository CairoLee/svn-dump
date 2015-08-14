using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GodLesZ.Games.Match3 {

	public class Board : DrawableGameComponent {
		public const int NumberOfColumns = 8;
		public const int NumberOfRows = 8;
		public const int NumberOfGems = 7;
		public const int TileHeight = 48;
		public const int TileWidth = 48;

		private readonly Random mRandom = new Random();
		private Point mDesfocus = new Point(-1, -1);
		private EBoardState mState = EBoardState.Initialize;
		private SpriteBatch mSpriteBatch;
		private InputHelper mInputState;
		private Texture2D mNumberSheet;

		public Point Focus = new Point(-1, -1);
		public Texture2D FocusTexture;
		public SoundEffect MissSound;
		public int Score;
		public Gem[,] Table = new Gem[NumberOfColumns, NumberOfRows];
		public SoundEffect WinSound;

		public Rectangle Bounds {
			get;
			protected set;
		}

		public EBoardState State {
			get { return mState; }
			protected set {
				//Debug.WriteLine("[Board] Switch state from {0} to {1}", mState, value);
				mState = value;
			}
		}


		public Board(Game game, int posX = 224, int posY = 64, int width = 384, int height = 384)
			: base(game) {
			State = EBoardState.Initialize;
			Score = 0;

			Bounds = new Rectangle(posX, posY, width, height);
		}


		private void InitializeBoard() {
			Debug.WriteLine("[Board] Initialized");

			do {
				for (var col = 0; col < NumberOfColumns; col++) {
					for (var row = 0; row < NumberOfRows; row++) {
						Table[col, row] = new Gem(Game, (EGemType)mRandom.Next(0, 7), new Vector2(Bounds.X + (col * 48), Bounds.Y + (row * 48)));
					}
				}
			} while (CheckBoard().Count != 0 || CheckMovable() == false);

			for (var col = 0; col < NumberOfColumns; col++) {
				for (var row = 0; row < NumberOfRows; row++) {
					Table[col, row].Scale = 0f;
					Table[col, row].ZoomIn = true;
				}
			}

			State = EBoardState.Input;
		}

		protected override void LoadContent() {
			mSpriteBatch = Game.Services.GetService<SpriteBatch>();
			mInputState = Game.Services.GetService<InputHelper>();
			FocusTexture = Game.Content.Load<Texture2D>(@"Texture\focus");
			MissSound = Game.Content.Load<SoundEffect>(@"Sound\sound1");
			WinSound = Game.Content.Load<SoundEffect>(@"Sound\sound2");
			mNumberSheet = Game.Content.Load<Texture2D>(@"Texture\number");

			base.LoadContent();
		}

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			if (mInputState.IsNewLeftPressed()) {
				Input(new Point(Mouse.GetState().X, Mouse.GetState().Y));
			}

			bool bCountScore;
			switch (State) {
				case EBoardState.Initialize:
					InitializeBoard();
					break;

				case EBoardState.Process:
					State = CheckBoard().Count >= 1 ? EBoardState.Destroy : EBoardState.Revert;
					break;

				case EBoardState.Swap:
					Swap();
					State = EBoardState.Process;
					break;

				case EBoardState.Revert:
					if (!Table[Focus.X, Focus.Y].IsMoving() && !Table[mDesfocus.X, mDesfocus.Y].IsMoving()) {
						Swap();
						State = EBoardState.Input;
						Focus = new Point(-1, -1);
						MissSound.Play();
					}

					break;

				case EBoardState.Destroy:
					bCountScore = true;
					for (var col = 0; col < NumberOfColumns && bCountScore; col++) {
						for (var row = 0; row < NumberOfRows; row++) {
							if (!Table[col, row].IsMoving() && !Table[col, row].ZoomOut) {
								continue;
							}

							bCountScore = false;
							break;
						}
					}

					if (bCountScore) {
						var list = CheckBoard();
						foreach (var g in list) {
							g.ZoomOut = true;
						}

						State = EBoardState.Refresh;
						Score += list.Count * list.Count;
						WinSound.Play();
					}

					break;

				case EBoardState.Refresh:
					bCountScore = true;
					for (var col = 0; col < NumberOfColumns && bCountScore; col++) {
						for (var row = 0; row < NumberOfRows; row++) {
							if (!Table[col, row].IsMoving() && !Table[col, row].ZoomOut) {
								continue;
							}

							bCountScore = false;
							break;
						}

					}

					if (bCountScore) {
						Focus = new Point(-1, -1);

						for (var col = 0; col < NumberOfColumns; col++) {
							for (var row = 0; row < NumberOfRows; row++) {
								if (Table[col, row].Scale <= 0f) {
									Table[col, row] = null;
								}
							}
						}

						for (var row = NumberOfRows - 1; row >= 0; row--) {
							for (var col = 0; col < NumberOfColumns; col++) {
								if (Table[col, row] != null) {
									continue;
								}

								for (var i = row - 1; i >= -1; i--) {
									if (i == -1) {
										Table[col, row] = new Gem(Game, (EGemType)mRandom.Next(0, 7), Mapping(new Point(col, -1)));
										Table[col, row].SetMove(Mapping(new Point(col, row)));
									} else if (Table[col, i] != null) {
										Table[col, row] = Table[col, i];
										Table[col, i] = null;
										Table[col, row].SetMove(Mapping(new Point(col, row)));
										break;
									}
								}
							}
						}

						if (CheckBoard().Count == 0) {
							State = CheckMovable() ? EBoardState.Input : EBoardState.Initialize;
						} else {
							State = EBoardState.Destroy;
						}
					}

					break;
			}

			UpdateTable(gameTime);
		}

		protected void UpdateTable(GameTime gameTime) {

			for (var col = 0; col < NumberOfColumns; col++) {
				for (var row = 0; row < NumberOfRows; row++) {
					Table[col, row].Update(gameTime);
				}
			}

		}

		public override void Draw(GameTime gameTime) {
			base.Draw(gameTime);

			// Draw each gem
			for (var r = 0; r < NumberOfColumns; r++) {
				for (var c = 0; c < NumberOfRows; c++) {
					Table[r, c].Draw(gameTime);
				}
			}


			// Focused
			var mouseState = Mouse.GetState();
			if (Bounds.Contains(mouseState.X, mouseState.Y)) {
				var posInArea = new Point(mouseState.X - Bounds.X, mouseState.Y - Bounds.Y);
				var gemPosition = new Point((posInArea.X / 48) * 48, (posInArea.Y / 48) * 48);
				var focusArea = new Rectangle(Bounds.X + gemPosition.X, Bounds.Y + gemPosition.Y, 48, 48);
				mSpriteBatch.Draw(FocusTexture, focusArea, new Color(0, 156, 255, 50));
			}

			// Selected
			if (Focus.X >= 0 && Focus.Y >= 0) {
				var selectedGemArea = new Rectangle(Bounds.X + (Focus.X * 48), Bounds.Y + (Focus.Y * 48), 48, 48);
				mSpriteBatch.Draw(FocusTexture, selectedGemArea, Color.White);
			}


			DrawScore(new Vector2(64f, 160f));
		}


		public Vector2 Mapping(Point point) {
			return new Vector2(Bounds.X + (point.X * 48), Bounds.Y + (point.Y * 48));
		}


		protected void DrawScore(Vector2 position) {
			var height = mNumberSheet.Height;
			var width = mNumberSheet.Width / 10;
			var str = Score.ToString(CultureInfo.InvariantCulture);
			for (var i = 0; i < str.Length; i++) {
				var rectangle = new Rectangle((str[i] - '0') * width, 0, width, height);
				var destinationRectangle = new Rectangle(((int)position.X) + (i * width), (int)position.Y, width, height);
				mSpriteBatch.Draw(mNumberSheet, destinationRectangle, rectangle, Color.White);
			}
		}


		protected List<Gem> CheckColumn(int col) {
			var list = new List<Gem>();
			var list2 = new List<Gem>();
			for (var row = 0; row < NumberOfRows; row++) {
				if (list.Count == 0) {
					list.Add(Table[col, row]);
				} else if (list[list.Count - 1].Type == Table[col, row].Type) {
					list.Add(Table[col, row]);
					if (row == NumberOfRows - 1 && list.Count >= 3) {
						list2.AddRange(list);
					}
				} else {
					if (list.Count >= 3) {
						list2.AddRange(list);
					}
					list.Clear();
					list.Add(Table[col, row]);
				}
			}
			return list2;
		}

		protected List<Gem> CheckBoard() {
			int num;
			var list2 = new List<Gem>();

			for (num = 0; num < NumberOfRows; num++) {
				var list = CheckRow(num);
				if (list == null) {
					continue;
				}

				list2.AddRange(list);
			}

			for (num = 0; num < NumberOfColumns; num++) {
				var list = CheckColumn(num);
				if (list == null) {
					continue;
				}

				list2.AddRange(list);
			}

			return list2;
		}

		protected bool CheckMovable() {
			for (var col = 0; col < NumberOfColumns; col++) {
				for (var row = 0; row < NumberOfRows; row++) {
					var pBase = new Point(col, row);

					if (col < NumberOfColumns - 1 && CheckSwap(pBase, new Point(col + 1, row)).Count != 0) {
						return true;
					}
					if (row < NumberOfRows - 1 && CheckSwap(pBase, new Point(col, row + 1)).Count != 0) {
						return true;
					}
				}

			}

			return false;
		}

		protected List<Gem> CheckRow(int row) {
			var list = new List<Gem>();
			var list2 = new List<Gem>();
			for (var col = 0; col < NumberOfColumns; col++) {
				if (list.Count == 0) {
					list.Add(Table[col, row]);
				} else if (list[list.Count - 1].Type == Table[col, row].Type) {
					list.Add(Table[col, row]);
					if (col == NumberOfColumns - 1 && list.Count >= 3) {
						list2.AddRange(list);
					}
				} else {
					if (list.Count >= 3) {
						list2.AddRange(list);
					}

					list.Clear();
					list.Add(Table[col, row]);
				}
			}
			return list2;
		}

		protected List<Gem> CheckSwap(Point pointA, Point pointB) {
			List<Gem> list;

			var gem = Table[pointA.X, pointA.Y];
			Table[pointA.X, pointA.Y] = Table[pointB.X, pointB.Y];
			Table[pointB.X, pointB.Y] = gem;
			list = CheckColumn(pointA.X);
			var list2 = list.ToList();
			list = CheckColumn(pointB.X);
			list2.AddRange(list);
			list = CheckRow(pointA.Y);
			list2.AddRange(list);
			list = CheckRow(pointB.Y);
			list2.AddRange(list);
			gem = Table[pointA.X, pointA.Y];
			Table[pointA.X, pointA.Y] = Table[pointB.X, pointB.Y];
			Table[pointB.X, pointB.Y] = gem;
			return list2;
		}

		protected void Input(Point point) {
			if (State != EBoardState.Input) {
				return;
			}

			if (Bounds.Contains(point) == false) {
				return;
			}

			var point2 = new Point((point.X - Bounds.X) / 48, (point.Y - Bounds.Y) / 48);
			if (Focus.X < 0 || Focus.Y < 0) {
				Focus = point2;
			} else if ((((Focus.X - point2.X) * (Focus.X - point2.X)) + ((Focus.Y - point2.Y) * (Focus.Y - point2.Y))) == 1) {
				mDesfocus = point2;
				State = EBoardState.Swap;
			} else {
				Focus = new Point(-1, -1);
			}

			Debug.WriteLine("[Board] New focus: {0}", Focus);
		}

		protected void Swap() {
			var gem = Table[Focus.X, Focus.Y];
			Table[Focus.X, Focus.Y] = Table[mDesfocus.X, mDesfocus.Y];
			Table[mDesfocus.X, mDesfocus.Y] = gem;
			Table[Focus.X, Focus.Y].SetMove(Mapping(Focus));
			Table[mDesfocus.X, mDesfocus.Y].SetMove(Mapping(mDesfocus));
		}

		protected void Swap(Point tileA, Point tileB) {
			var gem = Table[tileA.X, tileA.Y];
			Table[tileA.X, tileA.Y] = Table[tileB.X, tileB.Y];
			Table[tileB.X, tileB.Y] = gem;
			Table[tileA.X, tileA.Y].SetMove(new Vector2(Bounds.X + (tileA.X * 48), Bounds.Y + (tileA.Y * 48)));
			Table[tileB.X, tileB.Y].SetMove(new Vector2(Bounds.X + (tileB.X * 48), Bounds.Y + (tileB.Y * 48)));
		}

	}

}