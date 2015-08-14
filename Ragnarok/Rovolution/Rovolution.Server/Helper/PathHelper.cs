using System;
using Rovolution.Server.Geometry;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Helper {

	public class PathHelper {
		public const int MAX_HEAP = 150;
		public const int MAX_WALKPATH = 32;

		public static EDirection[][] WalkChoises = new EDirection[3][]{
			new EDirection[3]{EDirection.UpLeft,	EDirection.Up,	EDirection.UpRight},
			new EDirection[3]{EDirection.Left,		EDirection.None,EDirection.Right},
			new EDirection[3]{EDirection.DownLeft,	EDirection.Down,EDirection.DownRight},
		};

		private static Random RandomWay = new Random();


		/// <summary>
		/// Initialize defines, globals, bla..
		/// </summary>
		public static void Initialize() {
		}



		/*==========================================
		 * heap push (helper function)
		 *------------------------------------------*/
		private static int CalcIndex(int x, int y) {
			return ((x) + (y) * MAX_WALKPATH) & (MAX_WALKPATH * MAX_WALKPATH - 1);
		}

		private static void PushHeapPath(int[] heap, STmpPath[] tp, int index) {
			int i, h;

			h = heap[0];
			heap[0]++;

			for (i = (h - 1) / 2; h > 0 && tp[index].cost < tp[heap[i + 1]].cost; i = (h - 1) / 2) {
				heap[h + 1] = heap[i + 1];
				h = i;
			}

			heap[h + 1] = index;
		}

		/*==========================================
		 * heap update (helper function)
		 *------------------------------------------*/
		private static void UpdateHeapPath(int[] heap, STmpPath[] tp, int index) {
			int i, h;
			for (h = 0; h < heap[0]; h++) {
				if (heap[h + 1] == index) {
					break;
				}
			}
			if (h == heap[0]) {
				ServerConsole.ErrorLine("update_heap_path bug\n");
				Core.Kill();
				return;
			}

			for (i = (h - 1) / 2; h > 0 && tp[index].cost < tp[heap[i + 1]].cost; i = (h - 1) / 2) {
				heap[h + 1] = heap[i + 1];
				h = i;
			}

			heap[h + 1] = index;
		}

		/*==========================================
		 * heap pop (helper function)
		 *------------------------------------------*/
		private static int PopHeapPath(int[] heap, STmpPath[] tp) {
			int i, h, k;
			int ret, last;

			if (heap[0] <= 0)
				return -1;
			ret = heap[1];
			last = heap[heap[0]];
			heap[0]--;

			for (h = 0, k = 2; k < heap[0]; k = k * 2 + 2) {
				if (tp[heap[k + 1]].cost > tp[heap[k]].cost)
					k--;
				heap[h + 1] = heap[k + 1];
				h = k;
			}

			if (k == heap[0]) {
				heap[h + 1] = heap[k];
				h = k - 1;
			}

			for (i = (h - 1) / 2; h > 0 && tp[heap[i + 1]].cost > tp[last].cost; i = (h - 1) / 2) {
				heap[h + 1] = heap[i + 1];
				h = i;
			}

			heap[h + 1] = last;

			return ret;
		}

		/*==========================================
		 * calculate cost for the specified position
		 *------------------------------------------*/
		private static int CalcCost(STmpPath p, int x1, int y1) {
			int xd = Math.Abs(x1 - p.x);
			int yd = Math.Abs(y1 - p.y);
			return (xd + yd) * 10 + p.dist;
		}

		/*==========================================
		 * attach/adjust path if neccessary
		 *------------------------------------------*/
		public static int AddPath(int[] heap, STmpPath[] tp, int x, int y, int dist, int before, int cost) {
			int i;

			i = CalcIndex(x, y);

			if (tp[i].x == x && tp[i].y == y) {
				if (tp[i].dist > dist) {
					tp[i].dist = (short)dist;
					tp[i].before = (short)before;
					tp[i].cost = (short)cost;
					if (tp[i].flag > 0)
						PushHeapPath(heap, tp, i);
					else
						UpdateHeapPath(heap, tp, i);
					tp[i].flag = 0;
				}
				return 0;
			}

			if (tp[i].x > 0 || tp[i].y > 0)
				return 1;

			tp[i].x = (short)x;
			tp[i].y = (short)y;
			tp[i].dist = (short)dist;
			tp[i].before = (short)before;
			tp[i].cost = (short)cost;
			tp[i].flag = 0;
			PushHeapPath(heap, tp, i);

			return 0;
		}

		/*==========================================
		 * Find the closest reachable cell, 
		 * 'count' cells away from (x0,y0) in direction (dx,dy).
		 *------------------------------------------*/
		public static int BlownPos(Map m, int x0, int y0, int dx, int dy, int count) {

			if (count > 25) { //Cap to prevent too much processing...?
				ServerConsole.ErrorLine("path_blownpos: count too many {0}!", count);
				count = 25;
			}
			if (dx > 1 || dx < -1 || dy > 1 || dy < -1) {
				ServerConsole.ErrorLine("path_blownpos: illegal dx={0} or dy={1} !", dx, dy);
				dx = (dx > 0) ? 1 : ((dx < 0) ? -1 : 0);
				dy = (dy > 0) ? 1 : ((dy < 0) ? -1 : 0);
			}

			while (count > 0 && (dx != 0 || dy != 0)) {
				if (!m.CheckCell(x0 + dx, y0 + dy, ECollisionType.Walkable)) {// attempt partial movement
					bool fx = (dx != 0 && m.CheckCell(x0 + dx, y0, ECollisionType.Walkable));
					bool fy = (dy != 0 && m.CheckCell(x0, y0 + dy, ECollisionType.Walkable));
					if (fx && fy) {
						if (RandomWay.Next(0, 1) == 1)
							dx = 0;
						else
							dy = 0;
					}
					if (!fx)
						dx = 0;
					if (!fy)
						dy = 0;
				}

				x0 += dx;
				y0 += dy;
				count--;
			}

			return (x0 << 16) | y0; //TODO: use 'struct point' here instead?
		}

		/*==========================================
		 * is ranged attack from (x0,y0) to (x1,y1) possible?
		 *------------------------------------------*/
		public static bool SearchLongPath(ShootpathData spd, Map m, int x0, int y0, int x1, int y1, ECollisionType cell) {
			int dx, dy;
			int wx = 0, wy = 0;
			int weight;

			if (spd == null)
				spd = new ShootpathData(); // use dummy output variable

			dx = (x1 - x0);
			if (dx < 0) {
				x0 = x0.Swap(ref x1);
				y0 = y0.Swap(ref y1);
				dx = -dx;
			}
			dy = (y1 - y0);

			spd.rx = spd.ry = 0;
			spd.len = 1;
			spd.x[0] = x0;
			spd.y[0] = y0;

			if (m.CheckCell(x1, y1, cell))
				return false;

			if (dx > Math.Abs(dy)) {
				weight = dx;
				spd.ry = 1;
			} else {
				weight = Math.Abs(y1 - y0);
				spd.rx = 1;
			}

			while (x0 != x1 || y0 != y1) {
				if (m.CheckCell(x0, y0, cell))
					return false;
				wx += dx;
				wy += dy;
				if (wx >= weight) {
					wx -= weight;
					x0++;
				}
				if (wy >= weight) {
					wy -= weight;
					y0++;
				} else if (wy < 0) {
					wy += weight;
					y0--;
				}
				if (spd.len < MAX_WALKPATH) {
					spd.x[spd.len] = x0;
					spd.y[spd.len] = y0;
					spd.len++;
				}
			}

			return true;
		}

		/// <summary>
		/// path search (x0,y0).(x1,y1) (walkable)
		/// </summary>
		/// <param name="wpd">path info will be written here</param>
		/// <param name="m">map to check the path on</param>
		/// <param name="pStart">start-point</param>
		/// <param name="pEnd">end-point</param>
		/// <returns></returns>
		public static bool SearchPath(out WalkpathData wpd, Map m, Point2D pStart, Point2D pEnd) {
			return SearchPath(out wpd, m, pStart, pEnd, 0);
		}

		/// <summary>
		/// path search (x0,y0).(x1,y1) (walkable)
		/// <para>
		/// flag & 1 = easy path search only
		/// </para>
		/// </summary>
		/// <param name="wpd">path info will be written here</param>
		/// <param name="m">map to check the path on</param>
		/// <param name="pStart">start-point</param>
		/// <param name="pEnd">end-point</param>
		/// <param name="flag">&1 = easy path search only</param>
		/// <returns></returns>
		public static bool SearchPath(out WalkpathData wpd, Map m, Point2D pStart, Point2D pEnd, int flag) {
			return SearchPath(out wpd, m, pStart, pEnd, flag, ECollisionType.Walkable);
		}

		/// <summary>
		/// path search (x0,y0).(x1,y1)
		/// <para>
		/// flag & 1 = easy path search only
		/// </para>
		/// </summary>
		/// <param name="wpd">path info will be written here</param>
		/// <param name="m">map to check the path on</param>
		/// <param name="pStart">start-point</param>
		/// <param name="pEnd">end-point</param>
		/// <param name="flag">&1 = easy path search only</param>
		/// <param name="cell">type of obstruction to check for</param>
		/// <returns></returns>
		public static bool SearchPath(out WalkpathData wpd, Map m, Point2D pStart, Point2D pEnd, int flag, ECollisionType cell) {
			return SearchPath(out wpd, m, pStart.X, pStart.Y, pEnd.X, pEnd.Y, flag, cell);
		}

		/// <summary>
		/// path search (x0,y0).(x1,y1)
		/// <para>
		/// flag & 1 = easy path search only
		/// </para>
		/// </summary>
		/// <param name="wpd">path info will be written here</param>
		/// <param name="m">map to check the path on</param>
		/// <param name="x0">start X</param>
		/// <param name="y0">start Y</param>
		/// <param name="x1">end X</param>
		/// <param name="y1">end Y</param>
		/// <param name="flag">&1 = easy path search only</param>
		/// <param name="cell">type of obstruction to check for</param>
		/// <returns></returns>
		public static bool SearchPath(out WalkpathData wpd, Map m, int x0, int y0, int x1, int y1, int flag, ECollisionType cell) {
			int[] heap = new int[MAX_HEAP + 1];
			STmpPath[] tp = new STmpPath[MAX_WALKPATH * MAX_WALKPATH];
			int i, j, len, x, y, dx, dy;
			int rp, xs, ys;

			wpd = new WalkpathData();


			//Do not check starting cell as that would get you stuck.
			if (x0 < 0 || x0 >= m.Width || y0 < 0 || y0 >= m.Height /*|| m.CheckTile(x0,y0,cell) == false*/ )
				return false;
			if (x1 < 0 || x1 >= m.Width || y1 < 0 || y1 >= m.Height || m.CheckCell(x1, y1, cell) == false)
				return false;

			// calculate (sgn(x1-x0), sgn(y1-y0))
			dx = ((dx = x1 - x0) > 0) ? ((dx < 0) ? -1 : 1) : 0;
			dy = ((dy = y1 - y0) > 0) ? ((dy < 0) ? -1 : 1) : 0;

			// try finding direct path to target
			x = x0;
			y = y0;
			i = 0;
			while (i < wpd.path.Length) {
				wpd.path[i] = WalkChoises[-dy + 1][dx + 1];
				i++;

				x += dx;
				y += dy;

				if (x == x1)
					dx = 0;
				if (y == y1)
					dy = 0;

				if (dx == 0 && dy == 0)
					break; // success
				if (m.CheckCell(x, y, cell) == false)
					break; // obstacle = failure
			}

			if (x == x1 && y == y1) { //easy path successful.
				wpd.path_len = (uint)i;
				wpd.path_pos = 0;
				return true;
			}

			if ((flag & 1) == 1)
				return false;

			i = CalcIndex(x0, y0);
			tp[i].x = (short)x0;
			tp[i].y = (short)y0;
			tp[i].dist = 0;
			tp[i].before = 0;
			tp[i].cost = (short)CalcCost(tp[i], x1, y1);
			tp[i].flag = 0;
			heap[0] = 0;
			PushHeapPath(heap, tp, CalcIndex(x0, y0));
			xs = m.Width - 1; // ‚ ‚ç‚©‚¶‚ß‚PŒ¸ŽZ‚µ‚Ä‚¨‚­
			ys = m.Height - 1;

			while (true) {
				int e = 0, f = 0;
				int dist;
				int cost;
				int[] dc = new int[4];

				if (heap[0] == 0)
					return false;
				rp = PopHeapPath(heap, tp);
				x = tp[rp].x;
				y = tp[rp].y;
				dist = tp[rp].dist + 10;
				cost = tp[rp].cost;

				if (x == x1 && y == y1)
					break;

				// dc[0] : y++
				// dc[1] : x--
				// dc[2] : y--
				// dc[3] : x++

				if (y < ys && m.CheckCell(x, y + 1, cell)) {
					f |= 1;
					dc[0] = (y >= y1 ? 20 : 0);
					e += AddPath(heap, tp, x, y + 1, dist, rp, cost + dc[0]); // (x,   y+1)
				}
				if (x > 0 && m.CheckCell(x - 1, y, cell)) {
					f |= 2;
					dc[1] = (x <= x1 ? 20 : 0);
					e += AddPath(heap, tp, x - 1, y, dist, rp, cost + dc[1]); // (x-1, y  )
				}
				if (y > 0 && m.CheckCell(x, y - 1, cell)) {
					f |= 4;
					dc[2] = (y <= y1 ? 20 : 0);
					e += AddPath(heap, tp, x, y - 1, dist, rp, cost + dc[2]); // (x  , y-1)
				}
				if (x < xs && m.CheckCell(x + 1, y, cell)) {
					f |= 8;
					dc[3] = (x >= x1 ? 20 : 0);
					e += AddPath(heap, tp, x + 1, y, dist, rp, cost + dc[3]); // (x+1, y  )
				}
				if ((f & (2 + 1)) == (2 + 1) && m.CheckCell(x - 1, y + 1, cell))
					e += AddPath(heap, tp, x - 1, y + 1, dist + 4, rp, cost + dc[1] + dc[0] - 6); // (x-1, y+1)
				if ((f & (2 + 4)) == (2 + 4) && m.CheckCell(x - 1, y - 1, cell))
					e += AddPath(heap, tp, x - 1, y - 1, dist + 4, rp, cost + dc[1] + dc[2] - 6); // (x-1, y-1)
				if ((f & (8 + 4)) == (8 + 4) && m.CheckCell(x + 1, y - 1, cell))
					e += AddPath(heap, tp, x + 1, y - 1, dist + 4, rp, cost + dc[3] + dc[2] - 6); // (x+1, y-1)
				if ((f & (8 + 1)) == (8 + 1) && m.CheckCell(x + 1, y + 1, cell))
					e += AddPath(heap, tp, x + 1, y + 1, dist + 4, rp, cost + dc[3] + dc[0] - 6); // (x+1, y+1)
				tp[rp].flag = 1;
				if (e > 0 || heap[0] >= MAX_HEAP - 5)
					return false;
			}

			if (!(x == x1 && y == y1)) // will never happen...
				return false;

			for (len = 0, i = rp; len < 100 && i != CalcIndex(x0, y0); i = tp[i].before, len++) {
			}
			if (len == 100 || len >= wpd.path.Length)
				return false;

			wpd.path_len = (uint)len;
			wpd.path_pos = 0;
			for (i = rp, j = len - 1; j >= 0; i = tp[i].before, j--) {
				dx = tp[i].x - tp[tp[i].before].x;
				dy = tp[i].y - tp[tp[i].before].y;
				Point2D p = new Point2D(dx, dy);
				wpd.path[j] = p.ToDirection();
			}

			return true;
		}


		// Distance functions
		public static bool InRange(int dx, int dy, int range) {
			if (dx < 0)
				dx = -dx;
			if (dy < 0)
				dy = -dy;
			return ((dx < dy ? dy : dx) <= range);
		}


		public static bool check_distance_bl(WorldObjectUnit bl1, WorldObjectUnit bl2, int distance) {
			return InRange((bl1).X - (bl2).X, (bl1).Y - (bl2).Y, distance);
		}
		public static bool check_distance_blxy(WorldObjectUnit bl, int x1, int y1, int distance) {
			return InRange((bl).X - (x1), (bl).Y - (y1), distance);
		}
		public static bool check_distance_blxy(int x0, int y0, int x1, int y1, int distance) {
			return InRange((x0) - (x1), (y0) - (y1), distance);
		}

	}

}
