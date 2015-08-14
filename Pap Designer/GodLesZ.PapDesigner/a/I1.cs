using c;
using System;
using System.Collections.Generic;
namespace a
{
	public class I1 : F1
	{
		private new int A = -1;
		private new string A;
		private new string a;
		public I1(h2 h, s1 s, p1 p, global::c.a a, string text) : base(h, p, text)
		{
			if (s != null && s.A() != p)
			{
				throw new l1();
			}
			this.A = a.A();
			this.A = a.c();
		}
		protected new global::c.a A()
		{
			return (global::c.a)base.A().J().B(this.A);
		}
		protected override bool D()
		{
			global::c.a a = this.A();
			this.a = a.c();
			return this.a != this.A;
		}
		protected override void C()
		{
			global::c.a a = this.A();
			if (a.c() != this.A)
			{
				a.D(this.A);
				base.A().H();
			}
		}
		protected override void c()
		{
			global::c.a a = this.A();
			if (a.c() != this.a)
			{
				a.D(this.a);
				base.A().H();
			}
		}
	}
	public class i1
	{
		private f<d1> A = new f<d1>(30);
		private Stack<d1> A = new Stack<d1>();
		public i1()
		{
			this.A();
			f<d1> expr_2A = this.A;
			expr_2A.A = (f<d1>.A)Delegate.Combine(expr_2A.A, new f<d1>.A(this.A));
		}
		public int A()
		{
			return this.A.A();
		}
		public bool A()
		{
			return this.A.A() > 0;
		}
		public bool a()
		{
			return this.A.Count > 0;
		}
		public d1 A()
		{
			return this.A.A();
		}
		public d1 a()
		{
			return this.A.Peek();
		}
		public string A()
		{
			return this.A().d();
		}
		public string a()
		{
			return this.a().d();
		}
		public d1 B()
		{
			if (!this.A())
			{
				return null;
			}
			return this.A.A();
		}
		public E1 A(h2 h, string text)
		{
			E1 e = new E1(this, h, text);
			this.A(e);
			return new E1(e);
		}
		public void A(E1 e)
		{
			this.A(e);
		}
		public void a(E1 e)
		{
			e.a();
		}
		public void A(f<d1> f, d1 d)
		{
			if (d is E1)
			{
				E1 e = (E1)d;
				if (e.A())
				{
					bool flag;
					do
					{
						flag = (f.B() == e.A());
						f.a();
					}
					while (!flag);
				}
			}
		}
		public void A()
		{
			this.A.A();
			this.A.Clear();
		}
		public bool A(d1 d)
		{
			bool flag = d.A();
			if (flag)
			{
				this.A(d);
			}
			return flag;
		}
		private void A(d1 d)
		{
			this.A.A(d);
			this.A.Clear();
		}
		public void a()
		{
			if (this.A())
			{
				d1 d = this.A.a();
				this.A.Push(d);
				d.B();
			}
		}
		public void B()
		{
			if (this.a())
			{
				d1 d = this.A.Pop();
				this.A.A(d);
				d.b();
			}
		}
	}
}
