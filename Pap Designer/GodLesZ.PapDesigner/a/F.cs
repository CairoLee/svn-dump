using c;
using d;
using D;
using System;
using System.Collections.Generic;
using System.Drawing;
namespace a
{
	public class F : e<F>
	{
		private F2 A;
		private D.C A;
		private G2 A = G2.None;
		private G2 a = G2.None;
		private f2 A;
		public bool A;
		public F(F2 f, D.C c) : this(f, c, G2.None, G2.None)
		{
		}
		public F(F2 f, D.C c, G2 g) : this(f, c, g2.a(g) ? g : G2.None, g2.B(g) ? g : G2.None)
		{
		}
		public F(F2 f, D.C c, G2 g, G2 g2)
		{
			if (g2.B(g))
			{
				throw new l1();
			}
			if (g2.a(g2))
			{
				throw new l1();
			}
			this.A = f;
			this.A = c;
			this.A = g;
			this.a = g2;
			this.A = f.B(c);
		}
		public D.C a()
		{
			return this.A;
		}
		public Point a()
		{
			return new Point(this.a().a(), this.a().B());
		}
		public G2 a()
		{
			return this.A;
		}
		public G2 B()
		{
			return this.a;
		}
		public bool a()
		{
			return this.A == G2.None && this.a == G2.None;
		}
		public f2 a()
		{
			return this.A;
		}
		public d.a a()
		{
			if (this.A == null || !this.a())
			{
				return null;
			}
			return this.A.A;
		}
		public Rectangle a(out Point ptr)
		{
			D.C c = this.a();
			Y1 y = this.A.h(c.a());
			Y1 y2 = this.A.I(c.B());
			Point point = new Point(y.B(), y2.B());
			switch (this.a())
			{
			case G2.East:
				point.X = y.a();
				break;
			case G2.West:
				point.X = y.A();
				break;
			}
			switch (this.B())
			{
			case G2.South:
				point.Y = y2.a();
				break;
			case G2.North:
				point.Y = y2.A();
				break;
			}
			Rectangle result = new Rectangle(point.X, point.Y, 0, 0);
			int num = 6;
			int num2 = 7;
			result.Inflate(global::c.C.C.Width * num / num2, global::c.C.C.Height * num / num2);
			ptr = point;
			return result;
		}
		public bool A(F f)
		{
			return f != null && (this.A == f.A && this.a == f.a && this.A == f.A) && D.C.a(this.A, f.A);
		}
		public override bool Equals(object obj)
		{
			return obj is F && F.a(this, (F)obj);
		}
		public static bool a(F f, F f2)
		{
			if (f != null)
			{
				return f.A(f2);
			}
			return f2 == null || f2.A(f);
		}
		public static bool B(F f, F f2)
		{
			return !F.a(f, f2);
		}
		public override int GetHashCode()
		{
			throw new NotSupportedException("InsertionSpot.GetHashCode() is not supported");
		}
	}
	public class f<T>
	{
		public delegate void A(f<T>, T);
		private LinkedList<T> A = new LinkedList<T>();
		private int A;
		public f<T>.A A;
		public f(int a)
		{
			this.A = a;
		}
		public int A()
		{
			return this.A.Count;
		}
		public void A()
		{
			this.A.Clear();
		}
		public void A(T value)
		{
			this.A.AddLast(value);
			while (this.A.Count > this.A)
			{
				T t = this.B();
				this.a();
				if (this.A != null)
				{
					this.A(this, t);
				}
			}
		}
		public T A()
		{
			return this.A.Last.Value;
		}
		public T a()
		{
			T result = this.A();
			this.A.RemoveLast();
			return result;
		}
		public T B()
		{
			return this.A.First.Value;
		}
		public void a()
		{
			this.A.RemoveFirst();
		}
	}
}
