using a;
using b;
using c;
using D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Xml;
namespace d
{
	public class C : D.a
	{
		public new const float A = 2.4f;
		public new const int A = 4;
		public new const float a = 0f;
		protected override Size b(D.a.a a, IList<D.a.A> list, float num, out string ptr)
		{
			float num2 = 1f + (float)Math.Sqrt((double)(1f + 2f * num / 2.4f / a.A.Height));
			int num3 = (int)Math.Round((double)num2);
			ptr = null;
			int num4;
			while (true)
			{
				num4 = 0;
				ptr = this.A(a, list, num3, false, out num4);
				if (ptr != null)
				{
					break;
				}
				num3++;
			}
			if (num4 > 1)
			{
				string text = this.A(a, list, num3, true, out num4);
				if (text != null)
				{
					ptr = text;
				}
			}
			num3 = Math.Max(4, num3);
			float num5 = a.A.Height * (float)num3;
			float num6 = num5 * 2.4f;
			float num7 = 0f * a.A.Height / 14f;
			float num8 = (float)Math.Sqrt(2.4);
			num6 += num7 * num8;
			num5 += 0f / num8;
			return new Size((int)num6, (int)num5);
		}
		private new string A(D.a.a a, IList<D.a.A> list, int num, bool flag, out int ptr)
		{
			int num2 = 0;
			ptr = 0;
			StringBuilder stringBuilder = new StringBuilder();
			float num3 = 2f * a.A.Height * 2.4f;
			int num4 = 0;
			int i = 0;
			while (i < list.Count)
			{
				num2++;
				int num5 = 2 * num2;
				int num6 = (num5 < num) ? 1 : ((num5 > num) ? -1 : 0);
				num4 += num6;
				if (num4 <= 0)
				{
					return null;
				}
				float num7 = (float)num4 * num3;
				D.a.A a2 = null;
				float num8 = 0f;
				while (i < list.Count)
				{
					D.a.A a3 = list[i];
					float num9 = num8 + a3.A;
					if (a2 != null && a2.A)
					{
						num9 += a.A.Width;
					}
					if (num9 > num7 || (flag && num2 <= 1) || (a2 != null && a2.a))
					{
						if (a2 != null && !a2.A && !a2.a && !a2.A.EndsWith("" + '-'))
						{
							stringBuilder.Append('-');
						}
						stringBuilder.Append("\n");
						break;
					}
					if (a2 != null && a2.A)
					{
						stringBuilder.Append(' ');
					}
					stringBuilder.Append(a3.A);
					num8 = num9;
					a2 = a3;
					i++;
				}
			}
			ptr = num4 - 1;
			num2 += ptr;
			for (int j = 0; j < num4; j++)
			{
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}
	}
	public abstract class c : d.a
	{
		private new static StringFormat A = null;
		public new static SolidBrush A = new SolidBrush(Color.LightCoral);
		public c(Point point, string text) : base(point, text)
		{
		}
		public c(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override Size h()
		{
			return global::c.C.a;
		}
		public override Color J()
		{
			return Color.LightCoral;
		}
		public override Size O()
		{
			return new Size(this.L().Height / 4, 0);
		}
		public override void P(GraphicsPath graphicsPath)
		{
			Rectangle rectangle = this.L();
			Rectangle rectangle2 = this.o();
			Point[] points = new Point[]
			{
				new Point(rectangle2.X, rectangle.Y),
				new Point(rectangle.X + rectangle.Width, rectangle.Y),
				new Point(rectangle2.X + rectangle2.Width, rectangle.Y + rectangle.Height),
				new Point(rectangle.X, rectangle.Y + rectangle.Height)
			};
			graphicsPath.AddPolygon(points);
		}
		public override Rectangle M()
		{
			Rectangle result = this.L();
			Size size = this.O();
			result.Inflate(-size.Width / 2, -size.Height / 2);
			return result;
		}
		public abstract string c1(B1);
		public override void z(B1 b)
		{
			base.z(b);
			Rectangle r = this.L();
			r.X += global::c.C.A.Width / 50;
			b.A().DrawString(this.c1(b), global::c.C.c(), global::d.c.A, r, this.D1());
		}
		public new virtual StringFormat D1()
		{
			if (global::d.c.A == null)
			{
				global::d.c.A = new StringFormat();
				global::d.c.A.Alignment = StringAlignment.Near;
				global::d.c.A.LineAlignment = StringAlignment.Far;
				global::d.c.A.FormatFlags = StringFormatFlags.NoClip;
			}
			return global::d.c.A;
		}
	}
}
namespace D
{
	public class C : e<C>
	{
		private global::b.B A;
		private global::b.B a;
		public C(global::b.B b, global::b.B b2)
		{
			if (global::b.B.a(b, null) || global::b.B.a(b2, null))
			{
				throw new ArgumentException();
			}
			this.A = b;
			this.a = b2;
		}
		public C(C c) : this(c.A, c.a)
		{
		}
		public bool a()
		{
			return this.A.a() && this.a.a();
		}
		public int a()
		{
			return this.A.a();
		}
		public int B()
		{
			return this.a.a();
		}
		public global::b.B a()
		{
			return this.A;
		}
		public global::b.B B()
		{
			return this.a;
		}
		public bool A(C c)
		{
			return c != null && this.a() == c.a() && this.B() == c.B();
		}
		public override bool Equals(object obj)
		{
			return obj is C && C.a(this, (C)obj);
		}
		public static bool a(C c, C c2)
		{
			if (c != null)
			{
				return c.A(c2);
			}
			return c2 == null || c2.A(c);
		}
		public static bool B(C c, C c2)
		{
			return !C.a(c, c2);
		}
		public override int GetHashCode()
		{
			throw new NotSupportedException("CellPointer.GetHashCode() is not supported");
		}
	}
	public class c : global::c.A<global::c.a>
	{
		public c()
		{
		}
		public c(global::c.a a) : base(a)
		{
		}
		public c(IEnumerable enumerable) : base(enumerable)
		{
		}
	}
}
