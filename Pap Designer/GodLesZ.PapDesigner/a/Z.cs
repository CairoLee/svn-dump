using System;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class Z : i
	{
		private new Rectangle A;
		public Z(e2 e, Point point) : base(e)
		{
			if (e.A().J())
			{
				throw new l1();
			}
			e.Cursor = X.A().B();
			base.F(point);
			this.A = e.l(this.A, this.B);
		}
		public override void A(bool flag)
		{
			this.A.L(this.A);
			if (this.A.Width <= 0 || this.A.Height <= 0)
			{
				flag = false;
			}
			base.A(flag);
			if (!(this.A.L() is A1))
			{
				throw new l1();
			}
			if (flag)
			{
				H2 h = new H2(this.A.L().A(), this.A.l(this.A), true);
				if (h.a() > 0)
				{
					this.A.L().A(h);
				}
			}
		}
		public override void C(MouseEventArgs mouseEventArgs)
		{
		}
		public override void D(MouseEventArgs mouseEventArgs)
		{
			base.D(mouseEventArgs);
			this.A.L(this.A);
			this.A = this.A.l(this.A, this.B);
		}
	}
	public class z : i
	{
		private new Type A;
		private new Cursor A;
		private new Cursor a;
		private new Cursor B = Cursors.No;
		private new F A;
		private new F a;
		public z(e2 e, Type type) : base(e)
		{
			if (e.A().J())
			{
				throw new l1();
			}
			this.A = type;
			this.A = X.A().A(type);
			this.a = X.A().a(type);
			e.Cursor = this.A;
		}
		public override void A(bool flag)
		{
			bool flag2 = false;
			try
			{
				if (flag)
				{
					this.A.L(null);
					flag2 = this.A.L().A(this.A, this.A, this.A);
				}
			}
			finally
			{
				base.A(flag2);
			}
		}
		public new Type a()
		{
			return this.A;
		}
		public override void C(MouseEventArgs mouseEventArgs)
		{
			base.C(mouseEventArgs);
		}
		public override void c(MouseEventArgs mouseEventArgs)
		{
			this.a = null;
			this.D(mouseEventArgs);
			this.A(global::a.F.B(this.A, null) && mouseEventArgs.Button == MouseButtons.Left);
		}
		public override void D(MouseEventArgs mouseEventArgs)
		{
			base.D(mouseEventArgs);
			Point point = this.A.l(this.B);
			F f = this.A.L().A().A(point);
			if (global::a.F.a(this.a, f))
			{
				return;
			}
			this.a = f;
			if (!this.A.L().a(this.A, f))
			{
				f = null;
			}
			if (global::a.F.B(f, null))
			{
				if (f.a() != null)
				{
					this.A.Cursor = this.a;
				}
				else
				{
					this.A.Cursor = this.A;
				}
			}
			else
			{
				this.A.Cursor = this.B;
			}
			this.A.L(this.A = f);
		}
		public override void d(MouseEventArgs mouseEventArgs)
		{
		}
		public override void e()
		{
			if (K1.A().A().ToolCursorExitOnLeave)
			{
				H2 h = this.A.L().A();
				this.A(false);
				this.A.L().A(h);
			}
		}
	}
}
