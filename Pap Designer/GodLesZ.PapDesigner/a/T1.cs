using d;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public interface T1 : s1, IDisposable
	{
		Rectangle h();
		Point I();
		void i(Point);
		float J();
		void j(float);
		bool K();
		void k();
	}
	public class t1 : Form
	{
		private static Size? A = null;
		private Color A = SystemColors.Window;
		private W1<p1> A;
		private s1 A;
		private d.B A;
		private IContainer A;
		private Button A;
		private Button a;
		private Label A;
		private ListBox A;
		private Label a;
		private TextBox A;
		private CheckBox A;
		private ToolTip A;
		public t1(s1 s, string text, d.B b, W1<p1> w)
		{
			this.A();
			this.Font = d2.a().Font;
			H.A(this.A);
			H.A(this.A, this.A, this.A);
			H.A(this.A, this.A, this.a);
			this.A = s;
			this.A = b;
			this.A = w;
			this.A.MaxLength = 64;
			this.A = this.A.BackColor;
			this.Text = text;
			this.A.Text = o1.b(b.c());
			if (w != null)
			{
				foreach (p1 current in w)
				{
					this.A.Items.Add(current.b());
				}
			}
			if (t1.A.HasValue)
			{
				base.Size = t1.A.Value;
			}
			this.a();
		}
		public bool A()
		{
			return this.A.Checked;
		}
		public void A(bool @checked)
		{
			this.A.Checked = @checked;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			e2 e = this.A as e2;
			if (e != null)
			{
				u.A(this, e.RectangleToScreen(e.L(this.A.E())));
			}
		}
		private void a(object obj, EventArgs eventArgs)
		{
			this.A.Height = this.A.Top - this.A.Top - 2;
		}
		private void B(object obj, EventArgs eventArgs)
		{
			if (this.A.SelectedIndex >= 0)
			{
				this.A.Text = this.A.Items[this.A.SelectedIndex].ToString();
			}
		}
		private void b(object obj, EventArgs eventArgs)
		{
			this.a();
		}
		private void A(object obj, CancelEventArgs cancelEventArgs)
		{
			cancelEventArgs.Cancel = !this.A(this.A.Text, true);
			this.A((Control)obj, cancelEventArgs.Cancel);
		}
		private void C(object obj, EventArgs eventArgs)
		{
			TextBox textBox = (TextBox)obj;
			textBox.Text = o1.b(textBox.Text);
		}
		private void c(object obj, EventArgs eventArgs)
		{
			if (this.a() && this.A(this.A.Text, false))
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		private void A(object obj, FormClosingEventArgs formClosingEventArgs)
		{
			t1.A = new Size?(base.Size);
		}
		private void A(Control control, bool flag)
		{
			control.BackColor = (flag ? k1.A : this.A);
			if (flag)
			{
				control.Focus();
			}
		}
		private bool a()
		{
			bool result = this.ValidateChildren();
			int num = -1;
			string text = o1.b(this.A.Text);
			for (int i = 0; i < this.A.Items.Count; i++)
			{
				if (Q1.A(text, this.A.Items[i].ToString()))
				{
					num = i;
					break;
				}
			}
			string text2 = this.A.Text;
			this.A.SelectedIndex = num;
			this.A.Text = text2;
			this.A.Enabled = (num == -1 && this.A.A(text));
			if (!this.A.Enabled)
			{
				this.A.Checked = false;
			}
			this.A.Enabled = (text.Length > 0);
			return result;
		}
		private bool A(string text, bool flag)
		{
			string text2 = o1.b(text);
			if (flag)
			{
				return true;
			}
			this.A.D(text2);
			return true;
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
			this.A = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(t1));
			this.A = new Button();
			this.a = new Button();
			this.A = new Label();
			this.A = new ListBox();
			this.a = new Label();
			this.A = new TextBox();
			this.A = new CheckBox();
			this.A = new ToolTip(this.A);
			base.SuspendLayout();
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.A.Location = new Point(124, 140);
			this.A.Name = "btnOk";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 5;
			this.A.Text = "OK";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.c);
			this.a.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.a.DialogResult = DialogResult.Cancel;
			this.a.Location = new Point(205, 140);
			this.a.Name = "btnCancel";
			this.a.Size = new Size(75, 23);
			this.a.TabIndex = 6;
			this.a.Text = "Abbrechen";
			this.a.UseVisualStyleBackColor = true;
			this.A.AutoSize = true;
			this.A.Location = new Point(12, 11);
			this.A.Name = "lbTitle";
			this.A.Size = new Size(27, 13);
			this.A.TabIndex = 0;
			this.A.Text = "Titel";
			this.A.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.A.FormattingEnabled = true;
			this.A.IntegralHeight = false;
			this.A.Location = new Point(65, 34);
			this.A.Name = "lbxChoice";
			this.A.Size = new Size(215, 77);
			this.A.TabIndex = 3;
			this.A.SetToolTip(this.A, "Auswahl an bereits bestehenden Unterprogrammen, die dieses Symbol repräsentieren kann");
			this.A.SelectedIndexChanged += new EventHandler(this.B);
			this.a.AutoSize = true;
			this.a.Location = new Point(12, 34);
			this.a.Name = "lbChoice";
			this.a.Size = new Size(47, 13);
			this.a.TabIndex = 2;
			this.a.Text = "Auswahl";
			this.A.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.A.Location = new Point(65, 8);
			this.A.Name = "tbTitle";
			this.A.Size = new Size(215, 20);
			this.A.TabIndex = 1;
			this.A.SetToolTip(this.A, "Titel des Symbols und des Unterprogramms, welches durch das Sybol repräsentiert wird");
			this.A.Leave += new EventHandler(this.C);
			this.A.Validating += new CancelEventHandler(this.A);
			this.A.TextChanged += new EventHandler(this.b);
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.A.AutoSize = true;
			this.A.Location = new Point(65, 117);
			this.A.Name = "cbCreateNewDgm";
			this.A.Size = new Size(180, 17);
			this.A.TabIndex = 7;
			this.A.Text = "Neues Diagramm dazu erzeugen";
			this.A.SetToolTip(this.A, "Erzeugt bei 'Ok' ein neues Diagramm passend zum gewählten Symboltitel und öffnet es direkt");
			this.A.UseVisualStyleBackColor = true;
			base.AcceptButton = this.A;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoValidate = AutoValidate.EnableAllowFocusChange;
			base.CancelButton = this.a;
			base.ClientSize = new Size(292, 174);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new Size(550, 320);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(300, 200);
			base.Name = "ModuleEditDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Unterprogramm bearbeiten";
			base.Shown += new EventHandler(this.a);
			base.FormClosing += new FormClosingEventHandler(this.A);
			base.Load += new EventHandler(this.A);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
