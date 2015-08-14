using d;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class J : i
	{
		private new static Q1 A;
		public J(e2 e) : base(e)
		{
			if (!e.A().J())
			{
				throw new l1();
			}
		}
		public override void c(MouseEventArgs mouseEventArgs)
		{
			base.D(mouseEventArgs);
			h2 h = q1.A().A(this.A.A());
			if (mouseEventArgs.Button == MouseButtons.Left && J.A != this.A.A())
			{
				string text = "";
				if (h.e())
				{
					text += "Dieses Diagramm ist geschützt\n";
				}
				else
				{
					text += "Dieses Diagramm ist vom Autor geschützt worden\n";
				}
				text += "und kann daher nicht bearbeitet werden.";
				v.A(this.A, text);
				J.A = this.A.L();
				return;
			}
			if (mouseEventArgs.Button == MouseButtons.Right)
			{
				this.A.l();
				e2.L(this.A, this.A.L());
			}
		}
	}
	public class j : i
	{
		private new H2 A;
		private new H2 a;
		private new d.a A;
		private new bool A;
		private new bool a;
		private new bool B;
		private new F A;
		private new F a;
		private new bool b;
		public new I A;
		private new Point? A = null;
		private new Rectangle A = Rectangle.Empty;
		private new Rectangle a = Rectangle.Empty;
		private new Rectangle B = Rectangle.Empty;
		private new bool C;
		private new Size A = new Size(0, 0);
		public j(e2 e, MouseEventArgs mouseEventArgs, KeyEventArgs keyEventArgs, bool flag, bool flag2) : base(e, keyEventArgs)
		{
			this.A = e.L().A();
			this.A = this.A.A();
			this.A = flag;
			this.a = flag2;
			if (e.A().J())
			{
				throw new l1();
			}
			if (this.A == null)
			{
				throw new l1();
			}
			if (this.A.A() == null)
			{
				throw new l1();
			}
			if (mouseEventArgs == null)
			{
				throw new l1();
			}
			this.A = e.L(this.A.A());
			Bitmap bitmap = e2.L(e, this.A);
			this.A = new I(bitmap, 0.5f);
			this.c(mouseEventArgs);
			this.B();
		}
		public override void A(bool flag)
		{
			try
			{
				if (this.A != null)
				{
					this.a = Rectangle.Empty;
					this.C = false;
					this.A.E(this.B);
					this.A.A();
					this.A = null;
				}
				if (flag)
				{
					this.A.L(null);
					string str = (this.A.a() > 1) ? "Auswahl" : "Symbol";
					if (this.B)
					{
						this.A.L().A(this.A, this.a(), this.A, str + " repliziern");
					}
					else
					{
						this.A.L().a(this.A, this.A, this.A, str + " verschieben");
					}
				}
			}
			finally
			{
				base.A(flag);
			}
		}
		public override bool B()
		{
			this.B = (this.A != null && (this.A.KeyData & Keys.Control) == Keys.Control && this.A.L().E());
			this.a();
			return base.B();
		}
		public override void C(MouseEventArgs mouseEventArgs)
		{
		}
		public override void c(MouseEventArgs mouseEventArgs)
		{
			this.a = null;
			base.c(mouseEventArgs);
			if (this.A.HasValue)
			{
				this.A(false);
				return;
			}
			this.a();
			Point point = this.A.l(this.B);
			this.A = new Size(this.A.d() - point.X, this.A.G() - point.Y);
			this.a = this.A;
			this.C = true;
			this.A.E(this.a);
			this.A = new Point?(this.B);
		}
		public override void D(MouseEventArgs mouseEventArgs)
		{
			base.D(mouseEventArgs);
			if (!this.A)
			{
				this.B.X = this.A.X;
			}
			if (!this.a)
			{
				this.B.Y = this.A.Y;
			}
			this.a();
			Point value = this.A.Value;
			this.a.Offset(this.B.X - value.X, this.B.Y - value.Y);
			this.A.E(this.B);
			this.A.E(this.a);
			this.A = new Point?(new Point(this.B.X, this.B.Y));
		}
		public override void d(MouseEventArgs mouseEventArgs)
		{
			bool flag = global::a.F.B(this.A, null) && mouseEventArgs.Button == MouseButtons.Left;
			this.A(flag);
			this.A = null;
		}
		private new H2 a()
		{
			if (this.a == null)
			{
				this.a = this.A.A();
				this.a.a();
			}
			return this.a;
		}
		private new void a()
		{
			Point point = this.A.l(this.B);
			point += this.A;
			F f = this.A.L().A().A(point);
			if (global::a.F.a(this.a, f) && this.b == this.B)
			{
				return;
			}
			this.a = f;
			this.b = this.B;
			bool flag = false;
			if (global::a.F.B(f, null) && f.a() && this.A.L().A().A(this.A) == f.a())
			{
				flag = true;
				f = null;
			}
			if (global::a.F.B(f, null))
			{
				if (this.B)
				{
					if (!this.A.L().A(this.a(), f))
					{
						f = null;
					}
				}
				else
				{
					if (!this.A.L().A(this.A.L(), f))
					{
						f = null;
					}
				}
			}
			if (global::a.F.B(f, null) || flag)
			{
				this.A.Cursor = (this.B ? X.A().b() : X.A().C());
			}
			else
			{
				this.A.Cursor = Cursors.No;
			}
			this.A.L(this.A = f);
		}
		public new void a(Graphics graphics)
		{
			if (this.C)
			{
				this.A.A(graphics, this.a.Location);
				this.B = this.a;
			}
		}
	}
}
