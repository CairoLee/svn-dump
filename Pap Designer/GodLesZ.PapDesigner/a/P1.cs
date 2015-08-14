using c;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
namespace a
{
	public abstract class P1<T_ITEM> : o1 where T_ITEM : P1<T_ITEM>
	{
		public new delegate bool A(T_ITEM, string);
		public new delegate void a(T_ITEM, string);
		private new P1<T_ITEM>.A A;
		private new P1<T_ITEM>.a A;
		protected P1()
		{
		}
		protected P1(string text) : base(text)
		{
		}
		public override bool A(string text)
		{
			if (!base.A(text))
			{
				return false;
			}
			if (this.A != null)
			{
				Delegate[] invocationList = this.A.GetInvocationList();
				Delegate[] array = invocationList;
				for (int i = 0; i < array.Length; i++)
				{
					P1<T_ITEM>.A a = (P1<T_ITEM>.A)array[i];
					if (!a((T_ITEM)((object)this), text))
					{
						return false;
					}
				}
			}
			return true;
		}
		public override bool a(string text)
		{
			string text2 = base.b();
			bool flag = base.b() != text;
			if (!base.a(text))
			{
				return false;
			}
			if (flag && this.A != null)
			{
				this.A((T_ITEM)((object)this), text2);
			}
			return true;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void B(P1<T_ITEM>.A b)
		{
			this.A = (P1<T_ITEM>.A)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void b(P1<T_ITEM>.A value)
		{
			this.A = (P1<T_ITEM>.A)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void B(P1<T_ITEM>.a b)
		{
			this.A = (P1<T_ITEM>.a)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void b(P1<T_ITEM>.a value)
		{
			this.A = (P1<T_ITEM>.a)Delegate.Remove(this.A, value);
		}
	}
	public abstract class p1 : P1<p1>, L, l, N
	{
		private new int A = -1;
		protected new DateTime A;
		protected new DateTime a;
		private new bool A;
		protected new D1<global::c.a> A = new D1<global::c.a>();
		public p1()
		{
			this.J();
		}
		public p1(string text) : base(text)
		{
			this.J();
		}
		private void J()
		{
			DateTime now = DateTime.Now;
			this.A = now;
			this.a = now;
		}
		public new int A()
		{
			return this.A;
		}
		public new void a(int num)
		{
			this.A = num;
		}
		public bool J()
		{
			return this.A;
		}
		public DateTime J()
		{
			return this.A;
		}
		public DateTime j()
		{
			return this.a;
		}
		public abstract bool E();
		public abstract void e(bool);
		public c1<global::c.a> J()
		{
			return this.A;
		}
		protected abstract C2 F();
		public abstract s1 f();
		public abstract B1 G(s1, Graphics, a1, bool);
		public abstract bool g(Control, v1, string);
		public abstract void H();
		public virtual void h(bool flag)
		{
			this.A = flag;
		}
		public virtual void I(byte[] array)
		{
			byte[] array2 = j2.A(this);
			if (!this.J(array2, array))
			{
				s1[] array3 = this.F().A(this);
				this.i(array);
				this.F().A(array3, this);
			}
		}
		private bool J(byte[] array, byte[] array2)
		{
			if (object.ReferenceEquals(array, array2))
			{
				return true;
			}
			if (array.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != array2[i])
				{
					return false;
				}
			}
			return true;
		}
		public abstract void c();
		public abstract bool D();
		public abstract void d(DateTime);
		public abstract void B(XmlWriter, X1);
		public abstract void b(XmlReader, w1);
		public virtual void C(w1 w)
		{
			w.A = this.J();
			foreach (global::c.a current in this.A.C())
			{
				current.C(w);
			}
		}
		public abstract void i(byte[]);
	}
}
