using b;
using c;
using C;
using d;
using D;
using E;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
namespace a
{
	public class Q1 : p1
	{
		public new delegate void A(p1, d.a);
		public new delegate void a(p1, d.a);
		public new const string A = "DIAGRAM";
		public new const string a = "1.00";
		private new h<d.a> A = new h<d.a>();
		private new h<D.A> A = new h<D.A>();
		private new F2 A = new F2();
		private new C2 A = new C2();
		private new byte[] A;
		private new bool A;
		private new static Regex A = new Regex("(\\s|-){1,}");
		private new d.a A;
		private new d.a a;
		private new static readonly string[,] A;
		private new Q1.A A;
		private new Q1.a A;
		public Q1(string text, bool flag) : base(text)
		{
			this.A().h(1);
			this.A().I(3);
			this.A(new global::b.b(Point.Empty, base.b()), 0, 0, false);
			this.A(this.A = new global::b.A(Point.Empty), 0, 1, false);
			this.A(this.a = new E.A(Point.Empty), 0, 2, false);
			if (!this.a(new D.A(this.A, this.a)))
			{
				throw new l1();
			}
			base.B(new P1<p1>.a(this.A));
			this.e(flag);
		}
		public Q1(XmlReader xmlReader, w1 w)
		{
			this.b(xmlReader, w);
			base.B(new P1<p1>.a(this.A));
		}
		public Q1(byte[] array)
		{
			j2.A(this, array);
			base.B(new P1<p1>.a(this.A));
		}
		~Q1()
		{
			base.b(new P1<p1>.a(this.A));
		}
		public new int A()
		{
			return this.A.get_Count();
		}
		public new int a()
		{
			return this.A.get_Count();
		}
		public new F2 A()
		{
			return this.A;
		}
		protected override C2 F()
		{
			return this.A;
		}
		public override bool E()
		{
			return this.a != null && this.a.c() == "End";
		}
		public override void e(bool flag)
		{
			if (this.a != null)
			{
				this.a.D(flag ? "End" : "Ende");
			}
		}
		public new void A(s1 s)
		{
			this.A.A(s);
		}
		public new void a(s1 s)
		{
			this.A.a(s);
		}
		public override void H()
		{
			this.A.a();
		}
		public override s1 f()
		{
			return new e2(this);
		}
		public override B1 G(s1 s, Graphics graphics, a1 a, bool flag)
		{
			return new b1((e2)s, graphics, a, flag, this.E());
		}
		public override bool g(Control owner, v1 v, string text)
		{
			S1 s = new S1(text, this, v);
			return s.ShowDialog(owner) == DialogResult.OK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public new void A(Q1.A b)
		{
			this.A = (Q1.A)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public new void a(Q1.A value)
		{
			this.A = (Q1.A)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public new void A(Q1.a b)
		{
			this.A = (Q1.a)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public new void a(Q1.a value)
		{
			this.A = (Q1.a)Delegate.Remove(this.A, value);
		}
		private new void A(p1 p, string text)
		{
			if (p != this)
			{
				throw new l1();
			}
			d.a a = this.A().A();
			a.D(base.b());
			this.A.a();
		}
		public new global::c.b A(Point point)
		{
			d.a a = this.a(point);
			if (a != null)
			{
				global::c.b b = a.W(point);
				if (b != null && this.A(a, b.A(), true))
				{
					return b;
				}
			}
			return null;
		}
		public new global::c.a A(Point point)
		{
			global::c.a a = this.A(point);
			if (a == null)
			{
				a = this.A(point);
			}
			return a;
		}
		public new d.a A(Point point)
		{
			foreach (d.a current in (IEnumerable<d.a>)this.A)
			{
				if (current.e(point))
				{
					return current;
				}
			}
			return null;
		}
		private new d.a a(Point pt)
		{
			foreach (d.a current in (IEnumerable<d.a>)this.A)
			{
				if (current.l().Contains(pt))
				{
					return current;
				}
			}
			return null;
		}
		private new D.A A(Point point)
		{
			foreach (D.A current in (IEnumerable<D.A>)this.A)
			{
				if (current.e(point))
				{
					return current;
				}
			}
			return null;
		}
		public new void A(string text, string text2)
		{
			foreach (d.a current in (IEnumerable<d.a>)this.A)
			{
				d.B b = current as d.B;
				if (b != null && Q1.A(b.c(), text) && !Q1.A(b.c(), text2))
				{
					b.D(text2);
					n1.B();
				}
			}
			this.A.a();
		}
		public new bool A(string text)
		{
			foreach (d.a current in (IEnumerable<d.a>)this.A)
			{
				d.B b = current as d.B;
				if (b != null && Q1.A(b.c(), text))
				{
					return true;
				}
			}
			return false;
		}
		public new static bool A(string text, string text2)
		{
			text = Q1.A.Replace("" + text.ToUpper(), "");
			text2 = Q1.A.Replace("" + text2.ToUpper(), "");
			return text == text2;
		}
		public new string A(Type type)
		{
			if (type == typeof(D.b))
			{
				if (!this.E())
				{
					return "Eingabe von ";
				}
				return "Input ";
			}
			else
			{
				if (type == typeof(global::C.c))
				{
					if (!this.E())
					{
						return "Ausgabe von ";
					}
					return "Output ";
				}
				else
				{
					if (type == typeof(global::c.c))
					{
						return "?";
					}
					if (type != typeof(d.A))
					{
						return "";
					}
					if (!this.E())
					{
						return "Kommentar";
					}
					return "Comment";
				}
			}
		}
		public new d.a A(Type type, Point point)
		{
			if (type == null)
			{
				throw new l1();
			}
			d.a result;
			if (type == typeof(global::c.B))
			{
				ConstructorInfo constructor = type.GetConstructor(new Type[]
				{
					typeof(Point)
				});
				result = (d.a)constructor.Invoke(new object[]
				{
					point
				});
			}
			else
			{
				ConstructorInfo constructor2 = type.GetConstructor(new Type[]
				{
					typeof(Point),
					typeof(string)
				});
				result = (d.a)constructor2.Invoke(new object[]
				{
					point,
					this.A(type)
				});
			}
			return result;
		}
		public new static bool A(Type type)
		{
			return type == typeof(D.b) || type == typeof(global::C.c) || type == typeof(d.b) || type == typeof(d.B);
		}
		public new bool A(Type type, F f)
		{
			d.a a = global::a.F.B(f, null) ? f.a() : null;
			if (a == null)
			{
				return false;
			}
			new Point(f.a().a(), f.a().B());
			f.a();
			if (type == a.GetType())
			{
				return false;
			}
			if (a is global::c.B)
			{
				if (type == typeof(global::c.c))
				{
					return true;
				}
				if (a.E1() > 1)
				{
					return false;
				}
				if (type == typeof(global::C.b))
				{
					foreach (D.A a2 in a.g())
					{
						if (a2.d() != G2.South)
						{
							return false;
						}
					}
					return true;
				}
			}
			else
			{
				if (!true)
				{
					return false;
				}
				if (!Q1.A(a.GetType()))
				{
					return false;
				}
			}
			return Q1.A(type);
		}
		public new bool a(Type type, F f)
		{
			if (global::a.F.a(f, null))
			{
				throw new l1();
			}
			if (f.a() != null && !this.A(type, f))
			{
				return false;
			}
			d.a a = this.A(type, Point.Empty);
			H2 h = new H2(a);
			return this.a(h, f);
		}
		public new d.a A(Type type, F f)
		{
			d.a a = this.A(type, Point.Empty);
			this.A(a, f);
			return a;
		}
		public new void A(d.a a, F f)
		{
			H2 h = new H2(a);
			this.a(h, f);
			if (a is global::C.b && ((global::C.b)a).A() == null)
			{
				global::C.b b = (global::C.b)a;
				global::b.c c = new global::b.c(Point.Empty, "");
				this.A(c, b, G2.South, true, false);
				this.A(b, G2.South, false);
				b.A(c);
				c.A(b);
			}
		}
		public new bool A(H2 h, F f)
		{
			d.a a = f.a();
			if (a != null && !h.A(a))
			{
				if (!(a is global::c.B))
				{
					return false;
				}
				if (h.A() is d.A)
				{
					return false;
				}
				if (!(a is global::c.B))
				{
					return false;
				}
			}
			return this.a(h, f);
		}
		public new void A(H2 h, F f)
		{
			this.a(h, f);
		}
		public new void A(H2 h)
		{
			F f = new F(this.A(), this.A().A(this.A), G2.South);
			this.A(h, f);
		}
		public new bool A(k k, F f)
		{
			if (k == null)
			{
				throw new l1();
			}
			return k.d() && this.A(k.A(), f);
		}
		public new void A(k k, F f)
		{
			this.A(k.A(), f);
		}
		public new void A(H2 h, bool flag)
		{
			IDictionary<D.A, bool> dictionary = h.A();
			foreach (d.a current in h.A())
			{
				if (!(current is global::C.C) || this.A(current))
				{
					this.A(current, flag);
				}
			}
			foreach (D.A current2 in h.A())
			{
				if (this.A.Contains(current2))
				{
					this.a(current2);
					this.A(current2, flag);
				}
			}
			foreach (D.A current3 in dictionary.Keys)
			{
				this.A(current3, flag);
			}
			this.A(flag);
		}
		public new d.a A(H2 h)
		{
			int num = -2147483648;
			foreach (global::c.a a in (IEnumerable)h)
			{
				d.a a2 = a as d.a;
				if (a2 != null)
				{
					foreach (D.A a3 in a2.G())
					{
						int num2 = this.A().I() - this.A().A(a2).Y;
						if (!h.A(a3.d()))
						{
							num2 += 10000;
							if (a3.d(this.A()) == G2.South)
							{
								num2 += 10000;
							}
							if (num < num2)
							{
								num = num2;
								h.A(a2);
							}
						}
					}
				}
			}
			return h.A();
		}
		public new void A(H2 h, string text)
		{
			IDictionary<D.A, bool> dictionary = h.A();
			foreach (D.A current in dictionary.Keys)
			{
				this.a(current);
			}
			F f = this.A().A(h.A(), G2.None);
			this.A(h, true);
			d.a a = this.A(typeof(d.B), f);
			a.D(text);
			this.A().A();
			foreach (D.A current2 in dictionary.Keys)
			{
				d.a a2 = h.A(current2.d()) ? a : current2.d();
				d.a a3 = h.A(current2.G()) ? a : current2.G();
				if (this.A(a2) && this.A(a3))
				{
					current2.G(a2, a3);
					this.a(current2);
				}
			}
			this.H();
		}
		private new bool A(d.a a, int num, int num2, bool flag)
		{
			if (this.A().A(a))
			{
				throw new l1();
			}
			D.C c = this.A.E(num, num2);
			if (this.A.B(c) != null)
			{
				return false;
			}
			if (!flag)
			{
				F f = new F(this.A, c);
				this.A().A(a, f);
				this.A(a);
				n1.B();
			}
			return true;
		}
		private new bool A(d.a a)
		{
			return this.A.Contains(a);
		}
		private new bool A(D.A a)
		{
			if (a == null)
			{
				return false;
			}
			if (!this.A.Contains(a))
			{
				return false;
			}
			bool flag = this.A(a.d());
			bool flag2 = this.A(a.G());
			if (flag != flag2)
			{
				throw new l1();
			}
			return flag;
		}
		private new bool A(global::c.a a)
		{
			d.a a2 = a as d.a;
			if (a2 != null)
			{
				return this.A(a2);
			}
			D.A a3 = a as D.A;
			return a3 != null && this.A(a3);
		}
		private new bool A(d.a a, bool flag)
		{
			if (a is global::b.b || a is global::b.a)
			{
				return false;
			}
			object[,] array = new object[2, 2];
			int num = 0;
			foreach (D.A a2 in a.G())
			{
				G2 g = a2.d(this.A());
				foreach (D.A a3 in a.g())
				{
					G2 g2 = a3.d(this.A());
					if (g2 == g)
					{
						array[num, 0] = a2;
						array[num, 1] = a3.G();
						num++;
						break;
					}
				}
			}
			foreach (D.A a4 in a.d())
			{
				this.a(a4);
			}
			if (!this.A().A(a, flag, false))
			{
				throw new l1();
			}
			this.a(a);
			n1.B();
			if (this.A != null)
			{
				this.A(this, a);
			}
			for (int i = 0; i < num; i++)
			{
				D.A a5 = (D.A)array[i, 0];
				d.a a6 = (d.a)array[i, 1];
				a5.G(a5.d(), a6);
				this.a(a5);
			}
			if (a is global::C.C)
			{
				global::C.C c = (global::C.C)a;
				if (c.A() != null)
				{
					c.A().A(null);
					this.A(c.A(), flag);
					c.A(null);
				}
			}
			return true;
		}
		private new bool A(d.a a, d.a a2, G2 g, bool flag, bool flag2)
		{
			if (!this.A().A(a, a2, g, flag, flag2))
			{
				return false;
			}
			if (!flag2)
			{
				this.A(a);
				n1.B();
				this.C(a);
				if (this.A != null)
				{
					this.A(this, a);
				}
			}
			return true;
		}
		private new bool a(H2 h, F f)
		{
			f.A = false;
			if (h == null)
			{
				return false;
			}
			if (h.A() == null)
			{
				return false;
			}
			d.a a = f.a();
			if (a is global::b.b)
			{
				return false;
			}
			if (a is global::b.a)
			{
				return false;
			}
			using (F2 f2 = F2.A(this.A()))
			{
				if (a != null)
				{
					f2.A(a, true, false);
				}
				if (!f2.A(h, f))
				{
					bool result = false;
					return result;
				}
				if (this.A(h.A()))
				{
					global::C.b[] array = h.A();
					for (int i = 0; i < array.Length; i++)
					{
						global::C.b b = array[i];
						if (!f2.A(b))
						{
							bool result = false;
							return result;
						}
					}
					global::b.c[] array2 = h.A();
					for (int j = 0; j < array2.Length; j++)
					{
						global::b.c c = array2[j];
						if (!f2.A(c))
						{
							bool result = false;
							return result;
						}
					}
					bool flag = F2.A(f2, this.A());
					if (flag)
					{
						bool result = false;
						return result;
					}
				}
			}
			f.A = true;
			return true;
		}
		private new void a(H2 h, F f)
		{
			if (!f.A && !this.a(h, f))
			{
				throw new l1();
			}
			bool flag = this.A(h.A());
			D.C c = null;
			List<D.A> list = null;
			d.a a = f.a();
			if (a != null)
			{
				if (h.A(a))
				{
					a = null;
				}
				else
				{
					c = this.A().A(a);
					list = new List<D.A>();
					foreach (D.A a2 in a.d())
					{
						this.a(a2);
						d.a a3 = h.A();
						if (a2.d() != a3 && a2.G() != a3)
						{
							list.Add(a2);
						}
					}
					this.A(a, true);
				}
			}
			Dictionary<D.A, G2> dictionary = new Dictionary<D.A, G2>();
			foreach (D.A current in (IEnumerable<D.A>)this.A)
			{
				dictionary.Add(current, current.d(this.A()));
			}
			this.A().A(h, f);
			if (!this.A(h.A()))
			{
				foreach (global::c.a a4 in (IEnumerable)h)
				{
					if (a4 is d.a)
					{
						this.A((d.a)a4);
					}
				}
				foreach (global::c.a a5 in (IEnumerable)h)
				{
					if (a5 is D.A)
					{
						D.A a6 = (D.A)a5;
						if (h.A(a6.d()) && h.A(a6.G()))
						{
							this.a(a6);
						}
					}
				}
			}
			n1.B();
			List<D.A> list2 = new List<D.A>();
			List<D.A> list3 = new List<D.A>();
			List<D.A> list4 = new List<D.A>();
			List<D.A> list5 = new List<D.A>();
			foreach (D.A current2 in (IEnumerable<D.A>)this.A)
			{
				G2 g = G2.None;
				if (dictionary.TryGetValue(current2, out g) && (!current2.d(this.A()) || current2.d(this.A()) != g))
				{
					list2.Add(current2);
					if (h.A(current2.G()))
					{
						if (h.A(current2.d()))
						{
							throw new l1();
						}
						list3.Add(current2);
					}
					else
					{
						if (h.A(current2.d()))
						{
							list4.Add(current2);
						}
						else
						{
							list5.Add(current2);
						}
					}
				}
			}
			foreach (D.A current3 in list2)
			{
				this.a(current3);
			}
			foreach (D.A current4 in list3)
			{
				foreach (D.A current5 in list4)
				{
					G2 g2 = global::D.A.d(this.A(), current4.d(), current5.G());
					try
					{
						if (g2 != G2.None && g2 == dictionary[current4] && g2 == dictionary[current5])
						{
							this.A(current4.d(), current5.G(), current4);
						}
					}
					catch
					{
					}
				}
			}
			foreach (D.A current6 in list5)
			{
				this.A(current6.d(), current6.G(), current6);
			}
			if (global::D.C.B(c, null))
			{
				foreach (D.A current7 in list)
				{
					d.a a7 = this.A().A(c);
					if (current7.d() == a)
					{
						this.A(a7, current7.G(), current7);
					}
					else
					{
						this.A(current7.d(), a7, current7);
					}
				}
			}
			if (flag)
			{
				this.A(false);
			}
			this.H();
		}
		private new void A(d.a a, d.a a2, D.A a3)
		{
			if (a == a2)
			{
				return;
			}
			if (a2 is d.A)
			{
				return;
			}
			G2 g = global::D.A.d(this.A(), a, a2);
			if (!a2.v(g))
			{
				return;
			}
			d.a a4 = this.A().A(a, g);
			if (a4 == null)
			{
				return;
			}
			if (a4 != a2)
			{
				G2 g2 = global::D.A.d(this.A(), a4, a2);
				if (g2 != g)
				{
					return;
				}
			}
			if (a3 == null)
			{
				a3 = new D.A(a, a4);
			}
			a3.G(a, a4);
			this.a(a3);
			if (a4 != a2)
			{
				this.A(a4, a2, null);
			}
		}
		private new void A(d.a a, bool flag)
		{
			if (a is global::c.B)
			{
				if (a.D1() == 0 && this.A(a))
				{
					this.A(a, flag);
				}
				if (a.d() && a.G().A().d(this.A()) == a.g().A().d(this.A()))
				{
					if (Q1.a(a, false))
					{
						return;
					}
					this.A(a, flag);
				}
			}
		}
		private new void A(bool flag)
		{
			List<global::c.B> list = new List<global::c.B>();
			foreach (d.a current in (IEnumerable<d.a>)this.A)
			{
				if (current is global::c.B && current.E1() >= 2 && !Q1.a(current, false))
				{
					list.Add((global::c.B)current);
				}
			}
			foreach (global::c.B current2 in list)
			{
				D.A[] array = current2.g().A();
				this.A(current2, flag);
				D.A[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					D.A a = array2[i];
					this.A(a, flag);
				}
			}
		}
		private new void A(d.a a)
		{
			this.A.Add(a);
			base.J().A(a);
		}
		private new void a(d.a a)
		{
			this.A.Remove(a);
			base.J().b(a);
		}
		public new bool A(d.a a, G2 g, bool flag)
		{
			d.a a2 = null;
			bool flag2 = this.A(a, g, true, out a2);
			if (a2 != null)
			{
				D.A a3 = new D.A(a, a2);
				D.A a4 = null;
				if (this.A.a(a3, out a4))
				{
					if (a3.d() == a4.d())
					{
						return false;
					}
					int num = 45;
					if (a4.d() < num)
					{
						return false;
					}
				}
			}
			if (!flag2)
			{
				a2 = null;
			}
			bool flag3 = false;
			Point empty = Point.Empty;
			if (a2 == null)
			{
				Point point = this.A().A(a);
				D.A a5 = this.A(point, g, ref empty);
				if (a5 != null && !Q1.a(a5.d(), true) && !Q1.a(a5.d()))
				{
					d.a a6 = new global::c.B(new Point(0, 0));
					flag3 = this.A(a6, empty.X, empty.Y, true);
					if (flag3)
					{
						a2 = a6;
					}
				}
			}
			bool flag4 = false;
			bool flag5 = false;
			if (a2 == null)
			{
				Point point2 = this.A().A(a);
				Point left = g2.A(point2, g);
				flag5 = (left != empty);
				global::c.B b = new global::c.B(new Point(0, 0));
				flag4 = (this.A(b, a, g, flag5, true) && this.a(a, g, !flag5));
				if (flag4)
				{
					a2 = b;
				}
			}
			if (a2 == null)
			{
				return false;
			}
			if (!flag)
			{
				if (flag3)
				{
					this.A(a2, empty.X, empty.Y, false);
					this.C(a2);
				}
				else
				{
					if (flag4)
					{
						this.A(a2, a, g, flag5, false);
					}
				}
				d.a a7 = null;
				List<D.A> list = null;
				if (!this.A(a, g, false, out a7))
				{
					list = new List<D.A>();
					D.A[] array = a.g().A();
					for (int i = 0; i < array.Length; i++)
					{
						D.A a8 = array[i];
						this.a(a8);
						list.Add(a8);
					}
				}
				D.A a9 = new D.A(a, a2);
				D.A a10 = null;
				if (this.A.a(a9, out a10))
				{
					this.a(a10);
					a10.G(a9.d(), a9.G());
					a9 = a10;
				}
				this.a(a9);
				Q1.a(a9, true);
				this.A.A(a9);
				this.A(a, false);
				if (list != null)
				{
					foreach (D.A current in list)
					{
						this.A(current, false);
					}
				}
				this.H();
			}
			return true;
		}
		public new bool A(s1 s, D.A a)
		{
			if (a == null)
			{
				throw new l1();
			}
			U1 u = new U1(s, "Verbindungstext", a.c(), a.E());
			bool flag = u.ShowDialog(s.B()) == DialogResult.OK;
			if (flag)
			{
				a.D(u.A());
				Q1.a(a, false);
				d.a a2 = a.d();
				if (a2 is global::c.B && a2.E1() >= 2)
				{
					D.A a3 = null;
					D.A a4 = null;
					foreach (D.A a5 in a2.g())
					{
						if (a5.d(this.A()) == G2.East && !string.IsNullOrEmpty(a5.c()))
						{
							a3 = a5;
						}
						if (a5.d(this.A()) == G2.South && !string.IsNullOrEmpty(a5.c()))
						{
							a4 = a5;
						}
					}
					if (a3 != null && a4 != null)
					{
						global::c.B b = new global::c.B(Point.Empty);
						this.A(b, a4.d(), G2.South, false, false);
						IEnumerator enumerator2 = b.g().GetEnumerator();
						try
						{
							if (enumerator2.MoveNext())
							{
								D.A a6 = (D.A)enumerator2.Current;
								a6.D(a4.c());
								a4.D("");
							}
						}
						finally
						{
							IDisposable disposable2 = enumerator2 as IDisposable;
							if (disposable2 != null)
							{
								disposable2.Dispose();
							}
						}
					}
				}
				this.F().a();
			}
			return flag;
		}
		public new static D.A A(D.A a)
		{
			D.A a2 = a;
			int num = 0;
			while (num++ <= 1000)
			{
				if (string.IsNullOrEmpty(a2.c()))
				{
					d.a a3 = a2.d();
					if (a3 is global::c.B && a3.E1() <= 1)
					{
						D.A a4 = a3.G();
						if (a4 != null && a4 != a)
						{
							a2 = a4;
							continue;
						}
					}
				}
				return a2;
			}
			throw new l1();
		}
		public new static D.A a(D.A a)
		{
			D.A a2 = a;
			int num = 0;
			while (num++ <= 1000)
			{
				d.a a3 = a2.G();
				if (a3 is global::c.B)
				{
					D.A a4 = a3.d();
					if (a4 != null && a4 != a)
					{
						a2 = a4;
						continue;
					}
				}
				return a2;
			}
			throw new l1();
		}
		public new static bool a(d.a a, bool flag)
		{
			d.a a2 = Q1.A(a) as global::c.c;
			return a2 != null && a2.E1() == 1 && (!flag || Q1.a(a2));
		}
		public new static d.a A(d.a a)
		{
			d.a a2 = a;
			int num = 0;
			while (num++ <= 1000)
			{
				D.A a3 = a2.G();
				if (a3 != null)
				{
					a2 = a3.d();
					if (a2 != a && a2 is global::c.B)
					{
						continue;
					}
				}
				if (a2 == a)
				{
					return null;
				}
				return a2;
			}
			throw new l1();
		}
		public new static bool a(d.a a)
		{
			if (!(a is global::c.c))
			{
				return false;
			}
			D.A a2 = a.d();
			return a2 != null && Q1.C(a2.G());
		}
		public static bool C(d.a a)
		{
			d.a a2 = a;
			int num = 0;
			while (num++ <= 1000)
			{
				if (!(a2 is global::c.B))
				{
					return false;
				}
				if (a2.E1() > 1)
				{
					return true;
				}
				D.A a3 = a2.d();
				if (a3 == null)
				{
					return false;
				}
				a2 = a3.G();
			}
			throw new l1();
		}
		public new bool A(D.A a, bool flag, bool flag2)
		{
			if (this.A.Contains(a))
			{
				bool flag3 = Q1.a(a.d()) || Q1.a(a.d(), false);
				this.a(a);
				if (flag3)
				{
					this.A(flag2);
				}
				if (flag)
				{
					this.A(a, flag2);
				}
				return true;
			}
			return false;
		}
		private new bool a(D.A a)
		{
			bool flag = false;
			if (!this.A(a.d(), a.G(), flag))
			{
				return false;
			}
			D.A a2 = null;
			if (this.A.a(a, out a2))
			{
				return false;
			}
			this.A(a);
			n1.B();
			return true;
		}
		private new void A(D.A a)
		{
			this.A.Add(a);
			base.J().A(a);
			a.d().d(a);
			a.G().d(a);
		}
		private new bool A(d.a a, d.a a2, bool flag)
		{
			G2 g = global::D.A.d(this.A(), a, a2);
			if (g != G2.None)
			{
				d.a a3 = null;
				if (this.A(a, g, flag, out a3) && a3 == a2)
				{
					return true;
				}
			}
			return false;
		}
		private new bool A(d.a a, G2 g, bool flag, out d.a ptr)
		{
			ptr = null;
			if (!a.V(g, flag))
			{
				return false;
			}
			ptr = this.A().A(a, g);
			if (ptr == null)
			{
				return false;
			}
			if (!ptr.v(g))
			{
				return false;
			}
			foreach (D.A a2 in a.g())
			{
				if (a2.d(this.A()) == g)
				{
					return false;
				}
			}
			return true;
		}
		private new void a(D.A a)
		{
			this.A.Remove(a);
			base.J().b(a);
			n1.B();
			if (!a.d().d(a))
			{
				throw new l1();
			}
			if (!a.G().d(a))
			{
				throw new l1();
			}
		}
		private new bool A(D.A a, bool flag, out Rectangle ptr)
		{
			Rectangle rectangle = new Rectangle(this.A().A(a.d()), new Size(1, 1));
			Rectangle b = new Rectangle(this.A().A(a.G()), new Size(1, 1));
			Rectangle rectangle2 = Rectangle.Union(rectangle, b);
			if (rectangle2.Width > 1 && rectangle2.Height > 1)
			{
				throw new l1();
			}
			if (flag)
			{
				if (rectangle2.Width > 1)
				{
					rectangle2.Width -= 2;
					rectangle2.X++;
				}
				if (rectangle2.Height > 1)
				{
					rectangle2.Height -= 2;
					rectangle2.Y++;
				}
			}
			if ((rectangle2.Width == 1 && rectangle2.Height >= 1) || (rectangle2.Height == 1 && rectangle2.Width >= 1))
			{
				ptr = rectangle2;
				return true;
			}
			ptr = Rectangle.Empty;
			return false;
		}
		private new void A(D.A a, bool flag)
		{
			this.A(a.d(), flag);
			this.A(a.G(), flag);
		}
		private new static void a(D.A a, bool flag)
		{
			d.a a2 = a.d();
			if (!(a2 is global::c.c))
			{
				return;
			}
			if (a2.E1() != 2)
			{
				return;
			}
			D.A a3 = null;
			foreach (D.A a4 in a2.g())
			{
				if (!object.ReferenceEquals(a4, a))
				{
					a3 = a4;
					break;
				}
			}
			if (a3 == null)
			{
				return;
			}
			if (flag)
			{
				D.A a5 = a3;
				a3 = a;
				a = a5;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < Q1.A.GetLength(0); i++)
			{
				dictionary.Add(Q1.A[i, 0], Q1.A[i, 1]);
				dictionary.Add(Q1.A[i, 1], Q1.A[i, 0]);
			}
			string key = (a.c() == null) ? "" : a.c().Trim().ToLower();
			if (dictionary.ContainsKey(key))
			{
				a.D(dictionary[dictionary[key]]);
				a3.D(dictionary[key]);
			}
		}
		private void C(d.a a)
		{
			if (!a.u())
			{
				return;
			}
			D.A[] array = this.A(a, false);
			for (int i = 0; i < array.Length; i++)
			{
				D.A a2 = array[i];
				if (a2 != null)
				{
					this.a(a2);
					D.A a3 = new D.A(a, a2.G());
					this.a(a3);
					a2.G(a);
					this.a(a2);
				}
			}
		}
		private new bool a(d.a a, G2 g, bool flag)
		{
			if (!(a is global::c.B))
			{
				return true;
			}
			if (Q1.a(a, false))
			{
				return true;
			}
			D.A a2 = a.G();
			if (a2 == null || a2.d(this.A()) != g)
			{
				return true;
			}
			Point point = this.A().A(a);
			Point point2 = g2.A(point, g);
			if (!flag && this.A().A(point2.X, point2.Y))
			{
				return true;
			}
			switch (g)
			{
			case G2.East:
			case G2.West:
				if (this.A().A(point.X) > 1)
				{
					return true;
				}
				break;
			case G2.South:
			case G2.North:
				if (this.A().a(point.Y) > 1)
				{
					return true;
				}
				break;
			}
			return false;
		}
		private new D.A[] A(d.a a, bool flag)
		{
			int num;
			int num2;
			if (!this.A().A(a, out num, out num2))
			{
				throw new l1();
			}
			return this.A(num, num2, flag);
		}
		private new D.A[] A(int num, int num2, bool flag)
		{
			List<D.A> list = new List<D.A>();
			bool[] array = new bool[]
			{
				default(bool),
				true
			};
			bool[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				bool flag2 = array2[i];
				d.a[] array3 = this.A().A(num, num2, flag2);
				if (array3 != null)
				{
					D.A a = new D.A(array3[0], array3[1]);
					D.A item;
					if (this.A.a(a, out item))
					{
						list.Add(item);
					}
				}
			}
			return list.ToArray();
		}
		private new D.A A(Point point, G2 g, ref Point ptr)
		{
			int num = 1073741823;
			Rectangle rectangle = g2.A(point, g, num);
			List<Point> list = new List<Point>();
			int num2 = 2147483647;
			D.A result = null;
			foreach (D.A current in (IEnumerable<D.A>)this.A)
			{
				Rectangle b;
				if (g2.A(g, current.d(this.A())) && this.A(current, true, out b))
				{
					Rectangle rectangle2 = Rectangle.Intersect(rectangle, b);
					if (rectangle2.Width == 1 && rectangle2.Height == 1)
					{
						list.Add(rectangle2.Location);
						int num3;
						g2.A(point, rectangle2.Location, out num3);
						if (num3 < num2)
						{
							num2 = num3;
							result = current;
							ptr = rectangle2.Location;
						}
					}
				}
			}
			return result;
		}
		public new void A(e2 e, B1 b)
		{
			this.A(e, b, false);
			this.A(e, b, true);
		}
		public new void A(e2 e, B1 b, bool flag)
		{
			using (Pen pen = new Pen(b.B(), 7f))
			{
				Graphics graphics = b.A();
				foreach (D.A current in (IEnumerable<D.A>)this.A)
				{
					if (graphics.ClipBounds.IntersectsWith(current.E()) && (!b.c() || e.L().A(current)) && flag == (current.d().d() == current.G().d()))
					{
						if (flag && !b.D())
						{
							d.a a = current.d();
							d.a a2 = current.G();
							if (a.G() > a2.G())
							{
								a = current.G();
								a2 = current.d();
							}
							graphics.DrawLine(pen, a.d(), a.E().Bottom, a2.d(), a2.E().Top);
						}
						current.d(b);
					}
				}
			}
		}
		public override void c()
		{
			this.A = j2.A(this);
			this.A = false;
		}
		public override bool D()
		{
			if (this.A != null)
			{
				this.A = j2.A(j2.A(this), this.A);
			}
			return this.A;
		}
		public override void d(DateTime dateTime)
		{
			if (this.D())
			{
				this.a = dateTime;
			}
		}
		public new void A(Z1 z)
		{
		}
		public override void B(XmlWriter xmlWriter, X1 x)
		{
			if (x == null)
			{
				throw new l1();
			}
			xmlWriter.WriteStartElement("DIAGRAM");
			xmlWriter.WriteAttributeString("FORMAT", "1.00");
			xmlWriter.WriteAttributeString("ID", "" + base.A());
			xmlWriter.WriteAttributeString("NAME", base.b());
			xmlWriter.WriteAttributeString("CREATED", this.A.ToString("yyyy.MM.dd HH:mm:ss"));
			xmlWriter.WriteAttributeString("MODIFIED", this.a.ToString("yyyy.MM.dd HH:mm:ss"));
			((l)this.A()).B(xmlWriter, x);
			xmlWriter.WriteStartElement("CONNECTIONS");
			foreach (D.A current in (IEnumerable<D.A>)this.A)
			{
				current.B(xmlWriter, x);
			}
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();
		}
		public override void b(XmlReader xmlReader, w1 w)
		{
			if (w == null)
			{
				throw new l1();
			}
			w.A = base.J();
			bool isEmptyElement = xmlReader.IsEmptyElement;
			if (xmlReader["FORMAT"] != "1.00")
			{
				throw new l1();
			}
			base.a(int.Parse(xmlReader["ID"]));
			base.b(xmlReader["NAME"]);
			if (Z1.c(w.A, new Z1("2.1.0.2")))
			{
				this.A = DateTime.ParseExact(xmlReader["CREATED"], "yyyy.MM.dd HH:mm:ss", null);
				this.a = DateTime.ParseExact(xmlReader["MODIFIED"], "yyyy.MM.dd HH:mm:ss", null);
			}
			else
			{
				if (w.A != null)
				{
					this.A = w.A.CreationTime;
					this.a = w.A.LastWriteTime;
				}
			}
			xmlReader.ReadStartElement("DIAGRAM");
			((l)this.A()).b(xmlReader, w);
			if (!(this.A().A() is global::b.b))
			{
				throw new l1();
			}
			d.a[] array = this.A().A();
			for (int i = 0; i < array.Length; i++)
			{
				d.a a = array[i];
				this.A(a);
				if (a is global::b.A)
				{
					this.A = a;
				}
				if (a is E.A)
				{
					this.a = a;
				}
				n1.B();
			}
			if (xmlReader.Name == "CONNECTIONS")
			{
				bool isEmptyElement2 = xmlReader.IsEmptyElement;
				xmlReader.ReadStartElement("CONNECTIONS");
				if (!isEmptyElement2)
				{
					while (xmlReader.IsStartElement())
					{
						D.A a2 = new D.A(xmlReader, w);
						this.A(a2);
					}
					xmlReader.ReadEndElement();
				}
			}
			if (!isEmptyElement)
			{
				xmlReader.ReadEndElement();
			}
			foreach (D.A current in (IEnumerable<D.A>)this.A)
			{
				global::c.c c = current.d() as global::c.c;
				if (c != null)
				{
					G2 g = current.d(this.A());
					string text = c.A(g);
					if (!string.IsNullOrEmpty(text) && !(text.Trim() == "?"))
					{
						current.D(o1.b(text));
					}
				}
			}
		}
		public new static Q1 A(byte[] array)
		{
			return new Q1(array);
		}
		public override void i(byte[] array)
		{
			Q1 q = Q1.A(array);
			this.A = q.A;
			this.A = q.A;
			this.A = q.A;
			n1.B();
			this.A = q.A;
		}
		static Q1()
		{
			// Note: this type is marked as 'beforefieldinit'.
			string[,] array = new string[4, 2];
			array[0, 0] = "ja";
			array[0, 1] = "nein";
			array[1, 0] = "wahr";
			array[1, 1] = "falsch";
			array[2, 0] = "yes";
			array[2, 1] = "no";
			array[3, 0] = "true";
			array[3, 1] = "false";
			Q1.A = array;
		}
	}
	public class q1
	{
		private static string A = "Die Projektdatei\n'{0}'\nkonnte nicht geladen werden.";
		private static q1 A = null;
		private K1 A = K1.A();
		private Form A;
		private W1<h2> A = new W1<h2>();
		private Dictionary<h2, R1> A = new Dictionary<h2, R1>();
		private Dictionary<h2, string> A = new Dictionary<h2, string>();
		private q1(Form form)
		{
			if (form == null)
			{
				throw new l1();
			}
			this.A = form;
			this.A.B(new W1<h2>.B(this.A));
			this.A.E(new W1<h2>.a(this.A));
		}
		public static q1 A()
		{
			if (q1.A == null)
			{
				throw new l1();
			}
			return q1.A;
		}
		public static q1 A(Form form)
		{
			if (q1.A != null)
			{
				throw new l1();
			}
			q1.A = new q1(form);
			return q1.A;
		}
		public W1<h2> A()
		{
			return this.A;
		}
		public Form A()
		{
			return this.A;
		}
		public void A(h2 h, int num)
		{
			h.E(new h2.A(this.a));
			h.c();
			R1 value = new R1(h);
			this.A.Add(h, value);
			if (h.F() != null)
			{
				this.A.a(h.F());
			}
		}
		public void A(h2 h)
		{
			this.B(h);
			this.A.Remove(h);
			this.A.Remove(h);
		}
		public void a(h2 h)
		{
			h.c();
			this.B(h);
		}
		public h2 A(bool flag, string text)
		{
			h2 result;
			try
			{
				if (!this.A.A().AllowMultipleProjects && !this.A())
				{
					result = null;
				}
				else
				{
					string text2 = this.A.A().PreferredSymbolLanguageEnglish ? "Project" : "Projekt";
					string text3 = this.A.B(text2);
					h2 h = new h2(text3, true);
					if (flag && !this.A(h, text))
					{
						result = null;
					}
					else
					{
						p1 p = h.E();
						h.E(p);
						this.A(h, false);
						result = h;
					}
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
				string text4 = string.Format("Das Projekt konnte nicht angelegt werden", new object[0]);
				MessageBox.Show(this.A, text4, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = null;
			}
			return result;
		}
		public void A()
		{
			if (!this.A.A().AllowMultipleProjects && !this.A())
			{
				return;
			}
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Multiselect = this.A.A().AllowMultipleProjects;
				openFileDialog.Filter = k1.D;
				openFileDialog.FilterIndex = 0;
				openFileDialog.RestoreDirectory = true;
				openFileDialog.InitialDirectory = this.A.A().RecentProjectPath;
				openFileDialog.SupportMultiDottedExtensions = false;
				openFileDialog.FileOk += new CancelEventHandler(this.A);
				DialogResult dialogResult = openFileDialog.ShowDialog(this.A);
				openFileDialog.FileOk -= new CancelEventHandler(this.A);
				if (dialogResult == DialogResult.OK)
				{
					this.A(openFileDialog.FileNames, false, true);
					this.A.A().RecentProjectPath = Path.GetDirectoryName(openFileDialog.FileName);
				}
			}
		}
		private void A(object obj, CancelEventArgs cancelEventArgs)
		{
			OpenFileDialog openFileDialog = (OpenFileDialog)obj;
			cancelEventArgs.Cancel = true;
			string[] fileNames = openFileDialog.FileNames;
			int i = 0;
			while (i < fileNames.Length)
			{
				string text = fileNames[i];
				if (this.A(text))
				{
					if (this.A(text, false))
					{
						i++;
						continue;
					}
				}
				return;
			}
			cancelEventArgs.Cancel = false;
		}
		public void A(string[] array, bool flag, bool flag2)
		{
			b2 b = b2.A();
			try
			{
				b.b();
				List<string> list = new List<string>();
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					if (this.A(text) && this.A(text, flag))
					{
						list.Add(text);
						if (!this.A.A().AllowMultipleProjects)
						{
							break;
						}
					}
				}
				if (list.Count != 0)
				{
					if (flag2 || this.A.A().AllowMultipleProjects || this.A())
					{
						foreach (string current in list)
						{
							try
							{
								this.A(current, flag);
							}
							catch (Exception)
							{
							}
						}
					}
				}
			}
			finally
			{
				b.C();
			}
		}
		public bool A(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (!Path.IsPathRooted(text))
			{
				return false;
			}
			if (!File.Exists(text))
			{
				return false;
			}
			string text2 = Path.GetExtension(text);
			if (string.IsNullOrEmpty(text2))
			{
				return false;
			}
			text2 = text2.ToLower();
			return text2 == ".pap" || text2 == ".pap-backup";
		}
		private void A(string text, bool flag)
		{
			try
			{
				if (!this.A(text))
				{
					throw new l1();
				}
				h2 h = h2.E(text);
				this.A(h, true);
			}
			catch (N1 n)
			{
				n1.A(n);
				if (!flag)
				{
					string text2 = string.Format(q1.A, text);
					text2 += "\n\n";
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"Die Projektdatei wurde mit '",
						j1.a(),
						"' Version '",
						n.A().ToString(),
						"' erstellt.\n"
					});
					string text4 = text2;
					text2 = string.Concat(new string[]
					{
						text4,
						"Sie benutzen gerade '",
						j1.a(),
						"' Version '",
						n.a().ToString(),
						"'.\n"
					});
					string text5 = text2;
					text2 = string.Concat(new string[]
					{
						text5,
						"Zum Öffnen dieser Projektdatei benötigen Sie '",
						j1.a(),
						"' Version '",
						n.A().ToString(),
						"'."
					});
					MessageBox.Show(this.A, text2, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (m1 m)
			{
				n1.A(m);
				if (!flag)
				{
					string text6 = string.Format(q1.A, text);
					text6 += "\n\nDer Inhalt der Projektdatei ist beschädigt.";
					MessageBox.Show(this.A, text6, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
				if (!flag)
				{
					string text7 = string.Format(q1.A, text);
					MessageBox.Show(this.A, text7, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		public bool A(h2 h, string text)
		{
			bool flag = h.F();
			i2 i = new i2(text, h, this.A);
			bool result = i.ShowDialog(this.A) == DialogResult.OK;
			if (flag != h.F())
			{
				b2.A().c(h);
			}
			return result;
		}
		public DialogResult A(h2 h, bool flag)
		{
			h.D();
			if (!h.f() && this.a(h) && !h.f())
			{
				return DialogResult.Cancel;
			}
			if (h == null)
			{
				return DialogResult.None;
			}
			if (!string.IsNullOrEmpty(h.F()) && h.F().EndsWith(".pap-backup"))
			{
				flag = true;
			}
			if (this.A(h) == DialogResult.Cancel)
			{
				return DialogResult.Cancel;
			}
			DialogResult result;
			try
			{
				if (h.F() != null && !flag)
				{
					using (new C())
					{
						h.F();
					}
					result = DialogResult.OK;
				}
				else
				{
					string text = h.F();
					if (string.IsNullOrEmpty(text))
					{
						text = y1.A(h.b(), 64);
					}
					text = y1.A(text, ".pap");
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Filter = k1.d;
						saveFileDialog.FilterIndex = 0;
						saveFileDialog.RestoreDirectory = true;
						saveFileDialog.InitialDirectory = this.A.A().RecentProjectPath;
						saveFileDialog.FileName = text;
						saveFileDialog.Tag = h;
						saveFileDialog.FileOk += new CancelEventHandler(this.a);
						DialogResult dialogResult = saveFileDialog.ShowDialog();
						saveFileDialog.FileOk -= new CancelEventHandler(this.a);
						if (dialogResult == DialogResult.OK)
						{
							using (new C())
							{
								h.F(saveFileDialog.FileName);
							}
							this.A.A().RecentProjectPath = Path.GetDirectoryName(saveFileDialog.FileName);
						}
						result = dialogResult;
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
				string text2 = "Der Schreibzugriff auf die Datei ist nicht zulässig.";
				text2 += "\nÄndern Sie die Dateiberechtigungen oder ";
				text2 += "\nspeichern Sie das Dokument unter einem anderen Namen.";
				MessageBox.Show(this.A, text2, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				result = DialogResult.Cancel;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this.A, ex.Message, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				result = DialogResult.Cancel;
			}
			return result;
		}
		private void a(object obj, CancelEventArgs cancelEventArgs)
		{
			SaveFileDialog saveFileDialog = (SaveFileDialog)obj;
			h2 h = (h2)saveFileDialog.Tag;
			h2 h2 = this.A(saveFileDialog.FileName);
			if (h2 != null && h2 != h)
			{
				string text = "Die ausgewählte Zieldatei '{0}' ist als Projekt '{1}' geöffnet.\n";
				text += "Wählen Sie eine andere Zieldatei!";
				text = string.Format(text, Path.GetFileName(saveFileDialog.FileName), h2.b());
				MessageBox.Show(this.A, text, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cancelEventArgs.Cancel = true;
			}
		}
		public DialogResult A(h2 h)
		{
			bool flag = h.E();
			bool flag2 = string.IsNullOrEmpty(h.E());
			if (flag || flag2)
			{
				string text = "Projekteigenschaften geeignet wählen...";
				if (flag && !flag2)
				{
					text = "Projektname bitte geeignet wählen...";
				}
				if (!flag && flag2)
				{
					text = "Ersteller bitte angeben...";
				}
				if (!this.A(h).A(text))
				{
					return DialogResult.Cancel;
				}
			}
			return DialogResult.OK;
		}
		private void B(h2 h)
		{
			if (h != null)
			{
				R1 r = this.A[h];
				r.A();
			}
		}
		public void b(h2 h)
		{
			if (h != null)
			{
				try
				{
					if (this.A(h))
					{
						this.A.c(h);
					}
				}
				catch (InvalidOperationException)
				{
				}
			}
		}
		public h2 A(p1 p)
		{
			foreach (h2 current in this.A)
			{
				if (current.E().B(p))
				{
					return current;
				}
			}
			return null;
		}
		private h2 A(string text)
		{
			foreach (h2 current in this.A)
			{
				if (text != null && y1.A(current.F(), text))
				{
					return current;
				}
			}
			return null;
		}
		private bool A(h2 h, bool flag)
		{
			if (!this.A.A().AllowMultipleProjects && !h.e())
			{
				h2[] array = this.A.B();
				for (int i = 0; i < array.Length; i++)
				{
					h2 h2 = array[i];
					if (!h2.e())
					{
						this.A.c(h2);
					}
				}
			}
			if (h.F() != null && !this.A(h.F(), false))
			{
				return false;
			}
			string text = this.A.b(h.b());
			if (text != h.b())
			{
				if (!flag)
				{
					string text2 = "Es ist bereits ein Projekt mit dem Namen '{0}' geöffnet\n";
					text2 += "Soll das zu ladende Projekt unter dem neuen Namen '{1}' geöffnet werden?";
					text2 = string.Format(text2, h.b(), text);
					DialogResult dialogResult = MessageBox.Show(this.A, text2, j1.a(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Cancel)
					{
						return false;
					}
				}
				h.b(text);
			}
			this.A.b(h);
			return true;
		}
		private bool A(string text, bool flag)
		{
			h2 h = this.A(text);
			if (h == null)
			{
				return true;
			}
			if (!flag)
			{
				string text2 = "Die ausgewählte Projektdatei '{0}' ist bereits als Projekt '{1}' geladen.\n";
				text2 += "Schliessen Sie das Projekt '{1}' zuerst, oder speichern Sie es unter einem anderen Namen!";
				text2 = string.Format(text2, Path.GetFileName(text), h.b());
				MessageBox.Show(this.A, text2, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return false;
		}
		public bool A()
		{
			foreach (h2 current in this.A)
			{
				if (!this.A(current))
				{
					return false;
				}
			}
			return true;
		}
		private bool A(h2 h)
		{
			if (h != null && h.g())
			{
				string text = "Geändertes Projekt '" + h.b() + "' speichern?";
				DialogResult dialogResult = MessageBox.Show(this.A, text, j1.a(), MessageBoxButtons.YesNoCancel);
				if (dialogResult == DialogResult.Yes)
				{
					dialogResult = this.A(h, false);
				}
				if (dialogResult == DialogResult.Cancel)
				{
					return false;
				}
			}
			return true;
		}
		public bool A(bool flag, bool flag2)
		{
			if (flag && !this.A())
			{
				return false;
			}
			b2 b = b2.A();
			try
			{
				b.b();
				h2[] array = this.A().B();
				this.A().B();
				if (flag2)
				{
					this.A.a();
					h2[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						h2 h = array2[i];
						if (h.F() != null)
						{
							this.A.B(h.F());
						}
					}
				}
			}
			finally
			{
				b.C();
			}
			return true;
		}
		public bool a(h2 h, bool flag)
		{
			if (h == null)
			{
				return false;
			}
			if (h.F() == null)
			{
				return false;
			}
			if (!File.Exists(h.F()))
			{
				return false;
			}
			if ((File.GetAttributes(h.F()) & FileAttributes.ReadOnly) != (FileAttributes)0)
			{
				return false;
			}
			if (flag)
			{
				return true;
			}
			string text = "Projekt '" + h.b() + "' und Projektdatei unwiderruflich löschen?";
			DialogResult dialogResult = MessageBox.Show(this.A, text, j1.a(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult == DialogResult.Yes)
			{
				this.A.c(h);
				if (h.F() != null)
				{
					try
					{
						File.Delete(h.F());
						return true;
					}
					catch (UnauthorizedAccessException)
					{
						text = "Projektdatei '" + h.F() + "' ist löschgeschützt";
						MessageBox.Show(this.A, text, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					catch (Exception)
					{
						text = "Projektdatei '" + h.F() + "' konnte nicht gelöscht werden";
						MessageBox.Show(this.A, text, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					return false;
				}
			}
			return false;
		}
		public R1 A(h2 key)
		{
			return this.A[key];
		}
		public bool a(string text, bool flag)
		{
			foreach (string current in this.A.Values)
			{
				if (current == text)
				{
					bool result = false;
					return result;
				}
			}
			if (!flag)
			{
				b2 b = b2.A();
				try
				{
					b.b();
					h2 h = null;
					try
					{
						byte[] array = Y.A().A(text);
						h = new C1(array).A();
						h.e();
					}
					catch (Exception)
					{
						MessageBox.Show("Tutorial konnte nicht geladen werden", "Systemfehler", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						bool result = false;
						return result;
					}
					if (!K1.A().A().AllowMultipleTutorials)
					{
						List<h2> list = new List<h2>();
						foreach (h2 current2 in this.A.Keys)
						{
							list.Add(current2);
						}
						foreach (h2 current3 in list)
						{
							this.A.c(current3);
						}
					}
					if (!this.A().B(h))
					{
						if (!this.A(h, false))
						{
							bool result = false;
							return result;
						}
						this.A[h] = text;
					}
					if (h != b2.A().A())
					{
						b2.A().C(h);
					}
				}
				finally
				{
					b.C();
				}
			}
			return true;
		}
		public bool a(h2 h)
		{
			if (h.F())
			{
				MessageBox.Show("Das Projekt ist vom Ersteller mit einem Dokumentenschutz versehen.", j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return true;
			}
			return false;
		}
	}
}
