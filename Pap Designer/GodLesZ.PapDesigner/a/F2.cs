using b;
using c;
using C;
using d;
using D;
using E;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Xml;
namespace a
{
	public class F2 : global::b.C<f2, Y1>, IDisposable, l
	{
		public new class A
		{
			private H2 A;
			private F2 A;
			private F A;
			private int A;
			private int a;
			private Point A;
			private D.C A;
			private bool A;
			private bool a;
			private int B;
			private int b;
			private int C;
			private int c;
			public A(H2 h, F2 f, F f2)
			{
				this.A = h;
				this.A = f;
				this.A = f2;
			}
			public bool A()
			{
				if (!this.a())
				{
					return false;
				}
				this.A(0, 0);
				for (int i = -1; i >= -this.b; i--)
				{
					this.A(i, 0, false);
				}
				for (int j = 1; j <= this.B; j++)
				{
					this.A(j, 0, true);
				}
				for (int k = -1; k >= -this.c; k--)
				{
					this.A(k, false, false);
				}
				for (int l = 1; l <= this.C; l++)
				{
					this.A(l, true, false);
				}
				this.A.A();
				return true;
			}
			private bool a()
			{
				int num;
				int num2;
				if (this.A.A(this.A, out this.A, out this.a, out num, out num2))
				{
					this.A = this.A.A().A();
					this.B = this.A.A().Width - this.A.X - 1;
					this.b = this.A.X;
					this.C = this.A.A().Height - this.A.Y - 1;
					this.c = this.A.Y;
					this.A = this.A.E(this.A, this.a);
					if ((this.A.A() == null && this.A.A() == null) || !this.A.A(this.A.A()) || this.A.A(this.A.A()).Y == this.A.B())
					{
						this.A = true;
						int num3 = 0;
						for (int i = 0; i < this.A.A().Width; i++)
						{
							d.a a = this.A.A().A(i, num3);
							if (a != null && !(a is d.A) && !(a is global::b.A))
							{
								this.A = false;
								break;
							}
						}
						this.a = true;
						num3 = this.A.A().Height - 1;
						for (int j = 0; j < this.A.A().Width; j++)
						{
							d.a a2 = this.A.A().A(j, num3);
							if (a2 != null && !(a2 is d.A) && !(a2 is E.A))
							{
								this.a = false;
								break;
							}
						}
						Point point = new Point(this.A.a(), this.A.B());
						if (this.A(point.X) == G2.None && this.A(point.Y, this.A.Y) == G2.None && !this.A(point.X, point.Y))
						{
							if (this.A.A() != null)
							{
								for (int k = -1; k >= -this.c; k--)
								{
									if (!this.A(k, false, true))
									{
										return false;
									}
								}
							}
							if (this.A.A() != null)
							{
								for (int l = 1; l <= this.C; l++)
								{
									if (!this.A(l, false, true))
									{
										return false;
									}
								}
							}
							return true;
						}
					}
				}
				if (num >= 0)
				{
					this.A.f(num);
				}
				if (num2 >= 0)
				{
					this.A.G(num2);
				}
				return false;
			}
			private void A(int num, int num2, bool flag)
			{
				Point point = new Point(this.A.a() + num, this.A.B() + num2);
				if (this.A(point.X) != G2.None || this.A(point.X, point.Y))
				{
					this.A.e(point.X + (flag ? 0 : 1));
				}
				this.A(num, num2);
			}
			private bool A(int num, bool flag, bool flag2)
			{
				for (int i = -this.b; i <= this.B; i++)
				{
					Point point = new Point(this.A.a() + i, this.A.B() + num);
					if (!flag2 || (point.X >= 0 && point.X < this.A.h()))
					{
						G2 g = this.A(point.Y, this.A.Y + num);
						if (g != G2.None || this.A(point.X, point.Y))
						{
							if (flag2)
							{
								return false;
							}
							this.A.F(point.Y + (flag ? 0 : 1));
							break;
						}
					}
				}
				if (flag2)
				{
					return true;
				}
				for (int j = -this.b; j <= this.B; j++)
				{
					this.A(j, num);
				}
				return true;
			}
			private G2 A(int num)
			{
				if (num < 0)
				{
					return G2.West;
				}
				if (num > this.A.h() - 1)
				{
					return G2.East;
				}
				return G2.None;
			}
			private G2 A(int num, int num2)
			{
				int num3 = this.A.a.a() + 2;
				if (this.A && num2 == 0)
				{
					num3--;
				}
				if (num < num3)
				{
					return G2.North;
				}
				int num4 = this.A.I() - 2;
				if (this.a && num2 == this.A.A().Height - 1)
				{
					num4++;
				}
				if (num > num4)
				{
					return G2.South;
				}
				return G2.None;
			}
			private bool A(int num, int num2)
			{
				d.a a = this.A.A(num, num2);
				return a != null && !this.A.A(a);
			}
			private void A(int num, int num2)
			{
				d.a a = this.A.A().A(this.A.X + num, this.A.Y + num2);
				if (a == null)
				{
					return;
				}
				int num3 = this.A.a() + num;
				int num4 = this.A.B() + num2;
				d.a a2 = this.A.A(num3, num4);
				if (a2 != null)
				{
					if (!this.A.A(a2))
					{
						throw new l1();
					}
					this.A.A(this.A.a(a2), true, true);
				}
				if (this.A.A(a))
				{
					this.A.A(this.A.a(a), true, true);
				}
				this.A.A(a, num3, num4, true);
			}
		}
		public new const string A = "LAYOUT";
		public new const string a = "1.00";
		private new Dictionary<d.a, f2> A = new Dictionary<d.a, f2>();
		private new Y1 A;
		private new Y1 a;
		private new D.C A;
		private new D.C a;
		private new Point? A = null;
		public F2()
		{
			base.h(new global::b.C<f2, Y1>.A(this.A));
			base.h(new global::b.C<f2, Y1>.a(this.A));
			this.A(0, 0);
		}
		public void Dispose()
		{
			this.A();
			this.A.Clear();
		}
		~F2()
		{
			this.Dispose();
		}
		public new static F2 A(F2 f)
		{
			F2 f2 = new F2();
			f2.h(f.h());
			f2.I(f.I());
			foreach (Y1 y in (IEnumerable)f.h())
			{
				int num = y.a();
				Y1 y2 = f2.h(num);
				foreach (Y1 y3 in (IEnumerable)f.h())
				{
					int num2 = y3.a();
					Y1 y4 = f2.I(num2);
					d.a a = f.A(num, num2);
					if (a != null)
					{
						f2.A(a, y2.a(), y4.a(), true);
					}
				}
				y2.A(null, false, false);
				foreach (Y1 y5 in (IEnumerable)f.h())
				{
					int num3 = y5.a();
					Y1 y6 = f2.I(num3);
					y6.A(null, false, false);
				}
			}
			return f2;
		}
		public new static bool A(F2 f, F2 f2)
		{
			if (f.h() != f2.h())
			{
				return false;
			}
			if (f.I() != f2.I())
			{
				return false;
			}
			if (f.A() != f2.A())
			{
				return false;
			}
			foreach (Y1 y in (IEnumerable)f2.h())
			{
				int num = y.a();
				f.h(num);
				foreach (Y1 y2 in (IEnumerable)f2.h())
				{
					int num2 = y2.a();
					f.I(num2);
					if (f.A(num, num2) != f2.A(num, num2))
					{
						return false;
					}
				}
			}
			return true;
		}
		public new int A()
		{
			return this.A.Count;
		}
		public new global::b.b A()
		{
			return this.A() as global::b.b;
		}
		public new d.a A()
		{
			f2 f = this.A(this.A, this.a);
			if (f == null)
			{
				return null;
			}
			return f.A;
		}
		public new void A(d.a a)
		{
			f2 f = this.a(a);
			this.A = f.A;
			this.a = f.a;
		}
		public new Point A()
		{
			return new Point(this.A.a(), this.a.a());
		}
		public new Rectangle A(int num, int num2)
		{
			Y1 y = base.h(num);
			Y1 y2 = base.I(num2);
			int num3 = y.A();
			int num4 = y2.A();
			return new Rectangle(num3, num4, y.a() - num3, y2.a() - num4);
		}
		public new D.C A(d.a a)
		{
			f2 f = this.a(a);
			if (f != null)
			{
				return this.H(f.A, f.a);
			}
			return null;
		}
		public new Point A(d.a a)
		{
			f2 f = this.a(a);
			return new Point(f.A.a(), f.a.a());
		}
		public new Point A(D.C c)
		{
			return new Point(c.a(), c.B());
		}
		public new bool A(int num, int num2)
		{
			return num >= 0 && num < base.h() && num2 >= 2 && num2 < base.I() - 1;
		}
		public new bool A()
		{
			return base.h() > k1.a.Width || base.I() > k1.a.Height;
		}
		public new d.a A(int num, int num2)
		{
			f2 f = this.a(num, num2);
			if (f == null)
			{
				return null;
			}
			return f.A;
		}
		public new d.a A(D.C c)
		{
			f2 f = this.B(c);
			if (f == null)
			{
				return null;
			}
			return f.A;
		}
		public new bool A(d.a key)
		{
			return this.A.ContainsKey(key);
		}
		public new f2 A(d.a key)
		{
			f2 result = null;
			if (this.A.TryGetValue(key, out result))
			{
				return result;
			}
			return null;
		}
		public new d.a[] A()
		{
			d.a[] array = new d.a[this.A()];
			this.A.Keys.CopyTo(array, 0);
			return array;
		}
		public new int A(int num)
		{
			return base.h(num).c();
		}
		public new int a(int num)
		{
			return base.I(num).c();
		}
		public new bool A(d.a a, out int ptr, out int ptr2)
		{
			f2 f = this.A(a);
			if (f == null)
			{
				ptr = -1;
				ptr2 = -1;
				return false;
			}
			ptr = f.A.a();
			ptr2 = f.a.a();
			return true;
		}
		public new d.a A(d.a a, G2 g)
		{
			int num;
			int num2;
			if (!this.A(a, out num, out num2))
			{
				return null;
			}
			return this.A(num, num2, g);
		}
		public new d.a[] A(int num, int num2, bool flag)
		{
			G2 g = flag ? G2.West : G2.North;
			G2 g2 = flag ? G2.East : G2.South;
			d.a[] array = new d.a[2];
			d.a[] array2 = array;
			array2[0] = this.A(num, num2, g);
			if (array2[0] != null)
			{
				array2[1] = this.A(num, num2, g2);
				if (array2[1] != null)
				{
					return array2;
				}
			}
			return null;
		}
		public new void A(d.a a, int num, int num2)
		{
			this.A(a, num, num2, false);
		}
		public new F A(Point point)
		{
			Point? point2 = null;
			if (this.A.HasValue)
			{
				Point value = this.A.Value;
				if (value.X < base.h() && value.Y < base.I() && this.A(value.X, value.Y).Contains(point))
				{
					point2 = new Point?(value);
				}
			}
			if (!point2.HasValue && base.h() > 0 && base.I() > 0)
			{
				Point value2 = new Point(base.h() - 1, base.I() - 1);
				foreach (Y1 y in (IEnumerable)base.h())
				{
					if (point.X < y.a())
					{
						value2 = new Point(y.a(), base.I() - 1);
						value2.X = y.a();
						break;
					}
				}
				foreach (Y1 y2 in (IEnumerable)base.h())
				{
					if (point.Y < y2.a())
					{
						value2.Y = y2.a();
						break;
					}
				}
				point2 = new Point?(value2);
			}
			if (!point2.HasValue)
			{
				return null;
			}
			this.A = point2;
			G2 g = G2.None;
			G2 g2 = G2.None;
			Point value3 = point2.Value;
			d.a a = this.A(value3.X, value3.Y);
			if (a == null || !a.e(point))
			{
				Rectangle rectangle = this.A(value3.X, value3.Y);
				if (point.X < rectangle.X + rectangle.Width / 4)
				{
					g = G2.West;
				}
				else
				{
					if (point.X > rectangle.X + rectangle.Width * 3 / 4)
					{
						g = G2.East;
					}
				}
				if (point.Y < rectangle.Y + rectangle.Height / 4)
				{
					g2 = G2.North;
				}
				else
				{
					if (point.Y > rectangle.Y + rectangle.Height * 3 / 4)
					{
						g2 = G2.South;
					}
				}
			}
			return new F(this, this.E(value3.X, value3.Y), g, g2);
		}
		public new F A(d.a a, G2 g)
		{
			f2 f = this.A(a);
			if (f == null)
			{
				return null;
			}
			Point point = new Point(f.A.a(), f.a.a());
			return new F(this, this.E(point.X, point.Y), G2.None, g);
		}
		public new D.C A(d.a a, F f)
		{
			int num;
			int num2;
			int num3;
			int num4;
			if (!this.A(f, out num, out num2, out num3, out num4))
			{
				throw new l1();
			}
			return this.A(a, num, num2, false);
		}
		public new bool A(F f, out int ptr, out int ptr2, out int ptr3, out int ptr4)
		{
			ptr3 = -1;
			ptr4 = -1;
			ptr = f.a().a();
			bool flag = false;
			if (f.a() != G2.None)
			{
				if (f.a() == G2.East)
				{
					ptr++;
				}
				flag = true;
			}
			ptr2 = f.a().B();
			bool flag2 = false;
			if (f.B() != G2.None)
			{
				if (f.B() == G2.South)
				{
					ptr2++;
				}
				if (ptr2 <= this.A.B())
				{
					return false;
				}
				if (ptr2 > this.a.B())
				{
					return false;
				}
				flag2 = true;
			}
			if (flag)
			{
				ptr3 = this.e(ptr).A;
			}
			if (flag2)
			{
				ptr4 = this.F(ptr2).A;
			}
			return true;
		}
		public new bool A(d.a a, bool flag, bool flag2)
		{
			f2 f = this.a(a);
			if (f == null)
			{
				throw new l1();
			}
			if (a is global::c.b)
			{
				throw new l1();
			}
			if (!flag2)
			{
				this.A(f, flag, flag);
			}
			return true;
		}
		public new bool A(H2 h, F f)
		{
			return new F2.A(h, this, f).A();
		}
		public new bool A(d.a a, d.a a2, G2 g, bool flag, bool flag2)
		{
			if (!this.A(a2))
			{
				throw new l1();
			}
			int num;
			int num2;
			if (!this.A(a2, out num, out num2))
			{
				throw new l1();
			}
			F f = null;
			if (flag)
			{
				Point point = g2.A(new Point(num, num2), g);
				if (this.A(point.X, point.Y))
				{
					f = new F(this, this.E(point.X, point.Y));
					if (f.a() != null)
					{
						f = null;
					}
				}
			}
			if (!flag2)
			{
				if (global::a.F.a(f, null))
				{
					f = new F(this, this.E(num, num2), g);
				}
				this.A(a, f);
			}
			return true;
		}
		public new bool A(global::C.C c)
		{
			return this.A(c, this.A(c), false);
		}
		public new bool A(global::C.C c, Point point, bool flag)
		{
			if (c.A() == null)
			{
				return false;
			}
			global::C.b b = c.A();
			global::b.c c2 = c.A();
			Point point2 = (c is global::C.b) ? point : this.A(b);
			Point point3 = (c is global::C.b) ? this.A(c2) : point;
			if (point2.X != point3.X)
			{
				return false;
			}
			if (point2.Y > point3.Y)
			{
				return false;
			}
			if (point2.Y == point3.Y && !flag)
			{
				return false;
			}
			int num = 0;
			for (int i = point2.Y + 1; i < point3.Y; i++)
			{
				d.a a = this.A(point2.X, i) as global::C.C;
				if (a != null && a != b && a != c2)
				{
					if (a is global::C.b)
					{
						num++;
					}
					if (a is global::b.c)
					{
						num--;
					}
				}
			}
			return num == 0;
		}
		private new void A(int num, int num2)
		{
			D.C c;
			if (num < base.h() && num2 < base.I())
			{
				c = this.E(num, num2);
			}
			else
			{
				c = this.d(num, num2, null);
			}
			this.A = base.h(c.a());
			this.a = base.I(c.B());
			this.A.A(k1.A.X);
			this.a.A(k1.A.Y);
		}
		public new void a(d.a a)
		{
			f2 f = this.a(a);
			if (f == null)
			{
				throw new l1();
			}
			f.A.A(null, false, false);
			f.a.A(null, false, false);
		}
		public new void A(Graphics graphics)
		{
			foreach (f2 current in this.A.Values)
			{
				current.A(this, graphics);
			}
			this.A.A(k1.A.X);
			this.a.A(k1.A.Y);
			this.A(this.A);
			this.A(this.a);
		}
		public new void A(Graphics graphics, d.a a)
		{
			this.a(a).A(this, graphics);
		}
		public new Rectangle A()
		{
			if (base.h() == 0 || base.I() == 0)
			{
				throw new l1();
			}
			Point location = new Point(base.h(0).A(), base.I(0).A());
			Rectangle result = new Rectangle(location, new Size(base.h(base.h() - 1).a() - location.X, base.I(base.I() - 1).a() - location.Y));
			result = Rectangle.Union(result, this.A().L());
			return result;
		}
		private new void A(Y1 y)
		{
			int num = y.a();
			bool flag = y.A();
			int num2 = flag ? base.h() : base.I();
			y.A();
			y.A(null, false, false);
			Y1 y2 = y;
			for (int i = num + 1; i < num2; i++)
			{
				Y1 y3 = flag ? base.h(i) : base.I(i);
				y3.A(null, false, false);
				y3.A(y2.a() + (y3.B() - y3.A()));
				y3.A();
				y2 = y3;
			}
			y2 = y;
			for (int j = num - 1; j >= 0; j--)
			{
				Y1 y4 = flag ? base.h(j) : base.I(j);
				y4.A(null, false, false);
				y4.A(y2.A() - (y4.a() - y4.B()));
				y4.A();
				y2 = y4;
			}
		}
		public new bool A(Rectangle rectangle, out Rectangle ptr)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			Point location = rectangle.Location;
			location.Offset(rectangle.Width / 2, rectangle.Height / 2);
			for (int i = 0; i < base.h(); i++)
			{
				int x = base.h(i).B();
				if (rectangle.Contains(x, location.Y))
				{
					if (num == -1)
					{
						num = i;
					}
					num2 = i;
				}
				else
				{
					if (num2 != -1)
					{
						break;
					}
				}
			}
			for (int j = 0; j < base.I(); j++)
			{
				int y = base.I(j).B();
				if (rectangle.Contains(location.X, y))
				{
					if (num3 == -1)
					{
						num3 = j;
					}
					num4 = j;
				}
				else
				{
					if (num4 != -1)
					{
						break;
					}
				}
			}
			if (num == -1 || num3 == -1)
			{
				ptr = Rectangle.Empty;
				return false;
			}
			ptr = new Rectangle(num, num3, num2 - num + 1, num4 - num3 + 1);
			return true;
		}
		public new void A()
		{
			for (int i = base.h() - 1; i >= 0; i--)
			{
				if (base.h(i).c() == 0)
				{
					this.f(i);
				}
			}
			for (int j = base.I() - 1; j >= 0; j--)
			{
				if (base.I(j).c() == 0)
				{
					this.G(j);
				}
			}
		}
		private new f2 a(d.a key)
		{
			f2 result = null;
			if (this.A.TryGetValue(key, out result))
			{
				return result;
			}
			throw new l1();
		}
		private new D.C A(d.a a, int num, int num2, bool flag)
		{
			if (this.A(a))
			{
				throw new l1();
			}
			Y1 y = base.h(num);
			Y1 y2 = base.I(num2);
			D.C c = this.E(y.a(), y2.a());
			if (this.B(c) != global::b.C<f2, Y1>.h())
			{
				throw new l1();
			}
			if (a is global::b.a)
			{
				if (a is global::b.A)
				{
					if (global::D.C.B(this.A, null))
					{
						throw new l1();
					}
					this.A = c;
				}
				if (a is E.A)
				{
					if (global::D.C.B(this.a, null))
					{
						throw new l1();
					}
					this.a = c;
				}
			}
			f2 f = new f2(a, y, y2);
			this.D(c, f);
			this.A.Add(f.A, f);
			if (!flag)
			{
				y.A(f, true, false);
				y2.A(f, true, false);
				n1.B();
			}
			return c;
		}
		private new void A(f2 f, bool flag, bool flag2)
		{
			Y1 y = f.A;
			Y1 y2 = f.a;
			D.C c = this.E(y.a(), y2.a());
			if (this.B(c) == global::b.C<f2, Y1>.h())
			{
				throw new l1();
			}
			this.C(c);
			if (y.c() == 0 && !flag)
			{
				this.f(y.a());
			}
			else
			{
				y.A(f, false, true);
			}
			if (y2.c() == 0 && !flag2)
			{
				this.G(y2.a());
			}
			else
			{
				y2.A(f, false, true);
			}
			d.a a = f.A;
			if (a is global::b.a)
			{
				if (a is global::b.A)
				{
					this.A = null;
				}
				if (a is E.A)
				{
					this.a = null;
				}
			}
			if (!this.A.Remove(f.A))
			{
				throw new l1();
			}
			f.A();
		}
		private new d.a A(int num, int num2, G2 g)
		{
			return this.A(ref num, ref num2, g, 2147483647);
		}
		private new d.a A(ref int ptr, ref int ptr2, G2 g, int num)
		{
			f2 f = this.A(ref ptr, ref ptr2, g, num);
			if (f == null)
			{
				return null;
			}
			return f.A;
		}
		private new f2 A(ref int ptr, ref int ptr2, G2 g, int num)
		{
			if (!g2.A(g))
			{
				return null;
			}
			if (g2.B(g))
			{
				return this.A(ptr, ref ptr2, g, num);
			}
			return this.A(ptr2, ref ptr, g, num);
		}
		private new f2 A(int num, ref int ptr, G2 g, int num2)
		{
			if (!g2.A(g))
			{
				throw new l1();
			}
			bool flag = g2.B(g);
			bool flag2 = g2.C(g);
			Y1 y = flag ? base.h(num) : base.I(num);
			int num3 = flag2 ? -1 : (flag ? base.I() : base.h());
			int num4 = flag2 ? -1 : 1;
			int num5 = 0;
			int num6 = ptr;
			while (ptr != num3)
			{
				f2 f = flag ? this.A(y, base.I(ptr)) : this.A(base.h(ptr), y);
				if (ptr != num6)
				{
					if (f != null && !(f.A is d.A))
					{
						return f;
					}
					if (num5 >= num2)
					{
						return null;
					}
				}
				ptr += num4;
				num5++;
			}
			return null;
		}
		public new global::b.B A(E.a a, bool flag)
		{
			return new Y1(this, a, flag);
		}
		public new f2 A(Y1 y, Y1 y2)
		{
			if (!y.A())
			{
				throw new l1();
			}
			if (y2.A())
			{
				throw new l1();
			}
			return this.a(y.a(), y2.a());
		}
		public new void A(D.C c, f2 f, f2 f2)
		{
			if (f == f2)
			{
				return;
			}
			if (f2 == global::b.C<f2, Y1>.h())
			{
				Y1 expr_18 = (Y1)c.a();
				expr_18.a(expr_18.c() - 1);
				Y1 expr_30 = (Y1)c.B();
				expr_30.a(expr_30.c() - 1);
				return;
			}
			if (f == global::b.C<f2, Y1>.h())
			{
				Y1 expr_51 = (Y1)c.a();
				expr_51.a(expr_51.c() + 1);
				Y1 expr_69 = (Y1)c.B();
				expr_69.a(expr_69.c() + 1);
			}
		}
		public new void B(XmlWriter xmlWriter, X1 x)
		{
			if (x == null)
			{
				throw new l1();
			}
			xmlWriter.WriteStartElement("LAYOUT");
			xmlWriter.WriteAttributeString("FORMAT", "1.00");
			xmlWriter.WriteAttributeString("COLUMNS", "" + base.h());
			xmlWriter.WriteAttributeString("ROWS", "" + base.I());
			xmlWriter.WriteStartElement("ENTRIES");
			int num = -1;
			foreach (Y1 y in (IEnumerable)base.h())
			{
				num++;
				int num2 = -1;
				foreach (Y1 y2 in (IEnumerable)base.h())
				{
					num2++;
					f2 f = this.A(y, y2);
					if (f != null)
					{
						xmlWriter.WriteStartElement("ENTRY");
						xmlWriter.WriteAttributeString("COLUMN", "" + num);
						xmlWriter.WriteAttributeString("ROW", "" + num2);
						if (global::b.B.a(y, this.A) && global::b.B.a(y2, this.a))
						{
							xmlWriter.WriteAttributeString("ANCHOR", "" + true);
						}
						f.A.B(xmlWriter, x);
						xmlWriter.WriteEndElement();
					}
				}
			}
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();
		}
		public void b(XmlReader xmlReader, w1 w)
		{
			if (xmlReader["FORMAT"] != "1.00")
			{
				throw new l1();
			}
			int num = int.Parse(xmlReader["COLUMNS"]);
			int num2 = int.Parse(xmlReader["ROWS"]);
			xmlReader.ReadStartElement("LAYOUT");
			base.h(num);
			base.I(num2);
			bool isEmptyElement = xmlReader.IsEmptyElement;
			xmlReader.ReadStartElement("ENTRIES");
			if (!isEmptyElement)
			{
				while (xmlReader.IsStartElement())
				{
					int num3 = int.Parse(xmlReader["COLUMN"]);
					int num4 = int.Parse(xmlReader["ROW"]);
					bool flag = xmlReader["ANCHOR"] == "" + true;
					if (flag)
					{
						this.A(num3, num4);
					}
					xmlReader.ReadStartElement("ENTRY");
					string text = xmlReader["SUBTYPE"];
					Type type = global::d.a.d(text);
					ConstructorInfo constructor = type.GetConstructor(new Type[]
					{
						typeof(XmlReader),
						typeof(w1)
					});
					d.a a = (d.a)constructor.Invoke(new object[]
					{
						xmlReader,
						w
					});
					this.A(a, num3, num4);
					xmlReader.ReadEndElement();
				}
				xmlReader.ReadEndElement();
			}
			xmlReader.ReadEndElement();
		}
		public void C(w1 w)
		{
		}
	}
	public class f2
	{
		public d.a A;
		public Y1 A;
		public Y1 a;
		public Rectangle A = default(Rectangle);
		public f2(d.a a, Y1 y, Y1 y2)
		{
			this.A = a;
			this.A = y;
			this.a = y2;
		}
		public void A()
		{
			this.A = null;
			this.A = null;
			this.a = null;
		}
		public void A(F2 f, Graphics graphics)
		{
			this.A.q(graphics);
			if (this.A is global::b.b)
			{
				Point point = this.A.d();
				int height = this.A.l().Height;
				this.A = new Rectangle(point.X - height / 2, point.Y - height / 2, height, height);
			}
			else
			{
				this.A = this.A.l();
			}
			Point point2 = this.A.d();
			if (graphics != null)
			{
				foreach (D.A a in this.A.g())
				{
					if (!string.IsNullOrEmpty(a.c()))
					{
						G2 g = a.d(f);
						Rectangle b = a.d(graphics, g);
						b.Width -= global::c.C.c.Width / 2;
						this.A = Rectangle.Union(this.A, b);
					}
				}
			}
			this.A.Offset(-point2.X, -point2.Y);
		}
	}
}
