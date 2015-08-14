using b;
using C;
using d;
using D;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace a
{
	public class R1
	{
		private h2 A;
		private i1 A;
		public R1(h2 a)
		{
			this.A = a;
			this.A = new i1();
		}
		public void A()
		{
			this.A.A();
		}
		public h2 A()
		{
			return this.A;
		}
		public i1 A()
		{
			return this.A;
		}
		public bool A(string text)
		{
			e1 e = new e1(this.A, "Projekteigenschaften");
			bool flag = false;
			try
			{
				flag = q1.A().A(this.A, text);
			}
			catch (Exception ex)
			{
				e.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(e);
			}
			return flag;
		}
		public bool a(string text)
		{
			e1 e = new e1(this.A, "Projektname");
			bool flag = false;
			try
			{
				flag = this.A.a(text);
			}
			catch (Exception ex)
			{
				e.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(e);
			}
			return flag;
		}
		public bool A(p1 p)
		{
			int num = -1;
			return this.A(p, ref num, null);
		}
		public bool A(p1 p, ref int ptr, H2 h)
		{
			this.A(p);
			g1 g = new H1(this.A, p, "Diagramm einfügen");
			bool flag = false;
			try
			{
				flag = true;
				if (ptr < 0)
				{
					ptr = this.A().E();
				}
				this.A().E(p, ptr);
				if (h != null)
				{
					((Q1)p).A(h);
				}
			}
			catch (Exception ex)
			{
				g.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(g);
			}
			return flag;
		}
		public bool a(p1 p)
		{
			byte[] array = this.A(p);
			g1 g = new h1(this.A, p, array, "Diagramm löschen");
			bool flag = false;
			try
			{
				this.A().e(p);
				flag = true;
			}
			catch (Exception ex)
			{
				g.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(g);
			}
			return flag;
		}
		public bool A(p1 p, string text)
		{
			f1 f = new f1(this.A, p, "Diagrammeigenschaften");
			bool flag = false;
			try
			{
				flag = p.g(null, this.A().E(), text);
			}
			catch (Exception ex)
			{
				f.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(f);
			}
			return flag;
		}
		public bool a(p1 p, string text)
		{
			f1 f = new f1(this.A, p, "Diagrammname");
			bool flag = false;
			try
			{
				flag = p.a(text);
			}
			catch (Exception ex)
			{
				f.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(f);
			}
			return flag;
		}
		public bool A(p1 p, int num)
		{
			G1 g = new G1(this.A, p, "Diagramm verschieben");
			bool flag = false;
			try
			{
				flag = this.A.E(p, num);
			}
			catch (Exception ex)
			{
				g.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(g);
			}
			return flag;
		}
		public g1 A(e2 e)
		{
			g1 result;
			try
			{
				byte[] array = this.A(e.A());
				result = new g1(this.A, e, array, "Symbol verschieben");
			}
			catch (Exception ex)
			{
				n1.A(ex);
				throw ex;
			}
			return result;
		}
		public void A(e2 e, g1 g)
		{
			try
			{
				this.A(e, g);
			}
			catch (Exception ex)
			{
				n1.A(ex);
				throw ex;
			}
		}
		public bool A(e2 e, Type type, F f)
		{
			byte[] array = this.A(e.A());
			string text = (f.a() != null) ? "Symbol umwandeln" : "Symbol einfügen";
			g1 g = new g1(this.A, e, array, text);
			bool flag = false;
			bool flag2 = false;
			d.a a = null;
			try
			{
				d.a a2 = f.a();
				a = e.L().A(type, f);
				string text2 = (a is d.A) ? "" : a.c();
				if (a2 != null && a2.d())
				{
					text2 = Regex.Replace("" + a2.c(), "(\\s){1,}", " ").Trim();
					if (a is D.b || a is global::C.c)
					{
						Type type2 = (a is D.b) ? typeof(global::C.c) : typeof(D.b);
						string text3 = e.L().A(type2).Split(new char[]
						{
							' '
						})[0];
						string newValue = e.L().A(a.GetType()).Split(new char[]
						{
							' '
						})[0];
						if (text2.StartsWith(text3))
						{
							text2 = text2.Replace(text3, newValue);
						}
					}
					if (a is d.B && text2.Length > 64)
					{
						text2 = text2.Substring(0, 64);
					}
				}
				if (a.d())
				{
					e.L().A(a);
					if (!(a is d.A))
					{
						a.D(text2);
					}
					if (!e.L(a, text2, out flag, false))
					{
						throw new L1();
					}
				}
				flag2 = true;
			}
			catch (Exception ex)
			{
				g.a();
				if (!(ex is L1))
				{
					n1.A(ex);
				}
			}
			if (flag2)
			{
				flag2 = this.A(e, g);
			}
			if (flag2 && flag && a is d.B)
			{
				e.l();
				this.A(a.c());
			}
			e.C();
			return flag2;
		}
		public void A(e2 e, d.a a)
		{
			d1 d = null;
			bool flag = a is global::b.b || a is global::b.a;
			if (flag)
			{
				d = new f1(this.A, e.A(), "Diagrammname");
			}
			else
			{
				d = new I1(this.A, e, e.A(), a, "Symbol bearbeiten");
			}
			bool flag2 = false;
			bool flag3 = false;
			try
			{
				flag3 = e.L(a, out flag2);
			}
			catch (Exception ex)
			{
				d.a();
				e.C();
				n1.A(ex);
			}
			if (flag3)
			{
				bool flag4 = this.A.A(d);
				if (flag4)
				{
					e.d(a);
				}
				if (flag2 && a is d.B)
				{
					e.l();
					this.A(a.c());
				}
			}
		}
		public void A(e2 e, d.a a, G2 g)
		{
			byte[] array = this.A(e.A());
			g1 g2 = new g1(this.A, e, array, "Verbindung einfügen");
			bool flag = false;
			try
			{
				flag = e.L().A(a, g, false);
			}
			catch (Exception ex)
			{
				g2.a();
				e.C();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(g2);
			}
		}
		public void A(e2 e, D.A a)
		{
			D.A a2 = a;
			if (K1.A().A().SmartConnectionDClick)
			{
				a2 = Q1.A(a);
				if (a2 != null && a2 != a)
				{
					e.L().A(a2);
				}
			}
			this.a(e, a2);
		}
		public void a(e2 e, D.A a)
		{
			byte[] array = this.A(e.A());
			d1 d = new g1(this.A, e, array, "Verbindung bearbeiten");
			bool flag = false;
			try
			{
				flag = e.L().A(e, a);
			}
			catch (Exception ex)
			{
				d.a();
				e.C();
				n1.A(ex);
			}
			if (flag)
			{
				bool flag2 = this.A.A(d);
				if (flag2)
				{
					e.d(a);
				}
			}
		}
		public bool A(e2 e, D.A a, string text)
		{
			byte[] array = this.A(e.A());
			g1 g = new g1(this.A, e, array, text);
			bool flag = false;
			try
			{
				e.L().A(a, true, false);
				flag = true;
			}
			catch (Exception ex)
			{
				g.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(g);
			}
			e.C();
			return flag;
		}
		public bool A(e2 e, H2 h, F f, string text)
		{
			try
			{
				if (h == null)
				{
					throw new l1();
				}
				if (h.a() == 0)
				{
					throw new l1();
				}
				if (h.A() == null)
				{
					throw new l1();
				}
				if (!h.c())
				{
					throw new l1();
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
				return false;
			}
			byte[] array = this.A(e.A());
			g1 g = new g1(this.A, e, array, text);
			bool flag = false;
			try
			{
				e.L().A(h, f);
				flag = true;
			}
			catch (Exception ex2)
			{
				g.a();
				e.C();
				n1.A(ex2);
			}
			if (flag)
			{
				flag = this.A(e, g);
			}
			return flag;
		}
		public bool a(e2 e, H2 h, F f, string text)
		{
			try
			{
				if (h == null)
				{
					throw new l1();
				}
				if (h.a() == 0)
				{
					throw new l1();
				}
				if (h.A() == null)
				{
					throw new l1();
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
				return false;
			}
			byte[] array = this.A(e.A());
			g1 g = new g1(this.A, e, array, text);
			bool flag = false;
			try
			{
				e.L().A(e.L(), f);
				flag = true;
			}
			catch (Exception ex2)
			{
				g.a();
				e.C();
				n1.A(ex2);
			}
			if (flag)
			{
				flag = this.A(e, g);
			}
			return flag;
		}
		public bool A(e2 e, H2 h, string text)
		{
			byte[] array = this.A(e.A());
			g1 g = new g1(this.A, e, array, text);
			bool flag = false;
			try
			{
				e.L().A(h, false);
				flag = true;
			}
			catch (Exception ex)
			{
				g.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(g);
			}
			e.C();
			return flag;
		}
		public bool A(e2 e, H2 h, string text, string text2)
		{
			byte[] array = this.A(e.A());
			g1 g = new g1(this.A, e, array, text2);
			bool flag = false;
			try
			{
				e.L().A(h, text);
				flag = true;
			}
			catch (Exception ex)
			{
				g.a();
				n1.A(ex);
			}
			if (flag)
			{
				flag = this.A.A(g);
			}
			e.C();
			return flag;
		}
		public bool A(e2 e, H2 h, Q1 q, string text)
		{
			Q1 q2 = e.L();
			q2.A(h);
			H2 h2 = h.A();
			E1 e2 = this.A.A(this.A, text);
			try
			{
				if (!this.A(e, h, q.b(), text))
				{
					throw new InvalidOperationException();
				}
				int num = -1;
				if (!this.A(q, ref num, h2))
				{
					throw new InvalidOperationException();
				}
				this.A.A(e2);
			}
			catch (Exception ex)
			{
				this.A.a(e2);
				e.C();
				n1.A(ex);
			}
			return true;
		}
		private byte[] A(p1 p)
		{
			g1 g = this.A().B() as g1;
			if (g != null && g.A() == p.A())
			{
				return g.A();
			}
			return null;
		}
		private bool A(e2 e)
		{
			if (e.L().A().A())
			{
				string text = "Die Größe des Diagrammrasters ist auf {0}x{1} beschränkt.\n";
				text += "Stellen Sie umfangreiche Abläufe besser\n";
				text += "durch mehrere kleine Teildiagramme da.";
				text = string.Format(text, k1.a.Width, k1.a.Height);
				v.A(e, text);
				return true;
			}
			return false;
		}
		private bool A(e2 e, d1 d)
		{
			bool flag = !this.A(e);
			if (flag)
			{
				this.A.A(d);
			}
			else
			{
				using (new C())
				{
					d.a();
				}
			}
			return flag;
		}
		private void A(string text)
		{
			Q1 q = (Q1)this.A.E();
			q.b(text);
			this.A(q);
		}
	}
	public class r1 : Form, b
	{
		private const int A = 2000;
		private Form A;
		private Form a;
		private IContainer A;
		private Timer A;
		private Label A;
		public r1()
		{
			bool flag = j1.A();
			this.B();
			Color foreColor = Color.FromArgb(0, 112, 0);
			this.A.ForeColor = foreColor;
			this.A.Text = j1.F();
			if (!flag)
			{
				Environment.Exit(-1);
			}
			this.A.Cursor = (this.Cursor = Cursors.WaitCursor);
		}
		public virtual Form a()
		{
			return new d2();
		}
		public void A(string[] array)
		{
			if (this.a != null)
			{
				((b)this.a).A(array);
				this.a.Activate();
			}
		}
		private void B(int num)
		{
			if (this.A != null)
			{
				this.A.Stop();
				this.A.Interval = ((num > 0) ? num : 1);
				this.A.Start();
			}
		}
		private void B(object obj, EventArgs eventArgs)
		{
			this.B(1);
		}
		private void b(object obj, EventArgs eventArgs)
		{
			Form form = (Form)obj;
			if (form != this.A)
			{
				throw new l1();
			}
			this.a = this.A;
			this.a.Disposed += new EventHandler(this.C);
			base.Hide();
		}
		private void C(object obj, EventArgs eventArgs)
		{
			base.Dispose();
		}
		private void c(object obj, EventArgs eventArgs)
		{
			this.A.Stop();
			if (this.A != null)
			{
				this.A.Dispose();
				this.A = null;
				this.A.Show();
				this.A.Shown += new EventHandler(this.b);
				return;
			}
			long ticks = DateTime.Now.Ticks;
			this.A = this.a();
			if (!(this.A is b))
			{
				throw new l1();
			}
			this.A.Owner = this;
			this.B(2000L, ticks);
		}
		private void B(long num, long num2)
		{
			if (this.A != null)
			{
				long num3 = (DateTime.Now.Ticks - num2) / 10000L;
				this.B((int)(num - num3));
			}
		}
		private void B(long num)
		{
			this.B(num, DateTime.Now.Ticks);
		}
		private void B(object obj, KeyEventArgs keyEventArgs)
		{
			if (r1.B(keyEventArgs.Modifiers, Keys.Alt) || r1.B(keyEventArgs.Modifiers, Keys.Control))
			{
				this.B(5000L);
				return;
			}
			if (r1.B(keyEventArgs.KeyCode, Keys.Escape))
			{
				this.B(0L);
			}
		}
		private static bool B(Keys keys, Keys keys2)
		{
			return (keys & keys2) == keys2;
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void B()
		{
			this.A = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(r1));
			this.A = new Timer(this.A);
			this.A = new Label();
			base.SuspendLayout();
			this.A.Tick += new EventHandler(this.c);
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.A.AutoSize = true;
			this.A.BackColor = Color.Transparent;
			this.A.Cursor = Cursors.Default;
			this.A.ForeColor = SystemColors.ControlText;
			this.A.Location = new Point(13, 158);
			this.A.Name = "label";
			this.A.Size = new Size(99, 13);
			this.A.TabIndex = 0;
			this.A.Text = "<product info here>";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = SystemColors.Control;
			this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(317, 221);
			base.Controls.Add(this.A);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "SplashScreen";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Splashscreen";
			base.Shown += new EventHandler(this.B);
			base.KeyDown += new KeyEventHandler(this.B);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
