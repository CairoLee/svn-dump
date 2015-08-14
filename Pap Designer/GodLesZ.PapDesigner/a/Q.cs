using System;
using System.Windows.Forms;
namespace a
{
	public class Q : P
	{
		private new static Q A;
		private new q1 A = q1.A();
		private new h2 A;
		private new x A;
		private new x a;
		private new x B;
		private new x b;
		private new x C;
		private new x c;
		private new x D;
		private Q()
		{
			this.A = this.A("Projekteigenschaften...", "bearbeiten", "ProjectProperties", new EventHandler(this.A));
			this.a = this.A("Projekt speichern", "", "ProjectSave", new EventHandler(this.a));
			this.a.A((Keys)131155);
			this.B = this.A("Projekt speichern unter...", "einem anderen Dateinamen", "", new EventHandler(this.B));
			this.b = this.A("Alle Projekte speichern", "", "", new EventHandler(this.b));
			this.C = this.A("{0} schließen", "", "ProjectClose", new EventHandler(this.C));
			this.c = this.A("Alle schließen", "", "", new EventHandler(this.c));
			this.D = this.A("Projektdatei löschen...", "", "EditDelete", new EventHandler(this.D));
		}
		public static Q A()
		{
			if (Q.A == null)
			{
				Q.A = new Q();
			}
			return Q.A;
		}
		public void A(h2 h, bool flag)
		{
			this.A = h;
			bool flag2 = h.g();
			bool flag3 = flag2;
			if (!flag3)
			{
				foreach (h2 current in this.A.A())
				{
					if (current.g())
					{
						flag3 = true;
						break;
					}
				}
			}
			this.D();
			this.A.A(h != null);
			this.a.A(flag2);
			this.B.A(h != null);
			this.b.A(flag3);
			this.C.A(h != null);
			this.c.A(this.A.A().B() > 1);
			this.D.A(h != null && this.A.a(h, true));
			this.b.a(flag && this.A.A().B() > 1);
			this.c.a(flag && this.A.A().B() > 1);
			if (h.F())
			{
				this.a.a(h.f());
				this.B.a(h.f());
				this.b.a(h.f());
				this.D.a(false);
			}
			this.C.A(new object[]
			{
				h.e() ? "Tutorial" : "Project"
			});
		}
		private void A(object obj, EventArgs eventArgs)
		{
			string text = obj.ToString().Split(new char[]
			{
				'.'
			})[0];
			q1.A().A(this.A).A(text);
		}
		private void a(object obj, EventArgs eventArgs)
		{
			this.A.A(this.A, false);
		}
		private void B(object obj, EventArgs eventArgs)
		{
			this.A.A(this.A, true);
		}
		private void b(object obj, EventArgs eventArgs)
		{
			this.A.A();
		}
		private void C(object obj, EventArgs eventArgs)
		{
			this.A.b(this.A);
		}
		private void c(object obj, EventArgs eventArgs)
		{
			this.A.A(true, false);
		}
		private void D(object obj, EventArgs eventArgs)
		{
			this.A.a(this.A, false);
		}
	}
	public class q : P
	{
		private new static q A;
		private new q1 A = q1.A();
		private new h2 A;
		private new p1 A;
		private new x A;
		private new x a;
		private new x B;
		private q()
		{
			this.A = this.A("Seite einrichten...", "", "PrintSetup", new EventHandler(this.A));
			this.a = this.A("Drucken...", "", "Print", new EventHandler(this.a));
			this.a.A((Keys)131152);
			this.B = this.A("Grafik exportieren...", "als Bilddatei", "Export", new EventHandler(this.B));
		}
		public static q A()
		{
			if (q.A == null)
			{
				q.A = new q();
			}
			return q.A;
		}
		public void A(h2 h, p1 p)
		{
			this.A = h;
			this.A = p;
			this.D();
			this.a.A(h != null);
			this.B.A(h != null && p != null);
		}
		private void A(object obj, EventArgs eventArgs)
		{
			u1.A();
		}
		private void a(object obj, EventArgs eventArgs)
		{
			if (q1.A().A(this.A) == DialogResult.OK)
			{
				u1.A(this.A.A(), this.A, this.A);
			}
		}
		private void B(object obj, EventArgs eventArgs)
		{
			O1.A(this.A);
		}
	}
}
