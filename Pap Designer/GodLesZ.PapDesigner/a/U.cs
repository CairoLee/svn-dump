using C;
using d;
using D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class U : P
	{
		private new static U A;
		private new q1 A = q1.A();
		private new Dictionary<Type, x> A;
		private new h2 A;
		private new e2 A;
		private new d.a A;
		private new x A;
		private new x a;
		private new x B;
		private new x b;
		private U()
		{
			this.A = this.A("Eingabe", "Symbol in Eingabe umwandeln", "sym_in_16", new EventHandler(this.A));
			this.a = this.A("Ausgabe", "Symbol in Ausgabe umwandeln", "sym_out_16", new EventHandler(this.A));
			this.B = this.A("Vorgang", "Symbol in Vorgang umwandeln", "sym_act_16", new EventHandler(this.A));
			this.b = this.A("Unterprogramm", "Symbol in Unterprogramm umwandeln", "sym_mod_16", new EventHandler(this.A));
			this.A = new Dictionary<Type, x>();
			this.A.Add(typeof(D.b), this.A);
			this.A.Add(typeof(global::C.c), this.a);
			this.A.Add(typeof(d.b), this.B);
			this.A.Add(typeof(d.B), this.b);
			foreach (Type current in this.A.Keys)
			{
				this.A[current].A(current);
			}
		}
		public static U A()
		{
			if (U.A == null)
			{
				U.A = new U();
			}
			return U.A;
		}
		public void A(h2 h, e2 e, d.a a)
		{
			this.A = h;
			this.A = e;
			this.A = a;
			if (e.L().J())
			{
				this.d();
				return;
			}
			this.D();
			this.A.A(h);
			foreach (Type current in this.A.Keys)
			{
				x x = this.A[current];
				x.A(a.GetType() != (Type)x.A());
			}
		}
		private void A(object obj, EventArgs eventArgs)
		{
			ToolStripDropDownItem toolStripDropDownItem = (ToolStripDropDownItem)obj;
			x x = (x)toolStripDropDownItem.Tag;
			Type type = (Type)x.A();
			R1 r = this.A.A(this.A);
			F f = this.A.L().A().A(this.A, G2.None);
			if (!this.A.L().A(type, f))
			{
				f = null;
			}
			if (global::a.F.B(f, null))
			{
				r.A(this.A, type, f);
			}
		}
	}
	public class u
	{
		private const int A = 12;
		public static void A(Form form, Rectangle rectangle)
		{
			Rectangle rectangle2 = u.A(rectangle);
			Point location = form.Location;
			if (rectangle.Width >= rectangle.Height)
			{
				int num = (rectangle.Bottom + rectangle.Top) / 2;
				int num2 = (rectangle2.Bottom + rectangle2.Top) / 2;
				if (num2 > num)
				{
					location.Y = rectangle.Bottom + 12;
				}
				else
				{
					location.Y = rectangle.Y - form.Height - 12;
				}
				location.X = rectangle.Left + (rectangle.Width - form.Width) / 2;
			}
			else
			{
				int num3 = (rectangle.Right + rectangle.Left) / 2;
				int num4 = (rectangle2.Right + rectangle2.Left) / 2;
				if (num4 > num3)
				{
					location.X = rectangle.Right + 12;
				}
				else
				{
					location.X = rectangle.X - form.Width - 12;
				}
				location.Y = rectangle.Top + (rectangle.Height - form.Height) / 2;
			}
			form.Location = location;
			u.a(form, rectangle2);
		}
		public static void A(Form form)
		{
			u.a(form, u.A(Rectangle.Empty));
		}
		public static void a(Form form, Rectangle rectangle)
		{
			Point location = form.Location;
			if (location.X < rectangle.Left)
			{
				location.X = rectangle.Left;
			}
			else
			{
				if (location.X + form.Width > rectangle.Right)
				{
					location.X = rectangle.Right - form.Width;
				}
			}
			if (location.Y < rectangle.Top)
			{
				location.Y = rectangle.Top;
			}
			else
			{
				if (location.Y + form.Height > rectangle.Bottom)
				{
					location.Y = rectangle.Bottom - form.Height;
				}
			}
			form.Location = location;
		}
		private static Rectangle A(Rectangle rectangle)
		{
			Form form = q1.A().A();
			Rectangle result = new Rectangle(form.Location, form.Size);
			Screen screen = Screen.FromControl(form);
			if (rectangle != Rectangle.Empty)
			{
				screen = Screen.FromRectangle(rectangle);
			}
			result.Intersect(screen.WorkingArea);
			result.Inflate(-12, -12);
			return result;
		}
	}
}
