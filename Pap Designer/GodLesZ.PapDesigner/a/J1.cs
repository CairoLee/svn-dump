using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
namespace a
{
	public class J1 : Form
	{
		private IContainer A;
		private PictureBox A;
		private Button A;
		private Label A;
		private Panel A;
		public J1()
		{
			this.A();
			this.Font = d2.a().Font;
			this.Text += j1.a();
			this.A.Text = j1.f();
		}
		private void A(object obj, MouseEventArgs mouseEventArgs)
		{
			int num = mouseEventArgs.X * 100 / this.A.Width;
			if (num > 35)
			{
				d2.a(j1.g());
				return;
			}
			d2.a(j1.H());
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void A()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(J1));
			this.A = new PictureBox();
			this.A = new Button();
			this.A = new Label();
			this.A = new Panel();
			((ISupportInitialize)this.A).BeginInit();
			this.A.SuspendLayout();
			base.SuspendLayout();
			this.A.BackColor = Color.White;
			this.A.BackgroundImage = (Image)componentResourceManager.GetObject("pictureBox.BackgroundImage");
			this.A.BackgroundImageLayout = ImageLayout.None;
			this.A.Cursor = Cursors.Hand;
			this.A.ErrorImage = null;
			this.A.InitialImage = null;
			this.A.Location = new Point(12, 0);
			this.A.Name = "pictureBox";
			this.A.Size = new Size(410, 70);
			this.A.TabIndex = 0;
			this.A.TabStop = false;
			this.A.MouseDown += new MouseEventHandler(this.A);
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.A.DialogResult = DialogResult.Cancel;
			this.A.Location = new Point(347, 373);
			this.A.Name = "btnOk";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 1;
			this.A.Text = "Schließen";
			this.A.UseVisualStyleBackColor = true;
			this.A.AutoSize = true;
			this.A.Location = new Point(21, 76);
			this.A.Name = "label";
			this.A.Size = new Size(66, 13);
			this.A.TabIndex = 2;
			this.A.Text = "<about info>";
			this.A.BackColor = Color.White;
			this.A.Controls.Add(this.A);
			this.A.Dock = DockStyle.Top;
			this.A.Location = new Point(0, 0);
			this.A.Name = "whiteBackPanel";
			this.A.Size = new Size(434, 72);
			this.A.TabIndex = 3;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			base.ClientSize = new Size(434, 408);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AboutBox";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Info über ";
			((ISupportInitialize)this.A).EndInit();
			this.A.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
	public class j1
	{
		private static Assembly A = Assembly.GetAssembly(typeof(j1));
		private static Z1 A = new Z1(j1.E());
		public static string A()
		{
			return j1.a() + "-" + j1.A().ToString();
		}
		public static string a()
		{
			return ((AssemblyTitleAttribute)j1.A.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
		}
		public static string B()
		{
			return ((AssemblyDescriptionAttribute)j1.A.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description;
		}
		public static string b()
		{
			return ((AssemblyConfigurationAttribute)j1.A.GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false)[0]).Configuration;
		}
		public static string C()
		{
			return ((AssemblyCompanyAttribute)j1.A.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0]).Company;
		}
		public static string c()
		{
			return ((AssemblyProductAttribute)j1.A.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
		}
		public static string D()
		{
			return ((AssemblyCopyrightAttribute)j1.A.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
		}
		public static string d()
		{
			return ((AssemblyTrademarkAttribute)j1.A.GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false)[0]).Trademark;
		}
		public static string E()
		{
			return ((AssemblyFileVersionAttribute)j1.A.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)[0]).Version;
		}
		public static string e()
		{
			return j1.A.GetModules()[0].FullyQualifiedName;
		}
		public static string F()
		{
			string format = "{0}  Version {1}\nEin Service des {3}.\n{2}. Alle Rechte vorbehalten.";
			return string.Format(format, new object[]
			{
				j1.a(),
				j1.E(),
				j1.D(),
				j1.h()
			});
		}
		public static string f()
		{
			string format = "{0} Version {1}\n{2}\n\nMit '{0}' können Sie symbolische Programmablaufpläne (PAP)\nangelehnt an die DIN 66001 gestalten. Konzipieren Sie Abläufe\nin der Programmierung oder visualisieren Sie beliebige\nVerfahrensanweisungen für z.B. Benutzerhandbücher.\n\n'{0}' ist aus meinem Lehrerwunsch heraus entstanden, ein didaktisch\nwirksames Werkzeug im Programmierunterricht anbieten zu können, welches\nein Grundverständnis der Strukturierten Programmierung fördert.\n- Die Symbole sind nach Funktionsaspekten farbig gestaltet.\n- Eine Projektdatei enthält alle Diagramme zu einer Aufgabenstellung.\n- Unterprogrammstruktur wird gezielt unterstützt.\n- Das Werkzeug hilft bei der graphischen Anordnung der Symbole.\n- Eingebaute Tutorial-Projekte fördern den Lernprozess.\n\n'{0}' ist zum Lernen gedacht und im Rahmen nicht kommerzieller\nZwecke für alle Freunde des {3} privat frei\nnutzbar. Modifikation, Verteilung und Vertrieb der Software ist nicht zulässig.\nAlle Rechte vorbehalten. Für den Einsatz der Software erfolgt keine Gewähr.\n\nfriedrich.folkmann@gmx.de\nLehrer am {3}";
			return string.Format(format, new object[]
			{
				j1.a(),
				j1.E(),
				j1.D(),
				j1.h()
			});
		}
		public static string G()
		{
			return "http://de.wikipedia.org/wiki/Programmablaufplan";
		}
		public static string g()
		{
			return "http://www.gso-koeln.de/papdesigner";
		}
		public static string H()
		{
			return "http://www.gso-koeln.de";
		}
		public static string h()
		{
			return "Georg-Simon-Ohm Berufskolleg in Köln";
		}
		public static bool A()
		{
			string text = string.Concat(new string[]
			{
				j1.f(),
				j1.A(),
				j1.C(),
				j1.b(),
				j1.D(),
				j1.B(),
				j1.E(),
				j1.H(),
				j1.h(),
				j1.g(),
				j1.c(),
				j1.F(),
				j1.a(),
				j1.d(),
				j1.G()
			});
			return !(new o(text).ToString() != "EAB0CA152F25E65C");
		}
		public static Z1 A()
		{
			return j1.A;
		}
	}
}
