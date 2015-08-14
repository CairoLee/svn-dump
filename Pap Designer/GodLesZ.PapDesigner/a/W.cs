using c;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class W : Form
	{
		private bool A;
		private V A;
		private IContainer A;
		private Label A;
		private TextBox A;
		private Button A;
		private Label a;
		private TextBox a;
		private Button a;
		private CheckBox A;
		private W() : this(null)
		{
		}
		private W(V v)
		{
			this.A = v;
			this.A();
			this.Font = d2.a().Font;
			this.A = V.a(v, null);
			if (!this.A)
			{
				this.a.Visible = false;
				this.a.Visible = false;
			}
			this.a(null, null);
			this.B(null, null);
		}
		public static bool A(ref V ptr)
		{
			W w = new W();
			W expr_07 = w;
			expr_07.Text += " (optional)";
			if (w.ShowDialog() == DialogResult.OK)
			{
				ptr = w.A;
				return true;
			}
			return false;
		}
		public static bool A(V v)
		{
			if (V.a(v, new V("")))
			{
				return true;
			}
			W w = new W(v);
			return w.ShowDialog() == DialogResult.OK;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			this.A.Focus();
		}
		private void a(object obj, EventArgs eventArgs)
		{
			char passwordChar = this.A.Checked ? '*' : '\0';
			this.A.PasswordChar = passwordChar;
			this.a.PasswordChar = passwordChar;
		}
		private void B(object obj, EventArgs eventArgs)
		{
			bool enabled;
			if (this.A)
			{
				int length = this.A.Text.Length;
				enabled = ((length == 0 || length >= 3) && this.A.Text == this.a.Text);
			}
			else
			{
				enabled = V.a(this.A, new V(this.A.Text));
			}
			this.A.Enabled = enabled;
		}
		private void b(object obj, EventArgs eventArgs)
		{
			this.A = new V(this.A.Text);
			base.DialogResult = DialogResult.OK;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(W));
			this.A = new Label();
			this.A = new TextBox();
			this.A = new Button();
			this.a = new Label();
			this.a = new TextBox();
			this.a = new Button();
			this.A = new CheckBox();
			base.SuspendLayout();
			this.A.AutoSize = true;
			this.A.Location = new Point(12, 15);
			this.A.Name = "lbPassword";
			this.A.Size = new Size(52, 13);
			this.A.TabIndex = 1;
			this.A.Text = "Kennwort";
			this.A.Location = new Point(134, 12);
			this.A.Name = "tbPassword";
			this.A.Size = new Size(169, 20);
			this.A.TabIndex = 2;
			this.A.TextChanged += new EventHandler(this.B);
			this.A.Location = new Point(147, 75);
			this.A.Name = "btnOk";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 5;
			this.A.Text = "OK";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.b);
			this.a.AutoSize = true;
			this.a.Location = new Point(12, 41);
			this.a.Name = "lbRepeat";
			this.a.Size = new Size(115, 13);
			this.a.TabIndex = 3;
			this.a.Text = "Kennwortwiederholung";
			this.a.Location = new Point(134, 38);
			this.a.Name = "tbRepeat";
			this.a.Size = new Size(169, 20);
			this.a.TabIndex = 4;
			this.a.TextChanged += new EventHandler(this.B);
			this.a.DialogResult = DialogResult.Cancel;
			this.a.Location = new Point(228, 75);
			this.a.Name = "btnCancel";
			this.a.Size = new Size(75, 23);
			this.a.TabIndex = 6;
			this.a.Text = "Abbrechen";
			this.a.UseVisualStyleBackColor = true;
			this.A.AutoSize = true;
			this.A.Checked = true;
			this.A.CheckState = CheckState.Checked;
			this.A.Location = new Point(12, 79);
			this.A.Name = "cbHideChars";
			this.A.Size = new Size(115, 17);
			this.A.TabIndex = 0;
			this.A.Text = "verdeckt eingeben";
			this.A.UseVisualStyleBackColor = true;
			this.A.CheckedChanged += new EventHandler(this.a);
			base.AcceptButton = this.A;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.a;
			base.ClientSize = new Size(315, 113);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "PasswordDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Passwort eingeben";
			base.Shown += new EventHandler(this.A);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
	public class w : Form
	{
		private K1 A;
		private IContainer A;
		private CheckBox A;
		private CheckBox a;
		private Button A;
		private Button a;
		private CheckBox B;
		private CheckBox b;
		private CheckBox C;
		private CheckBox c;
		private ToolTip A;
		private CheckBox D;
		private CheckBox d;
		public w()
		{
			this.B();
			this.Font = d2.a().Font;
			H.A(this.A);
			this.A = K1.A();
			this.A();
			base.Layout += new LayoutEventHandler(this.A);
		}
		private void A()
		{
			this.A.Checked = this.A.A().AllowMultipleProjects;
			this.B.Checked = this.A.A().AllowMultipleTutorials;
			this.a.Checked = this.A.A().KeepBackupFiles;
			this.b.Checked = this.A.A().SmartConnectionDClick;
			this.c.Checked = this.A.A().ToolCursorExitOnLeave;
			this.C.Checked = this.A.A().PreferredSymbolLanguageEnglish;
			this.D.Checked = this.A.A().SeparatePrintPageScaling;
			this.d.Checked = this.A.A().UseNarrowTextFont;
			this.a.Enabled = !this.A.A().ConfigFileReadOnly;
		}
		private void a()
		{
			this.A.A().AllowMultipleProjects = this.A.Checked;
			this.A.A().AllowMultipleTutorials = this.B.Checked;
			this.A.A().KeepBackupFiles = this.a.Checked;
			this.A.A().SmartConnectionDClick = this.b.Checked;
			this.A.A().ToolCursorExitOnLeave = this.c.Checked;
			this.A.A().PreferredSymbolLanguageEnglish = this.C.Checked;
			this.A.A().SeparatePrintPageScaling = this.D.Checked;
			this.A.A().UseNarrowTextFont = this.d.Checked;
		}
		private void A(object obj, LayoutEventArgs layoutEventArgs)
		{
			int x = this.a.Location.X;
			base.Width += this.A.Right + x - base.ClientSize.Width;
			base.Height += this.A.Bottom + x - base.ClientSize.Height;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			this.a();
			this.A();
		}
		private void a(object obj, EventArgs eventArgs)
		{
			this.A.B();
			this.A();
			this.A.A().SuppressConfigStorageOnce = true;
			this.a.Enabled = false;
		}
		private void B(object obj, EventArgs eventArgs)
		{
			base.DialogResult = DialogResult.OK;
		}
		private void A(object obj, FormClosedEventArgs formClosedEventArgs)
		{
			if (global::c.C.A() != this.A.A().UseNarrowTextFont)
			{
				global::c.C.A(this.A.A().UseNarrowTextFont);
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
		private void B()
		{
			this.A = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(w));
			this.A = new CheckBox();
			this.a = new CheckBox();
			this.A = new Button();
			this.a = new Button();
			this.B = new CheckBox();
			this.b = new CheckBox();
			this.C = new CheckBox();
			this.c = new CheckBox();
			this.A = new ToolTip(this.A);
			this.D = new CheckBox();
			this.d = new CheckBox();
			base.SuspendLayout();
			this.A.AutoSize = true;
			this.A.Location = new Point(12, 12);
			this.A.Name = "cbMultipleProjects";
			this.A.Size = new Size(234, 17);
			this.A.TabIndex = 1;
			this.A.Text = "Mehrere Projekte gleichzeitig öffnen möglich";
			this.A.SetToolTip(this.A, "Beim Öffnen oder Anlegen eines Projektes bleibt das vorher aktuelle Projekt weiterhin geöffnet");
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.A);
			this.a.AutoSize = true;
			this.a.Location = new Point(12, 68);
			this.a.Name = "cbKeepBackupFiles";
			this.a.Size = new Size(300, 17);
			this.a.TabIndex = 3;
			this.a.Text = "Sicherungsdatein beim Speichern von Projekten erzeugen";
			this.A.SetToolTip(this.a, "Beim Speichern eines Dokumentes bleibt die ursprüngliche Version als Sicherungsdatei erhalten");
			this.a.UseVisualStyleBackColor = true;
			this.a.Click += new EventHandler(this.A);
			this.A.DialogResult = DialogResult.Cancel;
			this.A.Location = new Point(277, 240);
			this.A.Name = "btnClose";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 0;
			this.A.Text = "Schließen";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.B);
			this.a.Location = new Point(12, 240);
			this.a.Name = "btnResetUserSettings";
			this.a.Size = new Size(202, 23);
			this.a.TabIndex = 9;
			this.a.Text = "Benutzereinstellungen zurücksetzen";
			this.A.SetToolTip(this.a, "Alle perönlichen Einstellungen werden auf Standardwerte zurückgesetzt");
			this.a.UseVisualStyleBackColor = true;
			this.a.Click += new EventHandler(this.a);
			this.B.AutoSize = true;
			this.B.Location = new Point(12, 35);
			this.B.Name = "cbMultipleTutorials";
			this.B.Size = new Size(235, 17);
			this.B.TabIndex = 2;
			this.B.Text = "Mehrere Tutorials gleichzeitig öffnen möglich";
			this.A.SetToolTip(this.B, "Beim Öffnen eines Tutorials bleibt das vorher aktuelle Tutorial weiterhin geöffnet");
			this.B.UseVisualStyleBackColor = true;
			this.B.Click += new EventHandler(this.A);
			this.b.AutoSize = true;
			this.b.Location = new Point(12, 203);
			this.b.Name = "cbSmartConnDClick";
			this.b.Size = new Size(330, 17);
			this.b.TabIndex = 8;
			this.b.Text = "Links-Klick auf Verbindungsabschnitt sucht Abschnitt am Symbol";
			this.A.SetToolTip(this.b, "Verfolgt eine Verbindungslinie bis zum Quellsymbol und selektiert dort den betreffenden Verbindungsabschnitt");
			this.b.UseVisualStyleBackColor = true;
			this.b.Click += new EventHandler(this.A);
			this.C.AutoSize = true;
			this.C.Location = new Point(12, 101);
			this.C.Name = "cbPrefSymlLangEnglish";
			this.C.Size = new Size(215, 17);
			this.C.TabIndex = 4;
			this.C.Text = "Bevorzugte Symboltextsprache Englisch";
			this.A.SetToolTip(this.C, "Sieht Englisch als Standardeinstellung für die festen Symboltexte von neu erstellten Diagrammen vor");
			this.C.UseVisualStyleBackColor = true;
			this.C.Click += new EventHandler(this.A);
			this.c.AutoSize = true;
			this.c.Location = new Point(12, 180);
			this.c.Name = "cbToolCursorExitOnLeave";
			this.c.Size = new Size(313, 17);
			this.c.TabIndex = 7;
			this.c.Text = "Einfügemodus beenden wenn Mauszeiger Diagramm verlässt";
			this.A.SetToolTip(this.c, "Der Einfügemodus beim Einfügen von Symbolen oder aus der Zwischenablage wird verlassen, wenn der Mauszeiger das Diagramm verlässt");
			this.c.UseVisualStyleBackColor = true;
			this.c.Click += new EventHandler(this.A);
			this.D.AutoSize = true;
			this.D.Location = new Point(12, 124);
			this.D.Name = "cbSeparatePrintPageScaling";
			this.D.Size = new Size(177, 17);
			this.D.TabIndex = 5;
			this.D.Text = "Druckseiten individuell skalieren";
			this.A.SetToolTip(this.D, "Führt zu unterschiedlichen Maßstäben der einzelnen Druckseiten");
			this.D.UseVisualStyleBackColor = true;
			this.D.Click += new EventHandler(this.A);
			this.D.CheckedChanged += new EventHandler(this.A);
			this.d.AutoSize = true;
			this.d.Location = new Point(12, 147);
			this.d.Name = "cbUseNarrowTextFont";
			this.d.Size = new Size(213, 17);
			this.d.TabIndex = 6;
			this.d.Text = "Schmale Diagrammschriftart verwenden";
			this.A.SetToolTip(this.d, "Verwendet eine schmale Schriftart für die Diagrammsymbole");
			this.d.UseVisualStyleBackColor = true;
			this.d.Click += new EventHandler(this.A);
			base.AcceptButton = this.A;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.A;
			base.ClientSize = new Size(364, 275);
			base.ControlBox = false;
			base.Controls.Add(this.D);
			base.Controls.Add(this.C);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.c);
			base.Controls.Add(this.d);
			base.Controls.Add(this.b);
			base.Controls.Add(this.a);
			base.Controls.Add(this.B);
			base.Controls.Add(this.A);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SettingsDialog";
			base.ShowInTaskbar = false;
			this.Text = "Einstellungen";
			base.FormClosed += new FormClosedEventHandler(this.A);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
