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
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
namespace a
{
	public class H2 : l, ICollection, IEnumerable
	{
		public const string A = "CLIPSET";
		public const string a = "1.00";
		private static int A;
		private int a = H2.A++;
		private F2 A;
		private bool A;
		private bool a;
		private global::b.A A;
		private E.A A;
		private global::C.b[] A = new global::C.b[0];
		private global::b.c[] A = new global::b.c[0];
		private h<d.a> A = new h<d.a>();
		private h<D.A> A = new h<D.A>();
		public H2(d.a a)
		{
			this.A = new F2();
			this.A.h(1);
			this.A.I(1);
			this.A.A(a, 0, 0);
			this.A.A(a);
			this.a(a);
		}
		public H2(F2 f, Rectangle rectangle, bool flag)
		{
			if (flag && !f.A(rectangle, out rectangle))
			{
				return;
			}
			this.a = true;
			this.A = new F2();
			int num = 2147483647;
			int num2 = -2147483648;
			int num3 = 2147483647;
			int num4 = -2147483648;
			for (int i = 0; i < rectangle.Height; i++)
			{
				for (int j = 0; j < rectangle.Width; j++)
				{
					d.a a = f.A(j + rectangle.X, i + rectangle.Y);
					if (a != null && !(a is global::b.b))
					{
						if (j < num)
						{
							num = j;
						}
						if (j > num2)
						{
							num2 = j;
						}
						if (i < num3)
						{
							num3 = i;
						}
						if (i > num4)
						{
							num4 = i;
						}
					}
				}
			}
			if (num == 2147483647)
			{
				return;
			}
			List<global::C.b> list = new List<global::C.b>();
			List<global::b.c> list2 = new List<global::b.c>();
			Rectangle rectangle2 = new Rectangle(num, num3, num2 - num + 1, num4 - num3 + 1);
			this.A.A();
			this.A.h(rectangle2.Width);
			this.A.I(rectangle2.Height);
			bool flag2 = false;
			for (int k = 0; k < rectangle2.Height; k++)
			{
				for (int l = 0; l < rectangle2.Width; l++)
				{
					d.a a2 = f.A(l + rectangle.X + num, k + rectangle.Y + num3);
					if (a2 != null && !(a2 is global::b.b))
					{
						this.A.A(a2, l, k);
						if (!flag2)
						{
							this.A.A(a2);
						}
						this.A(a2, list, list2);
					}
				}
			}
			this.A = list.ToArray();
			this.A = list2.ToArray();
			if (this.A.get_Count() > 0)
			{
				foreach (d.a current in (IEnumerable<d.a>)this.A)
				{
					foreach (D.A a3 in current.d())
					{
						if (!this.A.Contains(a3) && this.A.Contains(a3.d(current)))
						{
							this.A.Add(a3);
						}
					}
				}
			}
		}
		public H2 A()
		{
			byte[] array = this.A();
			return new H2(array);
		}
		private H2(byte[] array)
		{
			this.A = true;
			j2.A(this, array);
		}
		public int get_Count()
		{
			return this.A.get_Count() + this.A.get_Count();
		}
		public bool A()
		{
			return false;
		}
		public bool A(global::c.a a)
		{
			if (a is D.A)
			{
				return this.A.Contains(a as D.A);
			}
			if (a is d.a)
			{
				return this.A.Contains(a as d.a);
			}
			if (a != null)
			{
				throw new l1();
			}
			return false;
		}
		public void A(global::c.a a)
		{
			throw new InvalidOperationException();
		}
		public void A()
		{
			throw new InvalidOperationException();
		}
		public void A(global::c.a[] array, int num)
		{
			throw new NotImplementedException();
		}
		public bool a(global::c.a a)
		{
			throw new InvalidOperationException();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new G<global::c.a>(new ICollection[]
			{
				this.A,
				this.A
			});
		}
		public bool get_IsSynchronized()
		{
			return false;
		}
		public object get_SyncRoot()
		{
			return null;
		}
		public void CopyTo(Array array, int num)
		{
			throw new NotImplementedException();
		}
		public int A()
		{
			return this.a;
		}
		public bool a()
		{
			return this.get_Count() == 0;
		}
		public int a()
		{
			return this.A.get_Count();
		}
		public int c()
		{
			return this.A.get_Count();
		}
		public Rectangle A()
		{
			Rectangle result = Rectangle.Empty;
			foreach (d.a current in (IEnumerable<d.a>)this.A)
			{
				if (result.IsEmpty)
				{
					result = current.E();
				}
				else
				{
					result = Rectangle.Union(result, current.E());
				}
			}
			foreach (D.A current2 in (IEnumerable<D.A>)this.A)
			{
				if (result.IsEmpty)
				{
					result = current2.E();
				}
				else
				{
					result = Rectangle.Union(result, current2.E());
				}
			}
			return result;
		}
		public Size A()
		{
			return new Size(this.A().h(), this.A().I());
		}
		public IEnumerable<d.a> A()
		{
			return this.A;
		}
		public IEnumerable<D.A> A()
		{
			return this.A;
		}
		public d.a A()
		{
			return this.A.A();
		}
		public void A(d.a a)
		{
			if (!this.A.Contains(a))
			{
				throw new l1();
			}
			this.A.A(a);
		}
		public F2 A()
		{
			return this.A;
		}
		public bool c()
		{
			return this.A;
		}
		public bool D()
		{
			return this.a;
		}
		public global::b.A A()
		{
			return this.A;
		}
		public E.A A()
		{
			return this.A;
		}
		public global::C.b[] A()
		{
			return this.A;
		}
		public global::b.c[] A()
		{
			return this.A;
		}
		public void a()
		{
			foreach (global::c.a current in (IEnumerable<d.a>)this.A)
			{
				current.a(-1);
			}
			foreach (global::c.a current2 in (IEnumerable<D.A>)this.A)
			{
				current2.a(-1);
			}
		}
		public byte[] A()
		{
			byte[] array = j2.A(this);
			if (array == null)
			{
				throw new l1();
			}
			return array;
		}
		public void c()
		{
			string text = string.Format("CountFigures={0};CountConnections={1}", this.a(), this.c());
			m.A().A(base.GetType(), "Clip", text, this.A());
		}
		public static bool A(m m, out int ptr)
		{
			if (!m.a(typeof(H2)))
			{
				ptr = 0;
				return false;
			}
			ptr = -1;
			string[] array = m.a().Split(new char[]
			{
				';'
			});
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				string[] array3 = text.Split(new char[]
				{
					'='
				});
				if (array3[0] == "CountFigures")
				{
					ptr = int.Parse(array3[1]);
					break;
				}
			}
			if (ptr == -1)
			{
				throw new l1();
			}
			return true;
		}
		public static H2 a()
		{
			m m = m.A();
			if (!m.a(typeof(H2)))
			{
				return null;
			}
			if (m.A() != typeof(H2))
			{
				throw new l1();
			}
			if (m.A() != "Clip")
			{
				throw new l1();
			}
			m.a();
			byte[] array = m.A();
			m.A();
			return new H2(array);
		}
		public IDictionary<D.A, bool> A()
		{
			Dictionary<D.A, bool> dictionary = new Dictionary<D.A, bool>();
			foreach (d.a current in this.A())
			{
				foreach (D.A a in current.G())
				{
					if (!this.A(a))
					{
						dictionary.Add(a, false);
					}
				}
				foreach (D.A a2 in current.g())
				{
					if (!this.A(a2))
					{
						dictionary.Add(a2, true);
					}
				}
			}
			return dictionary;
		}
		private void a(d.a a)
		{
			List<global::C.b> list = new List<global::C.b>();
			List<global::b.c> list2 = new List<global::b.c>();
			this.A(a, list, list2);
			this.A = list.ToArray();
			this.A = list2.ToArray();
		}
		private void A(d.a a, List<global::C.b> list, List<global::b.c> list2)
		{
			this.A.Add(a);
			if (a is global::b.a)
			{
				if (a is global::b.A)
				{
					this.A = (a as global::b.A);
				}
				if (a is E.A)
				{
					this.A = (a as E.A);
					return;
				}
			}
			else
			{
				if (a is global::C.C)
				{
					if (a is global::C.b && list != null)
					{
						list.Add(a as global::C.b);
					}
					if (a is global::b.c && list2 != null)
					{
						list2.Add(a as global::b.c);
					}
				}
			}
		}
		public virtual void B(XmlWriter xmlWriter, X1 x)
		{
			if (x == null)
			{
				throw new l1();
			}
			if (this.c())
			{
				throw new l1();
			}
			if (this.A == null || this.A.get_Count() == 0)
			{
				throw new l1();
			}
			xmlWriter.WriteStartElement("CLIPSET");
			xmlWriter.WriteAttributeString("FORMAT", "1.00");
			xmlWriter.WriteAttributeString("ID", "" + this.A());
			this.A.B(xmlWriter, x);
			xmlWriter.WriteStartElement("CONNECTIONS");
			foreach (D.A current in (IEnumerable<D.A>)this.A)
			{
				current.B(xmlWriter, x);
			}
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();
		}
		public virtual void b(XmlReader xmlReader, w1 w)
		{
			if (this.A != null)
			{
				throw new l1();
			}
			this.A = new F2();
			if (w == null)
			{
				throw new l1();
			}
			w.A = new D1<global::c.a>();
			bool isEmptyElement = xmlReader.IsEmptyElement;
			if (xmlReader["FORMAT"] != "1.00")
			{
				throw new l1();
			}
			this.a = int.Parse(xmlReader["ID"]);
			xmlReader.ReadStartElement("CLIPSET");
			this.A.b(xmlReader, w);
			List<global::C.b> list = new List<global::C.b>();
			List<global::b.c> list2 = new List<global::b.c>();
			d.a[] array = this.A.A();
			for (int i = 0; i < array.Length; i++)
			{
				d.a a = array[i];
				this.A(a, list, list2);
				w.A.A(a);
			}
			this.A = list.ToArray();
			this.A = list2.ToArray();
			if (xmlReader.Name == "CONNECTIONS")
			{
				bool isEmptyElement2 = xmlReader.IsEmptyElement;
				xmlReader.ReadStartElement("CONNECTIONS");
				if (!isEmptyElement2)
				{
					while (xmlReader.IsStartElement())
					{
						D.A a2 = new D.A(xmlReader, w);
						this.A.Add(a2);
					}
					xmlReader.ReadEndElement();
				}
			}
			if (!isEmptyElement)
			{
				xmlReader.ReadEndElement();
			}
			this.C(w);
			this.A(this.A.A());
		}
		public virtual void C(w1 w)
		{
			foreach (global::c.a current in (IEnumerable<d.a>)this.A)
			{
				current.C(w);
			}
			foreach (global::c.a current2 in (IEnumerable<D.A>)this.A)
			{
				current2.C(w);
			}
		}
	}
	public class h2 : P1<h2>, L, l, N
	{
		public new delegate void A(h2);
		public new delegate void a(h2, string);
		public new delegate void B(h2, p1);
		public new delegate void b(h2, p1);
		public new const string A = "PROJECT";
		public new const string a = "1.00";
		private new int A = -1;
		private new DateTime A;
		private new DateTime a;
		private new string B;
		private new string b;
		private string C = "";
		private new bool A;
		private new V A;
		private new bool a;
		private new D1<p1> A = new D1<p1>();
		private new W1<p1> A = new W1<p1>();
		private new byte[] A;
		private new bool B;
		private new h2.A A;
		private new h2.a A;
		public h2(string text, bool flag) : base(text)
		{
			this.E();
			if (flag)
			{
				this.B = text;
			}
		}
		public h2(XmlReader xmlReader, w1 w)
		{
			this.E();
			this.b(xmlReader, w);
		}
		public h2(byte[] array, bool flag)
		{
			this.E();
			j2.A(this, array);
		}
		private void E()
		{
			DateTime now = DateTime.Now;
			this.A = now;
			this.a = now;
			this.A.B(new W1<p1>.B(this.e));
			this.A.E(new W1<p1>.a(this.F));
		}
		public new int A()
		{
			return this.A;
		}
		public new void a(int num)
		{
			this.A = num;
		}
		public string E()
		{
			return this.C;
		}
		public void E(string c)
		{
			this.C = c;
			n1.B();
		}
		public bool E()
		{
			return this.B != null && this.B == base.b();
		}
		public string e()
		{
			return this.B;
		}
		public string F()
		{
			return this.b;
		}
		private void e(string text)
		{
			if (this.b == text)
			{
				return;
			}
			if (string.IsNullOrEmpty(text) || text.Trim() != text)
			{
				throw new ArgumentException("Invalid file name");
			}
			string text2 = this.b;
			this.b = text;
			if (this.A != null)
			{
				this.A(this, text2);
			}
		}
		public string f()
		{
			if (!string.IsNullOrEmpty(this.F()))
			{
				return Path.GetFileName(this.F());
			}
			return "";
		}
		public DateTime E()
		{
			return this.A;
		}
		public DateTime e()
		{
			return this.a;
		}
		public bool e()
		{
			return this.A;
		}
		public void e()
		{
			this.A = true;
			this.E(new V("tutorial"));
		}
		public V E()
		{
			return this.A;
		}
		public bool F()
		{
			return V.B(this.E(), null);
		}
		public bool f()
		{
			return this.a;
		}
		public bool G()
		{
			using (IEnumerator<p1> enumerator = this.E().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					p1 current = enumerator.Current;
					return current.E();
				}
			}
			return K1.A().A().PreferredSymbolLanguageEnglish;
		}
		public void E(bool flag)
		{
			this.a = flag;
		}
		public void E(V v)
		{
			this.A = v;
			foreach (p1 current in this.A)
			{
				current.h(this.F());
			}
		}
		public c1<p1> E()
		{
			return this.A;
		}
		public W1<p1> E()
		{
			return this.A;
		}
		public int E()
		{
			return this.A.B();
		}
		public p1 E()
		{
			bool flag = this.G();
			string text = flag ? "Main flow" : "Hauptprogramm";
			if (this.A.B() > 0)
			{
				flag = this.G();
				text = (flag ? "Subflow" : "Unterprogramm");
			}
			return new Q1(this.A.B(text), flag);
		}
		public int E(p1 p)
		{
			return this.A.B(p);
		}
		public void E(p1 p)
		{
			this.E(p, this.A.B());
		}
		public void E(p1 p, int num)
		{
			this.A.B(p, num);
			n1.B();
		}
		public void e(p1 p)
		{
			this.A.c(p);
			n1.B();
		}
		public bool E(p1 p, int num)
		{
			if (num < 0)
			{
				return false;
			}
			if (num > this.E())
			{
				return false;
			}
			int num2 = this.E(p);
			if (num2 == num)
			{
				return false;
			}
			if (num2 + 1 == num)
			{
				return false;
			}
			this.e(p);
			if (num2 < num)
			{
				num--;
			}
			this.E(p, num);
			return true;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void E(h2.A a)
		{
			this.A = (h2.A)Delegate.Combine(this.A, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void e(h2.A value)
		{
			this.A = (h2.A)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void E(h2.a a)
		{
			this.A = (h2.a)Delegate.Combine(this.A, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void e(h2.a value)
		{
			this.A = (h2.a)Delegate.Remove(this.A, value);
		}
		private void e(p1 p, int num)
		{
			p.B(new P1<p1>.a(this.E));
			this.A.A(p);
			p.h(this.F());
		}
		private void F(p1 p)
		{
			p.b(new P1<p1>.a(this.E));
			this.A.b(p);
		}
		private void E(p1 p, string text)
		{
			foreach (p1 current in this.A)
			{
				Q1 q = current as Q1;
				if (q != null)
				{
					q.A(text, p.b());
				}
			}
		}
		public void F()
		{
			if (this.F() == null)
			{
				throw new l1();
			}
			this.F(this.F());
		}
		public void F(string text)
		{
			C1 c = new C1(this);
			DateTime now = DateTime.Now;
			this.d(now);
			j2.a(c, text);
			this.e(text);
			if (this.A != null)
			{
				this.A(this);
			}
		}
		public static h2 E(string text)
		{
			C1 c = new C1();
			j2.A(c, text);
			h2 h = c.A();
			h.e(text);
			return h;
		}
		public void c()
		{
			this.A = j2.A(this);
			this.B = false;
			foreach (p1 current in this.A)
			{
				current.c();
			}
		}
		public bool D()
		{
			if (this.A != null)
			{
				this.B = j2.A(j2.A(this), this.A);
			}
			foreach (p1 current in this.A)
			{
				if (this.B)
				{
					break;
				}
				if (current.D())
				{
					this.B = true;
				}
			}
			return this.B;
		}
		public void d(DateTime dateTime)
		{
			if (this.D())
			{
				this.a = dateTime;
			}
			foreach (p1 current in this.A)
			{
				current.d(dateTime);
			}
		}
		public bool g()
		{
			return (!this.F() || this.f()) && this.D();
		}
		public virtual void B(XmlWriter xmlWriter, X1 x)
		{
			if (x == null)
			{
				throw new l1();
			}
			xmlWriter.WriteStartElement("PROJECT");
			xmlWriter.WriteAttributeString("FORMAT", "1.00");
			xmlWriter.WriteAttributeString("NAME", base.b());
			xmlWriter.WriteAttributeString("AUTHOR", this.E());
			xmlWriter.WriteAttributeString("CREATED", this.A.ToString("yyyy.MM.dd HH:mm:ss"));
			xmlWriter.WriteAttributeString("MODIFIED", this.a.ToString("yyyy.MM.dd HH:mm:ss"));
			if (this.F())
			{
				xmlWriter.WriteAttributeString("PROTECTION", "" + this.E().ToString());
			}
			xmlWriter.WriteStartElement("DIAGRAMS");
			foreach (p1 current in this.A)
			{
				current.B(xmlWriter, x);
			}
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();
		}
		public virtual void b(XmlReader xmlReader, w1 w)
		{
			if (w == null)
			{
				throw new l1();
			}
			w.A = this.A;
			bool isEmptyElement = xmlReader.IsEmptyElement;
			if (xmlReader["FORMAT"] != "1.00")
			{
				throw new M1();
			}
			base.b("" + xmlReader["NAME"]);
			this.E("" + xmlReader["AUTHOR"]);
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
			if (xmlReader["PROTECTION"] != null)
			{
				this.A = V.a(xmlReader["PROTECTION"]);
			}
			xmlReader.ReadStartElement("PROJECT");
			bool isEmptyElement2 = xmlReader.IsEmptyElement;
			xmlReader.ReadStartElement("DIAGRAMS");
			if (!isEmptyElement2)
			{
				while (xmlReader.IsStartElement())
				{
					p1 p = new Q1(xmlReader, w);
					this.E(p);
				}
				xmlReader.ReadEndElement();
			}
			if (!isEmptyElement)
			{
				xmlReader.ReadEndElement();
			}
			this.C(w);
		}
		public virtual void C(w1 w)
		{
			w.A = this.A;
			foreach (p1 current in this.A.C())
			{
				current.C(w);
			}
		}
	}
}
