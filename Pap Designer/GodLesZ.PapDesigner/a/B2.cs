using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace a
{
	public class B2 : UserControl
	{
		public delegate void A(s1);
		private Dictionary<p1, TabPage> A = new Dictionary<p1, TabPage>();
		private h2 A;
		private s1 A;
		private static ContextMenuStrip A;
		private B2.A A;
		private IContainer A;
		private TabControl A;
		public B2()
		{
			this.B();
			ImageList imageList = new ImageList();
			imageList.Images.Add(x.A("Diagram"));
			imageList.Images.Add(x.A("DiagramOpen"));
			imageList.Images.Add(x.A("LightningOff"));
			imageList.Images.Add(x.A("LightningOn"));
			this.A.ImageList = imageList;
		}
		public W1<p1> A()
		{
			if (this.A() == null)
			{
				return null;
			}
			return this.A().E();
		}
		public h2 A()
		{
			return this.A;
		}
		public void A(h2 h)
		{
			if (this.A() != h)
			{
				if (this.A() != null)
				{
					this.A().E().b(new W1<p1>.B(this.A));
					this.A().E().e(new W1<p1>.a(this.A));
					foreach (p1 current in this.A().E())
					{
						this.A(current);
					}
				}
				this.A = h;
				if (this.A() != null)
				{
					int num = 0;
					foreach (p1 current2 in this.A().E())
					{
						this.A(current2, num++);
					}
					this.A().E().B(new W1<p1>.B(this.A));
					this.A().E().E(new W1<p1>.a(this.A));
				}
			}
		}
		public s1 A()
		{
			TabPage selectedTab = this.A.SelectedTab;
			if (selectedTab == null)
			{
				return null;
			}
			return ((E2)selectedTab.Controls[0]).A();
		}
		public s1 A(p1 key)
		{
			TabPage tabPage = this.A[key];
			this.A.SelectedTab = tabPage;
			this.a();
			return this.A(tabPage);
		}
		public void a(h2 h)
		{
			foreach (TabPage tabPage in this.A.TabPages)
			{
				e2 e = this.A(tabPage) as e2;
				if (e != null)
				{
					e.M(!h.F());
					e.l();
				}
			}
		}
		private void A(p1 p, int num)
		{
			TabPage tabPage = new TabPage(p.b());
			tabPage.Tag = p;
			tabPage.ImageIndex = -1;
			if (p is Q1)
			{
				E2 e = new E2();
				e.Dock = DockStyle.Fill;
				e.A().L((Q1)p);
				tabPage.Controls.Add(e);
				if (num < this.A.TabCount)
				{
					this.A.TabPages.Insert(num, tabPage);
				}
				else
				{
					this.A.TabPages.Add(tabPage);
				}
				this.A.Add(p, tabPage);
				p.B(new P1<p1>.a(this.A));
				this.a();
				return;
			}
			throw new l1();
		}
		private void A(p1 p)
		{
			p.b(new P1<p1>.a(this.A));
			TabPage tabPage = this.A[p];
			this.A.Remove(p);
			this.A.TabPages.Remove(tabPage);
			tabPage.Dispose();
			this.a();
		}
		private void A(p1 p, string text)
		{
			this.A[p].Text = p.b();
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void A(B2.A b)
		{
			this.A = (B2.A)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void a(B2.A value)
		{
			this.A = (B2.A)Delegate.Remove(this.A, value);
		}
		private void A(TabPage tabPage, Point position)
		{
			if (B2.A == null)
			{
				ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
				r.A().a(contextMenuStrip.Items);
				s.A().a(contextMenuStrip.Items);
				contextMenuStrip.Opened += new EventHandler(P.F);
				B2.A = contextMenuStrip;
			}
			s1 tag = this.A(tabPage);
			B2.A.Tag = tag;
			this.A();
			B2.A.Show(this.A, position);
		}
		private void A()
		{
			Q1 q = ((e2)B2.A.Tag).L();
			r.A().A(this.A(), q);
			s.A().A(this.A(), q);
		}
		private void A(object obj, MouseEventArgs mouseEventArgs)
		{
			if (mouseEventArgs.Button == MouseButtons.Left)
			{
				return;
			}
			int num = this.A(mouseEventArgs);
			if (num != -1)
			{
				Rectangle tabRect = this.A.GetTabRect(num);
				Point location = tabRect.Location;
				location.X += tabRect.Width / 2;
				location.Y += tabRect.Height;
				this.A(this.A.TabPages[num], location);
			}
		}
		private void A(object obj, EventArgs eventArgs)
		{
			this.a();
		}
		private p1 A(TabPage tabPage)
		{
			if (tabPage == null)
			{
				return null;
			}
			return ((E2)tabPage.Controls[0]).A().A();
		}
		private s1 A(TabPage tabPage)
		{
			if (tabPage == null)
			{
				return null;
			}
			return ((E2)tabPage.Controls[0]).A();
		}
		private int A(MouseEventArgs mouseEventArgs)
		{
			for (int i = 0; i < this.A.TabCount; i++)
			{
				if (this.A.GetTabRect(i).Contains(mouseEventArgs.X, mouseEventArgs.Y))
				{
					return i;
				}
			}
			return -1;
		}
		private void a()
		{
			s1 s = this.A();
			if (this.A != s)
			{
				if (this.A != null)
				{
					this.A(s);
				}
				this.A(this.A, false);
				this.A = s;
				this.A(this.A, true);
			}
		}
		private void A(s1 s, bool flag)
		{
			if (s != null)
			{
				TabPage tabPage = null;
				if (this.A.TryGetValue(s.A(), out tabPage))
				{
					int num = this.A.e() ? 2 : 0;
					tabPage.ImageIndex = (flag ? (1 + num) : -1);
				}
			}
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
			this.A = new TabControl();
			base.SuspendLayout();
			this.A.Dock = DockStyle.Fill;
			this.A.HotTrack = true;
			this.A.Location = new Point(0, 0);
			this.A.Name = "tabView";
			this.A.SelectedIndex = 0;
			this.A.Size = new Size(363, 276);
			this.A.TabIndex = 0;
			this.A.MouseDown += new MouseEventHandler(this.A);
			this.A.SelectedIndexChanged += new EventHandler(this.A);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.A);
			base.Name = "DiagramTabPanel";
			base.Size = new Size(363, 276);
			base.ResumeLayout(false);
		}
	}
	public class b2 : IDisposable
	{
		public delegate void A(h2);
		public delegate void a(s1);
		private static b2 A;
		private K1 A;
		private W1<h2> A;
		private I2 A;
		private A2 A;
		private V1 A;
		private int A;
		private bool A;
		private b2.A A;
		private b2.a A;
		public b2(K1 a, W1<h2> w, I2 i, A2 a2)
		{
			b2.A = this;
			this.A = a;
			this.A = w;
			this.A = i;
			this.A = a2;
			this.A = a2.A();
			if (w.B() > 0)
			{
				throw new l1();
			}
			this.A = (b2.A)Delegate.Combine(this.A, new b2.A(this.b));
			this.A = (b2.a)Delegate.Combine(this.A, new b2.a(this.a));
			w.C(new W1<h2>.a(this.a));
			w.F(new W1<h2>.a(this.a));
			w.B(new W1<h2>.a(this.A));
			w.D(new W1<h2>.a(this.A));
			w.B(new W1<h2>.B(this.A));
			w.E(new W1<h2>.a(this.B));
			i.A(w);
			i.A(new I2.A(this.A));
			this.A.A(w);
			this.A.A(new V1.A(this.A));
		}
		~b2()
		{
			if (!this.A)
			{
				throw new l1();
			}
		}
		public static b2 A()
		{
			if (b2.A == null)
			{
				throw new l1();
			}
			return b2.A;
		}
		public void Dispose()
		{
			if (!this.A)
			{
				if (this.A.B() > 0)
				{
					throw new l1();
				}
				this.A.a(new V1.A(this.A));
				this.A.A(null);
				this.A.a(new I2.A(this.A));
				this.A.A(null);
				this.A.c(new W1<h2>.a(this.a));
				this.A.f(new W1<h2>.a(this.a));
				this.A.b(new W1<h2>.a(this.A));
				this.A.d(new W1<h2>.a(this.A));
				this.A.b(new W1<h2>.B(this.A));
				this.A.e(new W1<h2>.a(this.B));
				this.A = (b2.A)Delegate.Remove(this.A, new b2.A(this.b));
				this.A = (b2.a)Delegate.Remove(this.A, new b2.a(this.a));
				this.A = null;
				this.A = null;
				this.A = null;
				b2.A = null;
			}
			this.A = true;
		}
		public h2 A()
		{
			return this.A.A();
		}
		public p1 A()
		{
			if (this.A() == null)
			{
				return null;
			}
			return this.A().A();
		}
		public s1 A()
		{
			return this.A.A();
		}
		private void A(h2 h)
		{
			this.A();
		}
		private void a(h2 h)
		{
			if (!this.A.B(h))
			{
				if (this.A.B() > 0)
				{
					h = this.A.B(0);
				}
				else
				{
					h = null;
				}
			}
			if (h != null)
			{
				this.A.A(h);
				this.A.A(h);
			}
			this.a();
		}
		private void A(h2 h, int num)
		{
			h.B(new P1<h2>.a(this.A));
			h.E(new h2.a(this.A));
			h.E().B(new W1<p1>.a(this.A));
			h.E().C(new W1<p1>.a(this.a));
			h.E().D(new W1<p1>.a(this.A));
			h.E().F(new W1<p1>.a(this.B));
		}
		private void B(h2 h)
		{
			h.b(new P1<h2>.a(this.A));
			h.e(new h2.a(this.A));
			h.E().b(new W1<p1>.a(this.A));
			h.E().c(new W1<p1>.a(this.a));
			h.E().d(new W1<p1>.a(this.A));
			h.E().f(new W1<p1>.a(this.B));
			if (h.F() != null)
			{
				this.A.A(h.F());
			}
		}
		private void A(h2 h, string text)
		{
			this.A(this.A());
		}
		private void A(p1 p)
		{
			this.A();
		}
		private void a(p1 p)
		{
			this.a();
		}
		private void B(p1 p)
		{
			this.a();
		}
		private void A()
		{
			this.A++;
		}
		private void a()
		{
			this.A--;
			if (this.A < 0)
			{
				throw new l1();
			}
			if (this.A == 0)
			{
				this.A(this.A());
				this.A(this.A());
			}
		}
		public void B()
		{
			this.A(this.A());
		}
		private void A(s1 s)
		{
			this.A();
			if (s != null)
			{
				this.A.A(s.A());
			}
			this.a();
		}
		private void A(o1 o)
		{
			if (this.A == 0)
			{
				this.A();
				if (o is h2)
				{
					h2 h = (h2)o;
					if (h != null)
					{
						this.A.A(h);
					}
				}
				if (o is p1)
				{
					p1 p = (p1)o;
					if (p != null)
					{
						this.A.A(p);
					}
				}
				this.a();
			}
		}
		private void b(h2 h)
		{
		}
		private void a(s1 s)
		{
			this.A.A(s);
			e2 e = s as e2;
			if (e != null)
			{
				e.L(this.A().E());
			}
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void A(b2.A b)
		{
			this.A = (b2.A)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void a(b2.A value)
		{
			this.A = (b2.A)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void A(b2.a b)
		{
			this.A = (b2.a)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void a(b2.a value)
		{
			this.A = (b2.a)Delegate.Remove(this.A, value);
		}
		public void C(h2 h)
		{
			this.A.A(h);
		}
		public void c(h2 h)
		{
			if (!this.A.B(h))
			{
				return;
			}
			this.A.A(h);
			this.B();
		}
		public s1 A(p1 p)
		{
			if (z1.A())
			{
				z1.A();
			}
			return this.A.A(p);
		}
		public void b()
		{
			this.A.A();
		}
		public void C()
		{
			this.A.a();
		}
	}
}
