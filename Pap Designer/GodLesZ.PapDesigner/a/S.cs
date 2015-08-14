using d;
using D;
using System;
using System.Windows.Forms;
namespace a
{
	public class S : P
	{
		private new static S A;
		private new q1 A = q1.A();
		private new h2 A;
		private new e2 A;
		private new int A = -1;
		private new int a = -1;
		private new x A;
		private new x a;
		private new x B;
		private new x b;
		private new x C;
		private new x c;
		private new x D;
		private new x d;
		private new x E;
		private new x e;
		private new x F;
		private x f;
		private S()
		{
			this.A = this.A("Rückgängig{0}", "", "EditUndo", new EventHandler(this.A));
			this.A.A((Keys)131162);
			this.a = this.A("Wiederholen{0}", "", "EditRedo", new EventHandler(this.B));
			this.a.A((Keys)131161);
			this.A("-", "", "", null);
			this.B = this.A("Erstelle Diagram '{0}'", "", "DiagramNew", new EventHandler(this.c));
			this.b = this.A("Gehe zu Diagram '{0}'", "", "NavigateNext", new EventHandler(this.b));
			this.C = this.A("Auswahl in Unterprogramm auslagern...", "", "SwapOut", new EventHandler(this.C));
			this.A("-", "", "", null);
			this.c = this.A("{0} bearbeiten...", "", "Properties", new EventHandler(this.D));
			this.D = this.A("Symbol neu einfügen", "", "", null);
			this.d = this.A("Symbol umwandeln in", "", "", null);
			this.A("-", "", "", null);
			this.E = this.A("{0} ausschneiden", "...in die Zwischenablage", "EditCut", new EventHandler(this.d));
			this.E.A((Keys)131160);
			this.e = this.A("{0} kopieren", "...in die Zwischenablage", "EditCopy", new EventHandler(this.E));
			this.e.A((Keys)131139);
			this.F = this.A("{0} einfügen", "...aus der Zwischenablage", "EditPaste", new EventHandler(this.e));
			this.F.A((Keys)131158);
			this.f = this.A("{0} löschen", "", "EditDelete", new EventHandler(this.F));
			this.f.A(Keys.Delete);
		}
		public static S A()
		{
			if (S.A == null)
			{
				S.A = new S();
			}
			return S.A;
		}
		public override void a(ToolStripItemCollection toolStripItemCollection)
		{
			base.a(toolStripItemCollection);
			foreach (ToolStripItem toolStripItem in toolStripItemCollection)
			{
				if (toolStripItem.Tag == this.D)
				{
					t.A().a(((ToolStripMenuItem)toolStripItem).DropDownItems);
					((ToolStripMenuItem)toolStripItem).DropDownOpened += new EventHandler(P.F);
				}
			}
			foreach (ToolStripItem toolStripItem2 in toolStripItemCollection)
			{
				if (toolStripItem2.Tag == this.d)
				{
					U.A().a(((ToolStripMenuItem)toolStripItem2).DropDownItems);
					((ToolStripMenuItem)toolStripItem2).DropDownOpened += new EventHandler(P.F);
				}
			}
		}
		public void A(h2 h, e2 e, bool flag)
		{
			this.A = h;
			if (h == null || h.F())
			{
				this.d();
				return;
			}
			this.A = e;
			if (e == null)
			{
				throw new l1();
			}
			m m = m.A();
			int num = 0;
			if (m.A(typeof(H2)) && !H2.A(m, out num))
			{
				throw new l1();
			}
			this.D();
			R1 r = q1.A().A(h);
			i1 i = r.A();
			k k = e.L();
			this.A.A(i.A() && (k.A() || flag));
			this.a.A(i.a() && (k.A() || flag));
			this.c.A(k.a() && (k.C() || e.L(k.A())));
			this.D.A(k.A() == null);
			this.d.A(k.A() != null && this.c.A() && Q1.A(k.A().GetType()));
			this.E.A(k.E() && k.e());
			this.e.A(k.E());
			this.F.A(m.A().A(typeof(H2)));
			this.f.A(k.e());
			this.C.A(k.f());
			bool flag2 = false;
			if (k.a() && k.b())
			{
				this.E(new object[]
				{
					"Symbol"
				});
			}
			else
			{
				if (k.a() && k.C())
				{
					flag2 = true;
					this.E(new object[]
					{
						"Verbindung"
					});
					this.c.A(new object[]
					{
						"Verbindungtext"
					});
					this.E.A(false);
					this.e.A(false);
				}
				else
				{
					this.E(new object[]
					{
						"Auswahl"
					});
				}
			}
			if (num == 1)
			{
				this.F.A(new object[]
				{
					"Symbol"
				});
			}
			else
			{
				if (num > 1)
				{
					this.F.A(new object[]
					{
						"Auswahl"
					});
				}
			}
			this.A.A(new object[]
			{
				i.A() ? (": " + i.A()) : ""
			});
			this.a.A(new object[]
			{
				i.a() ? (": " + i.a()) : ""
			});
			this.B.A(false);
			this.b.A(false);
			bool flag3 = false;
			if (k.a() && k.A() is d.B)
			{
				d.a a = k.A();
				this.B.A(new object[]
				{
					a.c()
				});
				this.b.A(new object[]
				{
					a.c()
				});
				p1 p = e.L(a, false);
				if (p != null)
				{
					if (p != e.A())
					{
						this.b.A(true);
						this.b.A(a);
						flag3 = true;
					}
				}
				else
				{
					this.B.A(true);
					this.B.A(a.c());
				}
			}
			if (this.d.A())
			{
				U.A().A(h, e, k.A());
			}
			this.b();
			if (!flag3)
			{
				this.b.a(false);
			}
			if (flag)
			{
				this.A.a(true);
				this.a.a(true);
			}
			if (this.D.A() && this.D.a())
			{
				t.A().A(h, e);
			}
			else
			{
				t.A().d();
			}
			if (this.E.A() || this.e.A() || this.F.A() || this.f.A())
			{
				this.E.a(!flag2);
				this.e.a(!flag2);
				this.F.a(true);
				this.f.a(true);
			}
		}
		private void A(object obj, EventArgs eventArgs)
		{
			using (new C())
			{
				i1 i = q1.A().A(this.A).A();
				if (i != null && i.A())
				{
					this.A = -1;
					d1 d = i.A();
					bool flag;
					if (!this.A(d, out flag) && !flag)
					{
						i.a();
						this.A.C();
					}
				}
			}
		}
		private void B(object obj, EventArgs eventArgs)
		{
			using (new C())
			{
				i1 i = q1.A().A(this.A).A();
				if (i != null && i.a())
				{
					d1 d = i.a();
					bool flag;
					if (!this.A(d, out flag) && !flag)
					{
						i.B();
						this.A.C();
					}
				}
			}
		}
		private void b(object obj, EventArgs eventArgs)
		{
			d.a a = this.b.A() as d.a;
			if (a != null)
			{
				this.A.l(a);
			}
		}
		private void C(object obj, EventArgs eventArgs)
		{
			if (this.A.a(this.A))
			{
				return;
			}
			k k = this.A.L();
			if (!k.f())
			{
				return;
			}
			if (!k.E())
			{
				return;
			}
			if (!k.e())
			{
				return;
			}
			Q1 q = (Q1)this.A.E();
			string text = obj.ToString().Split(new char[]
			{
				'.'
			})[0];
			if (q.g(null, this.A.E(), text))
			{
				using (new C())
				{
					this.A.A(this.A).A(this.A, k.A(), q, "" + obj);
				}
			}
		}
		private void c(object obj, EventArgs eventArgs)
		{
			string text = this.B.A().ToString();
			this.A.l();
			Q1 q = (Q1)this.A.E();
			q.b(text);
			this.A.A(this.A).A(q);
		}
		private void D(object obj, EventArgs eventArgs)
		{
			if (this.A == null)
			{
				return;
			}
			k k = this.A.L();
			if (k.b() && this.A.L(k.A()))
			{
				this.A.A(this.A).A(this.A, k.A());
				return;
			}
			if (k.C())
			{
				this.A.A(this.A).a(this.A, k.A() as D.A);
			}
		}
		private void d(object obj, EventArgs eventArgs)
		{
			if (this.A.a(this.A))
			{
				return;
			}
			if (this.A.L().E())
			{
				using (new C())
				{
					this.A = this.A.L().A().A();
					this.a = this.A.L().A();
					this.A.L().A().c();
					this.F(obj, eventArgs);
				}
			}
		}
		private void E(object obj, EventArgs eventArgs)
		{
			if (this.A.a(this.A))
			{
				return;
			}
			if (this.A.L().E())
			{
				using (new C())
				{
					this.A = -1;
					this.A.L().A().c();
				}
			}
		}
		private void e(object arg, EventArgs eventArgs)
		{
			H2 h = H2.a();
			if (this.A == h.A() && this.a == this.A.L().A())
			{
				this.A = -1;
			}
			else
			{
				h.a();
			}
			this.A.l();
			this.A.L(new y(h, this.A, "" + arg));
		}
		private new void F(object arg, EventArgs eventArgs)
		{
			using (new C())
			{
				k k = this.A.L();
				if (k.e())
				{
					if (k.C())
					{
						this.A.A(this.A).A(this.A, (D.A)k.A(), "" + arg);
					}
					else
					{
						if (!k.A())
						{
							this.A.A(this.A).A(this.A, k.A(), "" + arg);
						}
					}
					this.A.l();
				}
			}
		}
		private bool A(d1 d, out bool ptr)
		{
			ptr = false;
			if (d is F1 && !(d is H1) && !(d is h1))
			{
				p1 p = ((F1)d).A();
				b2 b = b2.A();
				if (b.A() != p)
				{
					ptr = true;
					string text = this.A.a();
					string text2 = "Die Option '" + text + "' erfordert einen Wechsel der aktuallen Ansicht.";
					text2 = text2 + "\nBitte betätgigen Sie dort '" + text + "' erneut.";
					DialogResult dialogResult = MessageBox.Show(text2, j1.a(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
					if (dialogResult != DialogResult.OK)
					{
						return true;
					}
					b2.A().A(p);
				}
			}
			return false;
		}
	}
	public class s : P
	{
		private new static s A;
		private new q1 A = q1.A();
		private new h2 A;
		private new p1 A;
		private new x A;
		private new x a;
		private s()
		{
			this.A = this.A("Grafik exportieren...", "als Bilddatei", "Export", new EventHandler(this.a));
			this.a = this.A("Drucken...", "", "Print", new EventHandler(this.A));
		}
		public static s A()
		{
			if (s.A == null)
			{
				s.A = new s();
			}
			return s.A;
		}
		public void A(h2 h, p1 p)
		{
			this.A = h;
			this.A = p;
			this.D();
			this.a.A(u1.A(h));
			this.A.A(p != null);
		}
		private void A(object obj, EventArgs eventArgs)
		{
			if (q1.A().A(this.A) == DialogResult.OK)
			{
				u1.A(this.A.A(), this.A, this.A);
			}
		}
		private void a(object obj, EventArgs eventArgs)
		{
			O1.A(this.A);
		}
	}
}
