using A;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class Y
	{
		private static Y A = null;
		private ComponentResourceManager A;
		private static readonly string[] A = new string[]
		{
			"Ablaufplan",
			"Verzweigungen",
			"Schleifen",
			"Unterprogramme",
			"Programmierung"
		};
		private Y()
		{
			this.A = new ComponentResourceManager(typeof(global::A.B));
		}
		public static Y A()
		{
			if (Y.A == null)
			{
				Y.A = new Y();
			}
			return Y.A;
		}
		public string[] A()
		{
			return Y.A;
		}
		public byte[] A(string str)
		{
			byte[] result;
			try
			{
				result = (byte[])this.A.GetObject("Tutorial_" + str);
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
	}
	public class y : i
	{
		private new string A;
		private new Cursor A;
		private new H2 A;
		private new F A;
		private new F a;
		public y(H2 h, e2 e, string text) : base(e)
		{
			if (e.A().J())
			{
				throw new l1();
			}
			this.A = h;
			if (h == null)
			{
				throw new l1();
			}
			this.A = text;
			this.A = X.A().a();
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
					flag2 = this.A.L().A(this.A, this.A, this.A, this.A);
				}
			}
			finally
			{
				base.A(flag2);
			}
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
			if (global::a.F.B(f, null) && !this.A.L().A(this.A, f))
			{
				f = null;
			}
			this.A.Cursor = (global::a.F.a(f, null) ? Cursors.No : this.A);
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
