using System;
using System.Collections.Generic;
using GodLesZ.Games.Ragnarok.RoBot.Library.Objects;
using GodLesZ.Games.Ragnarok.RoBot.Library.Objects.Enumerations;
using Rovolution.Server.Geometry;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Geometry {

	public class Map : IMap, IDisposable {
		private static int mInstances = 1;

		private int mMapID;
		private string mName;
		private MapBlock[,] mMapBlocks;
		private ECollisionType[] mMapCells;
		private bool mIsChanged = false;


		public bool IsChanged {
			get { return mIsChanged; }
			set { mIsChanged = value; }
		}

		public MapBlock[,] Blocks {
			get { return mMapBlocks; }
		}

		public ECollisionType[] Cells {
			get { return mMapCells; }
		}

		public MapBlock this[Location loc] {
			get { return GetBlock(loc.Point); }
		}

		public MapBlock this[Point2D p] {
			get { return GetBlock(p); }
		}

		public MapBlock this[int X, int Y] {
			get { return GetBlock(X, Y); }
		}

		public int ID {
			get { return mMapID; }
		}

		public string Name {
			get { return mName; }
		}

		public int Width {
			get;
			protected set;
		}

		public int Height {
			get;
			protected set;
		}

		public int WidthBlocks {
			get { return mMapBlocks.GetLength(0); }
		}

		public int HeightBlocks {
			get { return mMapBlocks.GetLength(1); }
		}

		#region IMap Member
		int IMap.Width {
			get { return Width; }
		}

		int IMap.Height {
			get { return Height; }
		}
		#endregion


		public Map(string name, int width, int height) {
			mMapID = mInstances++;
			mName = name;
			Width = width;
			Height = height;
			mMapBlocks = new MapBlock[Width / Global.BLOCK_SIZE, Height / Global.BLOCK_SIZE];
			mMapCells = new ECollisionType[Width * Height];

			InitializeBlocks();
		}


		private void InitializeBlocks() {
			for (int bx = 0; bx < WidthBlocks; bx++) {
				for (int by = 0; by < HeightBlocks; by++) {
					mMapBlocks[bx, by] = new MapBlock(ID);
				}
			}
		}


		public static string GetClientName(string mapname) {
			mapname = mapname.ToLower();
			int max = Global.MAP_NAME_LENGTH;
			if (mapname.Length > max) {
				ServerConsole.ErrorLine("Mapname '{0}' exceeds max length of {1}!", mapname, max);
				mapname = mapname.Substring(0, max);
			}
			if (mapname.EndsWith(".gat") == false) {
				mapname += ".gat";
			}

			return mapname;
		}

		public static ECollisionType ByteToFlag(byte gat) {
			ECollisionType flag = ECollisionType.NotWalkable;
			switch (gat) {
				case 0:
					flag = (ECollisionType.Walkable | ECollisionType.Shootable);
					break; // walkable ground
				case 1:
					flag = ECollisionType.NotWalkable;
					break; // non-walkable ground
				case 2:
					flag = (ECollisionType.Walkable | ECollisionType.Shootable);
					break; // ???
				case 3:
					flag = (ECollisionType.Walkable | ECollisionType.Shootable | ECollisionType.Water);
					break; // walkable water
				case 4:
					flag = (ECollisionType.Walkable | ECollisionType.Shootable);
					break; // ???
				case 5:
					flag = (ECollisionType.Shootable);
					break; // gap (snipable)
				case 6:
					flag = (ECollisionType.Walkable | ECollisionType.Shootable);
					break; // ???
				default:
					ServerConsole.ErrorLine("Unknown tile flag {0}, default to NoWalkable", gat);
					break;
			}

			return flag;
		}


		public void OnEnter(WorldObjectUnit obj) {
			Add(obj);
		}

		public void OnLeave(WorldObjectUnit obj) {
			Remove(obj);
		}

		public void OnMove(WorldObjectUnit obj, Point2D OldLocation) {
			Move(obj, OldLocation);
		}


		public void SetBlockData(MapBlock[,] blocks) {
			mMapBlocks = blocks;
		}

		public void SetCellData(ECollisionType[] cells) {
			mMapCells = cells;
		}


		public void SetCell(Point2D p, ECollisionType cell) {
			SetCell(p.X, p.Y, cell);
		}

		public void SetCell(int x, int y, ECollisionType cell) {
			if (mMapBlocks == null || IsValidCell(x, y) == false) {
				return;
			}

			int i = (y * Width) + x;
			mMapCells[i] = cell;
		}


		public MapBlock GetBlock(Point2D p) {
			return GetBlock(p.X, p.Y);
		}

		public MapBlock GetBlock(int x, int y) {
			int bx = x / Global.BLOCK_SIZE;
			int by = y / Global.BLOCK_SIZE;

			return GetBlockReal(bx, by);
		}

		public MapBlock GetBlockReal(Point2D p) {
			return GetBlockReal(p.X, p.Y);
		}

		public MapBlock GetBlockReal(int bx, int by) {
			if (mMapBlocks == null || IsValidBlock(bx, by) == false) {
				return null;
			}

			return mMapBlocks[bx, by];
		}


		public bool CheckCell(int x, int y, ECollisionType flag) {
			if (IsValidCell(x, y) == false) {
				return false;
			}
			int i = (y * Width) + x;
			ECollisionType cell = Cells[i];
			return (cell & flag) > 0;
		}

		public bool CheckCell(Point2D p, ECollisionType flag) {
			return CheckCell(p.X, p.Y, flag);
		}


		public List<WorldObject> ObjectsInRange(Rectangle2D area, EDatabaseType type) {
			List<WorldObject> list = new List<WorldObject>();
			MapBlock block;
			for (int x = area.X / Global.BLOCK_SIZE; x < area.EndX / Global.BLOCK_SIZE; ++x) {
				for (int y = area.Y / Global.BLOCK_SIZE; y < area.EndY / Global.BLOCK_SIZE; ++y) {
					if ((block = GetBlockReal(x, y)) == null) {
						continue;
					}

					if (type != EDatabaseType.All) {
						foreach (WorldObject obj in block.Values) {
							if ((obj.WorldID.Type & type) > 0) {
								list.Add(obj);
							}
						}
					} else {
						list.AddRange(block.Values);
					}
				}
			}
			return list;
		}

		public void ForeachInRange(Rectangle2D area, EDatabaseType type, ForeachInRangeDelegate callback, object[] args) {
			List<WorldObject> objects = ObjectsInRange(area, type);

			for (int i = 0; i < objects.Count; i++) {
				WorldObject obj = objects[i];
				if (callback(obj, args) <= 0) {
					break;
				}
			}

		}

		public void ForeachInRange(Rectangle2D area, ForeachInRangeVoidDelegate callback, object[] args) {
			ForeachInRange(area, EDatabaseType.Char, callback, args);
		}

		public void ForeachInRange(Rectangle2D area, EDatabaseType type, ForeachInRangeVoidDelegate callback, object[] args) {
			List<WorldObject> objects = ObjectsInRange(area, type);

			for (int i = 0; i < objects.Count; i++) {
				WorldObject obj = objects[i];
				callback(obj, args);
			}

		}

		public void ForeachInRange(Rectangle2D area, ForeachInRangeDelegate callback, object[] args) {
			ForeachInRange(area, EDatabaseType.Char, callback, args);
		}


		public bool SearchSpawnCell(ref Location loc) {
			Point2D spawnPoint = loc.Point;
			if (spawnPoint.X < 0 || spawnPoint.Y < 0) {
				// No free cell found?
				if (loc.Map.SearchFreeCell(ref spawnPoint, 1, 1, 0) == false) {
					// The may have a position like (X, -1), means we only need to find a valid Y
					// If nothing found, we end up here & check if Y is still not valid
					if (spawnPoint.X <= 0 || spawnPoint.Y <= 0 || loc.Map.CheckCell(spawnPoint, ECollisionType.Reachable) == false) {
						// No spot arround bases position fond, search on the whole map
						if (loc.Map.SearchFreeCell(null, ref spawnPoint, -1, -1, 1) == false) {
							// No spot on the map.. maybe a bug or something else
							return false;
						}
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Locates a random spare cell around the object given, using range as max 
		/// distance from that spot. Used for warping functions. Use range below 0 for whole map range.
		/// </summary>
		/// <param name="p">Source poition to use, will also contain the new position</param>
		/// <param name="rx">Range width</param>
		/// <param name="ry">Range height</param>
		/// <param name="flag">
		/// <para>&1 = random cell must be around given m,x,y, not around src</para>
		/// <PARA>&2 = the target should be able to walk to the target tile</para>
		/// <para>&4 = there shouldn't be any players around the target tile (use the no_spawn_on_player setting)</para>
		/// </param>
		/// <returns></returns>
		public bool SearchFreeCell(ref Point2D p, int rx, int ry, int flag) {
			// Flag needs to be 1 to let src be null
			flag |= 1;
			return SearchFreeCell(null, ref p, rx, ry, flag);
		}

		/// <summary>
		/// Locates a random spare cell around the object given, using range as max 
		/// distance from that spot. Used for warping functions. Use range below 0 for whole map range.
		/// </summary>
		/// <param name="src">src can be null as long as flag&1</param>
		/// <param name="p">Source poition to use (if flag & 1), will also contain the new position</param>
		/// <param name="rx">Range width</param>
		/// <param name="ry">Range height</param>
		/// <param name="flag">
		/// <para>&1 = random cell must be around given m,x,y, not around src</para>
		/// <PARA>&2 = the target should be able to walk to the target tile</para>
		/// <para>&4 = there shouldn't be any players around the target tile (use the no_spawn_on_player setting)</para>
		/// </param>
		/// <returns></returns>
		public bool SearchFreeCell(WorldObjectUnit src, ref Point2D p, int rx, int ry, int flag) {
			int tries, spawn = 0;
			int bx, by;
			int rx2 = 2 * rx + 1;
			int ry2 = 2 * ry + 1;

			if (src == null && ((flag & 1) != 1 || (flag & 2) != 2)) {
				ServerConsole.DebugLine("SearchFreeCell: Incorrect usage! When src is NULL, flag has to be &1 and can't have &2");
				return false;
			}

			if ((flag & 1) == 1) {
				bx = p.X;
				by = p.Y;
			} else {
				bx = src.X;
				by = src.Y;
			}

			// No range? Return the target cell then....
			if (rx == 0 && ry == 0) {
				p.X = bx;
				p.Y = by;
				return CheckCell(p, ECollisionType.Reachable);
			}

			// Calc max tries
			if (rx >= 0 && ry >= 0) {
				tries = rx2 * ry2;
				if (tries > 100) {
					tries = 100;
				}
			} else {
				tries = Width * Height;
				if (tries > 500) {
					tries = 500;
				}
			}

			Random rand = new Random();
			while (tries-- > 0) {
				p.X = (rx >= 0 ? (rand.Next() % rx2 - rx + bx) : (rand.Next() % (Width - 2) + 1));
				p.Y = (ry >= 0 ? (rand.Next() % ry2 - ry + by) : (rand.Next() % (Height - 2) + 1));

				// Avoid picking the same target tile
				if (p.X == bx && p.Y == by) {
					continue;
				}

				if (CheckCell(p, ECollisionType.Reachable) == true) {
					if ((flag & 2) == 2 && src.CanReach(p, 1) == false) {
						continue;
					}
					if ((flag & 4) == 4) {
						// Limit of retries reached.
						if (spawn >= 100) {
							return false;
						}
						/*
						if (spawn++ < battle_config.no_spawn_on_player &&
							map_foreachinarea(map_count_sub, m,
								*x-AREA_SIZE, *y-AREA_SIZE,
								*x+AREA_SIZE, *y+AREA_SIZE, BL_PC)
							)
							continue;
						*/
					}

					return true;
				}
			}

			p.X = bx;
			p.Y = by;
			return false;
		}

		public bool IsValidBlock(int x, int y) {
			int bx = x / Global.BLOCK_SIZE;
			int by = y / Global.BLOCK_SIZE;
			if (bx < 0 || bx >= WidthBlocks || by < 0 || by >= HeightBlocks) {
				return false;
			}
			return true;
		}

		public bool IsValidCell(int x, int y) {
			if (x < 0 || x >= Width || y < 0 || y >= Height) {
				return false;
			}
			return true;
		}

		/*
		public void DrawGat() {
			System.Drawing.Pen pBlack = new System.Drawing.Pen(System.Drawing.Color.Black);
			System.Drawing.Pen pRed = new System.Drawing.Pen(System.Drawing.Color.Red);
			System.Drawing.Pen pPink = new System.Drawing.Pen(System.Drawing.Color.Pink);
			System.Drawing.Font font = new System.Drawing.Font("Tahoma", 7);
			int scale = 25;

			using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(Width * scale, Height * scale)) {
				using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp)) {
					for (int x = 0; x < Width; x++) {
						for (int y = 0; y < Height; y++) {
							int xs = x * scale;
							int ys = y * scale;
							if (CheckCell(x, y, ECollisionType.Walkable) == true) {
								g.DrawRectangle(pPink, xs, ys, scale, scale);
								g.DrawString(x.ToString(), font, System.Drawing.Brushes.Black, xs + 1, ys + 1);
								g.DrawString(y.ToString(), font, System.Drawing.Brushes.Black, xs + 1, ys + 1 + (scale / 2f));
							} else {
								g.DrawRectangle(pBlack, xs, ys, scale, scale);
								g.DrawString(x.ToString(), font, System.Drawing.Brushes.White, xs + 1, ys + 1);
								g.DrawString(y.ToString(), font, System.Drawing.Brushes.White, xs + 1, ys + 1 + (scale / 2f));
							}
		*/
							/*
							g.DrawLine(pRed, new System.Drawing.Point(xs, ys), new System.Drawing.Point(xs + scale, ys));
							g.DrawLine(pRed, new System.Drawing.Point(xs + scale, ys), new System.Drawing.Point(xs + scale, ys + scale));
							g.DrawLine(pRed, new System.Drawing.Point(xs, ys), new System.Drawing.Point(xs, ys + scale));
							g.DrawLine(pRed, new System.Drawing.Point(xs, ys + scale), new System.Drawing.Point(xs + scale, ys + scale));
							*/
		/*
						}
					}

					string filename = "mapdebug_" + Name.ToLower() + ".png";
					if (System.IO.File.Exists(filename) == true) {
						System.IO.File.Delete(filename);
					}
					bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
				}
			}
		}
		*/


		private void Add(WorldObjectUnit obj) {
			this[obj.Location].AddUnit(obj);
		}

		private void Remove(WorldObjectUnit obj) {
			this[obj.Location].DelUnit(obj);
		}

		private void Move(WorldObjectUnit obj, Point2D OldLocation) {
			this[OldLocation].DelUnit(obj);
			this[obj.Location].AddUnit(obj);
		}


		public virtual void Dispose() {
			mMapBlocks = null;
			mMapCells = null;
		}


		public override string ToString() {
			return string.Format("{0} [{1}/{2}]", Name, Width, Height);
		}

	}

	public delegate int ForeachInRangeDelegate(WorldObject obj, object[] args);
	public delegate void ForeachInRangeVoidDelegate(WorldObject obj, object[] args);

}
