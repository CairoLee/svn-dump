using a;
using c;
using d;
using E;
using System;
using System.Drawing;
using System.Xml;
namespace b
{
	public class B : e<B>
	{
		public const int A = 2147483647;
		private E.a A;
		public B(E.a a)
		{
			if (a == null)
			{
				throw new ArgumentException();
			}
			this.A = a;
		}
		public bool a()
		{
			return this.a() != 2147483647;
		}
		public int a()
		{
			return this.A.A;
		}
		public bool A(B b)
		{
			return b != null && object.ReferenceEquals(this, b);
		}
		public override bool Equals(object obj)
		{
			return obj is B && global::b.B.a(this, (B)obj);
		}
		public static bool a(B b, B b2)
		{
			if (b != null)
			{
				return b.A(b2);
			}
			return b2 == null || b2.A(b);
		}
		public static bool B(B b, B b2)
		{
			return !global::b.B.a(b, b2);
		}
		public override int GetHashCode()
		{
			throw new NotSupportedException("LanePointer.GetHashCode() is not supported");
		}
	}
	public class b : d.a
	{
		public b(Point point, string text) : base(point, text)
		{
		}
		public b(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override Size h()
		{
			return new Size(100, 30);
		}
		public override Size I()
		{
			return new Size(0, 0);
		}
		public override int i()
		{
			return 0;
		}
		public override Font K()
		{
			return global::c.C.C();
		}
		public override Size n()
		{
			Size result = this.N();
			result.Width *= 8;
			return result;
		}
		public override void R(Graphics graphics)
		{
			base.R(graphics);
			base.g(base.g() + 10);
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
		}
		public override void z(B1 b)
		{
		}
	}
}
