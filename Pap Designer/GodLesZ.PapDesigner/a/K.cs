using b;
using c;
using C;
using d;
using D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
namespace a
{
	public class K
	{
		private WeakReference A;
		private int A = -1;
		private Rectangle A = Rectangle.Empty;
		private float A = 1f;
		private Point A = new Point(0, 0);
		public K(T1 t)
		{
			this.A = new WeakReference(t);
			this.A = t.A().A();
			this.A = t.h();
			this.A = t.J();
			this.A = t.I();
		}
		public T1 A()
		{
			T1 t = this.A.Target as T1;
			if (t == null)
			{
				return null;
			}
			if (t.h() != this.A)
			{
				return null;
			}
			if (t.A().A() != this.A)
			{
				return null;
			}
			return t;
		}
		public bool A()
		{
			T1 t = this.A();
			if (t == null)
			{
				return false;
			}
			t.j(this.A);
			t.i(this.A);
			return true;
		}
	}
	public class k
	{
		private e2 A;
		private ICollection A;
		private D.A A;
		private bool A;
		private bool a;
		private bool B;
		private bool b;
		private bool C;
		private bool c;
		public k(e2 e)
		{
			this.A = e;
		}
		public H2 A()
		{
			return this.A as H2;
		}
		public bool A()
		{
			return this.A == null || this.A.Count == 0;
		}
		public bool a()
		{
			return this.A != null && this.A.Count == 1;
		}
		public bool B()
		{
			return this.A() != null && this.A.Count > 1;
		}
		public bool b()
		{
			return this.A == null && this.a();
		}
		public bool C()
		{
			return this.A != null && this.a();
		}
		public global::c.a A()
		{
			if (this.A() == null)
			{
				return this.A;
			}
			return this.A().A();
		}
		public d.a A()
		{
			if (this.A() == null)
			{
				return null;
			}
			return this.A().A();
		}
		public bool c()
		{
			return this.A;
		}
		public bool D()
		{
			return this.a;
		}
		public bool d()
		{
			return this.A || this.a;
		}
		public bool E()
		{
			return this.B;
		}
		public bool e()
		{
			return this.b;
		}
		public bool F()
		{
			return this.C;
		}
		public bool f()
		{
			return this.c;
		}
		public void A()
		{
			this.A(null);
		}
		public void A(global::c.a a)
		{
			if (a is d.a)
			{
				d.a a2 = (d.a)a;
				if (!this.A.L().A().A(a2))
				{
					throw new l1();
				}
				this.A(new H2(a2));
				return;
			}
			else
			{
				if (a is D.A)
				{
					this.A(null);
					this.A = new global::c.a[]
					{
						a
					};
					this.A = false;
					this.a = false;
					this.B = false;
					this.b = true;
					this.C = a.d();
					this.A = (D.A)a;
					this.A.d(a);
					return;
				}
				this.A();
				return;
			}
		}
		public void A(H2 h)
		{
			this.A = null;
			if (h != null)
			{
				if (h.a() == 0 && h.c() == 0)
				{
					throw new l1();
				}
				if (h.c())
				{
					throw new l1();
				}
			}
			if (this.A != h)
			{
				if (this.A != null)
				{
					this.A.C();
				}
				this.A = h;
				this.a();
				if (this.A != null)
				{
					this.A.C();
				}
			}
		}
		public bool A(global::c.a a)
		{
			if (this.A is H2)
			{
				return ((H2)this.A).A(a);
			}
			return this.A is ICollection<global::c.a> && ((ICollection<global::c.a>)this.A).Contains(a);
		}
		private void a()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			int num = 0;
			if (this.A != null)
			{
				foreach (global::c.a a in this.A)
				{
					if (!(a is D.A))
					{
						if (a.d())
						{
							flag5 = true;
						}
						if (a is global::b.b)
						{
							flag = true;
							flag2 = true;
							flag3 = true;
							flag4 = true;
						}
						else
						{
							if (a is global::b.a)
							{
								flag2 = true;
								flag3 = true;
								flag4 = true;
							}
							else
							{
								if (a is global::C.C)
								{
									global::C.C c = (global::C.C)a;
									global::C.C c2 = c.A();
									if (c2 != null && !this.A().A(c2))
									{
										Point point = this.A.L().A().A(c);
										Point point2 = this.A.L().A().A(c2);
										bool flag7 = point.X == point2.X;
										flag = flag7;
										flag3 = true;
										continue;
									}
								}
								if (!(a is global::c.B))
								{
									num++;
								}
								flag6 = true;
							}
						}
					}
				}
			}
			bool flag8 = !this.A();
			this.A = (flag8 && !flag);
			this.a = (flag8 && !flag2);
			this.B = (flag8 && !flag3);
			this.b = (flag8 && (flag6 || !flag4));
			this.C = (flag5 && this.b());
			this.c = (this.b && this.B && num >= 2);
		}
	}
}
