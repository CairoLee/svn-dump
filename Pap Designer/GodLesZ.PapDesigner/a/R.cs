using System;
using System.Windows.Forms;
namespace a
{
	public class R : P
	{
		private new static R A;
		private new q1 A = q1.A();
		private new h2 A;
		private new x A;
		private new x a;
		private R()
		{
			this.A = this.A("Neues Diagramm erstellen...", "", "DiagramNew", new EventHandler(this.A));
			this.a = this.A("Diagramm {0} einfügen", "...aus der Zwischenablage", "EditPaste", new EventHandler(this.a));
		}
		public static R A()
		{
			if (R.A == null)
			{
				R.A = new R();
			}
			return R.A;
		}
		public void A(h2 h)
		{
			this.A = h;
			bool flag = R.A(this.a);
			this.D();
			bool flag2 = h != null && !h.F();
			this.A.A(flag2);
			this.a.A(flag2 && flag);
			this.b();
		}
		private void A(object obj, EventArgs eventArgs)
		{
			p1 p = this.A.E();
			string text = obj.ToString().Split(new char[]
			{
				'.'
			})[0];
			if (p.g(null, this.A.E(), text) && this.A.A(this.A).A(p))
			{
				b2.A().A(p);
			}
		}
		private void a(object obj, EventArgs eventArgs)
		{
			using (new C())
			{
				m m = m.A();
				if (m.a(typeof(Q1)))
				{
					R.A(this.A, m.A(), this.A.E());
				}
			}
		}
		public static bool A(x x)
		{
			m m = m.A();
			bool flag = m.a(typeof(Q1));
			x.A(new object[]
			{
				flag ? ("'" + m.A() + "'") : ""
			});
			x.A(flag);
			x.a(flag);
			return flag;
		}
		public static void A(h2 h, byte[] array, int num)
		{
			if (array != null)
			{
				p1 p = Q1.A(array);
				if (p != null)
				{
					if (h.E().B(p.b()))
					{
						p.b(h.E().b(p.b()));
					}
					p.a(-1);
					q1 q = q1.A();
					if (q.A(h).A(p, ref num, null))
					{
						b2.A().A(p);
					}
				}
			}
		}
	}
	public class r : P
	{
		private new static r A;
		private new q1 A = q1.A();
		private new h2 A;
		private new p1 A;
		private new x A;
		private new x a;
		private new x B;
		private new x b;
		private new x C;
		private r()
		{
			this.A = this.A("Diagrammeigenschaften...", "bearbeiten", "Properties", new EventHandler(this.A));
			this.a = this.A("Diagramm prüfen...", "auf logische Fehler", "", new EventHandler(this.a));
			this.A("-", "", "", null);
			this.B = this.A("Diagramm ausschneiden", "...in die Zwischenablage", "EditCut", new EventHandler(this.B));
			this.b = this.A("Diagramm kopieren", "...in die Zwischenablage", "EditCopy", new EventHandler(this.b));
			this.C = this.A("Diagramm löschen", "", "EditDelete", new EventHandler(this.C));
		}
		public static r A()
		{
			if (r.A == null)
			{
				r.A = new r();
			}
			return r.A;
		}
		public void A(h2 h, p1 p)
		{
			this.A = h;
			this.A = p;
			bool flag = h != null && !h.F();
			bool flag2 = flag && p != null && !p.J();
			bool flag3 = flag2 && !z1.A();
			bool flag4 = this.A();
			this.c(flag2, flag2);
			this.a.A(flag3 && flag4);
			this.B.A(flag3);
			this.C.A(flag3);
			this.b();
			if (this.B.A() || this.b.A() || this.C.A())
			{
				this.B.a(true);
				this.b.a(true);
				this.C.a(true);
			}
		}
		private bool A()
		{
			K1.A().A().EnableDiagramCheck = false;
			return false;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			string text = obj.ToString().Split(new char[]
			{
				'.'
			})[0];
			if (this.A.A(this.A).A(this.A, text))
			{
				s1 s = b2.A().A();
				if (s != null && s.A() == this.A)
				{
					s.C();
				}
			}
		}
		private void a(object obj, EventArgs eventArgs)
		{
		}
		private void B(object obj, EventArgs eventArgs)
		{
			if (this.A.a(this.A))
			{
				return;
			}
			using (new C())
			{
				r.A(this.A, this.A, true);
			}
		}
		private void b(object obj, EventArgs eventArgs)
		{
			using (new C())
			{
				r.a(this.A, this.A);
			}
		}
		private void C(object obj, EventArgs eventArgs)
		{
			r.A(this.A, this.A, false);
		}
		public static bool A(h2 h, p1 p, ref byte[] ptr)
		{
			q1 q = q1.A();
			if (q.a(h))
			{
				return false;
			}
			ptr = j2.A(p);
			return ptr != null && ptr.Length > 0;
		}
		public static void a(h2 h, p1 p)
		{
			byte[] array = null;
			if (r.A(h, p, ref array))
			{
				m.A().A(p.GetType(), p.b(), null, array);
			}
		}
		public static void A(h2 h, p1 p, bool flag)
		{
			string arg = flag ? "ausschneiden" : "löschen";
			string text = string.Format("Möchten Sie das Diagramm '{0}' wirklich {1}?", p.b(), arg);
			DialogResult dialogResult = MessageBox.Show(text, "Diagramm ausschneiden", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.OK)
			{
				q1 q = q1.A();
				if (flag)
				{
					r.a(h, p);
				}
				q.A(h).a(p);
			}
		}
	}
}
