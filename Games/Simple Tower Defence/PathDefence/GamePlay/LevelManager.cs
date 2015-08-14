using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PathDefence.Screens;

namespace PathDefence.GamePlay {
	public class LevelManager : DrawableGameComponent {
		public static Vector2 GridCount;
		private readonly PathDefenceGame CurrGame;
		private readonly GamePlayScreen GamePlayScreen;
		private readonly string Path;
		private SpriteBatch Background;
		private Vector2 CreepEnd;
		private Queue<int> EndPositions;
		public Vector2 GridSize;
		private byte[,] LevelGrid;
		private Vector2 Origin;
		private PathFinder PathFinder;
		private Vector2 Scale, Size;
		private Texture2D WallTex;

		public LevelManager(Game game, GamePlayScreen gamePlayScreen, string name)
			: base(game) {
			CurrGame = (PathDefenceGame)game;
			GamePlayScreen = gamePlayScreen;
			Path = "Content/Map/" + name + ".xml";
		}

		public override void Initialize() {
			GridCount = new Vector2(32, 32);
			CreepEnd = new Vector2(GridCount.X - 1, 15);
			LevelGrid = new byte[(int)GridCount.X, (int)GridCount.Y];
			Background = CurrGame.SpriteBatch;
			GridSize.X = CurrGame.CreepFieldWidth / GridCount.X;
			GridSize.Y = CurrGame.CreepFieldHeight / GridCount.Y;
			ResetLevel();

			WallTex = CurrGame.Content.Load<Texture2D>("Tower\\Textures\\Wall");
			Origin = Vector2.Zero;
			Size = new Vector2(GridSize.X, GridSize.Y);
			Scale = new Vector2(Size.X / WallTex.Width, Size.Y / WallTex.Height);
			LoadLevel();

			EndPositions = WaveManager.GenerateRandomList(32);

			PathFinder = new PathFinder(LevelGrid) { Diagonals = false, HeuristicEstimate = 100, SearchLimit = 99999 };

			base.Initialize();
		}

		public override void Draw(GameTime gameTime) {
			Background.Begin();
			for (int i = 0; i <= GridCount.X - 1; i++) {
				for (int j = 0; j <= GridCount.Y - 1; j++) {
					if (LevelGrid[i, j] < 1) {
						Background.Draw(WallTex, new Vector2(i * GridSize.X, j * GridSize.Y), null, Color.Gray, 0, Origin,
										Scale, SpriteEffects.None, 0);
					}
				}
			}
			Background.End();
			base.Draw(gameTime);
		}

		private void LoadLevel() {
			int j = 0, i = 0;
			var xml = XDocument.Load(Path);
			var levelNode = xml.Root.Element("Level");
			if (levelNode != null) {
				foreach (string s in levelNode.Value.Trim().Split(new[] { '-' })) {
					string tmp = s.Replace("\n", "").Replace("\r", "").Trim();
					if (tmp != "") {
						bool b = Convert.ToBoolean(tmp);
						LevelGrid[i, j] = (byte)(b ? 0 : 1);
						j++;

						if (j >= GridCount.Y) {
							i++;
							j = 0;
						}
					}
				}
			}
		}

		public int GetLevelHealth() {
			var xml = XDocument.Load(Path);
			var levelNode = xml.Root.Element("Level");
			if (levelNode != null) {
				return int.Parse(levelNode.Attribute("Health").Value);
			}
			return 0;
		}

		private void ResetLevel() {
			for (int i = 0; i <= GridCount.X - 1; i++) {
				for (int j = 0; j <= GridCount.Y - 1; j++) {
					LevelGrid[i, j] = 1;
				}
			}
		}

		private void SetField(byte value, int x, int y) {
			if ((x <= LevelGrid.GetUpperBound(0)) && (x >= 0) && (y <= LevelGrid.GetUpperBound(1)) && (y >= 0)) {
				LevelGrid[x, y] = value;
			}
		}

		private byte GetField(int x, int y) {
			if ((x <= LevelGrid.GetUpperBound(0)) && (x >= 0) && (y <= LevelGrid.GetUpperBound(1)) && (y >= 0)) {
				return LevelGrid[x, y];
			}
			return 0;
		}

		public void BuildTower(Vector2 position, Vector2 size) {
			for (int i = (int)position.X - 1; i < position.X + size.X - 1; i++) {
				for (int j = (int)position.Y - 1; j < position.Y + size.Y - 1; j++) {
					SetField(0, i, j);
				}
			}
		}

		public bool CanBuildTower(Vector2 pos, Vector2 size) {
			if (pos.X < 1 || (size.X > 1 ? pos.X >= 30 : pos.X >= 31)) {
				return false;
			}
			bool freePlace = true;
			var newPoints = new List<Vector2>();
			var tmpGrid = (byte[,])LevelGrid.Clone();
			for (var i = (int)pos.X; i < pos.X + size.X; i++) {
				for (var j = (int)pos.Y; j < pos.Y + size.Y; j++) {
					if (GetField(i, j) == 0) {
						freePlace = false;
					}
					SetField(0, i, j);
					newPoints.Add(new Vector2(i, j));
				}
			}
			bool wayAvailable = IsWayAvailable(Vector2.Zero) && freePlace;
			if (wayAvailable) {
				wayAvailable = GamePlayScreen.CheckCreepWay(newPoints);
			}
			for (int i = 0; i < GridCount.X; i++) {
				for (int j = 0; j < GridCount.Y; j++) {
					LevelGrid[i, j] = tmpGrid[i, j];
				}
			}
			return wayAvailable;
		}

		public bool IsWayAvailable(Vector2 start) {
			return PathFinder.FindPath(start, CreepEnd) != null;
		}

		public Queue<Vector2> FindPath(Vector2 start) {
			var tmpList = new Queue<Vector2>();
			CreepEnd = new Vector2(GridCount.X - 1, EndPositions.Dequeue());
			if (EndPositions.Count == 0) {
				EndPositions = WaveManager.GenerateRandomList(32);
			}
			List<PathFinderNode> pathList = PathFinder.FindPath(start, CreepEnd);
			if (pathList != null) {
				for (int i = pathList.Count - 1; i >= 0; i--) {
					PathFinderNode node = pathList[i];
					tmpList.Enqueue(new Vector2(node.X, node.Y));
				}
			}
			return tmpList;
		}

		public void RemoveTower(Vector2 pos, Vector2 size) {
			for (int i = (int)pos.X - 1; i < pos.X + size.X - 1; i++) {
				for (int j = (int)pos.Y - 1; j < pos.Y + size.Y - 1; j++) {
					SetField(1, i, j);
				}
			}
		}
	}
}