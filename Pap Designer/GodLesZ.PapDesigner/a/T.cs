using c;
using C;
using d;
using D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class T : P
	{
		private new static T A;
		private new q1 A = q1.A();
		private new h2 A;
		private new e2 A;
		private new x A;
		private new x a;
		private new x B;
		private new x b;
		private new x C;
		private T()
		{
			this.A = this.A("Ansicht ausrichten", "Ansicht automatisch ausrichten", "ViewAdjust", new EventHandler(this.A));
			this.a = this.A("Rasterlinien ausblenden", "...im Diagramm", "ViewGrid", new EventHandler(this.a));
			this.B = this.A("Rasterlinien anzeigen", "...im Diagramm", "ViewGrid", new EventHandler(this.a));
			this.b = this.A("Präsentationsansicht", "wechselt zur Präsentationsansicht", "ViewFull", new EventHandler(this.B));
			this.C = this.A("Präsentationsansicht schließen", null, "AppExit", new EventHandler(this.B));
		}
		public static T A()
		{
			if (T.A == null)
			{
				T.A = new T();
			}
			return T.A;
		}
		public void A(h2 h, e2 e)
		{
			this.A = h;
			this.A = e;
			this.D();
			bool flag = e != null;
			this.A.A(flag && e.K());
			this.A.a(flag);
			this.B.a(flag && !e.l() && !e.L().J());
			this.a.a(flag && e.l() && !e.L().J());
			this.b.a(flag && !z1.A());
			this.C.a(flag && z1.A());
		}
		private void A(object obj, EventArgs eventArgs)
		{
			if (this.A != null)
			{
				this.A.k();
			}
		}
		private void a(object obj, EventArgs eventArgs)
		{
			this.A.M(!this.A.l());
		}
		private void B(object obj, EventArgs eventArgs)
		{
			try
			{
				if (z1.A())
				{
					z1.A();
				}
				else
				{
					z1.A(this.A, this.A);
				}
			}
			catch
			{
				v.A(null);
			}
		}
		public x A()
		{
			return this.A;
		}
	}
	public class t : P
	{
		private new static t A;
		private new q1 A = q1.A();
		private new Dictionary<Type, x> A;
		private new h2 A;
		private new e2 A;
		private new Point A = new Point(0, 0);
		private new x A;
		private new x a;
		private new x B;
		private new x b;
		private new x C;
		private new x c;
		private new x D;
		private new x d;
		private t()
		{
			this.A = this.A("Eingabe", "Symbol für Eingabe einfügen", "sym_in_16", new EventHandler(this.A));
			this.a = this.A("Ausgabe", "Symbol für Ausgabe einfügen", "sym_out_16", new EventHandler(this.A));
			this.B = this.A("Vorgang", "Symbol für Vorgang einfügen", "sym_act_16", new EventHandler(this.A));
			this.b = this.A("Unterprogramm", "Symbol für Unterprogramm einfügen", "sym_mod_16", new EventHandler(this.A));
			this.C = this.A("Verzweigung", "Symbol für Verzweigung einfügen", "sym_branch_16", new EventHandler(this.A));
			this.c = this.A("Schleife", "Symbol für Schleife einfügen", "sym_loop_16", new EventHandler(this.A));
			this.D = this.A("Kommentar", "Kommentar einfügen", "sym_info_16", new EventHandler(this.A));
			this.d = this.A("Verbindungspunkt", "Verbindungspunkt bzw. Eckpunkt einfügen", "sym_conn_16", new EventHandler(this.A));
			this.A = new Dictionary<Type, x>();
			this.A.Add(typeof(D.b), this.A);
			this.A.Add(typeof(global::C.c), this.a);
			this.A.Add(typeof(d.B), this.b);
			this.A.Add(typeof(d.b), this.B);
			this.A.Add(typeof(global::c.c), this.C);
			this.A.Add(typeof(global::C.b), this.c);
			this.A.Add(typeof(d.A), this.D);
			this.A.Add(typeof(global::c.B), this.d);
			foreach (Type current in this.A.Keys)
			{
				this.A[current].A(current);
			}
		}
		public static t A()
		{
			if (t.A == null)
			{
				t.A = new t();
			}
			return t.A;
		}
		public void A(h2 h, e2 e)
		{
			this.A = h;
			this.A = e;
			if (e.L().J())
			{
				this.d();
				return;
			}
			this.D();
		}
		private void A(object obj, EventArgs eventArgs)
		{
			Type type = (Type)((x)((ToolStripMenuItem)obj).Tag).A();
			if (this.A.L() == typeof(A1))
			{
				this.A.l();
				this.A.L(new z(this.A, type));
			}
		}
		public x A(Type key)
		{
			return this.A[key];
		}
	}
}
