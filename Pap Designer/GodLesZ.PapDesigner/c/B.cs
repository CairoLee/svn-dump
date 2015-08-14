using a;
using c;
using d;
using D;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
namespace C
{
	public abstract class B : global::c.C, global::c.a, L, l
	{
		private new int A = -1;
		private new Pen A;
		private new Brush A;
		public new abstract int A();
		public new abstract void a(int);
		public new abstract string c();
		public new abstract void D(string);
		public new virtual bool d()
		{
			return true;
		}
		public abstract Rectangle E();
		public abstract bool e(Point);
		public abstract Pen F();
		public abstract Brush f();
		public virtual Pen G(B1 b)
		{
			if (this.A != b.a())
			{
				this.A = b.a();
				if (!b.b() && b.e(this) > 0)
				{
					this.A = global::c.C.b;
					this.A = global::c.C.A;
				}
				else
				{
					this.A = this.f();
					this.A = this.F();
				}
			}
			return this.A;
		}
		public virtual Brush g(B1 b)
		{
			this.G(b);
			return this.A;
		}
		public new abstract void B(XmlWriter, X1);
		public new abstract void b(XmlReader, w1);
		public new abstract void C(w1);
	}
	public class b : C
	{
		public b(Point point, string text) : base(point, text)
		{
		}
		public b(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override void P(GraphicsPath graphicsPath)
		{
			Rectangle rectangle = this.L();
			Rectangle rectangle2 = this.o();
			Point[] points = new Point[]
			{
				new Point(rectangle2.X, rectangle.Y),
				new Point(rectangle2.Right, rectangle.Y),
				new Point(rectangle.Right, rectangle.Y + this.L().Height / 4),
				new Point(rectangle.Right, rectangle.Bottom),
				new Point(rectangle.X, rectangle.Bottom),
				new Point(rectangle.X, rectangle.Y + this.L().Height / 4)
			};
			graphicsPath.AddPolygon(points);
		}
	}
}
namespace c
{
	public class b : d.a
	{
		public new const int A = 9;
		private new readonly Size A = new Size(18, 18);
		private new d.a A;
		private new G2 A = G2.None;
		public new bool A;
		public b(Point point, d.a a, G2 a2) : base(point, "")
		{
			this.A = a;
			this.A = a2;
		}
		public new d.a A()
		{
			return this.A;
		}
		public new G2 A()
		{
			return this.A;
		}
		public new static Rectangle A(Point point)
		{
			Rectangle result = new Rectangle(point.X, point.Y, 0, 0);
			result.Inflate(9, 9);
			return result;
		}
		public override Size h()
		{
			return this.A;
		}
		public override Color J()
		{
			return SystemColors.ControlLightLight;
		}
		public override int r()
		{
			return 0;
		}
		public override int S()
		{
			return 0;
		}
		public override int s()
		{
			return 0;
		}
		public override int T()
		{
			return 0;
		}
		public override void y(B1 b)
		{
			if (this.A)
			{
				return;
			}
			base.y(b);
		}
		public override void z(B1 b)
		{
			Graphics graphics = b.A();
			if (this.A)
			{
				return;
			}
			graphics.FillPath(this.j(), this.m());
			graphics.DrawPath(global::c.C.d, this.m());
			int num = this.h().Width / 4;
			int num2 = this.h().Height / 4;
			switch (this.A)
			{
			case G2.East:
				num = -num;
				break;
			case G2.South:
				num2 = -num2;
				goto IL_FA;
			case G2.West:
				break;
			case G2.North:
				goto IL_FA;
			default:
				return;
			}
			graphics.FillPolygon(global::c.C.a, new Point[]
			{
				new Point(base.d() - num, base.G()),
				new Point(base.d() + num, base.G() - num2),
				new Point(base.d() + num, base.G() + num2)
			});
			return;
			IL_FA:
			graphics.FillPolygon(global::c.C.a, new Point[]
			{
				new Point(base.d(), base.G() - num2),
				new Point(base.d() - num, base.G() + num2),
				new Point(base.d() + num, base.G() + num2)
			});
		}
		public override void A1(B1 b)
		{
		}
	}
	public class B : d.a
	{
		public B(Point point) : base(point, null)
		{
		}
		public B(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override Size h()
		{
			return global::c.C.C;
		}
		public override Size I()
		{
			return new Size(6, 6);
		}
		public override Color J()
		{
			return Color.Gray;
		}
		public override void P(GraphicsPath graphicsPath)
		{
			Rectangle rect = this.L();
			int height = rect.Height;
			int arg_12_0 = height / 2;
			graphicsPath.AddEllipse(rect);
		}
		public override void R(Graphics graphics)
		{
		}
		public override int w()
		{
			return 9;
		}
		public override bool d()
		{
			return false;
		}
		public override int T()
		{
			return 3;
		}
		public override int t()
		{
			if (Q1.a(this, true))
			{
				return 1;
			}
			return this.S();
		}
		public override int U()
		{
			if (Q1.a(this, false))
			{
				return this.T();
			}
			return 1;
		}
		public virtual bool c1(B1 b)
		{
			if (b.e(this) > 0)
			{
				return true;
			}
			if (b.b())
			{
				return false;
			}
			if (base.d())
			{
				D.A a = base.G().A();
				D.A a2 = base.g().A();
				if (a.d() == a2.d())
				{
					return (this != a.d() || string.IsNullOrEmpty(a.c())) && (this != a2.d() || string.IsNullOrEmpty(a2.c()));
				}
				if (a.d() != this && a2.d() != this)
				{
					return true;
				}
				if (a.G() != this && a2.G() != this)
				{
					return true;
				}
			}
			return base.D1() < 2;
		}
		public override void z(B1 b)
		{
			if (b.e(this) > 0 || this.c1(b))
			{
				base.z(b);
			}
		}
		public override void y(B1 b)
		{
			if (b.e(this) > 0 || this.c1(b))
			{
				base.y(b);
			}
		}
		public override void A1(B1 b)
		{
		}
	}
}
