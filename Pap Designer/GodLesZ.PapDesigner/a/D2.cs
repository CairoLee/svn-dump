using c;
using d;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace a
{
	public class D2 : c2
	{
		private new d.a A;
		protected D2()
		{
		}
		public D2(s1 s, string text, d.a a, string text2) : base(s, text, text2, a)
		{
			this.A = a;
			this.A.AcceptsTab = (a is d.A);
		}
		public override void B(TextBox textBox)
		{
			base.B(textBox);
			if (textBox.Text.EndsWith("?"))
			{
				textBox.SelectionStart--;
			}
		}
		public override string C(string text)
		{
			if (this.A is global::c.c)
			{
				int num = 0;
				string pattern = "^[ \\t]*\\r\\n";
				while (num < 2 && Regex.Match(text, pattern, RegexOptions.Singleline).Success)
				{
					text = Regex.Replace(text, pattern, "", RegexOptions.Singleline);
					num++;
				}
				text = base.C(text);
				if (num > 0)
				{
					while (num-- > 0)
					{
						text = "\r\n" + text + "\r\n";
					}
					text += "\r\n";
				}
			}
			else
			{
				if (this.A is d.A)
				{
					text = Regex.Replace(text.Trim(), "[\\t]", "  ");
					text = Regex.Replace(text.Trim(), "(?<!\\r\\n[ ]{0,6})[ ]+", " ");
				}
				else
				{
					text = base.C(text);
				}
			}
			return text;
		}
		public override bool b(string text)
		{
			bool flag = base.b(text);
			if (flag)
			{
				this.A.D(this.A());
			}
			return flag;
		}
	}
	public class d2 : Form, b
	{
		private static d2 A;
		private K1 A = K1.A();
		private A2 A;
		private q1 A;
		private b2 A;
		private Dictionary<Keys, int> A;
		private c A = new c();
		private IContainer A;
		private SplitContainer A;
		private I2 A;
		private ToolStripMenuItem A;
		private ToolStripMenuItem a;
		private ToolStripMenuItem B;
		private ToolStripMenuItem b;
		private ToolStripMenuItem C;
		private ToolStripMenuItem c;
		private MenuStrip A;
		private ToolStripMenuItem D;
		private ToolStripMenuItem d;
		private ToolStripMenuItem E;
		private ToolStripMenuItem e;
		private ToolStripMenuItem F;
		private ToolStripMenuItem f;
		private ToolStripMenuItem G;
		public d2()
		{
			this.b();
			d2.A = this;
			this.Font = this.A.Font;
			this.A = q1.A(this);
			this.A = new A2();
			this.A.Panel2.Controls.Add(this.A);
			this.A.Dock = DockStyle.Fill;
			this.A = new b2(this.A, this.A.A(), this.A, this.A);
			this.A.A(new b2.A(this.a));
			this.A.A(new b2.a(this.a));
			this.B.Enabled = false;
			if (global::a.A.A != null && global::a.A.A.Length > 0)
			{
				this.A.A(global::a.A.A, true, false);
			}
			if (this.A.A() == null)
			{
				this.A.A(this.A.A(true), true, false);
			}
			if (this.A.A() == null)
			{
				this.A.a(Y.A().A()[0], false);
			}
			if (this.A.A() == null)
			{
				this.a(null);
				this.a(null);
			}
			this.A.A();
			this.B();
			this.A = new Dictionary<Keys, int>();
			P.F(this.A);
		}
		public void a()
		{
			this.A.A(false, true);
			this.A.a(new b2.A(this.a));
			this.A.a(new b2.a(this.a));
			this.A.Dispose();
		}
		public static Form a()
		{
			if (d2.A == null)
			{
				throw new l1();
			}
			return d2.A;
		}
		public void A(string[] array)
		{
			if (array != null && array.Length > 0)
			{
				this.A.A(array, true, false);
			}
		}
		public void a(h2 h)
		{
			if (h != null)
			{
				this.Text = j1.a() + " - " + h.b();
				if (h.F() == null)
				{
					this.Text = j1.a() + " - " + h.b();
				}
				else
				{
					this.Text = j1.a() + " - " + Path.GetFileName(h.F());
				}
			}
			else
			{
				this.Text = j1.a();
			}
			this.C.Enabled = (h != null);
			this.b.Enabled = (h != null);
		}
		public void a(s1 s)
		{
			this.B.Enabled = (this.A.A() != null);
			this.b.Enabled = (this.A.A() != null && !this.A.A().F());
			this.C.Enabled = (this.A.A() != null);
		}
		private void a(object obj, EventArgs eventArgs)
		{
			if (!this.A.a())
			{
				string text = "PapDesigner konnte den Dateityp '.pap' nicht registrieren für\n";
				text = text + "'" + j1.e() + "',\n";
				text += "weil Ihr Benutzerkonto keine ausreichenden Zugriffsrechte aufweist.\n\n";
				if (this.A.a() != null)
				{
					text += "Wenn Sie pap-Dokumente im Explorer öffnen, wird die Installation\n";
					text = text + "'" + this.A.a() + "' dafür gestartet.";
				}
				else
				{
					text += "Sie können daher pap-Dokumente nicht durch Doppelklick im Explorer öffnen.";
				}
				MessageBox.Show(text, j1.a() + " - Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (!this.A.A().SuppressTutorialTip)
			{
				string text2 = "Über das Menü '" + this.F + "' können Sie Beispielprojekte öffnen,\n";
				text2 += "an denen Sie mehr über Programmablaufpläne lernen können.";
				MessageBox.Show(text2, j1.a() + " - Tip", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.A.A().SuppressTutorialTip = true;
			}
		}
		private void B(object obj, EventArgs eventArgs)
		{
			base.Close();
		}
		private void a(object obj, FormClosingEventArgs formClosingEventArgs)
		{
			formClosingEventArgs.Cancel = !this.A.A();
		}
		private void a(object obj, FormClosedEventArgs formClosedEventArgs)
		{
			this.a();
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keys)
		{
			if (this.A.A(keys))
			{
				return true;
			}
			if (this.A.ContainsKey(keys))
			{
				this.b(null, null);
				this.C(null, null);
				this.c(null, null);
				this.D(null, null);
				this.d(null, null);
				this.e(null, null);
			}
			bool flag = base.ProcessCmdKey(ref msg, keys);
			if (!flag)
			{
				d2.a(keys);
			}
			return flag;
		}
		public static void a(Keys keys)
		{
			int num = (int)(keys & Keys.KeyCode);
			if (num >= 65 && num <= 90)
			{
				SystemSounds.Exclamation.Play();
			}
		}
		private void B()
		{
			p.A().a(this.A.DropDownItems);
			R.A().a(this.A.DropDownItems);
			Q.A().a(this.A.DropDownItems);
			q.A().a(this.A.DropDownItems);
			this.A.DropDownItems.Add(new ToolStripSeparator());
			this.A.DropDownItems.Add(this.a);
			R.A().a(this.B.DropDownItems);
			r.A().a(this.B.DropDownItems);
			s.A().a(this.B.DropDownItems);
			S.A().a(this.b.DropDownItems);
			T.A().a(this.C.DropDownItems);
			this.A.DropDownOpened += new EventHandler(P.F);
			this.B.DropDownOpened += new EventHandler(P.F);
			this.b.DropDownOpened += new EventHandler(P.F);
			this.C.DropDownOpened += new EventHandler(P.F);
			this.c.DropDownOpened += new EventHandler(P.F);
			this.D.DropDownOpened += new EventHandler(P.F);
		}
		private void b(object obj, EventArgs eventArgs)
		{
			h2 h = this.A.A();
			p1 p = this.A.A();
			p.A().A(this.A.DropDownItems);
			if (h != null)
			{
				R.A().A(h);
				Q.A().A(h, true);
			}
			else
			{
				R.A().d();
				Q.A().d();
			}
			q.A().A(h, p);
		}
		private void C(object obj, EventArgs eventArgs)
		{
			h2 h = this.A.A();
			p1 p = this.A.A();
			if (h != null)
			{
				R.A().A(h);
				r.A().A(h, p);
			}
			else
			{
				R.A().d();
			}
			if (h != null && p != null)
			{
				s.A().A(h, p);
				return;
			}
			s.A().d();
		}
		private void c(object obj, EventArgs eventArgs)
		{
			h2 h = this.A.A();
			e2 e = this.A.A() as e2;
			S.A().A(h, e, true);
		}
		private void D(object obj, EventArgs eventArgs)
		{
			h2 h = this.A.A();
			e2 e = (e2)this.A.A();
			if (h != null)
			{
				T.A().A(h, e);
				return;
			}
			T.A().d();
		}
		private void d(object obj, EventArgs eventArgs)
		{
		}
		private void E(object obj, EventArgs eventArgs)
		{
			w w = new w();
			w.ShowDialog();
		}
		private void e(object obj, EventArgs eventArgs)
		{
			this.d.Text = string.Format(this.d.Text, j1.a());
		}
		private void F(object obj, EventArgs eventArgs)
		{
			D d = new D();
			d.Disposed += new EventHandler(this.f);
			this.G.Enabled = false;
			d.Show();
		}
		private void f(object obj, EventArgs eventArgs)
		{
			this.G.Enabled = true;
		}
		private void G(object obj, EventArgs eventArgs)
		{
			J1 j = new J1();
			j.ShowDialog();
		}
		private void g(object obj, EventArgs eventArgs)
		{
			d2.a(j1.H());
		}
		private void H(object obj, EventArgs eventArgs)
		{
			string text = "Tutorial - ";
			string[] array = Y.A().A();
			if (this.F.DropDownItems.Count < array.Length)
			{
				int num = 0;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = array2[i];
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(text + text2);
					toolStripMenuItem.Tag = text2;
					toolStripMenuItem.Click += new EventHandler(this.h);
					this.F.DropDownItems.Insert(num++, toolStripMenuItem);
					toolStripMenuItem.ToolTipText = string.Format("Beispielprojekt '{0}' zur Orientierung und zum Lernen", text2);
				}
				this.F.DropDownItems.Insert(num++, new ToolStripSeparator());
			}
			foreach (ToolStripItem toolStripItem in this.F.DropDownItems)
			{
				if (toolStripItem.Text.StartsWith(text))
				{
					toolStripItem.Enabled = this.A.a(toolStripItem.Tag as string, true);
				}
			}
		}
		private void h(object obj, EventArgs eventArgs)
		{
			using (new C())
			{
				string text = (obj as ToolStripMenuItem).Tag as string;
				if (text != null)
				{
					base.Update();
					this.A.a(text, false);
				}
			}
		}
		private void I(object obj, EventArgs eventArgs)
		{
			d2.a(j1.G());
		}
		private void a(object obj, DragEventArgs dragEventArgs)
		{
			dragEventArgs.Effect = DragDropEffects.Link;
		}
		private void B(object obj, DragEventArgs dragEventArgs)
		{
			using (new C())
			{
				string[] array = dragEventArgs.Data.GetData("FileDrop") as string[];
				if (array != null && array.Length > 0)
				{
					this.A.A(array, false, false);
				}
			}
		}
		public static void a(string text)
		{
			string text2 = "Möchten Sie die Internetadresse\n'" + text + "'\nmit dem Standardbrowser öffnen?";
			if (MessageBox.Show(text2, j1.a(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				Process.Start(text);
			}
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void b()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(d2));
			this.A = new SplitContainer();
			this.A = new ToolStripMenuItem();
			this.a = new ToolStripMenuItem();
			this.B = new ToolStripMenuItem();
			this.b = new ToolStripMenuItem();
			this.C = new ToolStripMenuItem();
			this.c = new ToolStripMenuItem();
			this.e = new ToolStripMenuItem();
			this.A = new MenuStrip();
			this.D = new ToolStripMenuItem();
			this.G = new ToolStripMenuItem();
			this.E = new ToolStripMenuItem();
			this.d = new ToolStripMenuItem();
			this.F = new ToolStripMenuItem();
			this.f = new ToolStripMenuItem();
			this.A = new I2();
			this.A.Panel1.SuspendLayout();
			this.A.SuspendLayout();
			this.A.SuspendLayout();
			base.SuspendLayout();
			this.A.Dock = DockStyle.Fill;
			this.A.Location = new Point(0, 24);
			this.A.Name = "splitContainer1";
			this.A.Panel1.Controls.Add(this.A);
			this.A.Size = new Size(794, 377);
			this.A.SplitterDistance = 120;
			this.A.TabIndex = 2;
			this.A.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.a
			});
			this.A.Name = "miProject";
			this.A.Size = new Size(53, 20);
			this.A.Text = "Projekt";
			this.A.DropDownOpening += new EventHandler(this.b);
			this.a.Image = (Image)componentResourceManager.GetObject("miAppExit.Image");
			this.a.Name = "miAppExit";
			this.a.ShortcutKeys = (Keys)262259;
			this.a.Size = new Size(167, 22);
			this.a.Text = "Beenden";
			this.a.ToolTipText = "Beendet das Programm";
			this.a.Click += new EventHandler(this.B);
			this.B.Name = "miDiagram";
			this.B.Size = new Size(66, 20);
			this.B.Text = "Diagramm";
			this.B.DropDownOpening += new EventHandler(this.C);
			this.b.Name = "miEdit";
			this.b.Size = new Size(71, 20);
			this.b.Text = "Bearbeiten";
			this.b.DropDownOpening += new EventHandler(this.c);
			this.C.Name = "miView";
			this.C.Size = new Size(54, 20);
			this.C.Text = "Ansicht";
			this.C.DropDownOpening += new EventHandler(this.D);
			this.c.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.e
			});
			this.c.Name = "miExtras";
			this.c.Size = new Size(50, 20);
			this.c.Text = "Extras";
			this.c.DropDownOpening += new EventHandler(this.d);
			this.e.Image = (Image)componentResourceManager.GetObject("miExtrasSettings.Image");
			this.e.Name = "miExtrasSettings";
			this.e.Size = new Size(148, 22);
			this.e.Text = "Einstellungen";
			this.e.Click += new EventHandler(this.E);
			this.A.Items.AddRange(new ToolStripItem[]
			{
				this.A,
				this.B,
				this.b,
				this.C,
				this.c,
				this.D,
				this.F
			});
			this.A.Location = new Point(0, 0);
			this.A.Name = "menuStrip";
			this.A.RenderMode = ToolStripRenderMode.Professional;
			this.A.ShowItemToolTips = true;
			this.A.Size = new Size(794, 24);
			this.A.TabIndex = 1;
			this.A.Text = "menuStrip";
			this.D.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.G,
				this.E,
				this.d
			});
			this.D.Name = "miHelp";
			this.D.Size = new Size(51, 20);
			this.D.Text = "Info    ";
			this.D.DropDownOpening += new EventHandler(this.e);
			this.G.Image = (Image)componentResourceManager.GetObject("miHelpUsageInfo.Image");
			this.G.Name = "miHelpUsageInfo";
			this.G.ShortcutKeys = Keys.F1;
			this.G.Size = new Size(276, 22);
			this.G.Text = "Hilfe zur Eingabe...";
			this.G.Click += new EventHandler(this.F);
			this.E.Image = (Image)componentResourceManager.GetObject("miHelpGsoLink.Image");
			this.E.Name = "miHelpGsoLink";
			this.E.Size = new Size(276, 22);
			this.E.Text = "Georg-Simon-Ohm Berufskolleg online...";
			this.E.ToolTipText = "Ins Internet durch Aufruf ihres Standardbrowsers";
			this.E.Click += new EventHandler(this.g);
			this.d.Image = (Image)componentResourceManager.GetObject("miHelpInfo.Image");
			this.d.Name = "miHelpInfo";
			this.d.Size = new Size(276, 22);
			this.d.Text = "Info über {0}...";
			this.d.Click += new EventHandler(this.G);
			this.F.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.f
			});
			this.F.Image = (Image)componentResourceManager.GetObject("miTutorial.Image");
			this.F.Name = "miTutorial";
			this.F.Size = new Size(82, 20);
			this.F.Text = "Lernhilfen";
			this.F.DropDownOpening += new EventHandler(this.H);
			this.f.Image = (Image)componentResourceManager.GetObject("miTutorialWikipediaLink.Image");
			this.f.Name = "miTutorialWikipediaLink";
			this.f.Size = new Size(209, 22);
			this.f.Text = "Wikipedia zu PAP online...";
			this.f.ToolTipText = "Ins Internet durch Aufruf ihres Standardbrowsers";
			this.f.Click += new EventHandler(this.I);
			this.A.Dock = DockStyle.Fill;
			this.A.Location = new Point(0, 0);
			this.A.Name = "projectTreeView";
			this.A.A(null);
			this.A.Size = new Size(120, 377);
			this.A.TabIndex = 0;
			this.AllowDrop = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(794, 401);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.A;
			base.Name = "MainForm";
			base.StartPosition = FormStartPosition.WindowsDefaultBounds;
			this.Text = "<dynamic title>";
			base.WindowState = FormWindowState.Maximized;
			base.FormClosed += new FormClosedEventHandler(this.a);
			base.DragDrop += new DragEventHandler(this.B);
			base.Shown += new EventHandler(this.a);
			base.FormClosing += new FormClosingEventHandler(this.a);
			base.DragEnter += new DragEventHandler(this.a);
			this.A.Panel1.ResumeLayout(false);
			this.A.ResumeLayout(false);
			this.A.ResumeLayout(false);
			this.A.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
