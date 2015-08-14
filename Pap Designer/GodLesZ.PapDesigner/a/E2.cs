using b;
using c;
using C;
using d;
using D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace a
{
	public class E2 : UserControl
	{
		private IContainer A;
		private e2 A;
		private O A;
		public E2()
		{
			this.A();
			int num = 180;
			this.A.A.Minimum = -num;
			this.A.A.Maximum = num;
			this.A.A.Value = 0;
			this.A.A.TickFrequency = num;
			this.A.A.SmallChange = num / 10;
			this.A.A.LargeChange = num / 5;
			this.A.A.Scroll += new EventHandler(this.a);
			this.A.A.MouseUp += new MouseEventHandler(this.A);
			this.A.L(new EventHandler<EventArgs>(this.A));
		}
		public e2 A()
		{
			return this.A;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			this.A.A.Value = this.A.L();
		}
		private void a(object obj, EventArgs eventArgs)
		{
			this.A.L(this.A.A.Value);
		}
		private void A(object obj, MouseEventArgs mouseEventArgs)
		{
			this.A.Focus();
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void A()
		{
			this.A = new e2();
			this.A = new O();
			base.SuspendLayout();
			this.A.AutoScroll = true;
			this.A.AutoScrollMinSize = new Size(4730, 4730);
			this.A.BackColor = SystemColors.Control;
			this.A.BackgroundImageLayout = ImageLayout.None;
			this.A.L(new Point(0, 0));
			this.A.a(null);
			this.A.L(null);
			this.A.Dock = DockStyle.Fill;
			this.A.L(null);
			this.A.L(false);
			this.A.Location = new Point(26, 0);
			this.A.Name = "diagramView";
			this.A.L(null);
			this.A.M(true);
			this.A.Size = new Size(580, 469);
			this.A.TabIndex = 2;
			this.A.L(null);
			this.A.L(0);
			this.A.Dock = DockStyle.Left;
			this.A.Location = new Point(0, 0);
			this.A.Name = "smallTrackbar";
			this.A.Size = new Size(26, 469);
			this.A.TabIndex = 3;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Name = "PapZoomPanel";
			base.Size = new Size(606, 469);
			base.ResumeLayout(false);
		}
	}
	public class e2 : UserControl, T1, s1, IDisposable
	{
		private const float A = 1.15f;
		private const float a = 10f;
		private Q1 A;
		private W1<p1> A;
		private R1 A;
		private i A;
		private A2.A A;
		private Point A = new Point(-2147483648, -2147483648);
		private bool A;
		private static readonly Size A = new Size(600, 600);
		private Matrix A;
		private Matrix a = new Matrix();
		private Matrix B = new Matrix();
		private Point a;
		private Point B;
		private Graphics A;
		private bool a;
		private bool B = K1.A().A().UseNarrowTextFont;
		private k A;
		private F A;
		private static ContextMenuStrip A = null;
		private global::c.b A;
		private bool b = true;
		private EventHandler<EventArgs> A;
		private IContainer A;
		public e2()
		{
			this.O();
			this.A = base.CreateGraphics();
			this.DoubleBuffered = true;
			this.N();
			this.A = new k(this);
			this.L();
		}
		public e2(Q1 q) : this()
		{
			this.L(q);
		}
		~e2()
		{
			this.Dispose();
		}
		public new virtual void Dispose()
		{
			this.L(null);
			base.Dispose();
		}
		public R1 L()
		{
			return this.A;
		}
		public h2 L()
		{
			if (this.L() == null)
			{
				return null;
			}
			return this.L().A();
		}
		public p1 A()
		{
			return this.A;
		}
		public void a(p1 p)
		{
			this.L((Q1)p);
		}
		public Q1 L()
		{
			return this.A;
		}
		public void L(Q1 q)
		{
			if (this.A != q)
			{
				if (this.A != null)
				{
					this.A.a(new Q1.a(this.l));
					this.A.a(new Q1.A(this.L));
					this.A.a(this);
				}
				this.A = q;
				this.l();
				if (this.A() != null)
				{
					this.L().A(this);
					this.f(this.A);
					this.k();
					h2 h = q1.A().A(this.A());
					if (h == null)
					{
						throw new l1();
					}
					this.A = q1.A().A(h);
					if (this.A.A() != h)
					{
						throw new l1();
					}
					this.L().A(new Q1.a(this.l));
					this.L().A(new Q1.A(this.L));
					this.M(!this.A().J());
				}
			}
		}
		public bool L()
		{
			return this.a;
		}
		public void L(bool flag)
		{
			this.a = flag;
		}
		public A2.A L()
		{
			return this.A;
		}
		public void L(A2.A a)
		{
			this.A = a;
		}
		public W1<p1> L()
		{
			return this.A;
		}
		public void L(W1<p1> w)
		{
			this.A = w;
		}
		public Point L()
		{
			return this.a;
		}
		public void L(Point point)
		{
			this.a = point;
			this.B = this.l(this.a);
		}
		public Point l()
		{
			return this.B;
		}
		public F L()
		{
			return this.A;
		}
		public void L(F f)
		{
			if (global::a.F.a(this.A, f))
			{
				return;
			}
			this.l(this.A);
			this.A = f;
			this.l(this.A);
		}
		public k L()
		{
			return this.A;
		}
		public Type L()
		{
			return this.L().GetType();
		}
		public i L()
		{
			return this.A;
		}
		public void L()
		{
			this.L(null);
		}
		public void L(i i)
		{
			this.L(null);
			if (this.A() == null)
			{
				this.A = null;
				return;
			}
			if (i == null)
			{
				this.A = new A1(this, this.A().J());
				return;
			}
			this.A = i;
		}
		public void l()
		{
			this.l(true);
		}
		public void l(bool flag)
		{
			this.L(null);
			this.L().A();
			if (flag && this.A != null)
			{
				this.A.A();
			}
			this.L(null);
			this.Cursor = Cursors.Default;
			this.L();
		}
		public void C()
		{
			if (!base.Visible)
			{
				return;
			}
			base.Invalidate();
		}
		public void E(Rectangle rc)
		{
			if (!base.Visible)
			{
				return;
			}
			if (rc.IsEmpty)
			{
				return;
			}
			base.Invalidate(rc);
		}
		public void e(Rectangle rectangle)
		{
			if (!base.Visible)
			{
				return;
			}
			if (rectangle.IsEmpty)
			{
				return;
			}
			rectangle.Inflate(1, 1);
			base.Invalidate(this.L(rectangle));
		}
		public void c(d.a a, bool flag)
		{
			if (!base.Visible)
			{
				return;
			}
			if (a == null)
			{
				return;
			}
			this.d(a);
			if (flag)
			{
				foreach (D.A a2 in a.d())
				{
					this.d(a2);
				}
			}
		}
		public void d(global::c.a a)
		{
			if (a is global::C.C)
			{
				this.L(((global::C.C)a).A());
			}
			this.L(a);
		}
		private void L(global::c.a a)
		{
			if (!base.Visible)
			{
				return;
			}
			if (a == null)
			{
				return;
			}
			this.e(a.E());
		}
		public void D(IEnumerable enumerable)
		{
			if (!base.Visible)
			{
				return;
			}
			if (enumerable == null)
			{
				return;
			}
			foreach (global::c.a a in enumerable)
			{
				this.d(a);
			}
		}
		public void L(IEnumerable<global::c.a> enumerable)
		{
			if (!base.Visible)
			{
				return;
			}
			if (enumerable == null)
			{
				return;
			}
			foreach (global::c.a current in enumerable)
			{
				this.d(current);
			}
		}
		public void F()
		{
			this.L(true);
			this.C();
		}
		public void f(Graphics graphics)
		{
			this.L().A().A(graphics);
			this.L(false);
			this.C();
		}
		public void M()
		{
			this.f(this.A);
		}
		public void L(p1 p, d.a a)
		{
			this.F();
		}
		public void l(p1 p, d.a a)
		{
			this.F();
		}
		public bool L(d.a a)
		{
			bool flag = false;
			return this.L(a, null, out flag, true);
		}
		public bool L(d.a a, out bool ptr)
		{
			return this.L(a, null, out ptr, false);
		}
		public bool L(d.a a, string text, out bool ptr, bool flag)
		{
			ptr = false;
			bool flag2 = a is global::b.b || a is global::b.a;
			if (!a.d() && !flag2)
			{
				return false;
			}
			if (a is global::c.B)
			{
				return false;
			}
			if (flag)
			{
				return true;
			}
			this.d(a);
			base.Update();
			if (flag2)
			{
				if (!this.A().g(this, this.A, null))
				{
					return false;
				}
			}
			else
			{
				if (a is d.B)
				{
					t1 t = new t1(this, a.G(), (d.B)a, this.L());
					if (t.ShowDialog(this) != DialogResult.OK)
					{
						return false;
					}
					ptr = t.A();
				}
				else
				{
					if (text == null)
					{
						text = a.c();
					}
					D2 d = new D2(this, a.G(), a, text);
					if (d.ShowDialog(this) != DialogResult.OK)
					{
						return false;
					}
				}
			}
			this.L().A().A(this.A, a);
			this.L().A().a(a);
			this.F();
			return true;
		}
		public global::c.b L()
		{
			return this.A;
		}
		public void L(global::c.b b)
		{
			if (this.A != b)
			{
				if (this.A != null)
				{
					this.d(this.A);
					this.d(this.A.A());
				}
				this.A = b;
				if (this.A != null)
				{
					this.d(this.A);
					this.d(this.A.A());
				}
			}
		}
		public p1 L(d.a a, bool flag)
		{
			if (a is d.B)
			{
				foreach (p1 current in this.L())
				{
					if (current is Q1 && Q1.A(a.c(), current.b()))
					{
						p1 result;
						if (flag && current == this.A())
						{
							result = null;
							return result;
						}
						result = current;
						return result;
					}
				}
			}
			return null;
		}
		public bool l(d.a a)
		{
			p1 p = this.L(a, true);
			if (p == null)
			{
				return false;
			}
			this.l();
			b2.A().A(p);
			return true;
		}
		public Point I()
		{
			return new Point(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y);
		}
		public void i(Point autoScrollPosition)
		{
			base.AutoScrollPosition = autoScrollPosition;
		}
		private void m()
		{
			this.L(this.J());
		}
		private void L(float num)
		{
			this.a.Reset();
			this.a.Translate((float)base.AutoScrollPosition.X, (float)base.AutoScrollPosition.Y);
			this.a.Scale(num, num);
			this.B.Dispose();
			this.B = this.a.Clone();
			this.B.Invert();
		}
		private void N()
		{
			Point[] array = new Point[]
			{
				new Point(k1.A)
			};
			this.a.TransformVectors(array);
			base.AutoScrollMinSize = new Size(array[0].X, array[0].Y);
		}
		public Rectangle g(Rectangle rectangle, ref float ptr, out Point ptr2, bool flag)
		{
			Rectangle result = this.G(flag);
			if (!flag)
			{
				if (e2.A.Width > result.Width)
				{
					result.Inflate((e2.A.Width - result.Width) / 2, 0);
				}
				if (e2.A.Height > result.Height)
				{
					int num = 90;
					int num2 = e2.A.Height - result.Height;
					int num3 = num2 * (100 - num) / 100;
					result.Y -= num3;
					result.Height += num3 + num2 * num / 100;
				}
			}
			if (ptr == 0f)
			{
				float val = (float)rectangle.Width / (float)result.Width;
				float val2 = (float)rectangle.Height / (float)result.Height;
				float num4 = 1f;
				ptr = Math.Min(val2, val) * num4;
			}
			int x = (rectangle.Left + rectangle.Right) / 2 - (int)(ptr * (float)(result.Left + result.Right)) / 2;
			int y = (rectangle.Top + rectangle.Bottom) / 2 - (int)(ptr * (float)(result.Top + result.Bottom)) / 2;
			ptr2 = new Point(x, y);
			return result;
		}
		public bool K()
		{
			float num = 0f;
			Point point;
			this.g(base.ClientRectangle, ref num, out point, false);
			return this.a.Elements[0] != num || this.a.OffsetX != (float)point.X || this.a.OffsetY != (float)point.Y;
		}
		public void k()
		{
			float num = 0f;
			Point point;
			this.g(base.ClientRectangle, ref num, out point, false);
			this.l(num);
			base.AutoScrollPosition = new Point(-point.X, -point.Y);
		}
		public Rectangle G(bool flag)
		{
			if (this.A() == null || this.L().A() == 0)
			{
				int num = 5;
				return new Rectangle(k1.A.Width * (num - 1) / num / 2, k1.A.Height * (num - 1) / num / 2, k1.A.Width / num, k1.A.Height / num);
			}
			Rectangle result = this.L().A().A();
			int num2 = flag ? 15 : 45;
			result.Inflate(num2, num2);
			return result;
		}
		public int L()
		{
			if (base.DesignMode)
			{
				return 0;
			}
			return this.L(this.J());
		}
		public void L(int val)
		{
			if (base.DesignMode)
			{
				return;
			}
			int num = Math.Min(180, Math.Max(-180, val));
			float num2 = (float)Math.Pow(1.1499999761581421, (double)((float)num / 10f));
			this.l(num2);
		}
		public bool l()
		{
			return this.b;
		}
		public void M(bool flag)
		{
			this.b = flag;
			this.C();
		}
		private int L(float num)
		{
			return (int)Math.Round(Math.Log((double)num, 1.1499999761581421) * 10.0);
		}
		public float J()
		{
			if (base.DesignMode)
			{
				return 1f;
			}
			return this.a.Elements[0];
		}
		public void j(float num)
		{
			this.l(num);
		}
		public void l(float num)
		{
			if (base.DesignMode)
			{
				return;
			}
			if (this.J() != num)
			{
				int num2 = this.L(num);
				if (num2 > 180)
				{
					this.L(180);
					return;
				}
				if (num2 < -180)
				{
					this.L(-180);
					return;
				}
				PointF pointF = new PointF((float)(base.ClientRectangle.Width / 2), (float)(base.ClientRectangle.Height / 2));
				this.L(this.J());
				PointF pointF2 = this.l(pointF);
				this.L(num);
				PointF pointF3 = this.l(pointF);
				RectangleF rectangleF = new RectangleF(0f, 0f, pointF2.X - pointF3.X, pointF2.Y - pointF3.Y);
				rectangleF = this.L(rectangleF);
				this.N();
				this.A = new Point(-2147483648, -2147483648);
				this.C();
				Point autoScrollPosition = new Point(-base.AutoScrollPosition.X + (int)rectangleF.Width, -base.AutoScrollPosition.Y + (int)rectangleF.Height);
				base.AutoScrollPosition = autoScrollPosition;
				if (this.A != null)
				{
					this.A(this, new EventArgs());
				}
			}
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void L(EventHandler<EventArgs> eventHandler)
		{
			this.A = (EventHandler<EventArgs>)Delegate.Combine(this.A, eventHandler);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void l(EventHandler<EventArgs> value)
		{
			this.A = (EventHandler<EventArgs>)Delegate.Remove(this.A, value);
		}
		public PointF L(PointF pointF)
		{
			PointF[] array = new PointF[]
			{
				pointF
			};
			this.a.TransformPoints(array);
			return array[0];
		}
		public Point L(Point point)
		{
			Point[] array = new Point[]
			{
				point
			};
			this.a.TransformPoints(array);
			return array[0];
		}
		public RectangleF L(RectangleF rectangleF)
		{
			PointF[] array = new PointF[]
			{
				new PointF(rectangleF.Width, rectangleF.Height)
			};
			this.a.TransformVectors(array);
			return new RectangleF(this.L(rectangleF.Location), new SizeF(array[0].X, array[0].Y));
		}
		public Rectangle L(Rectangle rectangle)
		{
			Point[] array = new Point[]
			{
				new Point(rectangle.Width, rectangle.Height)
			};
			this.a.TransformVectors(array);
			return new Rectangle(this.L(rectangle.Location), new Size(array[0].X, array[0].Y));
		}
		public PointF l(PointF pointF)
		{
			PointF[] array = new PointF[]
			{
				pointF
			};
			this.B.TransformPoints(array);
			return array[0];
		}
		public Point l(Point point)
		{
			Point[] array = new Point[]
			{
				point
			};
			this.B.TransformPoints(array);
			return array[0];
		}
		public RectangleF l(RectangleF rectangleF)
		{
			PointF[] array = new PointF[]
			{
				new PointF(rectangleF.Width, rectangleF.Height)
			};
			this.B.TransformVectors(array);
			return new RectangleF(this.l(rectangleF.Location), new SizeF(array[0].X, array[0].Y));
		}
		public Rectangle l(Rectangle rectangle)
		{
			Point[] array = new Point[]
			{
				new Point(rectangle.Width, rectangle.Height)
			};
			this.B.TransformVectors(array);
			return new Rectangle(this.l(rectangle.Location), new Size(array[0].X, array[0].Y));
		}
		public Rectangle L(Point point, Point point2)
		{
			Rectangle rectangle = new Rectangle(point.X, point.Y, 0, 0);
			Rectangle rectangle2 = new Rectangle(point2.X, point2.Y, 0, 0);
			return Rectangle.Union(rectangle, rectangle2);
		}
		public void L(Rectangle rectangle)
		{
			rectangle.Location = base.PointToScreen(rectangle.Location);
			ControlPaint.DrawReversibleFrame(rectangle, this.BackColor, FrameStyle.Dashed);
		}
		public Rectangle l(Point point, Point point2)
		{
			Rectangle rectangle = this.L(point, point2);
			this.L(rectangle);
			return rectangle;
		}
		private void L(object obj, EventArgs eventArgs)
		{
			this.A = true;
		}
		public static void L(e2 e, Point position)
		{
			if (e2.A == null)
			{
				ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
				S.A().a(contextMenuStrip.Items);
				r.A().a(contextMenuStrip.Items);
				s.A().a(contextMenuStrip.Items);
				T.A().a(contextMenuStrip.Items);
				e2.A = contextMenuStrip;
				e2.A.Opened += new EventHandler(P.F);
				e2.A.Closing += new ToolStripDropDownClosingEventHandler(e2.L);
			}
			e2.A.Tag = e;
			e2.n();
			e2.A.Show(e, position);
		}
		private static void n()
		{
			e2 e = (e2)e2.A.Tag;
			h2 h = e.L();
			e.l(e.L());
			if (e.L().A())
			{
				S.A().A(h, e, false);
				r.A().A(h, e.L());
				s.A().A(h, e.L());
				T.A().A(h, e);
				return;
			}
			if (e.L().a() && (e.L().A() is global::b.b || e.L().A() is global::b.a))
			{
				S.A().d();
				r.A().A(h, e.L());
				s.A().A(h, e.L());
				T.A().d();
				return;
			}
			S.A().A(h, e, false);
			r.A().d();
			s.A().d();
			T.A().d();
		}
		private static void L(object obj, CancelEventArgs cancelEventArgs)
		{
			e2 e = e2.A.Tag as e2;
			if (e != null)
			{
				global::c.a a = e.L().A();
				H2 h = e.L().A();
				e.l();
				if (h != null)
				{
					e.L().A(h);
					return;
				}
				e.L().A(a);
			}
		}
		private void L(object obj, KeyEventArgs keyEventArgs)
		{
			try
			{
				if (this.L() != null)
				{
					this.L().a(keyEventArgs);
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
			}
		}
		private void l(object obj, KeyEventArgs keyEventArgs)
		{
			if (this.L() == null)
			{
				return;
			}
			this.L().b();
		}
		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs)
		{
			try
			{
				if (this.L() != null)
				{
					this.L().C(mouseEventArgs);
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
			}
		}
		private void l(object obj, EventArgs eventArgs)
		{
			try
			{
				if (!this.Focused)
				{
					base.Focus();
				}
				if (this.L() != null)
				{
					this.L().E();
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
			}
		}
		private void L(object obj, MouseEventArgs mouseEventArgs)
		{
			try
			{
				if (!this.Focused)
				{
					base.Focus();
				}
				this.L(new Point(mouseEventArgs.X, mouseEventArgs.Y));
				if (this.L() != null)
				{
					this.L().c(mouseEventArgs);
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
			}
		}
		private void l(object obj, MouseEventArgs mouseEventArgs)
		{
			try
			{
				if (!this.Focused)
				{
					base.Focus();
				}
				if (this.L() != null)
				{
					this.L().D(mouseEventArgs);
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
			}
		}
		private void M(object obj, MouseEventArgs mouseEventArgs)
		{
			try
			{
				if (this.L() != null)
				{
					this.L().d(mouseEventArgs);
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
			}
		}
		private void M(object obj, EventArgs eventArgs)
		{
			try
			{
				if (this.L() != null)
				{
					this.L().e();
				}
			}
			catch (Exception ex)
			{
				n1.A(ex);
			}
		}
		protected override void OnPaint(PaintEventArgs paintEventArgs)
		{
			if (base.DesignMode)
			{
				base.OnPaint(paintEventArgs);
				return;
			}
			Graphics graphics = paintEventArgs.Graphics;
			if (this.B != K1.A().A().UseNarrowTextFont)
			{
				this.B = K1.A().A().UseNarrowTextFont;
				this.f(graphics);
				base.Invalidate();
				return;
			}
			if (this.L())
			{
				this.L().A().A(graphics);
				this.L(false);
			}
			if (this.A)
			{
				this.A = false;
				this.k();
			}
			if (this.A != base.AutoScrollPosition)
			{
				this.A = base.AutoScrollPosition;
				this.m();
			}
			this.A = graphics.Transform;
			graphics.Transform = this.a;
			B1 b = this.A().G(this, graphics, a1.Screen, false);
			this.L(b);
		}
		public void L(B1 b)
		{
			Graphics graphics = b.A();
			if (this.A() == null)
			{
				return;
			}
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (this.l() && !b.b())
			{
				this.L(graphics, this.G(b.C()));
			}
			List<d.a> list = new List<d.a>(this.L().A());
			F2 f = this.L().A();
			if (graphics.ClipBounds.IntersectsWith(f.A().L()))
			{
				list.Add(f.A());
			}
			for (int i = 0; i < this.L().A().h(); i++)
			{
				Y1 y = f.h(i);
				if ((float)y.a() >= graphics.ClipBounds.Left)
				{
					if ((float)y.A() > graphics.ClipBounds.Right)
					{
						break;
					}
					for (int j = 0; j < this.L().A().I(); j++)
					{
						Y1 y2 = f.I(j);
						if ((float)y2.a() >= graphics.ClipBounds.Top)
						{
							if ((float)y2.A() > graphics.ClipBounds.Bottom)
							{
								break;
							}
							f2 f2 = f.a(i, j);
							if (f2 != null && !graphics.ClipBounds.IntersectsWith(f2.A))
							{
								d.a a = f2.A;
								if (a != f.A() && (!b.c() || this.L().A(a)))
								{
									list.Add(f2.A);
								}
							}
						}
					}
				}
			}
			foreach (d.a current in list)
			{
				current.Y(b, false, true);
			}
			this.L().A(this, b);
			foreach (d.a current2 in list)
			{
				current2.Y(b, true, false);
			}
			if (this.L() is j)
			{
				graphics.Transform = this.A;
				j j2 = (j)this.L();
				j2.a(graphics);
				graphics.Transform = this.a;
			}
			if (global::a.F.B(this.L(), null))
			{
				this.L(graphics, this.L());
			}
			if (this.L() != null)
			{
				this.L().Y(b, true, true);
			}
		}
		private void L(Graphics graphics, f2 f)
		{
			F2 f2 = this.L().A();
			D.C c = f2.E(f.A.a(), f.a.a());
			F f3 = new F(f2, c);
			this.L(graphics, f3);
		}
		private void L(Graphics graphics, F f)
		{
			Point point;
			Rectangle rectangle = f.a(out point);
			Pen pen = global::c.C.b;
			graphics.DrawLine(pen, point.X, rectangle.Y, point.X, rectangle.Y + rectangle.Height);
			graphics.DrawLine(pen, rectangle.X, point.Y, rectangle.X + rectangle.Width, point.Y);
		}
		private void l(F f)
		{
			if (global::a.F.B(f, null))
			{
				Point point;
				Rectangle rectangle = f.a(out point);
				this.e(rectangle);
			}
		}
		public void L(Graphics graphics, Rectangle rectangle)
		{
			Rectangle rectangle2 = rectangle;
			Pen pen = global::c.C.A(this.BackColor);
			int num = 2;
			foreach (Y1 y in (IEnumerable)this.L().A().h())
			{
				if ((float)(y.B() + num) >= graphics.ClipBounds.Left)
				{
					if ((float)(y.B() - num) > graphics.ClipBounds.Right)
					{
						break;
					}
					graphics.DrawLine(pen, y.B(), rectangle2.Y, y.B(), rectangle2.Y + rectangle2.Height);
				}
			}
			foreach (Y1 y2 in (IEnumerable)this.L().A().h())
			{
				if ((float)(y2.B() + num) >= graphics.ClipBounds.Top)
				{
					if ((float)(y2.B() - num) > graphics.ClipBounds.Bottom)
					{
						break;
					}
					graphics.DrawLine(pen, rectangle2.X, y2.B(), rectangle2.X + rectangle2.Width, y2.B());
				}
			}
		}
		public void H(Rectangle rectangle, float num, B1 b)
		{
			Point point;
			this.g(rectangle, ref num, out point, b.C());
			Matrix matrix = new Matrix();
			matrix.Scale(num, num);
			matrix.Translate((float)point.X, (float)point.Y, MatrixOrder.Append);
			b.A().Transform = matrix;
			b.A().SetClip(this.L().A().A());
			this.L((b1)b);
		}
		public static Bitmap L(e2 e, Rectangle rectangle)
		{
			if (rectangle.Width <= 0 || rectangle.Height <= 0)
			{
				return null;
			}
			Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
			Matrix matrix = new Matrix();
			float num = e.J();
			matrix.Translate((float)(e.AutoScrollPosition.X - rectangle.X), (float)(e.AutoScrollPosition.Y - rectangle.Y));
			matrix.Scale(num, num);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Transform = matrix;
			B1 b = e.A().G(e, graphics, a1.Clip, true);
			b.A().SetClip(e.l(rectangle));
			e.L(b);
			return bitmap;
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void O()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.AutoScroll = true;
			base.AutoScrollMinSize = new Size(5000, 5000);
			this.BackColor = SystemColors.Control;
			this.BackgroundImageLayout = ImageLayout.None;
			this.DoubleBuffered = true;
			base.Name = "PapDiagramView";
			base.Size = new Size(199, 71);
			base.Load += new EventHandler(this.L);
			base.MouseDown += new MouseEventHandler(this.L);
			base.MouseMove += new MouseEventHandler(this.l);
			base.MouseEnter += new EventHandler(this.l);
			base.KeyUp += new KeyEventHandler(this.l);
			base.MouseLeave += new EventHandler(this.M);
			base.MouseUp += new MouseEventHandler(this.M);
			base.KeyDown += new KeyEventHandler(this.L);
			base.ResumeLayout(false);
		}
		Rectangle T1.h()
		{
			return base.ClientRectangle;
		}
		Control s1.B()
		{
			return base.Parent;
		}
		Form s1.b()
		{
			return base.FindForm();
		}
	}
}
