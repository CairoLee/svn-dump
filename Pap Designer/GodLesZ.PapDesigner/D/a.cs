using a;
using b;
using c;
using C;
using d;
using D;
using E;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Xml;
namespace D
{
	public abstract class a
	{
		protected class A
		{
			public string A;
			public float A;
			public bool A;
			public bool a;
			public A(string text, float num, bool flag, bool flag2)
			{
				this.A = text;
				this.A = num;
				this.A = flag;
				this.a = flag2;
			}
		}
		protected class a
		{
			public Graphics A;
			public Font A;
			public SizeF A;
			public float A;
			public float a;
			public a(Graphics graphics, Font font)
			{
				this.A = graphics;
				this.A = font;
			}
		}
		public const char A = '\0';
		public const char a = ' ';
		public const char B = '\t';
		public const char b = '\n';
		public const char C = '\r';
		public const char c = '-';
		public const char D = '~';
		public const char d = '~';
		public const int A = 25;
		public virtual Size A(Graphics graphics, Font font, string text, out string ptr)
		{
			D.a.a a = this.a(graphics, font);
			float num;
			IList<D.a.A> list = this.B(a, text, out num);
			return this.b(a, list, num, out ptr);
		}
		protected virtual D.a.a a(Graphics graphics, Font font)
		{
			D.a.a a = new D.a.a(graphics, font);
			SizeF sizeF = graphics.MeasureString("Wi", font);
			SizeF sizeF2 = graphics.MeasureString("WiWi", font);
			SizeF sizeF3 = graphics.MeasureString("Wi Wi", font);
			SizeF sizeF4 = graphics.MeasureString("Wi-Wi", font);
			SizeF sizeF5 = graphics.MeasureString("Wi\nWi", font);
			a.A = new SizeF(sizeF3.Width - sizeF2.Width, sizeF5.Height - sizeF.Height);
			float num = sizeF2.Width - sizeF.Width;
			a.a = sizeF.Width - num;
			a.A = sizeF4.Width - sizeF2.Width;
			return a;
		}
		protected virtual IList<D.a.A> B(D.a.a a, string text, out float ptr)
		{
			ptr = 0f;
			List<D.a.A> list = new List<D.a.A>();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			bool flag2 = false;
			int num = 0;
			while (num < text.Length || stringBuilder.Length > 0)
			{
				if (num < text.Length)
				{
					char c = text[num];
					char c2 = c;
					switch (c2)
					{
					case '\t':
						goto IL_5B;
					case '\n':
						goto IL_EE;
					case '\v':
					case '\f':
						break;
					case '\r':
						flag2 = true;
						goto IL_82;
					default:
						if (c2 == ' ')
						{
							goto IL_5B;
						}
						break;
					}
					if (c == '~')
					{
						goto IL_82;
					}
					stringBuilder.Append(c);
					if (c == '-' || stringBuilder.Length >= 25)
					{
						goto IL_82;
					}
					goto IL_EE;
					IL_5B:
					flag = true;
					goto IL_82;
				}
				goto IL_82;
				IL_EE:
				num++;
				continue;
				IL_82:
				if (stringBuilder.Length >= 0)
				{
					string text2 = stringBuilder.ToString();
					float num2 = a.A.MeasureString(text2, a.A).Width - a.a;
					list.Add(new D.a.A(text2, num2, flag, flag2));
					ptr += num2;
					if (flag)
					{
						ptr += a.A.Width;
					}
					stringBuilder.Length = 0;
					flag = false;
					flag2 = false;
					goto IL_EE;
				}
				goto IL_EE;
			}
			return list.ToArray();
		}
		protected abstract Size b(D.a.a, IList<D.a.A>, float, out string);
	}
	public class A : global::C.B, l
	{
		private new const int A = 5;
		public new const string A = "CONNECTION";
		public new const string a = "1.00";
		private new int a = -1;
		private new d.a A;
		private new d.a a;
		private new ulong A;
		private new Rectangle A = Rectangle.Empty;
		private new Point A;
		private new Point a;
		private new Rectangle a;
		private new string B;
		public override int A()
		{
			return this.a;
		}
		public override void a(int num)
		{
			this.a = num;
		}
		public override string c()
		{
			return this.B;
		}
		public override void D(string b)
		{
			this.B = b;
			n1.B();
		}
		public new d.a d()
		{
			return this.A;
		}
		public new void d(d.a a)
		{
			this.d(a, this.a);
		}
		public d.a G()
		{
			return this.a;
		}
		public void G(d.a a)
		{
			this.d(this.A, a);
		}
		public new Rectangle d()
		{
			return this.A;
		}
		public new G2 d()
		{
			int num = 0;
			if (Math.Abs(this.G().G() - this.d().G()) <= num)
			{
				if (this.G().d() > this.d().d())
				{
					return G2.East;
				}
				if (this.G().d() < this.d().d())
				{
					return G2.West;
				}
			}
			if (Math.Abs(this.G().d() - this.d().d()) <= num)
			{
				if (this.G().G() > this.d().G())
				{
					return G2.South;
				}
				if (this.G().G() < this.d().G())
				{
					return G2.North;
				}
			}
			return G2.None;
		}
		public A(d.a a, d.a a2)
		{
			this.d(a, a2);
		}
		public A(XmlReader xmlReader, w1 w)
		{
			this.b(xmlReader, w);
		}
		private new void d(d.a a, d.a a2)
		{
			if (a == null)
			{
				throw new l1();
			}
			if (a2 == null)
			{
				throw new l1();
			}
			if (a == a2)
			{
				throw new l1();
			}
			this.A = a;
			this.a = a2;
			uint hashCode = (uint)a.GetHashCode();
			uint hashCode2 = (uint)a2.GetHashCode();
			this.A = (ulong)Math.Max(hashCode, hashCode2);
			this.A <<= 32;
			this.A += (ulong)Math.Min(hashCode, hashCode2);
		}
		public void G(d.a a, d.a a2)
		{
			this.d(a, a2);
		}
		public new d.a d(d.a a)
		{
			if (a == this.d())
			{
				return this.G();
			}
			if (a == this.G())
			{
				return this.d();
			}
			throw new l1();
		}
		public new bool d(F2 f)
		{
			G2 g = this.d(f, false);
			return g != G2.None && f.A(this.d(), g) == this.G();
		}
		public new G2 d(F2 f)
		{
			return this.d(f, true);
		}
		public new G2 d(F2 f, bool flag)
		{
			G2 g = global::D.A.d(f, this.d(), this.G());
			if (flag && !g2.A(g))
			{
				throw new l1();
			}
			return g;
		}
		public new static G2 d(F2 f, d.a a, d.a a2)
		{
			Point point = f.A(a);
			Point point2 = f.A(a2);
			int num;
			return g2.A(point, point2, out num);
		}
		public new int d()
		{
			Point point = this.d().d();
			Point point2 = this.G().d();
			Rectangle rectangle = this.d().M();
			Rectangle rectangle2 = this.G().M();
			int num = Math.Max(0, Math.Abs(point2.X - point.X) - (rectangle.Width + rectangle2.Width) / 2);
			int num2 = Math.Max(0, Math.Abs(point2.Y - point.Y) - (rectangle.Height + rectangle2.Height) / 2);
			return num + num2;
		}
		public override int GetHashCode()
		{
			return this.A.GetHashCode();
		}
		public override bool Equals(object obj)
		{
			return obj is D.A && this.H((D.A)obj);
		}
		public virtual bool H(D.A a)
		{
			if (this.A == a.A)
			{
				if (this.A == a.A && this.a == a.a)
				{
					return true;
				}
				if (this.A == a.a && this.a == a.A)
				{
					return true;
				}
			}
			return false;
		}
		public override Pen F()
		{
			return global::c.C.D;
		}
		public override Brush f()
		{
			return global::c.C.A;
		}
		public override Rectangle E()
		{
			Rectangle result = this.G();
			int num = global::c.C.C.Width / 2;
			result.Inflate(num, num);
			if (this.d().Width != 0)
			{
				result = Rectangle.Union(result, this.d());
			}
			return result;
		}
		public override bool e(Point pt)
		{
			return this.G().Contains(pt) || this.A.Contains(pt);
		}
		public virtual bool h(Point pt)
		{
			return this.A.Contains(pt);
		}
		private Rectangle G()
		{
			Point left = this.d().d();
			Point left2 = this.G().d();
			if (left != this.A || left2 != this.a)
			{
				Rectangle rectangle = new Rectangle(left.X, left.Y, 0, 0);
				Rectangle b = new Rectangle(left2.X, left2.Y, 0, 0);
				this.a = Rectangle.Union(rectangle, b);
				int num = 7;
				this.a.Inflate(num, num);
				this.A = left;
				this.a = left2;
			}
			return this.a;
		}
		public new void d(B1 b)
		{
			Graphics graphics = b.A();
			Pen pen = this.G(b);
			Brush brush = this.g(b);
			Point pt = this.d().d();
			Point pt2 = this.G().d();
			pen.LineJoin = LineJoin.Round;
			pen.EndCap = LineCap.Square;
			graphics.DrawLine(pen, pt, pt2);
			if (string.IsNullOrEmpty(this.c()))
			{
				this.A = Rectangle.Empty;
			}
			else
			{
				this.d(graphics, brush);
			}
			if (!(this.G() is global::c.B) || !this.G().d())
			{
				this.G(graphics, brush);
			}
		}
		public new Rectangle d(Graphics graphics, G2 g)
		{
			this.d(graphics, null, g);
			return this.A;
		}
		private new void d(Graphics graphics, Brush brush)
		{
			this.d(graphics, brush, this.d());
		}
		private new void d(Graphics graphics, Brush brush, G2 g)
		{
			Rectangle rectangle = this.d().L();
			if (this.d() is global::c.B)
			{
				rectangle = new Rectangle(this.d().d(), new Size(0, 0));
			}
			Point point = new Point(0, 0);
			int num = global::c.C.A.Width / 50;
			int num2 = global::c.C.A.Width / 40;
			using (StringFormat stringFormat = new StringFormat())
			{
				switch (g)
				{
				case G2.East:
					point = new Point(rectangle.Right + num, this.d().G() + num2);
					break;
				case G2.South:
					point = new Point(this.d().d() + num, rectangle.Bottom + num2);
					break;
				case G2.West:
					stringFormat.Alignment = StringAlignment.Far;
					point = new Point(rectangle.Left - num, this.d().G() + num2);
					break;
				case G2.North:
					stringFormat.LineAlignment = StringAlignment.Far;
					point = new Point(this.d().d() + num, rectangle.Top - num2);
					break;
				default:
					return;
				}
				string text = this.c();
				Font font = global::c.C.a();
				if (brush != null)
				{
					graphics.DrawString(text, font, brush, point, stringFormat);
				}
				SizeF sizeF = graphics.MeasureString(text, font, new Point(0, 0), stringFormat);
				Rectangle rectangle2 = new Rectangle(point, sizeF.ToSize());
				switch (g)
				{
				case G2.West:
					rectangle2.X -= rectangle2.Width;
					break;
				case G2.North:
					rectangle2.Y -= rectangle2.Height;
					break;
				}
				this.A = rectangle2;
				stringFormat.Dispose();
			}
		}
		private void G(Graphics graphics, Brush brush)
		{
			Point point = this.d().d();
			Point point2 = this.G().d();
			if (point2.X != point.X && point2.Y != point.Y)
			{
				return;
			}
			Point point3 = new Point((point.X + point2.X) / 2, (point.Y + point2.Y) / 2);
			Point point4 = point3;
			Point point5 = point3;
			int num = 5;
			if (point2.X > point.X)
			{
				point3.X = this.G().M().Left;
				point4 = new Point(point3.X - num * 2, point3.Y + num);
				point5 = new Point(point3.X - num * 2, point3.Y - num);
			}
			else
			{
				if (point2.X < point.X)
				{
					point3.X = this.G().M().Right;
					point4 = new Point(point3.X + num * 2, point3.Y + num);
					point5 = new Point(point3.X + num * 2, point3.Y - num);
				}
			}
			if (point2.Y > point.Y)
			{
				point3.Y = this.G().M().Top;
				point4 = new Point(point3.X + num, point3.Y - num * 2);
				point5 = new Point(point3.X - num, point3.Y - num * 2);
			}
			else
			{
				if (point2.Y < point.Y)
				{
					point3.Y = this.G().M().Bottom;
					point4 = new Point(point3.X + num, point3.Y + num * 2);
					point5 = new Point(point3.X - num, point3.Y + num * 2);
				}
			}
			graphics.FillPolygon(brush, new Point[]
			{
				point3,
				point4,
				point5
			});
		}
		public override void B(XmlWriter xmlWriter, X1 x)
		{
			xmlWriter.WriteStartElement("CONNECTION");
			xmlWriter.WriteAttributeString("FORMAT", "1.00");
			xmlWriter.WriteAttributeString("ID", "" + this.A());
			xmlWriter.WriteAttributeString("FROM", "" + this.A.A());
			xmlWriter.WriteAttributeString("TO", "" + this.a.A());
			xmlWriter.WriteAttributeString("TEXT", "" + this.c());
			xmlWriter.WriteEndElement();
		}
		public override void b(XmlReader xmlReader, w1 w)
		{
			if (w == null)
			{
				throw new l1();
			}
			bool isEmptyElement = xmlReader.IsEmptyElement;
			if (xmlReader["FORMAT"] != "1.00")
			{
				throw new l1();
			}
			this.a(int.Parse(xmlReader["ID"]));
			this.D("" + xmlReader["TEXT"]);
			int num = int.Parse(xmlReader["FROM"]);
			int num2 = int.Parse(xmlReader["TO"]);
			d.a a = (d.a)w.A.B(num);
			d.a a2 = (d.a)w.A.B(num2);
			this.d(a, a2);
			xmlReader.ReadStartElement("CONNECTION");
			if (!isEmptyElement)
			{
				xmlReader.ReadEndElement();
			}
		}
		public override void C(w1 w)
		{
		}
	}
}
namespace d
{
	public abstract class a : global::C.B, l
	{
		public new const string A = "FIGURE";
		public new const string a = "1.00";
		private new int A = -1;
		private new Point A;
		private new Size A;
		private new string B = "";
		private new bool A = true;
		private new List<D.A> A = new List<D.A>();
		private new List<D.A> a = new List<D.A>();
		private new Rectangle? A = null;
		private new Rectangle? a = null;
		private new GraphicsPath A;
		private new Rectangle? B = null;
		private new Brush A;
		private new Pen A;
		private new StringFormat A;
		private new static Dictionary<string, Type> A;
		private new static Dictionary<Type, string> A;
		private new static Dictionary<Type, string> a;
		private new void d()
		{
			this.A = null;
			this.a = null;
			this.B = null;
			if (this.A != null)
			{
				this.A.Dispose();
			}
			this.A = null;
			if (this.A != null)
			{
				this.A.Dispose();
			}
			this.A = null;
		}
		public new string d()
		{
			return global::d.a.A[base.GetType()];
		}
		public new static Type d(string key)
		{
			if (global::d.a.A == null)
			{
				global::d.a.A = new Dictionary<string, Type>();
				global::d.a.A.Add("PapActivity", typeof(b));
				global::d.a.A.Add("PapComment", typeof(d.A));
				global::d.a.A.Add("PapCondition", typeof(global::c.c));
				global::d.a.A.Add("PapConnector", typeof(global::c.B));
				global::d.a.A.Add("PapEnd", typeof(E.A));
				global::d.a.A.Add("PapInput", typeof(D.b));
				global::d.a.A.Add("PapLoopStart", typeof(global::C.b));
				global::d.a.A.Add("PapLoopEnd", typeof(global::b.c));
				global::d.a.A.Add("PapModule", typeof(B));
				global::d.a.A.Add("PapOutput", typeof(global::C.c));
				global::d.a.A.Add("PapStart", typeof(global::b.A));
				global::d.a.A.Add("PapTitle", typeof(global::b.b));
				global::d.a.A = new Dictionary<Type, string>();
				foreach (string current in global::d.a.A.Keys)
				{
					global::d.a.A.Add(global::d.a.A[current], current);
				}
			}
			Type result;
			global::d.a.A.TryGetValue(key, out result);
			return result;
		}
		public new static string d(Type key)
		{
			if (global::d.a.a == null)
			{
				global::d.a.a = new Dictionary<Type, string>();
				global::d.a.a.Add(typeof(b), "Vorgang");
				global::d.a.a.Add(typeof(d.A), "Kommentar");
				global::d.a.a.Add(typeof(global::c.c), "Verzweigung - Bedingung");
				global::d.a.a.Add(typeof(global::c.B), "Verbindungspunkt");
				global::d.a.a.Add(typeof(E.A), "Ende");
				global::d.a.a.Add(typeof(D.b), "Eingabe");
				global::d.a.a.Add(typeof(global::C.b), "Schleife - Kopfbedingung");
				global::d.a.a.Add(typeof(global::b.c), "Schleife - Fußbedingung");
				global::d.a.a.Add(typeof(B), "Unterprogramm");
				global::d.a.a.Add(typeof(global::C.c), "Ausgabe");
				global::d.a.a.Add(typeof(global::b.A), "Start");
				global::d.a.a.Add(typeof(global::b.b), "Titel");
			}
			string result = "";
			global::d.a.a.TryGetValue(key, out result);
			return result;
		}
		public a(Point point, string text)
		{
			this.G();
			this.A = point;
			this.A = this.h();
			this.D(text);
			this.d();
		}
		public a(XmlReader xmlReader, w1 w)
		{
			this.G();
			this.b(xmlReader, w);
			this.d();
		}
		private void G()
		{
			if (this is global::c.b)
			{
				return;
			}
			global::d.a.d("DUMMY");
			if (!global::d.a.A.ContainsKey(base.GetType()))
			{
				throw new l1();
			}
		}
		public override int A()
		{
			return this.A;
		}
		public override void a(int num)
		{
			this.A = num;
		}
		public new Point d()
		{
			return this.A;
		}
		public new void d(Point right)
		{
			if (this.A != right)
			{
				this.A = right;
				this.d();
			}
		}
		public new int d()
		{
			return this.A.X;
		}
		public new void d(int x)
		{
			this.d(new Point(x, this.G()));
		}
		public int G()
		{
			return this.A.Y;
		}
		public void G(int y)
		{
			this.d(new Point(this.d(), y));
		}
		public new Size d()
		{
			return this.A;
		}
		public new void d(Size sz)
		{
			if (this.A != sz)
			{
				this.A = sz;
				this.d();
			}
		}
		public int g()
		{
			return this.A.Width;
		}
		public void g(int width)
		{
			this.d(new Size(width, this.c1()));
		}
		public int c1()
		{
			return this.A.Height;
		}
		public void c1(int height)
		{
			this.d(new Size(this.g(), height));
		}
		public override string c()
		{
			return this.B;
		}
		public override void D(string b)
		{
			if (this.c() != b)
			{
				this.B = b;
				this.A = true;
				this.d();
				n1.B();
			}
		}
		public virtual string H()
		{
			return this.c();
		}
		public string G()
		{
			return global::d.a.d(base.GetType());
		}
		public virtual Size h()
		{
			return global::c.C.A;
		}
		public virtual Size I()
		{
			return global::c.C.c;
		}
		public virtual int i()
		{
			return 2;
		}
		public virtual Color J()
		{
			return Color.LightGreen;
		}
		public virtual Brush j()
		{
			if (this.A == null)
			{
				this.A = new LinearGradientBrush(this.L(), Color.White, this.J(), LinearGradientMode.ForwardDiagonal);
			}
			return this.A;
		}
		public override Pen F()
		{
			if (this.A == null)
			{
				this.A = new Pen(this.J(), 1.5f);
			}
			return this.A;
		}
		public override Brush f()
		{
			return global::c.C.A;
		}
		public virtual Font K()
		{
			return global::c.C.B();
		}
		public virtual StringFormat k()
		{
			if (this.A == null)
			{
				this.A = new StringFormat();
				this.A.Alignment = StringAlignment.Center;
				this.A.LineAlignment = StringAlignment.Center;
				this.A.FormatFlags = StringFormatFlags.NoClip;
			}
			return this.A;
		}
		public virtual Rectangle L()
		{
			if (!this.A.HasValue)
			{
				this.A = new Rectangle?(new Rectangle(this.d() - this.g() / 2, this.G() - this.c1() / 2, this.g(), this.c1()));
			}
			return this.A.Value;
		}
		public virtual Rectangle l()
		{
			if (!this.a.HasValue)
			{
				Rectangle value = this.L();
				value.Inflate(this.I());
				this.a = new Rectangle?(value);
			}
			return this.a.Value;
		}
		public virtual Rectangle M()
		{
			return this.L();
		}
		public virtual GraphicsPath m()
		{
			if (this.A == null)
			{
				this.A = new GraphicsPath();
				this.P(this.A);
			}
			return this.A;
		}
		public virtual Size N()
		{
			Size result = this.h();
			result.Width -= 2 * this.O().Width;
			result.Height -= 2 * this.O().Height;
			return result;
		}
		public virtual Size n()
		{
			Size result = this.N();
			result.Height *= 6;
			return result;
		}
		public virtual Size O()
		{
			return new Size(0, 0);
		}
		public virtual Rectangle o()
		{
			Rectangle result = this.L();
			Size size = this.O();
			if (size.Width != 0)
			{
				result.X += size.Width;
				result.Width -= size.Width * 2;
			}
			if (size.Height != 0)
			{
				result.Y += size.Height;
				result.Height -= size.Height * 2;
			}
			return result;
		}
		public virtual void P(GraphicsPath graphicsPath)
		{
			graphicsPath.AddRectangle(this.L());
		}
		public virtual bool p(Point point)
		{
			return this.m().IsVisible(point);
		}
		public virtual Rectangle Q(Graphics graphics)
		{
			StringFormat stringFormat = this.k();
			SizeF sizeF = graphics.MeasureString(this.H(), this.K(), this.n(), stringFormat);
			Rectangle result = new Rectangle(new Point(this.d(), this.G()), sizeF.ToSize());
			result.Offset(new Point(-result.Width / 2, -result.Height / 2));
			return result;
		}
		public virtual void q(Graphics graphics)
		{
			if (this.A)
			{
				this.R(graphics);
			}
		}
		public virtual void R(Graphics graphics)
		{
			Size size = this.Q(graphics).Size;
			Size size2 = this.N();
			this.c1(this.h().Height + Math.Max(0, size.Height - size2.Height));
			this.g(this.h().Width + Math.Max(0, size.Width - size2.Width));
		}
		public virtual int r()
		{
			return 1;
		}
		public virtual int S()
		{
			return 3;
		}
		public virtual int s()
		{
			return 1;
		}
		public virtual int T()
		{
			return 1;
		}
		public virtual int t()
		{
			return this.S();
		}
		public virtual int U()
		{
			return this.T();
		}
		public virtual bool u()
		{
			return this.S() > 0 || this.T() > 0;
		}
		public virtual bool V(G2 g, bool flag)
		{
			int num = this.U();
			return this.E1() < num || (num == 1 && flag);
		}
		public virtual bool v(G2 g)
		{
			return this.d1() < this.t();
		}
		public virtual global::c.b W(Point pt)
		{
			G2[] array = new G2[]
			{
				G2.East,
				G2.South,
				G2.West,
				G2.North
			};
			G2[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				G2 g = array2[i];
				if (this.V(g, true))
				{
					Point point = this.X(g, this.w());
					if (global::c.b.A(point).Contains(pt))
					{
						return new global::c.b(point, this, g);
					}
				}
			}
			return null;
		}
		public virtual int w()
		{
			return 4;
		}
		public virtual Point X(G2 g, int num)
		{
			Point result = this.d();
			Rectangle rectangle = this.M();
			rectangle.Inflate(num, num);
			switch (g)
			{
			case G2.East:
				result.X = rectangle.Right;
				break;
			case G2.South:
				result.Y = rectangle.Bottom;
				break;
			case G2.West:
				result.X = rectangle.Left;
				break;
			case G2.North:
				result.Y = rectangle.Top;
				break;
			}
			return result;
		}
		public new M d()
		{
			return new M(this.a, this.A);
		}
		public M G()
		{
			return new M(this.a, null);
		}
		public M g()
		{
			return new M(null, this.A);
		}
		public new D.A d()
		{
			if (this.A.Count != 1)
			{
				return null;
			}
			return this.A[0];
		}
		public D.A G()
		{
			if (this.a.Count != 1)
			{
				return null;
			}
			return this.a[0];
		}
		public int D1()
		{
			return this.a.Count + this.A.Count;
		}
		public int d1()
		{
			return this.a.Count;
		}
		public int E1()
		{
			return this.A.Count;
		}
		public new bool d()
		{
			return this.a.Count == 1 && this.A.Count == 1;
		}
		public new void d(D.A a)
		{
			if (this == a.G())
			{
				this.a.Add(a);
				return;
			}
			if (this == a.d())
			{
				this.A.Add(a);
				return;
			}
			throw new l1();
		}
		public new bool d(D.A a)
		{
			if (this == a.G())
			{
				return this.a.Remove(a);
			}
			return this == a.d() && this.A.Remove(a);
		}
		public override Rectangle E()
		{
			if (!this.B.HasValue)
			{
				this.B = new Rectangle?(this.l());
			}
			return this.B.Value;
		}
		public override bool e(Point point)
		{
			return this.m().IsVisible(point);
		}
		public virtual void x(B1 b)
		{
			this.Y(b, true, true);
		}
		public virtual void Y(B1 b, bool flag, bool flag2)
		{
			Graphics graphics = b.A();
			Matrix transform = graphics.Transform;
			int num = this.i();
			bool flag3 = num > 0 && b.e(this) > 0;
			if (num < 0)
			{
				num = -num;
			}
			int num2 = flag3 ? (num + 1) : num;
			if (flag2 && num2 != 0)
			{
				using (Matrix transform2 = graphics.Transform)
				{
					transform2.Translate((float)num2, (float)num2);
					graphics.Transform = transform2;
					this.y(b);
					graphics.Transform = transform;
				}
			}
			if (flag)
			{
				if (flag3)
				{
					using (Matrix transform3 = graphics.Transform)
					{
						int num3 = -(num - 1);
						transform3.Translate((float)num3, (float)num3);
						graphics.Transform = transform3;
						this.Z(b);
						graphics.Transform = transform;
						return;
					}
				}
				this.Z(b);
			}
		}
		public virtual void y(B1 b)
		{
			Graphics graphics = b.A();
			graphics.FillPath(global::c.C.A(b), this.m());
		}
		public virtual void Z(B1 b)
		{
			this.z(b);
			this.A1(b);
		}
		public virtual void z(B1 b)
		{
			Graphics graphics = b.A();
			Pen pen = this.G(b);
			graphics.FillPath(this.j(), this.m());
			graphics.DrawPath(pen, this.m());
		}
		public virtual void A1(B1 b)
		{
			Graphics graphics = b.A();
			Rectangle r = this.o();
			r.Y += 2;
			this.A = null;
			r.Inflate(2, 0);
			graphics.DrawString(this.H(), this.K(), this.g(b), r, this.k());
		}
		public override void B(XmlWriter xmlWriter, X1 x)
		{
			if (x == null)
			{
				throw new l1();
			}
			xmlWriter.WriteStartElement("FIGURE");
			xmlWriter.WriteAttributeString("SUBTYPE", this.d());
			xmlWriter.WriteAttributeString("FORMAT", "1.00");
			this.a1(xmlWriter, x);
			xmlWriter.WriteStartElement("TEXT");
			xmlWriter.WriteCData(this.c());
			xmlWriter.WriteEndElement();
			this.B1(xmlWriter, x);
			xmlWriter.WriteEndElement();
		}
		public virtual void a1(XmlWriter xmlWriter, X1 x)
		{
			xmlWriter.WriteAttributeString("ID", "" + this.A());
		}
		public virtual void B1(XmlWriter xmlWriter, X1 x)
		{
		}
		public override void b(XmlReader xmlReader, w1 w)
		{
			if (w == null)
			{
				throw new l1();
			}
			bool isEmptyElement = xmlReader.IsEmptyElement;
			if (xmlReader["FORMAT"] != "1.00")
			{
				throw new l1();
			}
			this.b1(xmlReader, w);
			xmlReader.ReadStartElement("FIGURE");
			this.D("");
			if (xmlReader.Name == "TEXT")
			{
				bool isEmptyElement2 = xmlReader.IsEmptyElement;
				xmlReader.ReadStartElement("TEXT");
				if (!isEmptyElement2)
				{
					this.D(w1.A(xmlReader.ReadString()));
					xmlReader.ReadEndElement();
				}
			}
			this.C1(xmlReader, w);
			if (!isEmptyElement)
			{
				xmlReader.ReadEndElement();
			}
		}
		public virtual void b1(XmlReader xmlReader, w1 w)
		{
			this.a(int.Parse(xmlReader["ID"]));
			this.A = this.h();
		}
		public virtual void C1(XmlReader xmlReader, w1 w)
		{
		}
		public override void C(w1 w)
		{
		}
	}
	public class A : d.a
	{
		private new bool A = true;
		public A(Point point, string text) : base(point, text)
		{
		}
		public A(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override StringFormat k()
		{
			StringFormat stringFormat = base.k();
			stringFormat.Alignment = (this.A ? StringAlignment.Near : StringAlignment.Far);
			return stringFormat;
		}
		public override Font K()
		{
			return global::c.C.a();
		}
		public override Color J()
		{
			return global::c.C.A;
		}
		public override Size O()
		{
			return new Size(global::c.C.A.Width / 40, 0);
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
			Graphics graphics = b.A();
			Rectangle rect = this.L();
			Rectangle rectangle = this.Q(b.A());
			Pen c = global::c.C.C;
			if (b.e(this) > 0 || b.c())
			{
				graphics.DrawRectangle(this.G(b), rect);
				return;
			}
			int num = Math.Min(rectangle.Height * 3 / 2, rect.Height) / 2;
			int num2 = global::c.C.A.Width / 60;
			int num3;
			if (this.k().Alignment == StringAlignment.Far)
			{
				num3 = rect.X + rect.Width;
				num2 = -num2;
			}
			else
			{
				num3 = rect.X;
			}
			graphics.DrawLine(c, num3, base.G() - num, num3, base.G() + num);
			graphics.DrawLine(c, num3, base.G() - num, num3 + num2, base.G() - num);
			graphics.DrawLine(c, num3, base.G() + num, num3 + num2, base.G() + num);
		}
	}
}
