using System;
using System.Drawing;
namespace a
{
	public enum G2
	{
		East,
		South,
		West,
		North,
		None
	}
	public class g2
	{
		public const int A = 0;
		public const int a = 1;
		public const int B = 2;
		public const int b = 3;
		public const int C = 4;
		public const int c = 1;
		public const int D = 2;
		public static bool A(G2 g)
		{
			return g >= G2.East && g <= G2.North;
		}
		public static bool a(G2 g)
		{
			return g == G2.East || g == G2.West;
		}
		public static bool B(G2 g)
		{
			return g == G2.South || g == G2.North;
		}
		public static bool b(G2 g)
		{
			return g == G2.East || g == G2.South;
		}
		public static bool C(G2 g)
		{
			return g == G2.West || g == G2.North;
		}
		public static bool A(G2 g, G2 g2)
		{
			return g2.B(g) == g2.a(g2);
		}
		public static G2 A(G2 g)
		{
			if (!g2.A(g))
			{
				return G2.None;
			}
			return g;
		}
		public static G2 a(G2 g)
		{
			return g2.A(g ^ G2.West);
		}
		public static Rectangle A(Point location, G2 g, int num)
		{
			switch (g)
			{
			case G2.East:
				return new Rectangle(location, new Size(num, 1));
			case G2.South:
				return new Rectangle(location, new Size(1, num));
			case G2.West:
				return new Rectangle(new Point(location.X - (num - 1), location.Y), new Size(num, 1));
			case G2.North:
				return new Rectangle(new Point(location.X, location.Y - (num - 1)), new Size(1, num));
			default:
				throw new l1();
			}
		}
		public static G2 A(Point point, Point point2, out int ptr)
		{
			int num = point2.X - point.X;
			int num2 = point2.Y - point.Y;
			if (num2 == 0)
			{
				ptr = ((num > 0) ? num : (-num));
				if (num > 0)
				{
					return G2.East;
				}
				if (num < 0)
				{
					return G2.West;
				}
				return G2.None;
			}
			else
			{
				if (num != 0)
				{
					ptr = 0;
					return G2.None;
				}
				ptr = ((num2 > 0) ? num2 : (-num2));
				if (num2 > 0)
				{
					return G2.South;
				}
				if (num2 < 0)
				{
					return G2.North;
				}
				return G2.None;
			}
		}
		public static Point A(Point point, G2 g)
		{
			Point result = point;
			switch (g)
			{
			case G2.East:
				result.X++;
				break;
			case G2.South:
				result.Y++;
				break;
			case G2.West:
				result.X--;
				break;
			case G2.North:
				result.Y--;
				break;
			}
			return result;
		}
	}
}
