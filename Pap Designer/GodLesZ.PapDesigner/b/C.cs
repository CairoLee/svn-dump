using a;
using C;
using D;
using E;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Xml;
namespace b
{
	public class C<T_VALUE, T_LANEPTR> where T_LANEPTR : global::b.B
	{
		public delegate global::b.B A(E.a, bool);
		public delegate void a(D.C, T_VALUE, T_VALUE);
		public delegate void B(T_LANEPTR, int);
		public const int A = 2147483647;
		private List<E.a> A = new List<E.a>();
		private List<E.a> a = new List<E.a>();
		private List<List<T_VALUE>> A = new List<List<T_VALUE>>();
		private C<T_VALUE, T_LANEPTR>.A A;
		private C<T_VALUE, T_LANEPTR>.a A;
		private C<T_VALUE, T_LANEPTR>.B A;
		private C<T_VALUE, T_LANEPTR>.B a;
		private C<T_VALUE, T_LANEPTR>.B B;
		private C<T_VALUE, T_LANEPTR>.B b;
		public int h()
		{
			return this.A.Count;
		}
		public void h(int i)
		{
			if (i < 0)
			{
				throw new ArgumentException();
			}
			while (i > this.A.Count)
			{
				this.e(this.A.Count);
			}
			while (i < this.A.Count)
			{
				this.G(this.A.Count - 1);
			}
		}
		public int I()
		{
			return this.a.Count;
		}
		public void I(int i)
		{
			if (i < 0)
			{
				throw new ArgumentException();
			}
			while (i > this.a.Count)
			{
				this.F(this.a.Count);
			}
			while (i < this.a.Count)
			{
				this.G(this.a.Count - 1);
			}
		}
		public static T_VALUE h()
		{
			return default(T_VALUE);
		}
		public void h(C<T_VALUE, T_LANEPTR>.A a)
		{
			this.A = a;
		}
		public global::C.a<T_VALUE, T_LANEPTR> h()
		{
			return new global::C.a<T_VALUE, T_LANEPTR>(this);
		}
		public D.B<T_VALUE, T_LANEPTR> h()
		{
			return new D.B<T_VALUE, T_LANEPTR>(this);
		}
		public static bool h(T_VALUE t_VALUE, T_VALUE t_VALUE2)
		{
			if (t_VALUE != null)
			{
				return t_VALUE.Equals(t_VALUE2);
			}
			return t_VALUE2 == null || t_VALUE2.Equals(t_VALUE);
		}
		public virtual void A()
		{
			while (this.h() > 0)
			{
				this.f(this.h() - 1);
			}
			while (this.I() > 0)
			{
				this.G(this.I() - 1);
			}
		}
		public virtual T_VALUE a(int index, int index2)
		{
			List<T_VALUE> list = this.A[index];
			return list[index2];
		}
		public virtual T_VALUE B(D.C c)
		{
			this.h(c);
			return this.a(c.a(), c.B());
		}
		public virtual D.C b(int num, int num2)
		{
			return this.c(num, num2, global::b.C<T_VALUE, T_LANEPTR>.h());
		}
		public virtual void C(D.C c)
		{
			this.D(c, global::b.C<T_VALUE, T_LANEPTR>.h());
		}
		public virtual D.C c(int num, int num2, T_VALUE t_VALUE)
		{
			D.C c = this.E(num, num2);
			this.D(c, t_VALUE);
			return c;
		}
		public virtual void D(D.C c, T_VALUE t_VALUE)
		{
			this.h(c);
			int index = c.a();
			int index2 = c.B();
			List<T_VALUE> list = this.A[index];
			T_VALUE t_VALUE2 = list[index2];
			if (object.Equals(t_VALUE, null))
			{
				t_VALUE = global::b.C<T_VALUE, T_LANEPTR>.h();
			}
			if (!global::b.C<T_VALUE, T_LANEPTR>.h(t_VALUE, t_VALUE2))
			{
				list[index2] = t_VALUE;
				if (this.A != null)
				{
					this.A(c, t_VALUE2, t_VALUE);
				}
			}
		}
		public virtual D.C d(int i, int j, T_VALUE t_VALUE)
		{
			while (i >= this.A.Count)
			{
				this.e(this.A.Count);
			}
			while (j >= this.a.Count)
			{
				this.F(this.a.Count);
			}
			return this.c(i, j, t_VALUE);
		}
		public virtual D.C E(int num, int num2)
		{
			T_LANEPTR t_LANEPTR = this.h(num);
			T_LANEPTR t_LANEPTR2 = this.I(num2);
			return this.H(t_LANEPTR, t_LANEPTR2);
		}
		public T_LANEPTR h(int index)
		{
			return (T_LANEPTR)((object)this.A[index].A);
		}
		public T_LANEPTR I(int index)
		{
			return (T_LANEPTR)((object)this.a[index].A);
		}
		public virtual E.a e(int num)
		{
			E.a a = this.h(num, true);
			List<T_VALUE> list = new List<T_VALUE>();
			if (list.Capacity < this.a.Count)
			{
				list.Capacity = this.a.Count;
			}
			for (int i = 0; i < this.a.Count; i++)
			{
				list.Add(global::b.C<T_VALUE, T_LANEPTR>.h());
			}
			this.A.Insert(num, a);
			this.A.Insert(num, list);
			for (int j = num + 1; j < this.A.Count; j++)
			{
				this.A[j].A = j;
			}
			if (this.A != null)
			{
				this.A((T_LANEPTR)((object)a.A), num);
			}
			return a;
		}
		public virtual E.a F(int num)
		{
			E.a a = this.h(num, false);
			for (int i = 0; i < this.A.Count; i++)
			{
				List<T_VALUE> list = this.A[i];
				list.Insert(num, global::b.C<T_VALUE, T_LANEPTR>.h());
			}
			this.a.Insert(num, a);
			for (int j = num + 1; j < this.a.Count; j++)
			{
				this.a[j].A = j;
			}
			if (this.B != null)
			{
				this.B((T_LANEPTR)((object)a.A), num);
			}
			return a;
		}
		public virtual void f(int num)
		{
			for (int i = 0; i <= this.I() - 1; i++)
			{
				this.b(num, i);
			}
			E.a a = this.A[num];
			this.A.RemoveAt(num);
			T_LANEPTR t_LANEPTR = (T_LANEPTR)((object)a.A);
			a.A = null;
			a.A = 2147483647;
			this.A[num].Clear();
			this.A.RemoveAt(num);
			for (int j = num; j < this.A.Count; j++)
			{
				this.A[j].A = j;
			}
			if (this.a != null)
			{
				this.a(t_LANEPTR, num);
			}
		}
		public virtual void G(int num)
		{
			for (int i = 0; i <= this.h() - 1; i++)
			{
				this.b(i, num);
			}
			E.a a = this.a[num];
			this.a.RemoveAt(num);
			T_LANEPTR t_LANEPTR = (T_LANEPTR)((object)a.A);
			a.A = null;
			a.A = 2147483647;
			int count = this.A.Count;
			for (int j = 0; j < count; j++)
			{
				List<T_VALUE> list = this.A[j];
				list.RemoveAt(num);
			}
			for (int k = num; k < this.a.Count; k++)
			{
				this.a[k].A = k;
			}
			if (this.b != null)
			{
				this.b(t_LANEPTR, num);
			}
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void h(C<T_VALUE, T_LANEPTR>.a a)
		{
			this.A = (C<T_VALUE, T_LANEPTR>.a)Delegate.Combine(this.A, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void I(C<T_VALUE, T_LANEPTR>.a value)
		{
			this.A = (C<T_VALUE, T_LANEPTR>.a)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void h(C<T_VALUE, T_LANEPTR>.B b)
		{
			this.A = (C<T_VALUE, T_LANEPTR>.B)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void I(C<T_VALUE, T_LANEPTR>.B value)
		{
			this.A = (C<T_VALUE, T_LANEPTR>.B)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void i(C<T_VALUE, T_LANEPTR>.B b)
		{
			this.a = (C<T_VALUE, T_LANEPTR>.B)Delegate.Combine(this.a, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void J(C<T_VALUE, T_LANEPTR>.B value)
		{
			this.a = (C<T_VALUE, T_LANEPTR>.B)Delegate.Remove(this.a, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void j(C<T_VALUE, T_LANEPTR>.B b)
		{
			this.B = (C<T_VALUE, T_LANEPTR>.B)Delegate.Combine(this.B, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void K(C<T_VALUE, T_LANEPTR>.B value)
		{
			this.B = (C<T_VALUE, T_LANEPTR>.B)Delegate.Remove(this.B, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void k(C<T_VALUE, T_LANEPTR>.B b)
		{
			this.b = (C<T_VALUE, T_LANEPTR>.B)Delegate.Combine(this.b, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void L(C<T_VALUE, T_LANEPTR>.B value)
		{
			this.b = (C<T_VALUE, T_LANEPTR>.B)Delegate.Remove(this.b, value);
		}
		protected virtual T_LANEPTR g(E.a a, bool flag)
		{
			if (this.A != null)
			{
				return (T_LANEPTR)((object)this.A(a, flag));
			}
			return (T_LANEPTR)((object)new global::b.B(a));
		}
		protected virtual D.C H(T_LANEPTR t_LANEPTR, T_LANEPTR t_LANEPTR2)
		{
			return new D.C(t_LANEPTR, t_LANEPTR2);
		}
		private void h(D.C c)
		{
			if (!c.a())
			{
				throw new ArgumentException();
			}
			if (global::b.B.B(this.h(c.a()), c.a()))
			{
				throw new ArgumentException();
			}
			if (global::b.B.B(this.I(c.B()), c.B()))
			{
				throw new ArgumentException();
			}
		}
		private E.a h(int num, bool flag)
		{
			E.a a = new E.a();
			a.A = num;
			a.A = this.g(a, flag);
			return a;
		}
	}
	public class c : global::C.C
	{
		public c(Point point, string text) : base(point, text)
		{
		}
		public c(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override void P(GraphicsPath graphicsPath)
		{
			Rectangle rectangle = this.L();
			Rectangle rectangle2 = this.o();
			Point[] points = new Point[]
			{
				new Point(rectangle.X, rectangle.Y),
				new Point(rectangle.Right, rectangle.Y),
				new Point(rectangle.Right, rectangle.Bottom - this.L().Height / 4),
				new Point(rectangle2.Right, rectangle.Bottom),
				new Point(rectangle2.X, rectangle.Bottom),
				new Point(rectangle.X, rectangle.Bottom - this.L().Height / 4)
			};
			graphicsPath.AddPolygon(points);
		}
	}
}
