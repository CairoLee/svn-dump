using a;
using b;
using c;
using d;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
namespace c
{
	public class C
	{
		public const int A = 220;
		public const int a = 60;
		public static readonly Size A = new Size(220, 60);
		public static readonly Size a = new Size(220, 60);
		public static readonly Size B = new Size(240, 100);
		public static readonly Size b = new Size(220, 30);
		public static readonly Size C = new Size(16, 16);
		public static readonly Size c = new Size(20, 15);
		private static d A = new d(K1.A().A().UseNarrowTextFont);
		private static Font A = null;
		public static Color A = Color.DarkBlue;
		public static Color a = Color.Magenta;
		public static Pen A = new Pen(global::c.C.a, 1.5f);
		public static Pen a = new Pen(global::c.C.a, 3f);
		public static Pen B = new Pen(global::c.C.a);
		public static Pen b = new Pen(Color.Magenta, 3f);
		public static Pen C = new Pen(global::c.C.A, 1f);
		public static Brush A = new SolidBrush(global::c.C.A);
		private static Brush a = new SolidBrush(Color.FromArgb(160, Color.SlateGray));
		private static Brush B = new SolidBrush(Color.LightSlateGray);
		public static Brush b = new SolidBrush(global::c.C.a);
		private static Color B = Color.White;
		private static Pen c = null;
		public static Color b = Color.Black;
		public static Pen D = new Pen(global::c.C.b, 1f);
		public static SolidBrush A = new SolidBrush(global::c.C.b);
		public static Pen d = new Pen(Color.Green, 1f);
		public static SolidBrush a = new SolidBrush(Color.Green);
		public static SolidBrush B = new SolidBrush(SystemColors.ControlLight);
		public static bool A()
		{
			return global::c.C.A.A();
		}
		public static void A(bool flag)
		{
			global::c.C.A.a(flag);
			global::c.C.A = null;
		}
		public static Font A()
		{
			return global::c.C.A.A(10);
		}
		public static Font a()
		{
			return global::c.C.A.A(12);
		}
		public static Font B()
		{
			return global::c.C.A.A(14);
		}
		public static Font b()
		{
			return global::c.C.A.A(15);
		}
		public static Font C()
		{
			return global::c.C.A.A(17);
		}
		public static Font c()
		{
			if (global::c.C.A == null)
			{
				global::c.C.A = new Font(global::c.C.A.A(13), FontStyle.Bold | FontStyle.Italic);
			}
			return global::c.C.A;
		}
		public static Brush A(B1 b)
		{
			if (b.b())
			{
				return global::c.C.B;
			}
			return global::c.C.a;
		}
		public static Pen A(Color right)
		{
			if (global::c.C.B != right && global::c.C.c != null)
			{
				global::c.C.B = right;
				global::c.C.c.Dispose();
				global::c.C.c = null;
			}
			if (global::c.C.c == null)
			{
				int num = 32;
				Color color = Color.FromArgb(255, (int)right.R - num, (int)right.G - num, (int)right.B - num);
				global::c.C.c = new Pen(color, 0.5f);
			}
			return global::c.C.c;
		}
	}
	public class c : d.a
	{
		private new const string A = "CONNECTORLABEL";
		private new string[] A = new string[]
		{
			"?",
			"?",
			"?",
			"?"
		};
		private new static d.C A = new d.C();
		private new bool A = true;
		private new string a = "";
		public c(Point point, string text) : base(point, text)
		{
		}
		public c(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public new string A(G2 g)
		{
			if (g / G2.None > G2.East)
			{
				throw new l1();
			}
			return this.A[(int)g];
		}
		public new void A(G2 g, string text)
		{
			if (g / G2.None > G2.East)
			{
				throw new l1();
			}
			this.A[(int)g] = text;
		}
		public override Size h()
		{
			return global::c.C.B;
		}
		public override Color J()
		{
			return Color.Goldenrod;
		}
		public override void P(GraphicsPath graphicsPath)
		{
			Rectangle rectangle = this.L();
			Point[] points = new Point[]
			{
				new Point(rectangle.X + rectangle.Width / 2, rectangle.Y),
				new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height / 2),
				new Point(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height),
				new Point(rectangle.X, rectangle.Y + rectangle.Height / 2)
			};
			graphicsPath.AddPolygon(points);
		}
		public override Size O()
		{
			return new Size(this.h().Width / 8, this.h().Height / 8);
		}
		public override string c()
		{
			return base.c();
		}
		public override void D(string text)
		{
			this.A = true;
			base.D(text);
		}
		public override string H()
		{
			return this.a;
		}
		public override void R(Graphics graphics)
		{
			if (this.A)
			{
				Size size = global::c.c.A.A(graphics, this.K(), this.c(), out this.a);
				base.g(size.Width);
				base.c1(size.Height);
				this.A = false;
			}
		}
		public override int T()
		{
			return 3;
		}
		public override int U()
		{
			if (Q1.a(this))
			{
				return 1;
			}
			return this.T();
		}
		public override bool V(G2 g, bool flag)
		{
			return base.V(g, flag && !Q1.a(this));
		}
		public override void B1(XmlWriter xmlWriter, X1 x)
		{
		}
		public override void C1(XmlReader xmlReader, w1 w)
		{
			if (xmlReader.Name == "CONNECTORLABEL")
			{
				bool isEmptyElement = xmlReader.IsEmptyElement;
				this.A(G2.East, xmlReader[G2.East.ToString()]);
				this.A(G2.South, xmlReader[G2.South.ToString()]);
				this.A(G2.West, xmlReader[G2.West.ToString()]);
				this.A(G2.North, xmlReader[G2.North.ToString()]);
				xmlReader.ReadStartElement("CONNECTORLABEL");
				if (!isEmptyElement)
				{
					xmlReader.ReadEndElement();
				}
			}
		}
	}
}
namespace C
{
	public abstract class C : d.a
	{
		private new C A;
		private new int A = -1;
		public C(Point point, string text) : base(point, text)
		{
		}
		public C(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public new C A()
		{
			return this.A;
		}
		public new void A(C a)
		{
			this.A = a;
		}
		public new b A()
		{
			return (b)((this is b) ? this : this.A());
		}
		public new global::b.c A()
		{
			return (global::b.c)((this is global::b.c) ? this : this.A());
		}
		public override Size h()
		{
			return global::c.C.b;
		}
		public override Color J()
		{
			return Color.Goldenrod;
		}
		public override Size O()
		{
			return new Size(this.L().Height / 4, 0);
		}
		public override bool V(G2 g, bool flag)
		{
			return g == G2.South && base.V(g, flag);
		}
		public override bool v(G2 g)
		{
			return g != G2.North && base.v(g);
		}
		public override void a1(XmlWriter xmlWriter, X1 x)
		{
			base.a1(xmlWriter, x);
			if (this.A() != null)
			{
				xmlWriter.WriteAttributeString("ASSOCIATE", "" + this.A().A());
			}
		}
		public override void b1(XmlReader xmlReader, w1 w)
		{
			base.b1(xmlReader, w);
			if (xmlReader["ASSOCIATE"] != null)
			{
				this.A = int.Parse(xmlReader["ASSOCIATE"]);
			}
		}
		public override void C(w1 w)
		{
			global::c.a a = null;
			if (w.A.a(this.A, out a))
			{
				this.A((C)a);
			}
		}
	}
	public class c : d.c
	{
		public c(Point point, string text) : base(point, text)
		{
		}
		public c(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override string c1(B1 b)
		{
			return b.E();
		}
	}
}
