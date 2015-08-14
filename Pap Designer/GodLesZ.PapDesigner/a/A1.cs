using c;
using d;
using D;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class A1 : i
	{
		private new static Q1 A;
		private new bool A;
		private new global::c.b A;
		private new global::c.a A;
		private new d.a A;
		private new bool a;
		private new bool B;
		public A1(e2 e, bool flag) : base(e)
		{
			this.A = flag;
			if (e.A().J() != this.A)
			{
				throw new l1();
			}
			this.a = !K1.A().A().DoubleClickAction;
		}
		public override void c(MouseEventArgs mouseEventArgs)
		{
			this.B = false;
			base.c(mouseEventArgs);
			this.D(mouseEventArgs);
			if (this.A != null)
			{
				if (mouseEventArgs.Button == MouseButtons.Left && mouseEventArgs.Clicks == 1)
				{
					global::c.b b = this.A.L();
					if (!b.A)
					{
						b.A = true;
						this.A.L().A(this.A, b.A(), b.A());
						this.A.L(null);
						this.A.C();
					}
				}
				return;
			}
			if (!this.A.L().A(this.A))
			{
				if (this.A == null)
				{
					this.A.l();
					if (!this.A && mouseEventArgs.Button == MouseButtons.Left)
					{
						this.A.L(new Z(this.A, this.B));
						return;
					}
					if (mouseEventArgs.Button == MouseButtons.Right)
					{
						this.A(this.A, this.B);
						return;
					}
				}
				if (this.A)
				{
					if (mouseEventArgs.Button == MouseButtons.Left && A1.A != this.A.A())
					{
						this.A();
						A1.A = this.A.L();
						return;
					}
					if (mouseEventArgs.Button == MouseButtons.Right)
					{
						this.A(this.A, this.A.L());
					}
				}
				return;
			}
			if (this.A is d.a)
			{
				this.A.L().A().A((d.a)this.A);
			}
			if (this.A.L().a() && mouseEventArgs.Button == MouseButtons.Left && (mouseEventArgs.Clicks == 2 || this.A is D.A))
			{
				this.A(this.A, mouseEventArgs.Clicks == 1);
				return;
			}
			if (mouseEventArgs.Button == MouseButtons.Right && mouseEventArgs.Clicks == 1)
			{
				this.A(this.A, this.B);
				return;
			}
			if (!this.A && mouseEventArgs.Button == MouseButtons.Left && mouseEventArgs.Clicks == 1)
			{
				this.A = this.A.L().A();
				this.A.Cursor = X.A().A();
			}
			if (this.A is d.a && this.A.L().a())
			{
				this.B = true;
			}
		}
		public override void D(MouseEventArgs mouseEventArgs)
		{
			base.D(mouseEventArgs);
			Point point = this.A.l(this.A);
			Point point2 = this.A.l(this.B);
			if (!this.A && this.A != null)
			{
				if (this.A.p(point))
				{
					if (this.A.p(point) && i.F(this.A, this.B))
					{
						if (this.A.L().d())
						{
							i i = new j(this.A, mouseEventArgs, this.A, this.A.L().c(), this.A.L().D());
							this.A.L(i);
						}
						else
						{
							if (this.A.L().B())
							{
								v.A(null, "Für die ausgewählten Symbole ist eine Verschiebung nicht möglich.");
							}
						}
						this.A = null;
					}
					return;
				}
				this.A = null;
			}
			this.A = (this.A ? null : this.A.L().A(point2));
			if (this.A == null && this.A.L() != null && this.A.L().p(point2))
			{
				this.A = this.A.L();
			}
			if (this.A.L() != this.A)
			{
				this.A.L(this.A);
			}
			this.A = ((this.A != null) ? this.A.A() : null);
			if (this.A == null)
			{
				this.A = this.A.L().A(point2);
			}
			if (this.A == null)
			{
				if (this.A.L().a() && (this.A.L().A() == null || !this.A.L().A().D()) && !this.A.L().A().E().Contains(point2))
				{
					this.A.L().A();
					return;
				}
			}
			else
			{
				if (!this.A.L().A(this.A) && (this.A is d.a || !this.A.L().B()) && (!this.A || this.A.L(this.A as d.a, true) != null))
				{
					this.A.L().A(this.A);
				}
			}
		}
		public override void d(MouseEventArgs mouseEventArgs)
		{
			this.A.Cursor = Cursors.Default;
			this.A = null;
			if (this.B && mouseEventArgs.Button == MouseButtons.Left && !(this.A is D.A))
			{
				this.A(this.A, true);
			}
		}
		private new void A(global::c.a a, bool flag)
		{
			if (this.a != flag)
			{
				return;
			}
			if (a is d.a)
			{
				d.a a2 = (d.a)a;
				if (a2 is d.B && K1.A().A().FollowModuleLinkOnClick && this.A.l(a2))
				{
					return;
				}
				if (!this.A && this.A.L(a2))
				{
					this.A.L().A(this.A, a2);
					return;
				}
			}
			if (!this.A && a is D.A)
			{
				D.A a3 = (D.A)a;
				this.A.L().A(this.A, a3);
			}
		}
		private new void A()
		{
			h2 h = q1.A().A(this.A.A());
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
		}
		private new void A(e2 e, Point point)
		{
			if (this.A)
			{
				e.L().A();
			}
			e2.L(e, point);
		}
	}
	public enum a1
	{
		Screen,
		Paper,
		Picture,
		Clip = 4
	}
}
